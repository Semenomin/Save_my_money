   M S B A M L   `   `   `  ����F  BSaveMyMoney, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SaveMyMoneySaveMyMoney  5   	       SaveMyMoney.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SaveMyMoney     5   	   -   5          �Name$  
LogIn_form��5   	   $	��500��5      $	��750��6'   $	��750��63   $	��500��6B   $��20q�6R   $	��750��6_   $	��500��6n   $��Center=�6~   $��Center=�6�    � WindowStyle$
 None=�6�    � 
ResizeMode$ NoResize=�6�    � WindowStartupLocation$ CenterScreen=�6�    � Icon$ Resorses/Logo.png��6-  .��5	      � -   5         �Name$ 	Main_grid��5	         MainBlue#���   6    � RowDefinitions 5
   
   �� 5      $	��498 �6    � ColumnDefinitions 5   
   �� 5      $	��742 �6   .+�5   
   � -   5        $ Login_Button_Grid��5      $��292,377,293,65q�6*   .+�5      �� -   5         ��Name$ Log_In_Button��5      	 �� RadiusY$	 28��6/   
 �� RadiusX$
 28��6<    � Cursor$
 Hand��6I     
SecondBlue#���  6W   �� 5      -   5         ��Name$ LogIn_button_text��5       	 LogIn#���  6/   $��Center=�6Q   $��Center=�6s   $��Disabled=�6�   $��22(�6�   $
��Bold"�6�   #���   6  $
 Hand��6)  ��6�   Z� 6)  5      � 5   
   -   5        $ Password_Grid��5      $��237,311,237,131q�6&   .+�5      �� -   5        $ Text_box_password��5      $	 28��63   $
 28��6@   $
 Hand��6M   #���  6[   �� 5      -   5         ��Name$ Text_box_password_text��5      $
��Left=�66   $��56��6Q    �� TextWrapping$
 Wrap=�6]     Password#���  6q   $	��Top=�6�   $	��268��6�   $��20(�6�   $��20,0,0,0q�6�    �� SelectionBrush �	#FFB2B2B2$��Center=�6   #���   6B  ��6�   Z� ��6�   Z� 6�  5      � 5   
   -	   5        $ 
Login_grid��5      $��237,244,237,198q�6#   .+�5      �� -
   5        $ Text_box_Login��5      $	 28��60   $
 28��6=   $
 Hand��6J   #���  6X   �� 5      -   5        $ Text_box_Login_text��5      $
 Wrap=�63    	 Login#���  6G    �	#B2BFBFBF$��Center=�6�   $��20,0,0,0q�6�   $��20(�6�   #���   6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6  ��6f   Z� ��6|   Z� 6\  5      � 5   
   -   5        $ Button_close_grid��5      $
��Left=�6*   $��46��6E   $	��Top=�6Q   $��48��6i   $��
670,26,0,0q�6t   .+�5      A� -   5         A�Name$ Button_close��5      #���  6,   $
 Hand��6P   5      � 5   
   -   5        $ Button_svernut_grid��5      $
��Left=�6,   $��46��6G   $	��Top=�6S   $��48��6k   $��
610,26,0,0q�6v   .+�5       A� -   5        $ Button_svernut��5       #���  6.   $
 Hand��6R   5!      �� 5"   
   -   5        $ 
Main_label��5"      $��SAVE MY MONEY��6$   $��0,94,0,0q�6<   $	��Top=�6N   $��Segoe UI Light)�6f   $��Center=�6�   $��Center=�6�   #���  6�   $��80(�6�   $	��128��6   $
��Bold"�6   J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$      -   5        Forever_shadow��   Opacity$	 0.5Q�5$   ;   5&      �� 5'   
   -   5          Registration#���  5'      $
��Left=�69   $��306,443,0,16q�6T   $
 Hand��6j   $��22(�6x   $��Segoe UI Semibold)�6�   #���  6�   6�   � 5(   
   -   5        $ 	Lang_grid��5(      $
��Left=�6"   $��77��6=   $��625,400,0,0q�6I   $	��Top=�6^   $	��108��6v   $
 Hand��6�   .+�5)      �� #���  6   $��23��6<   $��Bottom=�6H   $	��108��6c   �� 5*      #���  6   $��23��6<   $��Center=�6H   $	��108��6c   �� 5+      #���  6   $��23��6<   $	��Top=�6H   $	��108��6`   $��Center=�6l   �� 5,        Language#���  6   $��39��69   $	��108��6E   #���   6g   $��Center=�6�   $��Center=�6�   ��6Q   Z� 6�   5-      5.      5/      