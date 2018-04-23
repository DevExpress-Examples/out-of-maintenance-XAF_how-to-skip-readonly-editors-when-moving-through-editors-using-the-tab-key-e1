Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating

Namespace ReadOnlyTabStopRemover.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As ObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim obj1 As DemoObject = ObjectSpace.CreateObject(Of DemoObject)()
			obj1.Name = "DemoObject1"
			obj1.DisableSimpleProperty = True
			obj1.Save()
			Dim obj2 As DemoObject = ObjectSpace.CreateObject(Of DemoObject)()
			obj2.Name = "DemoObject2"
			obj2.DisableSimpleProperty = False
			obj2.Save()
		End Sub
	End Class
End Namespace