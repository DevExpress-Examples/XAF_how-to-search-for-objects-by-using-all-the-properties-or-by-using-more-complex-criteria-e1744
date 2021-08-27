<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592807/16.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1744)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[SearchObjectBase.cs](./CS/Dennis.Search.Win/SearchObjectBase.cs) (VB: [SearchObjectBase.vb](./VB/Dennis.Search.Win/SearchObjectBase.vb))**
* [SearchObjectPropertyEditor.cs](./CS/Dennis.Search.Win/SearchObjectPropertyEditor.cs) (VB: [SearchObjectPropertyEditor.vb](./VB/Dennis.Search.Win/SearchObjectPropertyEditor.vb))
* [SearchObjectViewController.cs](./CS/Dennis.Search.Win/SearchObjectViewController.cs) (VB: [SearchObjectViewController.vb](./VB/Dennis.Search.Win/SearchObjectViewController.vb))
* [ProductSearchObject.cs](./CS/WinSolution.Module.Win/ProductSearchObject.cs) (VB: [ProductSearchObject.vb](./VB/WinSolution.Module.Win/ProductSearchObject.vb))
* [Product.cs](./CS/WinSolution.Module/Product.cs) (VB: [Product.vb](./VB/WinSolution.Module/Product.vb))
<!-- default file list end -->
# How to search for objects by using all the properties or by using more complex criteria


<p>This example provides a possible workaround for the <a href="https://www.devexpress.com/Support/Center/p/AS13324">Filtering - Support searching objects by a string through all the properties (or a set of properties) or by more complex criteria</a> suggestion.<br /> The Dennis.Search.Win module, shown in the example, provides API to create a non-persistent object that can be used to search by properties of a business class. Such a non-persistent search-object should implement the ISearchObject contract. By default, it's supported by the abstract and generic SearchObjectBase class in the module. Search-objects are shown in a Detail View with the help of the SearchObjectViewController. To compose a search criteria, a specific SearchObjectPropertyEditor is used (it contains the Search and Clear buttons).<br /> An example use of the implemented module is illustrated in the WinSolution.Module.Win module. There is a ProductSearchObject class that is inherited from the base SearchObjectBase class. If necessary, you can create several search objects for one business class. In UI, all search objects will be listed in a drop-down list in the toolbar of a View of your business class. Download and run the attached example to see how this works in action.<br /> (Take special note of the SearchObjectBase class implementation, because it asynchronously loads search results of a specific type from the data store into the Search Results nested List View.)<br /><br /></p>
<p>Note that if you are implementing this functionality in ASP.NET, it is necessary to set the <a href="https://documentation.devexpress.com/#Xaf/DevExpressExpressAppWebWebApplication_CollectionsEditModetopic">WebApplication.CollectionsEditMode</a> property to Edit. Otherwise, the search results will not be displayed.</p>
<p> </p>
<p><strong>See Also:</strong><br /> <a href="https://www.devexpress.com/Support/Center/p/E1607">How to allow users to create filter via the criteria editor before previewing a report</a><br /> <a href="https://www.devexpress.com/Support/Center/p/E932">How to use Criteria Property Editors</a></p>

<br/>


