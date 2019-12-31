Imports Connet

Public Class frmQuestionAnswer

    Private _knowTree As KnowTree = frmMain.SelectTree
    Private Enum QuesType
        enumTime = 0 '时间类型
    End Enum

    Private Sub btAsk_Click(sender As Object, e As EventArgs) Handles btAsk.Click
        Dim textArr() As String = Split(tbEdit.Text, " ")

        Dim nodeList As New ArrayList()
        For Each tex In textArr
            If GetNode(tex) Is Nothing Then
                Continue For
            End If
            nodeList.Add(GetNode(tex))
        Next

        ' 第一步：获取疑问句类型
        Dim qType As QuesType = getQuestionType(nodeList)
        tbShow.Text = "Q:" & tbEdit.Text
    End Sub

    Private Function GetNode(ByVal nodeName As String) As KnowNode
        ' 只考虑到知识树上没有相同节点。如果一棵知识树上有多个相同知识点，需要重新编写
        For Each node As KnowNode In _knowTree.KnowNodeList
            If node.Name = nodeName Then
                Return node
            End If
        Next
        Return Nothing
    End Function

    Private Function getQuestionType(ByVal nodeList As ArrayList) As QuesType
        For Each node As KnowNode In nodeList
            Dim attrList As New ArrayList()
            GetAllAttr(node, attrList)
            For Each attr As Attribute In attrList
                Dim a As Integer = 1
            Next
        Next
        Return Nothing
    End Function

    Private Sub GetAllAttr(ByVal node As KnowNode, ByRef attrList As ArrayList)
        ' 继承所以父节点的属性
        For Each attr In node.Attributes
            attrList.Add(attr)
        Next
        If TypeName(node.Parent) = "KnowNode" Then
            GetAllAttr(node.Parent, attrList)
        End If
    End Sub
End Class