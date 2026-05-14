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
    }
}