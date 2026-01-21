# WPF-DesktopTools

## Daily Report Tool

A WPF Desktop application for creating daily reports with modern UI design (ModernWPF).

### Features

- Display today's date at the top
- Email recipient and CC fields
- Data grid for report entries with the following columns:
  - ID
  - Delivery Date (auto-populated with today's date in YYYY-MM-DD format)
  - Charged Date (auto-populated with today's date in YYYY-MM-DD format)
  - Engagement ID
  - Activity
  - Account
  - Details
  - Charged (0 or 1)
- Create Email button that launches Outlook with the report data

### Requirements

- Windows OS
- .NET 8.0 Runtime
- Microsoft Outlook (for email functionality)

### How to Build

```bash
cd DailyReportTool
dotnet restore
dotnet build -c Release
```

### How to Run

**Option 1: Using the batch file**
```
Double-click RunDailyReportTool.bat
```

**Option 2: Using the executable directly**
```
Navigate to DailyReportTool\bin\Release\net8.0-windows\
Double-click DailyReportTool.exe
```

**Option 3: Using dotnet CLI**
```bash
cd DailyReportTool
dotnet run
```

### Usage

1. The application opens with today's date displayed at the top
2. Enter email recipients in the "Email To" field
3. Enter CC recipients in the "CC" field (optional)
4. Add report entries in the data grid:
   - ID: Enter a unique identifier
   - Delivery Date and Charged Date are auto-filled with today's date
   - Fill in Engagement ID, Activity, Account, and Details
   - Charged: Enter 0 or 1
5. Click "Create Email" to launch Outlook with a draft email containing the report

### Technologies Used

- WPF (Windows Presentation Foundation)
- .NET 8.0
- ModernWpf UI Library
- Microsoft Office Interop (for Outlook integration)
