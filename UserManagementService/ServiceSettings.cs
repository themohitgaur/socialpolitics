using SocialPolitics.Core.Enums;
namespace SocialPolitics.UserManagementService;

public class ServiceSettings
{
    public DatabaseTypes DatabaseType {  get; set; }    
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; } = "UserManagement";
}
