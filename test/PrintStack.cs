using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{


    public class node
    {
        public node(int value)
            : this(value, new List<node>())
        {

        }
        public void print(node root)
        {
            Queue q = new Queue();
            int levelNodes = 0;
            if (root == null) return;
            q.Enqueue(root);
            while (q.Count != 0)
            {
                levelNodes = q.Count;
                while (levelNodes > 0)
                {
                    node n = (node)q.Dequeue();
                    Console.Write(" " + n.value);
                    if (n.childeren != null)
                    {
                        foreach (var VARIABLE in n.childeren)
                        {
                            q.Enqueue(VARIABLE);    
                        }
                        
                    }
                    levelNodes--;
                }
                Console.WriteLine();
            }

        }

        public node(int value, List<node> children)
        {
            this.childeren = children;
            this.value = value;
        }

        public List<node> childeren = new List<node>();
        public int value;
    }


    public class PrintStack
    {
        public node root;


        public void Build()
        {
            root = new node(1, new List<node>()
            {
                new node(2, new List<node>
                {
                    new node(6), new node(7)
                
                }), new node(4, new List<node>
                {
                    new node(8, new List<node>
                    {
                        new node(9)
                    
                    })
                
                }), new node(5, new List<node>
                {
                    new node(10)
                
                })
            });

        }





    }
}
