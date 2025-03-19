<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DonorL.aspx.vb" Inherits="DonorLeave.DonorL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href='https://fonts.googleapis.com/css?family=Great+Vibes' rel='stylesheet' type='text/css' />

    <style>
       /* body {
         
            background-repeat: no-repeat;
            background-size: cover;
            background-position: center;
            border:2px;
            border-color:black;
            max-width: 1100px;
            margin: auto;
            padding:4px;
            text-align: center;

        }*/

        .forms > td {
            border:thin
        }
          .user-box {
                position:relative;
            }
            .user-box input {
                width: 100%;
                padding: 10px 0;
                font-size: 20px;
                color: #000;
             /*  color:white;*/
                border: none;
                border-bottom: 1px solid #000;
                outline: none;
                background: transparent;
                margin-left: 20px;
            }
            .user-box label {
                position:initial;
                
                top:0;
                left: 0;
                padding: 10px 0;
                font-size: 20px;
                color: #000;
                pointer-events: none;
                transition: .5s;
                margin-left: 20px;
            }
            .user-box input:focus ~ label,
            .user-box input:valid ~ label {
                
                top: +35px;
                left: 0;
                color: black;
                font-size: 20px;
            }


        #form1 {
            /* background: rgb(167, 208, 22, 0.5);*/
          /*  background: white;*/
            border:thick;
            box-sizing: border-box;
           /* box-shadow: 0 15px 25px rgba(0, 0, 0, .3);
            border-radius: 10px;*/
        }

        .titles {
            font: Arial;
            font-size: large;
            /*color: #91c2c5;*/
            color: black;
            font-weight:bold;
        }
        .lbl2 {
            font: Arial;
            font-size: 18px;
            color: blue;
            font-weight: bold;
        }
      .lbl3
        {
             font: Arial;
            font-size: 20px;
            color: black;
           
        }
                   
       

        .lbl4 {
            font:  Arial;
            font-size: 10px;
            color: black;
           
        }

        .lbl5{
            image-orientation:unset;

        }
        
        



        .auto-style8 {
            text-align: Center;
        }

          .shadowbutton {
                background-color: #003366;
                border: none;
                color: #d7d6d6;
                padding: 10px 15px;
                text-align: center;
                text-decoration: none;
                display: inline-block;
                margin: 4px 2px;
                cursor: pointer;
                -webkit-transition-duration: 0.4s; /* Safari */
                transition-duration: 0.4s;
                border-radius: 10px;
                box-shadow: 10px 5px 5px grey;

            }

            .shadowbutton:hover {
                box-shadow: 12px 7px 8px grey;
            }
                        
        .shadowbutton1 {
                background-color: white;
                border: none;
                color:  black;
                padding: 10px 15px;
                text-align: center;
                text-decoration: none;
                display: inline-block;
                margin: 4px 2px;
                cursor: pointer;
                -webkit-transition-duration: 0.4s;  
                transition-duration: 0.4s;
                border-radius: 10px;
                box-shadow: 10px 5px 5px gold;

            }

            .shadowbutton1:hover {
                box-shadow: 12px 7px 8px gold;
            }

            .bottom{

                margin-top:5rem;


            }
         .forms {
            background-color: #FDBE11;
        }

        .lab1 {
            color: white;
        }

        .lbl1 {
            background-color: beige;
        }

        .lbl2 {
            color: black
        }

        .auto-style1 {
            background-color: #FDBE11;
            margin-bottom: 0px;
        }
        .pt{
          cursor:pointer;
          color: white;
        }
        .auto-style1 {
            padding-top:0px;
            margin-bottom: 1px;
            background: yellow blue;
            border:thick;
            box-sizing: border-box;
            box-shadow: 0 15px 25px rgba(0, 0, 0, .3);
            border-radius: 10px;
        }
        .lblS{
        font: 400 130px/0.8 'Great Vibes', Helvetica, sans-serif;
        font-size:x-large ;
        font-weight:600;
        color:black;
        }

        </style>
     <script src="https://momentjs.com/downloads/moment.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"></script>
    <script type="text/javascript">
        windows.history.forward();
        function SetName(SignName, type) {
            if (type == 'RP') {
                document.getElementById('lblSignatureofDonorEmployee').innerHTML = SignName;
                document.getElementById('hRequestSignature').value = SignName;
                document.getElementById('txtRequestSignature').style.display = "none";
            }
            if (type == 'SUP') {
                document.getElementById('lblSupervisorSignature').innerHTML = SignName;
                document.getElementById('hSupervisorSignature').value = SignName;
                document.getElementById('txtSupervisorSignature').style.display = "none";
            }

            if (type == 'AS') {
                document.getElementById('lblApproverSignature').innerHTML = SignName;
                document.getElementById('hApproverSignature').value = SignName;
                document.getElementById('txtApproverSignature').style.display = "none";
            }
            if (type == 'PAS') {
                document.getElementById('lblPurchaseSignature').innerHTML = SignName;
                document.getElementById('hPurchaseSignature').value = SignName;
                document.getElementById('txtPurchaseSignature').style.display = "none";
            }
        }

    </script>

    <script>

         $(function () {
             $("#txtRequestDate").datepicker();
         });
         $(function () {
             $("#txtDate2").datepicker();
         });
         $(function () {
             $("#txtDate3").datepicker();
         });
         $(function () {
             $("#txtDate4").datepicker();
         });

    </script>

