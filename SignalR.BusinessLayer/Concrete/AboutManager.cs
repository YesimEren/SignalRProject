﻿using SignalR.BusinessLayer.Abstarct;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
           _aboutDal.Add(entity);
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public List<About> TGetAllList()
        {
            return _aboutDal.GetAllList();
        }

        public About TGetByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public void TUpdate(About entity)
        {
           _aboutDal.Update(entity);
        }
    }
}
