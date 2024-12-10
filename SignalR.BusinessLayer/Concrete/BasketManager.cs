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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketdal;

        public BasketManager(IBasketDal basketdal)
        {
            _basketdal = basketdal;
        }

        public void TAdd(Basket entity)
        {
           _basketdal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketdal.Delete(entity);
        }

        public List<Basket> TGetAllList()
        {
            return _basketdal.GetAllList();
        }

        public List<Basket> TGetBasketByMenuTableNumber(int id)
        {
            return _basketdal.GetBasketByMenuTableNumber(id);
        }

        public Basket TGetByID(int id)
        {
            return _basketdal.GetByID(id);
        }

        public void TUpdate(Basket entity)
        {
           _basketdal.Update(entity);
        }
    }
}