</head>



<body  runat="server">
    
    <div class="auto-style8">
&nbsp;<label class="titles" runat="server"  ><br/><br/><strong>MISSISWSIPPI STATE DEPARTMENTT OF HEALTH <br/>
                               DONATION OF LEAVE FOR CATASTROPHIC ILLNESS OR INJURY
                                             </strong></label>
    <br />
    <br />
    <br /><br />
    </div>
    <form id="form1" runat="server"   >
      <asp:Table runat ="server" Width ="940px" Align="Center"  BorderWidth ="1" CssClass="auto-style1" >
       
                <%-- First row--%>
          <asp:TableRow >
            
          
             <asp:TableCell ColumnSpan ="5">
                 <br /><br /><br />
                 <asp:Table runat="server" CellPadding="0" CellSpacing="0" >
                   <asp:TableRow CellPadding="0" CellSpacing="0">
                       <asp:TableCell CssClass="lbl3">
                           <asp:Label ID="lblI" runat="server"   align="left" CssClass="lbl3">&nbsp;&nbsp;&nbsp;&nbsp;I,&nbsp</asp:Label>
                       </asp:TableCell>
                       <asp:TableCell CssClass="lbl3">
                           <asp:TextBox ID="txtName" runat="server"   Width="350px"  ></asp:TextBox>

                       </asp:TableCell>
                       <asp:TableCell CssClass="lbl3">
                           <asp:Label ID="lblword" runat="server" Text=", hereby request that " BorderStyle="None"  ></asp:Label>
                       </asp:TableCell>
                       <asp:TableCell CssClass="lbl3">&nbsp <asp:TextBox ID="txthours" runat="server"   Width="200px"   ></asp:TextBox> </asp:TableCell>
                       <asp:TableCell CssClass="lbl3" >&nbsp<asp:Label ID="lblword2" runat="server" Text=" Hours of " BorderStyle="None" ></asp:Label><br/> </asp:TableCell>

                   </asp:TableRow>
                
                 </asp:Table>
                
             </asp:TableCell>

          </asp:TableRow >

      <%--    second rows--%>

          <asp:TableRow  CellPadding="0" CellSpacing="0" >

     <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblword3" runat="server" Text=" (Name of Donor Employee) " BorderStyle="None" ></asp:Label></asp:TableCell>
       </asp:TableRow>
       



          <asp:TableRow  CellPadding="0" CellSpacing="0"  >
           <asp:TableCell ColumnSpan ="3">
               <asp:Table runat="server">
                   <asp:TableRow>
                       <asp:TableCell CssClass="lbl3">&nbsp;&nbsp;&nbsp; <asp:Label ID="lblword4" runat="server" Text="personal leave and /or " BorderStyle="None" Align="left" ></asp:Label></asp:TableCell>
                       <asp:TableCell CssClass="lbl3"> <asp:TextBox ID="txtdigits" runat="server" Width="200px" ></asp:TextBox>   </asp:TableCell>
                       <asp:TableCell CssClass="lbl3"> <asp:Label ID="lblword5" runat="server" Text=" hours of major medical leave presently credited to my " BorderStyle="None"  ></asp:Label></asp:TableCell> 
                   </asp:TableRow>
              </asp:Table>
          </asp:TableCell>
              
        </asp:TableRow>
         <asp:TableRow><asp:TableCell><br /></asp:TableCell></asp:TableRow>
         <asp:TableRow>
             <asp:TableCell ColumnSpan ="2">
                 <asp:Table runat ="server">
                     <asp:TableRow CellPadding="0" CellSpacing="0">
                         <asp:TableCell CssClass="lbl3">&nbsp;&nbsp;&nbsp;<asp:Label ID="lblword6" runat="server" Text=" account be donated upon receipt of this signed form to "></asp:Label> </asp:TableCell>
                         <asp:TableCell CssClass="lbl3"><asp:TextBox ID="txtNameofRecipient" runat="server" Width="400px" ></asp:TextBox> </asp:TableCell>
                    </asp:TableRow>
                 </asp:Table>
              </asp:TableCell>
          </asp:TableRow>
        <asp:TableRow CellPadding="0" CellSpacing="0" >
            <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblword7" runat="server" Text=" (Name of Recipient Employee) " BorderStyle="None" align="left" ></asp:Label></asp:TableCell>

        </asp:TableRow>
          <asp:TableRow> <asp:TableCell><br /></asp:TableCell></asp:TableRow>

        <asp:TableRow>

       <asp:TableCell CssClass="lbl3" HorizontalAlign="Left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblword8" runat="server" Text=" I donate these hours to be used for the catastrophic injury or either the recipient " ></asp:Label> </asp:TableCell>
       
      </asp:TableRow>
      <asp:TableRow>
          <asp:TableCell><br /></asp:TableCell>
      </asp:TableRow>

       <asp:TableRow>
       <asp:TableCell CssClass="lbl3" HorizontalAlign="Left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblword9" runat="server" Text=" employee or his or her immediate family. I understand if the total amount of leave I have donated is " ></asp:Label> </asp:TableCell>
       
      </asp:TableRow>
      <asp:TableRow>
          <asp:TableCell><br /></asp:TableCell>
     </asp:TableRow>
      <asp:TableRow>
       <asp:TableCell CssClass="lbl3" HorizontalAlign="Left">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblword10" runat="server" Text=" not used by the recipient employee, the donated leave will be returned to me on a pro-rate basis.  " ></asp:Label> </asp:TableCell>
      </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><br /><br /></asp:TableCell>
        </asp:TableRow>

          <asp:TableRow>
              <asp:TableCell ColumnSpan ="3">
                  <asp:Table runat ="server">
                      <asp:TableRow CellPadding="0" CellSpacing="0">
                          <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    `
                                    <asp:HiddenField ID="hRequestSignature" runat="server" />
                                    <a id="txtRequestSignature" style="width: 120px;" runat="server" title="" class="pt" align="center"  onclick="popupWindow=window.open('Signature.aspx?type=RP', '_blank', 'toolbar=no,top=400,left=520,location=no,height=200,width=300,scrollbars=no,status=no');" >sign here</a>
                                    <asp:Label ID="lblSignatureofDonorEmployee" runat="server"   CssClass="lblS"></asp:Label>
                                 
                          </asp:TableCell>

                           <asp:TableCell CssClass="lbl3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       
                                    <asp:Textbox ID="txt4ssn" runat="server"  width="120"></asp:Textbox>

                          </asp:TableCell>

                           <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Textbox runat="server" ID="txtRequestDate"   width="150px"></asp:Textbox>
                           </asp:TableCell>

                     </asp:TableRow>
                 

                  </asp:Table>

              </asp:TableCell>

          </asp:TableRow>
          <asp:TableRow  >
              <asp:TableCell  ColumnSpan ="3">
                  <asp:Table runat="server">
                      <asp:TableRow CellPadding="0" CellSpacing="0">
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblEmployeeSig" runat="server" Text="(Signature of Donor Employee)"></asp:Label></asp:TableCell>
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="(Last 4 digits of SSN)"></asp:Label></asp:TableCell>
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="(Date Signed)"></asp:Label></asp:TableCell>
                      
                      </asp:TableRow>



                  </asp:Table>



              </asp:TableCell>

          </asp:TableRow>

       <%--   Signature of Immediate Supervisor--%>

          <asp:TableRow>
                  <asp:TableCell ColumnSpan ="3">
                  <asp:Table runat ="server">
                      <asp:TableRow CellPadding="0" CellSpacing="0">
                          <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    `
                                    <asp:HiddenField ID="hSupervisorSignature" runat="server" />
                                    <a id="txtSupervisorSignature" style="width: 120px;" runat="server" title="" class="pt" align="center"  onclick="popupWindow=window.open('Signature.aspx?type=SUP', '_blank', 'toolbar=no,top=400,left=520,location=no,height=200,width=300,scrollbars=no,status=no');" >sign here</a>
                                    <asp:Label ID="lblSupervisorSignature" runat="server"   CssClass="lblS"></asp:Label>
                                 
                          </asp:TableCell>

                           <asp:TableCell CssClass="lbl3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       
                                    <asp:Label ID="lblspace" runat="server"  width="120"></asp:Label>

                          </asp:TableCell>

                           <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:TextBox runat="server" ID="txtDate2"   width="150px"></asp:TextBox>
                           </asp:TableCell>

                     </asp:TableRow>
                 

                  </asp:Table>

              </asp:TableCell>


          </asp:TableRow>
          <asp:TableRow>
               <asp:TableCell  ColumnSpan ="3">
                  <asp:Table runat="server">
                      <asp:TableRow CellPadding="0" CellSpacing="0">
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="(Signature of Immediate Supervisor)"></asp:Label></asp:TableCell>
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" width="120px"></asp:Label>&nbsp;&nbsp;<br /><br /></asp:TableCell>
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="(Date Signed)"></asp:Label></asp:TableCell>
                                    
                      </asp:TableRow>

                  </asp:Table>

              </asp:TableCell>


          </asp:TableRow>

          <asp:TableRow>
                <asp:TableCell ColumnSpan ="3">
                <asp:Table runat ="server">
                    <asp:TableRow CellPadding="0" CellSpacing="0">
                        <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  `
                                  <asp:HiddenField ID="hHumanSignature" runat="server" />
                                  <a id="A1" style="width: 120px;" runat="server" title="" class="pt" align="center"  onclick="popupWindow=window.open('Signature.aspx?type=SUP', '_blank', 'toolbar=no,top=400,left=520,location=no,height=200,width=300,scrollbars=no,status=no');" >sign here</a>
                                  <asp:Label ID="Label7" runat="server"   CssClass="lblS"></asp:Label>
                       
                        </asp:TableCell>

                         <asp:TableCell CssClass="lbl3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             
                                  <asp:Label ID="Label10" runat="server"  width="120"></asp:Label>

                        </asp:TableCell>

                         <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:TextBox runat="server" ID="txtDate3"   width="150px"></asp:TextBox>
                         </asp:TableCell>

                   </asp:TableRow>
       

                </asp:Table>

            </asp:TableCell>


        </asp:TableRow>
          <asp:TableRow>
               <asp:TableCell  ColumnSpan ="3">
                  <asp:Table runat="server">
                      <asp:TableRow CellPadding="0" CellSpacing="0">
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="(Approval by Office of Human Resources)"></asp:Label></asp:TableCell>
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" width="120px"></asp:Label>&nbsp;&nbsp;<br /><br /></asp:TableCell>
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="(Date Signed)"></asp:Label></asp:TableCell>                                    
                      </asp:TableRow>
                  </asp:Table>
              </asp:TableCell>
          </asp:TableRow>

          <asp:TableRow>
                <asp:TableCell ColumnSpan ="3">
                <asp:Table runat ="server">
                    <asp:TableRow CellPadding="0" CellSpacing="0">
                        <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  `
                                  <asp:HiddenField ID="hStaffSignature" runat="server" />
                                  <a id="A2" style="width: 120px;" runat="server" title="" class="pt" align="center"  onclick="popupWindow=window.open('Signature.aspx?type=SUP', '_blank', 'toolbar=no,top=400,left=520,location=no,height=200,width=300,scrollbars=no,status=no');" >sign here</a>
                                  <asp:Label ID="Label11" runat="server"   CssClass="lblS"></asp:Label>
                       
                        </asp:TableCell>

                         <asp:TableCell CssClass="lbl3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             
                                  <asp:Label ID="Label12" runat="server"  width="120"></asp:Label>

                        </asp:TableCell>

                         <asp:TableCell>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:TextBox runat="server" ID="txtDate4"   width="150px"></asp:TextBox>
                         </asp:TableCell>

                   </asp:TableRow>
       

                </asp:Table>

            </asp:TableCell>


        </asp:TableRow>
          <asp:TableRow>
               <asp:TableCell  ColumnSpan ="3">
                  <asp:Table runat="server">
                      <asp:TableRow CellPadding="0" CellSpacing="0">
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="(Signature of Human Resources Leave Staff)"></asp:Label></asp:TableCell>
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label14" runat="server" width="120px"></asp:Label>&nbsp;&nbsp;<br /><br /></asp:TableCell>
                          <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label15" runat="server" Text="(Date Signed)"></asp:Label></asp:TableCell>                                    
                      </asp:TableRow>
                  </asp:Table>
              </asp:TableCell>
          </asp:TableRow>
          <asp:TableRow>
                <asp:TableCell  ColumnSpan ="3" style="display:flex; justify-content:center;">
                    
                   <asp:Table runat="server" ID="tblLeaveEntries" BorderWidth="1" CellPadding="5" GridLines="Both" BorderColor="Black">
                        <asp:TableRow>
                            <asp:TableHeaderCell RowSpan="2"></asp:TableHeaderCell>
                            <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Black">Employee</asp:TableHeaderCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black">Donor Employee</asp:TableHeaderCell>
                            <asp:TableHeaderCell BorderStyle="Solid" BorderColor="Black">Recipient Employee</asp:TableHeaderCell>
                        </asp:TableRow>
    
                        <asp:TableRow>
                            <asp:TableCell BorderStyle="Solid" BorderColor="Black">Date Donated Hours Entered in State’s Leave System</asp:TableCell>
                            <asp:TableCell BorderStyle="Solid" BorderColor="Black">
                                <asp:TextBox ID="txtDonorDateState" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell BorderStyle="Solid" BorderColor="Black">
                                <asp:TextBox ID="txtRecipientDateState" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
    
                        <asp:TableRow>
                            <asp:TableCell BorderStyle="Solid" BorderColor="Black">Date Donated Hours Entered in MSDH Electronic Leave System</asp:TableCell>
                            <asp:TableCell BorderStyle="Solid" BorderColor="Black">
                                <asp:TextBox ID="txtDonorDateMSDH" runat="server"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell BorderStyle="Solid" BorderColor="Black">
                                <asp:TextBox ID="txtRecipientDateMSDH" runat="server"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
          </asp:TableRow>
          <asp:TableRow>
             <asp:TableCell  ColumnSpan ="3">
                <asp:Table runat="server">
                    <asp:TableRow CellPadding="0" CellSpacing="0">
                        <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label16" runat="server" Text="Mississippi State Department of Health"></asp:Label></asp:TableCell>
                        <asp:TableCell CssClass="lbl4"><asp:Label ID="Label17" runat="server" width="120px"></asp:Label>&nbsp;&nbsp;<br /><br /></asp:TableCell>
                        <asp:TableCell CssClass="lbl4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label18" runat="server" Text="Form 4e Revision 10/01/2024"></asp:Label></asp:TableCell>                                    
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
      </asp:Table>


    </form>
</body>
</html>
