   M S B A M L   `   `   `  ����D  @EFTeszt01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	        EFTeszt01.GazdAlkGyogyszer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EFTeszt01     5   	   -   5          � Title$  Gyógyszer szerkesztés��5   	   $��381.728��6'   $��319.934��68    � Icon$ HOSPICON.png��6H    � 
ResizeMode$ NoResize=�6\    � WindowStartupLocation$ CenterScreen=�6r    +� FocusedElement 5	   	   ��  �� ElementName$ tbMegnevezes��.��5
      � -   5         �Name$ gyogyszerGrid��5
        � ShowGridLines .  � RowDefinitions 5   
   �� 5      $
��138* �6   �� 5      $
��215* �6   .+�5   
   �� -   5        	 ��Name$	 label��5      $��Megnevezés:*��6   $
��Left=�66   $��	10,10,0,0q�6Q   $	��Top=�6d   $	��120��6|   $��26��6�   �� 5   
   -   5        $	 
label_Copy��5      $��Hatóanyag(ok):* ��6$   $
��Left=�6?   $��	10,41,0,0q�6Z   $	��Top=�6m   $	��120��6�   $��26��6�   �� 5   
   -   5        $	 labelMennyiseg��5      $��Aktuális mennyiség:*��6(   $
��Left=�6G   $��15,31.548,0,0q�6b   $	��Top=�6y   $	��120��6�   $��26��6�   $��1��6�   �� 5   
   -   5        $	 labelRendeles��5      $��
Rendelés:��6'   $
��Left=�6;   $��187,31.548,0,0q�6V   $	��Top=�6n   $��65��6�   $��26��6�   $��1��6�   �� 5   
   -   5        $	 label_Copy3��5      $��
Egység: *��6%   $
��Left=�69   $��37,62.548,0,0q�6T   $	��Top=�6k   $	��120��6�   $��26��6�   $��1��6�   �� 5   
   -   5        $	 label_Copy4��5      $��Egységmennyiség: *��6%   $
��Left=�6B   $��37,93.548,0,0q�6]   $	��Top=�6t   $	��120��6�   $��26��6�   $��1��6�   �� 5   
   -	   5        $	 label_Copy5��5      $��Tartalék:*��6%   $
��Left=�6:   $��37,124.548,0,0q�6U   $	��Top=�6m   $	��120��6�   $��26��6�   $��1��6�   �� 5   
   -
   5        
 ��Name$
 tbMegnevezes��5      $
��Left=�6(   $��26��6C   $��
157,10,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6�   $	��147��6�   $��Center=�6�   ��6w   ��  �� Path$ 
Megnevezes� �� UpdateSourceTrigger$ Explicit=�6�   �� 5   
   -   5        $
 tbHatoanyag��5      $
��Left=�6'   $��86��6B   $��
157,42,0,0q�6N   $
 Wrap=�6b   $	��Top=�6�   $	��147��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6v   �� $ 	Hatoanyag�$ Explicit=�6�   �� 5   
   -   5        $
 tbMennyiseg��5      $
��Left=�6'   $��26��6B   $��140,31.548,0,0q�6N   $
 Wrap=�6f   $	��Top=�6�   $��47��6�   $��Center=�6�   $��1��6  ��6z   �� $ 	Mennyiseg�$ Explicit=�6  �� 5   
   -   5        $
 
tbRendeles��5      $
��Left=�6&   $��26��6A   $��257,31.548,0,0q�6M   $
 Wrap=�6e   $��0��6y   $	��Top=�6�   $��47��6�   $��Center=�6�   $��1��6�   �� 5   
   -   5        $
 tbEgyseg��5      $
��Left=�6$   $��26��6?   $��157,62.548,0,0q�6K   $
 Wrap=�6c   $	��Top=�6�   $	��147��6�   $��Center=�6�   $��1��6�   ��6w   �� $ Egyseg�$ Explicit=�6�   �� 5   
   -   5        $
 tbEgyegmenny��5      $
��Left=�6(   $��26��6C   $��157,93.548,0,0q�6O   $
 Wrap=�6g   $	��Top=�6�   $	��147��6�   $��Center=�6�   $��1��6!  ��6{   �� $ EgysegMennyiseg�$ Explicit=�6!  �� 5   
   -   5        $
 tbThreshold��5      $
��Left=�6'   $��26��6B   $��157,124.548,0,0q�6N   $
 Wrap=�6g   $	��Top=�6�   $	��147��6�   $��Center=�6�   $��1��6  ��6{   �� $ 	Threshold�$ Explicit=�6  �� 5   
   -   5         ��Name$ 
buttonSave��5       �� 	IsDefault . $��Mentés��66   $
��Left=�6G   $��28��6b   $��10,168.548,0,0q�6n   $	��Top=�6�   $	��147��6�   $��1��6�   �� 5    
   -   5        $ buttonCancel��5       $��Mégsem��6'   $
��Left=�68   $��28��6S   $��162,168.548,0,0q�6_   $	��Top=�6x   $	��142��6�   $��1��6�   5#      5$      