using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TaskManagerMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must specify username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "You must specify password")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 4 and 100 characters long!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
           /* get { return Password; }
            set {
                using (var sha = new SHA512CryptoServiceProvider())
                {
                    var data = Encoding.ASCII.GetBytes(value);
                    var shadata = sha.ComputeHash(data);
                    Password = shadata.ToString();
                }
            } 
        }*/
        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
            /*get { return this.ConfirmPassword; }
            set
            {
                using (var sha = new SHA512CryptoServiceProvider())
                {
                    var data = Encoding.ASCII.GetBytes(value);
                    var shadata = sha.ComputeHash(data);
                    ConfirmPassword = shadata.ToString();
                }
            }
        }*/
    }
}