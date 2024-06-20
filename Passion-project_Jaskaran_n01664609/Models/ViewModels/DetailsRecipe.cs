using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Passion_project_Jaskaran_n01664609.Models.ViewModels
{
    public class DetailsRecipe
    {
        public RecipeDto SelectedRecipe { get; set; }
        public IEnumerable<IngredientsDto> IngredientsOptions { get; set; }


    }
}