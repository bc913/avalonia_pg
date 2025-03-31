using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bcan.Pg.UI.ViewModels;

//https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/observablevalidator
public class ValidationUsingDataAnnotationViewModel : ObservableValidator
{
    private string? _email;

    [EmailAddress]
    [Required]
    public string? Email
    {
        get => _email;
        set => SetProperty(ref _email, value, true);
    }
}