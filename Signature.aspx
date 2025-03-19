<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Signature.aspx.vb" Inherits="DonorLeave.Signature" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
     .lbl1{
    font-size:large;
    font-weight:800;
}

.lbl2{
    font-size:medium ;
    font-weight:800;
    text-align:center;
    
}
.lbl3{
    font-size:small;
    font-weight:800;

}
.lbl4{
    font-size:small;
    font-weight:700;
    color:red;
}
.grad1 {
  background: linear-gradient(to right, white,#fff8db); /* Standard syntax (must be last) */
  width: 55px;
  height: 25px;
  font-weight:700;
  color:black;
  box-shadow:
    1px 1px 0 0 gray,
    2px 2px 0 0 gray,
    3px 3px 0 0 gray,
    4px 4px 0 0 gray,
    5px 5px 5px 0 #000000;
     }
 .grad1:hover {
  width: 60px;
  height: 30px;
  font-weight:900;
  color:black;
  box-shadow:
    1px 1px 0 0 gray,
    2px 2px 0 0 gray,
    3px 3px 0 0 gray,
    4px 4px 0 0 gray,
    5px 5px 5px 0 #000000;
        }
 </style>
<script>
    function Signature(SignName, type) {
        opener.SetName(SignName, type);
    }
</script>
</head>
<body id="body" runat="server"  style="background-color:burlywood">
    <input type="hidden" id="hSignName" name="hSignName" runat="server" /><input type="hidden" id="hType" name="hType" runat="server" />
    <form id="form2" runat="server" >
        <div>
            <asp:Table runat ="server" >
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" >
                        <asp:Table runat="server">
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="Center" >
                                    <asp:Label ID="lblSignName" runat="server" Text="" CssClass="lbl2"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblUserName" runat="server" Text="Username" CssClass="lbl3"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>&nbsp;
                        <asp:TextBox ID="txtUserName" runat="server" Visible="true" Height="15px" Width="180px" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="lbl3"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>&nbsp;
                        <asp:TextBox ID="txtPassword" runat="server" Visible="true" Height="15px" Width="180px" TextMode="Password"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Label ID="lblMessage" runat="server"  CssClass="lbl4"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="100" HorizontalAlign="Right" ColumnSpan="2">
                        <asp:Button ID="btn_Sign" runat="server" Text="Sign" Visible="true" OnClick="btn_Sign_Click"  CssClass="grad1" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
