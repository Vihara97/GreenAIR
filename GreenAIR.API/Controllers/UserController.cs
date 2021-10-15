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

        [HttpGet("{id}")]
        [ActionName("GetUserById")]
        public UserModel GetUserById([FromRoute] int id)
        {
            return _oUserBL.GetUserById(id);
        }

        [HttpPost]
        [ActionName("AddUser")]
        public bool AddUser([FromBody] UserModel _user)
        {
            return _oUserBL.AddUser(_user);
        }

        [HttpPost]
        [ActionName("EditUser")]
        public bool EditUser([FromBody] UserModel _user)
        {
            return _oUserBL.EditUser(_user);
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteUserById")]
        public bool DeleteUserById([FromRoute] int id)
        {
            return _oUserBL.DeleteUserById(id);
        }
    }
}
