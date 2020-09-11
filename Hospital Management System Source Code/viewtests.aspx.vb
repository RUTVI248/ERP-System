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

Public Partial Class viewtests
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)
		If Not IsPostBack Then
			pttyddl.Items.Insert(0, "---Select---")
			pttyddl.Items.Insert(1, "In-Patient")
			pttyddl.Items.Insert(2, "Out-Patient")
			testddl.Items.Insert(0, "---Select---")
			testddl.Items.Insert(1, "Blood Test")
			testddl.Items.Insert(2, "Urine Test")
		End If

	End Sub


	Protected Sub pttyddl_SelectedIndexChanged(sender As Object, e As EventArgs)
		If True Then


			If pttyddl.SelectedItem.Value = "In-Patient" Then
				Dim cmd As New SqlCommand("select patientid from hospital_inpatient", cn)
				Dim da As New SqlDataAdapter(cmd)
				Dim ds As New DataSet()
				da.Fill(ds)
				pidddl.DataSource = ds
				pidddl.DataTextField = "patientid"
				pidddl.DataBind()
				pidddl.Items.Insert(0, "---Select---")
			ElseIf pttyddl.SelectedItem.Value = "Out-Patient" Then
				Dim cmd As New SqlCommand("select patientid from hospital_outpatient", cn)
				Dim da As New SqlDataAdapter(cmd)
				Dim ds As New DataSet()
				da.Fill(ds)
				pidddl.DataSource = ds
				pidddl.DataTextField = "patientid"
				pidddl.DataBind()

				pidddl.Items.Insert(0, "---Select---")
			End If



		End If

	End Sub
	Protected Sub appbtn_Click(sender As Object, e As EventArgs)

		If testddl.SelectedItem.Value = "Blood Test" Then

			Dim qry As String = "select * from hospital_bloodtest where patientid=" + pidddl.SelectedItem.Value & " "
			Dim da As New SqlDataAdapter(qry, cn)
			Dim ds As New DataSet()
			da.Fill(ds)
			GridView1.DataSource = ds

			GridView1.DataBind()
		ElseIf testddl.SelectedItem.Value = "Urine Test" Then

			Dim qry As String = "select * from hospital_urintest where patientid=" + pidddl.SelectedItem.Value & " "
			Dim da As New SqlDataAdapter(qry, cn)
			Dim ds As New DataSet()
			da.Fill(ds)
			GridView1.DataSource = ds

			GridView1.DataBind()
		End If
	End Sub
	Protected Sub backbtn_Click(sender As Object, e As EventArgs)
		Response.Redirect("doctorsden.aspx")
	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		Response.Redirect("doctorsden.aspx")
	End Sub
End Class
