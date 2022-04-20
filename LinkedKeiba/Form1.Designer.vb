<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.AxJVLink1 = New AxJVDTLabLib.AxJVLink()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mmuConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfJV = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGetJVData = New System.Windows.Forms.Button()
        Me.rtbData = New System.Windows.Forms.RichTextBox()
        Me.prgDownload = New System.Windows.Forms.ProgressBar()
        Me.prgJVRead = New System.Windows.Forms.ProgressBar()
        Me.tmrDownload = New System.Windows.Forms.Timer(Me.components)
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AxJVLink1
        '
        Me.AxJVLink1.Enabled = True
        Me.AxJVLink1.Location = New System.Drawing.Point(452, 27)
        Me.AxJVLink1.Name = "AxJVLink1"
        Me.AxJVLink1.OcxState = CType(resources.GetObject("AxJVLink1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxJVLink1.Size = New System.Drawing.Size(117, 61)
        Me.AxJVLink1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mmuConfig})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(581, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mmuConfig
        '
        Me.mmuConfig.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConfJV})
        Me.mmuConfig.Name = "mmuConfig"
        Me.mmuConfig.Size = New System.Drawing.Size(58, 20)
        Me.mmuConfig.Text = "設定(&C)"
        '
        'mnuConfJV
        '
        Me.mnuConfJV.Name = "mnuConfJV"
        Me.mnuConfJV.Size = New System.Drawing.Size(157, 22)
        Me.mnuConfJV.Text = "JV-Linkの設定(&J)"
        '
        'btnGetJVData
        '
        Me.btnGetJVData.Location = New System.Drawing.Point(12, 37)
        Me.btnGetJVData.Name = "btnGetJVData"
        Me.btnGetJVData.Size = New System.Drawing.Size(90, 52)
        Me.btnGetJVData.TabIndex = 2
        Me.btnGetJVData.Text = "データ取得"
        Me.btnGetJVData.UseVisualStyleBackColor = True
        '
        'rtbData
        '
        Me.rtbData.Location = New System.Drawing.Point(12, 95)
        Me.rtbData.Name = "rtbData"
        Me.rtbData.Size = New System.Drawing.Size(557, 343)
        Me.rtbData.TabIndex = 3
        Me.rtbData.Text = ""
        Me.rtbData.WordWrap = False
        '
        'prgDownload
        '
        Me.prgDownload.Location = New System.Drawing.Point(108, 37)
        Me.prgDownload.Name = "prgDownload"
        Me.prgDownload.Size = New System.Drawing.Size(461, 23)
        Me.prgDownload.TabIndex = 4
        '
        'prgJVRead
        '
        Me.prgJVRead.Location = New System.Drawing.Point(108, 66)
        Me.prgJVRead.Name = "prgJVRead"
        Me.prgJVRead.Size = New System.Drawing.Size(461, 23)
        Me.prgJVRead.TabIndex = 5
        '
        'tmrDownload
        '
        Me.tmrDownload.Interval = 500
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 450)
        Me.Controls.Add(Me.prgJVRead)
        Me.Controls.Add(Me.prgDownload)
        Me.Controls.Add(Me.rtbData)
        Me.Controls.Add(Me.btnGetJVData)
        Me.Controls.Add(Me.AxJVLink1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Form1"
        CType(Me.AxJVLink1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AxJVLink1 As AxJVDTLabLib.AxJVLink
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mmuConfig As ToolStripMenuItem
    Friend WithEvents mnuConfJV As ToolStripMenuItem
    Friend WithEvents btnGetJVData As Button
    Friend WithEvents rtbData As RichTextBox
    Friend WithEvents prgDownload As ProgressBar
    Friend WithEvents prgJVRead As ProgressBar
    Friend WithEvents tmrDownload As Timer
End Class
