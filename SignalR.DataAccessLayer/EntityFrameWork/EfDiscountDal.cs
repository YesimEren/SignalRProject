using SignalR.DataAccessLayer.Abstract;
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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(Context context) : base(context)
        {
        }

        public void ChangeStatusToFalse(int id)
        {
            var context=new Context();
            var values = context.Discounts.Find(id);
            values.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var context=new Context();
            var values = context.Discounts.Find(id);
            values.Status=true;
            context.SaveChanges();

        }

        public List<Discount> GetListByStatusTrue()
        {
           var context=new Context();
            var values = context.Discounts.Where(x=>x.Status==true).ToList();
            return values;
        }
    }
}
