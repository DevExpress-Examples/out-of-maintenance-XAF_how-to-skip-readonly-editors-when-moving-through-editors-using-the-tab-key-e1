Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors

Namespace XAFCommunity.Win
	''' <summary>
	''' This controller sets UI control properties based upon class property attributes.
	''' The code will set the ReadOnly property based upon an attribute. Where controls
	''' are read-only the tabstop is set to false. If there is a TabStopAttribute override
	''' this is applied as well.
	''' </summary>
	Partial Public Class ReadOnlyTabStopController
		Inherits ViewController

		Public Sub New()
			Me.TargetViewType = ViewType.DetailView
		End Sub

		Protected Overrides Sub OnViewControlsCreated()
			MyBase.OnViewControlsCreated()
			Dim viewNode As DictionaryNode = Me.View.Info.Parent
			If viewNode IsNot Nothing Then
				Dim attr As DictionaryAttribute = viewNode.GetAttribute("TabOverReadOnlyEditors")
				Dim readOnlyTabStopFunctionality As Boolean
				If Boolean.TryParse(attr.Value, readOnlyTabStopFunctionality) Then
					If readOnlyTabStopFunctionality Then
						Dim detailView As DetailView = CType(View, DetailView)
						CheckControlsVisibility(detailView)
					End If
				End If
			End If
		End Sub
		Private Sub CheckControlsVisibility(ByVal detailView As DetailView)
			Guard.ArgumentNotNull(detailView, "detailView")
			' Determine here if the class implements a particular interface. 
			For Each viewItem As DetailViewItem In detailView.Items
				Dim objectType As Type = viewItem.ObjectType
				If TypeOf viewItem Is DXPropertyEditor AndAlso viewItem.Info IsNot Nothing Then
					Dim propertyName As String
                                                                                If viewItem.Info.KeyAttribute IsNot Nothing Then 
propertyName =  viewItem.Info.KeyAttribute.Value
else
propertyName=string.empty
end if
					Dim propertyIsReadOnly As Boolean = viewItem.Info.IsReadOnly
					Dim viewInfoIsModified As Boolean = viewItem.Info.IsModified
					' Access the visualisation control.
					Dim editor As BaseEdit = TryCast(viewItem.Control, BaseEdit)

					' ReadOnly Determination - this is only executed if the Dictionary has determined that a property should be
					' read only.
					If (Not propertyIsReadOnly) AndAlso (Not String.IsNullOrEmpty(propertyName)) Then
						Dim revisedReadOnly As Boolean = propertyIsReadOnly

						If editor IsNot Nothing AndAlso propertyIsReadOnly <> revisedReadOnly AndAlso (Not viewItem.Info.IsModified) AndAlso (Not editor.Properties.ReadOnly) Then
							If editor.Properties.ReadOnly <> revisedReadOnly Then
								If (Not viewInfoIsModified) Then
									editor.Properties.ReadOnly = revisedReadOnly
								End If
							End If
						End If
					End If
					' Post processing
					' if the control is read-only, then there is no need for the control to be a tabstop.
					If editor IsNot Nothing Then
						Dim controlHasTabStop As Boolean = editor.TabStop
						Dim revisedTabStop As Boolean = controlHasTabStop AndAlso ((Not editor.Properties.ReadOnly))
						If revisedTabStop <> controlHasTabStop Then
							editor.TabStop = revisedTabStop
						End If
					End If
				End If
			Next viewItem
		End Sub
	End Class
End Namespace