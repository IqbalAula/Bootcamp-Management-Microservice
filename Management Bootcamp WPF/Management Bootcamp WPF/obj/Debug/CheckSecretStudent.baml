   M S B A M L   `   `   `  ����R  NManagement Bootcamp WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Management_Bootcamp_WPFManagement_Bootcamp_WPF  5   	   0    *Management_Bootcamp_WPF.CheckSecretStudent   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Management_Bootcamp_WPF     5   	     � Title$  Check Security��5   	    � WindowStartupLocation$ CenterScreen=�6    $��Center=�6E   $	��250��6b   $	��400��6o   .��5	      � .+�5
   
   �� -   5         ��Name$ labelQuestion��5
      $��Secret Question��6'   $
��Left=�6A   $��	24,23,0,0q�6\   $	��Top=�6o   �� 5   
   -   5         ��Name$ comboBoxQuestion��5      $
��Left=�6-   $��	24,58,0,0q�6H   $	��Top=�6[   $	��344��6s   .@�5      �� $2��,What was your favorite sport in high school?��6   $
��Left=�6R   $	��344��6m   �� 5      $=��7What is the name of the High School you graduated from?��6   $
��Left=�6]   $	��344��6x   �� 5      $��What is your pet's name?��6   $
��Left=�6>   $	��344��6Y   �� 5      $3��-Where were you when you had your first kiss? ��6   $
��Left=�6S   $	��344��6n   �� 5      $,��&What is your grandmother's first name?��6   $
��Left=�6L   $	��344��6g   5      �� 5   
   -   5        $ labelAnswer��5      $��Secret Answer Question��6%   $
��Left=�6F   $��	24,92,0,0q�6a   $	��Top=�6t   �� 5   
   -   5         ��Name$ textBoxAnswer��5      $
��Left=�6)   $��23��6D   $��
24,126,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��344��6�   �� 5   
   -   5         ��Name$ 
buttonNext��5      $
��Next��6%   $
��Left=�64   $��293,175,0,0q�6O   $	��Top=�6d   $��75��6|   6�   5      5      