using Phone.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.Data.Repositories
{
	public class Unit : IUnit
	{
		private ApplicationDBContext _context;
		public IProductRepository Product { get; private set; }
		public ICategoryRepository Category { get; private set; }

		public Unit (ApplicationDBContext context)
		{
			_context = context;
			Category = new CategoryRepository(context);
			Product = new ProductRepository(context);
		}
		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
