using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorOpenApi;

internal class ExpandoTree : IExpandoTree
{
    private readonly Dictionary<string, ExpandoTreeNode> _nodes = new();
    private readonly List<string> _order = new();

    public void Add(string name, string anchor, string parentAnchor, bool collapsed)
    {
        if (_nodes.ContainsKey(anchor))
        {
            throw new InvalidOperationException($"A node with anchor '{anchor}' already exists.");
        }

        var node = new ExpandoTreeNode
        {
            Name         = name,
            Anchor       = anchor,
            ParentAnchor = parentAnchor,
            Collapsed    = collapsed
        };

        _nodes[anchor] = node;
        _order.Add(anchor);
    }

    public void Collapse(string anchor, bool collapsed)
    {
        if (_nodes.TryGetValue(anchor, out var node))
        {
            node.Collapsed = collapsed;
        }
        else
        {
            throw new KeyNotFoundException($"No node found with anchor '{anchor}'.");
        }
    }

    public bool IsCollapsed(string anchor)
    {
        return _nodes.TryGetValue(anchor, out var node) && node.Collapsed;
    }

    public bool Exists(string anchor) => _nodes.ContainsKey(anchor);

    public ExpandoTreeNode[] GetChildren(string anchor) => _order
            .Where(x => _nodes[x].ParentAnchor == anchor)
            .Select(x => _nodes[x])
            .ToArray();
}
