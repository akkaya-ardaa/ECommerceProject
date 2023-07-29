using System;
using Core.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.Concrete
{
	public abstract class BaseEntity : IEntity
	{
		[BsonId]
		public string Id { get; set; }
	}
}

