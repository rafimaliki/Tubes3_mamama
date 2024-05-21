using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using AvaloniaApplication3.ViewModels;
using ReactiveUI;
using AvaloniaApplication3.Algorithm;
using System.Text;


namespace AvaloniaApplication3.Views;

public partial class SolverPageView : ReactiveUserControl<SolverPageViewModel>
{
    private Image _imageDisplay;
    private Button _imageInputButton;
    private RadioButton _option1;
    private RadioButton _option2;
    private Button _searchButton;
    
    private string input_img = "";

    public SolverPageView()
    {
        InitializeComponent();
        DataContext = new SolverPageViewModel();
        
        this.WhenActivated(action => 
            action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }
    
    private async Task DoShowDialogAsync(InteractionContext<ResultWindowViewModel,
        EmptyPageViewModel?> interaction){
        
        var window = this.VisualRoot as Window;
        var dialog = new ResultWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<EmptyPageViewModel?>(window);
        interaction.SetOutput(result);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);

        _imageDisplay = this.FindControl<Image>("ImageDisplay");
        _option1 = this.FindControl<RadioButton>("Option1");
        _option2 = this.FindControl<RadioButton>("Option2");
        _searchButton = this.FindControl<Button>("SearchButton");
        _imageInputButton = this.FindControl<Button>("ImageInputButton");

        _searchButton.Click += SearchButton_Click;
        _imageInputButton.Click += ImageInputButton_Click;

    }

    private async void ImageInputButton_Click(object sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);

        var files = await topLevel!.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select an image",
                AllowMultiple = false,
                FileTypeFilter = new List<FilePickerFileType>
                {
                    new(
                        "Image files")
                    {
                        Patterns = new List<string> { "*.png", "*.jpg", "*.jpeg", "*.BMP" }
                    }
                }
            }
        );

        if (files.Count > 0)
        {
            var file = files[0];
            using (var stream = await file.OpenReadAsync())
            {
                var bitmap = new Bitmap(stream);
                
                _imageDisplay.Source = bitmap;
            }

            byte[] b = Utils.ImageConverter.PreprocessImage(file.Path.ToString());
            input_img = Encoding.GetEncoding("iso-8859-1").GetString(b);
                
            // Console.WriteLine(input_img.Length);
        }
    }


    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        if (_option1.IsChecked.Value)
        {
            // Do something
        }
        else if (_option2.IsChecked.Value)
        {
            // Do something else
        }
        
        KMP.findMatch(input_img);
    }
}