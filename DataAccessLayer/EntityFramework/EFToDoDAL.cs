﻿using DataAccessLayer.Absract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFToDoDAL : GenericRepository<ToDo>, IToDoDAL
    {
    }
}
