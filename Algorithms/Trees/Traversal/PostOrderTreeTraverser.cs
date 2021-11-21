namespace Algorithms.Trees.Traversal;

internal class PostOrderTreeTraverser : ITraverseTree
{
    public IEnumerable<int> Traverse(BstNode tree)
    {
        if (tree == null)
            return Enumerable.Empty<int>();

        List<int> result = new();

        result.AddRange(Traverse(tree.Left));
        result.AddRange(Traverse(tree.Right));
        result.Add(tree.Value);

        return result;
    }
}
