   M S B A M L   `   `   `  ????U  QFlowerShopManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FlowerShopManagementSystemFlowerShopManagementSystem  5   	   :    4FlowerShopManagementSystem.Suppliers.AddSupplierForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FlowerShopManagementSystem     5   	   $	??500??5   	   $	??740??6     ? WindowStyle$
  None=?6"    ? WindowStartupLocation$ CenterScreen=?65   
??????  ? AllowsTransparency . .??5	      ?? ???#F2F5F8 ?? CornerRadius$ 10??6"   ???	#FF008451$??2q?6L   ._?5
   
   ? $
??20 0q?6    ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $??* ?6    ?? 5      $
??auto ?6     ? ColumnDefinitions 5      ?? 5      $??* ?6#   ?? 5      $??* ?6#   .+?5      ??  ?? Orientation$ 
Horizontal=?6   $??	20 20 0 0q?62   .+?5      ?? $ 50??6   $	??1.5q?6+   ???#EFEFEF._?5      A? $??40??6   $??40??6)   ??5      ?? 5       ?? ImageSource$  /Images/Supplier image.png??6)   5      5       ?? 5"      $??ADD NEW SUPPLIER??6   ???#374655$??22(?6I   $??15 0 0 0q?6W   $??Center=?6i   $??SemiBold"?6?   5#      ?? 5%      $??1??6   $??2??6%   $	??0.7??69   $??-20 20 -20 20q?6F   ???#E1E6EB6]   ?? 5'      $??20 10q?6   $??0??6(   $??2??68   $ Vertical=?6E   .+?5(      ?? $ 
Horizontal=?6   .+?5)      ?? $??Supplier ID??6    ???#97A5B4$??13(?6H   $??0 0 0 8q?6V   ?? 5*      $??*??6    
???  ??$??3 0 0 0q?6:   5+      ?? 5-      -   5         ??Name$ tbxSupplierID??5-      $??Medium"?61   6E   5.      ?? 50      $??20 10q?6   $??1??6(   $??2??68   $ Vertical=?6E   .+?51      ?? $ 
Horizontal=?6   .+?52      ?? $??Supplier Name??6    ???#97A5B4$??13(?6J   $??0 0 0 8q?6X   ?? 53      $??*??6    
???  ??$??3 0 0 0q?6:   54      ?? 56      -   5        $ tbxSupplierName??56      $??Medium"?63   6G   57      ?? 59      $??20 10q?6   $??0??6(   $??3??68   $ Vertical=?6E   .+?5:      ?? $ 
Horizontal=?6   .+?5;      ?? $??Phone Number??6    ???#97A5B4$??13(?6I   $??0 0 0 8q?6W   ?? 5<      $??*??6    
???  ??$??3 0 0 0q?6:   5=      ?? 5?      -   5        $ tbxSupplierPhoneNumber??5?      $??Medium"?6:   5@      5A      ?? 5C      $??20 10q?6   $??1??6(   $??3??68   $ Vertical=?6E   .+?5D      ?? $ 
Horizontal=?6   .+?5E      ?? $??Street??6    ???#97A5B4$??13(?6C   $??0 0 0 8q?6Q   ?? 5F      $??*??6    
???  ??$??3 0 0 0q?6:   5G      ?? 5I      -   5        $ tbxSupplierStreet??5I      $??Medium"?65   6I   5J      ? 5L      $??4??6    5M      ?? 5N      $??* ?6'   ?? 5O      $??* ?6'   .+?5R      ?? $??20 10 -40 10q?6   $ Vertical=?63   .+?5S      ?? $ 
Horizontal=?6!   .+?5T      ?? $
??Ward??6$   ???#97A5B4$??13(?6E   $??0 0 0 8q?6S   ?? 5U      $??*??6$   
???  ??$??3 0 0 0q?6>   5V      ?? 5X      -   5        	 ??Name$	 cbbSupplierWard??5X      $??5q?68   

 ? Tag$

 null??6D   $??15(?6O   $??Sitka Subheading)?5[      $??SemiBold"?5\      .@?5]      ??  ?? 
IsSelected . .??69   P16=   ?? 5^      .??6'   P26+   ?? 5_      .??6'   P36+   ?? 5`      .??6'   P46+   ?? 5a      .??6'   P56+   ?? 5b      .??6'   P66+   ?? 5c      .??6'   P76+   ?? 5d      .??6'   P86+   ?? 5e      .??6'   P96+   ?? 5f      .??6'   P106,   ?? 5g      .??6'   P116,   ?? 5h      .??6'   P126,   ?? 5i      .??6'   P136,   ?? 5j      .??6'   P146,   ?? 5k      .??6'   P156,   ?? 5l      .??6'   P166,   ?? 5m      .??6'   P176,   ?? 5n      .??6'   P186,   ?? 5o      .??6'   P196,   ?? 5p      .??6'   P206,   ?? 5q      .??6'   P216,   ?? 5r      .??6'   P226,   ?? 5s      .??6'   P236,   ?? 5t      .??6'   P246,   ?? 5u      .??6'   P256,   ?? 5v      .??6'   P266,   ?? 5w      .??6'   P276,   ?? 5x      .??6'   P286,   5y      5{      ?? 5}      $??80 10 -100 10q?6   $ Vertical=?64   $??1??6K   .+?5~      ?? $ 
Horizontal=?6!   .+?5      ?? $??District??6$   ???#97A5B4$??13(?6I   $??0 0 0 8q?6W   ?? 5?      $??*??6$   
???  ??$??3 0 0 0q?6>   5?      ?? 5?      -   5        $	 cbbSupplierDistrict??5?      $??5q?6<   $

 null??6H   $??15(?6S   $??Sitka Subheading)?5?      $??SemiBold"?5?      .@?5?      ??  . .??69   
