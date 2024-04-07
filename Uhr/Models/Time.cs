using System;

namespace Uhr.Models;

public partial class Time
{
    private string _strHour;
    private string _strMinute;
    private string _strSecond;

    private int _iHour;
    private int _iMinute;
    private int _iSecond;

    private bool _showColon = true;

    public Time(string timeZone)
    {
        _updateTime(timeZone);
    }

    private void _updateTime(string timeZone)
    {
        if (timeZone =="loc")
        {
            _iHour = DateTime.Now.Hour;
            _iMinute = DateTime.Now.Minute;
            _iSecond = DateTime.Now.Second;
        }
        else if (timeZone == "utc")
        {
            _iHour = DateTime.UtcNow.Hour;
            _iMinute = DateTime.UtcNow.Minute;
            _iSecond = DateTime.UtcNow.Second;
        }

        if (_iHour < 10) _strHour = "0" + _iHour.ToString();
        else _strHour = _iHour.ToString();

        if (_iMinute < 10) _strMinute = "0" + _iMinute.ToString();
        else _strMinute = _iMinute.ToString();

        if (_iSecond < 10) _strSecond = "0" + _iSecond.ToString();
        else _strSecond = _iSecond.ToString();
    }
    
    public string GetTime(string timeZone)
    {
        _updateTime(timeZone);
        string retVal = _strHour + (_showColon ? ":" : " ") + _strMinute + (_showColon ? ":" : " ") + _strSecond;
        _showColon = !_showColon;
        return retVal;
    }
}