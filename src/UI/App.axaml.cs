using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Bcan.Pg.UI.Data;
using Bcan.Pg.UI.Factories;
using Bcan.Pg.UI.ViewModels;
using Bcan.Pg.UI.Views;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.Extensions.DependencyInjection;

namespace Bcan.Pg.UI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        LiveCharts.Configure(config =>
            config
                .AddDarkTheme()
        );
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
         collection.AddSingleton<MainWindowViewModel>();
         collection.AddTransient<HomePageViewModel>();
         collection.AddTransient<ChartsPageViewModel>();
         
         collection.AddSingleton<Func<ApplicationNames, PageViewModel>>(x => name => name switch
         {
             ApplicationNames.Home => x.GetRequiredService<HomePageViewModel>(),
             ApplicationNames.Charts => x.GetRequiredService<ChartsPageViewModel>(),
             _ => throw new NotImplementedException()
         });
         collection.AddSingleton<PageFactory>();
        
         // Service locator. Responsible for locating for your injected services
         var services = collection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = services.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}