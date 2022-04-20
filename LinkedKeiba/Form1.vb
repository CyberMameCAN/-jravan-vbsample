Public Class frmMain

    Private lDownloadCount As Long  ' JVOpne 総ダウンロードファイル数
    Private JVOpenFlg As Boolean      ' JVOpen 状態フラグ Open時:True

    Private Sub mnuConfJV_Click(sender As Object, e As EventArgs) Handles mnuConfJV.Click
        Try
            ' リターンコード
            Dim lReturnCode As Long
            ' 設定画面表示
            lReturnCode = AxJVLink1.JVSetUIProperties()
            If lReturnCode <> 0 Then
                MsgBox("JVSetUIPropertiesエラー コード：" & lReturnCode & ":", MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sid As String
        Dim lReturnCode As Long

        sid = "Test"  ' 呼び出し元の競馬ソフトの指定

        ' JVLink初期化
        lReturnCode = Me.AxJVLink1.JVInit(sid)

        If lReturnCode <> 0 Then
            MsgBox("JVInitエラーコード：" & lReturnCode & " : ", MessageBoxIcon.Error)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
    End Sub

    Private Sub btnGetJVData_Click(sender As Object, e As EventArgs) Handles btnGetJVData.Click
        Dim lReturnCode As Long

        Try
            Dim strDataSpec As String  ' JVOpen ファイル識別子
            Dim strFromTime As String  ' JVOpen データ提供日付
            Dim lOption As Long  ' JVOpen オプション
            Dim lReadCount As Long  ' JVOpen 戻り値
            'Dim lDownloadCount As Long  ' JVOpen 総ダウンロードファイル数
            Dim strLastFileTimestamp As String  ' JVOpen 最新ファイルのタイムスタンプ

            Const lBuffSize As Long = 110000  ' JVRead データ格納バッファサイズ
            Const lNameSize As Integer = 256  ' JVRead ファイル名サイズ
            Dim strBuff As String  ' JVRead データ格納バッファ
            Dim strFileName As String  ' JVRead ダウンロードファイル名
            Dim RaceInfo As JV_RA_RACE  ' レース詳細情報構造体

            ' 進捗状況表示初期設定
            tmrDownload.Enabled = False  ' タイマー停止
            prgDownload.Value = 0           ' JVData ダウンロード進捗
            prgJVRead.Value = 0              ' JVData 読み込み進捗

            strDataSpec = "RACE"
            strFromTime = "20050301000000"
            lOption = "2"

            ' JVLinkダウンロード処理
            lReturnCode = Me.AxJVLink1.JVOpen(strDataSpec, strFromTime, lOption, lReadCount, lDownloadCount, strLastFileTimestamp)
            If lReturnCode <> 0 Then
                MsgBox("JVOpenエラー：" & lReturnCode)
            Else
                MsgBox("戻り値：" & lReturnCode & vbCrLf &
                       "読み込みファイル数：" & lReadCount & vbCrLf &
                       "ダウンロードファイル数：" & lDownloadCount & vbCrLf &
                       "タイムスタンプ：" & strLastFileTimestamp)

                ' 進捗表示プログラスバー最大値設定
                If lDownloadCount = 0 Then
                    prgDownload.Maximum = 100  ' ダウンロード必要なし
                    prgDownload.Value = 100        ' 
                Else
                    prgDownload.Maximum = lDownloadCount
                    prgDownload.Value = True      ' タイマー開始
                End If
                prgJVRead.Maximum = lReadCount

                If lReadCount > 0 Then
                    Do
                        ' バックグラウンドでの処理を実行
                        Application.DoEvents()

                        strBuff = New String(vbNullChar, lBuffSize)
                        strFileName = New String(vbNullChar, lNameSize)

                        ' 1行読み込み
                        lReturnCode = Me.AxJVLink1.JVRead(strBuff, lBuffSize, strFileName)
                        Select Case lReturnCode
                            Case 0  ' 全ファイル読み込み終了
                                prgJVRead.Value = prgJVRead.Maximum  ' 進捗表示
                                Exit Do
                            Case -1  ' ファイル切り替わり
                                prgJVRead.Value = prgJVRead.Value + 1
                            Case -3  'ダウンロード中
                            Case -201  ' Initされていない
                                MsgBox("JVInitが行われていません")
                                Exit Do
                            Case -203  ' Openされていない
                                MsgBox("JVOpenが行われていません")
                                Exit Do
                            Case -503  ' ファイルがない
                                MsgBox(strFileName & "が存在しません")
                                Exit Do
                            Case Is > 0  ' 正常
                                ' ID(レコード種別)の識別
                                If Mid(strBuff, 1, 2) = "RA" Then
                                    ' レース詳細のみ処理
                                    ' レース詳細構造体への展開
                                    RaceInfo.SetData(strBuff)

                                    ' データ表示
                                    rtbData.AppendText("年：" & RaceInfo.id.Year &
                                                                   " 月日：" & RaceInfo.id.MonthDay &
                                                                   " 場：" & RaceInfo.id.JyoCD &
                                                                   " 回次：" & RaceInfo.id.Kaiji &
                                                                   " 日次：" & RaceInfo.id.Nichiji &
                                                                   " R：" & RaceInfo.id.RaceNum &
                                                                   " レース名：" & RaceInfo.RaceInfo.Ryakusyo10 &
                                                                   "天候コード：" & RaceInfo.TenkoBaba.TenkoCD &
                                                                   vbCrLf)
                                End If
                        End Select
                    Loop While (1)
                End If

                ' タイマー有効時は、無効化する
                If tmrDownload.Enabled = True Then
                    tmrDownload.Enabled = False
                    prgDownload.Value = prgDownload.Maximum
                End If

            End If
        Catch ex As Exception
            Debug.WriteLine(Err.Description)
            Exit Sub
        End Try

        ' JVLink終了処理
        lReturnCode = Me.AxJVLink1.JVClose()
        If lReturnCode <> 0 Then
            MsgBox("JVCloseエラー：" & lReturnCode)
        End If

    End Sub

    Private Sub tmrDownload_Tick(sender As Object, e As EventArgs) Handles tmrDownload.Tick
        Dim lReturnCode As Long  ' JVLink 返り値

        ' JVLinkダウンロード進捗率
        lReturnCode = AxJVLink1.JVStatus  ' ダウンロード済みのファイル数を返す
        If lReturnCode < 0 Then
            MsgBox("JVStatusエラー：" & lReturnCode)
            ' タイマー停止
            tmrDownload.Enabled = False

            'JVLink終了処理
            lReturnCode = Me.AxJVLink1.JVClose()
            If lReturnCode <> 0 Then
                MsgBox("JVCloseエラー：" & lReturnCode)
            End If

        ElseIf lReturnCode < lDownloadCount Then
            ' ダウンロード中
            ' プログレス表示
            prgDownload.Enabled = lReturnCode

        ElseIf lReturnCode = lDownloadCount Then
            ' ダウンロード完了
            ' タイマー停止
            tmrDownload.Enabled = False
            ' プログレス表示
            prgDownload.Value = lReturnCode

        End If

    End Sub
End Class
