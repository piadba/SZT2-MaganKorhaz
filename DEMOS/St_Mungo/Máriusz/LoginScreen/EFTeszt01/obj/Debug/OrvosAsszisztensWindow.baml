   M S B A M L   `   `   `  ����D  @EFTeszt01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	   %clr-namespace:EFTeszt01	EFTeszt01  5   	   &     EFTeszt01.OrvosAsszisztensWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +currentclr-namespace:EFTeszt01     5   	   )localclr-namespace:EFTeszt01     5   	     � Title$+  %Orvos és Asszisztens kezelőfelület��5	   	    � Icon$ HOSPICON.png��64   $	��380��6H   $	��700��6U    � WindowStartupLocation$ CenterScreen=�6a    � 
ResizeMode$ NoResize=�6�   .��5
      �  � 	Resources 5   
   !  EFTeszt01.BetegNevKonverter   BetegNevKonverter   EFTeszt01.KezelesKonverter  KezelesKonverter'  !EFTeszt01.GyogyszerIDNevKonverter  GyogyszerIDNevKonverter��%W   &	        &	      &	 &       5      6(     5      6'     5      6.   5       � ColumnDefinitions 5   
   �� 5      $
��106* �6   �� 5      $	��67* �6   .+�5   
   �� -   5         ��Name$ label��5      $��St. Mungo Magánkórház��6   $
��Left=�6?   $��
270,10,0,0q�6Z   $	��Top=�6n   $��14(�6�   $
��Bold"�6�   $��2��6�   �� 5   
   -   5        $ label1��5      $��Bejelentkezve mint:��6    $
��Left=�6>   $��	21,41,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5        $ aktOrvosLbl��5      $
��Left=�6D   $��
152,41,0,0q�6_   $	��Top=�6s   $��26��6�   $	��272��6�   ��6%   �� *
Orvos.Name+6�   �� 5   
   -   5         ��Name$ 
felhModBtn��5      $%��Felhasználói adatmódosítás��6%   $
��Left=�6J   $��	84,26,0,0q�6e   $	��Top=�6x   $	��157��6�   $��1��6�   �� 5   
   -   5        $ label3��5      $��Betegek listája:��6    $
��Left=�6;   $��	21,67,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $ label3_Copy��5      $$��Kiválasztott beteg adatlapja:��6%   $
��Left=�6M   $��
248,67,0,0q�6h   $	��Top=�6|   �� 5   
   -   5         ��Name$ betegLst��5      $
��Left=�6r   $	��140��6�   $��	21,98,0,0q�6�   $	��Top=�6�   $	��189��6�   ��6$   �� *	Betegek+	 �� 	Converter#	 [  6�   �� 5   
   -   5        $ 
adatlapLst��5      $
��Left=�6   $	��140��6�   $��
248,98,0,0q�6�   $	��Top=�6�   $	��417��6�   $��2��6�   ��6&   �� *SelectedKorlapTetel+#	 [ 6�   �� 5   
   -	   5        $ 
ujBetegBtn��5      $��Új beteg felvétele��6%   $
��Left=�6B   $��
21,248,0,0q�6]   $	��Top=�6q   $	��112��6�   6�   �� 5   
   -
   5        $ kezelesFelBtn��5      $��Kezelés felvétele��6(   $
��Left=�6D   $��248,248,0,0q�6_   $	��Top=�6t   $	��110��6�   6�   �� 5   
   -   5        $ korlapModBtn��5      $��Kórlap módosítása��6'   $
��Left=�6C   $��248,284,0,0q�6^   $	��Top=�6s   $	��110��6�   6�   �� 5   
   -   5        $ lazlapFelBtn��5      $��Lázlap felvétele��6'   $
��Left=�6B   $��
21,284,0,0q�6]   $	��Top=�6q   $	��112��6�   6�   �� 5    
   -   5        $ igenyBTN��5       $��Igényfelvétel��6#   $��1��6;   $
��Left=�6K   $��	84,52,0,0q�6f   $	��Top=�6y   $	��157��6�   6�   �� 5!   
   -   5        $ kijelentkezesBTN��5!      $��Kijelentkezés��6+   $
��Left=�6C   $��	16,10,0,0q�6^   $	��Top=�6q   $��94��6�   6�   �� 5"   
   -   5        $ 
gyogyadBTN��5"      $��Gyógyszer hozzáadása��6%   $
��Left=�6D   $��110,253,0,0q�6_   $	��Top=�6t   $	��130��6�   $��1��6�   5#      5$      