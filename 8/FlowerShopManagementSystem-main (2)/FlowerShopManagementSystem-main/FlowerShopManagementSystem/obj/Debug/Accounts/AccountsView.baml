   M S B A M L   `   `   `  ????U  QFlowerShopManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FlowerShopManagementSystemFlowerShopManagementSystem  5      6    0FlowerShopManagementSystem.Accounts.AccountsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:FlowerShopManagementSystem     5      g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5        ? 	Resources  5         	BoolToVis ?? 
TargetType ?? 
ResourceId ?? TypeInTargetAssembly&   System.Windows.Controls.DataGrid ?? Property ?? Value ?? 
TargetType ??Name J? SnapsToDevicePixels	 ?Name
 J? Opacity ? Points ?? Stretch ?? Triggers P? Property P? Value ?? 
TargetName??%?  &	        (??      5      $" DataGridSelectAllButtonStyle??"  )?? 5   
   6'   ?? 5   
   " ??6   .?5      ??  ? ?? 5      ?? 5      " ??6&   .R?5      ? .+?5      ?? $ Border??6(   #??? ??68    . 6y   ? 5      $	 Arrow??6&   
???   ?$??Right=?6B   $??8,8,3,3q?6^   $

 0.15Q?6o    ?   ??? ??? ??? ??? $ Uniform=?6?   $??Bottom=?6?   5       5      P? 5       ?@J?IsMouseOver . . ?5   "   ?? $ Border??6;   # ? ??6O    ? ??5      P? 5       ? ?? . . ?5   "   ?? $ Border??69   # ? ??6M    ? ??5      P? 5       ? {? .  . ?5   "   ?? $ Arrow??6?    ? y?$ 	Collapsed=?6R   5      5!      5#      5$      5%      .??5'      ? ???#EFF2F7 ? RowDefinitions 5(   
   ?? 5)      $
??auto ?6   ?? 5*      $
??auto ?6   ?? 5+      $
??auto ?6   ?? 5,      $??* ?6   ?? 5-      $
??auto ?6   .+?50   
   ?? $??Accounts??6   $??32(?6$   $??SemiBold"?62   $??0 20 0 0q?6H   ???#121518$
??Left=?6o   ?? 52   
   -   5         ??Name$ btnAddAccount??52   A     	addButton#??[ 6   $??0??64    ? Cursor$
 Hand??6X   .??53      ??  ?? Orientation$ 
Horizontal=?6   .+?54      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Plus=?6(   $??Center=?64   $??0 1 8 0q?6O   $??11??6`   $??11??6k   ?? 55      $??Add new account??6   56      58      ?? 5:   
   $??1??6   $??1??6   ???#DAE2EA$??	0 -1 0 10q?6A   ?? 5<   
   $??10 Accounts??6   $??2??6'   $??18(?64   $??SemiBold"?6B   ???#121518$
??Left=?6m   $??Center=?6?   ?? 5>   
   $??	Filter by??6   $??2??6%   $??13(?62   $??SemiBold"?6@   $??	0 0 215 0q?6V   ???#121518$??Right=?6~   $??Center=?6?   ? 5@   
   $	??200??6   $??Right=?6   $??2??67   .+?5A      ?? $
??10 0q?6   $??Center=?6&   ???#B0B9C6 J? IsHitTestVisible .   K? ZIndex$ 1??5B      $??Search in Accounts ...??6-   y?5C      ??  ?? ElementName$ textBoxFilter?? ?? Path$ Text.IsEmpty? ?? 	Converter# [  ?? 5E      -   5        $??textBoxFilter??5E        filterTextBox#??[ 6+   5F        5H   
   -   5          Name$ accountsDataGrid??5I        DataGridStyle1#???  5H        DataGridCellStyle1   	CellStyle# ?  6<     DataGridColumnHeaderStyle1   ColumnHeaderStyle# ?  6m   $??3??5I   -   ??6:   ?? *
accounts+   RowStyle 5J      ?? 5K      )  #System.Windows.Controls.DataGridRow"  6   .?5L      -   5        ?? 5M       ? ??$ 0 4 0 0q?6/   ?? 5N       ? ?? ?#FFFFFF63   ?? 5O       ?@J?SnapsToDevicePixels . 6<   ?? 5P       ?@=?ErrorTemplate 6A   Z? ?? 5Q       ?@?Cursor$
 Hand??6/   ?? 5R       ?@ ValidationErrorTemplate 5S      ?? 5T      .R?5U   "   ?? 
