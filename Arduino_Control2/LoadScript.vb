Public Class LoadScript
    Public ac As Integer
    Dim i As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ac = 1 Then

            If ListBox2.SelectedIndex < ListBox2.Items.Count - 1 Then
                ListBox2.SelectedIndex += 1
                '  Process.Start("D:\Arduino_Control2\ConsoleApp1\bin\Debug\ConsoleApp1.exe")
            Else
                Timer1.Stop()
                Label1.Text = "OK!"
                MDIParent2.Enabled = True
                Me.Close()
            End If
        End If
        If ac = 2 Then

            If ListBox1.SelectedIndex < ListBox1.Items.Count - 1 Then
                ListBox1.SelectedIndex += 1
                ' Process.Start("D:\Arduino_Control2\ConsoleApp1\bin\Debug\ConsoleApp1.exe")
            Else
                Timer1.Stop()
                Label1.Text = "OK!"
                MDIParent2.Enabled = True
                Me.Close()
            End If
        End If
        If ac = 4 Then

            If ListBox3.SelectedIndex < ListBox3.Items.Count - 1 Then
                ListBox3.SelectedIndex += 1
                ' Process.Start("D:\Arduino_Control2\ConsoleApp1\bin\Debug\ConsoleApp1.exe")
            Else
                Timer1.Stop()
                Label1.Text = "OK!"
                MDIParent2.Enabled = True
                Me.Close()
            End If
        End If
        If ac = 5 Then

            If ListBox4.SelectedIndex < ListBox4.Items.Count - 1 Then
                ListBox4.SelectedIndex += 1
                ' Process.Start("D:\Arduino_Control2\ConsoleApp1\bin\Debug\ConsoleApp1.exe")
            Else
                Timer1.Stop()
                Label1.Text = "OK!"
                MDIParent2.Enabled = True
                Me.Close()
            End If
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ac = 1 Then
            ListBox2.SelectedIndex = 0  'Select the first item on the list
        End If
        If ac = 2 Then
            ListBox1.SelectedIndex = 0  'Select the first item on the list
        End If
        If ac = 4 Then
            ListBox3.SelectedIndex = 0  'Select the first item on the list
        End If
        If ac = 5 Then
            ListBox4.SelectedIndex = 0  'Select the first item on the list
        End If
        Timer1.Enabled = True       'Enable my timer
        Timer1.Interval = 1000     'Send a message every 10 seconds
        Timer1.Start()
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        If ac = 1 Then
            Label1.Text = ListBox2.SelectedItem.ToString()

        End If
        'If ac = 2 Then
        '    Label1.Text = ListBox1.SelectedItem.ToString()

        'End If
        'If ac = 3 Then
        '    Label1.Text = ListBox3.SelectedItem.ToString()

        'End If
        'Label2.Text = (ListBox1.SelectedIndex + 1).ToString()
        'Note Label2 is showing the number of messages sent
        'so I'm adding 1 to the selected index
        ' SendSMS()   'Send an SMS to the new number selected
    End Sub
    Private Sub SendSMS()
        'Put some code in here to send the SMS
        MessageBox.Show("sending SMS to " + Label1.Text)
    End Sub

    'Private Sub Module1()
    '    Try
    '        Throw New NotImplementedException

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ac = 2 Then
            Label1.Text = ListBox1.SelectedItem.ToString()

        End If
        'If ac = 1 Then
        '    Label1.Text = ListBox2.SelectedItem.ToString()

        'End If
       
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        If ac = 4 Then
            Label1.Text = ListBox3.SelectedItem.ToString()

        End If
    End Sub
    Private Sub ListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox4.SelectedIndexChanged
        If ac = 5 Then
            Label1.Text = ListBox4.SelectedItem.ToString()

        End If
    End Sub
End Class