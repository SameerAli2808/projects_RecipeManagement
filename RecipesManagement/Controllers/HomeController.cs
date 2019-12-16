using RecipesManagement.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using RecipesManagement.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace RecipesManagement.Controllers
{
    [Route("[controller]/[action]")]
    //[Route("[controller]")] // option 1
    public class HomeController : Controller
    {
        private readonly IMapper _mapper; 
        private readonly IRecipeRepository _recipeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IRecipeRepository recipeRepository,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper)
        {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        //[Route("")] // Whatever the URL this action will be routed
        //[Route("[action]")] // option 1
        //[Route("~/Home")] // To avaoid 404 if no attribute had been entered 
        public ViewResult Index()
        {
            var model = _recipeRepository.GetAllRecipes();
            var recipeVM = _mapper.Map<List<RecipeCreateViewModel>>(model);
            return View(recipeVM);
        }

        [Route("{id}")]
        //[Route("[action]/{id}")] // option 1
        public ViewResult Details(int id)
        {
            Recipe recipe = _recipeRepository.GetRecipe(id);
            var recipeVM = _mapper.Map<RecipeCreateViewModel>(recipe);

            //HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            //{
            //    Recipe = _recipeRepository.GetRecipe(id),
            //    PageTitle = "Recipe Details"
            //};

            return View(recipeVM);
        }

        //public JsonResult Details()
        //{
        //    Recipe model = _recipeRepository.GetRecipe(1);
        //    return Json(model);
        //}

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Recipe recipe = _recipeRepository.GetRecipe(Id);
            var recipeVM = _mapper.Map<RecipeCreateViewModel>(recipe);

            //RecipeEditViewModel recipeEditViewModel = new RecipeEditViewModel
            //{
            //    Id = recipe.Id,
            //    Name = recipe.Name,
            //    Source = recipe.Source,
            //    Ingredient = recipe.Ingredient,
            //    //Ingredients = recipe.Ingredients,
            //    Time = recipe.Time,
            //    Preparation = recipe.Preparation,
            //    ExistingPhotoPath = recipe.PhotoPath
            //};
            return View(recipeVM);
        }

        [HttpPost]
        public IActionResult Edit(RecipeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Recipe recipe = _recipeRepository.GetRecipe(model.Id);
                


                //recipe.Name = model.Name;
                //recipe.Source = model.Source;
                //recipe.Ingredient = model.Ingredient;
                ////recipe.Ingredients = model.Ingredients;
                //recipe.Time = model.Time;
                //recipe.Preparation = model.Preparation;

                //if (model.Photos != null)
                //{
                //    if (model.ExistingPhotoPath != null)
                //    {
                //        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                //            "images", model.ExistingPhotoPath);
                //        System.IO.File.Delete(filePath);
                //    }
                //    recipe.PhotoPath = ProcessUploadedFile(model);
                //}

                _recipeRepository.Update(recipe);

                return RedirectToAction("index");
            }

            return View(model);
        }

        private string ProcessUploadedFile(RecipeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult Create(RecipeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                var newRecipe = _mapper.Map<Recipe>(model);

                //Recipe newRecipe = new Recipe
                //{
                //    Name = model.Name,
                //    Source = model.Source,
                //    Ingredient = model.Ingredient,
                //    Time = model.Time,
                //    Preparation = model.Preparation,
                //    PhotoPath = uniqueFileName
                //};

                _recipeRepository.Add(newRecipe);
                return RedirectToAction("details", new { id = newRecipe.Id });
            }

            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Recipe recipe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Recipe newRecipe = _recipeRepository.Add(recipe);
        //        //return RedirectToAction("details", new { id = newRecipe.Id });
        //    }

        //    return View();
        //}
    }
}
