   M S B A M L   `   `   `  ????U  QFlowerShopManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:FlowerShopManagementSystem.Orders!FlowerShopManagementSystem.Orders  5   	   2    ,FlowerShopManagementSystem.Orders.ProductIn4   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:FlowerShopManagementSystem.Orders     5   	   $	??500??5   	   $	??730??6     ? WindowStyle$
  None=?6"    ? WindowStartupLocation$ CenterScreen=?65   
??????  ? AllowsTransparency .  ? 	Resources 5	         updown_button_style ?? 
TargetType ??Name ?? CornerRadius ??Name ?? Triggers	 P? Property
 P? Value ?? 
TargetName  ThemeBrushActive ?? Value ?? Property ?? 
TargetType??%  &	        '?? ?    7   ?? 5
   
   " ??5      .R?5      ?? $ br??5      $??0q?5      ???	#FF008451$ 0??5      ._?5      ?? $ cp??5      #??z??5      #??z??5      #??z??5      5       5      P? 5      	 ?@J?IsMouseOver
 . . ?5      ?? $ br??5      # ?  5        ? ??5!      P? 5"      	 ? {?
 .  . ?5%      ?? $ br??5&       ? ??
 ?????5(      5)      5+      ?? 5,   
   " ??6   .?5-      ??  ? ??8   5/      50      51      .??53      ?? ???#F2F5F8$ 10??6"   ???	#FF008451$??2q?6L   ._?54   
   ? $
??20 0q?6    ? RowDefinitions 55      ?? 56      $
??auto ?6    ?? 57      $
??auto ?6    ?? 58      $??* ?6    ?? 59      $??50 ?6    .+?5D      ??  ?? Orientation$ 
Horizontal=?6   $??	20 20 0 0q?62   .+?5E      ?? $ 50??6   $	??1.5q?6+   ???#EFEFEF._?5F      A? $??40??6   $??40??6)   ??5G      ?? 5H       ?? ImageSource$ /Images/hibicus.png??6)   5J      5K      ?? 5M      $??PRODUCT DETAILS??6   ???#374655$??22(?6H   $??15 0 0 0q?6V   $??Center=?6h   $??SemiBold"?6?   5N      ?? 5P      $??1??6   $??2??6%   $	??0.7??69   $??-20 20 -20 20q?6F   ???#E1E6EB6]   ? 5R      $??2??6    ? ColumnDefinitions 5S      ?? 5T      $??* ?6'   ?? 5U      $??* ?6'   ?? 5V      $	??280 ?6'   .+?5Y      ?  5Z      ?? 5[      $??* ?6(   ?? 5\      $??* ?6(   ?? 5]      $??* ?6(   .+?5`      ?? $??20 10q?6!   $ Vertical=?60   .+?5a      ?? $??
Product ID??6$   ???#97A5B4$??13(?6K   $??0 0 0 8q?6Y   ?? 5c      $ 5??6!   
?????? $??1q?6K   ???	#FFA8A8A8._?5d      ?? -   5         ??Name$ txtblckProductID??5d   (    ?? Padding$
 10 8q?6B   $??13(?6Q   $??Center=?6_   $??Medium"?6z   5e      5f      ?? 5h      $??20 10q?6!   $??1??60   $ Vertical=?6=   .+?5i      ?? $??Price??6$   ???#97A5B4$??13(?6F   $??0 0 0 8q?6T   ?? 5k      $ 5??6!   
?????? $??1q?6K   ???	#FFA8A8A8._?5l      ?? -   5        $ txtblckProductPrice??5l   (   $
 10 8q?6E   $??13(?6T   $??Center=?6b   $??Medium"?6}   ??5m   (   ?? *productPrice+5n      5o      ?? 5s      $??20 10 -150 0q?6!   $ 
Horizontal=?67   $??2??6P   .+?5t      ?? $??Total Money:??6$   
???   ?$??15(?6K   $??0 0 0 8q?6Y   $??SemiBold"?6j   ?? 5v      $??5 0 0 0q?6$   $??15(?6P   $??SemiBold"?6^   
???  ????65   ?? *	Calculate+5w   $   5y      5|      ? 5~      $??1??6    5      ?? 5?      $
??114* ?6(   ?? 5?      $
??114* ?6(   ?? 5?      $	??67* ?6(   ?? 5?      $	??47* ?6(   .+?5?      ?? $??20,10,20,10q?6!   $ Vertical=?67   .+?5?      ?? $??Product Name??6$   ???#97A5B4$??13(?6M   $??0 0 0 8q?6[   ?? 5?      $ 5??6!   
?????? $??1q?6K   ???	#FFA8A8A8._?5?      ?? -   5        $ txtblckProductName??5?   (   $
 10 8q?6D   $??13(?6S   $??Center=?6a   $??Medium"?6|   5?      5?      ?? 5?      $??20,10,20,10q?6!   $??1??66   $ Vertical=?6C   .+?5?      ?? $??Quantity??6$   ???#97A5B4$??13(?6I   $??0 0 0 8q?6W   ?? 5?      $??36??6!   $	??161??6-   $
??Left=?69    J? OpacityMask 5?      !? 5?   "    !? Visual 5?   &   ?? 5?   *   
??????? J? SnapsToDevicePixels . $ 4??5?   -   ??5?   -   ?? *ActualWidth+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType$ BorderL???5?   -   ?? *ActualHeight+ ?? *FindAncestor+$ BorderL?5?   #   ._?5?      ? 
??????? 5?   "   ?? 5?   &   ?? 5?   &    5?   "   ?? 5?   &   ?? 5?   &   $??22 ?67   .+?5?   "   ?? -   5         ??Name$ tb_main??5?   %   $??Medium"?5?   %   $??14(?5?   %   $??0q?5?   %   $??Center=?5?   %   $??10 0 0 0q?5?   %   $??0??5?   %   $??2??5?   %   
???   ?$??1??5?   %   ??.  .??5?   d   5?   #   ?? 5?   "   -   5         ??Name$ cmdUp??5?   %   $??1??5?   %   $??0??5?   %   $
??auto??5?   %   $
??auto??5?   %    ? Cursor$
 Hand??5?   %   ??.  ??5?   &   F? 5?   *   $??Center=?5?   -   $??Center=?5?   -   
???????"???? 	=     ?     	= ? z  	= 	5?   -   5?   #   ?? 5?   "   -   5        $ cmdDown??5?   %   $??1??5?   %   $??1??5?   %   $
??auto??5?   %   $
??auto??5?   %   $
 Hand??5?   %   ??.  ??5?   &   F? 5?   *   $
??Left=?5?   -   $	??Top=?5?   -   
???????"????        ? z     ? 	=  	= 	5?   -   5?   #   ?? 5?   "   -   5        $ brdBrush??5?   %   
??????? J? IsHitTestVisible .  $	??1.5q?5?   %   $ 4??5?   %   $??2??5?   %   $??2??5?   %    ?? Padding$ 0q?5?   %   $??0q?5?   %   5?      5?      5?      5?      ?? 5?      $??2??6   $ Vertical=?6-   $
??20 0q?6D   .+?5?      ?? $??Image??6    ???#97A5B4$??13(?6B   $??0 0 0 8q?6P   $??Center=?6a   $??Center=?6|   ?? 5?      $ 5??6   $	??280??6.   ._?5?      ?? -   5         ??Name$ viewProductImage??5?   !   $??/Images/sunflower.png??6;   5?      5?      5?      ? 5?      $??3??6    5?      ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   .+?5?      ?? -	   5        $ btnBackProductIn4??5?      $
??Back??64   $
??Left=?6C     
backButton#??[ 5?      $??SemiBold"?69   $
 Hand??6o   ?? 5?      -
   5        $ 
btnConfirm??5?      $??1??6-   $??Confirm??6=   $??Right=?6O     
saveButton#??[ 5?      $??SemiBold"?69   $
 Hand??6O   6]   5?      5?      5      5     