using System;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
	public class Product : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Barcode { get; set; }
		public Media? FeaturedImage { get; set; }
		public IList<Category>? Categories { get; set; }
		public IList<Media>? Medias { get; set; }
		public int UnitPrice { get; set; }
	}
}

