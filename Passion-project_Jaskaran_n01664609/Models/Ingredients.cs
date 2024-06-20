using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Passion_project_Jaskaran_n01664609.Models
{
    public class Ingredients
    {

        [Key]
        public int IngredientID { get; set; }

        public string IngredientName { get; set; }
    }

    public class IngredientsDto
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
    }
    }