using RecipesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesManagement.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Recipe Recipe { get; set; }
        public string PageTitle { get; set; }
    }
}
