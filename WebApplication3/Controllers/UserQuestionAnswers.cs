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
    public class UserQuestionAnswers : ControllerBase
    {
        private readonly QuizDBContext _context;
        public UserQuestionAnswers(QuizDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult getUserQuestionsAnswer()
        {
            return new JsonResult(_context.UserQuestionAnswers);
        }
        [HttpPost]
        public JsonResult addUserQuestionAnswer(UserQuestionAnswer uqa)
        {
            _context.UserQuestionAnswers.Add(uqa);
            _context.SaveChanges();
            return new JsonResult("Users Answer added");
        }
        [HttpPut]
        public JsonResult updateUserQuestionAnswer(UserQuestionAnswer uqa)
        {
            var result = _context.UserQuestionAnswers.Single(x => x.UserId == uqa.UserId && x.QuestionId == uqa.QuestionId && x.ChoiceId == uqa.ChoiceId);
            _context.Entry(result).CurrentValues.SetValues(uqa);
            _context.SaveChanges();
            return new JsonResult("User answer updated");
        }
        [HttpDelete]
        public JsonResult deleteUserQuestionAnswer(UserQuestionAnswer uqa)
        {
            _context.UserQuestionAnswers.Remove(uqa);
            _context.SaveChanges();
            return new JsonResult("");
        }
    }
}
