using CommunityToolkit.Mvvm.ComponentModel;

namespace Bcan.Pg.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ValidationUsingDataAnnotationViewModel DataAnnotationVm { get; }
        = new ValidationUsingDataAnnotationViewModel();

    public ValidationUsingExcptInsideSetterViewModel ExptInsideSetterVm {get;}
        = new ValidationUsingExcptInsideSetterViewModel();

    public ValidationUsingObservableViewModel ObservableAnnVm {get;}
        = new ValidationUsingObservableViewModel();
}
