Option Explicit On
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Windows.Forms

Public Class MDIParent1
    Dim counter As Integer = 1
    Dim SText As New RichTextBox
    Dim newMDIChild As Form1
    Dim RunTime As String
    Dim Bmode As String
    Delegate Sub AddText(ByVal Text As String)
    Private Sub btns_click(ByVal sender As Object, ByVal e As EventArgs)
        MsgBox(DirectCast(sender, Button).Text & " clicked")

    End Sub
    
    
    Private Sub btns_Click(ByVal sender As Object, ByVal e As MouseEventArgs)
      
        Try
            Dim btn As Button = DirectCast(sender, Button)
            btn.Capture = False

            If RunTime = "Running" Then

                MsgBox("Me")
            Else
                OBJ_Resize.ResizeOBJ(sender, e, Me)
                'Const WM_NCLBUTTONDOWN As Integer = &HA1
                'Const HTCAPTION As Integer = &H2

                'Dim msg As Message = _
                '    Message.Create(btn.Handle, WM_NCLBUTTONDOWN, _
                '        New IntPtr(HTCAPTION), IntPtr.Zero)

                'Me.DefWndProc(msg)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click
        newMDIChild = New Form1()
        ' Set the Parent Form of the Child window. 
        newMDIChild.MdiParent = Me
        newMDIChild.Text = "System"
       
        ' Display the new form. 
        newMDIChild.Show()
        counter = 1
        Button1.Enabled = True
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*" 

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

   

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub RunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem.Click
        RunToolStripMenuItem.BackColor = Color.Green
        RunTime = "Running"
        Panel1.Enabled = False
       
    End Sub

    
    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 0 To _
          My.Computer.Ports.SerialPortNames.Count - 1
            ListBox1.Items.Add( _
               My.Computer.Ports.SerialPortNames(i))
        Next
        RunTime = "Stop"
        SerialPort1.Close()
    End Sub
 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim b As New Button
            b.Text = "Command" & counter.ToString
            counter += 1

            If RunTime = "Running" Then
                AddHandler b.Click, AddressOf btns_click
                'AddHandler b.MouseDown, AddressOf btns_click
            Else
                AddHandler b.MouseMove, AddressOf btns_click
            End If

            ' Panel1.Controls.Add(b)
            newMDIChild.Controls.Add(b)
            If counter = 5 Then
                Button1.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            counter = 1
        End Try
    End Sub



    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        RunToolStripMenuItem.BackColor = Color.AliceBlue
        RunTime = "Stop"
        Panel1.Enabled = True
    End Sub
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        SText.Invoke(New AddText(AddressOf SText.AppendText), SerialPort1.ReadLine + Environment.NewLine)
    End Sub


    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub stext_Click(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim stext As RichTextBox = DirectCast(sender, RichTextBox)
        stext.Capture = False

        If RunTime = "Running" Then


        Else
            OBJ_Resize.ResizeOBJ(sender, e, Me)
            'Const WM_NCLBUTTONDOWN As Integer = &HA1
            'Const HTCAPTION As Integer = &H2

            'Dim msg As Message = _
            '    Message.Create(btn.Handle, WM_NCLBUTTONDOWN, _
            '        New IntPtr(HTCAPTION), IntPtr.Zero)

            'Me.DefWndProc(msg)
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Try

            SText.Text = "Command" & counter.ToString
            counter += 1

            If RunTime = "Running" Then
                ' AddHandler b.Click, AddressOf btns_click
                'AddHandler b.MouseDown, AddressOf btns_click
            Else
                AddHandler SText.MouseMove, AddressOf stext_Click
            End If

            ' Panel1.Controls.Add(b)
            newMDIChild.Controls.Add(SText)

        Catch ex As Exception
            MsgBox(ex.Message)
            counter = 1
        End Try
    End Sub
End Class
