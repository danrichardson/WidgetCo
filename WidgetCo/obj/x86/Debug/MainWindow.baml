   M S B A M L   `   `   `  ����C  ?WidgetCo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WidgetCo.ViewWidgetCo.View  5   	   9!clr-namespace:WidgetCo.ViewModelsWidgetCo.ViewModels  5   	       WidgetCo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -viewsclr-namespace:WidgetCo.View     5   	   8
viewModels!clr-namespace:WidgetCo.ViewModels     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��600��6)    � DataContext 5      0   *WidgetCo.ViewModels.ChooseWidgetsViewModel  5   
   .��5      � $��6q�6    � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��50* �6   �� 5      $	��30* �6   .+�5   
       WidgetCo.View.Instructions  $��0��6      WidgetCo.View.ItemList  5   
   $��1��6       WidgetCo.View.RelatedItems  5   
   $��2��6   5      5      