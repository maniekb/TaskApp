using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskApp.MVC.Models
{
    public class TaskGroupModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<UserTaskModel> UserTasks { get; set; }
    }
}