TP.Thu Duc6E   ?? 5?      .??6'   Q36+   ?? 5?      .??6'   Q46+   ?? 5?      .??6'   Q56+   ?? 5?      .??6'   Q66+   ?? 5?      .??6'   Q76+   ?? 5?      .??6'   Q86+   ?? 5?      .??6'   Q106,   ?? 5?      .??6'   Q116,   ?? 5?      .??6'   Q126,   ?? 5?      .??6'   
Q.Binh Tan63   ?? 5?      .??6'   Q.Binh Thanh65   ?? 5?      .??6'   
Q.Go Vap61   ?? 5?      .??6'   Q.Phu Nhuan64   ?? 5?      .??6'   
Q.Tan Binh63   ?? 5?      .??6'   	Q.Tan Phu62   ?? 5?      .??6'   H.Binh Chanh65   ?? 5?      .??6'   	H.Can Gio62   ?? 5?      .??6'   
H.Cu Chi61   ?? 5?      .??6'   	H.Hoc Mon62   ?? 5?      .??6'   
H.Nha Be61   5?      5?      5?      ?? 5?      $??4??6   $??1??6&   $??134 10 20 10q?66   $ Vertical=?6L   .+?5?      ?? $ 
Horizontal=?6   .+?5?      ?? $
??City??6    ???#97A5B4$??13(?6A   $??0 0 0 8q?6O   ?? 5?      $??*??6    
???  ??$??3 0 0 0q?6:   5?      ?? 5?      -   5        $	 cbbSupplierCity??5?      $??5q?64   $

 null??6@   $??15(?6K   $??Sitka Subheading)?5?      $??SemiBold"?5?      .@?5?      ??  . .??65   TPHCM6<   5?      5?      ?? 5?      -   5         ??Name$ notify??5?      $$??Please input full information!??5?      $??5??5?      
???  ??$??13(?5?      $	??Top=?5?      $??SemiBold"?5?      $??20 0 0 0q?5?      ?? 5?      -	   5         ??Name$ btnAddSupplier??5?      $??1??6-   $??5??6=   $	??Add??6J   $??Right=?6X   $??	0 40 0 10q?6t      
saveButton#??[  6?   $??SemiBold"?6?    ? Cursor$
 Hand??6?   6?   ?? 5?      -
   5        $ btnBackAddSupplier??5?      $??5??61   $
??Back??6>   $
??Left=?6M   $??	0 40 0 10q?6h     
backButton#??[ 6{   $??SemiBold"?6?   $
 Hand??6?   6?   5?      5?      5?      