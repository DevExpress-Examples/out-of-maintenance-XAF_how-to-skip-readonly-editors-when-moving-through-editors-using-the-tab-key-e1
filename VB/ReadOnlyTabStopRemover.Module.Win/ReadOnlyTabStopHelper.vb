Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp

Namespace XAFCommunity.Win
	Public NotInheritable Class ReadOnlyTabStopHelper
		Private Sub New()
		End Sub
		Friend Shared Function GetReadOnlyTabStopSchema() As Schema
			Const schema As String = "<Element Name=""Application"">" & ControlChars.CrLf & "	                <Element Name=""Views"">" & ControlChars.CrLf & "                        <Attribute Name=""TabOverReadOnlyEditors"" Choice=""True,False"" IsNewNode=""True""/>" & ControlChars.CrLf & "	                </Element>" & ControlChars.CrLf & "                </Element>"

			Return New Schema(New DictionaryXmlReader().ReadFromString(schema))
		End Function
	End Class
End Namespace