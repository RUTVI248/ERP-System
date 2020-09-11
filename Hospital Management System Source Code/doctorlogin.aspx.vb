Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient

Public Partial Class doctorlogin
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Private dr As SqlDataReader
	Protected Sub Page_Load(sender As Object, e As EventArgs)

	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim qry As String
		qry = ("select * from hospital_doctorsignup where loginid='" + lidtxt.Text & "' and password='") + pwdtxt.Text & "'"
		Dim cmd As New SqlCommand(qry, cn)
		dr = cmd.ExecuteReader()
		If dr.Read() Then
			Response.Redirect("doctorsden.aspx")
		Else
			pwdlb.Text = "Enter valid UserName/Password"
		End If
	End Sub
End Class
