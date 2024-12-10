using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IBasketDal:IGenericDal<Basket>
    {
        //bulunduğumuz aktif masa gelsin ve siparişleri silelim
        List<Basket> GetBasketByMenuTableNumber(int id);
    }
}
