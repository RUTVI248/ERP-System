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

Public Partial Class ipregister
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("Data Source=IPOG-A95E1056D3;database=Hospitalmanagement;User ID=sa;password=sqlserver")
	Protected Sub Page_Load(sender As Object, e As EventArgs)
		If Not Page.IsPostBack Then
			filldrop()
			DropDownList5.Items.Insert(0, "...Select...")
		End If
		Dim dt As String = DateTime.Now.ToShortDateString()
		Dim dtm As String = DateTime.Now.ToShortTimeString()
		TextBox9.Text = dt
		TextBox10.Text = dtm
		cn.Open()
		Dim pid As Integer = 0
		Dim b As Integer = 0
		pid = Convert.ToInt32(New SqlCommand("select patientid from hospital_inpatient order by 1 desc", cn).ExecuteScalar().ToString()) + 1
		b = Convert.ToInt32(New SqlCommand("select admid from hospital_inpatient order by 1 desc", cn).ExecuteScalar().ToString()) + 1
		TextBox2.Text = pid.ToString()
		TextBox8.Text = b.ToString()
		cn.Close()


	End Sub
	Private Sub filldrop()
		cn.Open()
		Dim qry As String = "select name from hospital_doctorsignup"
		Dim da As New SqlDataAdapter(qry, cn)
		Dim ds As New DataSet()
		da.Fill(ds, "hospital_doctorsignup")
		DropDownList5.DataSource = ds
		DropDownList5.DataTextField = "name"
		DropDownList5.DataBind()
		cn.Close()

	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_inpatient"
		cmd.Connection = cn

		Dim p As New SqlParameter("@patientname", SqlDbType.VarChar, 20)
		p.Value = TextBox1.Text
		cmd.Parameters.Add(p)


		Dim p1 As New SqlParameter("@gender", SqlDbType.VarChar, 20)
		p1.Value = DropDownList1.Text
		cmd.Parameters.Add(p1)

		Dim p2 As New SqlParameter("@age", SqlDbType.Int)
		p2.Value = TextBox3.Text
		cmd.Parameters.Add(p2)

		Dim p3 As New SqlParameter("@address", SqlDbType.VarChar, 20)
		p3.Value = TextBox4.Text
		cmd.Parameters.Add(p3)

		Dim p4 As New SqlParameter("@phoneres", SqlDbType.BigInt)
		p4.Value = TextBox5.Text
		cmd.Parameters.Add(p4)

		Dim p5 As New SqlParameter("@phonemob", SqlDbType.BigInt)
		p5.Value = TextBox6.Text
		cmd.Parameters.Add(p5)

		Dim p6 As New SqlParameter("@maritual", SqlDbType.VarChar, 20)
		p6.Value = DropDownList2.Text
		cmd.Parameters.Add(p6)

		Dim p7 As New SqlParameter("@occupation", SqlDbType.VarChar, 20)
		p7.Value = TextBox7.Text
		cmd.Parameters.Add(p7)

		Dim p8 As New SqlParameter("@admid", SqlDbType.Int)
		p8.Value = TextBox8.Text
		cmd.Parameters.Add(p8)

		Dim p9 As New SqlParameter("@admdate", SqlDbType.DateTime)
		p9.Value = TextBox9.Text
		cmd.Parameters.Add(p9)

		Dim p10 As New SqlParameter("@admtime", SqlDbType.DateTime)
		p10.Value = TextBox10.Text
		cmd.Parameters.Add(p10)

		Dim p11 As New SqlParameter("@status", SqlDbType.VarChar, 20)
		p11.Value = DropDownList4.Text
		cmd.Parameters.Add(p11)

		Dim p12 As New SqlParameter("@symtoms", SqlDbType.VarChar, 20)
		p12.Value = TextBox12.Text
		cmd.Parameters.Add(p12)

		Dim p13 As New SqlParameter("@department", SqlDbType.VarChar, 20)
		p13.Value = DropDownList3.Text
		cmd.Parameters.Add(p13)

		Dim p14 As New SqlParameter("@wardno", SqlDbType.Int)
		p14.Value = TextBox14.Text
		cmd.Parameters.Add(p14)

		Dim p15 As New SqlParameter("@bedno", SqlDbType.Int)
		p15.Value = TextBox15.Text
		cmd.Parameters.Add(p15)

		Dim p16 As New SqlParameter("@doctor", SqlDbType.VarChar, 20)
		p16.Value = DropDownList5.Text
		cmd.Parameters.Add(p16)

		cmd.ExecuteNonQuery()
		cn.Close()
		Response.Redirect("doctorsden.aspx")

	End Sub
End Class
