<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="DonorLeave.Login" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" >
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 296px;
        }
        .auto-style4 {
            width: 260px;
        }
        .auto-style6 {
            width: 108px;
        }
        .auto-style7 {
            width: 158px;
        }
        .auto-style8 {
            width: 499px;
        }
        .auto-style9 {
            width: 661px;
            height: 97px;
        }
        .grad1 {
            background: linear-gradient(to right, white,lightgrey); /* Standard syntax (must be last) */
            width: 70px;
            height: 30px;
            font-weight:700;
        }
        .grad1:hover {
             width: 75px;
            height: 35px;
            font-weight:800;
        }
    </style>
    <script type="text/javascript">
   window.history.forward();
    </script>

</head>
    
<body style="height: 362px;background-color:whitesmoke" >
    <form id="form1" runat="server"  > 
    <div>
        <table>
            <tr>
               <td class="auto-style4"></td>
               <td class="auto-style3"></td></tr>
            <tr>
                <td class="auto-style4"></td>
                <img src="Images/demo1_header.gif" style="height:130px; width:1038px" />
            </tr>
            <tr>
                 <td class="auto-style4"></td>
                 <td align="center" style="font-weight:700">Please Enter User Name & Password Below</td>
                 <td></td>
           </tr>
        </table>

        <table style="height: 59px; width: 926px">
            <tr>
              <td class="auto-style7">

              </td>
              <td class="auto-style6"  align="right">
                   <asp:Label ID="Label2" runat="server" Text="User Name:" Visible="true"></asp:Label>  
              </td> 
              <td class="auto-style8">  
                  <asp:TextBox ID="txtUserName" runat="server"  Visible="true" Height="23px" Width="289px"></asp:TextBox>
                  <asp:Label ID="Label3" runat="server" Text="(your login ID, ex: john.doe)" Font-Size="Smaller" ></asp:Label>
              </td>
              <td class="auto-style26">&nbsp;</td> 
              <td class="auto-style21">&nbsp;</td>
            </tr>
            <tr>
                  <td class="auto-style7"></td>
                  <td class="auto-style6" align="right">
                      <asp:Label ID="Label1" runat="server" Text="Password:" Visible="true"></asp:Label>
                  </td>
                  <td class="auto-style8"> 
                       <asp:TextBox ID="txtPW" runat="server" Visible="true" Height="23px" Width="291px" TextMode="Password"></asp:TextBox>
                      <asp:Label ID="Label4" runat="server" Text="(your login password)" Font-Size="Smaller" ></asp:Label>
                  </td>
                  <td class="auto-style26">&nbsp;</td>
            </tr>
            <tr>
                 <td class="auto-style7"></td>
                 <td colspan="3" align="center">
                     <asp:Label ID="lblMessage" runat="server" ForeColor="red" Text=""></asp:Label>
                  </td> <td class="auto-style21">&nbsp;</td> 
            </tr>
            <tr id="trUserLogin" runat ="server" visible="false"  >
                 <td class="auto-style7"></td>
                 <td colspan="3" align="center">
                     <asp:TextBox ID="txtUserLogin" runat="server" Visible="true" Height="23px" Width="289px"></asp:TextBox>
                     <asp:Label ID="Label5" runat="server" Text="" Width="140" Font-Size="Smaller" ></asp:Label>
                  </td> <td class="auto-style21">&nbsp;</td> 
            </tr>
            <tr>
                <td class="auto-style7"></td>
               <td class="auto-style6">
                   &nbsp;</td>
                <td class="auto-style8" align="center">
                   <asp:Button ID="Button1"  runat="server" Text="Submit" class="grad1"/>
                </td><td></td><td></td><td></td><td></td><td></td><td></td>
           </tr>
       </table>
    </div>
 </form>
</body>
</html>