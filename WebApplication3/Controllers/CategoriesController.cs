using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly QuizDBContext _context;

        public CategoriesController(QuizDBContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public JsonResult getCategories()
        {
            return new JsonResult(_context.Categories);
        }

        // GET: api/Categories/5
        [HttpPost]
        public JsonResult addCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return new JsonResult("Category Succesfully Added");
        }
        [HttpPut]
        public JsonResult updateCategory(Category category)
        {
            var result = _context.Categories.Single(x => x.CategoryId == category.CategoryId);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(category);
                _context.SaveChanges();
                return new JsonResult("Category Succesfully Updated");
            }
            return new JsonResult("No such Category");
        }
        [HttpDelete("{categoryId}")]
        public JsonResult deleteUser(int categoryId)
        {
            var result = _context.Categories.Single(x => x.CategoryId == categoryId);
            if (result != null)
            {
                _context.Categories.Remove(result);
                _context.SaveChanges();
                return new JsonResult("Category Succesfully Deleted");
            }
            return new JsonResult("No such Category");

        }

    }
}
