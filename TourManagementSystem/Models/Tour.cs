using System.ComponentModel.DataAnnotations;

namespace TourManagementSystem.Models
{
    public class Tour
    {
        public int Id { get; set; } // Automaatne järjenumber

        [Required]
        public string Name { get; set; } // Reisi nimi

        public string Destination { get; set; } // Sihtkoht

        [Range(1, 10000)]
        public decimal Price { get; set; } // Hind eurodes

        public string Description { get; set; } // Kirjeldus


        //uus (lm)
        public string Emoji { get; set; } //emojiga ikoon
        public int DurationDays { get; set; } //reisi kestus päevades
        public string Region { get; set; } //reisi piirkond
        public double Rating { get; set; } //reisi hinnang 1-5
        public int RewiewCount { get; set; } //arvustuste arv
        //uuenddame siia seose broneeringutega
        public ICollection <Booking > Bookings { get; set; } = new List<Booking>(); // Seos broneeringutega
    }
}