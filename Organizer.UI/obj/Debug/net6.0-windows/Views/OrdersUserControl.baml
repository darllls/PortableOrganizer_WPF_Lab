   M S B A M L   `   `   `  ����G  COrganizer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Organizer.UI.ViewsOrganizer.UI.Views  5      A%clr-namespace:Organizer.UI.ConvertersOrganizer.UI.Converters  5      *    $Organizer.UI.Views.OrdersUserControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Organizer.UI.Views     5      4my%clr-namespace:Organizer.UI.Converters     5        � 	Resources  5
      0   *Organizer.UI.Converters.ImagePathConverter   my:ImagePathConverter��%   &	          5   
   6    5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   $��Center=�63   $��Center=�6P   .+�5      �� $��Orders��6   $��Center=�6%   $��Center=�6B   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ dataGridOrders��5    M   $��1��6   $��0��6       AutoGenerateColumns$ False��61   ��5!      ��  �� Path$ Orders� �� SelectedItem 68   �� $ SelectedOrder� �� Mode$ TwoWay=�   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn	   Header$	 OrderId��6%   
   
IsReadOnly$

 True��6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� $ OrderId�$ TwoWay=�6d     5$      $	 Number��6%    65   �� $ Number�$ TwoWay=�  5%      $
	 Date��6%    63   �� $
 Date�$ TwoWay=� �� StringFormat$ {0:yyyy-MM-dd}��4  .System.Windows.Controls.DataGridTemplateColumn  5&      $	 Status��6)      CellTemplate 5'      �� 5(      .R�5)      �� $��25��6$   $��25��6/   ��6;   �� *Status+ �� 	Converter# [  5*      5,      5.      �� 51   
   $��1��6   $��2��6"    �� Orientation$ Vertical=�63   $��0q�6J   .+�52      �� $��Change Status��6   $��10q�6X   $��40��6d   $
��Auto��6p   $
��Left=�6}   ��6-   �� $ CloseOrderCommand�6}   �� 53      $��	Add to DB��6   $��10q�6R   $��40��6^   $
��Auto��6j   $
��Left=�6w   ��6)   �� $ AddOrderCommand�6w   �� 54      $��Update in DB��6   $��10q�6X   $��40��6d   $
��Auto��6p   $
��Left=�6}   ��6,   �� $ UpdateOrderCommand�6}   �� 55      $��Delete from DB��6   $��10q�6Z   $��40��6f   $
��Auto��6r   $
��Left=�6   ��6.   �� $ DeleteOrderCommand�6   56      57      58      