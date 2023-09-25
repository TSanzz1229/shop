﻿using Phone.Data.Data;
using Phone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone.Data.Repositories
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private  ApplicationDBContext _context;
		public CategoryRepository(ApplicationDBContext context) : base(context) 
		{
			_context = context;
		}
		public void Update(Category category)
		{
			var categoryDB = _context.Categories.FirstOrDefault( x => x.ID == category.ID);
			if (categoryDB != null)
			{
				categoryDB.Name = category.Name;
				categoryDB.DisplayOrder = category.DisplayOrder;
			}
		}
	}
}
