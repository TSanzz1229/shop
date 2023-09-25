using Phone.Data.Data;
using Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.Data.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private ApplicationDBContext _context;
		public ProductRepository(ApplicationDBContext context) : base(context)
		{
			_context = context;
		}
		public void Update(Product product)
		{
			var categoryDB = _context.Products.FirstOrDefault(x => x.Id == product.Id);
			if (categoryDB != null)
			{
				categoryDB.Name = product.Name;
				categoryDB.Description = product.Description;
				categoryDB.Price = product.Price;
				if(product.Image!= null)
				{
					categoryDB.Image = product.Image;
				}

			}
		}
	}
}
