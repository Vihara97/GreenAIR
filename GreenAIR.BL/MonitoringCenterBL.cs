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
    public class MonitoringCenterBL
    {
        private Mapper _monitoringCenterMapper;

        public MonitoringCenterBL()
        {
            var _configMonitoringCenter = new MapperConfiguration(cfg => cfg.CreateMap<MonitoringCenter, MonitoringCenterModel>().ReverseMap());
            _monitoringCenterMapper = new Mapper(_configMonitoringCenter);
        }

        public List<MonitoringCenterModel> GetAllMonitoringCenters()
        {
            var db = new DataContext();
            List<MonitoringCenterModel> _monitoringCenterModels = _monitoringCenterMapper.Map<List<MonitoringCenter>, List<MonitoringCenterModel>>(db.MonitoringCenters.ToList());

            return _monitoringCenterModels;
        }

        public MonitoringCenterModel GetMonitoringCenterById(int id)
        {
            var db = new DataContext();
            MonitoringCenterModel _monitoringCenterModel = _monitoringCenterMapper.Map<MonitoringCenter, MonitoringCenterModel>(db.MonitoringCenters.FirstOrDefault(x => x.CenterID == id));

            return _monitoringCenterModel;
        }

        public bool AddMonitoringCenter(MonitoringCenterModel _monitoringCenter)
        {
            var db = new DataContext();

            var _existingMonitoringCenter = GetMonitoringCenterById(_monitoringCenter.CenterID);
            if (_existingMonitoringCenter != null)
            {
                return false;
            }
            else
            {
                MonitoringCenter _monitoringCenterEntity = _monitoringCenterMapper.Map<MonitoringCenterModel, MonitoringCenter>(_monitoringCenter);
                db.Add(_monitoringCenterEntity);

                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool EditMonitoringCenter(MonitoringCenterModel _monitoringCenter)
        {
            var db = new DataContext();

            var _existingMonitoringCenter = GetMonitoringCenterById(_monitoringCenter.CenterID);
            if (_existingMonitoringCenter != null)
            {
                MonitoringCenter _monitoringCenterEntity = _monitoringCenterMapper.Map<MonitoringCenterModel, MonitoringCenter>(_monitoringCenter);
                db.Update(_monitoringCenterEntity);

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

        public bool DeleteMonitoringCenterById(int id)
        {
            var db = new DataContext();
            MonitoringCenter _deleteMonitoringCenter = db.MonitoringCenters.FirstOrDefault(x => x.CenterID == id);
            db.Remove(_deleteMonitoringCenter);

            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
