   M S B A M L   `   `   `  ����D  @EFTeszt01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	   ,    &EFTeszt01.RecepciosIdopontKezeloWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:EFTeszt01     5   	   -   5          � Title$  IdopontKezelo��5   	   $	��326��6   $	��407��6,    � Icon$ HOSPICON.png��5	        � WindowStartupLocation$ CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y   .��5
      � .+�5   
   �� -   5         ��Name$ label��5      $��Orvos:��6   $
��Left=�60   $��27��6K   $��	23,10,0,0q�6W   $	��Top=�6j   $��48��6�   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��31��6@   $��	76,10,0,0q�6L   $	��Top=�6_   $	��117��6w   ��6�   �� *	Orvosok+��5      �� 5      .R�5      �� ��6   �� *Name+5      5      (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $
��Left=�6)   $��28��6D   $��	77,55,0,0q�6P   $	��Top=�6c   $	��117��6{      Text$ Dátum��6�   �� 5   
   -   5        $ label1��5      $��Dátum��6    $
��Left=�60   $��28��6K   $��	24,55,0,0q�6W   $	��Top=�6j   $��48��6�   �� 5   
   -   5         ��Name$ button��5      $��Időpontok listázása��6!   $
��Left=�6?   $��28��6Z   $��
254,53,0,0q�6f   $	��Top=�6z   $	��123��6�   6�   �� 5   
   -   5        	 ��Name$	 listBox��5      $
��Left=�6#   $	��171��6>   $��	23,88,0,0q�6K   $	��Top=�6^   $	��376��6v   ��6�   �� *IdopontAdatok+��5      �� 5      .R�5      ]� .+�5      �� 
 �� ContentStringFormat$
 Idő: {0:HH:mm}��6:   ��6    �� *Datum+6:   �� 5      ��6    �� *Nev+�� 5      ��6    �� *TAJ+5       5!      5#      �� 5$   
   -   5        $ button1��5$      $'��!Időpont foglalás / módosítás��6"   $
��Left=�6I   $��25��6d   $��220,260,0,0q�6p   $	��Top=�6�   $	��169��6�   6�   �� 5%   
   -	   5        $ visszaButton��5%      $��Vissza��6'   $
��Left=�68   $��23��6S   $��
24,264,0,0q�6_   $	��Top=�6s   $��75��6�   6�   5'      5(      