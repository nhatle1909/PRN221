   M S B A M L   `   `   `  ����J  FConvert3DObject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Convert3DObjectConvert3DObject  5   	       Convert3DObject.MainMenu   5   	   \hxUhttp://schemas.microsoft.com/clr-namespace/HelixToolkit.Wpf;assembly=HelixToolkit.Wpf  5   	   jhxCore_http://schemas.microsoft.com/clr-namespace/HelixToolkit.Wpf.Core;assembly=HelixToolkit.Wpf.Core  5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Convert3DObject     5   	     � Title$  	Main Menu��5
   	   $	��450��6   $	��800��6(   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��307* �6   �� 5      $	��93* �6   .+�5   
   �� -   5         ��Name$ FileURL��5      $��0,0,176,367q�6#    �� TextWrapping$
 Wrap=�68   $��18��6L   $��Bottom=�6X   $��Right=�6s   $	��408��6�   �� 5   
   -   5         ��Name$ Browser��5      $��Browser��6"   $��
0,0,71,367q�64   $��82��6^   $��23��6i   $��Bottom=�6u   $��Right=�6�   �� 5   
   -   5         ��Name$ ExtensionList��5      $��0,0,488,328q�6*   $��23��6q   $��96��6~   $��Bottom=�6�   $��Right=�6�   �� 5   
   $��	File Path��6   $��0,0,506,385q�6$   $��81��69   $��26��6D   $��Bottom=�6P   $��Right=�6k    J� RenderTransformOrigin$ 0.471,0.905&�6�   �� 5   
   -   5        $ Convert��5      $��Convert��6"   $��146,0,372,328q�64   $��24��6a   $��Bottom=�6m   �� 5   
   -   5        $ Preview��5      $��Preview��6"   $��0,0,487,289q�64   $��23��6I   $��Bottom=�6U   $��Right=�6p   $��97��6�   6�   �� 5   
   -   5        $ cbFolder��5      $
��Left=�6%   $��180,262,0,0q�6@   $	��Top=�6U   $	��118��6m   �� 5   
   $ ��Select folder Google Drive��6   $
��Left=�65   $��
24,258,0,0q�6P   $	��Top=�6d   �� 5   
   -   5        $ 	btnUpload��5      $��Upload��6$   $
��Left=�65   $��180,321,0,0q�6P   $	��Top=�6e   $��65��6}   $��21��6�   6�   �� 5   
   -   5        $ txbNameDriveFolder��5      $
��Left=�6.   $��
30,171,0,0q�6I   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��120��6�   �� 5   
   -	   5        $ btnCreateDriveFolder��5      $��Create folder��6/   $
��Left=�6G   $��30,0,0,0q�6b   $��Center=�6t   $��96��6�   $��24��6�   6�   �� 5   
   -
   5        $
��Open��5      $
��Left=�6    $��315,262,0,0q�6;   $	��Top=�6P   $��45��6h   6s   �� 5   
   -   5         ��Name$ lbNameFileDrive��5      $�� ��6)   $��13(�64   $
��Left=�6B   $��180,290,0,0q�6]   $	��Top=�6r   5       5!      