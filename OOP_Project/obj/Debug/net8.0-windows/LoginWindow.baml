   M S B A M L   `   `   `  ����F  BOOP_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OOP_ProjectOOP_Project  5   	       OOP_Project.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OOP_Project     5   	     � Title$  Вхід��5   	   $	��500��6   $	��400��6#    � 
ResizeMode$ NoResize=�6/    � WindowStartupLocation$ CenterScreen=�6E    � 	Resources 5
         RoundedTextBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 ��Name��%�  &	        �� 5   
   " ��6,   .�5      ��  � ��
 �����6+   �� 5       � ��$ 8q�6(   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 35��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 10��6!   #��z��5      #��z��5      #��z��5      ._�5      �� $	 PART_ContentHost��6+   $��0q�6E   5      5      5      5      5      .��5       � ���	#FFDDDDFF.+�5!   
   �� $��Center=�6   $��Center=�60   $	��250��6M   $��0,0,0,0q�6Y   .+�5#      �� $��
Логін��6   $
��Bold"�6%   $��	10,10,0,5q�67   $��Georgia)�6J   �� 5$      -   5        
 ��Name$
 LoginTextBox��5$      $��35��6,   #��[  68   $��Georgia)�6e   �� 5&      $��Пароль��6   $
��Bold"�6&   $��	10,10,0,3q�68   $��Georgia)�6K   �� 5'      $ 10��6   
�������$��1q�6:   
�������$��0,5,0,5q�6a   ._�5(      G� -   5         G�Name$ PasswordBox��5(      
������ $��0q�6L   $��35��6`   $��8q�6l   $��Georgia)�6x   5)      �� 5+      -   5         ��Name$ 	ErrorText��5+      $5��/Невірний логін або пароль��6+   
���  ��$��Georgia)�6]   $��Center=�5,      $y�Hidden=�6)   $��0,5,0,0q�6=   �� 5.      -   5        $��Увійти��5.      $��40��6&   $��0,20,0,0q�62   $��Georgia)�6E   $��1q�5/      ���	#FFCCCCCC
������� 50      ��%_   '��       �� 51      " ��6   .�52      ��  �@��CornerRadius$ 10��69   53      54      55      �� 57      -   5        $"��Увійти як гість��57      
�������$��Center=�6A   $��0,10,0,0q�6^    � Cursor$
 Hand��58      $��	Underline{�6   $��Georgia)�66   6K   �� 5:      -   5        $&�� Новий користувач?��5:      $��Center=�61   $��0,20,0,0q�6N   $
 Hand��5;      $��Georgia)�6A   
�������$��	Underline{�5<      5>      5?      5@      