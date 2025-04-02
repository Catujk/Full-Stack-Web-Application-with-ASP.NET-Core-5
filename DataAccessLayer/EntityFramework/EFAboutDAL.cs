using DataAccessLayer.Absract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAboutDAL : GenericRepository<About>, IAboutDAL 
    {
        // GenericRepository'den kalıtım aldık ve IAboutDAL interface'ini implement ettik.
        // GenericRepository'de olan metotları burada tekrar yazmamıza gerek kalmadı.
        // IAboutDAL interface'inde olmayan metotları burada yazabiliriz.
        // IAboutDAL yazmasak da olurdu. Sadece burada yazdığımız metotlar olacaktı.
        // Ama IAboutDAL yazarak burada yazdığımız metotları IAboutDAL'dan çağırabiliriz.
        // Ve ileride başka metotlar eklemek istediğimizde IAboutDAL'a ekleriz ve burada implement ederiz.
    }
}
