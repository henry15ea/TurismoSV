   M S B A M L   `   `   `  ����K  GTurismoSV_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana<TurismoSV_client.views.administrador.vadmin.controlesVentana  5      S    MTurismoSV_client.views.administrador.vadmin.controlesVentana.categoriaControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \localJclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana     5      .��5	      � .+�5
   
   � .+�5      ]� $��Stretch=�6   .+�5      �� $	��Top=�6     �� Padding$  5q�6.   $��1q�6:   ._�5      �  � Orientation$ Vertical=�6!   .+�5      �� $��
Categorias��6    $
��Left=�65   $��24(�6P   $	��Top=�6^   $
��Bold"�6v   5      �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Buscar��6$   67   �� 5      -   5         ��Name$ txt_itemSearch��5   &   $��15,0,0,0q�6>   $��Stretch=�6P   $	��520��6n   $	��720��6}   6�   �� 5      -   5         ��Name$ btn_searchElement��5   %   $��5,0,0,0q�6@   $��90��6Q   .��5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $,��&/views/administrador/vadmin/search.png��6,   $��32��6\   $��32��6h   $��UniformToFill=�6s   5   #   5      �� 5      $��50,0,0,0q�6)   .+�5   "   �� 
�������
���   �$��2q�6T   $  2q�6h    �� CornerRadius$ 4��6t   ._�5   &   �� -   5        $ 
btn_report��5   -   
������ 
������ $��Generar Reporte��6t   $��32��6�   5   '   5   #   5      5       5!      5"      �� 5$      $��Bottom=�6   
������ $ 
Horizontal=�6N   $��Stretch=�6g   $	��0,5q�6�   .+�5%      �� $��Stretch=�6"   
�������.+�5&      �� $  4q�6!   $��Stretch=�6-   $��Stretch=�6I   ._�5'      � $ Vertical=�6(   $��Stretch=�6?   $��Stretch=�6[   .+�5(   "   �� $��Elemento��6+   $��15(�6=   $��Stretch=�6K   $��Stretch=�6g   .��5)   &   �� $��Stretch=�61   $ Vertical=�6M   .+�5*   *   �� $��Nombre��60   $
��Left=�6A   $	��Top=�6\   �� 5+   *   -   5        $��	txtnombre��5+   �   $
��Left=�62    �� TextWrapping$
 Wrap=�6M   $�� ��6a   $	��Top=�6i   $	��274��6�   6�   �� 5,   *   $��Descripcion��60   $
��Left=�6F   $	��Top=�6b   �� 5.   *   -   5        $��txtdescripcion��5.   �   $
��Left=�62   $
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��274��6�   $	��360��6�   6�   �� 5/   *   $ 
Horizontal=�65   $��1q�6N   .+�50   .   �� 
��� � �$��4q�6H   $ 8��6\   $  4q�6m   ._�51   2   �� -   5        $ btn_saveData��51   9   $��Guardar��6O   
������ 
������ 
�������$	��120��6�   $
��Left=�6�   $	��Top=�6�   53   3   54   /   �� 55   .   
��� ���$��4q�6I   $ 8��6]   $  4q�6n   ._�56   2   �� -   5        $	��Acl��56   �   $��
Actualizar��69   
������ 
������ $	��110��6�   $
��Left=�6�   $	��Top=�6�   ${�False��6�   6�   57   /   58   +   59   '   5:   #   5;      5<      5=      � 5>      $��5q�6!   $ 
Horizontal=�6,   
������ $��Stretch=�6_   .+�5?      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataTable��5?   $      
IsReadOnly$
 True��67   $	��805��6I   $	��510��6U   	   AutoGenerateColumns$	 False��6f   ���#f9f9f9
   SelectionMode$
 Extended=�5@         AlternatingRowBackground �#fff �� AlternationCount$ 2��5A   9      SelectionUnit$ FullRow=�5B         GridLinesVisibility$
 None=�62   $��Visible=�6M   $��Visible=�6�      RowHeaderStyle 5C      �� 5D   "      ColumnHeaderStyle 5F      �� 5G   "      Columns 5J      4  .System.Windows.Controls.DataGridTemplateColumn  5K   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 69      Header$ Seleccionar��6D      CellTemplate 5L   &   �� 5M   *   .R�5N   .   �� .+�5O   2   �� 
���   �$	��0.2q�6M   ._�5P   6   �� ���#AFD3E2$ 4��6R   ���#146C94$��1q�6y   $  2q�6�   $��6q�6�   $��42��6�   ._�5Q   :   �� -	   5        
������ 
������ $��Center=�5Q   t   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *idcategoria+.��5R   >   �� $ 
Horizontal=�6I   $��Center=�6b   $��Center=�6   .+�5S   B   �� $,��&/views/administrador/vadmin/edit-1.png��6H   $��Center=�6x   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5T   ?   5U   ;   5V   7   5W   3   5X   /   5Y   +   5[   #     5]   "   $ Nombre��6:   $	 250 6J    5^   &   �� 5_   *   .R�5`   .   �� 
���   �$	��0.3q�6I   ._�5a   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�    �� TextAlignment$ Center=�6�   ��6�   �� *nombre+6�   5b   /   5c   +   5e   #     5g   "   $ Descripcion��6:   $	 250 6O    5h   &   �� 5i   *   .R�5j   .   �� 
���   �$	��0.3q�6I   ._�5k   2   �� $
��Wrap=�6<   $��Center=�6P   $��Stretch=�6k   $
��Bold"�6�   $ Center=�6�   ��6�   �� *descripcion+6�   5l   /   5m   +   5o   #     5q   "   $ 90 69   $ Eliminar��6D    5r   &   �� 5s   *   .R�5t   .   �� 
���   �$	��0.2q�6I   ._�5u   2   �� ���#D25380$ 4��6N   ���#D21312$��1q�6u   $  2q�6�   $��6q�6�   $��42��6�   ._�5v   6   �� -
   5        
������ 
������ $��Center=�5v   p   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *idcategoria+.��5w   :   �� $ 
Horizontal=�6E   $��Center=�6^   $��Center=�6{   .+�5x   >   �� $,��&/views/administrador/vadmin/delete.png��6D   $��Center=�6t   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5y   ;   5z   7   5{   3   5|   /   5}   +   5   #   5�      5�      5�      5�      5�      5�      5�      