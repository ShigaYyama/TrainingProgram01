Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Reflection
Imports System.Text
Imports Oracle.ManagedDataAccess.Client
Imports OracleInternal.Json

Public Class Tasks

    '配列：課題シート名
    Shared ArryTask() As String = {"課題①", "課題②", "課題③", "課題④", "課題⑤", "課題⑥"}

    '配列：課題シート名
    Shared ArrySubTask1() As String = {"問題01", "問題02", "問題03", "問題04", "問題05", "問題06", "問題07"}
    Shared ArrySubTask2() As String = {"問題01", "問題02", "問題03", "問題04", "問題05"}
    Shared ArrySubTask3() As String = {"問題解答①", "問題解答②"}
    Shared ArrySubTask4() As String = {"問題01", "問題02", "問題03", "問題04", "問題05", "問題06", "問題07", "問題08", "問題09"}
    Shared ArrySubTask5() As String = {"問題解答"}
    Shared ArrySubTask6() As String = {"問題解答"}

    'コンボボックス1に入れる値を配列で格納
    Public Shared Function Cbo1SetItems() As String()

        Return ArryTask

    End Function

    'コンボボックス2に入れる値を配列で格納(コンボボックス1の値で条件分岐する条件式)
    Public Shared Function Cbo2SetItems(cbo1 As String) As String()

        Dim cbo2 As String() = Nothing

        Select Case cbo1

            Case ArryTask(0)
                cbo2 = ArrySubTask1

            Case ArryTask(1)
                cbo2 = ArrySubTask2

            Case ArryTask(2)
                cbo2 = ArrySubTask3

            Case ArryTask(3)
                cbo2 = ArrySubTask4

            Case ArryTask(4)
                cbo2 = ArrySubTask5

            Case ArryTask(5)
                cbo2 = ArrySubTask6

            Case Else

        End Select

        Return cbo2

    End Function


    'SQL文を返すための準備(大村さん修正)
    Public Shared Function CboSelected(cbo1Index As Integer, cbo2Index As Integer) As Integer

        ' 選択されていない場合は-1を返す
        If cbo1Index < 0 Or cbo2Index < 0 Then
            Return -1
        End If

        Return cbo1Index * 10 + cbo2Index

    End Function


    'SQL文を返すための準備(修正前自作)
    'Public Shared Function CboSelected(cbo1 As String, cbo2 As String)

    '    'コンボボックス1とコンボボックス2の値によって、Functionに返す値を条件分岐する
    '    Dim AnsInt As Integer = Nothing

    '    Select Case cbo1

    '        Case "課題①"

    '            Select Case cbo2
    '                Case "問題01"
    '                    AnsInt = 0
    '                Case "問題02"
    '                    AnsInt = 1
    '                Case "問題03"
    '                    AnsInt = 2
    '                Case "問題04"
    '                    AnsInt = 3
    '                Case "問題05"
    '                    AnsInt = 4
    '                Case "問題06"
    '                    AnsInt = 5
    '                Case "問題07"
    '                    AnsInt = 6
    '            End Select

    '        Case "課題②"

    '            Select Case cbo2
    '                Case "問題01"
    '                    AnsInt = 10
    '                Case "問題02"
    '                    AnsInt = 11
    '                Case "問題03"
    '                    AnsInt = 12
    '                Case "問題04"
    '                    AnsInt = 13
    '                Case "問題05"
    '                    AnsInt = 14
    '            End Select

    '        Case "課題③"

    '            Select Case cbo2
    '                Case "問題解答①"
    '                    AnsInt = 20
    '                Case "問題解答②"
    '                    AnsInt = 21
    '            End Select

    '        Case "課題④"

    '            Select Case cbo2
    '                Case "問題01"
    '                    AnsInt = 30
    '                Case "問題02"
    '                    AnsInt = 31
    '                Case "問題03"
    '                    AnsInt = 32
    '                Case "問題04"
    '                    AnsInt = 33
    '                Case "問題05"
    '                    AnsInt = 34
    '                Case "問題06"
    '                    AnsInt = 35
    '                Case "問題07"
    '                    AnsInt = 36
    '                Case "問題08"
    '                    AnsInt = 37
    '                Case "問題09"
    '                    AnsInt = 38
    '            End Select

    '        Case "課題⑤"

    '            If cbo2 = "問題解答" Then
    '                AnsInt = 40
    '            End If

    '        Case "課題⑥"

    '            If cbo2 = "問題解答" Then
    '                AnsInt = 50
    '            End If
    '    End Select

    '    CboSelected = AnsInt

    'End Function

    Public Shared Function SelectSql(Subject As Integer) As String

        'コンボボックスの選択された値によって、Functionで返す値を条件分岐する
        Dim ExcSelect As String = Nothing

        Select Case Subject
                '回答文　課題①
            Case 0
                ExcSelect = Query1_1()
            Case 1
                ExcSelect = Query1_2()
            Case 2
                ExcSelect = Query1_3()
            Case 3
                ExcSelect = Query1_4()
            Case 4
                ExcSelect = Query1_5()
            Case 5
                ExcSelect = Query1_6()
            Case 6
                ExcSelect = Query1_7()
                '回答文　課題②
            Case 10
                ExcSelect = Query2_1()
            Case 11
                ExcSelect = Query2_2()
            Case 12
                ExcSelect = Query2_3()
            Case 13
                ExcSelect = Query2_4()
            Case 14
                ExcSelect = Query2_5()
                '回答文　課題③
            Case 20
                ExcSelect = Query3_1()
            Case 21
                ExcSelect = Query3_2()
                '回答文　課題④
            Case 30
                ExcSelect = Query4_1()
            Case 31
                ExcSelect = Query4_2()
            Case 32
                ExcSelect = Query4_3()
            Case 33
                ExcSelect = Query4_4()
            Case 34
                ExcSelect = Query4_5()
            Case 35
                ExcSelect = Query4_6()
            Case 36
                ExcSelect = Query4_7()
            Case 37
                ExcSelect = Query4_8()
            Case 38
                ExcSelect = Query4_9()
                '回答文　課題⑤
            Case 40
                ExcSelect = Query5_1()
                '回答文　課題⑥
            Case 50
                ExcSelect = Query6_1()

        End Select

        Return ExcSelect

    End Function


    '回答文　課題①
    Public Shared Function Query1_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT DISTINCT 顧客マスタ.顧客番号,顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "INNER JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "WHERE 売場トラン.売上金額>= 10000" & vbLf
        QueryComm &= "ORDER BY 顧客マスタ.顧客番号 ASC"

        Query1_1 = QueryComm

    End Function
    Public Shared Function Query1_2() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.性別,SUM(売場トラン.売上金額)AS 売上金額合計" & vbLf
        QueryComm &= "FROM 売場トラン" & vbLf
        QueryComm &= "INNER JOIN 顧客マスタ" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.性別"

        Query1_2 = QueryComm

    End Function
    Public Shared Function Query1_3() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "INNER JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "WHERE 売場トラン.売場 = '食品'" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名'"

        Query1_3 = QueryComm

    End Function
    Public Shared Function Query1_4() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 氏名,TRUNC((20220506 - TO_CHAR(生年月日, 'YYYYMMDD')) /10000, 0) AS 年齢" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "ORDER BY 顧客番号 ASC"

        Query1_4 = QueryComm

    End Function

    Public Shared Function Query1_5() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 氏名,連絡先１ AS 連絡先" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "UNION SELECT 氏名,連絡先２ AS 連絡先" & vbLf
        QueryComm &= "FROM 顧客マスタ"

        Query1_5 = QueryComm

    End Function

    Public Shared Function Query1_6() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名,COUNT(売場トラン.売場) AS 回数" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "AND 売場トラン.売場 IN('レストラン')" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名"

        Query1_6 = QueryComm

    End Function
    Public Shared Function Query1_7() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名,COUNT(売場トラン.売場) AS 回数" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "AND 売場トラン.売場 IN('レストラン')" & vbLf
        QueryComm &= "WHERE 顧客マスタ.氏名 LIKE '%山%'" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名"

        Query1_7 = QueryComm

    End Function

    '回答文　課題②
    Public Shared Function Query2_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT  s_no," & vbLf
        QueryComm &= "CASE WHEN s_name THEN NULL WHEN '未入力' THEN s_name END" & vbLf
        QueryComm &= "FROM ex_tbl"

        Query2_1 = QueryComm

    End Function

    Public Shared Function Query2_2() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT  s_no," & vbLf
        QueryComm &= "CURRENT_DATE()" & vbLf
        QueryComm &= "FROM ex_tbl"

        Query2_2 = QueryComm

    End Function

    Public Shared Function Query2_3() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM 売場トラン"

        Query2_3 = QueryComm

    End Function

    Public Shared Function Query2_4() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM 売場トラン"

        Query2_4 = QueryComm

    End Function

    Public Shared Function Query2_5() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM 売場トラン"

        Query2_5 = QueryComm

    End Function

    '回答文　課題③
    Public Shared Function Query3_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT ログイン情報.顧客番号,ログイン情報.LOGIN_ID,顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN ログイン情報" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = ログイン情報.顧客番号" & vbLf
        QueryComm &= "WHERE ログイン情報.顧客番号" & vbLf
        QueryComm &= "IN ('10001','10004')"

        Query3_1 = QueryComm

    End Function
    Public Shared Function Query3_2() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT ログイン情報.顧客番号,ログイン情報.LOGIN_ID,顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "INNER JOIN ログイン情報" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = ログイン情報.顧客番号" & vbLf
        QueryComm &= "WHERE EXISTS( SELECT 顧客番号,LOGIN_ID" & vbLf
        QueryComm &= "FROM ログイン情報" & vbLf
        QueryComm &= "WHERE 顧客番号" & vbLf
        QueryComm &= "IN ('10001','10004'))"

        Query3_2 = QueryComm

    End Function

    '回答文　課題④
    Public Shared Function Query4_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN 売場マスタ" & vbLf
        QueryComm &= "ON アイテムトラン.売場番号 = 売場マスタ.売場番号"

        Query4_1 = QueryComm

    End Function

    Public Shared Function Query4_2() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号"

        Query4_2 = QueryComm

    End Function

    Public Shared Function Query4_3() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "INSERT INTO アイテムマスタ" & vbLf
        QueryComm &= "SELECT アイテムトラン.種類番号,'ハム',アイテムマスタ.在庫状態,アイテムマスタ.区分１,アイテムマスタ.区分２" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号" & vbLf
        QueryComm &= "WHERE アイテムトラン.種類番号" & vbLf
        QueryComm &= "IN 2"

        Query4_3 = QueryComm

    End Function

    Public Shared Function Query4_4() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号" & vbLf
        QueryComm &= "INNER JOIN 売場マスタ" & vbLf
        QueryComm &= "ON アイテムトラン.売場番号 = 売場マスタ.売場番号" & vbLf
        QueryComm &= "WHERE アイテムマスタ.区分１" & vbLf
        QueryComm &= "IS NOT NULL"

        Query4_4 = QueryComm

    End Function

    Public Shared Function Query4_5() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "LEFT JOIN 売場マスタ" & vbLf
        QueryComm &= "ON アイテムトラン.売場番号 = 売場マスタ.売場番号"

        Query4_5 = QueryComm

    End Function

    Public Shared Function Query4_6() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "LEFT JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号"

        Query4_6 = QueryComm

    End Function

    Public Shared Function Query4_7() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "INSERT INTO アイテムマスタ" & vbLf
        QueryComm &= "SELECT アイテムトラン.種類番号,'ハム',アイテムマスタ.在庫状態,アイテムマスタ.区分１,アイテムマスタ.区分２" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "LEFT JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号" & vbLf
        QueryComm &= "WHERE アイテムトラン.種類番号" & vbLf
        QueryComm &= "IN 2"

        Query4_7 = QueryComm

    End Function

    Public Shared Function Query4_8() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "LEFT JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号" & vbLf
        QueryComm &= "LEFT JOIN 売場マスタ" & vbLf
        QueryComm &= "ON アイテムトラン.売場番号 = 売場マスタ.売場番号" & vbLf
        QueryComm &= "WHERE アイテムマスタ.区分１" & vbLf
        QueryComm &= "IS NOT NULL"

        Query4_8 = QueryComm

    End Function

    Public Shared Function Query4_9() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT アイテムトラン.種類番号," & vbLf
        QueryComm &= "CASE アイテムマスタ.在庫状態" & vbLf
        QueryComm &= "WHEN 'A' THEN '在庫あり'" & vbLf
        QueryComm &= "WHEN 'B' THEN '予約注文'" & vbLf
        QueryComm &= "WHEN 'C' THEN '在庫なし'" & vbLf
        QueryComm &= "ELSE '未定' END" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号"

        Query4_9 = QueryComm

    End Function

    '回答文　課題⑤
    Public Shared Function Query5_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "CREATE TABLE USER_MASTER" & vbLf
        QueryComm &= "(" & vbLf
        QueryComm &= "USER_ID      VARCHAR2(8) NOT NULL PRIMARY KEY," & vbLf
        QueryComm &= "DEPT_NO      VARCHAR2(8)," & vbLf
        QueryComm &= "USER_NAME    VARCHAR2(32)," & vbLf
        QueryComm &= "CREATED_ON   DATE DEFAULT SYSDATE," & vbLf
        QueryComm &= "MODIFIED_ON  DATE" & vbLf
        QueryComm &= ")"

        Query5_1 = QueryComm

    End Function

    '回答文　課題⑥
    Public Shared Function Query6_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 階数," & vbLf
        QueryComm &= "LISTAGG(売場, ',') WITHIN GROUP (ORDER BY 連番) 売場リスト" & vbLf
        QueryComm &= "FROM 売場階数トラン" & vbLf
        QueryComm &= "GROUP BY 階数"

        Query6_1 = QueryComm

    End Function


