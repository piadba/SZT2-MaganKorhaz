   M S B A M L   `   `   `  ����C  ?St_Mungo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	   ,    &EFTeszt01.OrvosAsszisztensLazlapWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EFTeszt01     5   	     � Title$  Lázlap kezelése��5   	   $	��470��6!    � Icon$ HOSPICON.png��6.   $	��300��6B   .��5	      �  � 	Resources 5
   
   '  !EFTeszt01.GyogyszerIDNevKonverter   GyogyszerIDNevKonverter��%   &	          5      6,   5      .+�5      �� -   5         ��Name$ orvosTB��5      $
��Left=�6'   $	��136��6B   $��	91,10,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $	��Top=�6�   $	��191��6�   ��6v   �� *BetegLazlapja.OrvosMegjegyzes+6�   �� 5   
   -   5         ��Name$ label��5      $��Lázlap:��6   $
��Left=�61   $��	10,10,0,0q�6L   $	��Top=�6_   $��68��6w   �� 5   
   -   5        $ label1��5      $��Ápoló megjegyzése:��6    $
��Left=�6=   $��
10,288,0,0q�6X   $	��Top=�6l   �� 5   
   -   5        $ noverLBL��5      $
��Left=�6T   $��
26,319,0,0q�6o   $	��Top=�6�   $��64��6�   $	��242��6�   ��6"   �� *BetegLazlapja.ApoloMegjegyzes+6�   �� 5   
   -   5         ��Name$ 	mentesBTN��5      $��Mentés��6$   $
��Left=�65   $��
10,404,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ megseBTN��5      $��Mégse��6#   $
��Left=�63   $��207,404,0,0q�6N   $	��Top=�6c   $��75��6{    J� RenderTransformOrigin$ 0.402,-1.283&�6�   �� 5   
   -   5         ��Name$ listBox��5      $
��Left=�6�   $	��109��6�   $��
91,174,0,0q�6�   $	��Top=�6�   $	��191��6�   ��6#   �� *BetegGyogyszerei+	 �� 	Converter#	 [  5      �� 5   
   -   5        $ label2��5      $��Gyógyszerek:��6    $
��Left=�67   $��
10,174,0,0q�6R   $	��Top=�6f   $��81��6~   �� 5   
   -	   5        $ gyogyBTN��5      $��+��6#   $
��Left=�6/   $��
61,205,0,0q�6J   $	��Top=�6^   $��17��6v   6�   �� 5   
   -
   5        $ gyogyDelBTN��5      $��-��6&   $
��Left=�62   $��
61,230,0,0q�6M   $	��Top=�6a   $��17��6y   6�   5      5      