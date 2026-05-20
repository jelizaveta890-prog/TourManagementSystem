using System.ComponentModel.DataAnnotations;

namespace TourManagementSystem.Models
{
    public class Booking
    {
        // Id (primary key)
        public int Id { get; set; }

        // ClientName (required)
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        // Email (required, valid email format)
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Display(Name  = "Email")]
        public string Email { get; set; }

        // TourId (foreign key to Tour)
        [Required(ErrorMessage = "Please enter your number of seats")]
        [Range(1, 20, ErrorMessage = "Between 1 and 20 seats")]
        [Display(Name = "Number of seats")]
        public string Seats { get; set; }

        // TourId (foreign key to Tour)
        [Required(ErrorMessage = "Please select a tour")]
        [Display(Name = "Tour")]
        public int TourId { get; set; }
        public Tour? Tour { get; set; }
    }
}
