using GreenAIR.BL;
using GreenAIR.MODEL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenAIR.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserBL _oUserBL = null;

        public UserController()
        {
            _oUserBL = new UserBL();
        }

        [HttpGet]
        [ActionName("GetAllUsers")]
        public List<UserModel> GetAllUsers()
        {
            return _oUserBL.GetAllUsers();
        }
    }
}
