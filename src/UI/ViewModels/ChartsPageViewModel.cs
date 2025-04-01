using Bcan.Pg.UI.Data;
using Bcan.Pg.UI.ViewModels.Charts;

namespace Bcan.Pg.UI.ViewModels;

public class ChartsPageViewModel : PageViewModel
{
    public ChartsPageViewModel()
    {
        PageName = ApplicationNames.Charts;
    }
    public LineChartViewModel LineChartViewModel { get; } = new();
    public RaceChartViewModel RaceChartViewModel { get; } = new();
    public WorldHeatMapViewModel WorldHeatMapViewModel { get; } = new();
    public LiveChartViewModel LiveChartViewModel { get; } = new();
}
