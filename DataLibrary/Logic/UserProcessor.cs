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
            string sql = @"insert into dbo.Users (Username, Password, Salt) values (@Username, @Password, @Salt);";
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
