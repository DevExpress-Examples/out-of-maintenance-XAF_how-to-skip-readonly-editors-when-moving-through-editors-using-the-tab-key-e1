Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports DevExpress.ExpressApp
Imports DevExpress.XtraEditors
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.ConditionalEditorState
Imports DevExpress.ExpressApp.ConditionalEditorState.Win

Namespace ReadOnlyTabStopRemover.Module.Win
	Public Class TestCustomEditorStateCustomization
		Inherits ViewController(Of DetailView)
		Private detailViewCustomization As EditorStateCustomizationDetailViewController
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			detailViewCustomization = Frame.GetController(Of EditorStateCustomizationDetailViewController)()
			If detailViewCustomization IsNot Nothing Then
				AddHandler detailViewCustomization.CustomEditorStateCustomization, AddressOf detailViewCustomization_CustomEditorStateCustomization
			End If
		End Sub
		Private Sub CustomizeTabStop(ByVal control As Control, ByVal shouldTabStop As Boolean)
			If control Is Nothing Then
				Return
			End If
			'The TextEdit control overrides the TabStop property, and so it should be explicitely set.
			Dim txtEditor As TextEdit = TryCast(control, TextEdit)
			If txtEditor IsNot Nothing Then
				txtEditor.TabStop = shouldTabStop
			Else
				control.TabStop = shouldTabStop
			End If
		End Sub
		Private Function ShouldTabOverReadOnlyEditors() As Boolean
			Dim modelOptionsExt As IModelOptionsEx = TryCast(Application.Model.Options, IModelOptionsEx)
			Return modelOptionsExt IsNot Nothing AndAlso modelOptionsExt.TabOverReadOnlyEditors
		End Function
		Private Sub detailViewCustomization_CustomEditorStateCustomization(ByVal sender As Object, ByVal e As CustomEditorStateCustomizationEventArgs)
			If e.EditorState = EditorState.Disabled Then
				Dim disabled As Boolean = e.Active
				Dim item As PropertyEditor = TryCast(e.Item, PropertyEditor)
				If item IsNot Nothing Then

				Dim dxEditor As BaseEdit = TryCast(item.Control, BaseEdit)
				'Customize tab stop for readonly editors affected by the ConditionalEditorState module.
				If disabled Then
					CustomizeTabStop(CType(item.Control, Control),ShouldTabOverReadOnlyEditors())
				Else
					CustomizeTabStop(CType(item.Control, Control),(Not disabled))
				End If
				End If
			End If
		End Sub
		Protected Overrides Sub OnViewControlsCreated()
			MyBase.OnViewControlsCreated()
			For Each item As PropertyEditor In View.GetItems(Of PropertyEditor)()
				Dim ctrl As Control = CType(item.Control, Control)
				Dim disabled As Boolean = ctrl IsNot Nothing AndAlso Not item.AllowEdit
				'Customize tab stop for readonly editors unaffected by the ConditionalEditorState module.
				If disabled Then
					CustomizeTabStop(ctrl,ShouldTabOverReadOnlyEditors())
				Else
					CustomizeTabStop(ctrl,True)
				End If
			Next item
		End Sub
		Protected Overrides Sub OnDeactivating()
			If detailViewCustomization IsNot Nothing Then
				RemoveHandler detailViewCustomization.CustomEditorStateCustomization, AddressOf detailViewCustomization_CustomEditorStateCustomization
			End If
			MyBase.OnDeactivating()
		End Sub
	End Class
End Namespace