   M S B A M L   `   `   `  ����F  BTaxi_Manage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Taxi_ManageTaxi_Manage  5   	       Taxi_Manage.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Taxi_Manage     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ add_rank��5
      $��Add to rank��6#   $
��Left=�69   $��	68,93,0,0q�6T   $	��Top=�6g   6   �� 5   
   -   5         ��Name$ taxi_number��5      $
��Left=�6'   $��	13,55,0,0q�6B    �� TextWrapping$
 Wrap=�6U   $��Taxi Number��6i   $	��Top=�6|   $	��176��6�   6�   �� 5   
   -   5         ��Name$ rank_box��5      $	��NaN��6O   $��13,158,611,31q�6\   $	��NaN��6s   �� 5   
   -   5        $ 	leaveRank��5      $��
Leave Rank��6$   $
��Left=�69   $��325,133,0,0q�6T   $	��Top=�6i   6�   �� 5   
   -   5        $ destination��5      $
��Left=�6'   $��
297,55,0,0q�6B   $
 Wrap=�6V   $��Destination��6j   $	��Top=�6}   $	��120��6�   �� 5   
   -   5        $
 fare��5      $
��Left=�6    $��
297,95,0,0q�6;   $
 Wrap=�6O   $
��Fare��6c   $	��Top=�6o   $	��120��6�   �� 5   
   -   5        $ taxis��5      $��549,55,10,167q�6L   �� 5   
   -   5        $ dropTaxiNum��5      $
��Left=�6'   $��297,249,0,0q�6B   $
 Wrap=�6W   $��Taxi number��6k   $	��Top=�6~   $	��120��6�   �� 5   
   -	   5        $ dropFare��5      $��	Drop Fare��6#   $
��Left=�67   $��329,300,0,0q�6R   $	��Top=�6g   6   �� 5   
   $��Taxi Joins Rank��6   $
��Left=�6*   $��	57,15,0,0q�6E   $	��Top=�6X   �� 5   
   $��Taxi Leaves Rank��6   $
��Left=�6+   $��
308,15,0,0q�6F   $	��Top=�6Z   �� 5   
   $��Taxi Drops Fare��6   $
��Left=�6*   $��	308,0,0,0q�6E   $��Center=�6X   �� 5   
   $��All taxis status��6   $
��Left=�6+   $��
627,15,0,0q�6F   $	��Top=�6Z   �� 5   
   -
   5        $ refresh��5      $��Refresh��6"   $
��Left=�64   $��648,310,0,0q�6O   $	��Top=�6d    J� RenderTransformOrigin$ 0.51,-0.413&�6�   �� 5   
   $��Currently in Rank��6   $
��Left=�6,   $��
51,125,0,0q�6G   $	��Top=�6[   �� 5   
   -   5        $ transaction��5      $��Transaction Log��6&   $
��Left=�6@   $��626,359,0,0q�6[   $	��Top=�6p   6�   5      5      