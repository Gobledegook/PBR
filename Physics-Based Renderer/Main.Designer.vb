<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RendererToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.prbMainView = New System.Windows.Forms.PictureBox()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.txtEditor = New System.Windows.Forms.RichTextBox()
        Me.dlgSaveAs = New System.Windows.Forms.SaveFileDialog()
        Me.mnuMain.SuspendLayout()
        CType(Me.prbMainView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.RendererToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(284, 24)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveAsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save&As"
        '
        'RendererToolStripMenuItem
        '
        Me.RendererToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenderToolStripMenuItem})
        Me.RendererToolStripMenuItem.Name = "RendererToolStripMenuItem"
        Me.RendererToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.RendererToolStripMenuItem.Text = "Renderer"
        '
        'RenderToolStripMenuItem
        '
        Me.RenderToolStripMenuItem.Name = "RenderToolStripMenuItem"
        Me.RenderToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.RenderToolStripMenuItem.Text = "&Render"
        '
        'prbMainView
        '
        Me.prbMainView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prbMainView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.prbMainView.Location = New System.Drawing.Point(0, 24)
        Me.prbMainView.Name = "prbMainView"
        Me.prbMainView.Size = New System.Drawing.Size(284, 124)
        Me.prbMainView.TabIndex = 1
        Me.prbMainView.TabStop = False
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "Scene Files|*.scene"
        Me.dlgOpen.InitialDirectory = "C:\"
        '
        'txtEditor
        '
        Me.txtEditor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEditor.Location = New System.Drawing.Point(12, 154)
        Me.txtEditor.Name = "txtEditor"
        Me.txtEditor.Size = New System.Drawing.Size(260, 96)
        Me.txtEditor.TabIndex = 2
        Me.txtEditor.Text = ""
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.txtEditor)
        Me.Controls.Add(Me.prbMainView)
        Me.Controls.Add(Me.mnuMain)
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Renderer"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        CType(Me.prbMainView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RendererToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents prbMainView As System.Windows.Forms.PictureBox
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtEditor As System.Windows.Forms.RichTextBox
    Friend WithEvents dlgSaveAs As System.Windows.Forms.SaveFileDialog

End Class
