using AutoMapper;
using GreenAIR.MODELS;
using GreenAIR.REPOSITORY;
using GreenAIR.REPOSITORY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenAIR.BL
{
    public class IOTDeviceBL
    {
        private Mapper _IOTDeviceMapper;

        public IOTDeviceBL()
        {
            var _configIOTDevice = new MapperConfiguration(cfg => cfg.CreateMap<IOTDevice, IOTDeviceModel>().ReverseMap());
            _IOTDeviceMapper = new Mapper(_configIOTDevice);
        }

        public List<IOTDeviceModel> GetAllIOTDevices()
        {
            var db = new DataContext();
            List<IOTDeviceModel> _IOTDeviceModels = _IOTDeviceMapper.Map<List<IOTDevice>, List<IOTDeviceModel>>(db.IOTDevices.ToList());

            return _IOTDeviceModels;
        }

        public IOTDeviceModel GetIOTDeviceById(int id)
        {
            var db = new DataContext();
            IOTDeviceModel _IOTDeviceModel = _IOTDeviceMapper.Map<IOTDevice, IOTDeviceModel>(db.IOTDevices.FirstOrDefault(x => x.DeviceID == id));

            return _IOTDeviceModel;
        }

        public bool AddIOTDevice(IOTDeviceModel _IOTDevice)
        {
            var db = new DataContext();

            var _existingIOTDevice = GetIOTDeviceById(_IOTDevice.DeviceID);
            if (_existingIOTDevice != null)
            {
                return false;
            }
            else
            {
                IOTDevice _IOTDeviceEntity = _IOTDeviceMapper.Map<IOTDeviceModel, IOTDevice>(_IOTDevice);
                db.Add(_IOTDeviceEntity);

                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool EditIOTDevice(IOTDeviceModel _IOTDevice)
        {
            var db = new DataContext();

            var _existingIOTDevice = GetIOTDeviceById(_IOTDevice.DeviceID);
            if (_existingIOTDevice != null)
            {
                IOTDevice _IOTDeviceEntity = _IOTDeviceMapper.Map<IOTDeviceModel, IOTDevice>(_IOTDevice);
                db.Update(_IOTDeviceEntity);

                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteIOTDeviceById(int id)
        {
            var db = new DataContext();
            IOTDevice _deleteIOTDevice = db.IOTDevices.FirstOrDefault(x => x.DeviceID == id);
            db.Remove(_deleteIOTDevice);

            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
