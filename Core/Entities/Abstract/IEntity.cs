using System;
using MongoDB.Bson;

namespace Core.Entities.Abstract
{
	public interface IEntity
	{
		string Id { get; set; }
	}
}

