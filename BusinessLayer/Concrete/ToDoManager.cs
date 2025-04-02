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
    public class ToDoManager : IToDoService
    {
        IToDoDAL _toDoDAL;

        public ToDoManager(IToDoDAL toDoDAL)
        {
            _toDoDAL = toDoDAL;
        }

        public void TAdd(ToDo entity)
        {
            _toDoDAL.Insert(entity);
        }

        public void TDelete(ToDo entity)
        {
            _toDoDAL.Delete(entity);
        }

        public ToDo TGetByID(int id)
        {
            return _toDoDAL.GetById(id);
        }

        public List<ToDo> TGetList()
        {
            return _toDoDAL.GetList();
        }

        public List<ToDo> TGetListWithFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDo entity)
        {
            _toDoDAL.Update(entity);
        }
    }
}
