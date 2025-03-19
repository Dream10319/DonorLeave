Imports Microsoft.VisualBasic
Imports System.DirectoryServices
Imports System.Object
Imports System.IO
Imports System.Net
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Web.Security

'Imports Microsoft.VisualBasic

Public Class SQLProcessing
    Public DomainName = ConfigurationManager.AppSettings("DomainName")
    Public Function AD(UN As String, PW As String)
        Dim array() As String
        ' Dim sitestart() As String
        '  Dim sql As String
        Dim z As Integer
        ' Dim groups As String
        Dim userFound As Boolean

        ReDim array(z)
        Dim i As Integer
        Dim Entry As New System.DirectoryServices.DirectoryEntry(DomainName, UN, PW)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.SearchScope = DirectoryServices.SearchScope.Subtree
        Searcher.Filter = "(&(objectcategory=user)(SAMAccountName=" & UN & "))"
        Dim res As SearchResult
        Try
            res = Searcher.FindOne
            userFound = True
            'Exit Function 'Comment this out to proceed to check AD group
        Catch
            MsgBox("You did not enter a correct user name or password.  Try again.")
            Return False
            Exit Function
        End Try

        ''#########################################
        '###########Start of check AD group########
        For i = 0 To res.Properties("memberOf").Count() - 1
            HttpContext.Current.Response.Write(res.Properties("memberOf")(i).ToString)
        Next

        For i = 0 To res.Properties("memberOf").Count() - 1
            Dim de As DirectoryEntry = New DirectoryEntry("LDAP://" + res.Properties("memberOf")(i).ToString())
            HttpContext.Current.Response.Write(de.Properties("name").Value.ToString())
            array(i) = de.Properties("name").Value.ToString()

            z = z + 1
            ReDim Preserve array(z)

        Next
        '############End of check AD group#############
        '##############################################

        Return userFound
    End Function


    Public Function GenericSelectCall(sql As String, connString As String)
        Dim CmdName As String = sql
        Dim cnn As New SqlConnection(connString)
        Dim dscmd As New SqlCommand(CmdName, cnn)
        Dim reader As SqlDataReader
        Dim array() As String
        Dim i As Integer
        i = 0
        ReDim array(i)
        cnn.Open()
        reader = dscmd.ExecuteReader
        i = 0
        While reader.Read
            array(i) = reader.Item(0)
            i = i + 1
            ReDim Preserve array(i)
        End While
        cnn.Close()
        Return array
    End Function

    Public Function ConvertSpacetoZero(input) As String
        Dim value As String = ""
        If input <= "" Then
            value = "0"
        Else
            value = input
        End If


        Return value
    End Function


    'Public Function GetData(ByVal cmdStatement As String, SqlConn As String) As DataTable
    '    Dim dt As New DataTable()
    '    Dim con As New SqlConnection(SqlConn)
    '    Dim sda As New SqlDataAdapter()
    '    Dim cmd As New SqlCommand()
    '    Dim ct As New CommandType()

    '    'cmd.CommandType = ct.Text(cmdStatement) 'CommandType.Text

    '    cmd.Connection = con
    '    Try
    '        con.Open()
    '        sda.SelectCommand = cmd
    '        sda.Fill(dt)
    '        Return dt
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        con.Close()
    '        sda.Dispose()
    '        con.Dispose()
    '    End Try
    'End Function
    Public Function GetData(ByVal cmdState As String, sqlconn As String) As DataTable
        Dim dt As New DataTable()
        'Dim con As New SqlConnection(sqlconn)
        Dim sda As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.CommandText = cmdState

        'dt(0)(0).ToString()
        'cmd.CommandType = CommandType.Text

        ''cmd.Connection = con
        ''Try
        ''    con.Open()
        ''    sda.SelectCommand = cmd
        ''    sda.Fill(dt)
        ''    Return dt
        ''Catch ex As Exception
        ''    Throw ex
        ''Finally
        ''    con.Close()
        ''    sda.Dispose()
        ''    con.Dispose()
        ''End Try
        Dim strSql As String = cmdState
        Dim dtb As New DataTable
        Using cnn As New SqlConnection(sqlconn)
            cnn.Open()
            Using dad As New SqlDataAdapter(strSql, cnn)
                dad.Fill(dtb)
            End Using
            cnn.Close()
        End Using
        Return dtb
    End Function

    Public Function CheckData(SQLconn As String, CalWeek As String, FormType As String) As DataSet
        Dim cmd As New SqlCommand
        Dim sql As New StringBuilder
        sql.Append("Select RecordID, Program, Activity, MondayTime, TuesdayTime, WednesdayTime, ThursdayTime, FridayTime, TotalTime, SignedByEmployee, SupervisorName,a.CalenderWeek,Approved")
        sql.Append(" FROM MSDH_Forms.dbo.TimeStudyDetail a ")
        sql.Append(" left join MSDH_Forms.dbo.TimeStudyEmmployeeInfo b on a.PIN = b.PIN and a.pid_nmbr = b.PID_No ")
        sql.Append(" Where a.PIN = '" & HttpContext.Current.Session("PIN") & "'")
        sql.Append(" and  FormType= '" & FormType & "'")
        sql.Append(" and  (APPROVED = 'No' or APPROVED = '' or APPROVED is null) ")
        If CalWeek <> "" Then
            sql.Append(" and a.CalenderWeek = '" & CalWeek & "' ")
        End If
        sql.Append(" order by RecordID ")
        Dim strSql As String = sql.ToString
        Dim ds As New DataSet
        Using cnn As New SqlConnection(SQLconn)
            cnn.Open()
            Using dad As New SqlDataAdapter(strSql, cnn)
                dad.Fill(ds)
            End Using
            cnn.Close()
        End Using
        Return ds
    End Function

    Public Function GetDataPrint(SQLconn As String, CalWeek As String, FormType As String) As DataSet
        Dim cmd As New SqlCommand
        Dim sql As New StringBuilder
        sql.Append("Select Program, Activity, MondayTime, TuesdayTime, WednesdayTime, ThursdayTime, FridayTime, TotalTime,Approved,")
        sql.Append("EmployeeName,b.PIN,Classification,ORG,PID_No")
        sql.Append(" FROM MSDH_Forms.dbo.TimeStudyDetail a ")
        sql.Append(" left join MSDH_Forms.dbo.TimeStudyEmmployeeInfo b on a.PIN = b.PIN and a.pid_nmbr = b.PID_No ")
        sql.Append(" Where a.PIN = '" & HttpContext.Current.Session("PIN") & "'")
        sql.Append(" and  FormType= '" & FormType & "'")
        sql.Append(" and  a.CalenderWeek= '" & CalWeek & "'")
        sql.Append(" and  (APPROVED = 'Yes') ")
        sql.Append(" order by RecordID ")
        Dim strSql As String = sql.ToString
        Dim ds As New DataSet
        Using cnn As New SqlConnection(SQLconn)
            cnn.Open()
            Using dad As New SqlDataAdapter(strSql, cnn)
                dad.Fill(ds)
            End Using
            cnn.Close()
        End Using
        Return ds
    End Function

    Public Function CheckDataMulti(SQLconn As String, FormType As String) As DataTable
        Dim dt As New DataTable()
        Dim sda As New SqlDataAdapter()
        Dim sql As New StringBuilder
        sql.Append("Select distinct a.CalenderWeek")
        sql.Append(" FROM MSDH_Forms.dbo.TimeStudyDetail a ")
        sql.Append(" left join MSDH_Forms.dbo.TimeStudyEmmployeeInfo b on a.PIN = b.PIN and a.pid_nmbr = b.PID_No ")
        sql.Append(" Where a.PIN = '" & HttpContext.Current.Session("PIN") & "'")
        sql.Append(" and  FormType= '" & FormType & "'")
        sql.Append(" and (APPROVED = 'No' or APPROVED = '' or APPROVED is null) Order by a.CalenderWeek")
        Dim cmd As New SqlCommand
        cmd.CommandText = sql.ToString
        Dim strSql As String = sql.ToString
        Dim dtb As New DataTable
        Using cnn As New SqlConnection(SQLconn)
            cnn.Open()
            Using dad As New SqlDataAdapter(strSql, cnn)
                dad.Fill(dtb)
            End Using
            cnn.Close()
        End Using
        Return dtb
    End Function

    Public Function GetForPrint(SQLconn As String, FormType As String) As DataTable
        Dim dt As New DataTable()
        Dim sda As New SqlDataAdapter()
        Dim sql As New StringBuilder
        sql.Append("Select distinct a.CalenderWeek,b.FormType")
        sql.Append(" FROM MSDH_Forms.dbo.TimeStudyDetail a ")
        sql.Append(" left join MSDH_Forms.dbo.TimeStudyEmmployeeInfo b on a.PIN = b.PIN and a.pid_nmbr = b.PID_No ")
        sql.Append(" Where a.PIN = '" & HttpContext.Current.Session("PIN") & "'")
        sql.Append(" and  FormType= '" & FormType & "'")
        sql.Append(" and (APPROVED = 'Yes') Order by a.CalenderWeek")
        Dim cmd As New SqlCommand
        cmd.CommandText = sql.ToString
        Dim strSql As String = sql.ToString
        Dim dtb As New DataTable
        Using cnn As New SqlConnection(SQLconn)
            cnn.Open()
            Using dad As New SqlDataAdapter(strSql, cnn)
                dad.Fill(dtb)
            End Using
            cnn.Close()
        End Using
        Return dtb
    End Function

    'Public Function UpdateTimeStudy(whereClause As String, RecordID As Integer, connstring As String) As DataSet
    '    Dim sql As New StringBuilder
    '    sql.Append("Update TimeStudyDetail SET ")
    '    sql.Append(whereClause)
    '    sql.Append("where RecordID = " & RecordID)
    '    Dim cnn As New SqlConnection(connstring)
    '    Dim CmdName As String = sql.ToString
    '    Dim dscmd As New SqlDataAdapter(CmdName, cnn)
    '    cnn.Open()
    '    Dim cmd As New SqlCommand(CmdName, cnn)
    '    cmd.ExecuteNonQuery()
    '    cnn.Close()
    'End Function

    'Public Function DeleteTimeStudy(RecordID As Integer, connstring As String) As DataSet
    '    Dim sql As New StringBuilder
    '    sql.Append("Delete from TimeStudyDetail ")
    '    sql.Append("where RecordID = " & RecordID)
    '    Dim cnn As New SqlConnection(connstring)
    '    Dim CmdName As String = sql.ToString
    '    Dim dscmd As New SqlDataAdapter(CmdName, cnn)
    '    cnn.Open()
    '    Dim cmd As New SqlCommand(CmdName, cnn)
    '    cmd.ExecuteNonQuery()
    '    cnn.Close()
    'End Function

    Public Class SQLProcessing
        Public Function GenericSelect(sql As String, connstring As String)
            Dim ds As New DataSet
            Dim SqlConnection As New SqlConnection(connstring)
            Dim command As New SqlCommand(sql, SqlConnection)
            Dim da As New SqlDataAdapter(command)
            'Dim command As New SqlCommand(sql, SqlConnection)
            da.Fill(ds, "SS_ENV")
            Return ds

        End Function

        Public Function GetData(ByVal cmdState As String, sqlconn As String) As DataTable
            Dim dt As New DataTable()
            'Dim con As New SqlConnection(sqlconn)
            Dim sda As New SqlDataAdapter()
            Dim cmd As New SqlCommand
            cmd.CommandText = cmdState

            Dim strSql As String = cmdState
            Dim dtb As New DataTable
            Using cnn As New SqlConnection(sqlconn)
                cnn.Open()
                Using dad As New SqlDataAdapter(strSql, cnn)
                    dad.Fill(dtb)
                End Using
                cnn.Close()
            End Using
            Return dtb
        End Function



        'Public Sub MiscInsertUpdate(sql As String, connstring As String)
        '    Dim cnn As New SqlConnection(connstring)
        '    Dim CmdName As String = sql
        '    Dim dscmd As New SqlDataAdapter(CmdName, cnn)
        '    cnn.Open()
        '    Dim cmd As New SqlCommand(CmdName, cnn)
        '    cmd.ExecuteNonQuery()
        '    cnn.Close()

        'End Sub

        Public Sub InsertUpdate(sql As String, connstring As String)
            Dim cnn As New SqlConnection(connstring)
            Dim CmdName As String = sql
            Dim dscmd As New SqlDataAdapter(CmdName, cnn)
            cnn.Open()
            Dim cmd As New SqlCommand(CmdName, cnn)
            cmd.ExecuteNonQuery()
            cnn.Close()
        End Sub


        'Public Function ProcessCheckTime(min As String, hour As String) As String
        '    Dim returnTime As String
        '    ' Dim i As Integer
        '    'ReDim returnTime(i)

        '    If hour > "" Then
        '        returnTime = hour

        '        If min > "" Then
        '            returnTime = returnTime + ":" + min
        '        Else
        '            returnTime = returnTime + ":00"
        '        End If

        '    Else
        '        Exit Function
        '    End If
        '    Return returnTime
        'End Function

        'Public Function Test1(min As String, hour As String)
        '    Dim returnTime As String
        '    ' Dim i As Integer
        '    'ReDim returnTime(i)

        '    If hour > "" Then
        '        returnTime = hour

        '        If min > "" Then
        '            returnTime = returnTime + ":" + min
        '        Else
        '            returnTime = returnTime + ":00"
        '        End If

        '    Else
        '        Exit Function
        '    End If
        '    Return returnTime
        'End Function
    End Class

    'Public Function ProcessedCheckTime(min As String, hour As String) As String
    '    Dim returnTime As String

    '    If hour > "" Then
    '        returnTime = hour
    '        If min > "" Then
    '            returnTime = returnTime + ":" + min
    '        Else
    '            returnTime = returnTime + ":00"
    '        End If
    '    ElseIf min > "" Then
    '        returnTime = "00"
    '        returnTime = returnTime + ":" + min
    '    Else
    '        Exit Function
    '    End If
    '    Return returnTime
    'End Function

    Public Sub InsertUpdate(sql As String, connstring As String)
        Dim cnn As New SqlConnection(connstring)
        Dim CmdName As String = sql
        Dim dscmd As New SqlDataAdapter(CmdName, cnn)
        cnn.Open()
        Dim cmd As New SqlCommand(CmdName, cnn)
        cmd.ExecuteNonQuery()
        cnn.Close()
    End Sub


End Class
