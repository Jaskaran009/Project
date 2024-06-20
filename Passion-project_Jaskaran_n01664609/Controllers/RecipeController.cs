using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using Passion_project_Jaskaran_n01664609.Models;
using Passion_project_Jaskaran_n01664609.Models.ViewModels;
using System.Web.Script.Serialization;

namespace Passion_project_Jaskaran_n01664609.Controllers
{
    public class RecipeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static RecipeController()
        {
            client.BaseAddress = new Uri("https://localhost:44324/api/");
        }

        // GET: Recipe/List
        public ActionResult List()
        {
            string url = "RecipeData/ListRecipe";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<RecipeDto> recipes = response.Content.ReadAsAsync<IEnumerable<RecipeDto>>().Result;
                return View(recipes);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            DetailsRecipe ViewModel = new DetailsRecipe(); // Ensure DetailsRecipe exists and is correctly implemented
            string url = $"RecipeData/FindRecipe/{id}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                RecipeDto selectedRecipe = response.Content.ReadAsAsync<RecipeDto>().Result;
                return View(selectedRecipe);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Recipe/New
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            string url = "RecipeData/AddRecipe";

            string jsonPayload = jss.Serialize(recipe);
            HttpContent content = new StringContent(jsonPayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            string url = $"RecipeData/FindRecipe/{id}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                RecipeDto selectedRecipe = response.Content.ReadAsAsync<RecipeDto>().Result;
                return View(selectedRecipe);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Recipe/Update/5
        [HttpPost]
        public ActionResult Update(int id, Recipe recipe)
        {
            string url = $"RecipeData/UpdateRecipe/{id}";

            string jsonPayload = jss.Serialize(recipe);
            HttpContent content = new StringContent(jsonPayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Recipe/DeleteConfirm/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = $"RecipeData/FindRecipe/{id}";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                RecipeDto selectedRecipe = response.Content.ReadAsAsync<RecipeDto>().Result;
                return View(selectedRecipe);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Recipe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = $"RecipeData/DeleteRecipe/{id}";
            HttpResponseMessage response = client.PostAsync(url, null).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // Handle other actions or errors here
        public ActionResult Error()
        {
            return View();
        }
    }
}
