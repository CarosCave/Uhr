using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Uhr.Models;

namespace Uhr.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private static Time _timeUtc = new Time("utc");
    
    private static Time _timeLoc = new Time("loc");
    
    private string _strTimeUtc = _timeUtc.GetTime("utc");
    
    private string _strTimeLoc = _timeLoc.GetTime("loc");

    [ObservableProperty]
    private string _currentTimeUtc;// => "UTC: " + StrTimeUtc;
    
    [ObservableProperty]
    private string _currentTimeLoc;// => "LOC: " + StrTimeLoc;

    [RelayCommand]
    public void TriggerUpdateTime()
    {
        _strTimeUtc = _timeUtc.GetTime("utc");
        _strTimeLoc = _timeLoc.GetTime("loc");
        CurrentTimeLoc = "LOC: " + _strTimeLoc;
        CurrentTimeUtc = "UTC: " + _strTimeUtc;
    }
}