   M S B A M L   `   `   `  ����  ContactsTestProject/    )ContactsTestProject.View.ContactsEditView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      �   � RowDefinitions  5   
   �� 5      �� 5	      �� 5
       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��First Name:��6   6(   �� 5   
   $��1��6n   ��6   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6n   �� 5   
   $��
Last Name:��6   $��1��6%   64   �� 5   
   $��1��6m   $��1��6}   ��6   �� *
LastName+$ PropertyChanged=� . 6}   �� 5   
   $��Date Of Birth:��6   $��2��6)   68   (  "System.Windows.Controls.DatePicker  5   
   $��1��6s   $��2��6�      SelectedDate 6   �� *DOB+$ PropertyChanged=� . 6�   5      5      