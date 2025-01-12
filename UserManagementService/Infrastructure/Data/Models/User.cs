using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialPolitics.UserManagementService.Infrastructure.Data.Models
{
    public class User
    {
        [BsonId] // Marks this property as the MongoDB _id field
        [BsonRepresentation(BsonType.ObjectId)] // Treats _id as an ObjectId in MongoDB
        public string Id { get; set; } // Maps MongoDB's _id field to this property

        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public string Constituency { get; set; }
        public string AadhaarNumber { get; set; }
        public string PANNumber { get; set; }
        public string VoterID { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string ProfilePicture { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
