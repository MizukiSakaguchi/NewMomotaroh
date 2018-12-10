using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class CategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public CategoryDto(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
