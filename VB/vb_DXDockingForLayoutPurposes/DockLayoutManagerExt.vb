Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports DevExpress.Xpf.Layout.Core
Imports DevExpress.Xpf.Docking
Imports DevExpress.Xpf.Docking.Platform

Namespace vb_DXDockingForLayoutPurposes
	'S171364
	Friend Class DockLayoutManagerExt
		Inherits DockLayoutManager

		Private layoutView As IView
		Private customizationView As IView

		Protected Overrides Function CreateLayoutView(ByVal element As IUIElement) As IView
			layoutView = New CustomLayoutView(element)
			Return layoutView
		End Function
		Protected Overrides Function CreateCustomizationView(ByVal element As IUIElement) As IView
			customizationView = New MyCustomizationView(element)
			Return customizationView
		End Function
	End Class

	Public Class MyCustomizationView
		Inherits CustomizationView
		Public Sub New(ByVal viewUIElement As IUIElement)
			MyBase.New(viewUIElement)
		End Sub

		Protected Overrides Sub RegisterListeners()
			MyBase.RegisterUIServiceListener(New LayoutViewSelectionListener())
			MyBase.RegisterUIServiceListener(New CustomizationViewUIInteractionListener())
			MyBase.RegisterUIServiceListener(New MyCustomizationDraggingListener()) 'my version
		End Sub
	End Class

	Public Class CustomLayoutView
		Inherits LayoutView
		Public Sub New(ByVal viewUIElement As IUIElement)
			MyBase.New(viewUIElement)
		End Sub

		Protected Overrides Sub RegisterListeners()
			RegisterUIServiceListener(New LayoutViewRegularDragListener())
			RegisterUIServiceListener(New LayoutViewFloatingDragListener())
			RegisterUIServiceListener(New LayoutViewReorderingListener())
			RegisterUIServiceListener(New MyDragListener()) ' my version
			RegisterUIServiceListener(New LayoutViewNonClientDraggingListener())
			RegisterUIServiceListener(New LayoutViewUIInteractionListener())
			RegisterUIServiceListener(New LayoutViewSelectionListener())
			RegisterUIServiceListener(New LayoutViewActionListener())
		End Sub
	End Class

	Public Class MyDragListener
		Inherits LayoutViewClientDraggingListener
		Public Overrides Function CanDrop(ByVal point As Point, ByVal element As ILayoutElement) As Boolean

			Dim dockLayoutElementDragInfo As New DockLayoutElementDragInfo(Me.View, point, element)
			Dim draggedItem As BaseLayoutItem = dockLayoutElementDragInfo.Item
			Dim target As BaseLayoutItem = dockLayoutElementDragInfo.Target
			If (Not DragHelper.IsItemInGroup(draggedItem)) AndAlso (Not DragHelper.IsTargetInGroup(target)) Then
				Return MyBase.CanDrop(point, element)
			End If
			Dim result As Boolean = DragHelper.AllowMoving(draggedItem, target)
			Return result

		End Function
	End Class

	Public Class MyCustomizationDraggingListener
		Inherits CustomizationViewClientDraggingListener
		Public Overrides Function CanDrop(ByVal point As Point, ByVal element As ILayoutElement) As Boolean
			Dim dockLayoutElementDragInfo As New DockLayoutElementDragInfo(MyBase.View, point, element)
			Dim draggedItem = dockLayoutElementDragInfo.Item
			Dim target = dockLayoutElementDragInfo.Target
			If (TypeOf dockLayoutElementDragInfo.DropTarget Is HiddenItemElement OrElse TypeOf dockLayoutElementDragInfo.DropTarget Is HiddenItemsListElement) AndAlso dockLayoutElementDragInfo.Item.AllowHide Then
				Dim itemType As LayoutItemType = dockLayoutElementDragInfo.Item.ItemType
                Return (LayoutItemsHelper.IsLayoutItem(dockLayoutElementDragInfo.Item) OrElse itemType = LayoutItemType.Group)
			End If
			If (Not DragHelper.IsItemInGroup(draggedItem)) AndAlso (Not DragHelper.IsTargetInGroup(target)) Then
				Return MyBase.CanDrop(point, element)
			End If
			Return DragHelper.AllowMoving(draggedItem, target)
		End Function
	End Class
End Namespace
