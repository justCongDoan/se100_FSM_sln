   M S B A M L   `   `   `  ????U  QFlowerShopManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FlowerShopManagementSystemFlowerShopManagementSystem  5   	   [2clr-namespace:FlowerShopManagementSystem.Resources$FlowerShopManagementSystem.Resources  5	   	   1    +FlowerShopManagementSystem.Orders.EditOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   6local(clr-namespace:FlowerShopManagementSystem   5   	   E
components2clr-namespace:FlowerShopManagementSystem.Resources   5	   	   $	??600??5   	   $
??1100??6     ? WindowStyle$
  None=?6#    ? WindowStartupLocation$ CenterScreen=?66   
??????  ? AllowsTransparency . .??5      ?? ???#F2F5F8 ?? CornerRadius$ 10??6"   ???	#FF008451$??2q?6L   ._?5   
   ? $
??20 0q?6    ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $??* ?6    ?? 5      $
??auto ?6    .+?5      ??  ?? Orientation$ 
Horizontal=?6   $??	20 20 0 0q?62   .+?5      ?? $ 50??6   $	??1.5q?6+   ???#EFEFEF._?5       A? $??40??6   $??40??6)   ??5!      ?? 5"       ?? ImageSource$ /Images/shopping-bag.png??6)   5$      5%      ?? 5'      $??ORDER DETAILS??6   ???#374655$??22(?6F   $??15 0 0 0q?6T   $??Center=?6f   $??SemiBold"?6?   5(      ?? 5*      $??1??6   $??2??6%   $	??0.7??69   $??-20 20 -20 20q?6F   ???#E1E6EB6]   ? 5,      $??2??6    ? ColumnDefinitions 5-      ?? 5.      $	??350 ?6'   ?? 5/      $??* ?6'   .+?53      ?  54      ?? 55      $??* ?6(   ?? 56      $??* ?6(   ?? 57      $??* ?6(   ?? 58      $??* ?6(   .+?5;      ?? $??20 10q?6!   $ Vertical=?60   $??1??6G   .+?5<      ?? $??Order ID??6$   ???#97A5B4$??13(?6I   $??0 0 0 8q?6W   ?? 5>      -   5         ??Name$ tbxEditOrderID??5>   "   $??Medium"?6:   5@      ?? 5B      $??20 10q?6!   $??2??60   $ Vertical=?6=   .+?5C      ?? $??Customer Phone??6$   ???#97A5B4$??13(?6O   $??0 0 0 8q?6]   ? 5E       5F      ?? 5G   "   $??* ?63   ?? 5H   "   $
??auto ?63   .+?5K      ?? -   5        $ tbxEditCustomerPhone??5K   &   $??Medium"?6D   6X   ?? 5M      -   5        	 ??Name$	 btnEditFind??5M   5   $??1??6%      
findButton#??[  6J   
 ? Cursor$

 Hand??6n   $??5 0 0 0q?6?   .??5N   "   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Magnify=?68     gridButtonIcon#??[ 6G   $??20??6o   $??20??6{   5O      5P      5Q      ?? 5S      $??20 10q?6!   $ Vertical=?61   .+?5T      ?? $??Employee ID??6$   ???#97A5B4$??13(?6L   $??0 0 0 8q?6Z   ?? 5V      -   5        $ tbxEditEmployeeID??5V   "   $??Medium"?6=    ?? 
IsReadOnly . 6Q   5W      ?? 5Y      $??20 10q?6!   $??3??60   $ Vertical=?6=   .+?5Z      ?? $??Customer Name??6$   ???#97A5B4$??13(?6N   $??0 0 0 8q?6\   ?? 5\      -   5        $ tbxEditCustomerName??5\   "   $??Medium"?6?    . 6S   5]      5_      ? 5c      $??1??6    5d      ?? 5e      $??* ?6(   ?? 5f      $
??auto ?6(   .+?5i      &   System.Windows.Controls.DataGrid  -   5          Name$ editOrderDetailsDataGrid??5j        DataGridStyle1#???  5i        DataGridCellStyle1   	CellStyle# ?  6H     DataGridColumnHeaderStyle1   ColumnHeaderStyle# ?  6y   $??0??5j   A      RowStyle 5k      ?? 5l       ?? 
TargetType)  #System.Windows.Controls.DataGridRow"  6$   .?5m   "   ??  ?? Property ? ?? ?? Value$ 0 4 0 0q?6;   ?? 5n   "    ? ?? ?#FFFFFF6?   ?? 5o   "    ?@J?SnapsToDevicePixels . 6H   ?? 5p   "    ?@=?ErrorTemplate 6M   Z? ?? 5q   "    ?@?Cursor$
 Hand??6;   ?? 5r   "    ?@ ValidationErrorTemplate 5s   &   ?? 5t   *   .R?5u   .   ?? 
???  ??$??2,0,0,0q?6I   $??!??6Z   $??Center=?6c   5v   +   5x   #   ?? 5y   "    ? ?? 5z   &   ?? 5{   *    ?? 
TargetType"  6:   .R?5|   .   ??  ??Name$ 
DGR_Border??65    ?? Padding$	 0 8q?6I   $ 5??6W   #??z??6h   $??0q?6?    J? SnapsToDevicePixels . ._?5}   2   ?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid   5~   6   ?? 5   :   $
??Auto ?6K   ?? 5?   :   $??* ?6K    5?   6   ?? 5?   :   $??* ?6H   ?? 5?   :   $
??Auto ?6H   .+?5?   6   ?  9System.Windows.Controls.Primitives.DataGridCellsPresenter  $??1??6M      
ItemsPanel#??z 6]   # z 6?   A  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter  5?   6   $??1??6O   $??1??6_      DetailsVisibility#y?z 6?  $   SelectiveScrollingOrientation 6l   ?? *AreRowDetailsFrozen+#   RowDetailsScrollingConverter ?? 	Converter# Z ;  5System.Windows.Controls.SelectiveScrollingOrientation   Vertical ?? ConverterParameter# Z  ?? RelativeSource ??   ?? AncestorType"   6?  :  4System.Windows.Controls.Primitives.DataGridRowHeader  5?   6   $??2??6H   $ Vertical=?6Y   y?6?   ?? *HeadersVisibility+!!   HeadersVisibilityConverter# Z! 7	  1System.Windows.Controls.DataGridHeadersVisibility
" 	  Row# Z"  ?? "   5?   3   5?   /   5?   +   5?   #   # ?? Triggers# 5?   "   P? 5?   &   $ P? Property$ ?@J?IsMouseOver% P? Value% . . ?5?   *   ??  ? ?? ?#e5e5e56G   5?   '   P? 5?   &   $ ?@ 
IsSelected% . . ?5?   *   ??  ? ?? ?#e5e5e56G   5?   '   ]? 5?   &   & ]? 
Conditions& 5?   *   ?? 5?   .   ' ?? Property' ?@ 
IsSelected( ?? Value( . 6N   ?? 5?   .   ' ?@??IsSelectionActive( .  6^   ./?5?   *   ??  ? ?? ?#dfdfdf6G   5?   '   5?      )   Columns) 5?      0
  *System.Windows.Controls.DataGridTextColumn
  5?      ,  &System.Windows.Controls.DataGridColumn*   Header$* #??61   +   
IsReadOnly+ . ,   CanUserResize, .  -   Width5  /System.Windows.Controls.DataGridLengthConverter$
- auto 6d   1  +System.Windows.Controls.DataGridBoundColumn.   Binding. 6q   ?? *
sttSanPham+4  .System.Windows.Controls.DataGridTemplateColumn  5?      $* 
Product ID??65   + . $- * 6[   /   CellTemplate/ 5?   "   ?? 5?   &   .R?5?   *   ?? $ 
Horizontal=?65   .+?5?   .   ?? $??Center=?6S   ??68   ?? *	productID+6S   5?   +   5?   '   5?      
  5?      $
* Name??61   + . $- * 6Q   . 6[   ?? *productName+
  5?      $* Quantity??61   + . $- * 6U   . 6_   ?? *productQuantity+
  5?      $* Price??61   + . $- * 6R   . 6\   ?? *productPrice+0 ?? StringFormat$0 {0:C}??
  5?      $* Total Money??61   + . $- * 6X   . 6b   ?? *productTotalMoney+$0 {0:C}??  5?      $* 
Operations??65   + . $
- auto 6[   / 5?   "   ?? 5?   &   .R?5?   *   ?? $ 
Horizontal=?65   .+?5?   .   ?? $	 btnEditRemoveProduct??65   -   5          gridRemoveButton#??[ 5?   S   $

 Hand??6}   .??5?   2     $ DeleteOutline=?6H   #??[ 6]   5?   /   5?   +   5?   '   5?      5?      ? 5?      $??1??6   $??
10 15 10 0q?6(    5?      ?? 5?      $??* ?6/   ?? 5?      $
??auto ?6/   .+?5?      ?? $ 
Horizontal=?6%   .+?5?      ?? $??Total Money??6(   $??SemiBold"?6;   $??15(?6Q   $??0 5 0 0q?6_   ?? 5?      $ 5??6%   
?????? $??1q?6O   ???	#FFA8A8A8$??5 0 0 0q?6{   ._?5?   "   ?? -   5        1 ??Name$1 txtblckTotalMoney??5?   ,   2 ?? Padding$2 7 4 0 0q?6G   $??13(?6Z   $??Center=?6h   $
??Bold"?6?   $??25??6?   $	??200??6?   3 ?? TextAlignment$
3 Left=?6?   $
??100$??5?   ,   5?      5?      ?? 5?      -	   5        $	 editChooseProductBtn??5?   !   $??Choose Products??6?   $??SemiBold"?6Y     
saveButton#??[ 6o   $??30??6?   $??13(?5?      $??Right=?6N   $??1??6k   $	??160??6{   5?      5?      5?      ? 5?      $??3??6    5?      ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   .+?5?      ?? -
   5        $	 btnSaveOrder??5?      $??1??6/   $??5??6?   $
??Save??6L   $??Right=?6[   $??	0 40 0 10q?6w   #??[ 5?      $??SemiBold"?69   $

 Hand??6O   6]   ?? 5?      -   5        $	 btnBackEditOrder??5?      $??5??63   $
??Back??6@   $
??Left=?6O   $??	0 40 0 10q?6j     
backButton#??[ 5?      $??SemiBold"?69   $

 Hand??6n   5?      5?      5?      5?      