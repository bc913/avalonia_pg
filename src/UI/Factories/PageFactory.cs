using System;
using Bcan.Pg.UI.Data;
using Bcan.Pg.UI.ViewModels;

namespace Bcan.Pg.UI.Factories;

public class PageFactory
{
    private readonly Func<ApplicationNames, PageViewModel> pageFactory;
    public PageFactory(Func<ApplicationNames, PageViewModel> factory)
    {
        pageFactory = factory;
    }

    public PageViewModel Create(ApplicationNames pageName) => pageFactory.Invoke(pageName);
}