End Class


'Public Shared Function SelectSql(Subject As Integer) As String

'    'ここの配列にメソッド名を入れる

'    '回答のSQL文を配列として格納（AnsSql1～6として変数を割り振る）
'    Dim AnsSql1() As String = {"Query1_1","Query1_2","Query1_3","Query1_4","Query1_5","Query1_6","Query1_7"}
'    Dim AnsSql2() As String = {"Query2_1","Query2_2","Query2_3","Query2_4","Query2_5"}
'    Dim AnsSql3() As String = {"Query3_1","Query3_2"}
'    Dim AnsSql4() As String = {"Query4_1","Query4_2","Query4_3","Query4_4","Query4_5","Query4_6","Query4_7","Query4_8","Query4_9"}
'    Dim AnsSql5() As String = {"Query5_1"}
'    Dim AnsSql6() As String = {"Query6_1"}

'配列のメソッド名を条件分岐で呼び出す
'    'コンボボックスの選択された値によって、Functionで返す値を条件分岐する
'    Dim Sql() As String = Nothing
'    Dim ExcSelect As String = Nothing

'    Select Case Subject
'        Case < 10
'            Sql = AnsSql1
'            For i As Integer = 0 To UBound(Sql)

'                If Subject = i Then
'                    ExcSelect = Call (Sql(i))
'                End If

'            Next
'        Case < 20
'            Sql = AnsSql2
'            For i As Integer = 0 To UBound(Sql)

'                If Subject = 10 + i Then
'                    ExcSelect = Sql(i)
'                End If

'            Next
'        Case < 30
'            Sql = AnsSql3
'            For i As Integer = 0 To UBound(Sql)

'                If Subject = 20 + i Then
'                    ExcSelect = Sql(i)
'                End If

'            Next
'        Case < 40
'            Sql = AnsSql4
'            For i As Integer = 0 To UBound(Sql)

'                If Subject = 30 + i Then
'                    ExcSelect = Sql(i)
'                End If

'            Next
'        Case < 50
'            Sql = AnsSql5
'            For i As Integer = 0 To UBound(Sql)

'                If Subject = 40 + i Then
'                    ExcSelect = Sql(i)
'                End If

'            Next
'        Case < 60
'            Sql = AnsSql6
'            For i As Integer = 0 To UBound(Sql)

'                If Subject = 50 + i Then
'                    ExcSelect = Sql(i)
'                End If

'            Next
'    End Select

'    Return ExcSelect

'End Function






