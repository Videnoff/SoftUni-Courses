using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                this.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return this.GetAsString(0).Trim();
        }

        private string GetAsString(int indentation = 0)
        {
            var result = new string(' ', indentation) + this.Key + "\r\n";

            foreach (var child in this.Children)
            {
                result += child.GetAsString(indentation + 2);
                
            }

            return result;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var node = this;
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                var list = node.Children.ToList();

                for (int i = list.Count - 1; i >= 0; i--)
                {
                    queue.Enqueue(list[i]);
                }
            }

            return node;
        }

        public List<T> GetLeafKeys()
        {
            var leafNodes = this.GetLeafNodes();
            
            return leafNodes.Select(x => x.Key).ToList();
        }

        private List<Tree<T>> GetLeafNodes()
        {
            var leafNodes = new List<Tree<T>>();
            
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Count == 0)
                {
                    leafNodes.Add(node);
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return leafNodes;
        }

        public List<T> GetMiddleKeys()
        {
            var notes = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }

                if (current.Parent != null && current.Children.Count >= 1)
                {
                    notes.Add(current.Key);
                }
            }

            return notes;
        }

        public List<T> GetLongestPath()
        {
            var current = this.GetDeepestLeftomostNode();

            var longestPath = new List<T>();

            while (current.Parent != null)
            {
                longestPath.Add(current.Key);
                current = current.Parent;
            }

            longestPath.Add(current.Key);

            longestPath.Reverse();

            return longestPath;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var leafNodes = this.GetLeafNodes();
            var result = new List<List<T>>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                var currentSum = 0;
                var currentNodes = new List<T>();

                while (node != null)
                {
                    currentNodes.Add(node.Key);
                    currentSum += Convert.ToInt32(node.Key);
                    node = node.Parent;
                }

                if (currentSum == sum)
                {
                    currentNodes.Reverse();
                    result.Add(currentNodes);
                }
            }

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var roots = new List<Tree<T>>();

            SubTreeSumDFS(this, sum, roots);

            return roots;
        }

        private int SubTreeSumDFS(Tree<T> node, int targetSum, List<Tree<T>> roots)
        {
            var currentSum = Convert.ToInt32(node.Key);
            
            foreach (var child in node.Children)
            {
                currentSum += SubTreeSumDFS(child, targetSum, roots);
            }

            if (currentSum == targetSum)
            {
                roots.Add(node);
            }

            return currentSum;
        }
    }
}
