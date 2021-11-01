using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class TemplatedDataTable<TItem> : ComponentBase
    {
        [Parameter] public List<TItem> Items { get; set; }
        [Parameter] public TItem SelectedItem { get; set; }
        [Parameter] public Dictionary<string, int> ReportBarFilters { get; set; }
        [Parameter] public List<string> Filters { get; set; }
        [Parameter] public string SelectedFilter { get; set; } = string.Empty;

        [Parameter] public RenderFragment NavBarTemplate { get; set; }
        [Parameter] public RenderFragment HeaderTemplate { get; set; }
        [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }

        [Parameter] public EventCallback<string> OnSelectedFilterChanged { get; set; }
        [Parameter] public EventCallback<TItem> OnSelectedChanged { get; set; }

        [Parameter] public string LoadingMessage { get; set; } = string.Empty;

        [Parameter] public bool HasReportBar { get; set; } = false;
        [Parameter] public bool HasFilter { get; set; } = false;
        [Parameter] public bool HasNavBar { get; set; } = false;

        protected async Task HandleSelectedFilterChanged(string filter)
        {
            await OnSelectedFilterChanged.InvokeAsync(filter);
        }

        protected async Task HandleOnSelectedChanged(TItem item)
        {
            SelectedItem = item;
            await OnSelectedChanged.InvokeAsync(item);
        }

    }
}
