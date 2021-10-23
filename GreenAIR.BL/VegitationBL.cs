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
    public class VegitationBL
    {
        private Mapper _VegitationMapper;

        public VegitationBL()
        {
            var _configVegitation = new MapperConfiguration(cfg => cfg.CreateMap<Vegitation, VegitationModel>().ReverseMap());
            _VegitationMapper = new Mapper(_configVegitation);
        }

        public List<VegitationModel> GetAllVegitations()
        {
            var db = new DataContext();
            List<VegitationModel> _VegitationModels = _VegitationMapper.Map<List<Vegitation>, List<VegitationModel>>(db.Vegitations.ToList());

            return _VegitationModels;
        }

        public VegitationModel GetVegitationById(int id)
        {
            var db = new DataContext();
            VegitationModel _VegitationModel = _VegitationMapper.Map<Vegitation, VegitationModel>(db.Vegitations.FirstOrDefault(x => x.ID == id));

            return _VegitationModel;
        }

        public bool AddVegitation(VegitationModel _Vegitation)
        {
            var db = new DataContext();

            var _existingVegitation = GetVegitationById(_Vegitation.ID);
            if (_existingVegitation != null)
            {
                return false;
            }
            else
            {
                Vegitation _VegitationEntity = _VegitationMapper.Map<VegitationModel, Vegitation>(_Vegitation);
                db.Add(_VegitationEntity);

                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool EditVegitation(VegitationModel _Vegitation)
        {
            var db = new DataContext();

            var _existingVegitation = GetVegitationById(_Vegitation.ID);
            if (_existingVegitation != null)
            {
                Vegitation _VegitationEntity = _VegitationMapper.Map<VegitationModel, Vegitation>(_Vegitation);
                db.Update(_VegitationEntity);

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

        public bool DeleteVegitationById(int id)
        {
            var db = new DataContext();
            Vegitation _deleteVegitation = db.Vegitations.FirstOrDefault(x => x.ID == id);
            db.Remove(_deleteVegitation);

            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
