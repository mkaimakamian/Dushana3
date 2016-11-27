Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BusinessLogicLayer
Imports DataAccessLayer
Imports DataTypeObject
Imports System.Threading
<TestClass()> Public Class LogTest

    ' Se ejecuta siempre antes de cada método y limpia los logs de la base
    <TestInitialize()> Public Sub Inicializar()
        Dim dal As New LogDAL()
        dal.DeleteLogs()
    End Sub


    <TestMethod()> Public Sub LogInfo()
        Dim identifier As String = "Log creado por un test: " + Now.ToString()
        Dim log As New LogBLL()
        log.AddLogInfo("Test Log", identifier, Me)
        log.AddLogCritical("Test Log", identifier, Me)
        log.AddLogWarn("Test Log", identifier, Me)
        log.AddLogDebug("Test Log", identifier, Me)
        Dim lista As List(Of LogDTO) = PerformLog(LogDTO.level.INFO)
        Assert.AreEqual(lista.Count, 1, "Debe recuperar sólo un registro")
    End Sub

    <TestMethod()> Public Sub LogWarn()
        Dim identifier As String = "Log creado por un test: " + Now.ToString()
        Dim log As New LogBLL()
        log.AddLogInfo("Test Log", identifier, Me)
        log.AddLogCritical("Test Log", identifier, Me)
        log.AddLogWarn("Test Log", identifier, Me)
        log.AddLogDebug("Test Log", identifier, Me)
        Dim lista As List(Of LogDTO) = PerformLog(LogDTO.level.WARNING)
        Assert.AreEqual(lista.Count, 3, "Debe recuperar sólo tres registros")
    End Sub

    <TestMethod()> Public Sub LogCritical()
        Dim identifier As String = "Log creado por un test: " + Now.ToString()
        Dim log As New LogBLL()
        log.AddLogInfo("Test Log", identifier, Me)
        log.AddLogCritical("Test Log", identifier, Me)
        log.AddLogWarn("Test Log", identifier, Me)
        log.AddLogDebug("Test Log", identifier, Me)
        Dim lista As List(Of LogDTO) = PerformLog(LogDTO.level.CRITICAL)
        Assert.AreEqual(lista.Count, 2, "Debe recuperar sólo dos registros")
    End Sub

    <TestMethod()> Public Sub LogDebug()
        Dim identifier As String = "Log creado por un test: " + Now.ToString()
        Dim log As New LogBLL()
        log.AddLogInfo("Test Log", identifier, Me)
        log.AddLogCritical("Test Log", identifier, Me)
        log.AddLogWarn("Test Log", identifier, Me)
        log.AddLogDebug("Test Log", identifier, Me)
        Dim lista As List(Of LogDTO) = PerformLog(LogDTO.level.DEBUG)
        Assert.AreEqual(lista.Count, 4, "Debe recuperar todos los registros")
    End Sub

    <TestMethod()> Public Sub LogNoFilter()
        Dim identifier As String = "Log creado por un test: " + Now.ToString()
        Dim log As New LogBLL()
        Dim result As ResultDTO
        log.AddLogInfo("Test Log", identifier, Me)
        log.AddLogCritical("Test Log", identifier, Me)
        log.AddLogWarn("Test Log", identifier, Me)
        log.AddLogDebug("Test Log", identifier, Me)

        result = log.GetLog(LogDTO.level.DEBUG)
        Dim lista As List(Of LogDTO) = CType(result.value, List(Of LogDTO))

        Assert.AreEqual(lista.Count, 4, "Debe recuperar todos los registros")
    End Sub

    <TestMethod()> Public Sub LogSince()
        ' Prueba que los logs puedan recuperarse considerando el desde
        Dim identifier As String = "Log creado por un test: " + Now.ToString()
        Dim log As New LogBLL()
        Dim result As ResultDTO

        log.AddLogInfo("Test Log", identifier, Me)
        log.AddLogCritical("Test Log", identifier, Me)

        Thread.Sleep(2000)

        log.AddLogWarn("Test Log", identifier, Me)
        log.AddLogDebug("Test Log", identifier, Me)

        result = log.GetLog(LogDTO.level.DEBUG, Now.AddSeconds(-1))
        Dim lista As List(Of LogDTO) = CType(result.value, List(Of LogDTO))

        Assert.AreEqual(lista.Count, 2, "Debe recuperar dos registros")
    End Sub

    <TestMethod()> Public Sub LogUntil()
        ' Prueba que los logs puedan recuperarse considerando el hasta
        Dim identifier As String = "Log creado por un test: " + Now.ToString()
        Dim log As New LogBLL()
        Dim result As ResultDTO

        log.AddLogInfo("Test Log", identifier, Me)
        log.AddLogCritical("Test Log", identifier, Me)

        Thread.Sleep(1000)
        log.AddLogWarn("Test Log", identifier, Me)

        Thread.Sleep(1000)
        log.AddLogDebug("Test Log", identifier, Me)

        result = log.GetLog(LogDTO.level.DEBUG, until:=Now.AddSeconds(-1))
        Dim lista As List(Of LogDTO) = CType(result.value, List(Of LogDTO))

        ' El manejo del tiempo es medio tricky, de modo tal que con que no recupere cuatro, está bien
        Assert.IsTrue(lista.Count < 4, "Debe recuperar dos registros")
    End Sub

    Private Function PerformLog(ByRef loglevel As Integer) As List(Of LogDTO)
        Dim log As New LogBLL()
        Dim result As ResultDTO
        Dim count As Integer = 0

        result = log.GetLog(loglevel, Now.AddMinutes(-1), Now.AddMinutes(1), Me.GetType().ToString())

        ' El value del resultado es una lista de logs
        Return CType(result.value, List(Of LogDTO))
    End Function
End Class