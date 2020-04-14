Imports System.Data.OleDb
Public Class f
    Dim comando As New OleDbCommand
    Dim dbsource As String = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb"

    Private dv As New DataView
    Private Sub Update_cambium_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Carga los datos de la base de datos en el datagridview1
        Dim cnn As New OleDbConnection(dbsource)
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
        TextBox11.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value().ToString
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value().ToString
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value().ToString
        TextBox10.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value().ToString
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value().ToString
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value().ToString
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value().ToString
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value().ToString
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value().ToString
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(9).Value()
        DateTimePicker2.Value = DataGridView1.Rows(e.RowIndex).Cells(10).Value()
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(11).Value().ToString
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value().ToString
        ComboBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(13).Value().ToString
        ComboBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(14).Value().ToString
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(15).Value().ToString
        'camibo

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim date1 As Date = DateTimePicker1.Value
        Dim date2 As Date = DateTimePicker2.Value

        If TextBox10.Text = "" Or TextBox11.Text = "" Then
            MessageBox.Show("Please select an instrument to update", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try


            Dim id As Integer = Convert.ToInt32(TextBox11.Text)

            Dim cnn As New OleDbConnection(dbsource)
            cnn.Open()
            Dim actualizar As String
            actualizar = "UPDATE Cambium SET [sn]='" & TextBox6.Text & "', [station]='" & TextBox1.Text.ToString & "', [description]='" & TextBox3.Text.ToString & "', [flex_cal_id]='" & TextBox4.Text.ToString & "', [asset]='" & TextBox5.Text.ToString & "', [serial]='" & TextBox7.Text.ToString & "', [status]='" & ComboBox1.Text.ToString & "', [cal_date]='" & date1 & "', [due_date]='" & date2 & "', [repair]='" & ComboBox2.Text.ToString & "', [months]='" & TextBox2.Text.ToString & "', [match]='" & ComboBox4.Text.ToString & "', [comments]='" & TextBox8.Text.ToString & "' WHERE ID=" & id & " AND instrument='" & TextBox10.Text.ToString & "' "
            'actualizar = "UPDATE Cambium SET [sn]='" & TextBox6.Text & "', [station]='" & TextBox1.Text.ToString & "', [description]='" & TextBox3.Text.ToString & "', [flex_cal_id]='" & TextBox4.Text.ToString & "', [asset]='" & TextBox5.Text.ToString & "', [serial]='" & TextBox7.Text.ToString & "', [status]='" & ComboBox1.Text.ToString & "',  [repair]='" & ComboBox2.Text.ToString & "', [months]='" & TextBox2.Text.ToString & "', [match]='" & ComboBox4.Text.ToString & "', [comments]='" & TextBox8.Text.ToString & "' WHERE instrument='" & TextBox10.Text.ToString & "' AND Id= " & id & ""
            comando = New OleDbCommand(actualizar, cnn)
            comando.ExecuteNonQuery()
            MsgBox("The update was successfully.", MsgBoxStyle.Information, "Notification")

            'Dim da As New OleDbDataAdapter("SELECT * FROM Cambium", cnn)
            'Dim ds As New DataSet
            'da.Fill(ds)
            ''DataGridView1.DataSource = ds.Tables(0)
            'dv.Table = ds.Tables(0)
            'DataGridView1.DataSource = dv
            ''DataGridView2.DataSource = dv
            'cnn.Close()
            cnn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        Dim cnn2 As New OleDbConnection(dbsource)
        Dim da As New OleDbDataAdapter("SELECT * FROM Cambium", cnn2)
        Dim ds As New DataSet
        da.Fill(ds)
        'DataGridView1.DataSource = ds.Tables(0)
        dv.Table = ds.Tables(0)
        DataGridView1.DataSource = dv

        cnn2.Close()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class