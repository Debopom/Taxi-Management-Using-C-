   M S B A M L   `   `   `  ����F  BTaxi_Manage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Taxi_ManageTaxi_Manage  5   	       Taxi_Manage.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Taxi_Manage     5   	     � Title$  Window1��5   	   $	��450��6   $	��800��6&   .��5	      � -   5         �Name$ tn_label��5	      .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ transaction��5
      $��347,54,0,101q�6S   �� 5   
   -   5         ��Name$ search��5      $��Search��6!   $
��Left=�62   $��129,114,0,0q�6M   $	��Top=�6b   6z   �� 5   
   -   5         ��Name$ 
taxiNumber��5      $
��Left=�6&   $��	89,78,0,0q�6A    �� TextWrapping$
 Wrap=�6T   $��Enter taxi number��6h   $	��Top=�6�   $	��120��6�   �� 5   
   $��Company total Income��6   $
��Left=�6/   $��
83,307,0,0q�6J   $	��Top=�6^   �� 5   
   -   5         ��Name$ companyTotal��5      $��Label��6&   $
��Left=�66   $��129,344,0,0q�6Q   $	��Top=�6f   �� 5   
   $��Transaction Logs��6   $
��Left=�6+   $��
477,10,0,0q�6F   $	��Top=�6Z   $��20(�6r   �� 5   
   $��Search with taxi number��6   $
��Left=�62   $��	80,29,0,0q�6M   $	��Top=�6`   �� 5   
   $��Taxi number��6   $
��Left=�6&   $��
58,204,0,0q�6A   $	��Top=�6U   �� 5   
   $��Total paid to taxi��6   $
��Left=�6-   $��
34,246,0,0q�6H   $	��Top=�6\   �� 5   
   -   5        $ 	tn_label1��5      $�� ��6#   $
��Left=�6.   $��	209,0,0,0q�6I   $��Center=�6\   �� 5   
   -   5        $ tp_label��5      $�� ��6"   $
��Left=�6-   $��209,246,0,0q�6H   $	��Top=�6]    J� RenderTransformOrigin$ 0.185,0.555&�6u   �� 5   
   -   5        $ refresh��5      $��Refresh��6"   $
��Left=�64   $��555,362,0,0q�6O   $	��Top=�6d   6|   5      5      