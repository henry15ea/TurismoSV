   M S B A M L   `   `   `  ����K  GTurismoSV_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana<TurismoSV_client.views.administrador.vadmin.controlesVentana  5      Y    STurismoSV_client.views.administrador.vadmin.controlesVentana.MunicipiosAdminControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \localJclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana     5      .��5	      � .+�5
   
   � .+�5      ]� $��Stretch=�6   .+�5      �� $	��Top=�6     �� Padding$  5q�6.   $��1q�6:   ._�5      �  � Orientation$ Vertical=�6!   .+�5      �� $��
Municipios��6    $
��Left=�65   $��24(�6P   $	��Top=�6^   $
��Bold"�6v   5      �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Buscar��6$   67   �� 5      -   5         ��Name$ txt_itemSearch��5   &   $��15,0,0,0q�6>   $��Stretch=�6P   $	��520��6n   $	��720��6}   6�   �� 5      -   5         ��Name$ btn_searchElement��5   %   $��5,0,0,0q�6@   $��90��6Q   .��5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $,��&/views/administrador/vadmin/search.png��6,   $��32��6\   $��32��6h   $��UniformToFill=�6s   5   #   5      5      5      5      �� 5      $��Bottom=�6   
������ $ 
Horizontal=�6N   $��Stretch=�6g   $	��0,5q�6�   .+�5      �� $��Stretch=�6"   
�������.+�5      �� $  4q�6!   $��Stretch=�6-   $��Stretch=�6I   ._�5       � $ Vertical=�6(   $��Stretch=�6?   $��Stretch=�6[   .+�5!   "   �� $��Elemento��6+   $��15(�6=   $��Stretch=�6K   $��Stretch=�6g   .��5"   &   �� $��Stretch=�61   $ Vertical=�6M   .+�5$   *   �� $��Nombre��60   $
��Left=�6A   $	��Top=�6\   �� 5&   *   -   5        $��	txtnombre��5&   �   $
��Left=�62    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��254��6�   6�   �� 5'   *   $��Departamento��60   $
��Left=�6G   $	��Top=�6b   �� 5)   *   -   5        $
��cbox��5)   s   $
��Left=�63   $	��Top=�6O   $	��254��6g   6s   �� 5,   *   $ 
Horizontal=�65   $��10,15,10,10q�6O   .+�5-   .   �� 
��� � �$��4q�6H    �� CornerRadius$ 8��6\   $  4q�6m   ._�5.   2   �� -   5        $ btn_saveData��5.   9   $��Guardar��6O   
������ 
������ 
�������$	��120��6�   $
��Left=�6�   $	��Top=�6�   50   3   51   /   �� 52   .   
��� ���$��4q�6I   $ 8��6]   $  4q�6n   ._�53   2   �� -   5        $	��Acl��53   �   $��
Actualizar��69   
������ 
������ $	��110��6�   $
��Left=�6�   $	��Top=�6�   ${�False��6�   6�   54   /   55   +   56   '   57   #   58      59      5:      � 5;      $��5q�6!   $ 
Horizontal=�6,   
������ $��Stretch=�6_   .+�5<      � $��5q�6%   $ 
Horizontal=�60   
������ $��Stretch=�6c   .+�5=      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataTable��5=   (      
IsReadOnly$
 True��6;   $	��490��6M   $	��792��6Z   $	��510��6f   	   AutoGenerateColumns$	 False��6w   ���#f9f9f9
   SelectionMode$
 Extended=�5>         AlternatingRowBackground �#fff �� AlternationCount$ 2��5?   9      SelectionUnit$ FullRow=�5@         GridLinesVisibility$
 None=�62   $��Visible=�6M   $��Visible=�6�      RowHeaderStyle 5A   "   �� 5B   &      ColumnHeaderStyle 5D   "   �� 5E   &      Columns 5H   "   4  .System.Windows.Controls.DataGridTemplateColumn  5I   &   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6=      Header$ Seleccionar��6H      CellTemplate 5J   *   �� 5K   .   .R�5L   2   �� .+�5M   6   �� 
���   �$	��0.2q�6Q   ._�5N   :   �� ���#AFD3E2$ 4��6V   ���#146C94$��1q�6}   $  2q�6�   $��6q�6�   $��42��6�   ._�5O   >   �� -   5        
������ 
������ $��Center=�5O   x   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *idmunicipio+.��5P   B   �� $ 
Horizontal=�6M   $��Center=�6f   $��Center=�6�   .+�5Q   F   �� $,��&/views/administrador/vadmin/edit-1.png��6L   $��Center=�6|   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5R   C   5S   ?   5T   ;   5U   7   5V   3   5W   /   5Y   '     5[   &   $ 	Municipio��6>   $	 290 6Q    5\   *   �� 5]   .   .R�5^   2   �� 
���   �$	��0.3q�6M   ._�5_   6   �� $
��Wrap=�6@   $��Center=�6T   $��Stretch=�6o   $
��Bold"�6�    �� TextAlignment$ Center=�6�   ��6�   �� *nom+6�   5`   3   5a   /   5c   '     5e   &   $ Departamento��6>   $	 290 6T    5f   *   �� 5g   .   .R�5h   2   �� 
���   �$	��0.3q�6M   ._�5i   6   �� $
��Wrap=�6@   $��Center=�6T   $��Stretch=�6o   $
��Bold"�6�   $ Center=�6�   ��6�   �� *nomd+6�   5j   3   5k   /   5m   '     5o   &   $ 90 6=   $ Eliminar��6H    5p   *   �� 5q   .   .R�5r   2   �� 
���   �$	��0.2q�6M   ._�5s   6   �� ���#D25380$ 4��6R   ���#D21312$��1q�6y   $  2q�6�   $��6q�6�   $��42��6�   ._�5t   :   �� -	   5        
������ 
������ $��Center=�5t   t   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *idmunicipio+.��5u   >   �� $ 
Horizontal=�6I   $��Center=�6b   $��Center=�6   .+�5v   B   �� $,��&/views/administrador/vadmin/delete.png��6H   $��Center=�6x   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5w   ?   5x   ;   5y   7   5z   3   5{   /   5}   '   5�      5�      5�      5�      5�      5�      5�      5�      