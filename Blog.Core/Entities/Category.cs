using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }             // Primary Key
        public string Name { get; set; }        // Kategori adı

        // Her kategorinin birden fazla post'u olabilir
        public List<Post> Posts { get; set; }
    }
}
