   M S B A M L   `   `   `  ����K  GTurismoSV_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyAclr-namespace:TurismoSV_client.views.administrador.dialogsReports3TurismoSV_client.views.administrador.dialogsReports  5   	   E    ?TurismoSV_client.views.administrador.dialogsReports.wcategorias   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   SlocalAclr-namespace:TurismoSV_client.views.administrador.dialogsReports     5   	     � Title$  Generar Reporte��5   	   $	��400��6!   $	��270��6-   $��5q�6:    � WindowStartupLocation$ CenterScreen=�6F   .��5	      � .+�5
   
   �� -   5         ��Name$ 	workPanel��5
       �� Padding$ 1q�6$   $��1q�60    �� CornerRadius$ 5��6;   ._�5      �  � RowDefinitions 5      �� 5      $��32 �6$   �� 5      $	��150 �6$   �� 5      $��38 �6$   .+�5      �� $��0��6   ���#295270 �� Orientation$ 
Horizontal=�6?   .+�5      �� $,��&Generar Reporte Paquetes por categoria��6   $��15(�6M   
�������$��	Condensed&�6n   $
��Bold"�6�   6�   5      �� 5      $��1��6   ���#DCDCDC$ Vertical=�6?   .+�5      �� $ 5q�6   ._�5      �� .+�5      �� $��Seleccione categoria��6$   $��15(�6C   6S   �� 5      -   5         ��Name$ cmbx_listadoCategorias��5   '   $��Center=�6G   $��Center=�6b    �� 
IsReadOnly$
 True��6�   $��32��6�   6�   �� 5      $��Cantidad de elementos��6$   $��15(�6D   6T   �� 5      -   5        	 ��Name$	 txt_numElements��5   &   
 �� 	MaxLength$
 5��6?    �� TextWrapping$
 Wrap=�6M   $	��100��6a   $	��380��6l   $��0,10,0,5q�6x   $��Center=�6�   $��Stretch=�6�   $��18(�6�   6�   5      5      5      �� 5      $��2��6   ���#2C323D$ 
Horizontal=�6?   .+�5       �� $ 3q�6   ._�5!      �� $ 
Horizontal=�6%   .+�5"      �� ���#AE323D
�������$	��0.8q�6N   $ 1q�6d   $ 4��6p   $	��120��6�   ._�5#   "   �� -   5         ��Name$ 
btn_cancel��5#   )   $��Cancelar��6=   
������ 
������ $
��Bold"�6�   
�������6�   5$      �� 5&      $��	130,0,0,0q�6%   ���#1E793E
�������$	��0.8q�6a   $ 1q�6w   $ 4��6�   $	��120��6�   ._�5'   "   �� -   5        $ btn_generaReport��5'   )   $��Generar Reporte��6C   
������ 
������ $
��Bold"�6�   
�������6�   5(      5)      5*      5+      5,      5-      5.      5/      