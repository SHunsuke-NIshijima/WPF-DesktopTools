# Daily Report Tool - UI Documentation

## Application Overview

The Daily Report Tool is a WPF desktop application designed for creating and managing daily work reports with seamless Microsoft Outlook integration.

## UI Layout

### 1. Header Section
- **Today's Date**: Displays the current date in YYYY-MM-DD format at the top-left of the window
- Font: 18pt, SemiBold
- Updates automatically to the current system date

### 2. Email Recipients Section
Located below the date display:
- **Email To**: Text input field for entering primary email recipients
- **CC**: Text input field for entering carbon copy recipients
- Both fields include placeholder text for user guidance
- Height: 30px with padding

### 3. Report Entries Table
A DataGrid component with the following columns:

| Column | Width | Description |
|--------|-------|-------------|
| ID | 50px | Unique identifier for each entry |
| Delivery Date | 120px | Auto-populated with today's date (YYYY-MM-DD) |
| Charged Date | 120px | Auto-populated with today's date (YYYY-MM-DD) |
| Engagement ID | 120px | Project or engagement identifier |
| Activity | 150px | Type of activity performed |
| Account | 120px | Account or client name |
| Details | Auto-fill | Detailed description of work |
| Charged | 80px | Binary value (0 or 1) indicating charge status |

#### Table Features:
- **Editable**: All cells are editable by double-clicking
- **Add Rows**: New rows can be added by clicking the empty row at the bottom
- **Delete Rows**: Rows can be deleted by selecting and pressing Delete key
- **Sortable**: Click column headers to sort
- **Resizable**: Column widths can be adjusted
- **Alternating Colors**: Alternating row background (#F5F5F5) for better readability
- **Validation**: Charged column only accepts 0 or 1 values

#### Auto-fill Behavior:
- When a new row is created, the Delivery Date and Charged Date columns automatically populate with today's date
- The date format is YYYY-MM-DD (e.g., 2026-01-21)

### 4. Action Button Section
Located at the bottom-left:
- **Create Email Button**:
  - Size: 150px wide × 40px tall
  - Style: Accent button (ModernWpf style)
  - Font Size: 14pt
  - Function: Launches Microsoft Outlook with a draft email containing the report data

## User Workflow

1. **Launch Application**: Open via EXE file or batch script
2. **View Date**: Current date is displayed automatically
3. **Enter Recipients**: Fill in Email To and CC fields
4. **Add Report Entries**: Click in the data grid to add entries
   - ID: Enter a unique number
   - Delivery/Charged Dates: Auto-filled, can be modified
   - Fill in remaining fields (Engagement ID, Activity, Account, Details)
   - Charged: Enter 0 (not charged) or 1 (charged)
5. **Create Email**: Click "Create Email" button
   - Outlook opens with a new draft email
   - Recipients are pre-filled
   - Subject line: "Daily Report - [Date]"
   - Body contains formatted report table
6. **Review & Send**: Review the email in Outlook and send when ready

## Design System

The application uses **ModernWpf** UI library, which provides:
- Modern Windows UI controls
- Consistent styling across components
- Accent color theming
- Native Windows 10/11 appearance
- Smooth animations and transitions

## Technical Specifications

- **Framework**: .NET 8.0
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Design Library**: ModernWpf 0.9.6
- **Office Integration**: Microsoft.Office.Interop.Outlook
- **Window Size**: 1200px × 650px (resizable)
- **Startup Position**: Center screen

## Keyboard Shortcuts

- **Tab**: Navigate between fields
- **Enter**: Move to next row in DataGrid
- **Delete**: Remove selected row from DataGrid
- **Ctrl+C**: Copy selected cell/row
- **Ctrl+V**: Paste into selected cell/row

## Error Handling

- **Invalid Charged Value**: Red border appears if value is not 0 or 1
- **Outlook Not Found**: Error message displays if Outlook is not installed
- **Email Creation Failure**: Error dialog shows detailed error message

## Future Enhancement Opportunities

- Save reports to file (CSV, Excel)
- Load previous reports
- Email templates
- Multiple report templates
- Auto-save functionality
- Report history tracking
- Export to PDF
- Dark mode theme
