   M S B A M L   `   `   `  ����K  GTurismoSV_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:TurismoSV_client.views.templateTurismoSV_client.views.template  5   	   2    ,TurismoSV_client.views.template.templateview   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:TurismoSV_client.views.template     5   	     � Title$  templateview��5   	   $	��450��6   $	��800��6+    � Icon$ /views/tourism-icon-7.jpg��67    � SizeToContent$ Manual=�6X    � WindowStartupLocation$ CenterScreen=�6o   $
��1200��6�   $��719.4��6�   
�������.��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��119* �6   ��5      �� 5      5      �� 5      $��1081* �6   ��5      �� 5      5      .+�5   
   �� ���	#FF1261AD J� RenderTransformOrigin$ 0.481,0.604&�6,   $	��703��6P   $��Bottom=�6]   .+�5      � $��Center=�6   $��0,25,5,5q�65   .+�5      �� $��48��6   $��49��6$   $!��/views/turismo-1024x637.png��6/    J� OpacityMask �	#FF45E49E6T   5      �� 5       �� Padding$ 5q�6   ���#001d3d$��Bottom=�66   ._�5      � $	��634��6   
������ $	��250��6=    � RowDefinitions 5      �� 5      $
��458* �6(   �� 5      $	��25* �6(   .+�5!      �� ._�5"      �� 
������ $��	-2,0,0,20q�6>   .+�5#      �� $��49��6)   ���#457b9d	 �� Orientation$	 
Horizontal=�6J   .+�5$   "   �� $��41��6(   $��56��64   $(��"/views/template/tourism-icon-7.jpg��6?   �� 5%   "   $��Inicio��6)   $��52��6:   
������ 
������ ���#fff5'   #   5(      �� 5)      $��51��6)   ���#457b9d$	 
Horizontal=�6J   $��0,5,0,1q�6c   .+�5*   "   �� $��46��6(   $��54��64   $��/views/shopping-cart.png��6?   �� 5+   "   $��Comprar��6)   
������ 
������ ���#fff6n   5,      �� 5-      $��53��6)   ���#457b9d$	 
Horizontal=�6J   $��0,5,0,1q�6c   .+�5.   "   �� $��45��6(   $��56��64   $��/views/user.png��6?   �� 5/   "   $��Cuenta��6)   
������ 
������ ���#fff6m   50      �� 51      $��46��6)   ���#457b9d$	 
Horizontal=�6J   $��0,5,0,1q�6c   .+�52   "   �� $��35��6(   $��54��64   $��/views/list.png��6?   �� 53   "   $��	Historial��6)   
������ 
������ ���#fff6p   54      55      56      �� 57      58      59      5:      � 5;   
   $��1��6    5<      �� 5=      $	��59* �6    �� 5>      $
��647* �6    .+�5@      �� ���	#FF1261AD$	 
Horizontal=�60   $��RightToLeft=�6I   $��0,0,0,1q�6e   .+�5D      �� -   5        
 ��Name$
 btn_profileMenu��5D      $��Menú��62   ��6[   Z� ��5E      �� 5F      .R�5G      � .+�5H   "   � $��	MenuPopup��6(    � VerticalOffset$ 25��5I   a   $	��300��6u    � PlacementTarget 5H   9   ��  �� ElementName$ MyButton����5I      �� *	IsChecked+$ MenuToggleButton�� �� Mode$ TwoWay=�.��5J   &   �� $��5q�6-    �� CornerRadius$ 5��6A   ���#023047
�������._�5K   *   �� $ 5q�61   $ 15��6=   
�������._�5L   .   �� $	 Vertical=�69   .+�5M   2   �� $
 btn_account��69   -   5        $��Cuenta��5M   N   6_   �� 5O   2   $
 btn_closeSesion��69   -   5        $��Cerrar sesion��5O   R   $��0,5,0,0q�6j   6{   5Q   /   5R   +   5S   '   5T   #   d� 5V   "   $��MenuToggleButton��6/   $
��Left=�6G   #��["�6c   $��76��6�   $��50��6�   .��5W   &   �� $��49��6,   $��77��68   $ ��/views/default_profile.png��6C   5Y   #   5[      5\      5^      �� 5`      -   5        $
 btn_username��5`      $��Menú��6/   $	��192��6S   $��0,5,0,5q�6_   
�������$��Center=�6�   $��LeftToRight=�6�   $��18(�6�   $
��Bold"�6�   $��Carlito)�6  ��6p   Z� ��6�   Z� 5a      5b      �� 5c      
����  �$��3,1,3,1q�6+   $��1��6<   $��2��6I   5e      5f      5g      5h      