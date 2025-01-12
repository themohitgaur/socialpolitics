namespace SocialPolitics.UserManagementService.Api.ApiModels;

public class RegisterRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string Password { get; set; }
    public string Constituency { get; set; }
    public string AadhaarNumber { get; set; }
    public string PANNumber { get; set; }
    public string VoterID { get; set; }
    public string ProfilePicture { get; set; }
}
