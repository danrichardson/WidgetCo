WidgetCo
========

The WidgetCo project is a basic Visual Studio solution that demonstrates many aspects of creating a supportable application using the Microsoft stack.  Basically, a company has a product Catalog, and the products are related to each other in some way.  When the user selects a product, they are shown related products.

The code is structured in the MVVM (Model-View-ViewModel) pattern.  The Model consists of the objects that implement the ICatalog interface - the Catalog and MockCatalog classes inherit the BaseCatalog class.  The MockCatalog is used for the Unit Tests to verify the ICatalog functionality.  The View is a simple WPF structure to show basic UI functionality.  The ViewModel ties the bindings in the View to the data of the Model.

Techniques demonstrated include:
&nbsp;&nbsp;MVVM design pattern<br>
&nbsp;&nbsp;Separation of concerns<br>
&nbsp;&nbsp;LINQ use on data structures<br>
&nbsp;&nbsp;Interface design<br>
&nbsp;&nbsp;Mocking<br>
&nbsp;&nbsp;Unit Tests<br>
&nbsp;&nbsp;WPF UI design<br>
