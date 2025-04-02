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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDAL _socialMediaDAL;
        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMediaDAL.Insert(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socialMediaDAL.Delete(entity);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialMediaDAL.GetById(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediaDAL.GetList();
        }

        public List<SocialMedia> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaDAL.Update(entity);
        }
    }
}
