using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class TemplatedDataViewer<TItem> : ComponentBase
    {
        [Parameter] public List<TItem> Items { get; set; }
        [Parameter] public TItem SelectedItem { get; set; }

        [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }
        [Parameter] public RenderFragment<TItem> ViewerTemplate { get; set; }
        [Parameter] public RenderFragment NavBarTemplate { get; set; }

        [Parameter] public EventCallback<string> OnSearch { get; set; }
        [Parameter] public EventCallback<TItem> OnItemSelected { get; set; }
        [Parameter] public bool ListIsSearchable { get; set; } = false;

        [Parameter] public string LoadingMessage { get; set; } = "Loading...";
        [Parameter] public string SearchText { get; set; } = string.Empty;
        [Parameter] public string LoadingAnimationColor { get; set; } = "#206994";
        [Parameter] public string LogoUrl { get; set; } = "../imgs/logo.png";
        [Parameter] public Dictionary<string, List<string>> Errors { get; set; }

        protected async Task HandleSearch(string searchString)
        {
            SearchText = searchString;
            await OnSearch.InvokeAsync(searchString);
        }

        protected async Task HandleItemSelected(TItem item)
        {
            SelectedItem = item;
            await OnItemSelected.InvokeAsync(item);
        }
    }
}
