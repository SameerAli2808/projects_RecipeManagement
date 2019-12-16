using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesManagement.Models
{
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantinty { get; set; }
        [ForeignKey("Recepie")]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
