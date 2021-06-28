using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoicesController : ControllerBase
    {
        private readonly QuizDBContext _context;

        public ChoicesController(QuizDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult getChoices()
        {
            return new JsonResult(_context.Choices.ToList());
        }
        [HttpGet("{id}")]
        public JsonResult getChoicesById(int id)
        {
            return new JsonResult(_context.Choices.Where(x => x.QuestionId == id).ToList());
        }
        [HttpGet("{questionId}/{id}")]
        public JsonResult getChoiceById(int questionId, int id)
        {
            return new JsonResult(_context.Choices.Where(x => x.QuestionId == questionId && x.ChoiceId == id).ToList());
        }

        [HttpPost]
        public JsonResult addChoice(Choice choice)
        {
            _context.Choices.Add(choice);
            _context.SaveChanges();
            return new JsonResult("Choice Succesfullt added");
        }
        [HttpPut]
        public JsonResult updateChoice(Choice choice)
        {
            var result = _context.Choices.Single(x => x.ChoiceId == choice.ChoiceId);
            _context.Entry(result).CurrentValues.SetValues(choice);
            _context.SaveChanges();
            return new JsonResult("Choice Succesfullt updated");
        }
        [HttpDelete("{id}")]
        public JsonResult deleteChoic(int id)
        {
            var result = _context.Choices.Single(x => x.ChoiceId == id);
            _context.Choices.Remove(result);
            _context.SaveChanges();
            return new JsonResult("Choice Succesfullt delete");
        }


    }
}
