using SignalR.BusinessLayer.Abstarct;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;
       

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
          
        }

        public void BookingStatusApproved(int id)
        {
           _bookingDal.BookingStatusApproved(id);
        }

        public void BookingStatusCancelled(int id)
        {
            _bookingDal.BookingStatusCancelled(id);
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
         

        }

        public void TDelete(Booking entity)
        {
           _bookingDal.Delete(entity);
        }

        public List<Booking> TGetAllList()
        {
          return _bookingDal.GetAllList();
        }

        public Booking TGetByID(int id)
        {
           return _bookingDal.GetByID(id);
        }

        public void TUpdate(Booking entity)
        {
           _bookingDal.Update(entity);
        }
    }
}
