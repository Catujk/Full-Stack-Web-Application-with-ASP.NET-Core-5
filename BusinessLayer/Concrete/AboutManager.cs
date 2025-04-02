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
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutDAL;
        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        // IAboutDAL _aboutDAL = new EfAboutDAL();
        // Hatalı bir kullanım. Çünkü AboutManager sınıfı EfAboutDAL sınıfına bağımlı hale gelmiş olur. Ve Interface'lerin amacı boşa çıkar.
        // Zaten Interface'den sınıf oluşturulamaz. Interface'lerin amacı, bir sınıfın hangi metotları içermesi gerektiğini belirtmektir.
        // Bu şekilde bir kullanım yerine yukarıdaki gibi bir kullanım yaparak Dependency Injection yapmış olduk.
        // Bu sayede AboutManager sınıfı EfAboutDAL sınıfına bağımlı hale gelmedi.

        // IAboutDAL burada ne işe yarar?   
        // IAboutDAL, EfAboutDAL sınıfının içerisindeki metotları içerir.
        // Bu sayede AboutManager sınıfı EfAboutDAL sınıfının içerisindeki metotları kullanabilir.

        // EFAboutDAL sınıfı içerisindeki metotları kullanabilmek için IAboutDAL türünde bir değişken tanımladık.
        // Bu değişkenin içerisine EfAboutDAL sınıfının referansını atadık.
        // Bu sayede IAboutDAL türündeki değişken üzerinden EfAboutDAL sınıfının içerisindeki metotları kullanabiliriz.

        public void TAdd(About entity)
        {
            _aboutDAL.Insert(entity);
        }

        public void TDelete(About entity)
        {
            _aboutDAL.Delete(entity);
        }

        public About TGetByID(int id)
        {
            return _aboutDAL.GetById(id);
        }

        public List<About> TGetList()
        {
            return _aboutDAL.GetList();
        }

        public List<About> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About entity)
        {
            _aboutDAL.Update(entity);
        }
    }
}
