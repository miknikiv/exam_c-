   M S B A M L   `   `   `  ����  zad3     MediaLibrary.AddEditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add/Edit Media Item��5   	   $	��400��6%   $	��300��61   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Tytuł��6   $��0��6    �� 5   
   -   5        $��TytułTextBox��5      $��0��6&   ��63   �� *Tytuł+ �� Mode$ TwoWay=��� 5   
   $��Reżyser/Autor��6   $��1��6(   �� 5   
   -   5        $��ReżyserAutorTextBox��5      $��1��6-   ��6:   �� *ReżyserAutor+$ TwoWay=��� 5   
   $��Wydawca/Studio��6   $��2��6)   �� 5   
   -   5        $��WydawcaStudioTextBox��5      $��2��6.   ��6;   �� *WydawcaStudio+$ TwoWay=��� 5   
   $��Nośnik��6   $��3��6!   �� 5   
   -   5        $��NośnikComboBox��5      $��3��6)    �� SelectedItem 66   �� *	Nośnik+$ TwoWay=�.@�5      �� $	��VHS��6   �� 5      $	��DVD��6   �� 5      $��BlueRay��6   �� 5      $��Kaseta��6   �� 5      $��CD��6   �� 5      $��Pendrive��6   5       �� 5"   
   $��Długość (HH:mm:ss)��6   $��4��6-   �� 5#   
   -   5        $��DługośćTextBox��5#      $��4��6(   ��65   �� *
Długość+$ TwoWay=��� 5%   
   $��Data Wydania��6   $��5��6'   (  "System.Windows.Controls.DatePicker  5&   
   -   5        $��DataWydaniaDatePicker��5&      $��5��62      SelectedDate 6?   �� *DataWydania+$ TwoWay=��� 5(   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5)      �� -   5        $��ZapiszButton��5)   &   $��Zapisz��6   $	��100��6O   �� 5*      -   5        $��AnulujButton��5*   &   $��Anuluj��6   $	��100��6O   5+      5,      5-      