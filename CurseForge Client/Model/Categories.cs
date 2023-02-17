using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurseForgeClient.Model
{
    public class Categories
    {
        public List<Category> Data { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }
        public string ClassId { get; set; }
    }
}
