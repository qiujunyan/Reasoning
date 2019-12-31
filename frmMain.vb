Imports Connet
Imports System.Data.SqlClient


Public Class frmMain
    Inherits System.Windows.Forms.Form
    Private SelectNode As TreeNode = Nothing
    Public SelectTree As KnowTree = Nothing

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Server.LoadAllServer() Then
            MsgBox("没有找到相关知识，系统退出！")
            End
        End If
        LoadDefault()
        RedrawTree()
        Me.Show()
    End Sub


    Private Sub LoadDefault()
        Dim defDomain As String = GetSetting("ConceptualNetwork", "Start", "Default")
        If (defDomain Is Nothing) Or (defDomain.Length = 0) Then
            Dim dft As New frmDefault
            If dft.ShowDialog() = Windows.Forms.DialogResult.OK Then
            End If
        End If

        Dim strArr() As String = defDomain.Split(New Char() {" "c})
        Dim dm As Domain = Server.CurServer.LoadDomain(strArr(0))
        Server.CurServer.CurDomain = dm
    End Sub

    Public Sub RedrawTree()
        Dim curDomain As Domain = Server.GetCurDomain()
        If curDomain Is Nothing Then
            MsgBox("当前Domain为空！")
            Return
        End If
        For Each kt As KnowTree In curDomain.KnowTreeList
            If kt.TreeName = "推理知识树" Then
                kt.ShowOnTreeView(tvKnowTree)
                SelectTree = kt
            End If
        Next
    End Sub

    '右键知识树菜单：弹出
    Private Sub ShowItem(ByVal Attr As Attribute, ByVal ForeColor As Color)
        Dim itm As ListViewItem = lvAttr.Items.Add(Attr.AttrName.ShowNoCode())
        itm.ForeColor = ForeColor
        itm.Tag = Attr
        If Attr.AttrValue Is Nothing Then Return
        If Attr.AttrValue.GetType().IsSubclassOf(GetType(Meaning)) Then
            Dim mn As Meaning = Attr.AttrValue
            itm.SubItems.Add(mn.ShowNoCode())
        Else
            itm.SubItems.Add(Attr.AttrValue.ToString())
        End If
    End Sub

    Private Sub tvKnowTree_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvKnowTree.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            SelectNode = tvKnowTree.GetNodeAt(e.X, e.Y)
            tvKnowTree.SelectedNode = SelectNode
            lvAttr.Items.Clear()
            If TypeOf SelectNode.Tag Is KnowNode Then
                Dim kn As KnowNode = SelectNode.Tag
                Dim attr As Attribute
                For Each attr In kn.Attributes
                    ShowItem(attr, Color.Blue)
                Next
            End If

        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                tvKnowTree.SelectedNode = tvKnowTree.GetNodeAt(e.X, e.Y)
        End If
    End Sub

    '右键知识树菜单：新建知识树
    Private Sub tsNewKnowTree_Click(sender As Object, e As EventArgs) Handles tsNewKnowTree.Click
        Dim dm As Domain = Server.GetCurDomain()
        If dm Is Nothing Then Return
        Dim frm As New frmKnowTree
        frm.Domain = dm
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim tr As KnowTree = frm.EditTree
            dm.CurrentKnowTree = tr
            Dim nd As TreeNode = tr.ShowOnTreeView(tvKnowTree)
            If Not nd Is Nothing Then nd.EnsureVisible()
        End If
    End Sub

    '右键知识树菜单：修改知识树
    Private Sub tsModifyTree_Click(sender As Object, e As EventArgs) Handles tsModifyTree.Click
        If tvKnowTree.SelectedNode Is Nothing Then Return
        If TypeOf tvKnowTree.SelectedNode.Tag Is KnowTree Then
            Dim dm As Domain = Server.CurServer.CurDomain
            Dim kt As KnowTree = tvKnowTree.SelectedNode.Tag
            dm.CurrentKnowTree = kt
            Dim frm As New frmKnowTree
            frm.EditTree = kt
            frm.ShowDialog(Me)
        End If
    End Sub

    '右键知识树菜单：删除知识树
    Private Sub tsDelKownTree_Click(sender As Object, e As EventArgs) Handles tsDelKownTree.Click
        Dim nd As TreeNode = tvKnowTree.SelectedNode
        If nd Is Nothing Then Return
        Dim kt As KnowTree
        If TypeOf nd.Tag Is KnowTree Then
            kt = nd.Tag
        Else
            kt = CType(nd.Tag, KnowNode).KnowTree
        End If
        Server.CurServer.CurDomain.CurrentKnowTree = kt
        If MsgBox("真的要删除知识树：" & kt.TreeName & "？", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Dim Trans As SqlTransaction = kt.Domain.WhichServer.Database.BeginTransaction()
            If kt.DBDelete(Trans) Then
                Trans.Commit()
                Dim dm As Domain = kt.Domain
                dm.KnowTreeList.Remove(kt)
                dm.CurrentKnowTree = Nothing
                tvKnowTree.Nodes.Remove(nd)
                MsgBox("删除成功!")
            Else
                Trans.Rollback()
                MsgBox("删除失败，详情见日志!")
            End If
        End If
    End Sub


    '右键知识树菜单：新建知识点
    Private Function ParentNode(ByVal nd As TreeNode) As TreeNode
        Dim rn As TreeNode = nd
        Do While (Not rn.Parent Is Nothing)
            rn = rn.Parent
        Loop
        Return rn
    End Function
    Private Sub tsNewKnowNode_Click(sender As Object, e As EventArgs) Handles tsNewKnowNode.Click
        Dim SelNode As TreeNode = tvKnowTree.SelectedNode
        If SelNode Is Nothing Then Return
        If SelNode.Tag Is Nothing Then Return
        Dim frm As New frmKnowNode
        If TypeOf SelNode.Tag Is KnowTree Then
            frm.KnowTree = SelNode.Tag
            Server.CurServer.CurDomain.CurrentKnowTree = SelNode.Tag

        Else
            frm.SetParent = SelNode.Tag
            Server.CurServer.CurDomain.CurrentKnowTree = CType(SelNode.Tag, KnowNode).KnowTree
        End If

        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim nd As TreeNode = frm.EditNode.ShowOnNode(SelNode)
            If Not nd Is Nothing Then nd.EnsureVisible()
        End If
    End Sub

    '右键知识树菜单：编辑知识点
    Private Sub tsEditKnowNode_Click(sender As Object, e As EventArgs) Handles tsEditKnowNode.Click
        If tvKnowTree.SelectedNode Is Nothing Then Return
        If tvKnowTree.SelectedNode.Tag Is Nothing Then Return
        If Not tvKnowTree.SelectedNode.IsExpanded Then
            If TypeOf tvKnowTree.SelectedNode.Tag Is KnowTree Then
                Server.CurServer.CurDomain.CurrentKnowTree = tvKnowTree.SelectedNode.Tag
                Dim EditNode As TreeNode = tvKnowTree.SelectedNode
                Dim frm As New frmKnowTree
                frm.EditTree = EditNode.Tag
                frm.IsEdit = True
                frm.ShowDialog(Me)
            Else
                Dim EditNode As TreeNode = tvKnowTree.SelectedNode
                Server.CurServer.CurDomain.CurrentKnowTree = CType(tvKnowTree.SelectedNode.Tag, KnowNode).KnowTree
                Dim frm As New frmKnowNode
                frm.EditNode = EditNode.Tag
                frm.ShowDialog(Me)
            End If
        End If
    End Sub

    '右键知识树菜单：删除知识点
    Public Function ProcAllNodes() As ProcessKnowNodeType
        Dim frm As New frmDelOpt
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Return frm.ProcType
        Else
            Return ProcessKnowNodeType.NoneProcess
        End If
    End Function

    Private Sub RedrawNode(ByVal nd As TreeNode)
        Dim ndList As New ArrayList
        For Each snd As TreeNode In nd.Nodes
            ndList.Add(snd.Tag)
        Next
        If TypeOf nd.Tag Is KnowTree Then
            Dim kt As KnowTree = nd.Tag
            For Each k As KnowNode In kt.Root
                If Not ndList.Contains(k) Then
                    k.ShowOnNode(nd)
                End If
            Next
        Else
            Dim kn As KnowNode = nd.Tag
            For Each k As KnowNode In kn.Children
                If Not ndList.Contains(k) Then
                    k.ShowOnNode(nd)
                End If
            Next
            For Each k As KnowNode In kn.Member
                If Not ndList.Contains(k) Then
                    k.ShowOnNode(nd)
                End If
            Next
        End If
    End Sub
    Private Sub DelKnowNode_Click(sender As Object, e As EventArgs) Handles DelKnowNode.Click
        If tvKnowTree.SelectedNode Is Nothing Then Return
        If tvKnowTree.SelectedNode.Tag Is Nothing Then Return
        If TypeOf tvKnowTree.SelectedNode.Tag Is KnowNode Then

            Server.CurServer.CurDomain.CurrentKnowTree = CType(tvKnowTree.SelectedNode.Tag, KnowNode).KnowTree
            Dim EditNode As TreeNode = tvKnowTree.SelectedNode
            Dim nd As KnowNode = EditNode.Tag
            Dim DelType As ProcessKnowNodeType
            If nd.HaveOffspring() Then
                DelType = ProcAllNodes()
            Else
                If MsgBox("真的要删除知识点'" & nd.Name & "'？", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    DelType = ProcessKnowNodeType.LocalProcess
                Else
                    Return
                End If
            End If
            If DelType = ProcessKnowNodeType.AllProcess Then
                Dim Trans As SqlTransaction = nd.KnowTree.Domain.WhichServer.Database.BeginTransaction()
                If nd.DeleteAll(Trans) Then
                    Trans.Commit()
                    EditNode.Parent.Nodes.Remove(EditNode)
                Else
                    Trans.Rollback()
                    MsgBox("删除失败，详情见日志！")
                End If
                tvKnowTree.SelectedNode.Remove()
            ElseIf DelType = ProcessKnowNodeType.LocalProcess Then
                Dim ppn As TreeNode = EditNode.Parent.Parent
                Dim pn As TreeNode = EditNode.Parent
                Dim Trans As SqlTransaction = nd.KnowTree.Domain.WhichServer.Database.BeginTransaction()
                If nd.DeleteMeOnly(Trans) Then
                    Trans.Commit()
                    EditNode.Remove()
                    RedrawNode(pn)
                Else
                    Trans.Rollback()
                    If MsgBox("删除失败，系统需要退出以避免出现知识混乱！", MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton1) = MsgBoxResult.Ok Then
                        Me.MdiParent.Close()
                    End If
                End If
            End If
        End If
    End Sub

    '右键知识树菜单：展开知识点
    Private Sub tsExpandAll_Click(sender As Object, e As EventArgs) Handles tsExpandAll.Click
        If tvKnowTree.SelectedNode Is Nothing Then Return
        tvKnowTree.SelectedNode.ExpandAll()
    End Sub

    '右键知识树菜单：收缩知识点
    Private Sub tsCloseAll_Click(sender As Object, e As EventArgs) Handles tsCloseAll.Click
        If tvKnowTree.SelectedNode Is Nothing Then Return
        tvKnowTree.SelectedNode.Collapse()
    End Sub

    '右键知识树菜单：属性
    Private Sub tsProperty_Click(sender As Object, e As EventArgs) Handles tsProperty.Click
        If TypeOf tvKnowTree.SelectedNode.Tag Is KnowNode Then
            Dim kn As KnowNode = tvKnowTree.SelectedNode.Tag
            Server.CurServer.CurDomain.CurrentKnowTree = kn.KnowTree

            Dim frmAttr As New frmAttr
            frmAttr.Belong = kn
            frmAttr.ShowDialog(Me)
        End If
    End Sub

    '右键知识树菜单：谓词
    Private Sub tsPredicate_Click(sender As Object, e As EventArgs) Handles tsPredicate.Click
        Dim frm As New frmPredicate()
        frm.ShowDialog(Me)
    End Sub

    '右键知识树菜单：规则
    Friend WithEvents lvRule As System.Windows.Forms.ListView
    ' Friend WithEvents lvAttr As System.Windows.Forms.ListView
    Friend WithEvents lvSyn As System.Windows.Forms.ListView
    Friend WithEvents lblAttr As System.Windows.Forms.Label
    Public Sub ShowRule(ByVal rl As Rule)
        Dim itm As ListViewItem = lvRule.Items.Add(rl.RuleName)
        itm.Tag = rl
        itm.SubItems.Add(rl.ShowMeaning())
    End Sub


    Private Sub ShowDetail(ByVal Obj As Object)
        lvAttr.Items.Clear()
        lvRule.Items.Clear()
        lvSyn.Items.Clear()

        If TypeOf Obj Is KnowNode Then
            Dim kn As KnowNode = Obj, Attr As Attribute
            lblAttr.Text = "知识点：" & kn.Name & "的属性："
            For Each Attr In kn.Attributes
                ShowItem(Attr, Color.Blue)
            Next
            If TypeOf kn.Key Is Concept Then
                Dim cn As Concept = kn.Key
                For Each Attr In cn.Attributes
                    ShowItem(Attr, Color.Red)
                Next
            End If
            For Each rl As Rule In kn.RuleSet
                ShowRule(rl)
            Next
        ElseIf TypeOf Obj Is KnowTree Then
            Dim kt As KnowTree = Obj
            lblAttr.Text = "知识树 " & kt.TreeName & " 的属性："
            For Each inst As InstanceOfNode In kt.InstanceList
                Dim itm As ListViewItem = lvAttr.Items.Add(inst.Instance.Name)
                itm.Tag = inst
                Dim sbStr As String = Variable.GetTypeStr(inst.InstanceType)
                If inst.Value IsNot Nothing Then
                    sbStr = sbStr & " -- " & inst.Value.ToString()
                End If
                itm.SubItems.Add(sbStr)
            Next
            For Each rl As Rule In kt.TopRuleList
                ShowRule(rl)
            Next
        End If
    End Sub
    Private Sub tsRule_Click(sender As Object, e As EventArgs) Handles tsRule.Click
        Dim nd As TreeNode = tvKnowTree.SelectedNode
        If nd.Tag Is Nothing Then Return
        If TypeOf nd.Tag Is KnowTree Then
            Dim frm As New frmRule
            frm.AssocObj = nd.Tag
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ShowDetail(tvKnowTree.SelectedNode.Tag)
            End If
        ElseIf TypeOf nd.Tag Is KnowNode Then
            Dim kn As KnowNode = nd.Tag
            '          If MsgBox("创建一个简单规则否？简单规则是指结论直接给知识点赋真或假。", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton2, "建立规则") = MsgBoxResult.Yes Then
            Dim kv As InstanceOfNode = kn.KnowTree.GetInstance(kn.Name)
            Dim frm As New frmSimpleRule()

            '      End If
        End If
        If (TypeOf nd.Tag Is KnowTree) Or (TypeOf nd.Tag Is KnowNode) Then
            Dim frm As New frmRule
            frm.AssocObj = nd.Tag
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ShowDetail(tvKnowTree.SelectedNode.Tag)
            End If
        End If
    End Sub


    '右键属性菜单：添加


    Private Sub tsAddAttr_Click(sender As Object, e As EventArgs) Handles tsAddAttr.Click
        If tvKnowTree.SelectedNode Is Nothing Then Return
        If tvKnowTree.SelectedNode.Tag Is Nothing Then Return
        If TypeOf tvKnowTree.SelectedNode.Tag Is KnowNode Then
            Dim kn As KnowNode = tvKnowTree.SelectedNode.Tag
            Dim frm As New frmAttr
            frm.Belong = kn
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ShowItem(frm.EditAttr, Color.Blue)
            End If

        ElseIf TypeOf tvKnowTree.SelectedNode.Tag Is KnowTree Then
            Dim kr As KnowTree = tvKnowTree.SelectedNode.Tag
            Dim frm As New frmVariable()
            frm.KnowTree = kr
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ShowDetail(tvKnowTree.SelectedNode.Tag)
            End If
        End If
    End Sub

    '右键属性菜单：编辑
    Private Sub tsEditAttr_Click(sender As Object, e As EventArgs) Handles tsEditAttr.Click
        If tvKnowTree.SelectedNode Is Nothing Then Return
        If tvKnowTree.SelectedNode.Tag Is Nothing Then Return
        If lvAttr.SelectedItems.Count = 0 Then Return
        Dim IsConc As Boolean
        Dim sel As Integer = lvAttr.SelectedIndices(0)
        Dim Attr As Attribute = lvAttr.SelectedItems(0).Tag
        If TypeOf tvKnowTree.SelectedNode.Tag Is KnowNode Then
            Dim kn As KnowNode = tvKnowTree.SelectedNode.Tag
            Dim frm As New frmAttr
            If lvAttr.SelectedItems(0).ForeColor.Equals(Color.Red) Then
                IsConc = True
                frm.Belong = kn.Key
            Else
                IsConc = False
                frm.Belong = kn
            End If
            frm.EditAttr = Attr
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                lvAttr.Items.RemoveAt(sel)
                Dim itm As ListViewItem = lvAttr.Items.Insert(sel, frm.EditAttr.AttrName.ShowNoCode())
                itm.Tag = frm.EditAttr
                itm.ForeColor = IIf(IsConc, Color.Red, Color.Blue)
                If Not frm.EditAttr.AttrValue Is Nothing Then
                    If frm.EditAttr.AttrValue.GetType().IsSubclassOf(GetType(Meaning)) Then
                        Dim mn As Meaning = frm.EditAttr.AttrValue
                        itm.SubItems.Add(mn.ShowNoCode())
                    Else
                        itm.SubItems.Add(frm.EditAttr.AttrValue.ToString())
                    End If
                End If
            End If
        ElseIf TypeOf tvKnowTree.SelectedNode.Tag Is KnowTree Then
            MsgBox("请用删除、添加方式来修改！")
        End If
    End Sub


    '右键属性菜单：删除
    Private Sub tsDelAttr_Click(sender As Object, e As EventArgs) Handles tsDelAttr.Click
        If tvKnowTree.SelectedNode Is Nothing Then Return
        If tvKnowTree.SelectedNode.Tag Is Nothing Then Return
        If TypeOf tvKnowTree.SelectedNode.Tag Is KnowNode Then
            If lvAttr.SelectedItems.Count = 0 Then Return
            Dim Attr As Attribute = lvAttr.SelectedItems(0).Tag
            If MsgBox("真的要删除属性：" & Attr.ShowNoCode() & "　否？", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Return
            Dim kn As KnowNode = tvKnowTree.SelectedNode.Tag
            Dim Trans As SqlTransaction = kn.KnowTree.Domain.WhichServer.Database.BeginTransaction()
            If Attr.DBDelete(kn, Trans) Then
                Trans.Commit()
                kn.Attributes.Remove(Attr)
                lvAttr.Items.RemoveAt(lvAttr.SelectedIndices(0))
            Else
                Trans.Rollback()
                MsgBox("从数据库中删除属性出错，详情见日志！")
            End If
        ElseIf TypeOf tvKnowTree.SelectedNode.Tag Is KnowTree Then
            If lvAttr.SelectedItems.Count = 0 Then Return
            Dim kr As KnowTree = tvKnowTree.SelectedNode.Tag
            Dim inst As InstanceOfNode = lvAttr.SelectedItems(0).Tag
            If MsgBox("真的要删除知识树：" & kr.TreeName & " 的实例：" & inst.Instance.Name & " 否？",
                MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton2, "操作确认") = MsgBoxResult.Yes Then
                Dim Trans As SqlTransaction = kr.Domain.WhichServer.Database.BeginTransaction()
                If inst.DBDelete(Trans) Then
                    '20160916修改: 增加Commit语句
                    Trans.Commit()
                    kr.InstanceList.Remove(inst)
                    lvAttr.Items.Remove(lvAttr.SelectedItems(0))
                End If
            End If
        End If
    End Sub

    Private Sub tsMenu_Click(sender As Object, e As EventArgs) Handles tsMenu.Click
        Dim frm As New frmQuestionAnswer
        frm.Show()
    End Sub
End Class
