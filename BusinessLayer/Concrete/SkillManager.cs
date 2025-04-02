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
    public class SkillManager : ISkillService
    {
        ISkillDAL _skillDAL;
        public SkillManager(ISkillDAL skillDAL)
        {
            _skillDAL = skillDAL;
        }

        public void TAdd(Skill entity)
        {
            _skillDAL.Insert(entity);
        }

        public void TDelete(Skill entity)
        {
            _skillDAL.Delete(entity);
        }

        public Skill TGetByID(int id)
        {
            return _skillDAL.GetById(id);
        }

        public List<Skill> TGetList()
        {
            return _skillDAL.GetList();
        }

        public List<Skill> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Skill entity)
        {
            _skillDAL.Update(entity);
        }
    }
}
