﻿using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFrameWork;
using SignalR.EntityLayer.Entities;
using SignalR.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestoimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
           _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial entity)
        {
           _testimonialDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
           _testimonialDal.Delete(entity);
        }

        public List<Testimonial> TGetAllList()
        {
            return _testimonialDal.GetAllList();
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDal.GetByID(id);
        }

        public void TUpdate(Testimonial entity)
        {
           _testimonialDal.Update(entity);
        }
    }
}
