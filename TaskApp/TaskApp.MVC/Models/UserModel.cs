using System.ComponentModel.DataAnnotations;

namespace TaskApp.MVC.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string FullName => Firstname + " " + Lastname;
    }
}
