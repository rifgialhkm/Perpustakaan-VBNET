Imports System.Data.Odbc
Public Class Perpustakaan

    Sub awal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

        Call Koneksi()
        DA = New OdbcDataAdapter("Select * From tb_buku", conn)
        DS = New DataSet
        DA.Fill(DS, "tb_buku")
        DataGridView1.DataSource = DS.Tables("tb_buku")

    End Sub

    Private Sub ButtonCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCreate.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Pastikan datanya terisi semua")
        Else
            Call Koneksi()
            Dim create As String = "insert into tb_buku values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            CMD = New OdbcCommand(create, conn)
            CMD.ExecuteNonQuery()
            MsgBox("Data Buku Berhasil diinput")

            Call awal()
        End If
    End Sub

    Private Sub ButtonEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEdit.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Pastikan datanya terisi semua")
        Else
            Call Koneksi()
            Dim edit As String = "Update ignore tb_buku set kd_buku='" & TextBox1.Text & "', judul='" & TextBox2.Text & "', penerbit='" & TextBox3.Text & "', jenis_buku='" & TextBox4.Text & "'"
            CMD = New OdbcCommand(edit, conn)
            CMD.ExecuteNonQuery()
            MsgBox("Data Buku Berhasil diedit")

            Call awal()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            CMD = New OdbcCommand("Select * From tb_buku where kd_buku='" & TextBox1.Text & "'", conn)
            RD = CMD.ExecuteReader
            RD.Read()

            If RD.HasRows Then
                TextBox2.Text = RD.Item("judul")
                TextBox3.Text = RD.Item("penerbit")
                TextBox4.Text = RD.Item("jenis_buku")
            Else
                MsgBox("Data Tidak Ditemukan")
            End If
        End If
    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Pastikan data yang akan Anda hapus terisi")
        Else
            Call Koneksi()
            Dim delete As String = "delete from tb_buku where kd_buku='" & TextBox1.Text & "'"
            CMD = New OdbcCommand(delete, conn)
            CMD.ExecuteNonQuery()
            MsgBox("Data Buku Berhasil dihapus")

            Call awal()
        End If
    End Sub
End Class
