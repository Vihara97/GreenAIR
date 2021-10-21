using GreenAIR.BL;
using GreenAIR.MODELS;
using GreenAIR.REPOSITORY.Models;
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
    public class IOTDeviceController : ControllerBase
    {
        private IOTDeviceBL _oIOTDeviceBL = null;

        public IOTDeviceController()
        {
            _oIOTDeviceBL = new IOTDeviceBL();
        }

        [HttpGet]
        [ActionName("GetAllIOTDevices")]
        public List<IOTDeviceModel> GetAllIOTDevices()
        {
            return _oIOTDeviceBL.GetAllIOTDevices();
        }

        [HttpGet("{id}")]
        [ActionName("GetIOTDeviceById")]
        public IOTDeviceModel GetIOTDeviceById([FromRoute] int id)
        {
            return _oIOTDeviceBL.GetIOTDeviceById(id);
        }

        [HttpPost]
        [ActionName("AddIOTDevice")]
        public bool AddIOTDevice([FromBody] IOTDeviceModel _IOTDevice)
        {
            return _oIOTDeviceBL.AddIOTDevice(_IOTDevice);
        }

        [HttpPost]
        [ActionName("EditIOTDevice")]
        public bool EditIOTDevice([FromBody] IOTDeviceModel _IOTDevice)
        {
            return _oIOTDeviceBL.EditIOTDevice(_IOTDevice);
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteIOTDeviceById")]
        public bool DeleteIOTDeviceById([FromRoute] int id)
        {
            return _oIOTDeviceBL.DeleteIOTDeviceById(id);
        }
    }
}
