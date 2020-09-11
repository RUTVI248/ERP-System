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

Public Partial Class operationth
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)
		If Not IsPostBack Then
		End If
	End Sub


	Protected Sub pttypeddl_SelectedIndexChanged(sender As Object, e As EventArgs)

		cn.Open()
		If pttypeddl.SelectedItem.Value = "In-Patient" Then
			Dim cmd As New SqlCommand("select patientid from hospital_inpatient", cn)
			Dim da As New SqlDataAdapter(cmd)
			Dim ds As New DataSet()
			da.Fill(ds)
			pidddl.DataSource = ds
			pidddl.DataTextField = "patientid"
			pidddl.DataBind()
			pidddl.Items.Insert(0, "...Select...")
		ElseIf pttypeddl.SelectedItem.Value = "Out-Patient" Then
			Dim cmd As New SqlCommand("select patientid from hospital_outpatient", cn)
			Dim da As New SqlDataAdapter(cmd)
			Dim ds As New DataSet()
			da.Fill(ds)
			pidddl.DataSource = ds
			pidddl.DataTextField = "patientid"
			pidddl.DataBind()
			pidddl.Items.Insert(0, "...Select...")
		End If

		cn.Close()
	End Sub
	Protected Sub pidddl_SelectedIndexChanged(sender As Object, e As EventArgs)


		If pttypeddl.SelectedItem.Value = "In-Patient" Then
			cn.Open()
			Dim cmd As New SqlCommand("select patientname,doctor from hospital_inpatient where patientid='" + pidddl.Text & "'", cn)
			Dim dr As SqlDataReader = cmd.ExecuteReader()
			If dr.Read() Then
				pntxt.Text = dr(0).ToString()
				doctxt.Text = dr(1).ToString()
			End If

			cn.Close()
		ElseIf pttypeddl.SelectedItem.Value = "Out-Patient" Then
			cn.Open()
			Dim cmd As New SqlCommand("select patientname,assigndoctor from hospital_outpatient where patientid='" + pidddl.Text & "'", cn)
			Dim dr As SqlDataReader = cmd.ExecuteReader()
			If dr.Read() Then
				pntxt.Text = dr(0).ToString()
				doctxt.Text = dr(1).ToString()
			End If
			cn.Close()
		End If

	End Sub

	Protected Sub sbtn_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_operation"
		cmd.Connection = cn

		Dim p As New SqlParameter("@patienttype", SqlDbType.VarChar, 20)
		p.Value = pttypeddl.Text
		cmd.Parameters.Add(p)

		Dim p1 As New SqlParameter("@patientid", SqlDbType.Int)
		p1.Value = pidddl.Text
		cmd.Parameters.Add(p1)

		Dim p2 As New SqlParameter("@patientname", SqlDbType.VarChar, 20)
		p2.Value = pntxt.Text
		cmd.Parameters.Add(p2)

		Dim p3 As New SqlParameter("@refdoctor", SqlDbType.VarChar, 20)
		p3.Value = doctxt.Text
		cmd.Parameters.Add(p3)

		Dim p4 As New SqlParameter("@operationtype", SqlDbType.VarChar, 20)
		p4.Value = optddl.Text
		cmd.Parameters.Add(p4)

		Dim p5 As New SqlParameter("@operatonresult", SqlDbType.VarChar, 20)
		p5.Value = orddl.Text
		cmd.Parameters.Add(p5)

		cmd.ExecuteNonQuery()
		cn.Close()
		Response.Redirect("laborataries.aspx")

	End Sub
End Class
