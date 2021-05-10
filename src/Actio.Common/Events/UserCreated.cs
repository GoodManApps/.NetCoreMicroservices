namespace Actio.Common.Events
{
    public class UserCreated : IEvent
    {
        public string Email { get; }
        public string UserName { get; }

        protected UserCreated() { }

        public UserCreated(string email, string userName)
        {
            this.Email = email;
            this.UserName = userName;

        }
    }
}