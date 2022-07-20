using Dapper;
using ShortStoryNetwork.Context;
using ShortStoryNetwork.IServices;
using ShortStoryNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.Services
{
    public class UserInfoService : IUserInfo
    {
        private readonly DBContext _context;

        public UserInfoService(DBContext context)
        {
            _context = context;
        }

        UserInfo _oUserInfo = new UserInfo();

        public async Task<UserInfo> addEditUser(UserInfo oUser)
        {
            var spName = "usp_CRUDUserInfo";
            using (var connection = _context.CreateConnection())
            {


                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "E");
                para.Add("@UserId", oUser.UserId);
                para.Add("@PasswordHash", oUser.PasswordHash);
                para.Add("@FirstName", oUser.FirstName);
                para.Add("@LastName", oUser.LastName);
                para.Add("@EmailAddress", oUser.EmailAddress);
                para.Add("@UserRole", oUser.UserRole);
                para.Add("@IsEditor", oUser.IsEditor);
                para.Add("@IsBanned", oUser.IsBanned);


                var result = await connection.QueryAsync<UserInfo>
                    (spName, para, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<UserInfo> DeleteUser(int UserId)
        {

                var spName = "usp_CRUDUserInfo";
                using (var connection = _context.CreateConnection())
                {


                    connection.Open();
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@ACTION", "D");
                    para.Add("@UserId", UserId);


                    var user = await connection.QueryAsync<UserInfo>
                        (spName, para, commandType: CommandType.StoredProcedure);
                    return user.FirstOrDefault();

                }
        }

        public async Task<IEnumerable<UserInfo>> getAllUsers()
        {
            var spName = "usp_CRUDUserInfo";
            using (var connection = _context.CreateConnection())
            {


                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "A");
                
                var user = await connection.QueryAsync<UserInfo>
                    (spName, para, commandType: CommandType.StoredProcedure);
                return user.ToList();

            }
        }

        public async Task<UserInfo> getUserbyId(int UserId)
        {
            var spName = "usp_CRUDUserInfo";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "G");
                para.Add("@EmployeeID", UserId);
                //var employees = await connection.QueryAsync<Employee>(qr);
                //return employees.ToList();

                var user = await connection.QueryAsync<UserInfo>
                    (spName, para, commandType: CommandType.StoredProcedure);
                return user.FirstOrDefault();

            }
        }

        public async Task<UserInfo> isEmailExists(string email)
        {
            var spName = "usp_CRUDUserInfo";
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                DynamicParameters para = new DynamicParameters();
                para.Add("@ACTION", "EXISTS");
                para.Add("@EmailAddress", email);
                //var employees = await connection.QueryAsync<Employee>(qr);
                //return employees.ToList();

                var user = await connection.QueryAsync<UserInfo>
                    (spName, para, commandType: CommandType.StoredProcedure);
                return user.FirstOrDefault();

            }
        }
    }
}
