Public Class Form1

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim data() As String = {txtProductName.Text, txtPrice.Text, txtAmount.Text, txtTotal.Text}
            DataGridView1.Rows.Add(data)

            txtProductName.Clear()
            txtPrice.Clear()
            txtAmount.Clear()
            txtTotal.Clear()
            txtProductName.Focus()

            Calculate()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        Try
            Dim total As Integer
            total = CInt(txtPrice.Text) * CInt(txtAmount.Text)
            txtTotal.Text = total.ToString("#,##0")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                If MessageBox.Show("ທ່ານຕ້ອງການລົບຫຼືບໍ່", "ແຈ້ງເຕືອນ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    For i = 0 To DataGridView1.SelectedRows.Count - 1
                        Dim row As DataGridViewRow
                        row = DataGridView1.SelectedRows(i)
                        DataGridView1.Rows.Remove(row)
                    Next

                    Calculate()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculate()
        Try
            Dim nettotal As Integer
            For i = 0 To DataGridView1.Rows.Count - 1
                nettotal += CInt(DataGridView1.Rows(i).Cells("Column4").Value)
            Next
            lblNetTotal.Text = nettotal.ToString("#,##0")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
