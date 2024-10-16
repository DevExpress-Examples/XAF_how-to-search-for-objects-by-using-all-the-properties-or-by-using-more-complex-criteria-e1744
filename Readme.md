<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592807/22.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1744)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:
* [MySearchClass.cs](CS/EFCore/ComplexSearchEF/ComplexSearchEF.Module/BusinessObjects/MySearchClass.cs)
* [Model.DesignedDiffs.xafml](CS/EFCore/ComplexSearchEF/ComplexSearchEF.Module/Model.DesignedDiffs.xafml)
* [MySearchController.cs](CS/EFCore/ComplexSearchEF/ComplexSearchEF.Module/Controllers/MySearchController.cs)
* [MyShowSearchController.cs](CS/EFCore/ComplexSearchEF/ComplexSearchEF.Module/Controllers/MyShowSearchController.cs)
<!-- default file list end -->
# How to search for XAF objects using a complex criterion


To accomplish this task, take the following steps:


1. Create a [non-persistent](https://docs.devexpress.com/eXpressAppFramework/116516/business-model-design-orm/non-persistent-objects) class with properties that we will use to find persistent objects: [MySearchClass.cs](CS/EFCore/ComplexSearchEF/ComplexSearchEF.Module/BusinessObjects/MySearchClass.cs)
2. In this class add a collection of persistent objects as described at [How to: Show Persistent Objects in a Non-Persistent Object's View](https://docs.devexpress.com/eXpressAppFramework/116106/business-model-design-orm/non-persistent-objects/how-to-show-persistent-objects-in-a-non-persistent-objects-view#persistent-collection). This collection will show the search results.
3. In this class' non-persistent detail  view, add a custom 'Search' action as described at [How to: Include an Action to a Detail View Layout](https://docs.devexpress.com/eXpressAppFramework/112816/task-based-help/miscellaneous-ui-customizations/how-to-include-an-action-to-a-detail-view-layout)
4. When a user presses this 'Search' action, create a criterion based on the properties from point 1 and get persistent objects that fit this criterion as described at the 'Get a collection' section of [Create, Read, Update and Delete Data](https://docs.devexpress.com/eXpressAppFramework/113711/concepts/data-manipulation-and-business-logic/create-read-update-and-delete-data): [MySearchController.cs](CS/EFCore/ComplexSearchEF/ComplexSearchEF.Module/Controllers/MySearchController.cs)
5. To show this non-persistent class view, use the solution from [Ways to Show a View](https://docs.devexpress.com/eXpressAppFramework/112803/ui-construction/views/ways-to-show-a-view/ways-to-show-a-view): [MyShowSearchController.cs](CS/EFCore/ComplexSearchEF/ComplexSearchEF.Module/Controllers/MyShowSearchController.cs)

![image](https://github.com/DevExpress-Examples/XAF_how-to-search-for-objects-by-using-all-the-properties-or-by-using-more-complex-criteria-e1744/assets/14300209/c5b8ac4b-9e88-4f29-99cd-b2a0bdf64890)


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF_how-to-search-for-objects-by-using-all-the-properties-or-by-using-more-complex-criteria-e1744&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF_how-to-search-for-objects-by-using-all-the-properties-or-by-using-more-complex-criteria-e1744&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
