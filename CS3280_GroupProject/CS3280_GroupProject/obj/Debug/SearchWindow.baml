   M S B A M L   `   `   `  ����N  JCS3280_GroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CS3280_GroupProjectCS3280_GroupProject  5   	   &     CS3280_GroupProject.SearchWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CS3280_GroupProject     5   	   -   5          �Name$  SearchWindow1��5   	    � Title$ Search Invoices��5   	   $��504.011��6!   $��643.105��62    � 
ResizeMode$ NoResize=�6B    � WindowStartupLocation$ CenterScreen=�6X   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5      $ White��6   � 5      $ 	#FFD4D4D4��6   $
 0.15Q�61   5      .+�5   
   �� -   5         ��Name$ 	Btn_Clear��5      $��Clear��6$   $
��Left=�64   $��
397,20,0,0q�6O   $	��Top=�6c   $��95��6{   $��22��6�   ��5      
� 5      .��5      � $ Black��6#   $ 1Q�61   � 5      $ White��6#   $	 0.5Q�61   5      5      �� 5   
   -   5        $ 
Btn_Select��5      $��Select Invoice��6%   $
��Left=�6>   $��
497,20,0,0q�6Y   $	��Top=�6m   $��83��6�   $��22��6�   {�.  ��5      
� 5      .��5      � $ Black��6#   $ 1Q�61   � 5      $ White��6#   $	 0.5Q�61   5      5       �� 5!   
   -   5        	 ��Name$	 Filter_Number��5!      $
��Left=�6*   $��	64,20,0,0q�6E   $	��Top=�6X   $	��106��6p   ��5"      
� 5#      .��5$      � $ 	#FFF0F0F0��6#   � 5%      $ White��6#   $	 0.5Q�61   5&      5(      �� 5)   
   $��Invoice Number��6   $
��Left=�6)   $��22��6D   $��81,1,0,0q�6P   $	��Top=�6b   $��68��6z   $��8(�6�   �� 5*   
   -   5        $	 Filter_Date��5*      $
��Left=�6(   $��
175,20,0,0q�6C   $	��Top=�6W   $	��106��6o   �� 5+   
   $��Invoice Date��6   $
��Left=�6'   $��22��6B   $��	199,1,0,0q�6N   $	��Top=�6a   $��67��6y   $��8(�6�   �� 5,   
   -   5        $	 Filter_Total��5,      $
��Left=�6)   $��
286,20,0,0q�6D   $	��Top=�6X   $	��106��6p   �� 5-   
   $��Invoice Total��6   $
��Left=�6(   $��22��6C   $��	313,1,0,0q�6O   $	��Top=�6b   $��68��6z   $��8(�6�   &   System.Windows.Controls.DataGrid  5.   
   -   5        
  Name$
 Invoice_Data��5.      $
��Left=�6)   $	��418��6D   $��	10,47,0,0q�6Q   $	��Top=�6d   $	��617��6|   ��5/      �� 50      $ 0.5,1&�6&   $ 0.5,0&�67   .��51      � $ Black��6#   $ 1Q�61   � 52      $ White��6#   � 53      $ 	#FF2F2F2F��6#   $
 0.85Q�65   54      56      58      59      