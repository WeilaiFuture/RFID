   M S B A M L   `   `   `  ����A  =用户, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:用户用户  5   	       用户.Window3   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:用户     5   	     � Title$  预约模块��5   	   $	��450��6   $	��800��6#   .��5	      ]� .+�5
   
   � $	��Top=�6   
�������$��0,0,0,0q�67    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   .+�5      �� -   5        $��提交预约��5      $��0��6$   $��Right=�64   $��80��6P   $��0q�6[   
�������$��0,0,0.6,0.6q�6�   $��25��6�   $��Bottom=�6�   6�   �� 5      -   5        $��删除预约��5      $��1��6$   $
��Left=�64   $	��Top=�6P   $��80��6h   $��25��6s   $��0q�6   
�������6�   5      �� 5   
   -   5        $��listView��5       J� 	AllowDrop . $��Disabled=�64   $��Visible=�6j    �� View 5      �� 5      .P�5      �� $��   预约编号   ��6%    �� Width$	 150��6d    �� DisplayMemberBinding 69   �� *	IdOfOrder+6d   �� 5      $��   卡号   ��6%   $	 150��6[    67   �� *Id+6[   �� 5      $��        时间      ��6%   $	 200��6k    6@   �� *	OrderDate+6k   �� 5      $ ��        预约时间      ��6%   $	 200��6h    6B   �� *Date+6h   5       5"      5$      5%      