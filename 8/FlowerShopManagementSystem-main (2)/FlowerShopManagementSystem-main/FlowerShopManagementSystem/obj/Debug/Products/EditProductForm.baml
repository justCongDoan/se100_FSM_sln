   M S B A M L   `   `   `  ????U  QFlowerShopManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FlowerShopManagementSystemFlowerShopManagementSystem  5   	   9    3FlowerShopManagementSystem.Products.EditProductForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FlowerShopManagementSystem     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	??600??5	   	   $
??1100??6     ? WindowStyle$
  None=?6#    ? WindowStartupLocation$ CenterScreen=?66   
??????  ? AllowsTransparency . .??5
      ?? ???#F2F5F8 ?? CornerRadius$ 10??6"   ???	#FF008451$??2q?6L   ._?5   
   ? $
??20 0q?6    ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $??* ?6    ?? 5      $
??auto ?6    .+?5      ??  ?? Orientation$ 
Horizontal=?6   $??	20 20 0 0q?62   .+?5      ?? $ 50??6   $	??1.5q?6+   ???#EFEFEF._?5      A? $??40??6   $??40??6)   ??5      ?? 5       ?? ImageSource$ /Images/hibicus.png??6)   5!      5"      ?? 5$      $??PRODUCT DETAILS??6   ???#374655$??22(?6H   $??15 0 0 0q?6V   $??Center=?6h   $??SemiBold"?6?   5%      ?? 5'      $??1??6   $??2??6%   $	??0.7??69   $??-20 20 -20 20q?6F   ???#E1E6EB6]   ? 5)      $??2??6    ? ColumnDefinitions 5*      ?? 5+      $??* ?6'   ?? 5,      $??* ?6'   ?? 5-      $??* ?6'   .+?50      ?  51      ?? 52      $??* ?6(   ?? 53      $??* ?6(   ?? 54      $??* ?6(   .+?57      ?? $??20 10q?6!   $ Vertical=?60   .+?58      ?? $??
Product ID??6$   ???#97A5B4$??13(?6K   $??0 0 0 8q?6Y   ?? 5:      -   5         ??Name$ tbxProductID??5:   "   $??Medium"?68   	 ?? 
IsReadOnly	 . 6L   5;      ?? 5=      $??20 10q?6!   $??1??60   $ Vertical=?6=   .+?5>      ?? $ 
Horizontal=?6%   .+?5?      ?? $??Product Type??6(   ???#97A5B4$??13(?6Q   $??0 0 0 8q?6_   ?? 5@      $??*??6(   
???  ??$??3 0 0 0q?6B   5A      ?? 5C      -   5        $ tbxEditProductType??5C   "   $??Medium"?6>   6R   5D      ?? 5H      $??20 10q?6!   $ Vertical=?60   $??2??6G   .+?5I      ?? $ 
Horizontal=?6%   .+?5J      ?? $??Event??6(   ???#97A5B4$??13(?6J   $??0 0 0 8q?6X   ?? 5K      $??*??6(   
???  ??$??3 0 0 0q?6B   5L      ?? 5N      -   5        $ tbxEditEvent??5N   "   $??Medium"?68   6L   5P      5S      ? 5U      $??1??6    5V      ?? 5W      $??* ?6(   ?? 5X      $??* ?6(   ?? 5Y      $??* ?6(   .+?5\      ?? $??20 10q?6!   $ Vertical=?61   .+?5]      ?? $ 
Horizontal=?6%   .+?5^      ?? $??Product Name??6(   ???#97A5B4$??13(?6Q   $??0 0 0 8q?6_   ?? 5_      $??*??6(   
???  ??$??3 0 0 0q?6B   5`      ?? 5b      -   5        $ tbxEditProductName??5b   "   $??Medium"?6>   6R   5c      ?? 5e      $??20 10q?6!   $??1??60   $ Vertical=?6=   .+?5f      ?? $ 
Horizontal=?6%   .+?5g      ?? $??Supplier??6(   ???#97A5B4$??13(?6M   $??0 0 0 8q?6[   ?? 5h      $??*??6(   
???  ??$??3 0 0 0q?6B   5i      ?? 5k      -   5        
 ??Name$
 cbbEditSuppier??5k   #   $??0 3 0 0q?6;   $??5q?6L   
 ? Tag$
 null??6X   $??15(?6c   $??Sitka Subheading)?5n      $??SemiBold"?5o      .@?5p      ??  ?? 
IsSelected . .??6=   Sai Gon - Dam Sen6P   ?? 5q      .??6+   	Ho Thi Ky66   ?? 5r      .??6+   Cho hoa Hau Giang6>   ?? 5s      .??6+   Cho hoa cong vien 23/96C   ?? 5t      .??6+   Ben Binh Dong6:   5u      5v      ?? 5x      $??2??6!   $??20 10q?6.   $ Vertical=?6=   .+?5y      ?? $ 
Horizontal=?6%   .+?5z      ?? $??Price??6(   ???#97A5B4$??13(?6J   $??0 0 0 8q?6X   ?? 5{      $??*??6(   
???  ??$??3 0 0 0q?6B   5|      ?? 5~      -   5        $ tbxEditProductPrice??5~   "   $??Medium"?6?   5   "   5?      5?      ?? 5?      $??2??6   $ Vertical=?6-   $??20 10q?6D   .+?5?      ?? $ 
Horizontal=?6!   $??Center=?6:   $??35 0 0 0q?6W   .+?5?      ?? $ 
Horizontal=?6%   .+?5?      ?? $??Image??6(   ???#97A5B4$??13(?6J   $??0 0 0 8q?6X   $??Center=?6i   $??Center=?6?   ?? 5?      $??*??6(   
???  ??$??3 0 0 0q?6B   5?      ?? 5?      -   5         ??Name$ editProductImageBtn??5?   U      chevron#??[  6!   $??	10 -5 0 0q?6B   .??5?      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=?66   $??25??6B   $??25??6N   5?      5?      ?? 5?      $ 5??6   $??0 10 0 0q?6/   $	??280??6A   ._?5?      ?? -   5         ??Name$ editProductImage??5?   !   $??/Images/sunflower.png??6;   5?      5?      5?      ? 5?      $??3??6    5?      ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   .+?5?      ?? -	   5         ??Name$ notify??5?      $$??Please input full information!??5?      
???  ??$??13(?5?      $	??Top=?5?      $??SemiBold"?5?      $??
20 -40 0 0q?5?      ?? 5?      -
   5        $ btnSaveProduct??5?      $??1??61   $??5??6A   $
??Save??6N   $??Right=?6]   $??	0 40 0 10q?6y     
saveButton#??[ 5?      $??SemiBold"?69    ? Cursor$
 Hand??6O   6]   ?? 5?      -   5        $ btnBackEditProduct??5?      $??5??65   $
??Back??6B   $
??Left=?6Q   $??	0 40 0 10q?6l     
backButton#??[ 5?      $??SemiBold"?69   $
 Hand??6p   5?      5?      5?      5?      