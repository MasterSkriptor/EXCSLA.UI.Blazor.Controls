using EXCSLA.UI.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class ReportBar : ComponentBase
    {
        [Inject] public IColorPicker ColorPicker { get; set; }

        [Parameter] public Dictionary<string, int> Items { get; set; }
        [Parameter] public string SelectedItem { get; set; }
        [Parameter] public EventCallback<string> OnSelectedItemChanged { get; set; }

        protected async Task HandleOnSelectedItemChanged(string value)
        {
            SelectedItem = Items != null && Items.Count > 0 ? Items.Where(i => i.Key == value).FirstOrDefault().Key : string.Empty;
            StateHasChanged();
            
            await OnSelectedItemChanged.InvokeAsync(SelectedItem);
        }
    }
}
