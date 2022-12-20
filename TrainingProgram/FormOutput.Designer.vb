<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOutput
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblOutputScreen = New System.Windows.Forms.Label()
        Me.btnOutput = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cboKadai1 = New System.Windows.Forms.ComboBox()
        Me.cboKadai2 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblOutputScreen
        '
        Me.lblOutputScreen.AutoSize = True
        Me.lblOutputScreen.Location = New System.Drawing.Point(56, 42)
        Me.lblOutputScreen.Name = "lblOutputScreen"
        Me.lblOutputScreen.Size = New System.Drawing.Size(116, 18)
        Me.lblOutputScreen.TabIndex = 0
        Me.lblOutputScreen.Text = "帳票出力画面"
        '
        'btnOutput
        '
        Me.btnOutput.Location = New System.Drawing.Point(227, 310)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(117, 40)
        Me.btnOutput.TabIndex = 1
        Me.btnOutput.Text = "出力"
        Me.btnOutput.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(402, 310)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(118, 40)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "終了"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cboKadai1
        '
        Me.cboKadai1.FormattingEnabled = True
        Me.cboKadai1.Location = New System.Drawing.Point(64, 117)
        Me.cboKadai1.Name = "cboKadai1"
        Me.cboKadai1.Size = New System.Drawing.Size(360, 26)
        Me.cboKadai1.TabIndex = 3
        '
        'cboKadai2
        '
        Me.cboKadai2.FormattingEnabled = True
        Me.cboKadai2.Location = New System.Drawing.Point(59, 215)
        Me.cboKadai2.Name = "cboKadai2"
        Me.cboKadai2.Size = New System.Drawing.Size(365, 26)
        Me.cboKadai2.TabIndex = 4
        '
        'frmOutput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 419)
        Me.Controls.Add(Me.cboKadai2)
        Me.Controls.Add(Me.cboKadai1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOutput)
        Me.Controls.Add(Me.lblOutputScreen)
        Me.Name = "frmOutput"
        Me.Text = "帳票出力"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblOutputScreen As Label
    Friend WithEvents btnOutput As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents cboKadai1 As ComboBox
    Friend WithEvents cboKadai2 As ComboBox
End Class
