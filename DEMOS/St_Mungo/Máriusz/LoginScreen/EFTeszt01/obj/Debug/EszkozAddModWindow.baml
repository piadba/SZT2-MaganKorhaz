   M S B A M L   `   `   `  ����D  @EFTeszt01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	   "    EFTeszt01.EszkozAddModWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EFTeszt01     5   	     � Title$  Szerkesztés��5   	   $��183.577��6   $��300.898��6.    � Icon$ HOSPICON.png��6>    � 
ResizeMode$ NoResize=�6R    � WindowStartupLocation$ CenterScreen=�6h    +� FocusedElement 5	   	   ��  �� ElementName$ textBox��.��5
      � .+�5   
   �� -   5         ��Name$ saveBtn��5      $��Mentés��6"   $
��Left=�63   $��
24,109,0,0q�6N   $	��Top=�6b   $	��118��6z    �� 	IsDefault . 6�   �� 5   
   -   5        $ 	cancelBtn��5      $��Mégsem��6$   $
��Left=�65   $��155,109,0,0q�6P   $	��Top=�6e   $	��124��6}   6�   �� 5   
   -   5         ��Name$ label��5      $��Megnevezés: ��6   $
��Left=�66   $��	24,10,0,0q�6Q   $	��Top=�6d   $��89��6|   �� 5   
   -   5        	 ��Name$	 textBox��5      $
��Left=�6#   $��19��6>   $��
118,14,0,0q�6J   
 �� TextWrapping$

 Wrap=�6^   $	��Top=�6�   $	��149��6�   ��6r   ��  �� Path$ 
Megnevezes� �� UpdateSourceTrigger$ Explicit=�6�   �� 5   
   -   5         ��Name$ checkBox��5      $�� ��6%   $
��Left=�60   $��
118,47,0,0q�6K   $	��Top=�6_   $	��149��6w   $��16��6�    d� 	IsChecked 6�   �� $ Statusz�$ Explicit=��� 5   
   -   5        $ 
labelCombo��5      $��	Csoport: ��6$   $
��Left=�68   $��	24,72,0,0q�6S   $	��Top=�6f   $��89��6~   �� 5   
   -   5         ��Name$ comboCsoport��5   ]   $
��Left=�6s   $��
118,76,0,0q�6�   $	��Top=�6�   $	��149��6�    �� SelectedValue 6   �� $ Eszkoz_FejID�$ Explicit=�6�   �� 5   
   -   5        $ 
labelIgeny��5      $��Igényelt: ��6$   $
��Left=�69   $��	24,41,0,0q�6T   $	��Top=�6g   $��89��6   5      5      