   M S B A M L   `   `   `  ����J  FConvert3DObject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Convert3DObject.ViewsConvert3DObject.Views  5   	   (    "Convert3DObject.Views._3DModelView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X THelixToolkit.Wpf, Version=2.24.0.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d(helixhttp://helix-toolkit.org/wpf  5   	   /local#clr-namespace:Convert3DObject.Views  5   	   -   5          � Title$  _3DModelView��5	   	   $	��550��6   $	��800��6+    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	   .��5      ��  �� CornerRadius$ 10��6   ��5   
   �� 5       �� ImageSource$ /Images/background.jpg��6   ._�5   
   �� $ 10��6   $��2q�5       J� Opacity$	 0.9Q�5      ��5      �� 5       �� 
StartPoint$	 0,0&�6&   	 �� EndPoint$		 1,1&�67   .��5      � 
 � Color$
 #462AD8��6#    � Offset$ 0Q�63   � 5      $
 #DA34AE��6#   $
 0.75Q�63   � 5      $
 #8A16C1��6#   $ 1Q�63   5      ��5       �� 5!      $	 0,1&�6&   $		 1,0&�67   .��5"      � $
 #060531��6#   $ 0Q�63   � 5#      $
 #1B1448��6#   $
 0.75Q�63   5$      ._�5'      �  � RowDefinitions 5(      �� 5)      $��30 �6$   �� 5*      .+�5-      �  � ColumnDefinitions 5.      �� 5/      �� 50      $��25 �6+   �� 51      $��25 �6+   �� 52      $��5 �6+   .+�55      �� -   5         ��Name$ btnMinimize��55      $��0q�56      $��-��57      
�������$��16(�59      $��
Montserrat)�5:       � Cursor$
 Hand��5;      $��1��5<      ��5?      �� 5@       �� 
TargetType" ��6$   .�5A   "   ��  �� Property � �� �� Value �#28AEED6?    �� Triggers 5B   "   P� 5C   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5D   *   ��  � �� �#278BEF6G   5E   '   5G      ��5J      �� 5K       �� 
TargetType" ��6.   .R�5L   "   �� $��18��6)   $��18��64   $ 9��5M   )   #��z��5N   )   ._�5O   &   �� $��Center=�67   $��Center=�5P   7   5Q   #   5R      5T      �� 5V      -   5        $ btnClose��5V      $��0q�5W      $��X��5X      
�������$��16(�5Z      $��
Montserrat)�5[      $
 Hand��5\      $��2��5]      ��5`      �� 5a      " ��6$   .�5b   "   ��  � �� �#DA34AE6?    5c   "   P� 5d   &    �@J�IsMouseOver$
 True��6E   . �5e   *   ��  � �� �#C62DAE6G   5f   '   5h      ��5k      �� 5l      " ��6.   .R�5m   "   �� $��18��6)   $��18��64   $ 9��5n   )   #��z��5o   )   ._�5p   &   �� $��Center=�67   $��Center=�5q   7   5r   #   5s      5u      5v      � 5x      $��1��6   .+�5y      &   HelixToolkit.Wpf.HelixViewport3D  -   5          Name$ 
viewPort3d��5y   -      ZoomExtentsWhenLoaded$
 true��6A   $��10,0,0,0q�6^   $	��452��6p   $	��Top=�6}   $
��Left=�6�   $	��535��6�   
�������   InfoBackground �	#80FFFFFF K� ZIndex$ 1��6     InfoForeground 6�   Z�    Children. 5{      $  HelixToolkit.Wpf.DefaultLights  5|      �� 5}      $��Label��6   $
��Left=�6,   $��	10,10,0,0q�6G   $	��Top=�6Z   $	��390��6r   $	��535��6   
���   �6�   5~      5      5�      5�      5�      