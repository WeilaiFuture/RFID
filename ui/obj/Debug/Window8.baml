   M S B A M L   `   `   `  ����G  C消费中心, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:消费中心消费中心  5   	       消费中心.Window8   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:消费中心     5   	     � Title$  消费记录��5   	   $	��450��6   $	��800��6#   .��5	      ]� .+�5
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
��Auto �6#   .+�5      �� -   5        $��用户查找��5      $��3��6$   $
��Left=�64   $	��Top=�6P   $��80��6h   $��25��6s   $��0q�6   
�������6�   �� 5      $��请输入账号：��6   $��7��6%   67   �� 5      -   5        $��Text2��5      $��8��6#   $��Center=�64   $	��200��6O   $��25��6\   5      � 5   
   .+�5      �� -   5        $��listView��5       J� 	AllowDrop . $��Disabled=�68   $��Visible=�6n    �� View 5      �� 5      .P�5      �� $��   账单编号   ��6)    �� Width$	 150��6j    �� DisplayMemberBinding 6=   �� *IdOfPayment+6j   �� 5      $��
  卡号  ��6)   $	 150��6^    69   �� *Id+6^   �� 5       $��        时间      ��6)   $	 150��6j    6D   �� *Time+6j   �� 5!      $��
  地点  ��6)   $	 150��6d    69   �� *
AreaName+6d   �� 5"      $��        金额      ��6)   $	 150��6i    6D   �� *Pay+6i   5#      5%      5&      5'      5(      