   M S B A M L   `   `   `  ����R  NManagement Bootcamp WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Management_Bootcamp_WPFManagement_Bootcamp_WPF  5   	   (    "Management_Bootcamp_WPF.MenuMentor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Management_Bootcamp_WPF     5   	   -   5          � Title$  Menu Mentor��5   	   $��614.337��6   $��733.456��6.   .��5
      � $��0,0,0,-1q�6   .+�5   
   �� -   5         ��Name$ 
tabControl��5      $
��Left=�6)   $	��513��6D   $��	10,56,0,0q�6Q   $	��Top=�6d   $	��706��6|   .@�5      �� $��Manage Lesson��6   .��5      � ���	#FFE5E5E5$��0,0,0,-4q�6.   .+�5      �� -   5         ��Name$ labelSearchLesson��5      $��Search Category��67   $
��Left=�6Q   $��	206,4,0,0q�6l   $	��Top=�6   $��97��6�   �� 5      -   5         ��Name$ comboBoxSearchLesson��5      $
��Left=�6=   $��	308,8,0,0q�6X   $	��Top=�6k   $	��111��6�   .@�5      �� $��Id��6'   $
��Left=�64   $��92��6O   �� 5      $
��Name��6'   $
��Left=�66   $��92��6Q   �� 5      $��Level��6'   $
��Left=�67   $��92��6R   �� 5      $��
Department��6'   $
��Left=�6<   $��92��6W   5      �� 5      -   5         ��Name$ textBoxSearchLesson��5      $
��Left=�6;   $��23��6V   $��	424,7,0,0q�6b    �� TextWrapping$
 Wrap=�6u   $	��Top=�6�   $	��169��6�   �� 5      -   5         ��Name$ buttonSearchLesson��5      $��Search��69   $
��Left=�6J   $��
611,10,0,0q�6e   $	��Top=�6y   $��75��6�   6�   �� 5      -   5        $ labelIdLesson��5      $��Id��63   $
��Left=�6@   $��	22,16,0,0q�6[   $	��Top=�6n   �� 5      -   5         ��Name$ textBlockIdLesson��5       $
��Left=�6;   $��
140,20,0,0q�6V   $
��Wrap=�6j   $�� ��6~   $	��Top=�6�   �� 5      -	   5        $ labelNameLesson��5      $
��Name��65   $
��Left=�6D   $��	22,47,0,0q�6_   $	��Top=�6r   �� 5      -
   5        $ textBoxNameLesson��5      $
��Left=�69   $��23��6�   $��	97,50,0,0q�6�   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��403��6�   �� 5      -   5        $ buttonInsertLesson��5      $��Insert��69   $
��Left=�6J   $��118,156,0,0q�6e   $	��Top=�6z   $��75��6�   6�   �� 5      -   5        $ buttonUpdateLesson��5      $��Update��69   $
��Left=�6J   $��239,156,0,0q�6e   $	��Top=�6z   $��75��6�   6�   �� 5      -   5        $ buttonDeleteLesson��5      $��Delete��69   $
��Left=�6J   $��353,156,0,0q�6e   $	��Top=�6z   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGridLesson��5      $
��Left=�67   	   
IsReadOnly	 . $��
22,195,0,0q�6d   $	��Top=�6x   $	��653��6�   $	��208��6�   
   AutoGenerateColumns
 .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Id��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$ Id�6[     5!      $
 Name��61    6?   �� $
 Name�6_     5"      $ Level��61    6@   �� $ level�6a     5#      $ 
Department��61    6E   �� $ Departements.Name�6r   5%      �� 5&      -   5        $ labelLevelLesson��5&      $��Level��66   $
��Left=�6F   $��	22,80,0,0q�6a   $	��Top=�6t   �� 5'      -   5        $ comboBoxLevelLesson��5'      $
��Left=�6<   $��	98,84,0,0q�6W   $	��Top=�6j   $��95��6�   .@�5(      �� $��Pre Requisite��6'   $
��Left=�6?   $��92��6Z   �� 5)      $��Fundamental��6'   $
��Left=�6=   $��92��6X   �� 5*      $��Begginer��6'   $
��Left=�6:   $��92��6U   �� 5+      $��Intermediate��6'   $
��Left=�6>   $��92��6Y   5,      �� 5-      -   5        $ labelDepartmentLesson��5-      $��
Department��6;   $
��Left=�6Q   $��
22,113,0,0q�6l   $	��Top=�6�   �� 5.      -   5        $ comboBoxDepartmentLesson��5.       �� DisplayMemberPath$
 Name��6l    �� SelectedValuePath$ Id��6�   $
��Left=�6�   $��
98,117,0,0q�6�   $	��Top=�6�   $	��124��6�   ��6A   �� $ getDepartment�6�   5/      50      51      �� 52   
   -   5        $ labelMentorWelcome��52      $��Welcome Mentor��6,   $
��Left=�6E   $��
422,10,0,0q�6`   $	��Top=�6t   $	��105��6�   �� 53   
   -   5        $ labelMentor��53      $
��....��6%   $
��Left=�64   $��
532,10,0,0q�6O   $	��Top=�6c   $	��165��6{   54      55      