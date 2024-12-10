using SignalR.DataAccessLayer.EntityFramework;
using SignalR.EntiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstarct
{
    public interface IBookingService:IGenericService<Booking>
    {
        void BookingStatusApproved(int id);
        void BookingStatusCancelled(int id);
    }
}
