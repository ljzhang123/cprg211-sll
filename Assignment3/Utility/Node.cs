using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
	public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }

        public Node(object data) 
        {
            this.Data = data;
            this.Next = null;
        }

        public Node(object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
