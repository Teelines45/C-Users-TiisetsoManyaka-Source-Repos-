using CommunityToolkit.Mvvm.ComponentModel;
using AppSolultion2._0.Models;

namespace AppSolultion2._0.ViewModel;

internal partial class SearchInfoPageViewModel : ObservableObject
{

    private readonly SearchService.SearchService _searchSearvice;

    public SearchInfoPageViewModel(string weatherDescription)
    {
        this.weatherDescription = weatherDescription;
    }


    [ObservableProperty]
    private string latitude;

    [ObservableProperty]
    private string longitude;

    [ObservableProperty]
    private string temperature;

    [ObservableProperty]
    private string weatherDescription;

    [ObservableProperty]
    private string location;

    [ObservableProperty]
    private string humidity;


    private async Task SearchCommand()
    {
        var MarkModel = await _searchSearvice.GetSearchResults(latitude, longitude);
        

        if (MarkModel != null)
        {
            weatherDescription =  MarkModel.Current.Weather_descriptions[0];
        }
    }
}
