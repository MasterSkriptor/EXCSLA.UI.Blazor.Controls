using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class TemplatedModalForm<TItem> : ComponentBase
    {
        private Dictionary<string, List<string>> _errors = new();

        [Parameter] public TItem Item { get; set; } = Activator.CreateInstance<TItem>();
        [Parameter] public RenderFragment<TItem> FormTemplate { get; set; }
        [Parameter] public EventCallback<TItem> OnSave { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnCancel { get; set; }
        [Parameter] public string SaveButtonTitle { get; set; } = "Save";
        [Parameter] public string CancelButtonTitle { get; set; } = "Cancel";
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public bool IsOpen { get; set; } = false;
        [Parameter] public bool SaveButtonDisabled { get; set; } = true;
        [Parameter] public bool CancelButtonDisabled { get; set; } = false;

        [Parameter] public Dictionary<string, List<string>> Errors { get => _errors; set { _errors = value; } }

        protected async Task HandleSave(TItem item)
        {
            await OnSave.InvokeAsync(item);
        }

        protected async Task HandleCancel(MouseEventArgs e)
        {
            await OnCancel.InvokeAsync(e);
        }

    }
}
