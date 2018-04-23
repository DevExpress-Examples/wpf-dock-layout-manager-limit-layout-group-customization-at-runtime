Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports DevExpress.Xpf.Docking

Namespace vb_DXDockingForLayoutPurposes
	Public Class Helper
		Inherits DependencyObject
		Public Shared ReadOnly DisableCrossingGroupBoundariesProperty As DependencyProperty = DependencyProperty.RegisterAttached("DisableCrossingGroupBoundaries", GetType(Boolean), GetType(Helper), New PropertyMetadata(False, New PropertyChangedCallback(AddressOf PropertyChanged)))

		Public Shared Function GetDisableCrossingGroupBoundaries(ByVal d As DependencyObject) As Boolean
			Return CBool(d.GetValue(DisableCrossingGroupBoundariesProperty))
		End Function
		Public Shared Sub SetDisableCrossingGroupBoundaries(ByVal d As DependencyObject, ByVal value As Boolean)
			d.SetValue(DisableCrossingGroupBoundariesProperty, value)
		End Sub

		Public Shared Sub PropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			If Not(TypeOf d Is LayoutGroup) Then
				Throw New ArgumentException("Use this attached property only with LayoutGroup")
			End If
		End Sub

	End Class
	Public NotInheritable Class DragHelper
		Private Sub New()
		End Sub
		Public Shared Function AllowMoving(ByVal item As BaseLayoutItem, ByVal target As BaseLayoutItem) As Boolean
			Dim result As Boolean = False
			If target Is Nothing Then
				Return False
			End If
			If DragHelper.IsItemInGroup(item) AndAlso DragHelper.IsTargetInGroup(target) AndAlso (TypeOf target Is LayoutControlItem) Then
				Return True
			End If
			Dim draggedItem As BaseLayoutItem = Nothing, targetItem As BaseLayoutItem = Nothing
			If TypeOf item Is LayoutControlItem Then
				draggedItem = TryCast(item, LayoutControlItem)
				If TypeOf target Is LayoutControlItem Then
					targetItem = TryCast(target, LayoutControlItem)
                    If targetItem.Parent Is draggedItem.Parent Then
                        result = True
                    End If
				End If
				If TypeOf target Is LayoutGroup Then
					targetItem = TryCast(target, LayoutGroup)
                    If targetItem.Parent Is draggedItem.Parent Then
                        result = True
                    End If
				End If
			End If
			If TypeOf item Is LayoutGroup Then
				draggedItem = TryCast(item, LayoutGroup)
				If TypeOf target Is LayoutControlItem Then
					targetItem = TryCast(target, LayoutControlItem)
                    If targetItem.Parent Is draggedItem.Parent Then
                        result = True
                    End If
				End If
				If TypeOf target Is LayoutGroup Then
					targetItem = TryCast(target, LayoutGroup)
                    If targetItem.Parent Is draggedItem.Parent Then
                        result = True
                    End If
				End If
			End If
			Return result
		End Function


		Public Shared Function IsItemInGroup(ByVal item As BaseLayoutItem) As Boolean
			Dim result As Boolean = False
			Dim currentItem As BaseLayoutItem = item
			Do While currentItem.Parent IsNot Nothing
				If TypeOf currentItem.Parent Is LayoutGroup Then
					Dim lgroup As LayoutGroup = TryCast(currentItem.Parent, LayoutGroup)
					Dim allowCustomization As Boolean = Helper.GetDisableCrossingGroupBoundaries(lgroup)
					If allowCustomization Then
						result = True
						Exit Do
					End If
				End If
				currentItem = currentItem.Parent
			Loop
			Return result
		End Function
		Public Shared Function IsTargetInGroup(ByVal target As BaseLayoutItem) As Boolean
			Dim result As Boolean = False
			Dim currentTarget As BaseLayoutItem = target
			Do While currentTarget IsNot Nothing
				If TypeOf currentTarget Is LayoutGroup Then
					Dim lgroup As LayoutGroup = TryCast(currentTarget, LayoutGroup)
					Dim allowCustomization As Boolean = Helper.GetDisableCrossingGroupBoundaries(lgroup)
					If allowCustomization Then
						result = True
						Exit Do
					End If
				End If
				currentTarget = currentTarget.Parent
			Loop
			Return result
		End Function

	End Class




End Namespace

