<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQuestionAnswer
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tbShow = New System.Windows.Forms.TextBox()
        Me.btAsk = New System.Windows.Forms.Button()
        Me.pnlCtl = New System.Windows.Forms.Panel()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.tbEdit = New System.Windows.Forms.TextBox()
        Me.pnlCtl.SuspendLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbShow
        '
        Me.tbShow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbShow.Location = New System.Drawing.Point(96, 0)
        Me.tbShow.Multiline = True
        Me.tbShow.Name = "tbShow"
        Me.tbShow.ReadOnly = True
        Me.tbShow.Size = New System.Drawing.Size(476, 28)
        Me.tbShow.TabIndex = 1
        '
        'btAsk
        '
        Me.btAsk.Dock = System.Windows.Forms.DockStyle.Left
        Me.btAsk.Location = New System.Drawing.Point(0, 0)
        Me.btAsk.Name = "btAsk"
        Me.btAsk.Size = New System.Drawing.Size(96, 28)
        Me.btAsk.TabIndex = 2
        Me.btAsk.Text = "提问"
        Me.btAsk.UseVisualStyleBackColor = True
        '
        'pnlCtl
        '
        Me.pnlCtl.Controls.Add(Me.tbShow)
        Me.pnlCtl.Controls.Add(Me.btAsk)
        Me.pnlCtl.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCtl.Location = New System.Drawing.Point(0, 0)
        Me.pnlCtl.Name = "pnlCtl"
        Me.pnlCtl.Size = New System.Drawing.Size(572, 28)
        Me.pnlCtl.TabIndex = 6
        '
        'scMain
        '
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.Location = New System.Drawing.Point(0, 28)
        Me.scMain.Name = "scMain"
        Me.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.tbEdit)
        Me.scMain.Size = New System.Drawing.Size(572, 342)
        Me.scMain.SplitterDistance = 190
        Me.scMain.TabIndex = 7
        '
        'tbEdit
        '
        Me.tbEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEdit.Location = New System.Drawing.Point(0, 0)
        Me.tbEdit.Multiline = True
        Me.tbEdit.Name = "tbEdit"
        Me.tbEdit.Size = New System.Drawing.Size(572, 190)
        Me.tbEdit.TabIndex = 0
        Me.tbEdit.Text = "今天 是 星期几 ？"
        '
        'frmQuestionAnswer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 370)
        Me.Controls.Add(Me.scMain)
        Me.Controls.Add(Me.pnlCtl)
        Me.Name = "frmQuestionAnswer"
        Me.Text = "问答"
        Me.pnlCtl.ResumeLayout(False)
        Me.pnlCtl.PerformLayout()
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel1.PerformLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbShow As TextBox
    Friend WithEvents btAsk As Button
    Friend WithEvents pnlCtl As Panel
    Friend WithEvents scMain As SplitContainer
    Friend WithEvents tbEdit As TextBox
End Class
