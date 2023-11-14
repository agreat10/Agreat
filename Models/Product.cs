using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agreat.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1,100000)]
        public double Price { get; set; }

        public string Image { get; set; }

        [Display(Name ="Тип категории")]
        public int CategoryId { get; set; }

        [ForeignKey("CategotyId")]
        public virtual Category Category { get; set; }
    }
}
