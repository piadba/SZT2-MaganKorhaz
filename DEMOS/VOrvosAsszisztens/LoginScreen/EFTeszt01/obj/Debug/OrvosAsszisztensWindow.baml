   M S B A M L   `   `   `  ����D  @EFTeszt01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	   %clr-namespace:EFTeszt01	EFTeszt01  5   	   &     EFTeszt01.OrvosAsszisztensWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +currentclr-namespace:EFTeszt01     5   	   )localclr-namespace:EFTeszt01     5   	     � Title$  OrvosAsszisztensWindow��5	   	   $	��350��6(   $	��500��65    � WindowStartupLocation$ CenterScreen=�6A   .��5
      �  � 	Resources 5   
   !  EFTeszt01.BetegNevKonverter   BetegNevKonverter   EFTeszt01.KezelesKonverter  KezelesKonverter��%:   &	        &	        5      6(     5      6'   5      .+�5   
   �� -   5         ��Name$ label��5      $��St. Mungo Magánkórház��6   $
��Left=�6?   $��
165,10,0,0q�6Z   $	��Top=�6n   $��14(�6�   $
��Bold"�6�   �� 5   
   -   5        $ label1��5      $��Bejelentkezve mint:��6    $
��Left=�6>   $��	21,41,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5        $ aktOrvosLbl��5      $
��Left=�6H   $��
152,41,0,0q�6c   $	��Top=�6w   $��26��6�   $��69��6�   ��6%   �� *Orvos.UserName+6�   �� 5   
   -   5         ��Name$ 
felhModBtn��5      $%��Felhasználói adatmódosítás��6%   $
��Left=�6J   $��
284,44,0,0q�6e   $	��Top=�6y   $	��157��6�   6�   �� 5   
   -   5        $ label3��5      $��Betegek listája:��6    $
��Left=�6;   $��	21,67,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $ label3_Copy��5      $$��Kiválasztott beteg adatlapja:��6%   $
��Left=�6M   $��
248,67,0,0q�6h   $	��Top=�6|   �� 5   
   -   5         ��Name$ betegLst��5      $
��Left=�6r   $	��140��6�   $��	21,98,0,0q�6�   $	��Top=�6�   $	��189��6�   ��6$   �� *	Betegek+ �� 	Converter# [  6�   �� 5   
   -   5        $ 
adatlapLst��5      $
��Left=�6   $	��140��6�   $��
248,98,0,0q�6�   $	��Top=�6�   $	��212��6�   ��6&   �� *SelectedKorlapTetel+# [ 6�   �� 5   
   -	   5        $ 
ujBetegBtn��5      $��Új beteg felvétele��6%   $
��Left=�6B   $��
21,243,0,0q�6]   $	��Top=�6q   $	��112��6�   6�   �� 5   
   -
   5        $ kezelesFelBtn��5      $��Kezelés felvétele��6(   $
��Left=�6D   $��248,243,0,0q�6_   $	��Top=�6t   $��97��6�   �� 5   
   -   5        $ korlapModBtn��5      $��Kórlap módosítása��6'   $
��Left=�6C   $��350,243,0,0q�6^   $	��Top=�6s   $	��110��6�   �� 5   
   -   5        $ lazlapFelBtn��5      $��Lázlap felvétele��6'   $
��Left=�6B   $��248,274,0,0q�6]   $	��Top=�6r   $��97��6�   �� 5   
   -   5        $ lazlapModBtn��5      $��Lázlap módosítása��6'   $
��Left=�6C   $��350,274,0,0q�6^   $	��Top=�6s   $	��110��6�   5      5      