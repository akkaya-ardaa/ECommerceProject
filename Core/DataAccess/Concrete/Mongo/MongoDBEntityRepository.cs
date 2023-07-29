using System;
using System.Linq.Expressions;
using Core.DataAccess.Abstract;
using Core.DataAccess.Configuration;
using Core.Entities.Concrete;
using MongoDB.Driver;

namespace Core.DataAccess.Concrete.Mongo
{
	public class MongoDBEntityRepository<TEntity, TOptions> : IEntityRepository<TEntity>
		where TEntity : BaseEntity, new()
		where TOptions : IMongoOptions, new()
	{
		private readonly IMongoCollection<TEntity> _collection;
		public MongoDBEntityRepository(TOptions options)
		{
			var connectionString = options.ConnectionString;
			var databaseName = options.DatabaseName;

			var database = new MongoClient(connectionString).GetDatabase(databaseName);
			var collection = database.GetCollection<TEntity>($"{typeof(TEntity).Name}s");
			_collection = collection;
		}

        public async Task AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null ?
                (int)await _collection.CountDocumentsAsync(filter) :
                (int)await _collection.CountDocumentsAsync(Builders<TEntity>.Filter.Empty);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _collection.DeleteOneAsync(e => e.Id == entity.Id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null ?
                (await _collection.FindAsync(filter)).ToEnumerable() :
                (await _collection.FindAsync(Builders<TEntity>.Filter.Empty)).ToEnumerable();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await (await _collection.FindAsync(filter)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> SkipTakeAsync(int skip = 0, int take = 100, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> sortBy = null, bool sortByDescending = true)
        {
            return (await _collection.FindAsync(filter != null ? filter : Builders<TEntity>.Filter.Empty, new FindOptions<TEntity, TEntity>
            {
                Skip = skip,
                Limit = take,
                Sort = sortBy != null ? (sortByDescending ? Builders<TEntity>.Sort.Descending(sortBy) : Builders<TEntity>.Sort.Ascending(sortBy)) : null
            })).ToEnumerable();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync(t => t.Id == entity.Id, entity);
        }
    }
}

