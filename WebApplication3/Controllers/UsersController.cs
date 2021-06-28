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
    public class UsersController : ControllerBase
    {
        private readonly QuizDBContext _context;

        public UsersController(QuizDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult getUsers()
        {
            return new JsonResult(_context.Users.ToList());
        }
        [Route("login")]
        [HttpPost]
        public JsonResult authUser(User user) {
            return new JsonResult(_context.Users.SingleOrDefault(x => x.EmailAddress == user.EmailAddress && x.Password == user.Password));
        }
        [HttpPost]
        public JsonResult addUsers(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return new JsonResult("User Succesfully Added");
        }

        public JsonResult updateUser(User user)
        {
            var result = _context.Users.Single(x => x.UserId == user.UserId);
            if(result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();
                return new JsonResult("User Succesfully Updated");
            }
            return new JsonResult("No such User");
        }
        [HttpDelete("{userId}")]
        public JsonResult deleteUser(int userId)
        {
            var result = _context.Users.Single(x => x.UserId == userId);
            if (result != null)
            {
                _context.Users.Remove(result);
                _context.SaveChanges();
                return new JsonResult("User Succesfully Deleted");
            }
            return new JsonResult("No such User");

        }
    }
}
