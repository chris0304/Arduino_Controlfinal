Imports System.Windows.Forms
Imports System.IO
Imports System.IO.Ports
Imports System.Threading

Public Class MDIParent2
        Dim ChildForm As Form1
        Dim Runs As String
        Dim Stops As String
        Dim b As Button
        Dim counter As Integer
    Dim ServoC As Button
        Dim SerialM As RichTextBox
        Dim LcdT As TextBox
        Dim SendB As Button
        Dim ConB As Button
        Dim DisB As Button
    Dim CS(10) As String
        Dim SPort As ListBox
        Dim ArduinoConnect As Boolean = False

        Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click
            ' Create a new instance of the child form.
            ChildForm = New Form1()
            ' Make it a child of this MDI form before showing it.
            ChildForm.MdiParent = Me

            m_ChildFormNumber += 1
            ChildForm.Text = "Window " & m_ChildFormNumber

            ChildForm.Show()
            Runs = "Stops"
            Label2.Enabled = True
            Label4.Enabled = True
            Label5.Enabled = True
            Label6.Enabled = True
            Label8.Enabled = True
        End Sub
        Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
            TextBox2.Invoke(New MDIParent1.AddText(AddressOf TextBox2.AppendText), SerialPort1.ReadLine + Environment.NewLine)

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

        Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
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
        Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Close all child forms of the parent.
            For Each ChildForm As Form1 In Me.MdiChildren
                ChildForm.Close()
                ClearToolStripMenuItem.PerformClick()
            Next
        End Sub

        Private m_ChildFormNumber As Integer

        Private Sub RunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem.Click
            Try

                Runs = "Running"
                StopToolStripMenuItem.Enabled = True
                RunToolStripMenuItem.Enabled = False
                Panel1.Enabled = False
                Timer1.Start()


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub

        Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
            Try
                Runs = "Stops"
                StopToolStripMenuItem.Enabled = False
                RunToolStripMenuItem.Enabled = True
                Panel1.Enabled = True
                Timer1.Stop()
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Public Sub clicker()
            If Runs = "Running" Then
                ' AddHandler b.Click, AddressOf btns1_Click
                ' AddHandler b.MouseDown, AddressOf btns1_Click
            Else
                AddHandler b.MouseMove, AddressOf btns_Click

            End If
        End Sub

        Public Sub clicker1()
            If Runs = "Running" Then
                ' AddHandler b.Click, AddressOf btns1_Click
                ' AddHandler b.MouseDown, AddressOf btns1_Click
            Else

                AddHandler ServoC.MouseMove, AddressOf Servo_Scroll
            End If
        End Sub
        Public Sub clicker2()
            If Runs = "Running" Then
                ' AddHandler b.Click, AddressOf btns1_Click
                ' AddHandler b.MouseDown, AddressOf btns1_Click
            Else

                AddHandler SerialM.MouseMove, AddressOf SerialM_Click
            End If
        End Sub
        Public Sub clicker3()
            If Runs = "Running" Then
                ' AddHandler b.Click, AddressOf btns1_Click
                ' AddHandler b.MouseDown, AddressOf btns1_Click
            Else

                AddHandler LcdT.MouseMove, AddressOf LCDT_Click
            End If
        End Sub
        Public Sub clicker4()
            If Runs = "Running" Then
                ' AddHandler b.Click, AddressOf btns1_Click
                ' AddHandler b.MouseDown, AddressOf btns1_Click
            Else

                AddHandler SendB.MouseMove, AddressOf SendB_Click
            End If
        End Sub
        Public Sub clicker5()
            If Runs = "Running" Then
                ' AddHandler b.Click, AddressOf btns1_Click
                ' AddHandler b.MouseDown, AddressOf btns1_Click
            Else

                AddHandler ConB.MouseMove, AddressOf ConB_Click
            End If
        End Sub
        Public Sub clicker6()
            If Runs = "Running" Then
                ' AddHandler b.Click, AddressOf btns1_Click
                ' AddHandler b.MouseDown, AddressOf btns1_Click
            Else

                AddHandler SPort.MouseMove, AddressOf Sport_Click
            End If
        End Sub
        Private Sub btns1_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
                Dim btn1 As Button = DirectCast(sender, Button)
                btn1.Capture = False
                Dim cs As String = btn1.Text
                If Runs = "Running" Then

                    MsgBox(cs)
                    If btn1.Text = "Command0" Then

                        RichTextBox1.Text = btn1.Text
                    End If
                    If btn1.Text = "Command1" Then
                        RichTextBox1.Text = btn1.Text
                    End If
                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub btns_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
                Dim btn As Button = DirectCast(sender, Button)
                btn.Capture = False
                If Runs = "Running" Then

                Else
                    OBJ_Resize.ResizeOBJ(sender, e, Me)
                    If CheckBox1.Checked = True Then
                        b.Dispose()
                    End If
                End If

            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            Try
                If CS(1) = "Commands" Then
                    AddHandler b.Click, AddressOf btns1_Click
                Else
                End If
                If CS(3) = "Sends" Then
                    AddHandler SendB.Click, AddressOf SendB1_Click
                Else
                End If
            If CS(2) = "Disconnect" Then
                AddHandler ServoC.Click, AddressOf Servo1_Scroll
            Else
            End If
                If CS(4) = "Connects" Then
                    AddHandler ConB.Click, AddressOf ConB1_Click
                Else
                End If
                If CS(5) = "Port" Then
                    AddHandler SPort.SelectedIndexChanged, AddressOf Sport1_Click

                Else
                End If
            Catch ex As Exception

            End Try
        End Sub


        Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
            Try
                b = New Button
                b.Text = "Command" & counter.ToString
                counter += 1
                CS(1) = "Commands"
                clicker()

                ' Panel1.Controls.Add(b)
                ChildForm.Controls.Add(b)
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub


        Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
            Try

            ServoC = New Button
            ServoC.Text = "Disconnect"
                clicker1()
            CS(2) = "Disconnect"
                ChildForm.Controls.Add(ServoC)
                Label2.Enabled = False
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub Servo_Scroll(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
            Dim c As Button = DirectCast(sender, Button)
                c.Capture = False

                If Runs = "Running" Then
                Else
                    OBJ_Resize.ResizeOBJ(sender, e, Me)
                    If CheckBox1.Checked = True Then
                        ServoC.Dispose()
                    End If
                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub Servo1_Scroll(ByVal sender As Object, ByVal e As System.EventArgs)

            Try
            Dim c As Button = DirectCast(sender, Button)
                c.Capture = False

                If Runs = "Running" Then

                SerialPort1.Close()
                RichTextBox1.Text = "Disconnected"

                Else

                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
            Try

                SerialM = New RichTextBox
                SerialM.Text = "Serial"
                clicker2()
                ChildForm.Controls.Add(SerialM)
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub SerialM_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
                Dim c As RichTextBox = DirectCast(sender, RichTextBox)
                c.Capture = False

                If Runs = "Running" Then
                Else
                    OBJ_Resize.ResizeOBJ(sender, e, Me)
                    If CheckBox1.Checked = True Then
                        SerialM.Dispose()
                    End If
                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub

        Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
            Try

                LcdT = New TextBox
                LcdT.Text = "Type Command"
                clicker3()
                ChildForm.Controls.Add(LcdT)
                Label4.Enabled = False
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub LCDT_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
                Dim c As TextBox = DirectCast(sender, TextBox)
                c.Capture = False

                If Runs = "Running" Then
                Else
                    OBJ_Resize.ResizeOBJ(sender, e, Me)
                    If CheckBox1.Checked = True Then
                        LcdT.Dispose()
                    End If
                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub

        Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
            Try

                SendB = New Button
                SendB.Text = "Send Command"
                clicker4()
                CS(3) = "Sends"
                ChildForm.Controls.Add(SendB)
                Label5.Enabled = False
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub SendB_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
                Dim c As Button = DirectCast(sender, Button)
                c.Capture = False

                If Runs = "Running" Then
                Else
                    OBJ_Resize.ResizeOBJ(sender, e, Me)
                    If CheckBox1.Checked = True Then
                        SendB.Dispose()
                    End If
                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub SendB1_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
                Dim c As Button = DirectCast(sender, Button)
                c.Capture = False

                If Runs = "Running" Then
                    TextBox1.Text = LcdT.Text
                    ' SerialPort1.Write(LcdT.Text)
                Else

                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub

        Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
            Try

                ConB = New Button
                ConB.Text = "Connect"
                clicker5()
                CS(4) = "Connects"
                ChildForm.Controls.Add(ConB)
                Label6.Enabled = False
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub ConB_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
                Dim c As Button = DirectCast(sender, Button)
                c.Capture = False

                If Runs = "Running" Then
                Else
                    OBJ_Resize.ResizeOBJ(sender, e, Me)
                    If CheckBox1.Checked = True Then
                        ConB.Dispose()
                    End If
                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
    'Private Sub ConB1_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

    '    Try
    '        If Runs = "Running" Then
    '            If SPort.SelectedIndex <> -1 Then
    '                Try
    '                    If SerialPort1.IsOpen Then

    '                        ConB.Text = "Connect"
    '                        RichTextBox1.Text = "Connected"

    '                    Else

    'SerialPort1.PortName = SPort.SelectedItem.ToString
    'SerialPort1.BaudRate = 9600
    'SerialPort1.DataBits = 8
    'SerialPort1.Parity = Parity.None
    'SerialPort1.StopBits = StopBits.One
    'SerialPort1.Handshake = Handshake.None
    'SerialPort1.Encoding = System.Text.Encoding.Default
    'SerialPort1.Open()
    '                        RichTextBox1.Text = "Connecting...."
    '                        SerialPort1.Write("UNO")
    '                        Timer2.Interval = 500
    '                        Timer2.Start()
    '                        Dim serialMessage As String
    '                        While Timer2.Enabled And ArduinoConnect = False
    '                            Application.DoEvents()
    '                            serialMessage = SerialPort1.ReadLine()
    '                            If serialMessage.Contains("Arduino") Then
    '                                serialMessage = SerialPort1.ReadLine()
    '                                ConB.Text = "Disconnect"
    '                                ArduinoConnect = True
    '                                RichTextBox1.Text = "Arduino Connected"
    '                            End If
    '                        End While
    '                        SerialPort1.Close()
    '                    End If
    '                Catch ex As Exception
    '                    RichTextBox1.Text = ex.Message
    '                End Try

    '            Else
    '                RichTextBox1.Text = "Please choose a serial port"
    '            End If
    '        Else
    '        End If
    '    Catch ex As Exception
    '        RichTextBox1.Text = ex.Message
    '    End Try

    'End Sub
    Private Sub ConB1_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try

                If SPort.SelectedIndex <> -1 Then
                    If Runs = "Running" Then
                    Try
                        'With SerialPort1
                        '    .PortName = ComboBox1.Text
                        '    .BaudRate = 9600
                        '    .Parity = IO.Ports.Parity.None
                        '    .DataBits = 8
                        '    .StopBits = IO.Ports.StopBits.One
                        'End With
                        If SerialPort1.IsOpen Then
                            SerialPort1.Close()
                        Else

                            With SerialPort1
                                .PortName = SPort.SelectedItem.ToString
                                .BaudRate = 9600
                                .Parity = IO.Ports.Parity.None
                                .DataBits = 8
                                .StopBits = IO.Ports.StopBits.One
                                '.Handshake = Handshake.None
                                '.Encoding = System.Text.Encoding.Default
                            End With
                            SerialPort1.Open()

                            RichTextBox1.Text = "Connected"

                        End If

                    Catch ex As Exception
                        RichTextBox1.Text = ex.Message
                    End Try

                    Else
                        RichTextBox1.Text = "Please choose a serial port"
                    End If
                Else
                End If
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try

        End Sub
        Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
            Try

                SPort = New ListBox
                ' SPort.Text = "Port"
                clicker6()
                CS(5) = "Port"
                For Each sp As String In My.Computer.Ports.SerialPortNames
                    SPort.Items.Add(sp)
                Next

                ChildForm.Controls.Add(SPort)
            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub Sport_Click(ByVal sender As Object, ByVal e As MouseEventArgs)

            Try
                Dim c As ListBox = DirectCast(sender, ListBox)
                c.Capture = False

                If Runs = "Running" Then
                Else
                    OBJ_Resize.ResizeOBJ(sender, e, Me)
                    If CheckBox1.Checked = True Then
                        SPort.Dispose()
                    End If
                End If


            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub
        Private Sub Sport1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

            Try
                Dim c As ListBox = DirectCast(sender, ListBox)
                c.Capture = False

            Catch ex As Exception
                RichTextBox1.Text = ex.Message
            End Try
        End Sub


        Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        End Sub



        Private Sub RichTextBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            OBJ_Resize.ResizeOBJ(sender, e, Me)
        End Sub

        Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
            Try
                SerialPort1.Write(TextBox1.Text)

            Catch ex As Exception

            End Try
        End Sub
        Private Sub ServoMotorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServoMotorToolStripMenuItem.Click
            Dim Child2 As Form2
            Child2 = New Form2()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "Servo Guide " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

   

        Private Sub JoystickToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JoystickToolStripMenuItem.Click
            Dim Child2 As Form11
            Child2 = New Form11()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "Joystick " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

        Private Sub RelayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelayToolStripMenuItem.Click
            Dim Child2 As Form3
            Child2 = New Form3()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "Relay " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

        Private Sub BigSoundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BigSoundToolStripMenuItem.Click
            Dim Child2 As Form4
            Child2 = New Form4()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "BigSound " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

        Private Sub TrackingSensorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackingSensorToolStripMenuItem.Click
            Dim Child2 As Form5
            Child2 = New Form5()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "Servo Guide " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

        Private Sub FlameModulToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlameModulToolStripMenuItem.Click
            Dim Child2 As Form6
            Child2 = New Form6()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "FlameModule " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

        Private Sub LinearMagneticHallSensorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinearMagneticHallSensorsToolStripMenuItem.Click
            Dim Child2 As Form7
            Child2 = New Form7()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "LinearMagneticHallSensors " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

        Private Sub MetaltouchSensorModuleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetaltouchSensorModuleToolStripMenuItem.Click
            Dim Child2 As Form8
            Child2 = New Form8()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "MetaltouchSensorModule " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

        Private Sub ColorRGBLEDModuleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorRGBLEDModuleToolStripMenuItem.Click
            Dim Child2 As Form9
            Child2 = New Form9()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "ColorRGBLEDModule " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

        Private Sub TemperatureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TemperatureToolStripMenuItem.Click
            Dim Child2 As Form10
            Child2 = New Form10()
            ' Make it a child of this MDI form before showing it.
            Child2.MdiParent = Me

            m_ChildFormNumber += 1
            Child2.Text = "Temperature " & m_ChildFormNumber

            Child2.Show()
            Runs = "Stops"
        End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        LoadScript.ac = 1
        LoadScript.Show()
        Me.Enabled = False
        RunToolStripMenuItem.Enabled = True
    End Sub

    Private Sub MDIParent2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RadioButton1.Checked = True Then
            RadioButton1.PerformClick()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        LoadScript.ac = 2
        LoadScript.Show()
        Me.Enabled = False
        RunToolStripMenuItem.Enabled = True
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        LoadScript.ac = 4
        LoadScript.Show()
        Me.Enabled = False
        RunToolStripMenuItem.Enabled = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        LoadScript.ac = 5
        LoadScript.Show()
        Me.Enabled = False
        RunToolStripMenuItem.Enabled = True
    End Sub
End Class

