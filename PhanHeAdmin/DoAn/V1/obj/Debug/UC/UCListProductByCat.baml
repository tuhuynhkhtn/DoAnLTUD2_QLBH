   M S B A M L   `   `   `  ����=  9V1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:V1.PageV1.Page  5      -clr-namespace:V1.UltilitiesV1.Ultilities  5          V1.UC.UCListProductByCat   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #lclr-namespace:V1.Page     5      )uclr-namespace:V1.Ultilities     5        � 	Resources  5
      $   V1.Ultilities.ImgPathConverter   ipc   V1.Page.PageListProduct  dbForWd  ProTemplate �� CornerRadius � RowDefinitions �� Path �� 	Converter �� StringFormat � ColumnDefinitions
 � Tag �� RelativeSource��%1  &	        &	      &	 &     7     5   
   6     5   
   6   �� 5   
   .R�5      � 
�������$��2q�6+   $��Center=�66   .+�5      �� $��1q�6   $	��222��6-   $	��330��69   
�����F�$ 3��6^   ._�5      � $��Center=�6    5      �� 5      $	��200 �6,   �� 5      �� 5      �� 5      �� 5      $��30 �6,   �� 5      $��10 �6,   .+�5      �� $��0��6    $	��200��6-   $	��200��69   ��6F   �� $ ProID�8   �� 5      $��1��6$   $��
ExtraBlack"�6O   
���   �$
��Wrap=�6z   ��61   �� $ ProName�6z   �� 5      $��2��6$   $
��Bold"�6c   
���  ����61   �� $ Price�$ {0:N}��6u   �� 5      $��3��6$   $��
ExtraBlack"�6O   
���   �$
��Wrap=�6z   ��61   �� $ TinyDes�6z   � 5      $��4��6   $��Center=�6,   $��Stretch=�6I    5      �� 5    "   �� 5!   "   .+�5#      �� $��0��6%   $��70��65   $��25��6@   $ ��u:Commands.ButtonDetailCmd��6b    6L   �� *ProID+��6�   ��  �� *Self+$	 Tag�.��6�   Chi tiết6�   �� 5$      $��1��6%   $��70��65   $��25��6@   $!��u:Commands.ButtonBuyListCmd��6b   $	��Mua��6�    6L   �� *ProID+��6�   ��  �� *Self+$	 Tag�6�   5%      5&      5'      5(      5)      5*      .��5+      �  5,   
   �� 5-      $��30 �6   �� 5.      �� 5/      $��30 �6   .+�51   
   �� $��0��6   
����iA�$
��Bold"�64   .��6F   Danh sách sản phẩm6]   � 52   
   $��1��6   .+�53      �� -   5        $��lvPro��53      #��[ 6$   ��54      �� 55      .R�56      A� 	 A� Columns$	 4��6&   57      59      5:      �� 5;   
   $��2��6   $��30��6   $��0 2 5 0q�6*   $��Right=�6;   ._�5<      � .+�5=      �� -   5        $��btnPrev��5=      $��20��6(   $��0 0 10 0q�63    6[   �� *CatID+.��6q   <6w   �� 5>      -   5        $��tbPage��5>      $��Center=�6*   $��5q�6E   ��5?      `� 5@      $ 	{0} / {1}��6'   .1�5A      �� 
 �� Source#
 [ 6&   $ CurPage�6H   �� 5B      #
 [ 6&   $ 	TotalPage�6H   5C      5E      �� 5F      -   5        $��btnNext��5F      $��20��6(   $��	 10 0 0 0q�63    6\   �� *	CurPage+.��6t   >6z   5G      5H      5I      5J      