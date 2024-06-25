<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643681/13.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4845)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DockLayoutManagerExt.cs](./CS/DXDockingForLayoutPurposes/DockLayoutManagerExt.cs) (VB: [DockLayoutManagerExt.vb](./VB/DXDockingForLayoutPurposes/DockLayoutManagerExt.vb))
* [Helpers.cs](./CS/DXDockingForLayoutPurposes/Helpers.cs) (VB: [Helpers.vb](./VB/DXDockingForLayoutPurposes/Helpers.vb))
* [MainWindow.xaml](./CS/DXDockingForLayoutPurposes/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXDockingForLayoutPurposes/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXDockingForLayoutPurposes/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXDockingForLayoutPurposes/MainWindow.xaml.vb))
<!-- default file list end -->
# How to limit LayoutGroup customization at runtime


<p>We have prepared an example demonstrating how to limit LayoutGroup customization at runtime.</p><p>To provide this functionality, we created a DockLayoutManager class descendant and the attached DisableCrossingGroupBoundaries property. The DisableCrossingGroupBoundaries property can be attached only to the LayoutGroup.</p><p>In this case, the LayoutGroup with the property assigned to true allows any customization and prevents moving inner elements outside LayoutGroup boundaries. For the LayoutGroup without this property, the default logic is used for arranging elements.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-dock-layout-manager-limit-layout-group-customization-at-runtime&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-dock-layout-manager-limit-layout-group-customization-at-runtime&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
