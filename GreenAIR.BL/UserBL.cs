using AutoMapper;
using GreenAIR.MODEL;
using GreenAIR.REPOSITORY;
using GreenAIR.REPOSITORY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenAIR.BL
{
    public class UserBL
    {
        private Mapper _userMapper;

        public UserBL()
        {
            var _configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>().ReverseMap());
            _userMapper = new Mapper(_configUser);
        }

        public List<UserModel> GetAllUsers()
        {
            var db = new DataContext();
            List<UserModel> _userModels = _userMapper.Map<List<User>, List<UserModel>>(db.Users.ToList());

            return _userModels;
        }

        public UserModel GetUserById(int id)
        {
            var db = new DataContext();
            UserModel _userModel = _userMapper.Map<User, UserModel>(db.Users.FirstOrDefault(x => x.UserID == id));

            return _userModel;
        }

        public bool AddUser(UserModel _user)
        {
            var db = new DataContext();

            var _existingUser = GetUserById(_user.UserID);
            if (_existingUser != null)
            {
                return false;
            }
            else
            {
                User _userEntity = _userMapper.Map<UserModel, User>(_user);
                db.Add(_userEntity);

                if (db.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
