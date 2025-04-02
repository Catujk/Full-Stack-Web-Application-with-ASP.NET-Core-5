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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDAL _experienceDAL;
        public ExperienceManager(IExperienceDAL experienceDAL)
        {
            _experienceDAL = experienceDAL;
        }

        public void TAdd(Experience entity)
        {
            _experienceDAL.Insert(entity);
        }

        public void TDelete(Experience entity)
        {
            _experienceDAL.Delete(entity);
        }

        public Experience TGetByID(int id)
        {
            return _experienceDAL.GetById(id);
        }

        public List<Experience> TGetList()
        {
            return _experienceDAL.GetList();
        }

        public List<Experience> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Experience entity)
        {
            _experienceDAL.Update(entity);
        }
    }
}
