   M S B A M L   `   `   `  ����N  JContactsTestProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ContactsTestProject.ViewContactsTestProject.View  5   	   M+clr-namespace:ContactsTestProject.ViewModelContactsTestProject.ViewModel  5   	   $    ContactsTestProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4v&clr-namespace:ContactsTestProject.View     5   	   :vm+clr-namespace:ContactsTestProject.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5      1  +ContactsTestProject.ViewModel.ContactListVM   VM��%   &	          5   
   6   5	      .��5
      �  � DataContext 6   ��  �� Source# [   � RowDefinitions 5   
   �� 5      $
��40px �6   6,   �� 5      6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Contacts Test Project��6    �� Padding$ 0,0,10,0q�65   $��Center=�6H   $��Tahoma)�6c   $��22(�6w   6�   �� 5      $
��10 0q�64   $��5q�6C   ��6   �� *
AddCommand+.��6N   Add6S   �� 5      $
��10 0q�65   $��5q�6D   ��6   �� *EditCommand+.��6O   Edit6U   �� 5      $
��10 0q�67   $��5q�6F   ��6   �� *DeleteCommand+.��6Q   Delete6Y   5      /   )ContactsTestProject.View.ContactsListView  5   
   $��1��6   5      5      