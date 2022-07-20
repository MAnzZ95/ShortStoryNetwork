using ShortStoryNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.IServices
{
    public interface IUserInfo
    {
        Task<UserInfo> addEditUser(UserInfo oUser);

        Task<IEnumerable<UserInfo>> getAllUsers();
        Task<UserInfo> getUserbyId(int UserId);

        Task<UserInfo> DeleteUser(int UserId);

        Task<UserInfo> isEmailExists(string email);
    }
}
