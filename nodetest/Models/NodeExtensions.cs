namespace nodetest.Models;

static class NodeExtensions
{
    static bool CanAttachOutput(this INode node, INode output)
    {
        return node.Outputs.CanAdd(new Connection(node, output));
    }

    static bool CanAttachInput(this INode node, INode input)
    {
        return node.Inputs.CanAdd(new Connection(input, node));
    }

    public static void AttachInput(this INode node, INode input)
    {
        node.Inputs.Add(new Connection(input, node));
    }

    public static void AttachOutput(this INode node, INode output)
    {
        node.Outputs.Add(new Connection(node, output));
    }

    public static void Connect(this INode node, INode target)
    {
        target.AttachInput(node);
        node.AttachOutput(target);
    }

    public static IEnumerable<INode> GetInputNodes(this INode node)
    {
        return node.Inputs.Select(connection => connection.From);
    }
    
    public static IEnumerable<INode> GetOutputNodes(this INode node)
    {
        return node.Outputs.Select(connection => connection.To);
    }
}