   M S B A M L   `   `   `  ����C  ?St_Mungo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	       EFTeszt01.IgenyMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EFTeszt01     5   	     � Title$  Eszköz igénylés��5   	   $	��430��6!   $	��516��6.    � Icon$ HOSPICON.png��6:    � WindowStartupLocation$ CenterScreen=�6N   .��5	      �  � 	Resources 5
   
   )  #EFTeszt01.EszkozBackgroundConverter   EszkozBackgroundConverter��%   &	          5      6.   5      .+�5   
   �� -   5         ��Name$ listBoxEszkozGroupIgeny��5      $
��Left=�63   $	��327��6N   $	��Top=�6[   $	��240��6s   $��0,58,0,0q�6   ��5      �� 5      .R�5      �� $	��200��6!   ��6-   ��  �� Path$ Statusz� �� 	Converter# [  .+�5      �� ��6    �� $ 
Megnevezes�5      5      5      �� 5   
   -   5         ��Name$ label��5      $��Eszköz típusok��6   $
��Left=�68   $��26��6S   $	��Top=�6_   $	��240��6w   $��Center=�6�   �� 5   
   -   5         ��Name$ newEszkozGroup��5      $��
Új igény��6)   $
��Left=�6<   $��21��6W   $��0,32,0,0q�6c   $	��Top=�6u   $��77��6�   6�   �� 5   
   -   5        $ listBoxEszkozIgeny��5      $
��Left=�6.   $	��327��6I   $��
251,58,0,0q�6V   $	��Top=�6j   $	��240��6�   ��5      �� 5      .R�5      �� $	��200��6{   ��6!   �� $ Statusz�# [  .+�5      �� ��6    �� $ 
Megnevezes�6F   5      5      5       �� 5!   
   -   5        $ label1��5!      $��
Eszközök��6    $
��Left=�63   $��26��6N   $��	251,2,0,0q�6Z   $	��Top=�6m   $	��233��6�   $��Center=�6�   �� 5"   
   -   5        $ 	newEszkoz��5"      $��Új eszköz igény��6$   $
��Left=�6>   $��21��6Y   $��
251,33,0,0q�6e   $	��Top=�6y   $��87��6�   6�   �� 5#   
   -   5        $ groupDelete��5#      $��Igény törlés��6&   $
��Left=�6=   $��21��6X   $��	82,32,0,0q�6d   $	��Top=�6w   $��73��6�   6�   �� 5$   
   -   5        $ eszkozDelete��5$      $��Igény törlés��6'   $
��Left=�6>   $��21��6Y   $��
343,33,0,0q�6e   $	��Top=�6y   $��66��6�   6�   �� 5%   
   
���   �$��1,0,0,0q�6%   $
��Left=�6?   $	��395��6Z   $��	245,0,0,0q�6g   $	��Top=�6z   $��6��6�   �� 5&   
   -	   5        $ GroupMod��5&      $��Módosítás��6#   $
��Left=�67   $��21��6R   $��
160,32,0,0q�6^   $	��Top=�6r   $��80��6�   6�   �� 5'   
   -
   5        $ igenyEszkozmod��5'      $��Módosítás��6)   $
��Left=�6=   $��21��6X   $��
414,33,0,0q�6d   $	��Top=�6x   $��80��6�   6�   5(      5)      