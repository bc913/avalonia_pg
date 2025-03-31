using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bcan.Pg.UI.ViewModels;

//https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/observableproperty#requesting-property-validation
public partial class ValidationUsingObservableViewModel : ObservableValidator
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    [EmailAddress]
    private string? _email;
}