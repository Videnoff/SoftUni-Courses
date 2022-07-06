namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private bool IsRootDeleted { get; set; }

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.children = new List<Tree<T>>();
            this.IsRootDeleted = false;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            List<T> result = new List<T>();

            if (IsRootDeleted)
            {
                return result;
            }

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node.Value);
                
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> result = new List<T>();

            if (IsRootDeleted)
            {
                return result;
            }

            this.Dfs(this, result);

            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var node = FindNode(this, parentKey);
            
            CheckEmptyNode(node);
            
            node.children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindNode(this, nodeKey);
            CheckEmptyNode(searchedNode);

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;
            }

            searchedNode.children.Clear();
            searchedNode.Value = default(T);

            Tree<T> searchedParent = searchedNode.Parent;

            if (searchedParent == null)
            {
                IsRootDeleted = true;
            }
            else
            {
                searchedParent.children.Remove(searchedNode);
            }
        }
        
        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindNode(this, firstKey);
            var secondNode = FindNode(this, secondKey);

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                var tempValue = firstNode.Value;
                var tempChildren = firstNode.Children;
                firstNode.Value = secondNode.Value;
                secondNode.Value = tempValue;

                firstNode.children.Clear();
                
                foreach (var child in secondNode.children)
                {
                    firstNode.AddChild(secondKey, child);
                }

                secondNode.children.Clear();
                
                foreach (var child in tempChildren)
                {
                    secondNode.AddChild(tempValue, child);
                }
            } else if (secondParent == null)
            {
                var tempValue = secondNode.Value;
                var tempChildren = secondNode.children;
                secondNode.Value = firstNode.Value;
                firstNode.Value = tempValue;
                
                secondNode.children.Clear();
                
                foreach (var child in firstNode.children)
                {
                    secondNode.AddChild(firstKey, child);
                }
                
                firstNode.children.Clear();
                
                foreach (var child in tempChildren)
                {
                    firstNode.AddChild(tempValue, child);
                }
            }
            else
            {
                firstNode.Parent = secondParent;
                secondNode.Parent = firstParent;

                var indexOfFirst = firstParent.children.IndexOf(firstNode);
                var indexOfSecond = secondParent.children.IndexOf(secondNode);

                firstParent.children[indexOfFirst] = secondNode;
                secondParent.children[indexOfSecond] = firstNode;
            }
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }
            
            result.Add(tree.Value);
        }

        private Tree<T> FindNode(Tree<T> root, T searchedValue)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Value.Equals(searchedValue))
                {
                    return node;
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
        
        private void CheckEmptyNode(Tree<T> searchedNode)
        {
            if (searchedNode == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
