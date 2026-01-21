# Daily Report Tool - UI Mockup

```
┌─────────────────────────────────────────────────────────────────────────────┐
│  Daily Report Tool                                                      _ □ × │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                               │
│  2026-01-21                                                                   │
│                                                                               │
│  Email To:                                                                    │
│  ┌────────────────────────────────────────────────────────────────────────┐  │
│  │ Enter email recipients                                                 │  │
│  └────────────────────────────────────────────────────────────────────────┘  │
│                                                                               │
│  CC:                                                                          │
│  ┌────────────────────────────────────────────────────────────────────────┐  │
│  │ Enter CC recipients                                                    │  │
│  └────────────────────────────────────────────────────────────────────────┘  │
│                                                                               │
│  Daily Report Entries                                                         │
│  ┌────────────────────────────────────────────────────────────────────────┐  │
│  │ ID │ Delivery Date │ Charged Date │ Engagement ID │ Activity │ Acc... │  │
│  ├────┼───────────────┼──────────────┼───────────────┼──────────┼────────┤  │
│  │  1 │  2026-01-21   │  2026-01-21  │               │          │        │  │
│  ├────┼───────────────┼──────────────┼───────────────┼──────────┼────────┤  │
│  │    │               │              │               │          │        │  │
│  ├────┼───────────────┼──────────────┼───────────────┼──────────┼────────┤  │
│  │    │               │              │               │          │        │  │
│  ├────┼───────────────┼──────────────┼───────────────┼──────────┼────────┤  │
│  │    │               │              │               │          │        │  │
│  ├────┼───────────────┼──────────────┼───────────────┼──────────┼────────┤  │
│  │    │               │              │               │          │        │  │
│  └────────────────────────────────────────────────────────────────────────┘  │
│                                                                               │
│  ┌──────────────┐                                                             │
│  │ Create Email │                                                             │
│  └──────────────┘                                                             │
│                                                                               │
└─────────────────────────────────────────────────────────────────────────────┘

Full DataGrid Columns (scroll right to see all):
┌────┬───────────────┬──────────────┬───────────────┬──────────┬─────────┬─────────┬─────────┐
│ ID │ Delivery Date │ Charged Date │ Engagement ID │ Activity │ Account │ Details │ Charged │
├────┼───────────────┼──────────────┼───────────────┼──────────┼─────────┼─────────┼─────────┤
│  1 │  2026-01-21   │  2026-01-21  │               │          │         │         │    0    │
└────┴───────────────┴──────────────┴───────────────┴──────────┴─────────┴─────────┴─────────┘

UI Features:
- Modern Windows 10/11 style (ModernWpf)
- Clean, professional appearance
- Accent color button (Create Email)
- Alternating row colors for readability
- Resizable columns
- Sortable headers
- Editable cells
- Add/Delete rows
```

## UI Behavior

### On Application Start:
- Today's date is displayed at the top
- One sample row is pre-populated with ID=1 and today's dates
- Email fields are empty and ready for input

### When Adding a New Row:
- Click in the empty row at the bottom
- Delivery Date and Charged Date auto-fill with today's date
- All other fields are empty and ready for input
- Charged defaults to 0

### When Editing Charged Column:
- Only accepts values 0 or 1
- Red border appears if invalid value is entered
- User must correct before proceeding

### When Clicking Create Email:
- Validates all data
- Opens Microsoft Outlook
- Creates new email draft with:
  - To: (from Email To field)
  - CC: (from CC field)
  - Subject: "Daily Report - [Date]"
  - Body: Formatted table with all entries
- Shows success message

## Color Scheme (ModernWpf)
- Background: White/Light Gray
- Accent: System accent color (typically blue)
- Text: Dark Gray/Black
- Alternating Rows: Light Gray (#F5F5F5)
- Hover: Subtle highlight
- Selection: Accent color with transparency

## Typography
- Title: 18pt, SemiBold
- Section Headers: 16pt, SemiBold
- Labels: Default, SemiBold
- Input Fields: Default, Regular
- Table Content: Default, Regular
- Button: 14pt, Regular
