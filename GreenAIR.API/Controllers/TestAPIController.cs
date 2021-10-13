using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenAIR.BL;

namespace GreenAIR.API.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {
        private Test TestBL = null;

        public TestAPIController()
        {
            TestBL = new Test();
        }

        [HttpGet]
        [ActionName("GetTestString")]
        public string GetTestString()
        {
            return TestBL.TestMethod();
        }

        [HttpGet]
        [ActionName("GetTestInt")]
        public int GetTestInt()
        {
            return 10;
        }

    }
}
