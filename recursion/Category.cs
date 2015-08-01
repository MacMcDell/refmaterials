using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion
{
  public  class Category
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Category> Children { get; set; }
        public int? ParentId { get; set; }
    }
}
