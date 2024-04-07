using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Uhr.Models;

namespace Uhr.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] 
    private static Time _timeUtc = new Time("utc");
    
    [ObservableProperty]
    private static Time _timeLoc = new Time("loc");

    [ObservableProperty]
    private string _strTimeUtc = _timeUtc.GetTime("utc");

    [ObservableProperty] 
    private string _strTimeLoc = _timeLoc.GetTime("loc");

    public string CurrentTimeUtc => "UTC: " + StrTimeUtc;
    public string CurrentTimeLoc => "LOC: " + StrTimeLoc;

    [RelayCommand]
    public void TriggerUpdateTime()
    {
        StrTimeUtc = _timeUtc.GetTime("utc");
        StrTimeLoc = _timeLoc.GetTime("loc");
    }
}