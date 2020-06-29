Public Class Menu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CambiumDB.Show()

    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Environment.UserName
        'Label2.Text = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\" & Label3.Text & "\Documents\Flex_DB.mdb"

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NovariantDB.Show()
    End Sub
End Class