???  ??$??2,0,0,0q?6=   $??!??6N   $??Center=?6W   5V      5X      ?? 5Y       ? ?? 5Z      ?? 5[      "  6.   .R?5\   "   ??  ??Name$ 
DGR_Border??6)     ?? Padding$	  0 8q?6=   ! ?? CornerRadius$! 5??6K   #??z??6\   $??0q?6?    . ._?5]   &   ?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid  " ? ColumnDefinitions" 5^   *   ?? 5_   .   $
??Auto ?6?   ?? 5`   .   $??* ?6?    5b   *   ?? 5c   .   $??* ?6<   ?? 5d   .   $
??Auto ?6<   .+?5f   *   ?  9System.Windows.Controls.Primitives.DataGridCellsPresenter  $??1??6A   #   
ItemsPanel#??z# 6Q   # z 6{   A  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter  5g   *   $??1??6C   $??1??6S   $   DetailsVisibility#y?z$ 6w  $%   SelectiveScrollingOrientation% 6`   ?? *AreRowDetailsFrozen+#&   RowDetailsScrollingConverter# Z& ;  5System.Windows.Controls.SelectiveScrollingOrientation'   Vertical( ?? ConverterParameter#( Z' ) ?? RelativeSource) ?? * ?? AncestorType"*  6w  :  4System.Windows.Controls.Primitives.DataGridRowHeader  5h   *   $??2??6<   $% Vertical=?6M   y?6?   ?? *HeadersVisibility+!+   HeadersVisibilityConverter# Z+ 7	  1System.Windows.Controls.DataGridHeadersVisibility
, 	  Row#( Z, ) ?? "*  5i   '   5j   #   5k      5m      - ?? Triggers- 5o      P? 5p       ?@J?IsMouseOver . . ?5q      ??  ? ?? ?#e5e5e56;   5s      P? 5t       ?@ 
IsSelected . . ?5u      ??  ? ?? ?#e5e5e56;   5w      ]? 5x      . ]? 
Conditions. 5y      ?? 5z   "   / ?? Property/ ?@ 
IsSelected0 ?? Value0 . 6B   ?? 5{   "   / ?@??IsSelectionActive0 .  6R   ./?5}      ??  ? ?? ?#dfdfdf6;   5~      5?      1   Columns1 5?      0
  *System.Windows.Controls.DataGridTextColumn
  5?      ,  &System.Windows.Controls.DataGridColumn2   Header$2 #??6%   3   
IsReadOnly3 . 4   CanUserResize4 .  5   Width5  /System.Windows.Controls.DataGridLengthConverter$
5 auto 6X   1  +System.Windows.Controls.DataGridBoundColumn6   Binding6 6e   ?? *sttTK+4  .System.Windows.Controls.DataGridTemplateColumn  5?      $2 Employee Name??6)   3 . $5 * 6R   7   CellTemplate7 5?      ?? 5?      .R?5?      ?? $ 
Horizontal=?6)   .+?5?   "   ?? $??50??6)   $??50??64   $??
0 10 10 10q?6@   ._?5?   &   A? ??5?   *   ?? 5?   .   8 ?? ImageSource8 69   ?? *
avatarTK+5?   '   5?   #   ?? 5?   "   $??Center=?6J   ??6,   ?? *employeeName+6J   5?      5?      5?      
  5?      $
2 Code??6%   3 . $5 * 6E   6 6O   ?? *employeeCode+
  5?      $2 Phone Number??6%   3 . $5 * 6M   6 6W   ?? *employeePhone+
  5?      $2 Working Date??6%   3 . $5 * 6M   6 6W   ?? *workingDate+  5?      $2 
Operations??6)   3 . $
5 auto 6O   7 5?      ?? 5?      .R?5?      ?? $ 
Horizontal=?6)   .+?5?   "   ?? $ btnEditAccount??6Q   -   5          gridEditButton#??[ 5?   )   .??5?   &     $ PencilOutline=?6<     gridButtonIcon#??[ 6Q   5?   #   ?? 5?   "   $ btnDeleteAccount??6d   -   5          gridRemoveButton#??[ 5?   )   $??5 0 0 0q?6S   .??5?   &     $ DeleteOutline=?6<   #??[ 6Q   5?   #   5?      5?      5?      5?      ?? 5?   
   $??4??6   $??Right=?6   ???#dee4ec$??1q?6P   $! 5??5?      $  5q?6"   
???????$??
0 10 10 10q?6A   ._?5?      ?? $ 
Horizontal=?6   .+?5?      ?? -   5        $ btnFirstPage??5?   ?    	 pagingButton#??[	 6   .??5?        $ ChevronDoubleLeft=?6,    
 pagingButtonIcon#??[
 6E   5?      ?? 5?      -   5        $ btnPreviousPage??5?   ?   #??[	 6   .??5?        $ ChevronLeft=?6,   #??[
 6?   5?      ?? 5?      $??1??6   ???#dee4ec$	??3 7q?65   ?? 5?        pagingTextBlock#??[ 69   ??6   ?? *CurrentPage+69   ?? 5?      $??of??6   #??[ 6&   $??0q?6O   ?? 5?      #??[ 67   ??6   ?? *	PageCount+67   ?? 5?      $??1??6   ???#dee4ec$	??3 7q?65   ?? 5?      -	   5        $ btnNextPage??5?   ?   #??[	 6   .??5?        $ ChevronRight=?6,   #??[
 6@   5?      ?? 5?      -
   5        $ btnLastPage??5?   ?   #??[	 6   .??5?        $ ChevronDoubleRight=?6,   #??[
 6F   5?      5?      5?      5?      5?      