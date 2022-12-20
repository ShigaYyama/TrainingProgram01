Public Class App

    'アプリケーションの2重起動チェック
    Public Shared Sub LoadCheck()


        ' 自分自身のプロセス名を取得する
        Dim myProcess As String = System.Diagnostics.Process.GetCurrentProcess().ProcessName

        ' 取得した同名のプロセスが他に存在するかを確認する
        If Diagnostics.Process.GetProcessesByName(myProcess).Length > 1 Then
            ' 存在する場合はエラーとする
            MessageBox.Show("既にアプリケーションが起動しています。")
            Application.Exit()
        End If

    End Sub
End Class
