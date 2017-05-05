using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Tree
{
  public class TreeNode
    {
        public TreeNode()
        {
            Value = (new Random()).Next(100).ToString();
        }
        public string Value { get; set; }
        public Color Color { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}
