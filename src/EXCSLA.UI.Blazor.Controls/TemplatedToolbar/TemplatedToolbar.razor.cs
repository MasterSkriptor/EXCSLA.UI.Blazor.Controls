using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class TemplatedToolbar : ComponentBase
    {
        [Parameter] public bool HasSearch { get; set; } = false;
        [Parameter] public string SearchText { get; set; } = string.Empty;
        [Parameter] public bool SearchOnKeyPress { get; set; } = true;

        [Parameter] public EventCallback<string> OnSearch { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        protected async Task HandleSearchOnKeyPress(KeyboardEventArgs args)
        {
            if(SearchOnKeyPress)
                await OnSearch.InvokeAsync(SearchText);
        }

        protected async Task HandleSearchOnClick(MouseEventArgs args)
        {
            await OnSearch.InvokeAsync(SearchText);
        }
    }
}
