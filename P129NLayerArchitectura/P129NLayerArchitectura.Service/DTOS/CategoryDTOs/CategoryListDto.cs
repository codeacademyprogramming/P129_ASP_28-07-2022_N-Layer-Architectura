using System;
using System.Collections.Generic;
using System.Text;

namespace P129NLayerArchitectura.Service.DTOS.CategoryDTOs
{
    public  class CategoryListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
    }
}
