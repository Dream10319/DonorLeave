Public Class Signature
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("type") = "IS" Then
            lblSignName.Text = "Inspector Signature"
            body.Attributes.Add("style", "background-color:#fdbe11")
        ElseIf Request.QueryString("type") = "AS" Then
            lblSignName.Text = "Approver Signature"
            body.Attributes.Add("style", "background-color:#fdbe11")

        ElseIf Request.QueryString("type") = "RP" Then
            lblSignName.Text = "Request's Signature"

            body.Attributes.Add("style", "background-color:#3f88d2")
        ElseIf Request.QueryString("type") = "PAS" Then
            lblSignName.Text = "Purchase Signature"

            body.Attributes.Add("style", "background-color:#3f88d2")
        End If
        If IsPostBack Then
            lblMessage.Text = ""
            If txtUserName.Text = "" And txtPassword.Text = "" Then
                lblMessage.Text = "Please enter User Name and Password"
                txtUserName.Focus()
            ElseIf txtUserName.Text <> "" And txtPassword.Text = "" Then
                lblMessage.Text = "Please enter a Password"
                txtPassword.Focus()
            ElseIf txtUserName.Text = "" And txtPassword.Text <> "" Then
                lblMessage.Text = "Please enter a User Name"
                txtUserName.Focus()
            Else
                Validate()
            End If
            hType.Value = Request.QueryString("type")
            hSignName.Value = Replace(txtUserName.Text, ".", " ")
        Else
            txtUserName.Focus()
        End If
    End Sub

    Overrides Sub Validate()
        Dim obj As Array
        Dim obj1 = New DonorLeave.ADAuthentication
        obj = obj1.AD(txtUserName.Text, txtPassword.Text)
        If obj(0) = "False" Then
            lblMessage.Text = obj(1)
        End If
    End Sub

    Protected Sub btn_Sign_Click(sender As Object, e As EventArgs)
        If lblMessage.Text = "" Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "Signature('" & hSignName.Value & "','" & hType.Value & "');", True)
            Dim closeScript As String = "<script language='javascript'> window.close() </script>"
            ClientScript.RegisterStartupScript(Me.GetType, "closeScript", closeScript)
        End If
    End Sub


End Class