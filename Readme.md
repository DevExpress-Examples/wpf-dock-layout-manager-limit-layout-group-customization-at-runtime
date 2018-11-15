<!-- default file list -->
*Files to look at*:

* [DockLayoutManagerExt.cs](./CS/DXDockingForLayoutPurposes/DockLayoutManagerExt.cs) (VB: [DockLayoutManagerExt.vb](./VB/vb_DXDockingForLayoutPurposes/DockLayoutManagerExt.vb))
* [Helpers.cs](./CS/DXDockingForLayoutPurposes/Helpers.cs) (VB: [Helpers.vb](./VB/vb_DXDockingForLayoutPurposes/Helpers.vb))
* [MainWindow.xaml](./CS/DXDockingForLayoutPurposes/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/vb_DXDockingForLayoutPurposes/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXDockingForLayoutPurposes/MainWindow.xaml.cs) (VB: [MainWindow.xaml](./VB/vb_DXDockingForLayoutPurposes/MainWindow.xaml))
<!-- default file list end -->
# How to limit LayoutGroup customization at runtime


<p>We have prepared an example demonstrating how to limit LayoutGroup customization at runtime.</p><p>To provide this functionality, we created a DockLayoutManager class descendant and the attached DisableCrossingGroupBoundaries property. The DisableCrossingGroupBoundaries property can be attached only to the LayoutGroup.</p><p>In this case, the LayoutGroup with the property assigned to true allows any customization and prevents moving inner elements outside LayoutGroup boundaries. For the LayoutGroup without this property, the default logic is used for arranging elements.</p>

<br/>


