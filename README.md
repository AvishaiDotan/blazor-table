# Blazor Table

This is a Blazor component that displays a table and allows users to interact with it, including adding and deleting columns and records, editing cells, sorting and filtering the table, and more.


![Index](https://user-images.githubusercontent.com/108017307/219502237-d2b32f63-5644-4583-820f-4f75e2160442.png)

## Features

### Adding Columns
![Blazor add column](https://user-images.githubusercontent.com/108017307/219497899-458c0a60-51c0-4fe9-85a4-0a9f21eeba6f.png)

To add a new column to the 
table, the user can either click on the "+" button located at the end of the table, or right-click on a column header and choose "Insert column right of this column" or "Insert column left of this column". Then, the user will be prompted to choose the column type from the following options: Text, Checkbox, Date, Number.

### Adding Records
![blazor add row](https://user-images.githubusercontent.com/108017307/219497926-804e9a4a-1cb3-41d9-b020-863d31bae6fb.jpg)

To add a new record to the table, the user can either click the "Add record" button located above the table, click the "+" button at the end of the table, or right-click on a record and choose "Add record below". Alternatively, the user can press the "Shift" and "Enter" keys on the keyboard.

![Index (1) (1) (1)](https://user-images.githubusercontent.com/108017307/219501950-2f3090ad-5e89-4d33-bb1d-5c01b58e104b.gif)

### Editing Cells

To edit a cell in the table, the user can either click on the cell and start typing, double-click on the cell, or press the "F2" key on the keyboard.

### Deleting Records

To delete a record from the table, the user can either right-click on the record and choose "Delete record", or press the "Ctrl" and "Del" keys on the keyboard when one of the cells of the record is highlighted.


### Duplicating Records

To duplicate a record in the table, the user can right-click on the record and choose "Duplicate record".

### Sorting the Table
![blazor sort](https://user-images.githubusercontent.com/108017307/219497973-deac17e8-dba7-4d52-8f93-252efc9b9924.jpg)
To sort the table, the user can click on a column header. Clicking once will sort the table in ascending order, and clicking again will sort the table in descending order.

### Filtering the Table
![blazor filter](https://user-images.githubusercontent.com/108017307/219498166-8cb09968-a5aa-46ca-8686-b047d86485e6.png)

To filter the table, the user can click on the filter icon located next to a column header. Then, the user can choose a filter condition from the dropdown menu or type in a custom value.

## Infrastructure

This component is built using Blazor WASM and LINQ. The UI is styled using SCSS, which is compiled to CSS during the build process.
