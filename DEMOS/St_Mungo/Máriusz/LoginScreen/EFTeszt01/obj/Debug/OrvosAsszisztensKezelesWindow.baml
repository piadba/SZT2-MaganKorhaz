   M S B A M L   `   `   `  ����D  @EFTeszt01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:EFTeszt01	EFTeszt01  5   	   -    'EFTeszt01.OrvosAsszisztensKezelesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:EFTeszt01     5   	     � Title$)  #Kezelés hozzáadása/módosítása��5   	    � Icon$ HOSPICON.png��6/   $	��320��6C   $	��360��6P    � WindowStartupLocation$ CenterScreen=�6\    � 
ResizeMode$ NoResize=�6�   .��5      � .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ datumDP��5      {�.  $
��Left=�68   $��
138,10,0,0q�6S   $	��Top=�6g   $	��186��6   �� 5   
   -   5         ��Name$ orvosTB��5      {�.  $
��Left=�65   $��23��6P   $��
138,45,0,0q�6\    �� TextWrapping$
 Wrap=�6p   $��TextBox��6�   $	��Top=�6�   $	��186��6�   �� 5	   
   -   5        $ kezlesTB��5	      $
��Left=�6$   $	��166��6?   $��	90,76,0,0q�6L   $
 Wrap=�6_   $��TextBox��6s   $	��Top=�6�   $	��234��6�   �� 5
   
   $��Kezelés dátuma:��6   $
��Left=�6*   $	��Top=�6E   $��	27,10,0,0q�6]   $	��106��6p   �� 5   
   $��Kezelő orvos:��6   $
��Left=�6(   $	��Top=�6C   $��	27,41,0,0q�6[   $	��106��6n   �� 5   
   $��	Kezelés:��6   $
��Left=�6#   $	��Top=�6>   $��	27,72,0,0q�6V   $	��106��6i   �� 5   
   -   5        $��Mentés��5      $
��Left=�6"   $��159,260,0,0q�6=   $	��Top=�6R   $��75��6j    J� RenderTransformOrigin$ 0.498,4.507&�6�   �� 5   
   -   5        $��Mégse��5      $
��Left=�6!   $��249,260,0,0q�6<   $	��Top=�6Q   $��75��6i   6t   �� 5   
   $��Button��6   $
��Left=�6"   $��464,159,-187,0q�6=   $	��Top=�6U   $��75��6m   5      5      