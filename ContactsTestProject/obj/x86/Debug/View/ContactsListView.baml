   M S B A M L   `   `   `  ����N  JContactsTestProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ContactsTestProject.ModelContactsTestProject.Model  5      C&clr-namespace:ContactsTestProject.ViewContactsTestProject.View  5      /    )ContactsTestProject.View.ContactsListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      5m'clr-namespace:ContactsTestProject.Model     5      4v&clr-namespace:ContactsTestProject.View     5        � 	Resources  5       �� Color    HighlightedContactBackground  HighlightedContactForground��%Z   &	        &	 "     �� 5   
   $	 Red��6   6&   �� 5	   
   $ White��6   6(   5
      .��5      �� ��6   �� *
Contacts+ �� SelectedItem 6/   �� *SelectedContact+ �� Mode$ TwoWay=�  5   
    �� 
TargetType �� Triggers �� Binding  AgeCheckConverter �� 	Converter �� ConverterParameter	 �� Value
 �� Property �� Value��%�   '��       7  7   7  �� 5      " ��6    5      �� 5       6"   �� *DOB+8   $ 20��	 True6   .a�5      �� 
 � ��8  6o   �� 5      
 � ��8  6n   5      5      5      ��5   
   �� 5      .R�5      *   $ContactsTestProject.View.ContactView    Name$ ContactV��6    5      5      5       