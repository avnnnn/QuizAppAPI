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
    public class QuestionController : ControllerBase
    {
        private readonly QuizDBContext _context;

        public QuestionController(QuizDBContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public JsonResult getQuestionsOfCategory(int id)
        {
            return  new JsonResult(_context.Questions.Where(x => x.CategoryId == id).ToList());
        }
        public JsonResult getQuestions()
        {
            return new JsonResult(_context.Questions.ToList());
        }
        [HttpPost] 
        public JsonResult addQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return new JsonResult("Succesfully added");
        }

        [HttpPut]
        public JsonResult updateResult(Question  question)
        {
            var result = _context.Questions.Single(x => x.QuestionId == question.QuestionId);
            if(result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(question);
                _context.SaveChanges();
                return new JsonResult("Question Succesfully updated");
            }
            return new JsonResult("No such Question");
        }
        [HttpDelete("{questionId}")]
        public JsonResult deleteResult(int questionId)
        {
            var result = _context.Questions.Single(x => x.QuestionId == questionId);
            if(result != null)
            {
                _context.Questions.Remove(result);
                _context.SaveChanges();
                return new JsonResult("Question Succesfullt delted");
            }
            return new JsonResult("No such Question");
        }
    }
}
