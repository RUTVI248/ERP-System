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

Public Partial Class patientinfo
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("Data Source=IPOG-A95E1056D3;database=Hospitalmanagement;User ID=sa;password=sqlserver")
	Protected Sub Page_Load(sender As Object, e As EventArgs)

	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		If type.SelectedItem.Value = "In-Patient" Then
			Dim Da As New SqlDataAdapter("select * from hospital_inpatient where patientid=" + TextBox1.Text & "", cn)
			'SqlCommandBuilder Cmd = new SqlCommandBuilder(Da);
			Dim Ds As New DataSet()
			Da.Fill(Ds, "hospital_inpatient")
			GridView1.DataSource = Ds.Tables(0)
			GridView1.DataBind()
		Else

			Dim Da As New SqlDataAdapter("select * from hospital_outpatient where patientid=" + TextBox1.Text & "", cn)
			'SqlCommandBuilder Cmd = new SqlCommandBuilder(Da);
			Dim Ds1 As New DataSet()
			Da.Fill(Ds1, "hospital_outpatient")
			GridView1.DataSource = Ds1.Tables(0)
			GridView1.DataBind()
		End If


	End Sub
	Protected Sub Button2_Click(sender As Object, e As EventArgs)
		Response.Redirect("doctorsden.aspx")
	End Sub
End Class



