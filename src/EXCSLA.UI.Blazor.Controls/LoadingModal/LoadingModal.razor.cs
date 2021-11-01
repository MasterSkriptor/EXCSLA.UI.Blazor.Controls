using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class LoadingModal : ComponentBase
    {
        [Parameter] public bool IsOpen { get; set; } = false;
        [Parameter] public string CssClass { get; set; } = "loading-screen";
        [Parameter] public string LogoUrl { get; set; } = string.Empty;
        [Parameter] public string LoadingAnimationColor { get; set; } = string.Empty;
        [Parameter] public string LoadingAnimationSize { get; set; } = string.Empty;
        [Parameter] public string Message { get; set; } = "Loading";
    }
}
