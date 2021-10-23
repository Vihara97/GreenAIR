using GreenAIR.BL;
using GreenAIR.MODELS;
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
    public class VegitationController : ControllerBase
    {
        private VegitationBL _oVegitationBL = null;

        public VegitationController()
        {
            _oVegitationBL = new VegitationBL();
        }

        [HttpGet]
        [ActionName("GetAllVegitations")]
        public List<VegitationModel> GetAllVegitations()
        {
            return _oVegitationBL.GetAllVegitations();
        }

        [HttpGet("{id}")]
        [ActionName("GetVegitationById")]
        public VegitationModel GetVegitationById([FromRoute] int id)
        {
            return _oVegitationBL.GetVegitationById(id);
        }

        [HttpPost]
        [ActionName("AddVegitation")]
        public bool AddVegitation([FromBody] VegitationModel _Vegitation)
        {
            return _oVegitationBL.AddVegitation(_Vegitation);
        }

        [HttpPost]
        [ActionName("EditVegitation")]
        public bool EditVegitation([FromBody] VegitationModel _Vegitation)
        {
            return _oVegitationBL.EditVegitation(_Vegitation);
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteVegitationById")]
        public bool DeleteVegitationById([FromRoute] int id)
        {
            return _oVegitationBL.DeleteVegitationById(id);
        }
    }
}
