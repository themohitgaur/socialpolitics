namespace SocialPolitics.UserManagementService.Api.ApiModels;

public class UserApiModel
{
        public String? UserId { get; set; }
        public String? FullName { get; set; }
        public String? Email { get; set; }
        public String? MobileNumber { get; set; }
        public String? Password { get; set; }
        public String? PasswordHash { get; set; }
        public String? Constituency { get; set; }
        public String? AadhaarNumber { get; set; }
        public String? PANNumber { get; set; }
        public String? VoterID { get; set; }
        public String? ProfilePicture { get; set; }
        public String? Role { get; set; }
        public String? Status { get; set; }
}
