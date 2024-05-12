using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;
using Microsoft.VisualBasic;
using ReactiveUI;

namespace AvaloniaApplication3.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private bool _isPaneOpen = false;
        private ViewModelBase _currentPage = new HomePageViewModel();
        
        public MainWindowViewModel()
        {
            ShowDialog = new Interaction<ResultWindowViewModel, EmptyPageViewModel?>();
            
           OpenWindowCommand = ReactiveCommand.CreateFromTask( async () =>
            {
                var store = new ResultWindowViewModel();
                var result = await ShowDialog.Handle(store);
            });
        }
        
        public ICommand OpenWindowCommand { get; }
        public Interaction<ResultWindowViewModel, EmptyPageViewModel?> ShowDialog { get; }

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