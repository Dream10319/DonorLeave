<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FormInstruction.aspx.vb" Inherits="DonorLeave.FormInstruction" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Form Instructions</title>
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style>
        /* Center the body content */
        html, body {
            height: 100%; /* Ensure the body takes full height of the viewport */
            margin: 0; /* Remove default margin */
            display: flex;
            justify-content: center; /* Center horizontally */
            align-items: center; /* Center vertically */
            background: grey; /* Background color */
        }

        .body {
            padding: 50px;
            text-align: center;
            width: 40%;
            background-color: #FDBE11;
            box-shadow: 0 15px 25px rgba(0, 0, 0, .3);
            border-radius: 10px;
        }

        .text-center {
            text-align: center;
        }

        .content {
            margin-top: 50px;
        }

        .second-text {
            text-align: left;
        }

        .sign-block {
            display: flex;
            justify-content: space-around;
            align-items: end;
            margin-top: 30px;
        }

        .name-sign-area {
            width: 200px;
            height: 40px;
            border-bottom: 1px solid black;
        }

        .date-sign-area {
            width: 100px;
            height: 40px;
            border-bottom: 1px solid black;
        }

        table {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        td, th {
            border: 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }

        .display-inline {
            display: flex;
            align-items: center;
        }

        .text-left {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="display:contents">
        <div class="body">
            <h3>Mississippi State Department of Health <br/> Form Instructions</h3>
            <h4>DONATION OF LEAVE FOR CATASTROPHIC ILLNESS OR INJURY </h4>
            <div class="content">
                <div class="display-inline">
                    <h4>FORM NUMBER</h4>
                    <p style="margin-left: 30px;">F-4</p>
                </div>
                <div class="display-inline">
                    <h4>REVISION DATE </h4>
                    <p style="margin-left: 30px;">October 1, 2024</p>
                </div>
                <div class="display-inline">
                    <h4>RETENTION PERIOD</h4>
                    <p style="margin-left: 30px;">This form will be retained for a period of three (3) years</p>
                </div>
                <div class="text-left">
                    <h4>PURPOSE</h4>
                    <p>
                        The purpose of this form is to document Donated Leave (Major Medical or Personal) to be used for a 
                        catastrophic injury or illness of either the employee or their immediate family. Immediate family includes 
                        spouse, parent, step-parent, child, step-child and sibling.
                    </p>
                </div>
                <div class="text-left">
                    <h4>INSTRUCTIONS</h4>
                    <p>
                        Enter the amounts of Personal and/or Medical Major Leave to be donated. Leave should be donated in 
                        increments of twenty-four (24) hours.
                    </p>
                </div>
                <div class="text-left">
                    <h4>OFFICE MECHANICS AND FILING</h4>
                    <p>
                        After an employee has completed this form, it should be sent to the employee’s immediate supervisor for 
                        signature. Upon receiving the supervisor's signature, the form should then be forwarded to the Office of 
                        Human Resources (HR). Once reviewed and approved by HR, the form will then be sent to the HR Leave 
                        Department. The HR Leave Department will make the necessary leave entries in the state leave system 
                        and the MSDH leave system. Once all actions have been completed, the form will be filed.
                    </p>
                </div>
            </div>            
        </div>
    </form>
</body>
</html>
