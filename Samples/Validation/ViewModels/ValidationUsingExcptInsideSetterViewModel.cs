using System;

namespace Bcan.Pg.UI.ViewModels;

public class ValidationUsingExcptInsideSetterViewModel : ViewModelBase
{
    private string? _email;

    public string? Email
    {
        get => _email;
        set 
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Email), "This field is required");
            
            if(!value.Contains('@'))
                throw new ArgumentException(nameof(Email), "Not a valid E-Mail address");

            _email = value;
            
        }
    }
}