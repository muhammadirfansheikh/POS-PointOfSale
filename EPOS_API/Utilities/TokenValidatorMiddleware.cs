using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

namespace EPOS_API.Utilities
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TokenValidatorMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _config;

        public TokenValidatorMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.GetEncodedUrl();
            string[] bipassUrl = { "UserLogin", "UserSignup", "Forgetpassword", "CrudAllCountry", "GetBusinessTypeList", "GetWebOrderAddress", "CrudWebMobileOrder" };
            string[] collection = url.Split('/');


            var result = Array.FindAll(bipassUrl, element => element == collection[collection.Length - 1].Split('?')[0]);

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (result.Length == 0)
            {
                if (token != null)
                {
                    attachAccountToContext(context, token);
                }
                else
                {
                    context.Items["Validate"] = false;
                }
            }
            else
            {
                context.Items["Validate"] = false;
            }

            await _next(context);
        }


        private void attachAccountToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                string key = _config["Jwt:Key"];
                var issuer = _config["Jwt:Issuer"];

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                // var accountId = jwtToken.Claims.First(x => x.Type == "id").Value;

                //attach account to context on successful jwt validation
                context.Items["Validate"] = true;
                //var accountId = jwtToken.Claims.First(x => x.Type == "id").Value;
            }
            catch (Exception ex)
            {
                context.Items["Validate"] = false;
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TokenValidatorMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenValidatorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenValidatorMiddleware>();
        }
    }
}
