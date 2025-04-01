using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Bcan.Pg.UI.ViewModels;

namespace Bcan.Pg.UI;

public class ViewLocator : IDataTemplate
{

    public Control? Build(object? param)
    {
        // Param is usually view model
        if (param is null)
            return null;
        
        // Follow a naming scheme to achieve this behavior
        var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name); //View type

        if (type == null) 
            return new TextBlock { Text = "Not Found: " + name };
        // Basically generates views from view models
        var control = Activator.CreateInstance(type) as Control;
        control!.DataContext = param;
        return control;
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}
