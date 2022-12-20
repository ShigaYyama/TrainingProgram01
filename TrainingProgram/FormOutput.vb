Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Oracle.ManagedDataAccess.Client
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Text
Imports System.Reflection

Public Class frmOutput

    '画面起動時
    Private Sub frmLoading(sender As Object, e As EventArgs) Handles MyBase.Load

        '2重起動確認
        App.LoadCheck()

        'データベース接続確認
        DataBases.Loading()

        'コンボボックス1に値を設定(配列)
        For Each Cbo1Items In Tasks.Cbo1SetItems
            cboKadai1.Items.Add(Cbo1Items)
        Next


    End Sub


    'コンボボックス（cboKadai1）値変更時
    Public Sub KadaiSheetSelected(sender As Object, e As EventArgs) Handles cboKadai1.SelectedIndexChanged

        '選択されたコンボボックス（cboKadai1）のシートに内にある問題の一覧を、コンボボックス（cboKadai2）に設定
        cboKadai2.Items.Clear()
        For Each Cbo2Items In Tasks.Cbo2SetItems(cboKadai1.Text)
            cboKadai2.Items.Add(Cbo2Items)
        Next

    End Sub


    '出力ボタン（btnOutput）押下時
    Private Sub OutputProc(sender As Object, e As EventArgs) Handles btnOutput.Click

        'データをエクセル出力
        DataBases.OutPuting(cboKadai1.SelectedIndex, cboKadai2.SelectedIndex)

    End Sub

    '閉じるボタン（btnExit）押下時
    Private Sub ExitProc(sender As Object, e As EventArgs) Handles btnClose.Click

        'アプリケーションを終了
        Application.Exit()

    End Sub

    'フォーム終了時
    Private Sub frmClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        'データベースとの接続を切断
        DataBases.Closing()

    End Sub


End Class



