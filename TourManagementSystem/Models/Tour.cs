using System.ComponentModel.DataAnnotations;

namespace TourManagementSystem.Models
{
    // Main model representing a travel tour
    public class Tour
    {
        // Primary key
        public int Id { get; set; }


        // Tour title
        [Required]
        public string Name { get; set; } = "";


        // Travel destination
        [Required]
        public string Destination { get; set; } = "";


        // Tour price in euros
        [Range(1, 10000)]
        public decimal Price { get; set; }


        // Tour description
        [Required]
        public string Description { get; set; } = "";


        // Visual emoji icon for the tour
        public string Emoji { get; set; } = "✈️";


        // Duration of the tour in days
        public int DurationDays { get; set; } = 7;


        // Tour region
        public string Region { get; set; } = "Europe";


        // Average rating from users
        public double Rating { get; set; } = 5.0;


        // Number of reviews
        public int RewiewCount { get; set; } = 0;


        // Relationship with bookings
        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();
    }
}
