   M S B A M L   `   `   `  ����I  EWPFMiroProgram, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPFMiroProgramWPFMiroProgram  5      #    WPFMiroProgram.CreateMiroView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WPFMiroProgram     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��40* �6   �� 5      $��* �6   �� 5      $
��100* �6   .+�5   
   �� $
��Left=�6   $��
29,119,0,0q�6/   $
��Wrap=�6C   $��
행 수 : ��6W   $	��Top=�6e   �� 5   
   $
��Left=�6   $��23��6-   $��
73,118,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6�   $	��120��6�   ��6a   �� *Row+ �� Mode$ TwoWay=�6�   �� 5   
   $
��Left=�6   $��
29,147,0,0q�6/   $
��Wrap=�6C   $��
열 수 : ��6W   $	��Top=�6e   �� 5   
   $
��Left=�6   $��23��6-   $��
73,147,0,0q�69   $
 Wrap=�6M   $	��Top=�6�   $	��120��6�   ��6a   �� *Col+$ TwoWay=�6�   �� 5   
   $
��Left=�6   $��
15,194,0,0q�6/   $
��Wrap=�6C   $��파일이름 : ��6W   $	��Top=�6f   �� 5   
   $
��Left=�6   $��23��6-   $��
74,194,0,0q�69   $
 Wrap=�6M   $	��Top=�6�   $	��134��6�   ��6a   �� *
Filename+$ TwoWay=�6�   �� 5   
   $��미로생성��6   ���	#FFF5C8C8���	#ff646464$��46,232,107,205q�6N   $��0��6f   ��5      �� *CreateCommand+�� 5   
   $��미로저장��6   ���	#FFF5C8C8���	#ff646464$��136,232,16,205q�6N   $��0��6f   ��5      �� *SaveCommand+� 5   
   $��2��6   .+�5      �� $��18(�6F   ���	#ff646464$��64,0,318,467q�6k   ��6   �� *Msg+ �� StringFormat$ 상태 : {0}��6k   �� 5      $
��Left=�6   $	��595��60   $��0,33,0,0q�6<   .+�5      �� $��11(�6!   ��6/   �� *
Mazefile+5      5      5       5!      