namespace Algorithms.Trees.Traversal;

internal class PreOrderTreeTraverser : ITraverseTree
{
    public IEnumerable<int> Traverse(BstNode tree)
    {
        if (tree == null)
            return Enumerable.Empty<int>();

        List<int> result = new();

        result.Add(tree.Value);
        result.AddRange(Traverse(tree.Left));
        result.AddRange(Traverse(tree.Right));

        return result;
    }
}
