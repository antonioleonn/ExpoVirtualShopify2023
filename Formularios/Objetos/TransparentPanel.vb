Public Class TransparentPanel
    Inherits System.Windows.Forms.Panel

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            ' Make background transparent
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H20
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        ' call MyBase.OnPaintBackground(e) only if the backColor is not Color.Transparent
        If Me.BackColor <> Color.Transparent Then
            MyBase.OnPaintBackground(e)
        End If
    End Sub
End Class
