   M S B A M L   `   `   `  ����K  GTurismoSV_client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana<TurismoSV_client.views.administrador.vadmin.controlesVentana  5      U    OTurismoSV_client.views.administrador.vadmin.controlesVentana.adicionalesControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \localJclr-namespace:TurismoSV_client.views.administrador.vadmin.controlesVentana     5      .��5	      � .+�5
   
   � $	��0.5q�6   .+�5      ]� $��Stretch=�6   $	��610��66   $
��1105��6C   
������ .+�5      �� $	��Top=�6     �� Padding$  5q�6.   $��1q�6:   ._�5      �  � Orientation$ Vertical=�6!   .+�5      �� $��Adicionales��6    $
��Left=�66   $��24(�6Q   $	��Top=�6_   $
��Bold"�6w   5      �� 5       �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Buscar��6$   67   �� 5      -   5         ��Name$ txt_itemSearch��5   &   $��15,0,0,0q�6>   $��Stretch=�6P   $	��520��6n   $	��720��6}   6�   �� 5      -   5         ��Name$ btn_searchElement��5   %   $��5,0,0,0q�6@   $��90��6Q   .��5   "   �� $ 
Horizontal=�6-   .+�5   &   �� $,��&/views/administrador/vadmin/search.png��6,   $��32��6\   $��32��6h   $��UniformToFill=�6s   5   #   5      �� 5      $��50,0,0,0q�6)   .+�5   "   �� 
�������
���   �$��2q�6T   $  2q�6h    �� CornerRadius$ 4��6t   ._�5   &   �� -   5        $ 
btn_report��5   -   
������ 
������ $��Generar Reporte��6t   $��32��6�   5   '   5   #   5      5       5!      5"      �� 5$      $��Bottom=�6   
������ $ 
Horizontal=�6N   $��Stretch=�6g   $	��5,5q�6�   .+�5%      �� $��Stretch=�6"   
�������.+�5&      �� $  4q�6!   $��Stretch=�6-   $��Stretch=�6I   ._�5'      � $ Vertical=�6(   $��Stretch=�6?   $��Stretch=�6[   .+�5(   "   �� $��	Adicional��6+   $��15(�6>   $��Stretch=�6L   $��Stretch=�6h   .��5)   &   �� $��Stretch=�61   $ Vertical=�6M   .+�5*   *   �� $��Nombre��60   $
��Left=�6A   $	��Top=�6]   �� 5+   *   -   5        $��	txtnombre��5+   �   $
��Left=�62    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��254��6�   6�   �� 5,   *   $��Descripcion��60   $
��Left=�6F   $	��Top=�6b   �� 5-   *   -   5        $��txtdescripcion��5-   �   $
��Left=�62   $
 Wrap=�6M   $�� ��6a   $	��Top=�6i   $	��254��6�   $	��290��6�   6�   �� 5.   *   $��Precio��60   $
��Left=�6A   $	��Top=�6]   �� 50   *   -   5        $��	txtprecio��50   �   $
��Left=�62   $
 Wrap=�6N   $�� ��6b   $��Center=�6j   $	��254��6�   $��32��6�   6�   �� 51   *   $ 
Horizontal=�65   $��1q�6N   .+�52   .   �� 
��� � �$��4q�6H   $ 8��6\   $  4q�6m   ._�53   2   �� -   5        $ btn_saveData��53   9   $��Guardar��6O   
������ 
������ 
�������$	��120��6�   $
��Left=�6�   $	��Top=�6�   55   3   56   /   �� 57   .   
��� ���$��4q�6I   $ 8��6]   $  4q�6n   ._�58   2   �� -   5        $	��Acl��58   �   $��
Actualizar��69   
������ 
������ $	��110��6�   $
��Left=�6�   $	��Top=�6�   ${�False��6�   6�   59   /   5:   +   5;   '   5<   #   5=      5>      5?      � 5@      $��5q�6!   $ 
Horizontal=�6,   
������ $��Stretch=�6_   .+�5A      &   System.Windows.Controls.DataGrid  -	   5        $��DG��5A   #      
IsReadOnly$
 True��6.   $	��804��6@   $	��500��6L   $	��510��6Y      AutoGenerateColumns$ False��6j   ���#f9f9f9	   SelectionMode$	 Extended=�5B      
   AlternatingRowBackground
 �#fff �� AlternationCount$ 2��5C   9      SelectionUnit$ FullRow=�5D         GridLinesVisibility$
 None=�62   $��Visible=�6M   $��Visible=�6�      Columns 5E      4  .System.Windows.Controls.DataGridTemplateColumn  5F   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 69      Header$ Seleccionar��6D      CellTemplate 5G   &   �� 5H   *   .R�5I   .   �� .+�5J   2   �� 
���   �$	��0.2q�6M   ._�5K   6   �� ���#AFD3E2$ 4��6R   ���#146C94$��1q�6y   $  2q�6�   $��6q�6�   $��42��6�   ._�5L   :   �� -
   5        
������ 
������ $��Center=�5L   t   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *idadicional+.��5M   >   �� $ 
Horizontal=�6I   $��Center=�6b   $��Center=�6   .+�5N   B   �� $,��&/views/administrador/vadmin/edit-1.png��6H   $��Center=�6x   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5O   ?   5P   ;   5Q   7   5R   3   5S   /   5T   +   5V   #     5W   "   $ Nombre��6:   $	 250 6J    5X   &   �� 5Y   *   .R�5Z   .   �� 
���   �$	��0.3q�6I   ._�5[   2   �� $��WrapWithOverflow=�6<    �� Padding$ 5q�6\   $��Center=�6h   $��Stretch=�6�   $
��Bold"�6�   ��6�   �� *nombre+6�   5\   /   5]   +   5_   #     5a   "   $ Descripcion��6:   $	 350 6O    5b   &   �� 5c   *   .R�5d   .   �� 
���   �$	��0.3q�6I   ._�5e   2   �� $
��Wrap=�6<   $��Center=�6P   $ 5q�6k   $��Stretch=�6w   $
��Bold"�6�   ��6�   �� *descripcion+6�   5f   /   5g   +   5i   #     5k   "   $ Precio��6:   $ 90 6J    5l   &   �� 5m   *   .R�5n   .   �� 
���   �$	��0.3q�6I   ._�5o   2   �� $
��Wrap=�6<    �� TextAlignment$ Center=�6P   $��Center=�6g   $��Stretch=�6�   $
��Bold"�6�   ��6�   �� *precio+6�   5p   /   5q   +   5s   #     5u   "   $ 90 69   $ Eliminar��6D    5v   &   �� 5w   *   .R�5x   .   �� 
���   �$	��0.2q�6I   ._�5y   2   �� ���#D25380$ 4��6N   ���#D21312$��1q�6u   $  2q�6�   $��6q�6�   $��42��6�   ._�5z   6   �� -   5        
������ 
������ $��Center=�5z   p   
�������$��SemiBold"�6�   $��Center=�6�   ��6�   �� *idadicional+.��5{   :   �� $ 
Horizontal=�6E   $��Center=�6^   $��Center=�6{   .+�5|   >   �� $,��&/views/administrador/vadmin/delete.png��6D   $��Center=�6t   $��20��6�   $��20��6�   $��0,0,5,0q�6�   $��Center=�6�   5}   ;   5~   7   5   3   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      