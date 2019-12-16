using Microsoft.AspNetCore.Http;
using RecipesManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesManagement.ViewModels
{
    public class RecipeCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 charecters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Source cannot exceed 50 charecters")]
        public string Source { get; set; }
        [Required]
        public List<Ingredients> Ingredients { get; set; }
        [Required]
        public int Time { get; set; }
        [Required]
        public string Preparation { get; set; }
        public List<IFormFile> Photos { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
