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

Public Partial Class dischargesummary
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)
		If Not Page.IsPostBack Then
			cn.Open()
			Dim qry As String = "select patientid from hospital_outpatient"
			Dim da As New SqlDataAdapter(qry, cn)
			Dim ds As New DataSet()
			da.Fill(ds, "hospital_outpatient")
			PID.DataSource = ds
			PID.DataTextField = "patientid"
			PID.DataBind()
			cn.Close()
			Calendar1.Visible = False
			PID.Items.Insert(0, "...Select...")
		End If


	End Sub
	Protected Sub Button2_Click(sender As Object, e As EventArgs)
		Calendar1.Visible = True
	End Sub
	Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs)
		TextBox3.Text = Calendar1.SelectedDate.ToShortDateString()
		Calendar1.Visible = False
	End Sub
	Protected Sub PID_SelectedIndexChanged(sender As Object, e As EventArgs)
		cn.Open()
		Dim Cmd As New SqlCommand("select patientname,opdate from hospital_outpatient WHERE patientid ='" + PID.SelectedValue & "'", cn)
		Dim dr As SqlDataReader = Cmd.ExecuteReader()
		If dr.Read() Then
			TextBox1.Text = dr(0).ToString()
			TextBox2.Text = dr(1).ToString()
		End If
		dr.Close()
		cn.Close()
	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_dischargesummary"
		cmd.Connection = cn

		Dim p As New SqlParameter("@patientid", SqlDbType.Int)
		p.Value = PID.Text
		cmd.Parameters.Add(p)
		Dim p1 As New SqlParameter("@patientname", SqlDbType.VarChar, 20)
		p1.Value = TextBox1.Text
		cmd.Parameters.Add(p1)
		Dim p2 As New SqlParameter("@joindate", SqlDbType.VarChar, 20)
		p2.Value = TextBox2.Text
		cmd.Parameters.Add(p2)
		Dim p3 As New SqlParameter("@dischargedate", SqlDbType.VarChar, 20)
		p3.Value = TextBox3.Text
		cmd.Parameters.Add(p3)
		cmd.ExecuteNonQuery()
		cn.Close()
	End Sub
	Protected Sub Button3_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim qry As String = "select * from hospital_dischargesummary"
		Dim da As New SqlDataAdapter(qry, cn)
		Dim ds As New DataSet()
		da.Fill(ds)
		GridView1.DataSource = ds
		GridView1.DataBind()

		cn.Close()
	End Sub
End Class
