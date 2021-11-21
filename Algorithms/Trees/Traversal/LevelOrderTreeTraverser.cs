namespace Algorithms.Trees.Traversal;

internal class LevelOrderTreeTraverser : ITraverseTree
{
    public IEnumerable<int> Traverse(BstNode tree)
    {
        var queue = new Queue<BstNode>();
        queue.Enqueue(tree);

        List<int> result = new();

        while (queue.TryDequeue(out BstNode? node))
        {
            if (node.Left != null)
                queue.Enqueue(node.Left);

            if (node.Right != null)
                queue.Enqueue(node.Right);

            result.Add(node.Value);
        }

        return result;
    }
}
