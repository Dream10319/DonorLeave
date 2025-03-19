Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.DirectoryServices
Imports Microsoft.VisualBasic
Imports System.Object
Imports System.IO

Imports DonorLeave.ADAuthentication

Public Class Login
    Inherits System.Web.UI.Page
    Dim SQLConn As String = ""
    Dim SQLConn1 As String = ""
    Dim SQLConn2 As String = ""
    Public encrypt As String
    Public decrypt As String
    Public encryptLPW = ConfigurationManager.AppSettings("encryptPW")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim hostname = HttpContext.Current.Request.Url.Host
        If hostname = "localhost" Or Left(hostname, 7) = "sandbox" Then
            '**** ENCRYPT CONNECTION STRING ********
            'encrypt = ConfigurationManager.AppSettings("conString1")
            'Decoding()
            'SQLConn = decrypt
            'encrypt = ConfigurationManager.AppSettings("conStringTS")
            'Decoding()
            'SQLConn1 = decrypt
            '***************************************
            SQLConn = ConfigurationManager.ConnectionStrings("conString").ToString
            ' SQLConn1 = ConfigurationManager.ConnectionStrings("conStringTS").ToString
        Else
            ' SQLConn = ConfigurationManager.ConnectionStrings("conString").ToString
            SQLConn = "Server=ad01\prod;Database=MSDH_Forms;User ID=MiForms_User;Password=ru!6WecHuve+;"
            '**** ENCRYPT CONNECTION STRING ********
            'encrypt = ConfigurationManager.AppSettings("conString")
            'Decoding()
            'SQLConn = decrypt
            '***************************************
        End If

        If (LCase(txtUserName.Text) = "tonye.lasseter" Or LCase(txtUserName.Text) = "ling.lu" Or LCase(txtUserName.Text) = "nick.creel") And Session("Var") = "0" Then
            trUserLogin.Visible = True
            txtPW.Focus()
            Session("Var") = "1"
            Exit Sub
        End If

        If IsPostBack Then
            lblMessage.Text = ""
            If txtUserName.Text = "" And txtPW.Text = "" Then
                lblMessage.Text = "Please enter User Name and Password"
                txtUserName.Focus()
            ElseIf txtUserName.Text <> "" And txtPW.Text = "" Then
                lblMessage.Text = "Please enter a Password"
                txtPW.Focus()
            ElseIf txtUserName.Text = "" And txtPW.Text <> "" Then
                lblMessage.Text = "Please enter a User Name"
                txtUserName.Focus()
            Else
                Validate()
                If lblMessage.Text = "" Then
                    'BuildForTimeStudy()
                    If Request.QueryString("page") <> "" Then
                        Dim link As String = Replace(Request.QueryString("page"), "||", "&")
                        Response.Redirect(link)
                    Else
                        If Request.QueryString("q") = "1" Then
                            Response.Redirect("Questionnaire.aspx")
                        Else
                            If Request.QueryString("s") = "1" Then
                                Response.Redirect("Default.aspx?s=1")
                            Else
                                'Dim ds As DataSet
                                'Dim dt = New IRAR.DataBaseProc
                                'ds = dt.GetLogin(HttpContext.Current.Session("PIN"), HttpContext.Current.Session("PIDID"), SQLConn)
                                'If ds.Tables(0).Rows.Count = 0 Then
                                '    Dim ds1 As DataSet
                                '    Dim dt1 = New IRAR.DataBaseProc
                                '    ds1 = dt1.InsertLogin(HttpContext.Current.Session("PIN"), HttpContext.Current.Session("PIDID"), Now(), SQLConn)
                                'End If
                                Session("UserName") = txtUserName.Text
                                Response.Redirect("DonorL.aspx")
                            End If
                        End If
                    End If
                End If
            End If
        Else
            Session("AdminPerson") = ""
            txtUserName.Focus()
            Session("Var") = "0"
            Session("EmailAddress") = ""
            Session("UserName") = txtUserName.Text
            Session("App") = ""
            Session("PropertyPerson") = ""
            Session("locCode") = ""
        End If

    End Sub

    Sub Decoding()
        Dim cipherText As String = encrypt
        Dim password As String = encryptLPW.ToString
        Dim wrapper As New EncryptDecrypt(password)
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            decrypt = plainText
        Catch ex As System.Security.Cryptography.CryptographicException
            'lblMessage.Text = "The data could not be decrypted with the password."
        End Try
    End Sub

    'Sub BuildForTimeStudy()
    '    Dim pr As New SQLProcessing
    '    Dim dt As Data.DataTable
    '    Dim sql As String
    '    If txtUserLogin.Text <> "" Then
    '        sql = " Select * FROM [MSDH_Forms].[dbo].[AD_INFO] where [Login_name] = '" + Replace(txtUserLogin.Text, "'", "''") + "'"
    '    Else
    '        sql = " Select * FROM [MSDH_Forms].[dbo].[AD_INFO] where [Login_name] = '" + Replace(txtUserName.Text, "'", "''") + "'"
    '    End If
    '    'sql = " Select * FROM [MSDH_Forms].[dbo].[AD_INFO1] where [Login_name] = '" + txtUserName.Text + "'"

    '    'dt = pr.GetData(sql, ConfigurationManager.ConnectionStrings("conStringTS").ConnectionString)
    '    dt = pr.GetData(sql, SQLConn)

    '    If dt.Rows.Count > 0 Then
    '        HttpContext.Current.Session("PIDID") = dt(0)("pid_nmbr")
    '        Dim pid As String = dt(0)("pid_nmbr")
    '        HttpContext.Current.Session("PID_ID") = pid.TrimStart(New Char() {"0"c})
    '        HttpContext.Current.Session("EmpNumber") = dt(0)("person_nmbr")
    '        HttpContext.Current.Session("FullName") = dt(0)("person_last_name") + ", " + dt(0)("person_first_name")
    '        HttpContext.Current.Session("OrgNum") = dt(0)("org_code")
    '        HttpContext.Current.Session("Location") = dt(0)("location")
    '        HttpContext.Current.Session("PIN") = dt(0)("pin_win_nmbr")
    '        HttpContext.Current.Session("JobName") = dt(0)("job_name")
    '        HttpContext.Current.Session("SupvEmail") = dt(0)("email")
    '        SetSecurityCookies(txtUserName.Text, txtPW.Text, True)
    '    End If

    'End Sub

    Public Shared Sub SetSecurityCookies(login As String, password As String, createPersistentCookie As Boolean)
        Dim timeout As DateTime = DateTime.Now
        If System.Configuration.ConfigurationManager.AppSettings("LoginCookieExpiration") Is Nothing Then
            timeout = timeout.AddMinutes(HttpContext.Current.Session.Timeout)
        Else
            timeout = timeout.AddDays(Int32.Parse(System.Configuration.ConfigurationManager.AppSettings("LoginCookieExpiration")))
        End If
        Dim ticket As New System.Web.Security.FormsAuthenticationTicket(1, login, DateTime.Now, timeout, createPersistentCookie, password, System.Web.Security.FormsAuthentication.FormsCookiePath)
        Dim encTicket As String = System.Web.Security.FormsAuthentication.Encrypt(ticket)
        Dim c As New HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encTicket)

        c.HttpOnly = True

        c.Path = ticket.CookiePath
        If ticket.IsPersistent Then
            c.Name = "CookieCheck"
            c.Expires = ticket.Expiration
        End If
        HttpContext.Current.Response.Cookies.Add(c)

    End Sub

    Overrides Sub Validate()
        'Dim objX As Array
        'Dim objX1 = New IRAR.ADAuthentication
        'objX = objX1.ADTest(txtUserName.Text, txtPW.Text)


        Dim obj As Array
        Dim obj1 = New DonorLeave.ADAuthentication
        obj = obj1.AD(txtUserName.Text, txtPW.Text)
        If obj(0) = "False" Then
            lblMessage.Text = obj(1)
        Else
            ' If Request.QueryString("resp") = "A" And Request.QueryString("email") = "yes" Then
            Dim objA As String
            Dim objA1 = New DonorLeave.ADAuthentication
            If txtUserLogin.Text <> "" Then
                objA = objA1.AD1(txtUserName.Text, txtPW.Text, txtUserLogin.Text)
            Else
                objA = objA1.AD1(txtUserName.Text, txtPW.Text, "")
            End If

            If objA = "IRMDBA" Or objA = "Server Administration" Or objA = "networksvc" Then
                Session("AdminPerson") = "yes"
            Else
                Session("AdminPerson") = "no"
            End If
            ' End If

            'Dim SQLconn As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            'Dim SQLconn1 As String = ConfigurationManager.ConnectionStrings("conString1").ConnectionString
            Dim getUserInfo As New SQLProcessing
            Dim sql As String
            Dim dt As Data.DataTable
            Dim hostname = HttpContext.Current.Request.Url.Host
            If hostname = "localhost" Then
                sql = "select Value1 from [MSDH_Forms].[dbo].[MSDHFormsConfig] where setting = 'URL' and value2 = 'localhost' "
                dt = getUserInfo.GetData(sql, SQLConn)
                Session("Host") = dt(0)("value1") & HttpContext.Current.Request.Url.Port & "/"
            ElseIf Left(hostname, 7) = "sandbox" Then
                sql = "select Value1 from [MSDH_Forms].[dbo].[MSDHFormsConfig] where setting = 'URL' and value2 = 'sandbox' "
                dt = getUserInfo.GetData(sql, SQLConn)
                Session("Host") = dt(0)("value1")
            Else
                sql = "select Value1 from MSDHFormsConfig where setting = 'URL' and value2 = 'prod' "
                dt = getUserInfo.GetData(sql, SQLConn)
                Session("Host") = dt(0)("value1")
            End If

            If txtUserLogin.Text <> "" Then
                Session("EmailAddress") = Replace(txtUserLogin.Text, "'", "''") & "@msdh.ms.gov" 'obj(0)
                Session("UserName") = Replace(txtUserLogin.Text, "'", "''")
                txtUserName.Text = Replace(txtUserLogin.Text, "'", "''")
            Else
                Session("EmailAddress") = Replace(obj(0), "'", "''")
                Session("UserName") = Replace(obj(1), "'", "''")
            End If

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("UserName") = txtUserName.Text
    End Sub
End Class