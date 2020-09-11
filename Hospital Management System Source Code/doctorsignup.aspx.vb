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

Public Partial Class doctorsignup
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)

	End Sub
	Protected Sub subbtn_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_doctorsignup"
		cmd.Connection = cn


		Dim p As New SqlParameter("@name", SqlDbType.VarChar, 20)
		p.Value = nametxt.Text
		cmd.Parameters.Add(p)

		Dim p1 As New SqlParameter("@loginid", SqlDbType.VarChar, 20)
		p1.Value = lidtxt.Text
		cmd.Parameters.Add(p1)

		Dim p2 As New SqlParameter("@password", SqlDbType.VarChar, 20)
		p2.Value = pwdtxt.Text
		cmd.Parameters.Add(p2)

		Dim p3 As New SqlParameter("@department", SqlDbType.VarChar, 20)
		p3.Value = depddl.Text
		cmd.Parameters.Add(p3)

		Dim p4 As New SqlParameter("@specialization", SqlDbType.VarChar, 20)
		p4.Value = speddl.Text
		cmd.Parameters.Add(p4)

		Dim p5 As New SqlParameter("@phonenumber", SqlDbType.BigInt)
		p5.Value = phtxt.Text
		cmd.Parameters.Add(p5)

		Dim p6 As New SqlParameter("@address", SqlDbType.VarChar, 20)
		p6.Value = addtxt.Text
		cmd.Parameters.Add(p6)

		Dim p7 As New SqlParameter("@email", SqlDbType.VarChar, 20)
		p7.Value = emtxt.Text
		cmd.Parameters.Add(p7)

		cmd.ExecuteNonQuery()
		cn.Close()
		Response.Redirect("doctorlogin.aspx")

	End Sub
	Protected Sub Resbtn_Click(sender As Object, e As EventArgs)
		Response.Redirect("doctorsignup.aspx")
	End Sub
	Protected Sub canbtn_Click(sender As Object, e As EventArgs)
		Response.Redirect("doctorlogin.aspx")
	End Sub
End Class
