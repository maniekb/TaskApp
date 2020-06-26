using System.ComponentModel.DataAnnotations;

namespace TaskApp.MVC.Models
{
    public class IndexModel
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int UserTasksCount { get; set; }
    }
}
