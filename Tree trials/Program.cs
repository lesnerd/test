using System;

namespace Tree_trials
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeToMirror tree = new BinaryTreeToMirror();
            tree.GenerateDummyTree();
            tree.Print(tree.tree);
            BinaryNode mirrorTree = tree.GetMirrorBinaryTree(tree.tree);
            tree.Print(mirrorTree);


            tree = new BinaryTreeToMirror();
            tree.CreateTreeForDistinctPaths();
            tree.Print(tree.tree);
            int result = tree.FindMaxNumOfDistinctValues(tree.tree);
        }
    }
}