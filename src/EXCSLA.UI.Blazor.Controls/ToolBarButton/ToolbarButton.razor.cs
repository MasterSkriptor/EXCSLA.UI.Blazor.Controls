using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class ToolbarButton : ComponentBase
    {
        [Parameter] public string Id { get; set; } = Guid.NewGuid().ToString();
        [Parameter] public Placement TooltipPlacement { get; set; } = Placement.Top;
        [Parameter] public string Tooltip { get; set; } = string.Empty;
        [Parameter] public bool IsDisabled { get; set; } = false;
        [Parameter] public string ButtonCss { get; set; } = "btn btn-light";
        [Parameter] public string IconCss { get; set; } = "oi oi-plus text-success";

        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        protected async Task HandleOnClick(MouseEventArgs e)
        {
            await OnClick.InvokeAsync(e);
        }

    }
}
