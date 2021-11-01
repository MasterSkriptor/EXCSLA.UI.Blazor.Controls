using EXCSLA.Shared.UI.Blazor.Client.ServerSideValidator;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class TemplatedForm<TItem> : ComponentBase
    {
        private Dictionary<string, List<string>> _errors = new();

        [Parameter] public TItem Item { get; set; } = Activator.CreateInstance<TItem>();
        [Parameter] public RenderFragment<TItem> FormTemplate { get; set; }
        [Parameter] public EventCallback<TItem> OnSave { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnCancel { get; set; }
        [Parameter] public EventCallback<string> OnFieldChanged { get; set; }
        [Parameter] public EventCallback<bool> OnValidated { get; set; }
        [Parameter] public string SaveButtonTitle { get; set; } = "Save";
        [Parameter] public string CancelButtonTitle { get; set; } = "Cancel";
        [Parameter] public bool SaveButtonDisabled { get; set; } = true;
        [Parameter] public bool CancelButtonDisabled { get; set; } = false;
        [Parameter] public Dictionary<string, List<string>> Errors { get => _errors; set { _errors = value; DisplayErrors(value); } }
        [Parameter] public ServerSideValidator ServerSideValidator { get; set; }

        public InputWatcher InputWatcher { get; set; }

        protected async Task HandleSave()
        {
            await OnSave.InvokeAsync(Item);
        }

        protected async Task HandleCancel(MouseEventArgs e)
        {
            await OnCancel.InvokeAsync(e);
        }

        protected async Task HandleFieldChanged(string field)
        {
            if (InputWatcher.Validate())
            {
                await OnValidated.InvokeAsync(true);
                SaveButtonDisabled = false;
            }
            else SaveButtonDisabled = true;
            await OnFieldChanged.InvokeAsync(field);
        }

        private void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            if (errors != null && errors.Count > 0)
                ServerSideValidator?.DisplayErrors(errors);
        }
    }
}
