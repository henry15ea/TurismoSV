   M S B A M L   `   `   `  ����K  GTurismoSV_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana<TurismoSV_client.views.administrador.vadmin.controlesVentana  5      W    QTurismoSV_client.views.administrador.vadmin.controlesVentana.departamentosControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \localJclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana     5      .��5	      � .+�5
   
   � .+�5      ]� $��Stretch=�6   .+�5      �� $	��Top=�6     �� Padding$  5q�6.   $��1q�6:   ._�5      �  � Orientation$ Vertical=�6!   .+�5      �� $��Departamentos��6    $
��Left=�68   $��24(�6S   $	��Top=�6a   $
��Bold"�6y   5      �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Buscar��6$   67   �� 5      -   5         ��Name$ txt_itemSearch��5   &   $��15,0,0,0q�6>   $��Stretch=�6P   $	��520��6n   $	��720��6}   6�   �� 5      -   5         ��Name$ btn_searchElement��5   %   $��5,0,0,0q�6@   $��90��6Q   .��5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $,��&/views/administrador/vadmin/search.png��6,   $��32��6\   $��32��6h   $��UniformToFill=�6s   5   #   5      5      5      5      �� 5      $��Bottom=�6   
������ $ 
Horizontal=�6N   $��Stretch=�6g   $	��0,5q�6�   .+�5      �� $��Stretch=�6"   
�������.+�5      �� $  4q�6!   $��Stretch=�6-   $��Stretch=�6I   ._�5      � $ Vertical=�6(   $��Stretch=�6?   $��Stretch=�6[   .+�5    "   �� $��Elemento��6+   $��15(�6=   $��Stretch=�6K   $��Stretch=�6g   .��5!   &   �� $��Stretch=�61   $ Vertical=�6M   .+�5"   *   �� $��Nombre��60   $
��Left=�6A   $��Center=�6]   �� 5#   *   -   5        $��	txtnombre��5#   �   $��Stretch=�62   $	��240��6P    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $��Stretch=�6|   6�   �� 5$   *   $ 
Horizontal=�65   $��1q�6N   .+�5%   .   �� 
��� � �$��4q�6H    �� CornerRadius$ 8��6\   $  4q�6m   ._�5&   2   �� -   5        $ btn_saveData��5&   9   $��Guardar��6O   
������ 
������ 
�������$	��120��6�   $
��Left=�6�   $	��Top=�6�   5(   3   5)   /   �� 5*   .   
��� ���$��4q�6I   $ 8��6]   $  4q�6n   ._�5+   2   �� -   5        $	��Acl��5+   �   $��
Actualizar��69   
������ 
������ $	��110��6�   $
��Left=�6�   $	��Top=�6�   ${�False��6�   6�   5,   /   5-   +   5.   '   5/   #   50      51      52      � 53      $��5q�6!   $ 
Horizontal=�6,   
������ $��Stretch=�6_   .+�54      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataTable��54   $      
IsReadOnly$
 True��67   $	��815��6I   $	��510��6U   	   AutoGenerateColumns$	 False��6f   ���#f9f9f9
   SelectionMode$
 Extended=�55         AlternatingRowBackground �#fff �� AlternationCount$ 2��56   9      SelectionUnit$ FullRow=�57         GridLinesVisibility$
 None=�62   $��Visible=�6M   $��Visible=�6�      RowHeaderStyle 58      �� 59   "      ColumnHeaderStyle 5;      �� 5<   "      Columns 5?      4  .System.Windows.Controls.DataGridTemplateColumn  5A   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6:      Width5  /System.Windows.Controls.DataGridLengthConverter$	 450 6J      CellTemplate 5B   &   �� 5C   *   .R�5D   .   �� 
���   �$	��0.3q�6I   ._�5E   2   �� $��Center=�68   $��Stretch=�6S   $��Center=�6q   $
��Bold"�6�   ��6�   �� *nombre+6�   5F   /   5G   +   5I   #     5K   "   $ 90 69   $ Eliminar��6D    5L   &   �� 5M   *   .R�5N   .   �� 
���   �$	��0.2q�6I   ._�5O   2   �� ���#D25380$ 4��6N   ���#D21312$��1q�6u   $  2q�6�   $��6q�6�   $��42��6�   ._�5P   6   �� -   5        
������ 
������ $��Center=�5P   p   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *iddepartamento+.��5Q   :   �� $ 
Horizontal=�6E   $��Center=�6^   $��Center=�6{   .+�5R   >   �� $,��&/views/administrador/vadmin/delete.png��6D   $��Center=�6t   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5S   ;   5T   7   5U   3   5V   /   5W   +   5Y   #     5Z   "   $ 90 69   $ Seleccionar��6D    5[   &   �� 5\   *   .R�5]   .   �� .+�5^   2   �� 
���   �$	��0.2q�6M   ._�5_   6   �� ���#AFD3E2$ 4��6R   ���#146C94$��1q�6y   $  2q�6�   $��6q�6�   $��42��6�   ._�5`   :   �� -   5        
������ 
������ $��Center=�5`   t   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *iddepartamento+.��5a   >   �� $ 
Horizontal=�6I   $��Center=�6b   $��Center=�6   .+�5b   B   �� $,��&/views/administrador/vadmin/edit-1.png��6H   $��Center=�6x   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5c   ?   5d   ;   5e   7   5f   3   5g   /   5h   +   5j   #   5m      5o      5p      5r      5s      5t      5u      