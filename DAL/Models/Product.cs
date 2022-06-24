using DAL.Base;
using DAL.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Product : BaseEntity, IEntity
    {
        [Required, MaxLength(255, ErrorMessage = "Name must be less than 255 chars")]
        public string Name { get; set; }
        [Required, Range(1, 5000, ErrorMessage = "Price is between 1-5000$")]
        public double Price { get; set; }
        [Required, Range(1, 100, ErrorMessage = "Count cannot be more than 100")]
        public int Count { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
