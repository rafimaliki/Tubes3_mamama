using System.Reactive.Linq;
using System.Windows.Input;
using AvaloniaApplication3.Utils;
using ReactiveUI;

namespace AvaloniaApplication3.ViewModels;

public class SolverPageViewModel : ViewModelBase
{
    public ICommand OpenResultWindowCommand { get; }

    public Interaction<BaseResultViewModel, EmptyPageViewModel?> ShowDialog { get; }
    
    public SolverPageViewModel()
    {
        ShowDialog = new Interaction<BaseResultViewModel, EmptyPageViewModel?>();
        
        OpenResultWindowCommand = ReactiveCommand.CreateFromTask( async () =>
        {
            BaseResultViewModel store = (Result.percentage >= 85 || Result.foundByAlgorithm) ? new ResultWindowViewModel() : new NoResultWindowViewModel();
            
            var result = await ShowDialog.Handle(store);
        });
    }
}