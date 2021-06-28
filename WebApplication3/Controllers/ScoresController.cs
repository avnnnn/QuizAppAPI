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
    public class ScoresController : ControllerBase
    {
        private readonly QuizDBContext _context;

        public ScoresController(QuizDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult getScores()
        {
            return new JsonResult(_context.Scores);
        }
        [HttpGet("{userId}/{categoryId}")]
        public JsonResult getScoreOfUser(int userId, int categoryId)
        {
            return new JsonResult(_context.Scores.SingleOrDefault(x => x.UserId == userId && x.BestCategoryId == categoryId));
        }

        [HttpPost]
        public JsonResult addScore(Score score)
        {
            _context.Scores.Add(score);
            _context.SaveChanges();
            return new JsonResult("Score Succesfullt added");
        }
        [HttpDelete]
        public JsonResult deleteScore(Score score)
        {
            var result = _context.Scores.Single(x => x.ScoreId == score.ScoreId && x.UserId == score.ScoreId && x.BestCategoryId == score.BestCategoryId);
            _context.Scores.Remove(result);
            _context.SaveChanges();
           return new JsonResult("  Score delted");
        }
        [HttpPut]
        public JsonResult updateScore(Score score)
        {
            var result = _context.Scores.Single(x => x.ScoreId == score.ScoreId && x.UserId == score.UserId && x.BestCategoryId == score.BestCategoryId);
            _context.Entry(result).CurrentValues.SetValues(score);
            _context.SaveChanges();
            return new JsonResult("Score updated");
        }
    }
}
