using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MauiLib3._1.Models
{
    public class EspressoModel
    {
        [Key]
        public int Id { get; set; }

        public int Coffee { get; set; }
        public int SmallCup { get; set; }

        // Foreign key
        public Guid DrinkId { get; set; }

        // Навігаційна властивість
        [ForeignKey("DrinkId")]
        public DrinkModel? Drink { get; set; } 
    }
}
