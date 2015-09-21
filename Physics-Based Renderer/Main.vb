Imports System.Net.Cache
Imports System.ComponentModel
Public Class Main
    Dim filePath As New String(String.Empty)
    Dim file As Render.scene3D
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = My.Computer.Screen.Bounds.Width / 1.1
        Me.Height = My.Computer.Screen.Bounds.Height / 1.1
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub RenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenderToolStripMenuItem.Click
        file = fromFile(txtEditor.Lines.ToList)
        Dim renderTask As New Render
        Dim pixels(,) As Color
        pixels = renderTask.render(file)
    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If dlgOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Text = dlgOpen.SafeFileName & " - Renderer"
            filePath = dlgOpen.FileName
            txtEditor.Text = My.Computer.FileSystem.ReadAllText(dlgOpen.FileName)
        End If
    End Sub
    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If dlgSaveAs.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Text = dlgSaveAs.FileName.Split("/").Last & " - Renderer"
            filePath = dlgSaveAs.FileName
            My.Computer.FileSystem.WriteAllText(dlgSaveAs.FileName, txtEditor.Text, False)
        End If
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If filePath = String.Empty Then
            If dlgSaveAs.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Text = dlgSaveAs.FileName.Split("/").Last & " - Renderer"
                filePath = dlgSaveAs.FileName
                My.Computer.FileSystem.WriteAllText(dlgSaveAs.FileName, txtEditor.Text, False)
            End If
        Else
            My.Computer.FileSystem.WriteAllText(filePath, txtEditor.Text, False)
        End If
    End Sub
End Class