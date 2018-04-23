Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model

Namespace ReadOnlyTabStopRemover.Module.Win
	<ToolboxItemFilter("Xaf.Platform.Win")> _
	Public NotInheritable Partial Class ReadOnlyTabStopRemoverWindowsFormsModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Overrides Sub ExtendModelInterfaces(ByVal extenders As ModelInterfaceExtenders)
			MyBase.ExtendModelInterfaces(extenders)
			extenders.Add(Of IModelOptions, IModelOptionsEx)()
		End Sub
	End Class
	Public Interface IModelOptionsEx
	Inherits IModelNode
		<DefaultValue(False), Category("Behavior")> _
		Property TabOverReadOnlyEditors() As Boolean
	End Interface
End Namespace
