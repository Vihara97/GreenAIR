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
    public class MonitoringCenterController : ControllerBase
    {
        private MonitoringCenterBL _oMonitoringCenterBL = null;

        public MonitoringCenterController()
        {
            _oMonitoringCenterBL = new MonitoringCenterBL();
        }

        [HttpGet]
        [ActionName("GetAllMonitoringCenters")]
        public List<MonitoringCenterModel> GetAllMonitoringCenters()
        {
            return _oMonitoringCenterBL.GetAllMonitoringCenters();
        }

        [HttpGet("{id}")]
        [ActionName("GetMonitoringCenterById")]
        public MonitoringCenterModel GetMonitoringCenterById([FromRoute] int id)
        {
            return _oMonitoringCenterBL.GetMonitoringCenterById(id);
        }

        [HttpPost]
        [ActionName("AddMonitoringCenter")]
        public bool AddMonitoringCenter([FromBody] MonitoringCenterModel _monitoringCenter)
        {
            return _oMonitoringCenterBL.AddMonitoringCenter(_monitoringCenter);
        }

        [HttpPost]
        [ActionName("EditMonitoringCenter")]
        public bool EditMonitoringCenter([FromBody] MonitoringCenterModel _monitoringCenter)
        {
            return _oMonitoringCenterBL.EditMonitoringCenter(_monitoringCenter);
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteMonitoringCenterById")]
        public bool DeleteMonitoringCenterById([FromRoute] int id)
        {
            return _oMonitoringCenterBL.DeleteMonitoringCenterById(id);
        }
    }
}
