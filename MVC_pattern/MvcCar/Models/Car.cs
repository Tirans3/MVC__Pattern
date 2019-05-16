using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCar.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name ="Release Data")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Color { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
