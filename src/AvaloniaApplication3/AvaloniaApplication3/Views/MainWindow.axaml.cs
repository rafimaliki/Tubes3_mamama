using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using AvaloniaApplication3.Algorithm;

namespace AvaloniaApplication3.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Database.Load();
    }
}