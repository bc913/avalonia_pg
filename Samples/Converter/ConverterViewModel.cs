using CommunityToolkit.Mvvm.ComponentModel;

namespace Bcan.Pg.UI.ViewModels;

public partial class ConverterViewModel : ViewModelBase
{
    [ObservableProperty]
    private decimal _number1 = 2.4M;

    [ObservableProperty]
    private decimal _number2 = 3.4M;

    [ObservableProperty]
    private string _operator = "+";

    public string[] AvailableMathOperators { get; } = new string[]
    {
        "+", "-", "*", "/"
    };
}
