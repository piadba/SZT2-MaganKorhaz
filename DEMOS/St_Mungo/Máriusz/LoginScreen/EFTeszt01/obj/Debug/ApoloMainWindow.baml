   M S B A M L   `   `   `  ����D  @EFTeszt01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	       EFTeszt01.ApoloMainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EFTeszt01     5   	   -   5        $	��648��5   %   $��686.287��62     � WindowStartupLocation$  CenterScreen=�6Y    � Icon$ HOSPICON.png��6�    � 
ResizeMode$ NoResize=�6�    � Title 6	   ��  �� Path$
 Name� � 	Resources 5	      "  EFTeszt01.ApoloWindowOrvosID   ApoloWindowOrvosID+  %EFTeszt01.ApoloWindowConverterBetegID  ApoloWindowConverterBetegID:  4EFTeszt01.ApoloWindowLazlapListboxisEnabledConverter . *ApoloWindowLazlapListboxisEnabledConverter��%W   &	        &	      &	 &       5
   
   6#     5   
   6,     5   
   6;   5      .��5      �  5   
   *  $EFTeszt01.ApoloMuszakButtonConverter  ApoloMuszakButtonConverter��%t   &	        &	      &	 &     &	 9       5      6'     5      60     5      6/     5      6?   5      .+�5   
   �� -   5         ��Name$ button��5      $
��Left=�6z   $��	10,10,0,0q�6�   $	��Top=�6�   $	��123��6�   ��6!   �� $ PeopleID� �� 	Converter# [ 6�   �� 5   
   -   5         ��Name$ LazlapListBox��5      $
��Left=�6)   $	��572��6D   $��	10,35,0,0q�6Q   $	��Top=�6d   $	��272��6|   {�6�   �� $ PeopleID�# [ 	 � ToolTip	 6�   �� $ MegjegyzesTT���5      �� 5      .R�5      �� $��0,0,0,5q�6   
����� �._�5      �� $	��255��6%   .+�5      �� 
 �� ContentStringFormat$
 Lapszám: {0}��6F   ��6$   �� $ LazlapID�6F   �� 5      $
 Kiíró Orvos: {0}��6s   ��6$   �� $ OrvosID�# [  6s   �� 5      $
 Kezelendő Beteg: {0}��6}   ��6$   �� $ BetegID�# [ 6}   5      5      5       5"      �� 5#   
   -   5        $ LazlapReszlet��5#      $��Lázlap részletek��6(   $
��Left=�6C   $��
138,10,0,0q�6^   $	��Top=�6r   $	��144��6�   6�   �� 5$   
   -   5        $ 	LazlapAdd��5$      $��Lázlap felvétel >>��6$   $
��Left=�6A   $��23��6\   $��
287,35,0,0q�6h   $	��Top=�6|   $	��101��6�   6�   �� 5%   
   -   5        $ LazlapRemove��5%      $��<< Lázlap leadás��6'   $
��Left=�6H   $��23��6c   $��
287,63,0,0q�6o   $	��Top=�6�   $	��101��6�   6�   �� 5&   
   -   5        $ SelfLazlapListBox��5&      $
��Left=�6-   $	��572��6H   $��
393,35,0,0q�6U   $	��Top=�6i   $	��272��6�   ��5'      �� 5(      .R�5)      �� $��0,0,0,5q�6   
����� �._�5*      �� $	��255��6%   .+�5+      �� $
 Lapszám: {0}��6A   ��6$   �� *
LazlapID+6A   �� 5,      $
 Kiíró Orvos: {0}��6o   ��6$   �� *	OrvosID+# [  6o   �� 5-      $
 Kezelendő Beteg: {0}��6x   ��6$   �� *	BetegID+# [ 6x   5.      5/      50      52      �� 53   
   -   5        $ buttonLazlapMod��53      $��Lázlap módosítás��6*   $
��Left=�6E   $��20��6`   $��
393,10,0,0q�6l   $	��Top=�6�   $	��149��6�   6�   �� 54   
   -	   5        $ 	btnLogout��54      $��Kijelentkezés��6$   $
��Left=�6<   $��
556,10,0,0q�6W   $	��Top=�6k   $	��109��6�   6�   55      56      