Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo

Namespace ReadOnlyTabStopRemover.Module
	<NavigationItem(True)> _
	Public Class Detail
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)

		End Sub

		#Region "DocumentNumber"

		Private _property As String

		<Size(10)> _
		Public Property DocumentNumber() As String
			Get
				Return _property
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("DocumentNumber", _property, value)
			End Set
		End Property

		#End Region

		#Region "DocumentNumberRO"

		Public ReadOnly Property DocumentNumberRO() As String
			Get
				Return Me.DocumentNumber
			End Get
		End Property

		#End Region

		#Region "DocumentReference"

		Private _documentReference As String

		<Size(10)> _
		Public Property DocumentReference() As String
			Get
				Return _documentReference
			End Get
			Set(ByVal value As String)
				SetPropertyValue(Of String)("DocumentReference", _documentReference, value)
			End Set
		End Property

		#End Region

		#Region "DocumentReferenceRO"

		Public ReadOnly Property DocumentReferenceRO() As String
			Get
				Return Me.DocumentReference
			End Get
		End Property

		#End Region

		#Region "DocumentDate"

		Private _documentDate As DateTime

		Public Property DocumentDate() As DateTime
			Get
				Return _documentDate
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue(Of DateTime)("DocumentDate", _documentDate, value)
			End Set
		End Property

		#End Region

		#Region "DocumentDateRO"

		Public ReadOnly Property DocumentDateRO() As DateTime
			Get
				Return Me.DocumentDate
			End Get
		End Property

		#End Region
	End Class
End Namespace
