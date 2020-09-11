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

Public Partial Class pharmacy
	Inherits System.Web.UI.Page
	Private cn As New SqlConnection("server=IPOG-A95E1056D3;user id=sa;password=sqlserver;database=Hospitalmanagement")
	Protected Sub Page_Load(sender As Object, e As EventArgs)




	End Sub
	Protected Sub Button1_Click(sender As Object, e As EventArgs)
		cn.Open()
		Dim cmd As New SqlCommand()
		cmd.CommandType = CommandType.StoredProcedure
		cmd.CommandText = "sp_hospital_pharmacy"
		cmd.Connection = cn
		Dim p As New SqlParameter("@patienttype", SqlDbType.VarChar, 20)
		p.Value = ptntyp.Text
		cmd.Parameters.Add(p)
		Dim p1 As New SqlParameter("@patientid", SqlDbType.Int)
		p1.Value = ptntid.Text
		cmd.Parameters.Add(p1)
		Dim p2 As New SqlParameter("@department", SqlDbType.VarChar, 20)
		p2.Value = dpt.Text
		cmd.Parameters.Add(p2)
		Dim p3 As New SqlParameter("@patientname", SqlDbType.VarChar, 20)
		p3.Value = ptntname.Text
		cmd.Parameters.Add(p3)
		Dim p4 As New SqlParameter("@medicine", SqlDbType.VarChar, 20)
		p4.Value = mdcnusd.Text
		cmd.Parameters.Add(p4)
		cmd.ExecuteNonQuery()
		cn.Close()

	End Sub
	Protected Sub DropDownList3_SelectedIndexChanged(sender As Object, e As EventArgs)
		cn.Open()
		If ptntyp.SelectedItem.Value = "In-Patient" Then

			Dim qry As String = "select patientid from hospital_inpatient"
			'qry = qry + " union all select '...select...' order by 1";
			Dim da As New SqlDataAdapter(qry, cn)
			Dim ds As New DataSet()
			da.Fill(ds, "hospital_inpatient")
			ptntid.DataSource = ds
			ptntid.DataTextField = "patientid"
			ptntid.DataBind()



			ptntid.Items.Insert(0, "...Select...")
		ElseIf ptntyp.SelectedItem.Value = "Out-Patient" Then
			Dim qry As String = "select patientid from hospital_outpatient"
			Dim da As New SqlDataAdapter(qry, cn)
			Dim ds As New DataSet()
			da.Fill(ds, "hospital_outpatient")
			ptntid.DataSource = ds
			ptntid.DataTextField = "patientid"
			ptntid.DataBind()
			ptntid.Items.Insert(0, "...Select...")
		ElseIf ptntyp.SelectedItem.Value = "...Select..." Then
			Response.Redirect("pharmacy.aspx")
		End If
		cn.Close()
	End Sub
	Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)

		If ptntyp.SelectedItem.Value = "In-Patient" Then
			cn.Open()
			Dim Cmd As New SqlCommand("select department,patientname  from hospital_inpatient WHERE patientid ='" + ptntid.SelectedValue & "'", cn)
			Dim dr As SqlDataReader = Cmd.ExecuteReader()
			If dr.Read() Then
				dpt.Text = dr(0).ToString()
				ptntname.Text = dr(1).ToString()
			End If
			dr.Close()
			cn.Close()
		ElseIf ptntyp.SelectedItem.Value = "Out-Patient" Then
			cn.Open()
			Dim Cmd As New SqlCommand("select department,patientname  from hospital_outpatient WHERE patientid ='" + ptntid.SelectedValue & "'", cn)
			Dim dr As SqlDataReader = Cmd.ExecuteReader()
			If dr.Read() Then
				dpt.Text = dr(0).ToString()
				ptntname.Text = dr(1).ToString()
			End If
			dr.Close()
			cn.Close()
		End If



	End Sub
	Protected Sub Button2_Click(sender As Object, e As EventArgs)
		Response.Redirect("pharmacy.aspx")
	End Sub
End Class
