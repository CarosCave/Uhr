using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Uhr.Models;
using System.Threading;

namespace Uhr.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private static Time _timeUtc = new Time("utc");
    
    private static Time _timeLoc = new Time("loc");
    
    private string _strTimeUtc = _timeUtc.GetTime("utc");
    
    private string _strTimeLoc = _timeLoc.GetTime("loc");

    [ObservableProperty]
    private string? _currentTimeUtc;
    
    [ObservableProperty]
    private string? _currentTimeLoc;
    
    public MainWindowViewModel()
    {
        new Timer(TriggerUpdateTime, null, 0, 500);
    }
    
    [RelayCommand]
    public void TriggerUpdateTime(object? state = null)
    {
        _strTimeUtc = _timeUtc.GetTime("utc");
        _strTimeLoc = _timeLoc.GetTime("loc");
        CurrentTimeLoc = "LOC: " + _strTimeLoc;
        CurrentTimeUtc = "UTC: " + _strTimeUtc;
        Console.WriteLine(CurrentTimeLoc);
    }
}