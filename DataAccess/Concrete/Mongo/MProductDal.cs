using System;
using Core.DataAccess.Concrete.Mongo;
using Core.DataAccess.Configuration;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.Mongo
{
    public class MProductDal : MongoDBEntityRepository<Product, MongoOptions>, IProductDal
    {
        public MProductDal(MongoOptions options) : base(options)
        {
        }
    }
}

