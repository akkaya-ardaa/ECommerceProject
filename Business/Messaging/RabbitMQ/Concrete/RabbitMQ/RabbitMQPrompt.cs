using System;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Newtonsoft.Json;

namespace Business.Messaging.RabbitMQ.Concrete.RabbitMQ
{
	public class RabbitMQPrompt<TEntity>
		where TEntity : BaseEntity, new()
	{
		public PromptType PromptType { get; set; }
		public TEntity Entity { get; set; }

        public override string ToString()
        {
			return JsonConvert.SerializeObject(this);
        }
    }

	public enum PromptType
	{
		Add,
		Update,
		Delete
	}
}

