using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCollege.SSO.Data.Entities
{
    public class RepresentationOfTheCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string MiddleName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = string.Empty;

        public string Company { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public AccountIdentity Account { get; set; } = null!;
    }
}
