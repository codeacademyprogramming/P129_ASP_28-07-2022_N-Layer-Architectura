using P129NLayerArchitectura.Core.Entities;
using P129NLayerArchitectura.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace P129NLayerArchitectura.Data.Repositories
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
    }
}
