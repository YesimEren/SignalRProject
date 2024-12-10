using SignalR.BusinessLayer.Abstarct;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MoneyCasesManager : IMoneyCasesService
    {
        private readonly IMoneyCasesDal _moneyCasesDal;

        public MoneyCasesManager(IMoneyCasesDal moneyCasesDal)
        {
            _moneyCasesDal = moneyCasesDal;
        }

        public void TAdd(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public List<MoneyCase> TGetAllList()
        {
            throw new NotImplementedException();
        }

        public MoneyCase TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public decimal TTotalMoneyCases()
        {
            return _moneyCasesDal.TotalMoneyCases();
        }

        public void TUpdate(MoneyCase entity)
        {
            throw new NotImplementedException();
        }
    }
}
