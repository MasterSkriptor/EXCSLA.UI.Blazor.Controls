using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public class InputWatcher : ComponentBase, IDisposable
    {
        //private EditContext editContext;

        [CascadingParameter]
        protected EditContext EditContext { get; set; }

        [Parameter]
        public EventCallback<string> FieldChanged { get; set; }

        protected override Task OnInitializedAsync()
        {
            if(EditContext == null)
            {
                throw new InvalidOperationException($"{nameof(InputWatcher)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. For example, you can use {nameof(InputWatcher)} " +
                    $"inside an {nameof(EditForm)}.");
            }

            EditContext.OnFieldChanged += async (sender, e) =>
            {
                await FieldChanged.InvokeAsync(e.FieldIdentifier.FieldName);
            };

            return base.OnInitializedAsync();
        }

        public bool Validate()
        => EditContext?.Validate() ?? false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                EditContext.OnFieldChanged -= async (sender, e) =>
                {
                    await FieldChanged.InvokeAsync(e.FieldIdentifier.FieldName);
                };
            }
        }
    }
}