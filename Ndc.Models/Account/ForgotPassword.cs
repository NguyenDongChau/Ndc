namespace Ndc.Models.Account
{
    public class ForgotPassword
    {
        public string Email { get; set; }
        public string UserToken { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
