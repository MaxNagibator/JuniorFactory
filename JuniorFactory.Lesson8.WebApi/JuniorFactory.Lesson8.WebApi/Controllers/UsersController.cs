using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JuniorFactory.Lesson8.Middlewares;
using JuniorFactory.Lesson8.Models.Users;

namespace JuniorFactory.Lesson8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        public string Login([FromBody] LoginModel model)
        {
            if (model.User == "admin")
            {
                if (model.Password == "123")
                {
                    return "secret123token";
                }
            }
            throw new Exception("user or password incorrect");
        }

        [HttpPost]
        [Route("Username")]
        [AuthFilter(Permissions.User)]
        public string GetUsername()
        {
            return "Павел";
        }

        [HttpPost]
        [Route("Balance")]
        [AuthFilter(Permissions.Admin)]
        public string GetBalance()
        {
            return "606217рублей";
        }

        /// <summary>
        /// Получить дом.
        /// </summary>
        /// <param name="id">Айди дома.</param>
        /// <returns>Инфа о доме.</returns>
        [HttpPost]
        [Route("House/{id}")]
        public string GetHouse(int id)
        {
            return "dom number " + id;
        }
    }
}
