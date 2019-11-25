Xamarin Forms Shell with basic MVVM
==============

I'm building a simple Xamarin Forms Shell app with basic MVVM architecture in mind
This was started off with the defaul Xamarin Forms Shell template in Visual Studio, and move structure to a more MVVM-friendly architecture.

Add page routing
```
Routing.RegisterRoute("itemdetailpage", typeof(ItemDetailPage));
```

Use Shell.Current.GoToAsync()
```
var url = Uri.EscapeDataString(item.Id);
await Shell.Current.GoToAsync($"itemdetailpage?itemId={url}", true);
```

use QueryProperty for pages
```
[QueryProperty("ItemId", "itemId")]
```