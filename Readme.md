<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128643681/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4845)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Dock Layout Manager - Limit LayoutGroup Customization at Runtime

This example limits [LayoutGroup](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.LayoutGroup) customization at runtime.

<img src="https://user-images.githubusercontent.com/12169834/175359371-47c8a0aa-9d45-470d-9f9f-a830ac39a423.png" width=900px/>

The example contains a [DockLayoutManager](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.DockLayoutManager) class descendant and the attached `DisableCrossingGroupBoundaries` property. You can attach the `DisableCrossingGroupBoundaries` property only to the [LayoutGroup](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.LayoutGroup).

In this case, a [LayoutGroup](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.LayoutGroup) with the property assigned to `true` allows users to customize the group and prevents them moving inner elements outside [LayoutGroup](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.LayoutGroup) boundaries. For the [LayoutGroup](https://docs.devexpress.com/WPF/DevExpress.Xpf.Docking.LayoutGroup) without this property, the default logic is used for arranging elements.


<!-- default file list -->
## Files to Look At

* [DockLayoutManagerExt.cs](./CS/DXDockingForLayoutPurposes/DockLayoutManagerExt.cs) (VB: [DockLayoutManagerExt.vb](./VB/vb_DXDockingForLayoutPurposes/DockLayoutManagerExt.vb))
* [Helpers.cs](./CS/DXDockingForLayoutPurposes/Helpers.cs) (VB: [Helpers.vb](./VB/vb_DXDockingForLayoutPurposes/Helpers.vb))
* [MainWindow.xaml](./CS/DXDockingForLayoutPurposes/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/vb_DXDockingForLayoutPurposes/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXDockingForLayoutPurposes/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/vb_DXDockingForLayoutPurposes/MainWindow.xaml.vb))
<!-- default file list end -->

## Documentation

- [Runtime Layout Customization](http://docs.devexpress.devx/WPF/7222/)
