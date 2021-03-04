using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concreate
{
    public class ProductManager : IProductService
    { //business codes
      //validation //Doğrulama kodlar 
      //...
      //[LogAspect]-->AOP
      //[Validate]
      //[RemoveCache]          
      //[Transaction]
      //[Performance]
      //+++++
      //Loglama
      //cacheremove
      //performance
      //transaction
      //yetkilendirme
      //business codes




        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResults<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResults<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResults<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>
                (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResults<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResults<Product> GetById(int productID)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productID));
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {

           
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
