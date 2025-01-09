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
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(Context context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationByFalse()
		{
			using var context=new Context();
			var value=context.Notifications.Where(x=>x.Status==false).ToList();
			return value;
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new Context();
			var values = context.Notifications.Where(x => x.Status == false).Count();
			return values;
		}

		public void NotificationStatusChangeToFalse(int id)
		{
			using var context=new Context();
			var value = context.Notifications.Find(id);
			value.Status = false;
			context.SaveChanges();
		}

		public void NotificationStatusChangeToTrue(int id)
		{
			using var context = new Context();
			var value = context.Notifications.Find(id);
			value.Status=true;
			context.SaveChanges();
		}
	}
}
