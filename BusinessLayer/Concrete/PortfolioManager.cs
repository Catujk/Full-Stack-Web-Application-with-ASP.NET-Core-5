using BusinessLayer.Absract;
using DataAccessLayer.Absract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDAL _portfolioDAL;
        public PortfolioManager(IPortfolioDAL portfolioDAL)
        {
            _portfolioDAL = portfolioDAL;
        }

        public void TAdd(Portfolio entity)
        {
            _portfolioDAL.Insert(entity);
        }

        public void TDelete(Portfolio entity)
        {
            _portfolioDAL.Delete(entity);
        }

        public Portfolio TGetByID(int id)
        {
            return _portfolioDAL.GetById(id);
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioDAL.GetList();
        }

        public List<Portfolio> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Portfolio entity)
        {
            _portfolioDAL.Update(entity);
        }
    }
}
