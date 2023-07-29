using System;
using Core.DataAccess.Concrete.Mongo;
using Core.DataAccess.Configuration;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.Mongo
{
    public class MCategoryDal : MongoDBEntityRepository<Category, MongoOptions>, ICategoryDal
    {
        public MCategoryDal(MongoOptions options) : base(options)
        {
        }
    }
}

