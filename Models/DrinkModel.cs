using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drink.Infrastructure.Models
{
    public class DrinkModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int Volume { get; set; }

        public ICollection<EspressoModel> Espressos { get; set; } = new List<EspressoModel>();
    }
}