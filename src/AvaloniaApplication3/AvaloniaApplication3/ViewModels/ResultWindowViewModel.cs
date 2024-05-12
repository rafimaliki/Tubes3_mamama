using Avalonia.Media.Imaging;
using AvaloniaApplication3.Helpers;
using AvaloniaApplication3.Utils;
namespace AvaloniaApplication3.ViewModels;

public class ResultWindowViewModel : ViewModelBase
{
    public Bitmap Image => ImageHelper.LoadFromResource(
        "/Assets/1__M_Left_index_finger.BMP");

    public string Text => Utils.Result._people.ToString();
}