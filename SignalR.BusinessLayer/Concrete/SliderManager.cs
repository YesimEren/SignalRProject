﻿using SignalR.BusinessLayer.Abstarct;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TAdd(Slider entity)
        {
           _sliderDal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
           _sliderDal.Delete(entity);
        }

        public List<Slider> TGetAllList()
        {
            return _sliderDal.GetAllList();
        }

        public Slider TGetByID(int id)
        {
            return _sliderDal.GetByID(id);
        }

        public void TUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
