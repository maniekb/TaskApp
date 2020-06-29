using System;
using System.ComponentModel.DataAnnotations;

namespace TaskApp.MVC.Models
{
    public class UserTaskModel
    {
        public int UserTaskId { get; set; }
        [Required]
        public int TaskGroupId { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
