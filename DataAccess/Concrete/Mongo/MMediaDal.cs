using System;
using Core.DataAccess.Concrete.Mongo;
using Core.DataAccess.Configuration;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.Mongo
{
    public class MMediaDal : MongoDBEntityRepository<Media, MongoOptions>, IMediaDal
    {
        public MMediaDal(MongoOptions options) : base(options)
        {
        }
    }
}

