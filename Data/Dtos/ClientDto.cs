using System.ComponentModel.DataAnnotations;

namespace Innovative.Backend.Data.Dtos
{
    
    public class ListingClientDo : AddClientDto
    {
        public int Id { get; set; }
    }
    public class UpdateClientDto : AddClientDto
    {
        public int Id { get; set; }
    }
    public class AddClientDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }
        [Required]
        public string? HomeAddress { get; set; }
    }
}
