Imports System.Data.OleDb
Public Class CambiumDB
    Private dv As New DataView
    Dim comandosql As New OleDbCommand

    Dim db As New Menu

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ''TextBox1.Text = DateDiff(DateInterval.Day, DateTimePicker1.Value, DateTimePicker2.Value)
        'conexion()

        'Dim date1 As Date = txtnorequired.Text
        'Dim date2 As Date = TextBox2.Text


        'TextBox3.Text = DateDiff(DateInterval.Day, date1, date2)
        'TextBox4.Text = DateTimePicker1.Value

        'Dim cont As Integer = 0
        ''recorre el grid fila por fila
        'For Each r As DataGridViewRow In DataGridView1.Rows

        '    'en cells() va el indice de la columna que quiere verificar que tenga datos
        '    If r.Cells(6).Value = "TG0299" Then
        '        cont += 1
        '    End If
        'Next
        'TextBox5.Text = cont

        'DateTimePicker2.Value = DateTimePicker1.Value.AddMonths(24)  'Colocar validacion dependiendo de los meses (12 o 24), verificar accion al usar no required.




    End Sub

    Private Sub CambiumDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Flex_DBDataSet.Cambium' table. You can move, or remove it, as needed.
        'Me.CambiumTableAdapter.Fill(Me.Flex_DBDataSet.Cambium)

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



        ProgressBar1.Value = "70"
        lblfecha.Text = DateTime.Now.ToString("MM/dd/yyyy")

        RecorrerDGVcambium()

    End Sub

    Private Sub RecorrerDGVcambium()

        Dim contpasdue As Integer = 0
        Dim contnorequired As Integer = 0
        Dim contontime As Integer = 0
        Dim contotal As Integer = 0
        Dim contoffline As Integer = 0
        Dim date1 As Date = DateTime.Now.ToString("MM/dd/yyyy")
        Dim date2 As Date
        Dim porcentaje As Integer = 0


        'Norequired
        'Offline
        'Offline
        'Offline
        'Offline
        'Offline
        'PastDue
        'Ontime
        'Conexion a base de datos.



        'Algoritmo----------------------------------------------------
        '##### Este algoritmo solo actualizara los registros de las fechas.
        'Verificar si a status es "NOrequired" y brincar a otro registro
        'Verifica si la fecha del registro es mayor a la fecha del dia actual si lo es actualiza el registro de la base de datos a "pastdue" y sino se actualizara a "ontime"

        'Inicio de codigo......
        For Each r As DataGridViewRow In DataGridView1.Rows
            txtID.Text = r.Cells(0).Value()
            date2 = r.Cells(10).Value()
            ' Dim id As String = r.Cells(0).Value()
            'En cells() va el indice de la columna que quiere verificar que tenga datos
            If r.Cells(8).Value = "Norequired" Then
                contnorequired += 1   'Cuenta la cantidad de veces que apare "Norequired"
            Else
                If r.Cells(8).Value = "Offline" Then
                    contoffline += 1   'Cuenta la cantidad de veces que apare "Offline"
                Else
                    If date1 > date2 Then
                        'Dim id As String = r.Cells(0).Value
                        SQLUPdateCambium()

                    End If

                End If
            End If




            'If r.Cells(6).Value = "Offline" Then
            '    contoffline += 1   'Cuenta la cantidad de veces que apare "Offline"
            'End If

            'If r.Cells(10).Value > DateTime.Now.ToString("dd/MM/yyyy") Then
            '    txtID.Text = r.Cells(0).Value
            '    SQLUPdateCambium()
            'End If
        Next

        actualizardgv()


        For Each r As DataGridViewRow In DataGridView1.Rows
            'en cells() va el indice de la columna que quiere verificar que tenga datos
            If r.Cells(8).Value = "PastDue" Then
                contpasdue += 1
            End If

            If r.Cells(8).Value = "Ontime" Then
                contontime += 1
            End If

            contotal += 1

        Next


        txtnorequired.Text = contnorequired
        txtontime.Text = contontime
        txtoffline.Text = contoffline
        txtpastduecont.Text = contpasdue
        TextBox1.Text = contotal - 1

        porcentaje = (contontime / (contotal - 1)) * 100
        ProgressBar1.Value = porcentaje
        Label5.Text = porcentaje & "%"


        'Fin del codigo......
        'Fin de algoritmo---------------------------------------------


        'Segundo Algoritmo----------------------------------------------------
        '##### Este algoritmo solo contara cuantos registros se tienen con pastdue,ontime,norequired
        'Verificar status de cada registros
        'Incrementar registro de acuerdo a lo que se tenga en el status.
        'Fin de algoritmo---------------------------------------------





        'recorre el grid fila por fila
        'For Each r As DataGridViewRow In DataGridView1.Rows
        '    contotal += 1


        '    'en cells() va el indice de la columna que quiere verificar que tenga datos
        '    If r.Cells(6).Value = "TG0299" Then
        '        ' cont += 1
        '    End If
        'Next

    End Sub

    'Private Sub conexion()
    '    Dim cadenaconexion As String
    '    'cadenaconexion = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb"  'C:\Users\dan25\Documents

    '    cadenaconexion = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\" & db.Label3.Text & "\Documents\Flex_DB.mdb"

    '    Dim miconexion As OleDbConnection
    '    miconexion = New OleDbConnection(cadenaconexion)

    '    Dim PNtableadapter As OleDbDataAdapter
    '    PNtableadapter = New OleDbDataAdapter

    '    PNtableadapter.SelectCommand = New OleDbCommand("SELECT * FROM Cambium WHERE  Id= 1", miconexion)
    '    Dim PNdataset As DataSet
    '    PNdataset = New DataSet

    '    PNdataset.Tables.Add("Cambium")
    '    PNtableadapter.Fill(PNdataset.Tables("Cambium"))

    '    txtnorequired.DataBindings.Clear()
    '    txtnorequired.DataBindings.Add("Text", PNdataset.Tables("Cambium"), "cal_date")


    '    TextBox2.DataBindings.Clear()
    '    TextBox2.DataBindings.Add("Text", PNdataset.Tables("Cambium"), "due_date")

    '    miconexion.Close()
    '    'data.

    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        New_cambium.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        New_Cambium_Basic.Show()

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub


    Public Sub ActualizarDB_Cambium()

    End Sub

    Public Sub SQLUPdateCambium()

        Try

            Dim cnn As New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb")
            cnn.Open()
            Dim actualizar As String
            'actualizar = "UPDATE Cabler SET NP_Jacket='" & TextBox1.Text & "', Traza_Jacket='" & TextBox2.Text & "', Cant_Jacket='" & TextBox6.Text & "', Fecha_Jacket='" & Label4.Text & "' WHERE Traza_cabler='" & TextBox3.Text & "'"
            actualizar = "UPDATE Cambium SET status='" & txtpastdue.Text & "' WHERE ID=" & txtID.Text & " "
            comandosql = New OleDbCommand(actualizar, cnn)
            comandosql.ExecuteNonQuery()

            cnn.Close()


        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub actualizardgv()
        Dim cnn As New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\dhernandez06\OneDrive - kochind.com\Desktop\Flex_1.0\Flex_DB.mdb")
        Dim da As New OleDbDataAdapter("SELECT * FROM Cambium", cnn)
        Dim ds As New DataSet
        da.Fill(ds)
        'DataGridView1.DataSource = ds.Tables(0)
        dv.Table = ds.Tables(0)
        DataGridView1.DataSource = dv
        'DataGridView2.DataSource = dv
        cnn.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        f.Show()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class