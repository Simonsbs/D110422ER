using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController {
        [HttpGet]
        public List<User> GetUser(int id) {
            List<User> users = new List<User>() {
                new User {
                    ID = 1,
                    UserName = "Test",
                    Password = "password",
                    Email = "Test@test.com",
                    HasACat = true,
                    DOB = DateTime.Now
                },
                new User {
                    ID = 2,
                    UserName = "Test 2",
                    Password = "password 2",
                    Email = "Test2@test.com",
                    HasACat = false,
                    DOB = DateTime.Now.AddDays(1)
                }
            };

            return users;
        }
    }
}
