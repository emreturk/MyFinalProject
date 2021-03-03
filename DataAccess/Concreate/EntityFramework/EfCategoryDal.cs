using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concreate.EntityFramework
{
   public class EfCategoryDal: EfEntityRepositoryBase<Category, NorthwindContext>,ICategoryDal
    {
        
    }
}
