namespace SocialPolitics.Core;
public class JwtSettings
{
    public String Issuer { get; set; }
    public String Audience { get; set; }
    public String SecretKey { get; set; }
}
