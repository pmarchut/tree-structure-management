using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalAuthDemo.Models
{
    public class Node
    {
        public Node()
        {
            SubNodes = new List<Node>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public virtual Node ParentNode { get; set; }

        public virtual List<Node> SubNodes { get; set; }

        public List<User> Users { get; set; }
    }
}
