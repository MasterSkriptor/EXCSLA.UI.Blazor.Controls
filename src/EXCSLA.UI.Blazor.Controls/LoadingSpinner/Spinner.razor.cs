﻿using EXCSLA.UI.Blazor.Controls.Enums;
using Microsoft.AspNetCore.Components;
using EXCSLA.UI.Blazor.Controls.LoadingSpinner;

namespace EXCSLA.UI.Blazor.Controls
{
    public partial class Spinner
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public SpinnerType Type { get; set; }

        protected RenderFragment SpinnerType { get; set; }


        protected override void OnInitialized()
        {
            LoadSpinner();
        }

        private void LoadSpinner()
        {
            SpinnerType = Type switch
            {
                Enums.SpinnerType.BT => new RenderFragment(x => { x.OpenComponent(1, typeof(BT)); x.CloseComponent(); }),
                Enums.SpinnerType.NB => new RenderFragment(x => { x.OpenComponent(1, typeof(NB)); x.CloseComponent(); }),
                Enums.SpinnerType.DotLoader => new RenderFragment(x => { x.OpenComponent(1, typeof(DotLoader)); x.CloseComponent(); }),
                _ => new RenderFragment(x => { x.OpenComponent(1, typeof(BT)); x.CloseComponent(); }),
            };
        }
    }
}
