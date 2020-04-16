Public Class New_Cambium_Basic

    'Dim dbsource As String = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb"
    Dim dbsource As String = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dan25\source\repos\Flex2\Flex_1.0\Flex_DB.mdb"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim conect_string2 As String = dbsource
            Dim conect2 As New OleDb.OleDbConnection(conect_string2)
            conect2.Open()

            Dim query2 As String = "INSERT INTO RecommendedCalibrationInterval ([Instrument],[Campo2],[Campo3]) VALUES (@snInstrument,@Campo2,@Campo3)"
            Dim Comando2 As New OleDb.OleDbCommand(query2, conect2)

            Comando2.Parameters.AddWithValue("@Instrument", TextBox2.Text)
            Comando2.Parameters.AddWithValue("@Campo2", ComboBox1.Text)
            Comando2.Parameters.AddWithValue("@Campo3", TextBox3.Text)


            Comando2.ExecuteNonQuery()
            conect2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub New_Cambium_Basic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class