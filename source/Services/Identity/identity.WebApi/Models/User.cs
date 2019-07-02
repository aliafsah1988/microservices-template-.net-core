namespace Identity.WebApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
