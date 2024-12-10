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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        public EfMenuTableDal(Context context) : base(context)
        {
        }

        public void ChangeMenuTableStatusToFalse(int id)
        {
           using var context=new Context();
           var value= context.MenuTables.Where(x=>x.MenuTableID==id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();

        }

        public void ChangeMenuTableStatusToTrue(int id)
        {
          using var context=new Context();
          var values=context.MenuTables.Where(x=>x.MenuTableID==id).FirstOrDefault();
          values.Status= true;
            context.SaveChanges();
        }

        public int MenuTableCount()
        {
           using var context = new Context();
            return context.MenuTables.Count();
        }
    }
}
