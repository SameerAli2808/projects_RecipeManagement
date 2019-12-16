using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RecipesManagement.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 charecters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 charecters")]
        public string Source { get; set; }
        public virtual List<Ingredients> Ingredients { get; set; }
        [Required]
        public int Time { get; set; }
        //[Required]
        public string Preparation { get; set; }
        public string PhotoPath { get; set; }
    }
}
