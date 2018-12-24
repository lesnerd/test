using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tree_trials
{
    public class BinaryNode
    {
        public int data;
        public BinaryNode left;
        public BinaryNode right;

        public BinaryNode(int data)
        {
            this.data = data;
        }
    }

    class NodeInfo
    {
        public BinaryNode Node;
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
        public NodeInfo Parent, Left, Right;
    }

    public class BinaryTreeToMirror
    {
        public BinaryNode tree;
        IDictionary<int, int> visited = new Dictionary<int, int>();
        private int distinct = 0;
        private int maximum = 0 ;
        public void GenerateDummyTree()
        {
            tree = new BinaryNode(1);
            tree.left = new BinaryNode(9);
            tree.left.left = new BinaryNode(4);
            tree.left.right = new BinaryNode(50);
            tree.right = new BinaryNode(12);
            tree.right.right = new BinaryNode(7);
        }

        public void CreateTreeForDistinctPaths()
        {
            tree = new BinaryNode(4);
            tree.left = new BinaryNode(5);
            tree.left.left = new BinaryNode(4);
            tree.left.left.left = new BinaryNode(5);
            tree.right = new BinaryNode(6);
            tree.right.right = new BinaryNode(6);
            tree.right.left = new BinaryNode(1);
        }

        public BinaryNode GetMirrorBinaryTree(BinaryNode Btree)
        {
            if (Btree == null)
                return null;

            BinaryNode newTree = new BinaryNode(Btree.data);

            newTree.left = GetMirrorBinaryTree(Btree.right);
            newTree.right = GetMirrorBinaryTree(Btree.left);

            return newTree;
        }

        public int FindMaxNumOfDistinctValues(BinaryNode Btree)
        {
            if (Btree == null)
                return 0;

            if (!visited.ContainsKey(Btree.data))//visited[Btree.data] == 0)
                distinct++;

            maximum = Math.Max(maximum, distinct);

            if (visited.ContainsKey(Btree.data))
                visited[Btree.data]++;
            else
                visited.Add(Btree.data,1);
            //visited[Btree.data]++;

            FindMaxNumOfDistinctValues(Btree.left);
            FindMaxNumOfDistinctValues(Btree.right);

            if (visited.ContainsKey(Btree.data))
                visited[Btree.data]--;
            if (visited.ContainsKey(Btree.data))
                if (visited[Btree.data] == 0)
                distinct--;

            return maximum;
        }

        public void Print(BinaryNode root, int topMargin = 4, int leftMargin = 4)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.data.ToString(" 0 ") };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.left ?? next.right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
    }


}
