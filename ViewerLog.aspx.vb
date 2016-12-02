Imports BusinessLogicLayer
Imports DataTypeObject
Partial Class ViewerLog
    Inherits System.Web.UI.Page

    Private Sub ViewerLog_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Dim logLevel As String = LogDTO.level.DEBUG
        Dim since As String = SinceCalendar.SelectedDate.ToShortDateString
        Dim until As String = UntilCalendar.SelectedDate.ToShortDateString

        'If Not IsNothing(Request.QueryString("level")) Then
        '    logLevel = Request.QueryString("level")
        'End If

        'If IsNothing(Session("LogCriteria")) Then
        '    RetrieveLogs(LogDTO.level.INFO)
        'Else
        '    Dim criteria As Dictionary(Of String, String) = Session("LogCriteria")
        '    RetrieveLogs(criteria("loglevel"), criteria("since"), criteria("until"))
        'End If
        RetrieveLogs(logLevel, since, until)

    End Sub

    Protected Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click
        '' Recarga la página con los criterios seleccionados
        'Dim criteria As New Dictionary(Of String, String)
        'criteria.Add("loglevel", CmbLevel.SelectedValue)
        'criteria.Add("since", SinceCalendar.SelectedDate.ToString())
        'criteria.Add("until", UntilCalendar.SelectedDate.ToString())
        'Session("LogCriteria") = criteria
        'Response.Redirect("ViewerLog.aspx")
    End Sub

    Private Sub RetrieveLogs(ByRef level As String, ByRef Optional since As String = Nothing, ByRef Optional until As String = Nothing)
        If IsNothing(Session("user")) Then
            ' Si no hay usuario en sessión, redirige al login
            Response.Redirect("LogIn.aspx")
        Else
            Dim logBll As New LogBLL()
            Dim result As ResultDTO
            result = logBll.GetLog(level, since, until)

            LogGridView.DataSource = result.value
            LogGridView.DataBind()
        End If
    End Sub

    'Private Sub ViewerLog_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    SinceCalendar.SelectedDate = Now.AddDays(-1)
    '    UntilCalendar.SelectedDate = Now.AddDays(1)
    'End Sub
End Class
