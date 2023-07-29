using System;
namespace Core.DataAccess.Configuration
{
	public interface IMongoOptions
	{
		string ConnectionString { get; }
		string DatabaseName { get; }
	}
}

