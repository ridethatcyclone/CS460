using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// A single-linked Node class.
    /// </summary>
    public class Node
    {
        public Object data;
        public Node next;

        public Node(object newItem)
        {
            data = null;
            next = null;
        }

        public Node(Object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
