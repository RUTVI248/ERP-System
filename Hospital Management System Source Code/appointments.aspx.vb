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

Public Partial Class reception
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)

		If Not Page.IsPostBack Then
			filldrop()
			pidddl.Items.Insert(0, "...Select...")
		End If

	End Sub
	Private Sub filldrop()
		cn.Open()
		Dim qry As String
		qry = "select patientid from hospital_inpatient"
		Dim da As New SqlDataAdapter(qry, cn)
		Dim ds As New DataSet()
		da.Fill(ds, "hospital_inpatient")
		pidddl.DataSource = ds
		pidddl.DataTextField = "patientid"
		pidddl.DataBind()

		cn.Close()
	End Sub


	Protected Sub pidddl_SelectedIndexChanged(sender As Object, e As EventArgs)
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_patientinfo"
		cmd.Connection = cn

		Dim p As New SqlParameter("@pid", SqlDbType.Int)
		p.Value = pidddl.Text
		cmd.Parameters.Add(p)

		Dim p1 As New SqlParameter("@patientname", SqlDbType.VarChar, 20)
		p1.Direction = ParameterDirection.Output
		cmd.Parameters.Add(p1)

		Dim p2 As New SqlParameter("@age", SqlDbType.Int)
		p2.Direction = ParameterDirection.Output
		cmd.Parameters.Add(p2)

		Dim p3 As New SqlParameter("@department", SqlDbType.VarChar, 20)
		p3.Direction = ParameterDirection.Output
		cmd.Parameters.Add(p3)

		cmd.ExecuteReader()
		pntxt.Text = cmd.Parameters("@patientname").Value.ToString()
		agtxt.Text = cmd.Parameters("@age").Value.ToString()
		deptxt.Text = cmd.Parameters("@department").Value.ToString()
		cn.Close()
	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_patientinfoenter"
		cmd.Connection = cn

		Dim pd As New SqlParameter("@pid", SqlDbType.VarChar, 20)
		pd.Value = pidddl.SelectedItem.Text
		cmd.Parameters.Add(pd)

		Dim pname As New SqlParameter("@patientname", SqlDbType.VarChar, 20)
		pname.Value = pntxt.Text
		cmd.Parameters.Add(pname)

		Dim age As New SqlParameter("@age", SqlDbType.Int)
		age.Value = agtxt.Text
		cmd.Parameters.Add(age)

		Dim dep As New SqlParameter("@department", SqlDbType.VarChar, 20)
		dep.Value = deptxt.Text
		cmd.Parameters.Add(dep)

		Dim doct As New SqlParameter("@doctor", SqlDbType.VarChar, 20)
		doct.Value = doctxt.Text
		cmd.Parameters.Add(doct)

		cmd.ExecuteNonQuery()
		cn.Close()

		Response.Redirect("receptionhome.aspx")
	End Sub
	Protected Sub Button2_Click(sender As Object, e As EventArgs)
		Response.Redirect("receptionhome.aspx")
	End Sub
End Class
