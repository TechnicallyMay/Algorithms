namespace Algorithms.Trees;

internal class BstNode
{
    public BstNode(int value)
    {
        Value= value;
    }

    public int Value { get; set; }

    public BstNode? Left { get; set; }

    public BstNode? Right { get; set; }

    public void Add(int value)
    {
        if (value > Value)
        {
            if (Right == null)
                Right = new BstNode(value);
            else
                Right.Add(value);
        }
        else
        {
            if (Left == null)
                Left = new BstNode(value);
            else
                Left.Add(value);
        }
    }
}
