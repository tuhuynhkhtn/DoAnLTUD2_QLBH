   M S B A M L   `   `   `  ����=  9V1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:V1.UltilitiesV1.Ultilities  5      #clr-namespace:V1.ModelV1.Model  5          V1.UC.UCLeft   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )uclr-namespace:V1.Ultilities     5      (localclr-namespace:V1.Model     5        � 	Resources  5
         CatTemplate �� DataType   V1.Model.Category �� RelativeSource �� Path
 � Tag  ProTemplate   V1.Model.NhaSanXuat  CatTemplate1 �� CornerRadius �� StringFormat  ProTemplate1��%j  &	        &	 A    &	 H    &	 B    �� 5   
   "  6+   .R�5      � $��Center=�6   $
��Left=�63   .+�5      �� $��1��6   $��3q�6)   $
��Left=�6P   $��Center=�6k   $!��u:Commands.ButtonLeftCatCmd��6�   $	��150��6  ��64   �� *	CatName+��6�   ��  �� *Self+$	 Tag� 6�   �� *CatID+6  5      5      �� 5   
   "  6+   .R�5      � .+�5      �� $��1��6   $��3q�6)   $��Right=�6V   $!��u:Commands.ButtonLeftProCmd��6s   ��64   �� *TenNhaSanXuat+��6�   ��  �� *Self+$	 Tag� 6�   �� *IDNhaSanXuat+5      5      �� 5   
   "  6,   .R�5      �� 
����+��$��1q�6.   $��3q�6B   $ 3��6M   ._�5      �� $	��150��6   $��3q�6(   ��5      `� 5      $	 {0}��6'   .1�5      �� $ CatName�6&   5      5      5      5       �� 5!   
   "  6-   .R�5"      �� 
����+��$��1q�6.   $��3q�6B   $ 3��6M   ._�5#      �� $	��150��6   $��3q�6(   ��5$      `� 5%      $	 {0}��6'   .1�5&      �� $ TenNhaSanXuat�6&   5'      5)      5*      5+      5,      .��5-      � 
����iA� � RowDefinitions 5.   
   �� 5/      $��30 �6   �� 50      �� 51      $��30 �6   �� 52      .+�54   
   �� $��0��6   $
��Bold"�6!   $
��Left=�63   $��Center=�6N   Loại sản phẩm6{   �� 55   
   -   5        $��lvCat��55       $��1��6   #��[  6P   ��6-   �� *
Categories+6P   �� 57   
   $��2��6   $
��Bold"�6!   $
��Left=�63   $��Center=�6N   Nhà sản xuất6z   �� 58   
   -   5        $��lvPro��58       $��3��6   #��[ 6R   ��6-   �� *NhanSanXuats+6R   59      5:      