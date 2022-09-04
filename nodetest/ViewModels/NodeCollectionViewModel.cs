using System.Collections;
using nodetest.Models;
using nodetest.Models.Nodes;
using nodetest.Shared;

namespace nodetest.ViewModels;

public class NodeCollectionViewModel
{
    public HashSet<NodeViewModel> KnownNodes = new();

    private NodeViewModel Root;

    private Vector2 Margin = new() { X = 40, Y = 40 };

    public Dictionary<int, List<NodeViewModel>> NodesByLevel { get; set; } = new();

    public NodeCollectionViewModel(NodeViewModel root)
    {
        Root = root;
        Process();
    }

    void Process()
    {
        AssignLevels(Root);
        CalculateY();
    }

    void CalculateY()
    {
       

        var levelHeightDictionary = NodesByLevel.ToDictionary(
            levelNodes => levelNodes.Key,
            levelNodes => levelNodes.Value.Select(node => node.Height).Sum() + (levelNodes.Value.Count + 1) * Margin.Y);


        var maxHeight = levelHeightDictionary.Values.Max();

        var currentX = Margin.X;
        foreach (var (level, nodes) in NodesByLevel.
                     OrderBy(levelNodes => levelNodes.Key))
        {
            var levelHeight = levelHeightDictionary[level];

          
            var maxWidthInLevel = nodes.MaxBy(node => node.Width)!.Width;

            var startY = (maxHeight - levelHeight) / 2;

            var currentY = startY;

            foreach (var node in nodes)
            {
                node.Position.Y = currentY;
                node.Position.X = currentX;
                currentY += node.Height + Margin.Y;
            }

            currentX += maxWidthInLevel + Margin.X;


        }
    }

    void AssignLevels(NodeViewModel nodeViewModel, int currentLevel = 0)
    {
        if (KnownNodes.Contains(nodeViewModel))
        {
            return;
        }

        KnownNodes.Add(nodeViewModel);

        foreach (var transput in nodeViewModel.GetInputNodes().Concat(nodeViewModel.GetOutputNodes()))
        {
            if (transput is NodeViewModel transputViewModel)
            {
                AssignLevels(transputViewModel, currentLevel + 1);
            }
            else
            {
                throw new InvalidOperationException();
            }
            
        }


        if (NodesByLevel.TryGetValue(currentLevel, out var list))
        {
            list.Add(nodeViewModel);
            return;
        }

        NodesByLevel[currentLevel] = new List<NodeViewModel>() { nodeViewModel };
    }
}