Imports Microsoft.VisualBasic
Imports System.DirectoryServices
Imports System.Object
Imports System.IO
Imports System.Net
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Class ADAuthentication
    Public DomainName = ConfigurationManager.AppSettings("DomainName")
    Public Function AD(UN As String, PW As String)
        Dim array(1) As String

        Dim Entry As New System.DirectoryServices.DirectoryEntry(DomainName, UN, PW)

        Dim searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        searcher.Filter = "(&(objectCategory=user)(SAMAccountName=" + UN + ")"
        searcher.SearchScope = DirectoryServices.SearchScope.Subtree
        searcher.Filter = "(&(objectcategory=user)(SAMAccountName=" & UN & "))"
        searcher.PropertiesToLoad.Add("mail")
        searcher.PropertiesToLoad.Add("SAMAccountName")
        Dim res As SearchResult
        'Dim x As String = ""
        Try
            res = searcher.FindOne
            array(0) = res.Properties("mail").Item(0).ToString
            array(1) = res.Properties("SAMAccountName").Item(0).ToString
        Catch ex As Exception
            array(0) = ("False")
            array(1) = ("You did not enter a correct user name or password.  Try again.")
        Finally
            Entry.Dispose()
            searcher.Dispose()
        End Try
        Return array
    End Function

    Public Function GetMail(UN As String)
        Dim array(1) As String
        Dim Entry As New System.DirectoryServices.DirectoryEntry(DomainName, UN, "")

        Dim searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        searcher.Filter = "(&(objectCategory=user)(SAMAccountName=" + UN + ")"
        searcher.SearchScope = DirectoryServices.SearchScope.Subtree
        searcher.Filter = "(&(objectcategory=user)(SAMAccountName=" & UN & "))"
        searcher.PropertiesToLoad.Add("mail")
        searcher.PropertiesToLoad.Add("SAMAccountName")
        Dim res As SearchResult
        Dim x As String = ""
        Try
            res = searcher.FindOne
            array(0) = res.Properties("mail").Item(0).ToString
            array(1) = res.Properties("SAMAccountName").Item(0).ToString
        Catch ex As Exception
            array(0) = ("False")
            array(1) = ("Invalid Org. Code. Try Again")
        Finally
            Entry.Dispose()
            searcher.Dispose()
        End Try
        Return array
    End Function


    Public Function AD1(UN As String, PW As String, UserLogin As String)
        Dim array() As String
        Dim z As Integer
        Dim userFound As Boolean

        ReDim array(z)
        Dim i As Integer
        Dim Entry As New System.DirectoryServices.DirectoryEntry(DomainName, UN, PW)
        Dim Searcher As New System.DirectoryServices.DirectorySearcher(Entry)
        Searcher.SearchScope = DirectoryServices.SearchScope.Subtree
        If UserLogin <> "" Then
            UN = UserLogin
        End If
        Searcher.Filter = "(&(objectcategory=user)(SAMAccountName=" & UN & "))"
        Dim res As SearchResult
        Dim MemberOf As String = ""
        Try
            res = Searcher.FindOne
            userFound = True
        Catch
            MsgBox("You did not enter a correct user name or password.  Try again.")
            Return False
            Exit Function
        End Try

        ''#########################################
        '###########Start of check AD group########
        If res IsNot Nothing Then
            For i = 0 To res.Properties("memberOf").Count() - 1
                HttpContext.Current.Response.Write(res.Properties("memberOf")(i).ToString)
            Next

            For i = 0 To res.Properties("memberOf").Count() - 1
                Dim de As DirectoryEntry = New DirectoryEntry("LDAP://" + res.Properties("memberOf")(i).ToString())
                HttpContext.Current.Response.Write(de.Properties("name").Value.ToString())
                If de.Properties("name").Value.ToString() = "IRMDBA" Or de.Properties("name").Value.ToString() = "Server Administration" Or de.Properties("name").Value.ToString() = "networksvc" Then
                    MemberOf = de.Properties("name").Value.ToString()
                End If
                z = z + 1
            Next
        End If

        '############End of check AD group#############
        '##############################################

        Return MemberOf
    End Function
End Class
