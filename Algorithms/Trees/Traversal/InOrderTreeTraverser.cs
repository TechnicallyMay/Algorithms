namespace Algorithms.Trees.Traversal;

internal class InOrderTreeTraverser : ITraverseTree
{
    public IEnumerable<int> Traverse(BstNode tree)
    {
        if (tree == null)
            return Enumerable.Empty<int>();

        List<int> result = new();

        result.AddRange(Traverse(tree.Left));
        result.Add(tree.Value);
        result.AddRange(Traverse(tree.Right));

        return result;
    }
}
