namespace DPEP.Common.DAL.Model
{
    public class AccountModel : Captcha
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string ReferenceCode { get; set; }
    }
}
