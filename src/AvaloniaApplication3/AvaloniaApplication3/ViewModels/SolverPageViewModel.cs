using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace AvaloniaApplication3.ViewModels;

public class SolverPageViewModel : ViewModelBase
{
    public ICommand OpenResultWindowCommand { get; }

    public Interaction<ResultWindowViewModel, EmptyPageViewModel?> ShowDialog { get; }
    
    public SolverPageViewModel()
    {
        ShowDialog = new Interaction<ResultWindowViewModel, EmptyPageViewModel?>();
        
        OpenResultWindowCommand = ReactiveCommand.CreateFromTask( async () =>
        {
            var store = new ResultWindowViewModel();
            var result = await ShowDialog.Handle(store);
        });
    }
}