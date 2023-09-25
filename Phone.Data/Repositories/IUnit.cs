using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.Data.Repositories
{
	public interface IUnit
	{
		ICategoryRepository Category { get; }
		 
		IProductRepository Product { get; }

		void Save();
	}
}
