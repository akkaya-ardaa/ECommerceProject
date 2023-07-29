using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
	public class Media : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string PhysicalPath { get; set; }
		public string WebPath { get; set; }
	}
}

