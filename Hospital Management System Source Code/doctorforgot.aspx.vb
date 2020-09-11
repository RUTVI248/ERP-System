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

Public Partial Class doctorforgot
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)
		Panel1.Visible = False
	End Sub
	Protected Sub pwdbtn_Click(sender As Object, e As EventArgs)
		Panel1.Visible = True
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_doctorforgot"
		cmd.Connection = cn

		Dim p As New SqlParameter("@loginid", SqlDbType.VarChar, 20)
		p.Value = lidtxt.Text
		cmd.Parameters.Add(p)

		Dim p1 As New SqlParameter("@password", SqlDbType.VarChar, 20)
		p1.Direction = ParameterDirection.Output
		cmd.Parameters.Add(p1)

		cmd.ExecuteReader()
		pwdtxt.Text = cmd.Parameters("@password").Value.ToString()

	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		Response.Redirect("doctorlogin.aspx")
	End Sub
End Class
