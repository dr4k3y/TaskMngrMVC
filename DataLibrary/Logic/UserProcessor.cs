using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.Logic
{
    public static class UserProcessor
    {
        public static int CreateUser(string userName, string userPassword)
        {
            string check = "select * from dbo.Users where Username=@Username";
            byte[] password;
            byte[] salt = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(salt);
            }
            using (var sha = new SHA512CryptoServiceProvider())
            {
                var hashdata = Encoding.ASCII.GetBytes(userPassword).Concat(salt).ToArray<byte>();

                var shadata = sha.ComputeHash(hashdata);
                password = shadata;
            }
            UserModel data = new UserModel
            {
                Username = userName,
                Password=password,
                Salt=salt
            };
            int i = SqlDataAccess.LoadData<UserModel>(check, data).Count;
            if (i == 0)
            {
                string sql = @"insert into dbo.Users (Username, Password, Salt) values (@Username, @Password, @Salt);";
                return SqlDataAccess.SaveData(sql, data);
            }
            else
            {
                return 0;
            }
        }
        public static int AuthenticateUser(string userName, string userPassword)
        {
            byte[] passwordHash;
            byte[] salt;
            string find = "select * from dbo.Users where Username=@Username";
            List<UserModel> user;
            UserModel data = new UserModel
            {
                Username=userName,
            };
            user = SqlDataAccess.LoadData(find, data);
            if (user.Count() != 0)
            {
                salt = user[0].Salt;
                using (var sha = new SHA512CryptoServiceProvider())
                {
                    var hashdata = Encoding.ASCII.GetBytes(userPassword).Concat(salt).ToArray<byte>();

                    var shadata = sha.ComputeHash(hashdata);
                    passwordHash = shadata;
                }
                if (passwordHash.SequenceEqual(user[0].Password))
                {
                    return user[0].Id;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
