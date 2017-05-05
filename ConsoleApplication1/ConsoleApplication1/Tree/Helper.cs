using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Tree
{
   public class Helper
    {
        private static string leftHandler = "/";
        private static string RightHandler = "\\";

        public static int height = 0;
        static object loc = new object();
        static List<int> widths = new List<int>();

        public static TreeNode BuildTree()
        {
            TreeNode rLeft = new TreeNode();
            TreeNode rRight = new TreeNode();

            TreeNode root = new TreeNode();
            root.Parent = null;
            root.Left = rLeft;
            root.Right = rRight;
            root.Left.Parent = root;
            root.Right.Parent = root;

            TreeNode L = new TreeNode();
            TreeNode R = new TreeNode();
            root.Left.Left = L;
            root.Left.Right = R;
            root.Left.Left.Parent = root.Left;
            root.Left.Right.Parent = root.Left;

            TreeNode L1 = new TreeNode();
            TreeNode R1 = new TreeNode();
            root.Right.Left = L1;
            root.Right.Right = R1;
            root.Right.Value = Guid.NewGuid().ToString();
            root.Right.Right.Parent = root.Right;
            root.Right.Left.Parent = root.Right;

            root.Left.Left.Left = new TreeNode();
            root.Left.Left.Right = new TreeNode();
            root.Left.Left.Left.Parent = root.Left.Left.Left;
            root.Left.Left.Right.Parent = root.Left.Left.Left;

            root.Left.Right.Right = new TreeNode();

            return root;
        }

        public static Tuple<int,int,int, List<Position>> WalkthroughTree(TreeNode root)
        {
            var nodeList = new List<Position>();
            GetTreeHeight(nodeList, root,0,1);
            var min = (from i in nodeList
                       select i.Width).Min();
            var max = (from i in nodeList
                       select i.Width).Max();

            return new Tuple<int, int, int,List<Position>>(height, min, max, nodeList);     
        }

        public static void GetTreeHeight(List<Position> widths, TreeNode root, int level, int width)
        {
            if (root != null)
            {
                widths.Add(new Position() { NodeValue = root.Value, Width = width, Height = level } );
                UpdateHeight(level);
                GetTreeHeight(widths, root.Left, level + 1, width -1);
                GetTreeHeight(widths, root.Right, level + 1, width + 1);
            }
        }

        public static void PrintTree(TreeNode root)
        {
            var tupe = WalkthroughTree(root);

        }


        #region Private

        //public static void PrintTree(TreeNode node, int levelHeight,int leftWidth, int height, List<Position> widths)
        //{
        //    if (node == null)
        //    {
        //        return;
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < position; i++)
        //    {
        //        sb.Append(" ");
        //    }

        //    sb.Append(node.Value);
        //    Console.WriteLine(sb.ToString());

        //    var h = height - levelHeight;
        //    while (h > 0)
        //    {
        //        sb.Clear();

        //        for (int i = 0; i < position; i++)
        //        {
        //            sb.Append(" ");
        //        }
        //    }

        //}

        private static void UpdateHeight(int level)
        {
            lock (loc)
            {
                height = level > height ? level : height;
            }
        }

        #endregion

    }

    public class Position
    {
        public string NodeValue { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
