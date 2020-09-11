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
	Private dt As String = DateTime.Now.ToShortDateString()
	Protected Sub Page_Load(sender As Object, e As EventArgs)

		optxt.Text = dt
	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_outpatient"
		cmd.Connection = cn

		Dim p As New SqlParameter("@patientname", SqlDbType.VarChar, 20)
		p.Value = pntxt.Text
		cmd.Parameters.Add(p)

		Dim p1 As New SqlParameter("@gender", SqlDbType.VarChar, 20)
		p1.Value = gddl.Text
		cmd.Parameters.Add(p1)

		Dim p2 As New SqlParameter("@age", SqlDbType.Int)
		p2.Value = agetxt.Text
		cmd.Parameters.Add(p2)

		Dim p3 As New SqlParameter("@address", SqlDbType.VarChar, 20)
		p3.Value = addtxt.Text
		cmd.Parameters.Add(p3)

		Dim p4 As New SqlParameter("@assigndoctor", SqlDbType.VarChar, 20)
		p4.Value = doctorddl.Text
		cmd.Parameters.Add(p4)

		Dim p5 As New SqlParameter("@phoneres", SqlDbType.BigInt)
		p5.Value = restxt.Text
		cmd.Parameters.Add(p5)

		Dim p6 As New SqlParameter("@phonemob", SqlDbType.BigInt)
		p6.Value = mobtxt.Text
		cmd.Parameters.Add(p6)

		Dim p7 As New SqlParameter("@opdate", SqlDbType.DateTime)
		p7.Value = optxt.Text
		cmd.Parameters.Add(p7)

		Dim p8 As New SqlParameter("@department", SqlDbType.VarChar, 20)
		p8.Value = depddl.Text
		cmd.Parameters.Add(p8)

		cmd.ExecuteNonQuery()
		cn.Close()

		Response.Redirect("outpatient.aspx")
	End Sub
End Class
