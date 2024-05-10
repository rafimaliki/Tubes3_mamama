using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Media;
using Avalonia.Styling;
using ReactiveUI;

namespace AvaloniaApplication3.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private bool _isPaneOpen = false;
        private ViewModelBase _currentPage = new HomePageViewModel();

        public bool IsPaneOpen
        {
            get => _isPaneOpen;
            set => this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
        }

        public void TogglePane()
        {
            IsPaneOpen = !IsPaneOpen;
        }

        public ViewModelBase CurrentPage
        {
            get => _currentPage;
            set => this.RaiseAndSetIfChanged(ref _currentPage, value);
        }
        
        private ListItemTemplate? _selectedNavItem;
        public ListItemTemplate? SelectedNavItem
        {
            get => _selectedNavItem;
            set
            {
                if (value != null)
                {
                    CurrentPage = (ViewModelBase)Activator.CreateInstance(value.ModelType);
                    _selectedNavItem = value;
                } else
                {
                    CurrentPage = (ViewModelBase)Activator.CreateInstance(typeof(HomePageViewModel));
                }
            }
        }
        
        
        public ObservableCollection<ListItemTemplate> NavItems { get; } = new ()
        {
            new ListItemTemplate(typeof(HomePageViewModel), "BroadActivityFeedRegular"),
            new ListItemTemplate(typeof(SolverPageViewModel), "PeopleSearchRegular"),
            new ListItemTemplate(typeof(AboutPageViewModel), "PersonQuestionMarkRegular"),
        };
    }
    
    public class ListItemTemplate 
    {
        public string Label { get; set; }
        public Type ModelType { get; set; }
        
        public StreamGeometry Icon { get; set; }
        
        public ListItemTemplate(Type modelType, string iconKey)
        {
            ModelType = modelType;
            Label = modelType.Name.Replace("PageViewModel", "");

            Application.Current!.Styles.TryGetResource(iconKey, ThemeVariant.Dark, out var result);
            Icon = (StreamGeometry) result;

        }
        
        
    }
}