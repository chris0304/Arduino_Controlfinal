Public Class Form4

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Clipboard.SetText(RichTextBox1.Text)
        MsgBox("Copy all codes")
    End Sub

    'Private Sub SuspendLayout()
    '    Throw New System.NotImplementedException
    'End Sub

End Class