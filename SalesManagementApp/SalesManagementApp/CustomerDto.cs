using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class CustomerDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }

        public CustomerDto(string id, string name, string tel)
        {
            this.Id = id;
            this.Name = name;
            this.Tel = tel;
        }

    }
}
