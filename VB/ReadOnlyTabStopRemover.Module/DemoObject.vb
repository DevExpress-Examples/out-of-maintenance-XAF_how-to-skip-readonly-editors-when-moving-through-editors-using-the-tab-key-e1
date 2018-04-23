Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.ConditionalEditorState

Namespace ReadOnlyTabStopRemover.Module
	<DefaultClassOptions, EditorStateRule("DemoObject.SimpleProperty.Disabled", "SimpleProperty", EditorState.Disabled, "DisableSimpleProperty", DevExpress.ExpressApp.ViewType.DetailView, "Disables the SimpleProperty only if the DisableSimpleProperty value is True")> _
	Public Class DemoObject
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _Name As String
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _Name, value)
			End Set
		End Property
		Private _DisableSimpleProperty As Boolean
		<ImmediatePostData> _
		Public Property DisableSimpleProperty() As Boolean
			Get
				Return _DisableSimpleProperty
			End Get
			Set(ByVal value As Boolean)
				SetPropertyValue("DisableSimpleProperty", _DisableSimpleProperty, value)
			End Set
		End Property
		Private _SimpleProperty As String
		Public Property SimpleProperty() As String
			Get
				Return _SimpleProperty
			End Get
			Set(ByVal value As String)
				SetPropertyValue("SimpleProperty", _SimpleProperty, value)
			End Set
		End Property
		Private _ReadOnlyProperty As String = "Always readonly"
		Public ReadOnly Property ReadOnlyProperty() As String
			Get
				Return _ReadOnlyProperty
			End Get
		End Property
	End Class
End Namespace
