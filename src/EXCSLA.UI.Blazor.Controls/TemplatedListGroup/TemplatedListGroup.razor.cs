using BlazorStrap;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class TemplatedListGroup<TItem> : ComponentBase
    {
        [Parameter] public RenderFragment CommandBar { get; set; }
        [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }
        [Parameter] public RenderFragment StatusBar { get; set; }
        [Parameter] public ListGroupType ListGroupType { get; set; } = ListGroupType.Button;
        [Parameter] public bool HasCommandBar { get; set; } = false;
        [Parameter] public bool HasStatusBar { get; set; } = false;
        [Parameter] public string Title { get; set; }
        [Parameter] public List<TItem> Items { get; set; }
    }
}
