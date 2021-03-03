using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResults<List<Product>> GetAll();
        IDataResults<List<Product>> GetAllByCategoryId(int id);
        IDataResults<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResults<List<ProductDetailDto>> GetProductDetails();
        IDataResults<Product>  GetById(int productID);
        IResult Add(Product product);
    }
}
