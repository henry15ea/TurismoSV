   M S B A M L   `   `   `  ����K  GTurismoSV_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana<TurismoSV_client.views.administrador.vadmin.controlesVentana  5      Y    STurismoSV_client.views.administrador.vadmin.controlesVentana.pkgCalificacionControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \localJclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana     5      .��5	      � .+�5
   
   � .+�5      ]� $��Stretch=�6   .+�5      �� $	��Top=�6     �� Padding$  5q�6.   $��1q�6:   ._�5      �  � Orientation$ Vertical=�6!   .+�5      �� $��Calificacion de paquetes��6    $
��Left=�6C   $��24(�6^   $	��Top=�6l   $
��Bold"�6�   5      �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Buscar��6$   67   �� 5      -   5         ��Name$ txt_itemSearch��5   &   $��15,0,0,0q�6>   $��Stretch=�6P   $	��520��6n   $	��720��6}   6�   �� 5      -   5         ��Name$ btn_searchElement��5   %   $��5,0,0,0q�6@   $��90��6Q   .��5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $,��&/views/administrador/vadmin/search.png��6,   $��32��6\   $��32��6h   $��UniformToFill=�6s   5   #   5      5      5      5      �� 5      $��Bottom=�6   
������ $ 
Horizontal=�6N   $��Stretch=�6g   $	��0,5q�6�   .+�5      �� $��Stretch=�6"   
�������.+�5      �� $  4q�6!   $��Stretch=�6-   $��Stretch=�6I   ._�5       � $ Vertical=�6(   $��Stretch=�6?   $��Stretch=�6[   .+�5!   "   �� $��Elemento��6+   $��15(�6=   $��Stretch=�6K   $��Stretch=�6g   .��5"   &   �� $��Stretch=�61   $ Vertical=�6M   .+�5$   *   �� $	��430��65   $��5q�6B   .+�5%   .   �� $��Usuario��64   $
��Left=�6F   $	��Top=�6a   �� 5&   .   -   5        $��cboxuser��5&   v   $
��Left=�67   $	��Top=�6R   $	��254��6j   6v   �� 5'   .   $��Paquete��64   $
��Left=�6F   $	��Top=�6b   �� 5(   .   -   5        $��cboxpaquete��5(   v   $
��Left=�67   $	��Top=�6R   $	��254��6j   6v   �� 5)   .   -   5        $��chblike��5)   �   $��le gusto��67   $��0,15,0,0q�6J   $
��Left=�6\   $	��Top=�6w   6�   5*   +   �� 5,   *   $ 
Horizontal=�65   $��1q�6N   .+�5-   .   �� 
��� � �$��4q�6H    �� CornerRadius$ 8��6\   $  4q�6m   ._�5.   2   �� -   5        $ btn_saveData��5.   9   $��Guardar��6O   
������ 
������ 
�������$	��120��6�   $
��Left=�6�   $	��Top=�6�   50   3   51   /   �� 52   .   
��� ���$��4q�6I   $ 8��6]   $  4q�6n   ._�53   2   �� -   5        $	��Acl��53   �   $��
Actualizar��69   
������ 
������ $	��110��6�   $
��Left=�6�   $	��Top=�6�   ${�False��6�   6�   54   /   55   +   56   '   57   #   58      59      5:      � 5;      $��5q�6!   $ 
Horizontal=�6,   
������ $��Stretch=�6_   .+�5<      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataTable��5<   $      
IsReadOnly$
 True��67   $	��500��6I   $	��805��6V   $	��510��6b      AutoGenerateColumns$ False��6s   ���#f9f9f9	   SelectionMode$	 Extended=�5=      
   AlternatingRowBackground
 �#fff �� AlternationCount$ 2��5>   9      SelectionUnit$ FullRow=�5?         GridLinesVisibility$
 None=�62   $��Visible=�6M   $��Visible=�6�      RowHeaderStyle 5@      �� 5A   "      ColumnHeaderStyle 5C      �� 5D   "      Columns 5G      4  .System.Windows.Controls.DataGridTemplateColumn  5H   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 69      Header$ Seleccionar��6D      CellTemplate 5I   &   �� 5J   *   .R�5K   .   �� .+�5L   2   �� 
���   �$	��0.2q�6M   ._�5M   6   �� ���#AFD3E2$ 4��6R   ���#146C94$��1q�6y   $  2q�6�   $��6q�6�   $��42��6�   ._�5N   :   �� -	   5        
������ 
������ $��Center=�5N   t   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *id_calificacion+.��5O   >   �� $ 
Horizontal=�6I   $��Center=�6b   $��Center=�6   .+�5P   B   �� $,��&/views/administrador/vadmin/edit-1.png��6H   $��Center=�6x   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5Q   ?   5R   ;   5S   7   5T   3   5U   /   5V   +   5X   #     5Z   "   $ Usuario��6:   $	 250 6K    5[   &   �� 5\   *   .R�5]   .   �� 
���   �$	��0.3q�6I   ._�5^   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�    �� TextAlignment$ Center=�6�   ��6�   �� *nom+6�   5_   /   5`   +   5b   #     5d   "   $ Paquete��6:   $	 250 6K    5e   &   �� 5f   *   .R�5g   .   �� 
���   �$	��0.3q�6I   ._�5h   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�   $ Center=�6�   ��6�   �� *nomd+6�   5i   /   5j   +   5l   #     5n   "   $
 Nota��6:   $	 250 6H    5o   &   �� 5p   *   .R�5q   .   �� 
���   �$	��0.3q�6I   ._�5r   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�   $ Center=�6�   ��6�   �� *nota+6�   5s   /   5t   +   5v   #     5x   "   $ Fecha��6:   $	 250 6I    5y   &   �� 5z   *   .R�5{   .   �� 
���   �$	��0.3q�6I   ._�5|   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�   $ Center=�6�   ��6�   �� *fecha+6�   5}   /   5~   +   5�   #     5�   "   $ 90 69   $ Eliminar��6D    5�   &   �� 5�   *   .R�5�   .   �� 
���   �$	��0.2q�6I   ._�5�   2   �� ���#D25380$ 4��6N   ���#D21312$��1q�6u   $  2q�6�   $��6q�6�   $��42��6�   ._�5�   6   �� -
   5        
������ 
������ $��Center=�5�   p   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *id_calificacion+.��5�   :   �� $ 
Horizontal=�6E   $��Center=�6^   $��Center=�6{   .+�5�   >   �� $,��&/views/administrador/vadmin/delete.png��6D   $��Center=�6t   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5�   ;   5�   7   5�   3   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      