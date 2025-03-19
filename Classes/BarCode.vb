
Public Class BarCode
    Private TextBoxOrder As New Dictionary(Of TextBox, TextBox)()

    'Public Sub New()
    '    InitializeComponent()

    '    TextBoxOrder.Add(BarcodeInput1, BarcodeInput2)
    '    TextBoxOrder.Add(BarcodeInput2, BarcodeInput3)
    '    TextBoxOrder.Add(BarcodeInput3, BarcodeInput1)

    '    BarcodeInput1.Tag = 1
    '    BarcodeInput2.Tag = 2
    '    BarcodeInput3.Tag = 3

    '    AddHandler BarcodeInput1.KeyDown, AddressOf BarcodeInputKeyDown
    '    AddHandler BarcodeInput2.KeyDown, AddressOf BarcodeInputKeyDown
    '    AddHandler BarcodeInput3.KeyDown, AddressOf BarcodeInputKeyDown

    '    AddHandler BarcodeInput1.Leave, AddressOf BarcodeInputLeave
    '    AddHandler BarcodeInput2.Leave, AddressOf BarcodeInputLeave
    '    AddHandler BarcodeInput3.Leave, AddressOf BarcodeInputLeave
    'End Sub

    'Private Sub BarcodeInputKeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter AndAlso ActiveControl.[GetType]() = GetType(TextBox) Then
    '        Dim nextTextBox As TextBox
    '        If TextBoxOrder.TryGetValue(DirectCast(ActiveControl, TextBox), nextTextBox) Then
    '            e.Handled = True
    '            e.SuppressKeyPress = True
    '            nextTextBox.Focus()
    '        End If
    '    End If
    'End Sub

    'Private Sub BarcodeInputLeave(sender As Object, e As EventArgs)
    '    If sender.[GetType]() = GetType(TextBox) Then
    '        Dim textBox As TextBox = DirectCast(sender, TextBox)
    '        If textBox.Tag.[GetType]() = GetType(Integer) Then
    '            BarcodeScanned(textBox.Text, CInt(textBox.Tag))
    '        End If
    '    End If
    'End Sub

    'Private Sub BarcodeScanned(barcode As String, order As Integer)
    '    DemoLabel.Text = Convert.ToString(order.ToString() + ": ") & barcode
    'End Sub
End Class
