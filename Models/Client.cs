using Innovative.Backend.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Innovative.Backend.Models
{
    public class Client: BaseEntity<int>
    {
        public string? Name { get; set; }
        public int PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string? Email { get; set; }
        public string? HomeAddress { get; set; }
    }
}
