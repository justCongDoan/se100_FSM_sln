   M S B A M L   `   `   `  ????U  QFlowerShopManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FlowerShopManagementSystemFlowerShopManagementSystem  5   	   8    2FlowerShopManagementSystem.Accounts.AddAccountForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FlowerShopManagementSystem     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	??600??5	   	   $
??1100??6     ? WindowStyle$
  None=?6#    ? WindowStartupLocation$ CenterScreen=?66   
??????  ? AllowsTransparency . .??5
      ?? ???#F2F5F8 ?? CornerRadius$ 10??6"   ???	#FF008451$??2q?6L   ._?5   
   ? $
??20 0q?6    ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $??* ?6    ?? 5      $
??auto ?6    .+?5      ??  ?? Orientation$ 
Horizontal=?6   $??	20 20 0 0q?62   .+?5      ?? $ 50??6   $	??1.5q?6+   ???#EFEFEF._?5      A? $??40??6   $??40??6)   ??5      ?? 5       ?? ImageSource$ /Images/accountImage.png??6)   5!      5"      ?? 5$      $??CREATE NEW ACCOUNT??6   ???#374655$??22(?6K   $??15 0 0 0q?6Y   $??Center=?6k   $??SemiBold"?6?   5%      ?? 5'      $??1??6   $??2??6%   $	??0.7??69   $??-20 20 -20 20q?6F   ???#E1E6EB6]   ? 5)      $??2??6    ? ColumnDefinitions 5*      ?? 5+      $??* ?6'   ?? 5,      $??* ?6'   ?? 5-      $??* ?6'   .+?50      ?  51      ?? 52      $??* ?6(   ?? 53      $??* ?6(   ?? 54      $??* ?6(   .+?57      ?? $??20 10q?6!   $ Vertical=?60   .+?58      ?? $ 
Horizontal=?6%   .+?59      ?? $??Employee ID??6(   ???#97A5B4$??13(?6P   $??0 0 0 8q?6^   ?? 5:      $??*??6(   
???  ??$??3 0 0 0q?6B   5;      ?? 5=      -   5         ??Name$ tbxEmployeeID??5=   "   $??Medium"?69   6M   5>      ?? 5@      $??20 10q?6!   $??1??60   $ Vertical=?6=   .+?5A      ?? $ 
Horizontal=?6%   .+?5B      ?? $??Phone Number??6(   ???#97A5B4$??13(?6Q   $??0 0 0 8q?6_   ?? 5C      $??*??6(   
???  ??$??3 0 0 0q?6B   5D      ?? 5F      -   5        $ tbxEmployeePhoneNumber??5F   "   $??Medium"?6B   $??0 3 0 0q?5H   "   63   5I      ? 5K      $??2??6    5L      ?? 5M      $??* ?6/   ?? 5N      $??* ?6/   .+?5Q      ?? $??20 10 -40 10q?6%   $ Vertical=?6;   .+?5R      ?? $ 
Horizontal=?6)   .+?5S   "   ?? $??Username??6,   ???#97A5B4$??13(?6Q   $??0 0 0 8q?6_   ?? 5U   "   $??*??6,   
???  ??$??3 0 0 0q?6F   5V      ?? 5X      -   5        $ tbxUsername??5X   &   $??Medium"?6;   6O   5Z      ?? 5\      $??80 10 -100 10q?6%   $ Vertical=?6<   $??1??6S   .+?5]      ?? $ 
Horizontal=?6)   .+?5^   "   ?? $??Password??6,   ???#97A5B4$??13(?6Q   $??0 0 0 8q?6_   ?? 5`   "   $??*??6,   
???  ??$??3 0 0 0q?6F   5a      ?? 5c      -   5        $ tbxPassword??5c   &   $??Medium"?6;   6O   5d      5e      5f      ? 5h      $??1??6    5i      ?? 5j      $??* ?6(   ?? 5k      $??* ?6(   ?? 5l      $??* ?6(   .+?5o      ?? $??20 10q?6!   $ Vertical=?61   .+?5p      ?? $ 
Horizontal=?6%   .+?5q      ?? $??Employee Name??6(   ???#97A5B4$??13(?6R   $??0 0 0 8q?6`   ?? 5r      $??*??6(   
???  ??$??3 0 0 0q?6B   5s      ?? 5u      -   5        $ tbxEmployeeName??5u   "   $??Medium"?6;   6O   5v      ?? 5x      $??20 10q?6!   $??1??60   $ Vertical=?6=   .+?5y      ?? $ 
Horizontal=?6%   .+?5z      ?? $??Working Date??6(   ???#97A5B4$??13(?6Q   $??0 0 0 8q?6_   ?? 5{      $??*??6(   
???  ??$??3 0 0 0q?6B   5|      (  "System.Windows.Controls.DatePicker  5~      -   5        	  Name$	 dpkWorkingDate??5~   %   $??0 5 0 0q?6=   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Select working date??6N   $??15(?5   %   $??Sitka Subheading)?63   $??SemiBold"?6Q   |?.   ? 	Resources 5?      :  4System.Windows.Controls.Primitives.DatePickerTextBox ?? 
TargetType ?? Property ?? Value??%[   '        ?? 5?   "   "  6(   .?5?   &   ??  ?@??
IsReadOnly . 6C   5?   #   5?      5?      5?      ?? 5?      $??2??6!   $??134 10 20 10q?6.   $ Vertical=?6D   .+?5?      ?? $ 
Horizontal=?6%   .+?5?      ?? $??Account Priority??6(   ???#97A5B4$??13(?6U   $??0 0 0 8q?6c   ?? 5?      $??*??6(   
???  ??$??3 0 0 0q?6B   5?      ?? 5?      -   5         ??Name$ cbbAccountPriority??5?   #   $??0 3 0 0q?6?   $??5q?6P   
 ? Tag$
 null??6\   $??15(?6g   $??Sitka Subheading)?5?      $??SemiBold"?5?       ? Cursor$
 Hand??5?   #   .@?5?      ?? $??Manager??6+   ?? 5?      $??Employee??6+    ?? 
IsSelected . 6>   5?      5?      5?      ?? 5?      $??2??6   $ Vertical=?6-   $??20 10q?6D   .+?5?      ?? $ 
Horizontal=?6!   $??Center=?6:   $??35 0 0 0q?6W   .+?5?      ?? $??Avatar??6$   ???#97A5B4$??13(?6G   $??0 0 0 8q?6U   $??Center=?6f   $??Center=?6?   ?? 5?      -   5         ??Name$ uploadAvatarBtn??5?   U      chevron#??[  6!   $??	10 -5 0 0q?6B   .??5?      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=?66   $??25??6B   $??25??6N   5?      5?      ?? 5?      $ 50??6   $??0 30 0 0q?60   ._?5?      A? $	??200??6#   $	??200??6/   ??5?      ?? 5?   "   -	   5        
avatar??$ /Images/man.png??5?   =   5?      5?      5?      5?      ? 5?      $??3??6    5?      ?? 5?      $??* ?6'   ?? 5?      $??* ?6'   .+?5?      ?? .+?5?      ?? -
   5         ??Name$ notify??5?       $$??Please input full information!??5?       
???  ??$??13(?5?       $	??Top=?5?       $??SemiBold"?5?       $??
20 -40 0 0q?5?       ?? 5?      -   5        $ btnBackEmployee??5?      $??5??66   $
??Back??6C   $
??Left=?6R   $??	0 40 0 10q?6m     
backButton#??[ 5?      $??SemiBold"?69   $
 Hand??6m   5?      ?? 5?      -   5        $ btnAddEmployee??5?      $??1??6-   $??5??6=   $	??Add??6J   $??Right=?6X   $??	0 40 0 10q?6t     
saveButton#??[ 5?      $??SemiBold"?69   $
 Hand??6O   6]   5?      5?      5?      5?      