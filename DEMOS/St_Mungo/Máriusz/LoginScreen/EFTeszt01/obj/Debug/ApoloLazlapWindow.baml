   M S B A M L   `   `   `  ����D  @EFTeszt01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	   !    EFTeszt01.ApoloLazlapWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EFTeszt01     5   	   -   5        $��553.753��5   E   $��451.068��6V     � WindowStartupLocation$  CenterScreen=�6f    � 
ResizeMode$ NoResize=�6�    � Icon$ HOSPICON.png��5	   	    � Title 5   	   ��  �� Path$ LazlapID� �� StringFormat$ Lapszám: {0}��.��5
      � .+�5   
   �� -   5         ��Name$ label��5      $��Kiíró orvos:��6   $
��Left=�66   $��	10,25,0,0q�6Q   $	��Top=�6d   $	��102��6|   �� 5   
   -   5         ��Name$ textBox��5      $��Center=�6#   {�.  $
��Left=�6X   $��26��6s   $��
199,25,0,0q�6    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��184��6�   ��6�   �� $ GetorvosNev�	 �� Mode$	 OneWay=�6�   �� 5   
   -   5        $ 
label_Copy��5      $��Kezelendő beteg:��6$   $
��Left=�6?   $��
10,215,0,0q�6Z   $	��Top=�6n   $	��102��6�   �� 5   
   -   5        $ textBox_Copy��5   5   $��Center=�6   {�.  $
��Left=�6^   $��26��6y   $��199,215,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��184��6�   
 J� RenderTransformOrigin$
 0.531,2.025&�6�   ��6�   �� *GetBetegNev+$	 OneWay=�6�   �� 5   
   -   5        $ label1��5      $��Orvos megjegyzés: ��6    $
��Left=�6=   $��	10,56,0,0q�6X   $	��Top=�6k   $	��114��6�   �� 5   
   -   5        $ textBox1��5      $
��Left=�6$   $	��123��6?   $��	10,87,0,0q�6L   $
 Wrap=�6_   {�.  $	��Top=�6�   $	��184��6�   ��6s   �� $ OrvosMegjegyzes�6�   �� 5   
   -   5        $ label2��5      $��Felírt gyógyszerek��6    $
��Left=�6=   $��
10,253,0,0q�6X   $	��Top=�6l   $	��126��6�   �� 5   
   -	   5         ��Name$ listboxGyogyszerek��5      $
��Left=�6.   $	��179��6I   $��199,246,0,0q�6V   $	��Top=�6k   $	��184��6�   ��5      �� 5      .R�5      �� .+�5      �� ��6    �� $ getGyogyszernev��� 5      ��6    �� $ getMennyiseg�5      5      5      �� 5   
   -
   5        $ textboxApoloMegjegyzes��5      $
��Left=�62   $	��123��6M   $��199,87,-20,0q�6Z   $
 Wrap=�6p   $	��Top=�6�   $	��184��6�   ��6�   �� *ApoloMegjegyzes+ �� UpdateSourceTrigger$ Explicit=�6�   �� 5   
   -   5        $ label1_Copy��5      $��Ápolói megjegyzés: ��6%   $
��Left=�6C   $��
269,56,0,0q�6^   $	��Top=�6r   $	��114��6�   �� 5   
   -   5         ��Name$ moreGyogyszer��5      $��+��6(   $
��Left=�64   $��25��6O   $��388,246,0,0q�6[   $	��Top=�6p   $��27��6�   6�   �� 5   
   -   5        $ lessGyogyszer��5      $��-��6(   $
��Left=�64   $��25��6O   $��388,276,0,0q�6[   $	��Top=�6p   $��27��6�   6�   �� 5    
   -   5         ��Name$ lezartCheckbox��5    Y   $��Center=�6   $��Center=�67   $��Lezárt?��6q   $
��Left=�6�   $��199,430,0,0q�6�   $	��Top=�6�   $��28��6�   $��89��6�   �� 5!   
   -   5        $ button��5!      $��Mentés��6!   $
��Left=�62   $��
26,469,0,0q�6M   $	��Top=�6a   $	��168��6y   $��23��6�   6�   �� 5"   
   -   5        $ button1��5"      $��Mégsem��6"   $
��Left=�63   $��231,469,0,0q�6N   $	��Top=�6c   $	��152��6{   6�   5%      5&      