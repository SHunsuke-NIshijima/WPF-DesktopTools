using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using DailyReportTool.Models;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace DailyReportTool;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string _todayDate = string.Empty;
    private ObservableCollection<ReportEntry> _reportEntries = new();

    public string TodayDate
    {
        get => _todayDate;
        set
        {
            _todayDate = value;
            OnPropertyChanged(nameof(TodayDate));
        }
    }

    public ObservableCollection<ReportEntry> ReportEntries
    {
        get => _reportEntries;
        set
        {
            _reportEntries = value;
            OnPropertyChanged(nameof(ReportEntries));
        }
    }

    public MainWindow()
    {
        InitializeComponent();
        TodayDate = DateTime.Now.ToString("yyyy-MM-dd");
        ReportEntries = new ObservableCollection<ReportEntry>();
        
        // Add a sample row to show the format
        ReportEntries.Add(new ReportEntry { ID = 1 });
        
        DataContext = this;
    }

    private void CreateEmailButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Create Outlook application instance
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

            // Set email recipients
            mailItem.To = EmailToTextBox.Text;
            mailItem.CC = EmailCCTextBox.Text;
            mailItem.Subject = $"Daily Report - {TodayDate}";

            // Build the email body with the table
            StringBuilder emailBody = new StringBuilder();
            emailBody.AppendLine($"Daily Report for {TodayDate}");
            emailBody.AppendLine();
            emailBody.AppendLine("Report Entries:");
            emailBody.AppendLine();

            // Create table header
            emailBody.AppendLine("ID\tDelivery Date\tCharged Date\tEngagement ID\tActivity\tAccount\tDetails\tCharged");
            emailBody.AppendLine(new string('-', 120));

            // Add each report entry
            foreach (var entry in ReportEntries)
            {
                emailBody.AppendLine($"{entry.ID}\t{entry.DeliveryDate}\t{entry.ChargedDate}\t{entry.EngagementID}\t{entry.Activity}\t{entry.Account}\t{entry.Details}\t{entry.Charged}");
            }

            mailItem.Body = emailBody.ToString();

            // Display the email (not sending automatically)
            mailItem.Display(false);

            MessageBox.Show("Email draft created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error creating email: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}