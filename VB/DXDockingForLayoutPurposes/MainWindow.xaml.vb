Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Markup
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Xpf.Layout.Core
Imports DevExpress.Xpf.Docking
Imports DevExpress.Xpf.Docking.Base
Imports DevExpress.Xpf.Docking.VisualElements
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core.Native
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Namespace DXDockingForLayoutPurposes
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits DXRibbonWindow

		Public Sub New()
			InitializeComponent()
			DataContext = New DataSource()
		End Sub
	End Class
	Public Class TestData
		Public Property Text() As String
		Public Property Number() As Integer
	End Class

	Public Class TestDataViewModel
		Implements INotifyPropertyChanged

'INSTANT VB NOTE: The field data was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private data_Conflict As TestData
		Public Sub New()
			data_Conflict = New TestData() With {
				.Text = String.Empty,
				.Number = 0
			}
		End Sub
		Public Property Text() As String
			Get
				Return Data.Text
			End Get
			Set(ByVal value As String)
				If Data.Text = value Then
					Return
				End If
				Data.Text = value
				RaisePropertyChanged("Text")
			End Set
		End Property
		Public Property Number() As Integer
			Get
				Return Data.Number
			End Get
			Set(ByVal value As Integer)
				If Data.Number = value Then
					Return
				End If
				Data.Number = value
				RaisePropertyChanged("Number")
			End Set
		End Property
		Protected ReadOnly Property Data() As TestData
			Get
				Return data_Conflict
			End Get
		End Property
		#Region "INotifyPropertyChanged"
		Public Event PropertyChanged As PropertyChangedEventHandler
		Protected Overridable Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
			RaiseEvent PropertyChanged(Me, e)
		End Sub
		Protected Sub RaisePropertyChanged(ByVal propertyName As String)
			OnPropertyChanged(New PropertyChangedEventArgs(propertyName))
		End Sub
		#End Region
	End Class

	Public Class DataSource
		Private source As ObservableCollection(Of TestDataViewModel)
		Public Sub New()
			source = CreateDataSource()
		End Sub
		Protected Function CreateDataSource() As ObservableCollection(Of TestDataViewModel)
			Dim res As New ObservableCollection(Of TestDataViewModel)()
			res.Add(New TestDataViewModel() With {
				.Text = "Row0",
				.Number = 0
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row1",
				.Number = 1
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row2",
				.Number = 2
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row3",
				.Number = 3
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row4",
				.Number = 4
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row5",
				.Number = 5
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row6",
				.Number = 6
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row7",
				.Number = 7
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row8",
				.Number = 8
			})
			res.Add(New TestDataViewModel() With {
				.Text = "Row9",
				.Number = 9
			})
			Return res
		End Function
		Public ReadOnly Property Data() As ObservableCollection(Of TestDataViewModel)
			Get
				Return source
			End Get
		End Property
	End Class
End Namespace
