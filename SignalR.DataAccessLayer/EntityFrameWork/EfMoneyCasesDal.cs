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
    public class EfMoneyCasesDal : GenericRepository<MoneyCase>, IMoneyCasesDal
    {
        public EfMoneyCasesDal(Context context) : base(context)
        {
        }

        public decimal TotalMoneyCases()
        {
            using var context=new Context();
            return context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
        }
    }
}
