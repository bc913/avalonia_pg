using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Bcan.Pg.UI.Data;
using Bcan.Pg.UI.Factories;
using Bcan.Pg.UI.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bcan.Pg.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private PageFactory _pageFactory;
    
    [ObservableProperty]
    private bool _isPaneOpen;
    
    [ObservableProperty]
    private ListItemTemplate? _selectedListItem;
    
    [ObservableProperty]
    private PageViewModel _currentPage = new HomePageViewModel();
    
    public ObservableCollection<ListItemTemplate> Items { get; }

    public MainWindowViewModel()
    {
    }
    public MainWindowViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        Items = new ObservableCollection<ListItemTemplate>
        {
            new ListItemTemplate(ApplicationNames.Home, "HomeRegular", "Home")
            // new ListItemTemplate(typeof(ButtonPageViewModel), "CursorHoverRegular", "Buttons"),
            // new ListItemTemplate(typeof(TextPageViewModel), "TextNumberFormatRegular", "Text"),
            // new ListItemTemplate(typeof(ValueSelectionPageViewModel), "CalendarCheckmarkRegular", "Value Selection"),
            // new ListItemTemplate(typeof(ImagePageViewModel), "ImageRegular", "Images"),
            // new ListItemTemplate(typeof(GridPageViewModel), "GridRegular", "Grids"),
            // new ListItemTemplate(typeof(DragAndDropPageViewModel), "TapDoubleRegular", "Drang And Drop"),
            // new ListItemTemplate(typeof(LoginPageViewModel), "LockRegular", "Login Form"),
            // new ListItemTemplate(typeof(ChartsPageViewModel), "PollRegular", "Charts")
        };
        
        SelectedListItem = Items.First(vm => vm.Name == ApplicationNames.Home);
    }

    [RelayCommand]
    private void TogglePane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
    
    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value is null) return;

        // var vm = Design.IsDesignMode
        //     ? Activator.CreateInstance(value.ModelType)
        //     : Ioc.Default.GetService(value.ModelType);
        //
        // if (vm is not ViewModelBase vmb) return;
        //         CurrentPage = vmb;


        CurrentPage = _pageFactory.Create(value.Name);

    }
}
