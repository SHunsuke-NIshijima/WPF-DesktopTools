# WPF Daily Report Tool - Project Structure

## Project Overview
```
WPF-DesktopTools/
├── DailyReportTool/               # Main WPF Application
│   ├── Models/                    # Data models
│   │   └── ReportEntry.cs         # Report entry data model with INotifyPropertyChanged
│   ├── Validators/                # Custom validation rules
│   │   └── ChargedValueValidationRule.cs  # Validates Charged field (0 or 1)
│   ├── App.xaml                   # Application entry point with ModernWpf resources
│   ├── App.xaml.cs                # Application code-behind
│   ├── MainWindow.xaml            # Main window UI definition
│   ├── MainWindow.xaml.cs         # Main window logic and Outlook integration
│   ├── AssemblyInfo.cs            # Assembly metadata
│   └── DailyReportTool.csproj     # Project file with dependencies
├── WPF-DesktopTools.sln           # Visual Studio solution file
├── RunDailyReportTool.bat         # Batch file to launch the application
├── README.md                      # User documentation
├── DOCUMENTATION.md               # Detailed UI and feature documentation
└── .gitignore                     # Git ignore configuration
```

## Architecture

### MVVM Pattern Implementation
- **Model**: `ReportEntry.cs` - Data structure with property change notifications
- **View**: `MainWindow.xaml` - XAML UI definition with data binding
- **ViewModel**: `MainWindow.xaml.cs` - View logic and data management

### Key Components

#### 1. ReportEntry Model
- Properties: ID, DeliveryDate, ChargedDate, EngagementID, Activity, Account, Details, Charged
- Implements INotifyPropertyChanged for two-way data binding
- Constructor accepts date parameter for consistency across entries
- Charged property validates input (throws exception if not 0 or 1)

#### 2. ChargedValueValidationRule
- Custom validation rule for WPF binding
- Ensures Charged column only accepts 0 or 1
- Provides user feedback when invalid value is entered

#### 3. MainWindow
- Modern UI using ModernWpf library
- Data binding to ObservableCollection<ReportEntry>
- Outlook COM integration for email generation
- Proper COM object disposal to prevent memory leaks

### Data Flow

```
User Input (DataGrid)
    ↓
Two-Way Binding
    ↓
ObservableCollection<ReportEntry>
    ↓
Property Change Notification (INotifyPropertyChanged)
    ↓
UI Updates Automatically
```

### Email Generation Flow

```
User clicks "Create Email" button
    ↓
Read email recipients from TextBoxes
    ↓
Create Outlook.Application COM object
    ↓
Create new MailItem
    ↓
Populate recipients, subject, and body
    ↓
Format report entries as tab-delimited table
    ↓
Display email draft in Outlook
    ↓
Release COM objects (prevent memory leaks)
    ↓
Show success message
```

## Technology Stack

| Component | Technology | Version |
|-----------|-----------|---------|
| Framework | .NET | 8.0 |
| UI Framework | WPF | (built-in) |
| Design Library | ModernWpf | 0.9.6 |
| Office Integration | Microsoft.Office.Interop.Outlook | 15.0.4797.1003 |
| Language | C# | 12.0 |
| Target | Windows | net8.0-windows |

## Build Configuration

### Development Build
```bash
dotnet build
```

### Release Build
```bash
dotnet build -c Release
```

### Output Location
```
DailyReportTool/bin/Release/net8.0-windows/DailyReportTool.exe
```

## Dependencies

### NuGet Packages
1. **ModernWpfUI** (0.9.6)
   - Provides modern Windows UI controls
   - Fluent Design System
   - Accent color theming

2. **Microsoft.Office.Interop.Outlook** (15.0.4797.1003)
   - COM interop for Microsoft Outlook
   - Email creation and manipulation
   - Requires Outlook installation

## Features Implemented

### ✅ Core Requirements
- [x] WPF Desktop Application
- [x] Launchable via EXE or BAT file
- [x] Display today's date (top-left)
- [x] Email To and CC fields
- [x] DataGrid with 8 columns
- [x] Auto-fill dates (YYYY-MM-DD format)
- [x] Charged column validation (0 or 1)
- [x] Create Email button
- [x] Outlook integration
- [x] Modern UI design (ModernWpf)

### ✅ Code Quality
- [x] Proper error handling
- [x] COM object disposal
- [x] Data validation
- [x] MVVM pattern
- [x] Clean code structure
- [x] No security vulnerabilities (CodeQL verified)

## Maintenance Notes

### Extending the Application
To add new columns to the report:
1. Add property to `ReportEntry.cs` model
2. Add column to `MainWindow.xaml` DataGrid
3. Update email body formatting in `CreateEmailButton_Click`

### Customizing Validation
To add validation to other columns:
1. Create new validation rule in `Validators/` folder
2. Apply to column binding in XAML
3. Update model property setter if needed

### Modifying Email Format
Email formatting is done in `MainWindow.xaml.cs`:
- Line 65-79: Builds email body
- Can be customized to HTML, CSV, or other formats
- Tab-delimited format works well with Excel paste

## Security Considerations

### ✅ Verified Safe
- No SQL injection vulnerabilities
- No XSS vulnerabilities
- No path traversal issues
- No command injection
- Proper input validation
- COM objects properly disposed

### Best Practices Applied
- Exception handling for all external operations
- Validation at both UI and model level
- Proper resource disposal (COM objects)
- No hardcoded credentials
- No sensitive data in source code

## Support and Documentation

For detailed information, see:
- **README.md** - Build and usage instructions
- **DOCUMENTATION.md** - Comprehensive UI and feature documentation
- **Code Comments** - Inline documentation in source files
