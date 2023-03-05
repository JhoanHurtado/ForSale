using System.ComponentModel.DataAnnotations;

namespace Users.Entity.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public Int64 IdentifyNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
    }
}