using System;
using Avalonia.Media.Imaging;
using AvaloniaApplication3.Helpers;
using AvaloniaApplication3.Utils;
namespace AvaloniaApplication3.ViewModels;

public class ResultWindowViewModel : ViewModelBase
{
    public Bitmap Image => Result._image;

    public string Text => Result._people.ToString();
    
    public string TimeDiff => Result.timeDiff.TotalMilliseconds.ToString() + "ms";
    
    public string Percentage => Result.percentage.ToString() + "%";
}