using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drink.Infrastructure.Models
{
    public class EspressoModel
    {
        [Key]
        public int Id { get; set; }

        public int Coffee { get; set; }

        public int SmallCup { get; set; }

        [ForeignKey("Drink")]
        public Guid DrinkId { get; set; }
        public DrinkModel Drink { get; set; } = null!;
    }
}