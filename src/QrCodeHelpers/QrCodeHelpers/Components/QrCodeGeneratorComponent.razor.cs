
using QRCoder;

using SixLabors.ImageSharp;

namespace ProgrammerAl.QrCodeHelpers.Components;
public partial class QrCodeGeneratorComponent
{
    private string QrCodeText { get; set; } = "Place Text Here";
    private string QrCodeImageUrl { get; set; } = "";
    private ComponentStateType State { get; set; } = ComponentStateType.Steady;

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    private async Task GenerateQrCodeAsync()
    {
        await UpdateStateAsync(ComponentStateType.GeneratingQrCode);

        var threadWork = Task.Run(() =>
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(QrCodeText, QRCodeGenerator.ECCLevel.Q);
            var graphic = new Base64QRCode(qrCodeData);
            var base64EncodedImage = graphic.GetGraphic(
                pixelsPerModule: 50,
                darkColor: Color.Black,
                lightColor: Color.Transparent,
                drawQuietZones: false,
                imgType: Base64QRCode.ImageType.Png);

            QrCodeImageUrl = string.Format("data:image/png;base64,{0}", base64EncodedImage);
        });

        await threadWork;
        await UpdateStateAsync(ComponentStateType.Steady);
    }

    private async Task UpdateStateAsync(ComponentStateType newState)
    {
        State = newState;
        await InvokeAsync(StateHasChanged);
    }

    private enum ComponentStateType
    {
        Steady,
        GeneratingQrCode
    }
}
