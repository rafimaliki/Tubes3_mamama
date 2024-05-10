using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Platform.Storage;

namespace AvaloniaApplication3.Views
{
    public partial class SolverPageView : UserControl
    {
        private Image _imageDisplay;
        private RadioButton _option1;
        private RadioButton _option2;
        private Button _searchButton;
        private Button _imageInputButton;

        public SolverPageView()
        {
            InitializeComponent();
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

            var files = await topLevel.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions
                {
                    Title = "Select an image",
                    AllowMultiple = false,
                    FileTypeFilter = new List<FilePickerFileType>
                    {
                        new FilePickerFileType(
                            "Image files")
                        {
                            Patterns = new List<string> { "*.png", "*.jpg", "*.jpeg" }
                        }
                    }
                }
            );
            
            if ( files.Count > 0 )
            {
                var file = files[0];
                Stream stream = await file.OpenReadAsync();
                var bitmap = new Bitmap(stream);
                _imageDisplay.Source = bitmap;
                
                // Console the image as binary
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
            
            Console.WriteLine("Search button clicked");
        }
    }
}