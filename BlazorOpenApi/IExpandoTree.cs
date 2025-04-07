using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorOpenApi;

public class ExpandoTreeNode
{
    public string Name { get; set; } = string.Empty;
    public string Anchor { get; set; } = string.Empty;
    public string ParentAnchor { get; set; } = string.Empty;
    public bool Collapsed { get; set; }
}

public interface IExpandoTree
{
    void Add(string name, string anchor, string parentAnchor, bool collapsed);
    void Collapse(string anchor, bool collapsed);
    bool IsCollapsed(string anchor);
    bool Exists(string anchor);
    ExpandoTreeNode[] GetChildren(string anchor);
}

//implement IExpandoTree