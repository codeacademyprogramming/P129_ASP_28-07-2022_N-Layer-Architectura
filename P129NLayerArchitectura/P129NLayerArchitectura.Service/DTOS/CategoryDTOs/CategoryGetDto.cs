using System;
using System.Collections.Generic;
using System.Text;

namespace P129NLayerArchitectura.Service.DTOS.CategoryDTOs
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }

        public CategoryGetDto Parent { get; set; }
        public IEnumerable<CategoryGetDto> Children { get; set; }
    }
}
