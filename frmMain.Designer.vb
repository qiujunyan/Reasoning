<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.tvKnowTree = New System.Windows.Forms.TreeView()
        Me.cmTreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsNewKnowTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsModifyTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDelKownTree = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsNewKnowNode = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditKnowNode = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelKnowNode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsPredicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsRule = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsExpandAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCloseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.label1 = New System.Windows.Forms.Label()
        Me.lvAttr = New System.Windows.Forms.ListView()
        Me.chAttrName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAttrValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmAttr = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsAddAttr = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditAttr = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsDelAttr = New System.Windows.Forms.ToolStripMenuItem()
        Me.label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmTreeView.SuspendLayout()
        Me.cmAttr.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvKnowTree
        '
        Me.tvKnowTree.ContextMenuStrip = Me.cmTreeView
        Me.tvKnowTree.Location = New System.Drawing.Point(2, 40)
        Me.tvKnowTree.Name = "tvKnowTree"
        Me.tvKnowTree.Size = New System.Drawing.Size(338, 458)
        Me.tvKnowTree.TabIndex = 0
        '
        'cmTreeView
        '
        Me.cmTreeView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNewKnowTree, Me.tsModifyTree, Me.tsDelKownTree, Me.ToolStripSeparator1, Me.tsNewKnowNode, Me.tsEditKnowNode, Me.DelKnowNode, Me.ToolStripSeparator2, Me.tsProperty, Me.tsPredicate, Me.tsRule, Me.ToolStripSeparator3, Me.tsExpandAll, Me.tsCloseAll})
        Me.cmTreeView.Name = "cmTreeView"
        Me.cmTreeView.Size = New System.Drawing.Size(137, 264)
        '
        'tsNewKnowTree
        '
        Me.tsNewKnowTree.Name = "tsNewKnowTree"
        Me.tsNewKnowTree.Size = New System.Drawing.Size(136, 22)
        Me.tsNewKnowTree.Text = "新建知识树"
        '
        'tsModifyTree
        '
        Me.tsModifyTree.Name = "tsModifyTree"
        Me.tsModifyTree.Size = New System.Drawing.Size(136, 22)
        Me.tsModifyTree.Text = "修改知识树"
        '
        'tsDelKownTree
        '
        Me.tsDelKownTree.Name = "tsDelKownTree"
        Me.tsDelKownTree.Size = New System.Drawing.Size(136, 22)
        Me.tsDelKownTree.Text = "删除知识树"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(133, 6)
        '
        'tsNewKnowNode
        '
        Me.tsNewKnowNode.Name = "tsNewKnowNode"
        Me.tsNewKnowNode.Size = New System.Drawing.Size(136, 22)
        Me.tsNewKnowNode.Text = "新建知识点"
        '
        'tsEditKnowNode
        '
        Me.tsEditKnowNode.Name = "tsEditKnowNode"
        Me.tsEditKnowNode.Size = New System.Drawing.Size(136, 22)
        Me.tsEditKnowNode.Text = "编辑知识点"
        '
        'DelKnowNode
        '
        Me.DelKnowNode.Name = "DelKnowNode"
        Me.DelKnowNode.Size = New System.Drawing.Size(136, 22)
        Me.DelKnowNode.Text = "删除知识点"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(133, 6)
        '
        'tsProperty
        '
        Me.tsProperty.Name = "tsProperty"
        Me.tsProperty.Size = New System.Drawing.Size(136, 22)
        Me.tsProperty.Text = "属性"
        '
        'tsPredicate
        '
        Me.tsPredicate.Name = "tsPredicate"
        Me.tsPredicate.Size = New System.Drawing.Size(136, 22)
        Me.tsPredicate.Text = "谓词"
        '
        'tsRule
        '
        Me.tsRule.Name = "tsRule"
        Me.tsRule.Size = New System.Drawing.Size(136, 22)
        Me.tsRule.Text = "规则"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(133, 6)
        '
        'tsExpandAll
        '
        Me.tsExpandAll.Name = "tsExpandAll"
        Me.tsExpandAll.Size = New System.Drawing.Size(136, 22)
        Me.tsExpandAll.Text = "全部展开"
        '
        'tsCloseAll
        '
        Me.tsCloseAll.Name = "tsCloseAll"
        Me.tsCloseAll.Size = New System.Drawing.Size(136, 22)
        Me.tsCloseAll.Text = "全部收缩"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.label1.Location = New System.Drawing.Point(-2, 25)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(47, 12)
        Me.label1.TabIndex = 1
        Me.label1.Text = "知识树:"
        '
        'lvAttr
        '
        Me.lvAttr.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chAttrName, Me.chAttrValue})
        Me.lvAttr.ContextMenuStrip = Me.cmAttr
        Me.lvAttr.FullRowSelect = True
        Me.lvAttr.GridLines = True
        Me.lvAttr.HideSelection = False
        Me.lvAttr.Location = New System.Drawing.Point(346, 40)
        Me.lvAttr.MultiSelect = False
        Me.lvAttr.Name = "lvAttr"
        Me.lvAttr.Size = New System.Drawing.Size(361, 458)
        Me.lvAttr.TabIndex = 2
        Me.lvAttr.UseCompatibleStateImageBehavior = False
        Me.lvAttr.View = System.Windows.Forms.View.Details
        '
        'chAttrName
        '
        Me.chAttrName.Text = "属性名"
        Me.chAttrName.Width = 120
        '
        'chAttrValue
        '
        Me.chAttrValue.Text = "属性值"
        Me.chAttrValue.Width = 120
        '
        'cmAttr
        '
        Me.cmAttr.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddAttr, Me.tsEditAttr, Me.tsDelAttr})
        Me.cmAttr.Name = "cmAttr"
        Me.cmAttr.Size = New System.Drawing.Size(101, 70)
        '
        'tsAddAttr
        '
        Me.tsAddAttr.Name = "tsAddAttr"
        Me.tsAddAttr.Size = New System.Drawing.Size(100, 22)
        Me.tsAddAttr.Text = "添加"
        '
        'tsEditAttr
        '
        Me.tsEditAttr.Name = "tsEditAttr"
        Me.tsEditAttr.Size = New System.Drawing.Size(100, 22)
        Me.tsEditAttr.Text = "编辑"
        '
        'tsDelAttr
        '
        Me.tsDelAttr.Name = "tsDelAttr"
        Me.tsDelAttr.Size = New System.Drawing.Size(100, 22)
        Me.tsDelAttr.Text = "删除"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.label3.Location = New System.Drawing.Point(344, 25)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(77, 12)
        Me.label3.TabIndex = 12
        Me.label3.Text = "知识点属性："
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(703, 25)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsMenu
        '
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(44, 21)
        Me.tsMenu.Text = "问答"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 510)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.tvKnowTree)
        Me.Controls.Add(Me.lvAttr)
        Me.Name = "frmMain"
        Me.Text = "语意推理实验"
        Me.cmTreeView.ResumeLayout(False)
        Me.cmAttr.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tvKnowTree As TreeView
    Friend WithEvents label1 As Label
    Friend WithEvents cmTreeView As ContextMenuStrip
    Friend WithEvents tsNewKnowTree As ToolStripMenuItem
    Friend WithEvents tsDelKownTree As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsNewKnowNode As ToolStripMenuItem
    Friend WithEvents tsEditKnowNode As ToolStripMenuItem
    Friend WithEvents DelKnowNode As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsExpandAll As ToolStripMenuItem
    Friend WithEvents tsCloseAll As ToolStripMenuItem
    Friend WithEvents tsModifyTree As ToolStripMenuItem
    Friend WithEvents tsProperty As ToolStripMenuItem
    Friend WithEvents tsPredicate As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsRule As ToolStripMenuItem
    Friend WithEvents lvAttr As ListView
    Friend WithEvents label3 As Label
    Friend WithEvents chAttrValue As ColumnHeader
    Friend WithEvents cmAttr As ContextMenuStrip
    Friend WithEvents tsAddAttr As ToolStripMenuItem
    Friend WithEvents tsEditAttr As ToolStripMenuItem
    Friend WithEvents tsDelAttr As ToolStripMenuItem
    Friend WithEvents chAttrName As ColumnHeader
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents tsMenu As ToolStripMenuItem
End Class
