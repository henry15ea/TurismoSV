   M S B A M L   `   `   `  ����K  GTurismoSV_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana<TurismoSV_client.views.administrador.vadmin.controlesVentana  5      Q    KTurismoSV_client.views.administrador.vadmin.controlesVentana.cuentasControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \localJclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana     5      .��5	      � .+�5
   
   � .+�5      ]� $��Stretch=�6   .+�5      �� $	��Top=�6     �� Padding$  5q�6.   $��1q�6:   ._�5      �  � Orientation$ Vertical=�6!   .+�5      �� $��Cuentas de acceso��6    $
��Left=�6<   $��24(�6W   $	��Top=�6e   $
��Bold"�6}   5      �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Buscar��6$   67   �� 5      -   5         ��Name$ txt_itemSearch��5   &   $��15,0,0,0q�6>   $��Stretch=�6P   $	��520��6n   $	��720��6}   6�   �� 5      -   5         ��Name$ btn_searchElement��5   %   $��5,0,0,0q�6@   $��90��6Q   .��5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $,��&/views/administrador/vadmin/search.png��6,   $��32��6\   $��32��6h   $��UniformToFill=�6s   5   #   5      5      5      5      �� 5      $��Bottom=�6   
������ $ 
Horizontal=�6N   $��Stretch=�6g   $	��0,5q�6�   .+�5      �� $��Stretch=�6"   
�������.+�5      �� $  4q�6!   $��Stretch=�6-   $��Stretch=�6I   ._�5       � $ Vertical=�6(   $��Stretch=�6?   $��Stretch=�6[   .+�5!   "   �� $��Elemento��6+   $��15(�6=   $��Stretch=�6K   $��Stretch=�6g   .��5"   &   �� $��Stretch=�61   $ Vertical=�6M   .+�5#   *   �� -   5        $��cboxusua��5#   u   $
��Left=�63   $��Center=�6N   $	��294��6i   $��32��6�   �� 5$   *   $��Usuario��60   $
��Left=�6B   $	��Top=�6^   �� 5%   *   -   5        $��
txtusuario��5%   �   $
��Left=�62    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��294��6�   $��32��6�   �� 5&   *   $��contraseña��60   $
��Left=�6E   $	��Top=�6a   $��32��6y   �� 5'   *   -   5        $��	txtcontra��5'   �   $
��Left=�62   $
 Wrap=�6M   $�� ��6a   $	��Top=�6i   $	��294��6�   $��32��6�   6�   �� 5(   *   -   5        $��	chbestado��5(   �   $��Estado��63   $��0,15,5,0q�6D   $
��Left=�6V   $	��Top=�6q   $��32��6�   �� 5+   *   $ 
Horizontal=�65   $��1q�6N   .+�5,   .   �� 
��� � �$��4q�6H    �� CornerRadius$ 8��6\   $  4q�6m   ._�5-   2   �� -   5        $ btn_saveData��5-   9   $��Guardar��6O   
������ 
������ 
�������$	��120��6�   $
��Left=�6�   $	��Top=�6�   5/   3   50   /   �� 51   .   
��� ���$��4q�6I   $ 8��6]   $  4q�6n   ._�52   2   �� -   5        $	��Acl��52   �   $��
Actualizar��69   
������ 
������ $	��110��6�   $
��Left=�6�   $	��Top=�6�   ${�False��6�   6�   53   /   54   +   55   '   56   #   57      58      59      � 5:      $��5q�6"   $ 
Horizontal=�6-   
������ $��Stretch=�6`   .+�5;      &   System.Windows.Controls.DataGrid  -	   5        $��DG��5;   #      
IsReadOnly$
 True��6-   $	��785��6?   $	��498��6K   $	��510��6X      AutoGenerateColumns$ False��6i   ���#f9f9f9	   SelectionMode$	 Extended=�5<      
   AlternatingRowBackground
 �#fff �� AlternationCount$ 2��5=   9      SelectionUnit$ FullRow=�5>         GridLinesVisibility$
 None=�62   $��Visible=�6M   $��Visible=�6�      RowHeaderStyle 5?      �� 5@   "      ColumnHeaderStyle 5B      �� 5C   "      Columns 5E      4  .System.Windows.Controls.DataGridTemplateColumn  5F   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 69      Header$ Seleccionar��6D      CellTemplate 5G   &   �� 5H   *   .R�5I   .   �� .+�5J   2   �� 
���   �$	��0.2q�6M   ._�5K   6   �� ���#AFD3E2$ 4��6R   ���#146C94$��1q�6y   $  2q�6�   $��6q�6�   $��42��6�   ._�5L   :   �� -
   5        
������ 
������ $��Center=�5L   t   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *	id_cuenta+.��5M   >   �� $ 
Horizontal=�6I   $��Center=�6b   $��Center=�6   .+�5N   B   �� $,��&/views/administrador/vadmin/edit-1.png��6H   $��Center=�6x   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5O   ?   5P   ;   5Q   7   5R   3   5S   /   5T   +   5V   #     5Y   "   $ Nombre��6:   $	 250 6J    5Z   &   �� 5[   *   .R�5\   .   �� 
���   �$	��0.3q�6I   ._�5]   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�    �� TextAlignment$ Center=�6�   ��6�   �� *nombre+6�   5^   /   5_   +   5a   #     5c   "   $ Usuario��6:   $	 250 6K    5d   &   �� 5e   *   .R�5f   .   �� 
���   �$	��0.3q�6I   ._�5g   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�   $ Center=�6�   ��6�   �� *u_name+6�   5h   /   5i   +   5k   #     5m   "   $ Clave��6:   $	 250 6I    5n   &   �� 5o   *   .R�5p   .   �� 
���   �$	��0.3q�6I   ._�5q   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�   $ Center=�6�   ��6�   �� *u_pass+6�   5r   /   5s   +   5u   #     5w   "   $ Registro��6:   $	 250 6L    5x   &   �� 5y   *   .R�5z   .   �� 
���   �$	��0.3q�6I   ._�5{   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�   $ Center=�6�   ��6�   �� *
u_registro+6�   5|   /   5}   +   5   #     5�   "   $ Estado��6:   $	 250 6J    5�   &   �� 5�   *   .R�5�   .   �� 
���   �$	��0.3q�6I   ._�5�   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�   $ Center=�6�   ��6�   �� *	u_state+6�   5�   /   5�   +   5�   #     5�   "   $ 90 69   $ Eliminar��6D    5�   &   �� 5�   *   .R�5�   .   �� 
���   �$	��0.2q�6I   ._�5�   2   �� ���#D25380$ 4��6N   ���#D21312$��1q�6u   $  2q�6�   $��6q�6�   $��42��6�   ._�5�   6   �� -   5        
������ 
������ $��Center=�5�   p   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *	id_cuenta+.��5�   :   �� $ 
Horizontal=�6E   $��Center=�6^   $��Center=�6{   .+�5�   >   �� $,��&/views/administrador/vadmin/delete.png��6D   $��Center=�6t   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5�   ;   5�   7   5�   3   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      