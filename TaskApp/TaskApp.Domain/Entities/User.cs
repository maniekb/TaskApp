namespace TaskApp.Domain.Entities
{
    public class User
    {
        public int UserId { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User()
        {
        }

        public User(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
