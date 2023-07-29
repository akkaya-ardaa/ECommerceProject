using System;
namespace Core.DataAccess.Configuration
{
	public class MongoOptions : IMongoOptions
	{
		public string ConnectionString { get; private set; }
		public string DatabaseName { get; private set; }
	}
}

