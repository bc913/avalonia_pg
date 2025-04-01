using Bcan.Pg.UI.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bcan.Pg.UI.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationNames _pageName;
}