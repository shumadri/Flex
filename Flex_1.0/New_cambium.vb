Imports System.Data.OleDb
Imports System.Data

Public Class New_cambium

    Dim Con_access As New OleDbConnection
    Dim comando As New OleDbCommand
    Dim adaptador As New OleDbDataAdapter
    Dim datos As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox6.Text = "" Then
            MsgBox("Write a serial number")
            Exit Sub
        End If
        If TextBox1.Text = "" Then
            MsgBox("Write a serial station")
            Exit Sub
        End If



        Try
            Dim conect_string1 As String = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb"
            Dim conect1 As New OleDb.OleDbConnection(conect_string1)
            conect1.Open()

            Dim date1 As Date = DateTimePicker1.Value
            Dim date2 As Date = DateTimePicker2.Value

            Dim query1 As String = "INSERT INTO Cambium ([sn],[station],[instrument],[description],[flex_cal_id],[asset],[serial],[status],[cal_date],[due_date],[repair],[months],[website],[match],[comments],[fecha_carga]) VALUES (@sn1,@station1,@instrument1,@description1,@flex_cal_id1,@asset1,@serial1,@status1,@cal_date1,@due_date1,@repair1,@months1,@website1,@match1,@comments1,@fecha_carga1)"
            Dim Comando1 As New OleDb.OleDbCommand(query1, conect1)

            Comando1.Parameters.AddWithValue("@sn1", TextBox6.Text)
            Comando1.Parameters.AddWithValue("@station1", TextBox1.Text)
            Comando1.Parameters.AddWithValue("@instrument1", ComboBox5.Text)
            Comando1.Parameters.AddWithValue("@description1", TextBox3.Text)
            Comando1.Parameters.AddWithValue("@flex_cal_id1", TextBox4.Text)
            Comando1.Parameters.AddWithValue("@asset1", TextBox5.Text)
            Comando1.Parameters.AddWithValue("@serial1", TextBox7.Text)
            Comando1.Parameters.AddWithValue("@status1", ComboBox1.Text)
            Comando1.Parameters.AddWithValue("@cal_date1", date1)
            Comando1.Parameters.AddWithValue("@due_date1", date2)
            Comando1.Parameters.AddWithValue("@repair1", ComboBox2.Text)
            Comando1.Parameters.AddWithValue("@months1", TextBox2.Text)
            Comando1.Parameters.AddWithValue("@website1", ComboBox3.Text)
            Comando1.Parameters.AddWithValue("@match1", ComboBox4.Text)
            Comando1.Parameters.AddWithValue("@comments1", ComboBox4.Text)
            Comando1.Parameters.AddWithValue("@fecha_carga1", DateTime.Now.ToString("dd/MM/yyyy") & " " & DateTime.Now.ToLongTimeString)
            Comando1.ExecuteNonQuery()
            conect1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub New_cambium_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Con_access.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb"
            Con_access.Open()
            comando.Connection = Con_access
            comando.CommandType = CommandType.Text
            comando.CommandText = "SELECT * FROM RecommendedCalibrationInterval"
            adaptador.SelectCommand = comando
            adaptador.Fill(datos)
            Me.ComboBox5.DataSource = datos
            Me.ComboBox5.DisplayMember = "Instrument"
            Me.ComboBox5.ValueMember = "Id"
            Me.ComboBox5.ResetText()
            Me.ComboBox5.SelectedText = "Select Instrument"
            Con_access.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'MessageBox.Show("Problema al conectar a BD")
        End Try

        ComboBox1.Text = ""
    End Sub

    Private Sub ComboBox5_TextChanged(sender As Object, e As EventArgs) Handles ComboBox5.TextChanged
        If ComboBox5.Text = "Select Instrument" Then
            TextBox2.Text = ""

        End If

        Try

            Dim cadenaconexion As String
            cadenaconexion = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb"
            Dim miconexion As OleDbConnection
            miconexion = New OleDbConnection(cadenaconexion)

            Dim PNtableadapter As OleDbDataAdapter
            PNtableadapter = New OleDbDataAdapter

            PNtableadapter.SelectCommand = New OleDbCommand("SELECT * FROM RecommendedCalibrationInterval WHERE Instrument = '" & ComboBox5.Text & "'", miconexion)
            Dim PNdataset As DataSet
            PNdataset = New DataSet

            PNdataset.Tables.Add("RecommendedCalibrationInterval")
            PNtableadapter.Fill(PNdataset.Tables("RecommendedCalibrationInterval"))

            TextBox2.DataBindings.Clear()
            TextBox2.DataBindings.Add("Text", PNdataset.Tables("RecommendedCalibrationInterval"), "Campo2")

            'TextBox15.DataBindings.Clear()
            'TextBox15.DataBindings.Add("Text", PNdataset.Tables("Part_Number"), "Filler")

            'ComboBox1.DataBindings.Clear()
            'ComboBox1.DataBindings.Add("Text", PNdataset.Tables("Part_Number"), "Cant_Pares")



            miconexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ' MessageBox.Show("Sucedio un error al cargar los datos, por favor vuelva a intentar")
        End Try
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        If TextBox2.Text = "12" Then
            DateTimePicker2.Value = DateTimePicker1.Value.AddMonths(12)
            ComboBox1.Text = ""
        End If

        If TextBox2.Text = "24" Then
            DateTimePicker2.Value = DateTimePicker1.Value.AddMonths(24)
            ComboBox1.Text = ""
        End If

        If TextBox2.Text = "NoRequired" Then
            ComboBox1.Text = "NoRequired"
        End If

    End Sub
End Class