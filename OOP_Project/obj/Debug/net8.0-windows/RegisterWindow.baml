   M S B A M L   `   `   `  ����F  BOOP_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OOP_ProjectOOP_Project  5   	        OOP_Project.RegisterWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OOP_Project     5   	     � Title$  Реєстрація��5   	   $	��600��6   $	��400��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K    � 	Resources 5	         RoundedTextBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 ��Name��%�  &	        �� 5   
   " ��6,   .�5      ��  � ��
 �����6+   �� 5       � ��$ 8q�6(   �� 5       � ��
 �����6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 35��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 10��6!   #��z��5   !   #��z��5   !   #��z��5   !   ._�5      �� $	 PART_ContentHost��6+   $��0q�6E   5      5      5      5      5      .��5       � ���	#FFDDDDFF.+�5!   
   �� $��Center=�6   $��Center=�60   $	��250��6M   .+�5#      �� $��Реєстрація��6   $��24(�6*   $
��Bold"�68   $��Georgia)�6J   $��0,0,0,20q�5$      $��Center=�6*   �� 5'      $��
Логін��6   $
��Bold"�6%   $��10,0,0,5q�67   $��Georgia)�6I   �� 5(      -   5        
 ��Name$
 LoginTextBox��5(      #��[  6,   $��Georgia)�6Y   �� 5)      -   5         ��Name$ 
LoginError��5)      $�� ��6,   
���  ��$��Georgia)�6E   $y�	Collapsed=�5*      $��0,3,0,0q�6/   $��Center=�6@   �� 5-      $��Пароль��6   $
��Bold"�6&   $��	10,10,0,5q�68   $��Georgia)�6K   �� 5.      $ 10��6   
�������$��1q�6:   
�������$��0,0,0,0q�6a   ._�5/      G� -   5         G�Name$ PasswordBox��5/      
������ $��0q�6L   $��35��6`   $��8q�6l   $��Georgia)�6x   50      �� 51      -   5        $ PasswordError��51      $.��(Пароль надто короткий��6/   
���  ��$��Georgia)�6]   $y�	Collapsed=�52      $��0,3,0,0q�6/   $��Center=�6@   �� 55      $#��Дата народження��6   $
��Bold"�6/   $��	10,10,0,5q�6A   $��Georgia)�6T   �� 56      -   5        $
 BirthDateTextBox��56      #��[  60   $��Georgia)�6]   �� 57      -   5        $ BirthDateError��57      $,��&Невірний формат дати��60   
���  ��$��Georgia)�6]   $y�	Collapsed=�58      $��0,3,0,0q�6/   $��Center=�6@   �� 5;      $!��Номер телефону��6   $
��Bold"�6.   $��	10,10,0,5q�6@   $��Georgia)�6S   �� 5<      -   5        $
 PhoneNumberTextBox��5<      #��[  62   $��Georgia)�6_   �� 5=      -   5        $ 
PhoneError��5=      $A��;Невірний формат номеру телефону��6,   
���  ��$��Georgia)�6d   $y�	Collapsed=�5>      $��0,3,0,0q�6/   $��Center=�6@   �� 5A      -	   5         ��Name$ RegisterButton��5A      $$��Зареєструватися��6-   $��40��6G   $��0,30,0,0q�6S   $��Georgia)�6e   $��1q�5B      ���	#FFCCCCCC
������� 5C      ��%_   '��       �� 5D      " ��6   .�5E      ��  �@��CornerRadius$ 10��69   5F      5G      5H      �� 5K      -
   5        $#��Є акаунт? Увійти��5K      
�������$��Center=�6B   $��0,10,0,0q�6_    � Cursor$
 Hand��5L      $��	Underline{�6L   $��Georgia)�6h   5N      5O      5P      