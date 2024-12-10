﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

using SignalR.DataAccessLayer.Repository;
using SignalR.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            throw new NotImplementedException();
        }

        public void BookingStatusCancelled(int id)
        {
            throw new NotImplementedException();
        }
    }
}
