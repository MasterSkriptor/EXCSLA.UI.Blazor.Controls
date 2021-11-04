using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class ReportBarItem : ComponentBase
    {
        [Parameter] public string BorderClass { get; set; }
        [Parameter] public string BackgroundClass { get; set; }
        [Parameter] public string TextCss { get; set; }

        [Parameter] public EventCallback<string> OnClick { get; set; }

        [Parameter] public KeyValuePair<string, int> Item { get; set; }

        public async Task BCCard_OnClick(string key)
        {
            await OnClick.InvokeAsync(key);
        }
    }
}
