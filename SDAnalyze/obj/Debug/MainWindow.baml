   M S B A M L   `   `   `  ����D  @SDAnalyze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SDAnalyze	SDAnalyze  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       SDAnalyze.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SDAnalyze     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  Storage Device Analysis��5	   	   $	��600��6)   $
��1000��66    � WindowStartupLocation$ CenterScreen=�6C    � DataContext 6h   ��  �� RelativeSource �� *Self+ � 	Resources 5
         BackgroundBrush �� Color  ForegroundBrush �� 
TargetType �� Property �� Value	 �� 
TargetType
 � RowDefinitions �� HeaderStringFormat �� CornerRadius �� Padding��%)  &	        &	 #     '�� F     7  �� 5   
   $ 	#FF191F26��62   �� 5   
   $ 	#FF0EF0FF��62   �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      "	 ��6&   .R�5      � 
 5      �� 5   "   $
��.05* �60   �� 5   "   $��* �60   .+�5      �� $��0��65   #��z��6B   # z 6e   $��Center=�6�   $��Center=�6�   $��20(�6�   $
��Bold"�6�   �� 5      $��1��6%   $��2q�62   8��  $ 5��6u   #��z��6�   # z��6�   ._�5   "   �� #��z��63   5       5!      5#      5%      5'      5(      ��5*      �� 5+   
   " �6   .�5,      ��  � ��# [  6+   5-      .��51      �  � ColumnDefinitions 52   
   �� 53      $	��.4* �6   �� 54      $	��.6* �6   
 56   
   �� 57      $��* �6   �� 58      $
��.05* �6   .+�5;   
   �� $��0��6   $��0��6    $��Explorer��60   #��[ 6B   $��1q�6p   $��2q�6{   #��[ 6�   .��5<      R� -   5         R�Name$ tvView��5<      #��[  6'   ��6U   �� *TreeViewItems+��5=      �� 5>       �� DataType   SDAnalyze.TreeViewNode"  6/    �� ItemsSource 6V   �� *
ChildNodes+.R�5?      �� #��[ 6;   ��6$   �� *Title+6;   5@      5B      5C      �� 5E   
   $��0��6   $��1��6    $��Analysis��60   #��[ 6B   $��1q�6p   $��2q�6{   #��[ 6�   .��5F        LiveCharts.Wpf.PieChart  -   5          Name$ lvcChart��5F      &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�6-      	Hoverable .    InnerRadius$	 200Q�6t      DisableAnimations .    Series 6�   �� *ChartSeries+6�   5G      �� 5I   
   -   5        $��0��5I      $��1��6!   $��Analyze��6.   #��[ 6@   #��[  6n   $��1q�6�   #��[ 6�   6�   5J      5K      