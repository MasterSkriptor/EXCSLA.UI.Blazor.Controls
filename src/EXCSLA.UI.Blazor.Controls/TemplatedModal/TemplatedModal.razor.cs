using BlazorStrap;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class TemplatedModal<TItem>
    {
        protected BSModal Modal { get; set; }

        [Parameter] public bool IsOpen { get; set; } = false;
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public TItem Item { get; set; }
        [Parameter] public RenderFragment<TItem> ItemTemplate { get; set; }
        [Parameter] public EventCallback<TItem> OnSave { get; set; }
        [Parameter] public EventCallback OnCancel { get; set; }
        [Parameter] public Size Size { get; set; } = Size.Medium;
        [Parameter] public Color SaveColor { get; set; } = Color.Primary;
        [Parameter] public string SaveText { get; set; } = "Save";
        [Parameter] public string CancelText { get; set; } = "Cancel";


        public void HandleCancel()
        {
            OnCancel.InvokeAsync(null);
            IsOpen = false;

        }

        public async Task HandleSave(TItem item)
        {
            await OnSave.InvokeAsync(item);
            IsOpen = false;

        }

        public void Show()
        {
            IsOpen = true;
        }

        public void Hide()
        {
            IsOpen = false;
        }

    }
}
