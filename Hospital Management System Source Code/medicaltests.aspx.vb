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

Public Partial Class medicaltests
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)
		If Not IsPostBack Then
			Panel1.Visible = False


			Panel2.Visible = False
		End If
	End Sub

	Protected Sub mttddl_SelectedIndexChanged(sender As Object, e As EventArgs)

	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		If mttddl.SelectedValue = "Blood Test" Then
			Panel1.Visible = True
		Else
			Panel2.Visible = True
		End If
	End Sub
	Protected Sub pidddl_SelectedIndexChanged(sender As Object, e As EventArgs)
		cn.Open()
		If pttypeddl.SelectedItem.Value = "In-Patient" Then

			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = "sp_hospital_medicaltest"
			cmd.Connection = cn

			Dim p As New SqlParameter("@pid", SqlDbType.Int)
			p.Value = pidddl.SelectedValue.ToString()
			cmd.Parameters.Add(p)

			Dim dr As SqlDataReader = cmd.ExecuteReader()
			If dr.Read() Then
				pntxt.Text = dr(0).ToString()
			End If
		ElseIf pttypeddl.SelectedItem.Value = "Out-Patient" Then
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = "sp_hospital_medicaltestout"
			cmd.Connection = cn

			Dim p As New SqlParameter("@pid", SqlDbType.Int)
			p.Value = pidddl.SelectedValue.ToString()
			cmd.Parameters.Add(p)

			Dim dr As SqlDataReader = cmd.ExecuteReader()
			If dr.Read() Then
				pntxt.Text = dr(0).ToString()
			End If
		End If
		cn.Close()
	End Sub
	Protected Sub pttypeddl_SelectedIndexChanged(sender As Object, e As EventArgs)
		cn.Open()
		If pttypeddl.SelectedItem.Value = "In-Patient" Then

			Dim qry As String
			qry = "select patientid from hospital_inpatient"
			Dim da As New SqlDataAdapter(qry, cn)
			Dim ds As New DataSet()
			da.Fill(ds, "hospital_inpatient")
			pidddl.DataSource = ds
			pidddl.DataTextField = "patientid"
			pidddl.DataBind()

			pidddl.Items.Insert(0, "...Select...")
		ElseIf pttypeddl.SelectedItem.Value = "Out-Patient" Then

			Dim qry As String
			qry = "select patientid from hospital_outpatient"
			Dim da As New SqlDataAdapter(qry, cn)
			Dim ds As New DataSet()
			da.Fill(ds, "hospital_outpatient")
			pidddl.DataSource = ds
			pidddl.DataTextField = "patientid"
			pidddl.DataBind()


			pidddl.Items.Insert(0, "...Select...")
		Else
			Response.Write("excute")
		End If
		cn.Close()
	End Sub
	Protected Sub Button2_Click(sender As Object, e As EventArgs)
		If Panel1.Visible = True Then
			cn.Open()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = "sp_hospital_bloodtest"
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

			Dim p3 As New SqlParameter("@mediclatestype", SqlDbType.VarChar, 20)
			p3.Value = mttddl.Text
			cmd.Parameters.Add(p3)

			Dim p4 As New SqlParameter("@bloodgroup", SqlDbType.VarChar, 20)
			p4.Value = bgtxt.Text
			cmd.Parameters.Add(p4)

			Dim p5 As New SqlParameter("@haemoglobin", SqlDbType.VarChar, 20)
			p5.Value = hmtxt.Text
			cmd.Parameters.Add(p5)

			Dim p6 As New SqlParameter("@bloodsugar", SqlDbType.VarChar, 20)
			p6.Value = bstxt.Text
			cmd.Parameters.Add(p6)

			Dim p7 As New SqlParameter("@sacid", SqlDbType.VarChar, 20)
			p7.Value = suatxt.Text
			cmd.Parameters.Add(p7)

			Dim p8 As New SqlParameter("@description", SqlDbType.VarChar, 20)
			p8.Value = rd1txt.Text
			cmd.Parameters.Add(p8)

			cmd.ExecuteNonQuery()
			cn.Close()
		ElseIf Panel2.Visible = True Then
			cn.Open()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = "sp_hospital_urintest"
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

			Dim p3 As New SqlParameter("@mediclatestype", SqlDbType.VarChar, 20)
			p3.Value = mttddl.Text
			cmd.Parameters.Add(p3)

			Dim p4 As New SqlParameter("@color", SqlDbType.VarChar, 20)
			p4.Value = colortxt.Text
			cmd.Parameters.Add(p4)

			Dim p5 As New SqlParameter("@clarity", SqlDbType.VarChar, 20)
			p5.Value = clartxt.Text
			cmd.Parameters.Add(p5)

			Dim p6 As New SqlParameter("@odor", SqlDbType.VarChar, 20)
			p6.Value = odtxt.Text
			cmd.Parameters.Add(p6)

			Dim p7 As New SqlParameter("@specificgravity", SqlDbType.VarChar, 20)
			p7.Value = sgtxt.Text
			cmd.Parameters.Add(p7)

			Dim p8 As New SqlParameter("@glucose", SqlDbType.VarChar, 20)
			p8.Value = gltxt.Text
			cmd.Parameters.Add(p8)

			Dim p9 As New SqlParameter("@description", SqlDbType.VarChar, 40)
			p9.Value = rd2txt.Text
			cmd.Parameters.Add(p9)

			cmd.ExecuteNonQuery()
			cn.Close()
		End If
		Response.Redirect("laborataries.aspx")
	End Sub
	Protected Sub Button3_Click(sender As Object, e As EventArgs)
		Response.Redirect("laborataries.aspx")
	End Sub
End Class
