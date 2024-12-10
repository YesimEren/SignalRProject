using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFrameWork
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(Context context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context=new Context();
            return context.Orders.Where(x => x.Description=="Müşteri Masada").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context=new Context();
            return context.Orders.OrderByDescending(x=>x.OrderID).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalOrderCount()
        {

            using var context = new Context();        
            return context.Orders.Where(x => x.OrderDate==DateTime.Now.Date).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public int TotalOrderCount()
        {
            using var context = new Context();
            return context.Orders.Count();
        }
    }
}
