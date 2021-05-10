using System.Net;
namespace Actio.Common.Events
{
    public class CreateUserRejected : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateUserRejected() { }

        public CreateUserRejected(string email, string reason, string code)
        {
            this.Email = email;
            this.Code = code;
            this.Reason = reason;
        }
    }
}