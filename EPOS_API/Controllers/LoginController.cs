using EPOS_API.Data;
using EPOS_API.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using EPOS_API.Model;
using BCryptNet = BCrypt.Net.BCrypt;

namespace EPOS_API.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        MessageDate<dynamic> responseDetail = new MessageDate<dynamic>();
        //int? IntNull = null;
        private static Random random = new Random();
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("UserLogin")]
        public string UserLogin([FromBody] EPOS_API.Model.UserLoginModel obj)
        {
            var response = User_Login(obj.Username, obj.Password, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic User_Login(string UserName, string Password, HttpContext context)
        {
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>();
                parm.Add(new SqlParameter() { ParameterName = "@LoginId", SqlDbType = SqlDbType.NVarChar, Value = UserName });
                // parm.Add(new SqlParameter() { ParameterName = "@Pswd", SqlDbType = SqlDbType.NVarChar, Value = Password });

                var spName = "SP_UserLogin";

                DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
                if (obj_response != null)
                {
                    bool verified = BCrypt.Net.BCrypt.Verify(Password, Convert.ToString(obj_response.Tables[1].Rows[0]["Password"]));
                    if (verified == true)
                    {
                        string Token = GenerateJSONWebToken(Convert.ToString(obj_response.Tables[1].Rows[0]["UserId"]), Convert.ToString(obj_response.Tables[1].Rows[0]["UserName"]));

                        //if(obj_response.Tables[1].Rows[0]["JWT"] == )
                        if (obj_response.Tables[1] != null)
                        {
                            obj_response.Tables[1].Rows[0]["JWT"] = Token;

                            responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                        }
                        else
                        {
                            responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                        }
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }

        [HttpPost("UserLoginAuth")]
        public string UserLoginAuth([FromBody] EPOS_API.Model.UserLoginAuthModel obj)
        {
            var response = User_Login_Auth(obj.Username, obj.Password, obj.BranchId, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private DataSet GetUserPassword(string UserName, string Password)
        {
            List<SqlParameter> parm = new List<SqlParameter>();
            parm.Add(new SqlParameter() { ParameterName = "@LoginId", SqlDbType = SqlDbType.NVarChar, Value = UserName });

            var spName = "SP_UserLogin";

            DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
            return obj_response;
        }

        private dynamic User_Login_Auth(string UserName, string Password, int? BranchId, HttpContext context)
        {
            try
            {
                //List<SqlParameter> parm = new List<SqlParameter>();
                //parm.Add(new SqlParameter() { ParameterName = "@LoginId", SqlDbType = SqlDbType.NVarChar, Value = UserName });
                //// parm.Add(new SqlParameter() { ParameterName = "@Pswd", SqlDbType = SqlDbType.NVarChar, Value = Password });

                //var spName = "SP_UserLogin";

                //DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());

                DataSet obj_response = GetUserPassword(UserName, Password);
                if (obj_response != null)
                {
                    bool verified = BCrypt.Net.BCrypt.Verify(Password, Convert.ToString(obj_response.Tables[1].Rows[0]["Password"]));
                    if (verified == true)
                    {
                        string Token = GenerateJSONWebToken(Convert.ToString(obj_response.Tables[1].Rows[0]["UserId"]), Convert.ToString(obj_response.Tables[1].Rows[0]["UserName"]));

                        if (obj_response.Tables[4] != null)
                        {

                            DataView dv = obj_response.Tables[4].DefaultView;
                            dv.RowFilter = "BranchId = '" + BranchId + "'";
                            DataTable selectedTable = dv.ToTable("dt");

                            if (selectedTable != null && selectedTable.Rows.Count > 0)
                            {
                                DataTable responce = new DataTable("Table");
                                responce = obj_response.Tables[0].AsEnumerable().CopyToDataTable();
                                responce.TableName = "Table";
                                DataSet ds = new DataSet();
                                ds.Tables.Add(responce);

                                responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, ds);
                            }
                            else
                            {
                                responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                            }

                        }
                        else
                        {
                            responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                        }
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }

                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }


        [HttpPost("ChangePassword")]
        public string ChangePassword([FromBody] ChangePasswordModel obj)
        {
            var response = Change_Password(obj, HttpContext);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic Change_Password(ChangePasswordModel obj, HttpContext context)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    DataSet ds = GetUserPassword(obj.UserName, obj.OldPassword);

                    if (ds != null)
                    {
                        bool verified = BCrypt.Net.BCrypt.Verify(obj.OldPassword, Convert.ToString(ds.Tables[1].Rows[0]["Password"]));
                        if (verified == true)
                        {
                            if (obj.NewPassword == obj.ConfirmPassword)
                            {
                                List<SqlParameter> parm = new List<SqlParameter>();
                                parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                                parm.Add(new SqlParameter() { ParameterName = "@NewPassword", SqlDbType = SqlDbType.NVarChar, Value = BCrypt.Net.BCrypt.HashPassword(obj.NewPassword) });

                                var spName = "SP_ChangePassword";

                                DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
                                if (obj_response != null)
                                {
                                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                                }
                                else
                                {
                                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                                }
                            }
                            else
                            {
                                responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, "New password and confirm password is invalid");
                            }
                        }
                        else
                        {
                            responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, "Old password is invalid");
                        }
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.InvalidToken, ResponseMessages.InvalidToken);
                }

                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }


        [HttpPost("ForgetPassword")]
        public string ForgetPassword(string LoginId)
        {
            var randomPass = RandomString(8);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(randomPass);

            var response = Forget_Password(LoginId, randomPass, passwordHash);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic Forget_Password(string LoginId, string randomPass, string passwordHash)
        {
            try
            {

                List<SqlParameter> parm = new List<SqlParameter>();
                parm.Add(new SqlParameter() { ParameterName = "@LoginId", SqlDbType = SqlDbType.NVarChar, Value = LoginId });
                parm.Add(new SqlParameter() { ParameterName = "@PswdEncrypt", SqlDbType = SqlDbType.NVarChar, Value = passwordHash });
                parm.Add(new SqlParameter() { ParameterName = "@Pswd", SqlDbType = SqlDbType.NVarChar, Value = randomPass });

                var spName = "SP_ForgetPassword";

                DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }

        [HttpPost("UserSignup")]
        public string UserSignup([FromBody] EPOS_API.Model.CompanyModel obj)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(GenericConstants.Password);
            var response = userSignup(obj, passwordHash);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic userSignup(EPOS_API.Model.CompanyModel obj, string password)
        {
            try
            {
                List<SqlParameter> parm = new List<SqlParameter>();
                parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                parm.Add(new SqlParameter() { ParameterName = "@CompanyName", SqlDbType = SqlDbType.NVarChar, Value = obj.CompanyName });
                parm.Add(new SqlParameter() { ParameterName = "@NoOfTerminals", SqlDbType = SqlDbType.Int, Value = obj.NoOfTerminals });
                parm.Add(new SqlParameter() { ParameterName = "@BusinessTypeId", SqlDbType = SqlDbType.Int, Value = obj.BusinessTypeId });
                parm.Add(new SqlParameter() { ParameterName = "@CountryId", SqlDbType = SqlDbType.Int, Value = obj.CountryId });
                parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                parm.Add(new SqlParameter() { ParameterName = "@CompanyLogo", SqlDbType = SqlDbType.NVarChar, Value = obj.CompanyLogo });
                parm.Add(new SqlParameter() { ParameterName = "@EmailAddress", SqlDbType = SqlDbType.NVarChar, Value = obj.EmailAddress });
                parm.Add(new SqlParameter() { ParameterName = "@Password", SqlDbType = SqlDbType.NVarChar, Value = password });

                var spName = "SP_SetupCompany";

                DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
                if (obj_response != null)
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }

        [HttpPost("CreateUser")]
        public string CreateUser([FromBody] EPOS_API.Model.UserModel obj)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(GenericConstants.Password);
            var response = createUser(obj, HttpContext, passwordHash);
            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            return json;
        }

        private dynamic createUser(EPOS_API.Model.UserModel obj, HttpContext context, string password)
        {
            try
            {
                if (Convert.ToBoolean(context.Items["Validate"]) == true)
                {
                    List<SqlParameter> parm = new List<SqlParameter>();
                    parm.Add(new SqlParameter() { ParameterName = "@OperationId", SqlDbType = SqlDbType.Int, Value = obj.OperationId });
                    parm.Add(new SqlParameter() { ParameterName = "@CompanyId", SqlDbType = SqlDbType.Int, Value = obj.CompanyId });
                    parm.Add(new SqlParameter() { ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value = obj.Name });
                    parm.Add(new SqlParameter() { ParameterName = "@UserName", SqlDbType = SqlDbType.NVarChar, Value = obj.UserName });
                    parm.Add(new SqlParameter() { ParameterName = "@Password", SqlDbType = SqlDbType.NVarChar, Value = password });
                    parm.Add(new SqlParameter() { ParameterName = "@EmailAddress", SqlDbType = SqlDbType.NVarChar, Value = obj.EmailAddress });
                    parm.Add(new SqlParameter() { ParameterName = "@RoleId", SqlDbType = SqlDbType.Int, Value = obj.RoleId });
                    parm.Add(new SqlParameter() { ParameterName = "@BranchIds", SqlDbType = SqlDbType.NVarChar, Value = obj.BranchIds });
                    parm.Add(new SqlParameter() { ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value = obj.UserId });
                    parm.Add(new SqlParameter() { ParameterName = "@IsActive", SqlDbType = SqlDbType.Bit, Value = obj.IsActive });
                    parm.Add(new SqlParameter() { ParameterName = "@IsEnable", SqlDbType = SqlDbType.Bit, Value = obj.IsEnable });
                    parm.Add(new SqlParameter() { ParameterName = "@UserIP", SqlDbType = SqlDbType.NVarChar, Value = obj.UserIP });
                    parm.Add(new SqlParameter() { ParameterName = "@User_Id", SqlDbType = SqlDbType.Int, Value = obj.User_Id });

                    var spName = "SP_CrudUser";

                    DataSet obj_response = new DapperManager(_config.GetConnectionString("MyConnection")).GetDataSet(spName, parm.ToArray());
                    if (obj_response != null)
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(true, ResponseCodes.Success, ResponseMessages.Success, obj_response);
                    }
                    else
                    {
                        responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Failure, ResponseMessages.Failure);
                    }
                }
                else
                {
                    responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.InvalidToken, ResponseMessages.InvalidToken);
                }
                return responseDetail;
            }
            catch (Exception ex)
            {
                return responseDetail = CommonObjects.GetRepsonsesWithDataSet(false, ResponseCodes.Exception, ex.Message);
            }
        }

        private string GenerateJSONWebToken(string userId, string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Sid, userId),
                //new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(43800),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
