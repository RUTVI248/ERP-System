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

Public Partial Class viewappointments
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)

		If Not Page.IsPostBack Then
			filldrop()
			doctorddl.Items.Insert(0, "...Select...")
		End If
	End Sub
	Private Sub filldrop()
		cn.Open()
		Dim qry As String = "select name from hospital_doctorsignup"
		Dim da As New SqlDataAdapter(qry, cn)
		Dim ds As New DataSet()
		da.Fill(ds, "hospital_doctorsignup")
		doctorddl.DataSource = ds
		doctorddl.DataTextField = "name"
		doctorddl.DataBind()
		cn.Close()

	End Sub

	Protected Sub doctorddl_SelectedIndexChanged(sender As Object, e As EventArgs)
	End Sub
	Protected Sub appbtn_Click(sender As Object, e As EventArgs)
		cn.Open()
		'string str = doctorddl.SelectedItem.ToString();
		Dim qry As String = "select * from hospital_patientinfo where doctor='" + doctorddl.SelectedValue & "' "
		Dim da As New SqlDataAdapter(qry, cn)
		Dim ds As New DataSet()
		da.Fill(ds)
		GridView1.DataSource = ds
		GridView1.DataBind()
		cn.Close()
	End Sub
	Protected Sub backbtn_Click(sender As Object, e As EventArgs)
		Response.Redirect("doctorsden.aspx")
	End Sub
End Class
