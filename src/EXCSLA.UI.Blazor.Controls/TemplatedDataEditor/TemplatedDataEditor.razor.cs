using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class TemplatedDataEditor<TItem> : ComponentBase
    {
        [Parameter] public List<TItem> Items { get; set; }
        [Parameter] public TItem SelectedItem { get; set; }

        [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }
        [Parameter] public RenderFragment<TItem> FormTemplate { get; set; }
        [Parameter] public RenderFragment NavBarTemplate { get; set; }

        [Parameter] public EventCallback<string> OnSearch { get; set; }
        [Parameter] public EventCallback<TItem> OnItemSelected { get; set; }
        [Parameter] public EventCallback<TItem> OnSave { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnCancel { get; set; }
        [Parameter] public EventCallback<bool> OnValidated { get; set; }
        [Parameter] public EventCallback<string> OnFieldChanged { get; set; }

        [Parameter] public bool ListIsSearchable { get; set; } = false;
        [Parameter] public bool IsSaveButtonDisabled { get; set; } = true;
        [Parameter] public bool IsCancelButtonDisabled { get; set; } = true;

        [Parameter] public string LoadingMessage { get; set; } = "Loading...";
        [Parameter] public string SearchText { get; set; } = string.Empty;
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

        protected async Task HandleSave(TItem item)
        {
            await OnSave.InvokeAsync(item);
        }

        protected async Task HandleOnCancel(MouseEventArgs e)
        {
            await OnCancel.InvokeAsync(e);
        }

        protected async Task HandleOnValidated(bool value)
        {
            await OnValidated.InvokeAsync(value);
        }

        protected async Task HandleOnFieldChanged(string value)
        {
            await OnFieldChanged.InvokeAsync(value);
        }
    }
}
