using System.ComponentModel;

namespace DailyReportTool.Models;

public class ReportEntry : INotifyPropertyChanged
{
    private int _id;
    private string _deliveryDate;
    private string _chargedDate;
    private string _engagementId;
    private string _activity;
    private string _account;
    private string _details;
    private int _charged;

    public int ID
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(ID));
        }
    }

    public string DeliveryDate
    {
        get => _deliveryDate;
        set
        {
            _deliveryDate = value;
            OnPropertyChanged(nameof(DeliveryDate));
        }
    }

    public string ChargedDate
    {
        get => _chargedDate;
        set
        {
            _chargedDate = value;
            OnPropertyChanged(nameof(ChargedDate));
        }
    }

    public string EngagementID
    {
        get => _engagementId;
        set
        {
            _engagementId = value;
            OnPropertyChanged(nameof(EngagementID));
        }
    }

    public string Activity
    {
        get => _activity;
        set
        {
            _activity = value;
            OnPropertyChanged(nameof(Activity));
        }
    }

    public string Account
    {
        get => _account;
        set
        {
            _account = value;
            OnPropertyChanged(nameof(Account));
        }
    }

    public string Details
    {
        get => _details;
        set
        {
            _details = value;
            OnPropertyChanged(nameof(Details));
        }
    }

    public int Charged
    {
        get => _charged;
        set
        {
            if (value != 0 && value != 1)
            {
                throw new ArgumentException("Charged must be 0 or 1", nameof(value));
            }
            _charged = value;
            OnPropertyChanged(nameof(Charged));
        }
    }

    public ReportEntry() : this(DateTime.Now.ToString("yyyy-MM-dd"))
    {
    }

    public ReportEntry(string todayDate)
    {
        _id = 0;
        _deliveryDate = todayDate;
        _chargedDate = todayDate;
        _engagementId = string.Empty;
        _activity = string.Empty;
        _account = string.Empty;
        _details = string.Empty;
        _charged = 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
