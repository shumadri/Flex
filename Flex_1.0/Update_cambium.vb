Imports System.Data.OleDb
Public Class f
    Private dv As New DataView
    Private Sub Update_cambium_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Carga los datos de la base de datos en el datagridview1
        Dim cnn As New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb")
        Dim da As New OleDbDataAdapter("SELECT * FROM Cambium", cnn)
        Dim ds As New DataSet
        da.Fill(ds)
        'DataGridView1.DataSource = ds.Tables(0)
        dv.Table = ds.Tables(0)
        DataGridView1.DataSource = dv
        'DataGridView2.DataSource = dv
        cnn.Close()

        Label17.Text = DateTime.Now.ToString("dd/MM/yyyy") & " " & DateTime.Now.ToLongTimeString
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        dv.RowFilter = String.Format("instrument like '%{0}%'", TextBox9.Text)
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value()
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value()
        TextBox10.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value()
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value()
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value()
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value()
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value()
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value()
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(9).Value()
        DateTimePicker2.Value = DataGridView1.Rows(e.RowIndex).Cells(10).Value()
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(11).Value()
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value()
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(13).Value()
        ComboBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(14).Value()
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(15).Value()




    End Sub
End Class