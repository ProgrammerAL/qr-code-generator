using Microsoft.AspNetCore.Components;

namespace ProgrammerAl.QrCodeHelpers.Components;
public partial class HeaderNavBarComponent : ComponentBase
{
    private bool IsAboutVisibile { get; set; } = false;

    private void ToggleAboutVisibility()
    {
        IsAboutVisibile = !IsAboutVisibile;
    }
}
