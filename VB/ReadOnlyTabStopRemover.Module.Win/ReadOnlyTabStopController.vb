Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports DevExpress.ExpressApp
Imports DevExpress.XtraEditors
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Editors

Namespace ReadOnlyTabStopRemover.Module.Win
	Public Class TestCustomEditorStateCustomization
		Inherits ViewController(Of DetailView)
		Private Function GetEditors() As IList(Of PropertyEditor)
			Return View.GetItems(Of PropertyEditor)()
		End Function
		Protected Overrides Overloads Sub OnActivated()
			MyBase.OnActivated()
			For Each editor As PropertyEditor In GetEditors()
				AddHandler editor.AllowEditChanged, AddressOf OnCustomizeTabStop
				AddHandler editor.ControlCreated, AddressOf OnCustomizeTabStop
			Next editor
		End Sub
		Private Sub OnCustomizeTabStop(ByVal sender As Object, ByVal e As System.EventArgs)
			CustomizeTabStop((CType(sender, PropertyEditor)))
		End Sub
		Protected Overrides Overloads Sub OnDeactivated()
			For Each editor As PropertyEditor In GetEditors()
				RemoveHandler editor.AllowEditChanged, AddressOf OnCustomizeTabStop
				RemoveHandler editor.ControlCreated, AddressOf OnCustomizeTabStop
			Next editor
			MyBase.OnDeactivated()
		End Sub
		Private Sub CustomizeTabStop(ByVal editor As PropertyEditor)
			Dim ctrl As Control = TryCast(editor.Control, Control)
			Dim disabled As Boolean = ctrl IsNot Nothing AndAlso Not editor.AllowEdit
			If disabled Then
				CustomizeTabStopCore(ctrl,ShouldTabOverReadOnlyEditors())
			Else
				CustomizeTabStopCore(ctrl,True)
			End If
		End Sub
		Private Sub CustomizeTabStopCore(ByVal control As Control, ByVal shouldTabStop As Boolean)
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
	End Class
End Namespace