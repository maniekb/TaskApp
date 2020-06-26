using System.Collections.Generic;

namespace TaskApp.MVC.Models
{
    public class EditModel
    {
        public TaskGroupModel TaskGroup { get; set; }
        public UserTaskModel UserTask { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
