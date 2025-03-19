Imports Microsoft.VisualBasic
Imports System.DirectoryServices
Imports System.Object
Imports System.IO
Imports System.Net
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Class DataBaseProc
    Public Property StartPage As String

    Public Function EqSalvagedInsert(inv As String, desc As String, mfg As String, serial As String, loc As String, sign As String)
        'Dim Sqlconn As String = ConfigurationManager.ConnectionStrings("conString35").ConnectionString
        Dim Sqlconn As String = ConfigurationManager.ConnectionStrings("conStringFamily").ConnectionString
        Dim sql As New StringBuilder
        sql.Append("insert into PropertyEquipmentSalvaged(InventoryNumber, Description, Mfg, Serialnumber, LocationCode, ResponsiblePersonSignature)")
        sql.Append("VALUES(")
        sql.Append("'" & inv)
        sql.Append("','" & desc)
        sql.Append("','" & mfg)
        sql.Append("','" & serial)
        sql.Append("','" & loc)
        sql.Append("','" & sign & "')")
        Dim sqlConnection1 As New SqlConnection(Sqlconn)
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request,(Eqsavlvaged/Insert),EqSalvaged did not get submitted was an ERROR!!!,error discription=>" & ex.Message)
        End Try

        Return Nothing
    End Function

    Public Function InsertEqSalvaged(inv As String, desc As String, mfg As String, serial As String, loc As String, signature As String, Sqlconn As String)


        Dim sql As New StringBuilder
        sql.Append("insert into PropertyEquipmentSalvaged(InventoryNumber, Description, Mfg,ResponsiblePersonSignature, Serialnumber, LocationCode)")
        sql.Append("VALUES(")
        sql.Append("'" & inv)
        sql.Append("','" & desc)
        sql.Append("','" & mfg)
        sql.Append("','" & signature)
        sql.Append("','" & serial)
        sql.Append("','" & loc & "')")

        Dim sqlConnection1 As New SqlConnection(Sqlconn)
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request,(Eqsavlvaged/Insert),EqSalvaged did not get submitted was an ERROR!!!,error discription=>" & ex.Message)
        End Try



        Return Nothing
    End Function


    Public Function InsertPropertyTransfer(TransferCreateDate As String, InventoryNumber As String, Item As String, Make As String, SerialNumber As String, TransferredFrom As String, LocationCodeFrom As String, TransferredTo As String, LocationCodeTo As String,
                                           TransferPersonSignature As String, TransferAuthPerson As String, NameOfPersonTransportSignature As String, Courier As String, Comments As String, Sqlconn As String)
        Dim sql As New StringBuilder
        sql.Append("insert into PropertyTransferLocChange(TransferCreateDate,InventoryNumber,Item,Make, SerialNumber,TransferredFrom, LocationCodeFrom,")
        sql.Append("TransferredTo,LocationCodeTo,TransferPersonSignature,TransferAuthPerson,NameOfPersonTransportSignature,Courier,Comments)")
        sql.Append(" VALUES(")
        sql.Append("'" & TransferCreateDate)
        sql.Append("','" & InventoryNumber)
        sql.Append("','" & Item)
        sql.Append("','" & Make)
        sql.Append("','" & SerialNumber)
        sql.Append("','" & TransferredFrom)
        sql.Append("','" & LocationCodeFrom)
        sql.Append("','" & TransferredTo)
        sql.Append("','" & LocationCodeTo)
        sql.Append("','" & TransferPersonSignature)
        sql.Append("','" & TransferAuthPerson)
        sql.Append("','" & NameOfPersonTransportSignature)
        sql.Append("','" & Courier)
        sql.Append("','" & Comments & "')")

        Dim sqlConnection1 As New SqlConnection(Sqlconn)
        'Dim ID As Integer
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request,(PropertyTransferDecline/Insert),PropertyTransferDeClineNotice did not get sub,itted was an ERROR!!!,error discription=>" & ex.Message)
        End Try
        sqlConnection1.Dispose()
        '  Return ID
        Return Nothing
        'sql.Append("','" & Comments & "');Select Scope_Identify()")
    End Function



    Public Function UpdatePurchaseDeclineNotice(PurchaseID As Integer, SpecialComments As String, Incompleteitems As String, Insufficient As String, CentralSupply As String, NoSupply As String, InsufficientDetail As String, Others As String, SQLconn As String)
        Dim sql As New StringBuilder
        sql.Append("UPDATE MSDH_Forms.dbo.PurchaseDeClineNotice")
        sql.Append(" SET SpecialComments = '" & SpecialComments & "'")
        sql.Append(",Incompleteitems = '" & Incompleteitems & "'")
        sql.Append(",Insufficient = '" & Insufficient & "'")
        sql.Append(",CentralSupply = '" & CentralSupply & "'")
        sql.Append(",NoSupply = '" & NoSupply & "'")
        sql.Append(",InsufficientDetail ='" & InsufficientDetail & "'")
        sql.Append(",Others ='" & Others & "'")
        sql.Append("where  PurchaseID = '" & PurchaseID & "'")

        Dim sqlConnection1 As New SqlConnection(SQLconn)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1
        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()

        Catch ex As Exception
            Throw New Exception("Your Update Purchase Request, (ChangeUpdateApprovedDecline), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)

        Finally
            sqlConnection1.Dispose()
        End Try

        Return Nothing
    End Function

    Public Function GetInvInfo(Inventory As String, SQLconn As String)
        Dim sql As New StringBuilder

        sql.Append(" select *,ResponsiblePerson,b.LocationCode ")
        sql.Append(" From MasterInventory a ")
        sql.Append(" inner join PropertyLocationsCode b on a.Additionallocation = b.locationcode")
        sql.Append(" where INVTag = '" & Inventory & "' ")
        ' Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conStringInv").ConnectionString)
        Dim sqlConnection1 As New SqlConnection(SQLconn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to pull Inventory Info From MasterInventory did Not Get processed there was an ERROR, error discription => " & ex.Message)

        Finally
            sqlConnection1.Close()
            ' sqlConnectin1.Dispose()
        End Try

        Return ds

    End Function


    Public Function GetValidLocCodeToInvNum(LocationCode As String, Inventory As String, SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append(" Select * from MasterInventory")
        sql.Append(" where INVTag = '" & Inventory & "'")
        If LocationCode <> "" Then
            Dim loc As String = LocationCode
            Dim loc1() As String = loc.Split(",")
            sql.Append(" and AdditionalLocation in (")
            For x = 0 To loc1.Length - 1
                If x = 0 Then
                    sql.Append("'" & loc1(x) & "'")
                Else
                    sql.Append("'" & loc1(x) & "'")
                End If
            Next
            sql.Append(")")
        End If

        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request get GetValidLocCodeToInvNum/MasterInventory did Not Get processed there was an ERROR, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()

        End Try
        Return ds
    End Function

    Public Function GetRespPerson(Inventory1 As String, Sqlconn As String)
        Dim sql As New StringBuilder
        sql.Append(" Select b.LocationCode,b.ResponsiblePerson,b.ResponsiblePerson2,b.ResponsiblePerson3 ")
        sql.Append("from MasterInventory a ")
        sql.Append("inner join PropertyLocationsCode b on a.Additionallocation = b.locationcode")
        sql.Append(" where INVTag = '" & Inventory1 & "'")
        Dim sqlConnection1 As New SqlConnection(Sqlconn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception(" Your Request get ResponsiblePerson/MasterInventory did not Get processed there was an ERROR, error discription=> " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try

        Return ds
    End Function

    Public Function GetLocCodes(LocationCode As String, Type As String, Sqlconn As String)
        Dim loc As String = LocationCode
        Dim loc1 As String = loc.Split("|").ToString
        Dim loc0 As String = ""
        Dim loc9() As String
        Dim sql As New StringBuilder
        sql.Append(" Select RecordID,LocationCode,LocationName ")
        sql.Append(" From PropertyLocationsCode where locationname <> '' ")
        If LocationCode <> "" Then
            For x = 0 To loc1.Count - 1
                loc0 = loc1(x)
                loc9 = loc0.Split("-")
                If x = 0 Then
                    sql.Append(" and LocationCode = '" & loc9(0) & "'")
                Else
                    sql.Append(" or LocationCode = '" & loc9(0) & "'")
                End If
            Next
        End If
        If Type = "1" Or Type = "" Then
            sql.Append(" order by LocationName")
        ElseIf Type = "2" Then
            sql.Append(" order by LocationCode")
        End If
        Dim sqlConnection1 As New SqlConnection(Sqlconn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request get GetLocCodes/PropertyLocationsCode did Not Get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally



            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function



    Public Function GetPurchaseFormDeclinenote(PurchaseID As Integer, SqlConn As String)
        Dim sql As New StringBuilder

        sql.Append(" Select * ")
        sql.Append(" FROM MSDH_Forms.dbo.PurchaseDeClineNotice")
        sql.Append(" where PurchaseID = " & PurchaseID)

        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("Purchase Table was Not read there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function
    Public Function UpdatePurchaseForm(Recordid As Integer, PurchaseSignature As String, Purchasedate As String, SQLconn As String)
        Dim sql As New StringBuilder
        sql.Append("UPDATE PurchaseRequest")
        sql.Append(" SET PurchaserSignature = '" & PurchaseSignature & "'")
        sql.Append(",PurchaserDate = '" & Purchasedate & "'")
        sql.Append(" where RecordID = " & Recordid)
        Dim sqlConnection1 As New SqlConnection(SQLconn)
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()

        Catch ex As Exception
            Throw New Exception("Your Update Request, (Purchase/UpdatePurchase), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function UpdateApproveForm(Recordid As Integer, ApproverSignature As String, ApproverDate As String, SQLconn As String)
        Dim sql As New StringBuilder
        sql.Append("UPDATE PurchaseRequest")
        'sql.Append(" SET ApproverSignature = '" & ApproverSignature & "'")
        'sql.Append(",ApproverDate = '" & ApproverDate & "'")
        sql.Append(" SET ApproverSignature = '" & ApproverSignature & "'")
        sql.Append(",ApproverDate = '" & ApproverDate & "'")
        sql.Append(" where RecordID = " & Recordid)
        Dim sqlConnection1 As New SqlConnection(SQLconn)
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()

        Catch ex As Exception
            Throw New Exception("Your Update Request, (Approve/UpdateApprove), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function InsertPurchaseDeclineNotice(PurchaseId As Integer, SpecialComments As String, Incompleteitems As String, Insufficient As String, CentralSupply As String, NoSupply As String, InsufficientDetail As String, Others As String, SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append("insert into PurchaseDeClineNotice(PurchaseId,SpecialComments,Incompleteitems,Insufficient,CentralSupply,NoSupply,InsufficientDetail,Others)")
        sql.Append(" VALUES(")
        sql.Append(PurchaseId)
        sql.Append(",'" & Replace(SpecialComments, "'", "''"))
        sql.Append("','" & Replace(Incompleteitems, "'", "''"))
        sql.Append("','" & Replace(Insufficient, "'", "''"))
        sql.Append("','" & Replace(CentralSupply, "'", "''"))
        sql.Append("','" & NoSupply)
        sql.Append("','" & InsufficientDetail)
        sql.Append("','" & Others & "')")

        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()

        Catch ex As Exception
            Throw New Exception("Your Request, (PurchaseDecline/Insert), PurchaseDeClineNotice did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try

        Return Nothing
    End Function


    Public Function GetPurchaseForm(RecordId As Integer, SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append(" select * ")
        sql.Append(" from MSDH_Forms.dbo.PurchaseRequest a")
        sql.Append(" inner join PurchaseDetail b on a.RecordID = b.purchaseID ")
        sql.Append(" where a.RecordID ='" & RecordId & "'")
        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()


        Catch ex As Exception
            Throw New ApplicationException("Purchase Table was not read there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function
    Public Function InsertPurchaseDetail6260(purchaseID As Integer, Descriptionz_Catalog_Number As String, IdentifyingNumber As String, Quantity As String, UnitCost As String, Extension As String, SQLConn As String)
        Dim sql As New StringBuilder
        Dim ID As Integer
        sql.Append("insert into PurchaseDetail(purchaseID,Descriptionz_Catalog_Number ,IdentifyingNumber,Quantity,UnitCost,Extension) ")
        sql.Append(" VALUES(")
        sql.Append(purchaseID)
        sql.Append(",'" & Replace(Descriptionz_Catalog_Number, "'", "''"))
        sql.Append("','" & Replace(IdentifyingNumber, "'", "''"))
        sql.Append("','" & Replace(Quantity, "'", "''"))
        sql.Append("','" & Replace(UnitCost, "'", "''"))
        sql.Append("','" & Extension & "')")

        Dim sqlConnection1 As New SqlConnection(SQLConn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (RequestForm/InsertForm), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try

        Return Nothing
    End Function
    Public Function InsertPurchaseDetail626(purchaseID As Integer, Descriptionz_Catalog_Number As String, IdentifyingNumber As String, Quantity As String, UnitCost As String, Extension As String, SQLConn As String)
        Dim sql As New StringBuilder
        Dim ID As Integer
        sql.Append("insert into PurchaseDetail(purchaseID,Descriptionz_Catalog_Number ,IdentifyingNumber,Quantity,UnitCost,Extension) ")
        sql.Append(" VALUES('")
        sql.Append(purchaseID)
        sql.Append("','" & Replace(Descriptionz_Catalog_Number, "'", "''"))
        sql.Append("','" & Replace(IdentifyingNumber, "'", "''"))
        sql.Append("','" & Replace(Quantity, "'", "''"))
        sql.Append("','" & Replace(UnitCost, "'", "''"))
        sql.Append("','" & Extension & "')")

        Dim sqlConnection1 As New SqlConnection(SQLConn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (RequestForm/InsertForm), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try

        Return Nothing
    End Function
    Public Function InsertPurchaseForms1(FiscalYear As String, UcNumber As String, Request_Address As String, Request_Address1 As String, Request_Address2 As String, Request_City As String, Request_state As String, Request_Zip As String _
                                         , Ship_Address As String, Ship_Address1 As String, Ship_Address2 As String, Ship_City As String, Ship_State As String _
                                         , Ship_Zip As String, CostCenter As String, CostCenter1 As String, CostCenter2 As String, FunctionArea As String, InternalOrder As String, RequestSignature As String, RequestDate As String, ApproverSignature As String, ApproverDate As String, ApproverEmail As String, SQLconn As String)
        Dim sql As New StringBuilder

        sql.Append("insert into PurchaseRequest(FiscalYear,UcNumber,Request_Address,Request_Address1,Request_Address2,Request_City, Request_state,Request_Zip,Ship_Address,Ship_Address1,Ship_Address2,Ship_City,Ship_State,Ship_Zip,CostCenter,CostCenter1,CostCenter2,FunctionArea,InternalOrder,RequestSignature,RequestDate,ApproverSignature,ApproverDate,ApproverEmail)")
        sql.Append(" VALUES(")
        sql.Append("'" & Replace(FiscalYear, "'", "''"))
        sql.Append("','" & UcNumber)
        sql.Append("','" & Request_Address)
        sql.Append("','" & Request_Address1)
        sql.Append("','" & Request_Address2)
        sql.Append("','" & Request_City)
        sql.Append("','" & Request_state)
        sql.Append("','" & Request_Zip)
        sql.Append("','" & Ship_Address)
        sql.Append("','" & Ship_Address1)
        sql.Append("','" & Ship_Address2)
        sql.Append("','" & Ship_City)
        sql.Append("','" & Ship_State)
        sql.Append("','" & Ship_Zip)
        sql.Append("','" & CostCenter)
        sql.Append("','" & CostCenter1)
        sql.Append("','" & CostCenter2)
        sql.Append("','" & FunctionArea)
        sql.Append("','" & InternalOrder)
        sql.Append("','" & RequestSignature)
        sql.Append("','" & RequestDate)
        sql.Append("','" & ApproverSignature)
        sql.Append("','" & ApproverDate)
        sql.Append("','" & [ApproverEmail] & "') ; Select Scope_Identity()")


        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(SQLconn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)

                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (RequestForm/InsertForm), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertPurchaseForms(FiscalYear As String, UcNumber As String, Request_Address As String, Request_Address1 As String, Request_Address2 As String, Request_City As String, Request_state As String, Request_Zip As String _
                                         , Ship_Address As String, Ship_Address1 As String, Ship_Address2 As String, Ship_City As String, Ship_State As String _
                                         , Ship_Zip As String, CostCenter As String, CostCenter1 As String, CostCenter2 As String, FunctionArea As String, InternalOrder As String, RequestSignature As String, RequestDate As String, ApproverSignature As String, ApproverDate As String, ApproverEmail As String, SQLconn As String)
        Dim sql As New StringBuilder

        sql.Append("insert into PurchaseRequest(FiscalYear,UcNumber,Request_Address,Request_Address1,Request_Address2,Request_City, Request_state,Request_Zip,Ship_Address,Ship_Address1,Ship_Address2,Ship_City,Ship_State,Ship_Zip,CostCenter,CostCenter1,CostCenter2,FunctionArea,InternalOrder,RequestSignature,RequestDate,ApproverSignature,ApproverDate,ApproverEmail)")
        sql.Append(" VALUES(")
        sql.Append("'" & Replace(FiscalYear, "'", "''"))
        sql.Append("','" & UcNumber)
        sql.Append("','" & Request_Address)
        sql.Append("','" & Request_Address1)
        sql.Append("','" & Request_Address2)
        sql.Append("','" & Request_City)
        sql.Append("','" & Request_state)
        sql.Append("','" & Request_Zip)
        sql.Append("','" & Ship_Address)
        sql.Append("','" & Ship_Address1)
        sql.Append("','" & Ship_Address2)
        sql.Append("','" & Ship_City)
        sql.Append("','" & Ship_State)
        sql.Append("','" & Ship_Zip)
        sql.Append("','" & CostCenter)
        sql.Append("','" & CostCenter1)
        sql.Append("','" & CostCenter2)
        sql.Append("','" & FunctionArea)
        sql.Append("','" & InternalOrder)
        sql.Append("','" & RequestSignature)
        sql.Append("','" & RequestDate)
        sql.Append("','" & ApproverSignature)
        sql.Append("','" & ApproverDate)
        sql.Append("','" & [ApproverEmail] & "') ; Select Scope_Identity()")


        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(SQLconn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)

                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (RequestForm/InsertForm), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function




    Public Function UpdateResponseNotes(ResponseNotes As String, RecordID As Integer, nextpage As String, CCEmails As String, ApprovalGroup As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.Form907 ")
        sql.Append(" SET ResponseNotes = '" & Replace(ResponseNotes, "'", "''''") & "'")
        sql.Append(", StartPage = '" & nextpage & "'")
        If Trim(CCEmails) <> "" Then
            sql.Append(", CCEmails = '" & CCEmails & "'")
        End If
        If Trim(ApprovalGroup) <> "" Then
            sql.Append(", ApprovalGroup = '" & ApprovalGroup & "'")
        End If
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (RequestForm/UpdateResponseNotes), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateApplication(Recordid As Integer, SQLconn As String)
        Dim sql As New StringBuilder
        sql.Append("Update  MSDH_FamilyPlanning.dbo.Application")
        sql.Append("set Firstname='" & "'")
        'sql.Append(", CompletedBy = '" &   & "'")
        sql.Append(", PID=''")
        sql.Append(", Address=''")
        sql.Append(", City=''")



        Return Nothing
    End Function



    Public Function UpdateAuthPerson(RecordID As Integer)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.Form907 ")
        sql.Append(" SET AuthPerson = ''")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (RequestForm/UpdateAuthPerson), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateStartPage(Link As String, RecordID As Integer)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.Form907 ")
        sql.Append(" SET StartPage = '" & Link & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (RequestForm/UpdateStartPage), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateStartPageTT(Link As String, RecordID As Integer)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.TravelTraining ")
        sql.Append(" SET StartPage = '" & Link & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (TravelTraining/UpdateStartPageTT), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateStartPageCM(Link As String, RecordID As Integer)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.ChangeManagement ")
        sql.Append(" SET StartPage = '" & Link & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        'Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            'reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (ChangeManagement/UpdateStartPageCM), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateCompleted(RecordID As String, UserLogin As String, Link As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.Form907 ")
        sql.Append(" SET DateFormCompleted = '" & Now() & "'")
        sql.Append(", CompletedBy = '" & UserLogin & "'")
        sql.Append(", StartPage = '" & Link & "'")
        sql.Append(", Inactive = 1")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Completed Update did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateSupvApp(Link As String, RecordID As Integer, AppPerson As String, AuthPerson As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.Form907 ")
        sql.Append(" SET StartPage = '" & Link & "'")
        sql.Append(", ApprovalPerson = '" & AppPerson & "'")
        sql.Append(", ApprovalDate = '" & Today() & "'")
        sql.Append(", AuthPerson = '" & AuthPerson & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Completed Update did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function Update907(RecordID As String, UserLogin As String, Level As String, Link As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.Form907 ")
        If Link <> "" Then
            sql.Append(" SET DateFormCompleted = '" & Now() & "'")
            sql.Append(", CompletedBy = '" & UserLogin & "'")
            sql.Append(", StartPage = '" & Link & "'")
            sql.Append(", Inactive = 1")
            sql.Append(", ApprovalUserLoginLevel" & Level & " = '" & UserLogin & "'")
            sql.Append(", ApprovalDateCompletedLevel" & Level & " = '" & Now() & "'")
            sql.Append(" Where RecordID = " & RecordID)
        Else
            sql.Append(" SET ApprovalUserLoginLevel" & Level & " = '" & UserLogin & "'")
            sql.Append(", ApprovalDateCompletedLevel" & Level & " = '" & Now() & "'")
            sql.Append(" Where RecordID = " & RecordID)
        End If

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Completed Update did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateApplicationForm(recordID As Integer, FirstName As String, LastName As String, PID As String, Address As String, City As String, State As String _
                                          , zip As String, Spouse As String, children As String, CreateData As String, Username As String)

        Dim sql As New StringBuilder
        sql.Append(" UPDATE MSDH_FamilyPlanning.dbo.Application ")

        sql.Append(" SET FirstName = '" & Replace(FirstName, "'", "''''") & "',LastName = '" & Replace(LastName, "'", "''''") & "',PID = '" & Replace(PID, "'", "''''") & "'
        ,Address = '" & Replace(Address, "'", "''''") & "',City = '" & Replace(City, "'", "''''") & "',State = '" & Replace(State, "'", "''''") & "',Zip = '" & Replace(zip, "'", "''''") & "'
        ,Spouse = '" & Replace(Spouse, "'", "''''") & "',children = '" & Replace(children, "'", "''''") & "',CreateData = '" & Replace(CreateData, "'", "''''") & "',Username = '" & Replace(Username, "'", "''''") & "'")
        sql.Append(" Where RecordID = " & recordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("ApplicationString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Completed Update did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateForm(RecordID As Integer, SSNLast4 As String, FirstName As String, LastName As String, UserLogin As String, JobTitle As String _
                               , WIN As String, PIN As String, BusTemp As String, UNIT As String, LocationRoom As String, PhoneNumber As String, ComputerAccess As String, Telecommunication As String _
                              , Pagertelephone As String, IDBadge As String, NewEmployee As String, CurrentEmployee As String, TerminateEmployee As String, actionAdd As String _
                              , actionChange As String, actionDelete As String, EffectiveDate As String, ContractEmployeeTerminationDate As String, orgCode As String _
                              , Actv As String, Rptg As String, UnitSecurityContact As String, Justification As String _
                              , TelephoneService As String, LongDistanceAuthorization As String, ClinicLocation As String, EmployeeClass As String _
                              , PictureName As String, PitctureNumber As String, Officedoor1 As String _
                              , Date1 As String, Notes As String, TimesFrames As String, TimeFramesNotes As String, PersonNumber As String, HIPAATraining As String _
                              , ComputerForm As String, SPAHRS_HR As String, Network As String, ResponseNotes As String _
                              , ApplNumberLogin As String, Justification_24_7 As String, StartPage As String, DateFormUpdated As String)


        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.Form907 ")
        sql.Append(" SET SSNLast4 = '" & SSNLast4 & "',FirstName = '" & Replace(FirstName, "'", "''''") & "',LastName = '" & Replace(LastName, "'", "''''") & "',UserLogin = '" & UserLogin & "',JobTitle = '" & JobTitle & "'")
        sql.Append(",WIN='" & WIN & "',PIN='" & PIN & "',BUS_TEMP='" & BusTemp & "',UNIT='" & UNIT & "',LocationRoom='" & LocationRoom & "',PhoneNumber='" & PhoneNumber & "'")
        sql.Append(",ComputerAccess='" & ComputerAccess & "',Telecommunication='" & Telecommunication & "',Pagertelephone='" & Pagertelephone & "',IDBadge='" & IDBadge & "'")
        sql.Append(",NewEmployee = '" & NewEmployee & "',CurrentEmployee = '" & CurrentEmployee & "',TerminateEmployee = '" & TerminateEmployee & "',actionAdd = '" & actionAdd & "'")
        sql.Append(",actionChange = '" & actionChange & "',actionDelete = '" & actionDelete & "',EffectiveDate = '" & EffectiveDate & "',ContractEmployeeTerminationDate = '" & ContractEmployeeTerminationDate & "'")
        sql.Append(",orgCode='" & orgCode & "',Actv='" & Actv & "',Rptg='" & Rptg & "'")
        sql.Append(",UnitSecurityContact='" & UnitSecurityContact & "',Justification='" & Replace(Justification, "'", "''''") & "'")
        sql.Append(",TelephoneService='" & TelephoneService & "',LongDistanceAuthorization='" & LongDistanceAuthorization & "'")
        sql.Append(",ClinicLocation='" & ClinicLocation & "',EmployeeClass='" & EmployeeClass & "'")
        sql.Append(",PictureName='" & PictureName & "',PitctureNumber='" & PitctureNumber & "'")
        sql.Append(",Officedoor1='" & Replace(Officedoor1, "'", "''''") & "',Date='" & Date1 & "'")
        sql.Append(",Notes='" & Replace(Notes, "'", "''''") & "',TimesFrames='" & TimesFrames & "',TimeFramesNotes='" & Replace(TimeFramesNotes, "'", "''''") & "',PersonNumber='" & PersonNumber & "',HIPAATraning='" & HIPAATraining & "'")
        sql.Append(",ComputerForm='" & ComputerForm & "',SPAHRS_HR='" & SPAHRS_HR & "',Network='" & Network & "',ResponseNotes='" & Replace(ResponseNotes, "'", "''''") & "',ApplicationNumberLogin='" & ApplNumberLogin & "'")
        sql.Append(",Justification_24_7='" & Justification_24_7 & "',StartPage='" & StartPage & "',DateFormUpdated='" & DateFormUpdated & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Updated Request, (RequestForm/btnSubmit_Click), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Friend Function GetPropertyUser(v1 As Object, v2 As String, sqlConn1 As String) As DataSet
        Throw New NotImplementedException()
    End Function

    Public Function InsertAllowedSite(ClientID As Integer, SiteID As Integer, SiteName As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO MSDH_Forms.dbo.MSDHAllowedSites (clientID,siteID,SiteName)")
        sql.Append("  VALUES('")
        sql.Append(ClientID)
        sql.Append("','" & SiteID)
        sql.Append("','" & SiteName & "')")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim rowCount As Integer

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)

                sqlConnection1.Open()
                rowCount = cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Insert into AllowedSites did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return rowCount
    End Function

    Public Function InsertTimeStudyDates(FromDate As String, ToDate As String, Month As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO MSDH_Forms.dbo.MSDHFormsConfig (Setting,Value1,Value2,Value3)")
        sql.Append("  VALUES('")
        sql.Append("TimeStudyMonth")
        sql.Append("','" & Month)
        sql.Append("','" & FromDate)
        sql.Append("','" & ToDate & "')")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        'Dim rowCount As Integer

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                'rowCount = cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Insert into MSDHFormsConfig did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function insertAppplicationFormu(FirstName As String, LastName As String, PID As String, Address As String, City As String, State As String _
                                 , zip As String, Spouse As String, Children As String, CreateDate As String, Username As String, SQLConn As String)

        ' Dim ID As Integer
        Dim sql As New StringBuilder
        sql.Append("insert into Application(FirstName,LastName,PID,Address,City,State,zip,Spouse,Children,CreateData,Username) ")
        sql.Append(" VALUES(")
        sql.Append("'" & Replace(FirstName, "'", "''"))
        sql.Append("','" & Replace(LastName, "'", "''"))
        sql.Append("','" & PID)
        sql.Append("','" & Replace(Address, "'", "''"))
        sql.Append("','" & Replace(City, "'", "''"))
        sql.Append("','" & Replace(State, "'", "''"))
        sql.Append("','" & Replace(zip, "'", "''"))
        sql.Append("','" & Replace(Spouse, "'", "''"))
        sql.Append("','" & Replace(Children, "'", "''"))
        sql.Append("','" & Replace(CreateDate, "'", "''"))
        sql.Append("','" & Replace(Username, "'", "''''") & "')")


        Dim sqlConnection1 As New SqlConnection(SQLConn)
        Dim cmd As New SqlCommand

        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (Application/insertAppplicationForm), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing

    End Function



    Public Function InsertFoodForm(FacilityName As String, FacilityDate As String, Address As String, City As String, State As String, Zip As String _
                                 , DayOf As String, Month As String, Year As String, Name As String, title As String, Release As String, Area As String, InspectorSignature As String, FirmRepresentative As String, Approverdate As String, ApproverEmail As String, FileName As String, DataFile As Byte(), SQLconn As String)
        'txtFacility.Text, txtdate1.Text, txtAddress.Text, txtcity.Text, StateList.SelectedValue, txtZip.Text, txtDay.Text, txtMonth.Text, txtYear.Text, txtname.Text, txttitle.Text, txtRelease.Text, txtArea.Value, hInspectorSignature.Value, txtRepresentative.Text, txtdate.Text, hApproverSignature.Value, SQLconn)
        Dim sql As New StringBuilder
        'sql.Append("insert into FoodForm(FacilityName,Date,Address,City,State,Zip,haveon,Month,Year,Name,Title,Release,ReasonforDestructionFoodItem,InspectorSignature,FirmRepresentative,Approverdate,ApproverEmail) ")
        sql.Append("insert into FoodForm(FacilityName,Date,Address,City,State,Zip,DayOf,Month,Year,Name,Title,Release,ReasonforDestructionFoodItem,InspectorSignature,FirmRepresentative,Approverdate,FileName,DataFile,ApproverEmail) ")


        sql.Append(" VALUES(")
        sql.Append("'" & Replace(FacilityName, "'", "''"))
        sql.Append("','" & FacilityDate)

        sql.Append("','" & Replace(Address, "'", "''"))
        sql.Append("','" & Replace(City, "'", "''"))
        sql.Append("','" & State)
        sql.Append("','" & Zip)
        sql.Append("','" & DayOf)
        sql.Append("','" & Month)
        sql.Append("','" & Year)
        sql.Append("','" & Name)
        sql.Append("','" & title)
        sql.Append("','" & Release)
        sql.Append("','" & Area)
        sql.Append("','" & InspectorSignature)

        sql.Append("','" & FirmRepresentative)
        sql.Append("','" & Approverdate)
        sql.Append("',@Name1")
        sql.Append(",@File1")

        sql.Append(",'" & ApproverEmail & "') ; Select Scope_Identity()")
        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(SQLconn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                cmd.Parameters.Add("@Name1", SqlDbType.VarChar).Value = FileName
                cmd.Parameters.Add("@File1", SqlDbType.Binary).Value = DataFile

                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (RequestForm/InsertForm), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try

        Return ID
    End Function

    Public Function InsertDeclineNotice(FoodID As Integer, DeclineNotice As String, SQLconn As String)
        Dim sql As New StringBuilder
        sql.Append("insert into DeclineNotice(FoodID,DeclineNotice) ")
        sql.Append(" VALUES(")
        sql.Append(FoodID)
        sql.Append(",'" & Replace(DeclineNotice, "'", "''") & "')")

        Dim sqlConnection1 As New SqlConnection(SQLconn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (DeclineNotice), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function InsertFoodFormDetail(FoodID As Integer, Items As String, Descrip As String, Quantity As String, Vol As String, SQLconn As String)

        Dim sql As New StringBuilder
        sql.Append("insert into FoodFormDetail(FoodID,NameofEmbargoedItemsDestroyed ,Description,Quantity,VolWt) ")
        sql.Append(" VALUES('")
        sql.Append(FoodID)
        sql.Append("','" & Replace(Items, "'", "''"))
        sql.Append("','" & Replace(Descrip, "'", "''"))
        sql.Append("','" & Quantity)
        sql.Append("','" & Vol & "')")
        'sql.Append("','" & StartPage & "') ; Select Scope_Identity()")
        Dim sqlConnection1 As New SqlConnection(SQLconn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (FoodFormDetail/InsertFoodFormDetail), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function GetAppInfo(RecordID As Integer, SQLConn As String)
        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From Application")
        sql.Append(" where RecordID = " & RecordID)
        Dim sqlConnection1 As New SqlConnection(SQLConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("Your Select of GetAppInfo table did not get submitted there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function




    Public Function InsertForm(SSNLast4 As String, FirstName As String, LastName As String, UserLogin As String, JobTitle As String _
                                , WIN As String, PIN As String, BusTemp As String, UNIT As String, LocationRoom As String, PhoneNumber As String, ComputerAccess As String, Telecommunication As String _
                                , Pagertelephone As String, IDBadge As String, NewEmployee As String, CurrentEmployee As String, TerminateEmployee As String, actionAdd As String _
                                , actionChange As String, actionDelete As String, EffectiveDate As String, ContractEmployeeTerminationDate As String, orgCode As String _
                                , Actv As String, Rptg As String, UnitSecurityContact As String, Justification As String _
                                , TelephoneService As String, LongDistanceAuthorization As String, ClinicLocation As String, EmployeeClass As String _
                                , PictureName As String, PictureNumber As String, Officedoor1 As String, Date1 As String _
                                , Notes As String, TimesFrames As String, TimeFramesNotes As String, PersonNumber As String, HIPAATraining As String, ComputerForm As String _
                                , SPAHRS_HR As String, Network As String, ApplicationNumberLogin As String _
                                , Justification_24_7 As String, PersonEnteredForm As String, RequestersEmail As String, StartPage As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO Form907 (SSNLast4,FirstName,LastName,UserLogin,JobTitle,WIN,PIN,BUS_TEMP,UNIT,LocationRoom,PhoneNumber,ComputerAccess,Telecommunication,Pagertelephone,IDBadge")
        sql.Append(",NewEmployee,CurrentEmployee,TerminateEmployee,actionAdd,actionChange,actionDelete,EffectiveDate,ContractEmployeeTerminationDate,orgCode,Actv,Rptg,UnitSecurityContact")
        sql.Append(",Justification,ClinicLocation, PersonNumber, HIPAATraning, ComputerForm, SPAHRS_HR,TelephoneService")
        sql.Append(",LongDistanceAuthorization,EmployeeClass,PictureName,PitctureNumber,Officedoor1,Date,Notes,TimesFrames")
        sql.Append(",TimeFramesNotes,Inactive,DateFormEntered,PersonEnteredForm,RequestersEmail,StartPage,NETWORK,ApplicationNumberLogin,Justification_24_7)")
        sql.Append("  VALUES(")
        sql.Append("'" & SSNLast4)
        sql.Append("','" & Replace(FirstName, "'", "''''"))
        sql.Append("','" & Replace(LastName, "'", "''''"))
        sql.Append("','" & UserLogin)
        sql.Append("','" & JobTitle)
        sql.Append("','" & WIN)
        sql.Append("','" & PIN)
        sql.Append("','" & BusTemp)
        sql.Append("','" & UNIT)
        sql.Append("','" & LocationRoom)
        sql.Append("','" & PhoneNumber)
        If ComputerAccess = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If Telecommunication = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If Pagertelephone = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If IDBadge = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If NewEmployee = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If CurrentEmployee = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If TerminateEmployee = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If actionAdd = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If actionChange = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If

        If actionDelete = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        sql.Append("','" & EffectiveDate)
        sql.Append("','" & ContractEmployeeTerminationDate)
        sql.Append("','" & orgCode)
        sql.Append("','" & Actv)
        sql.Append("','" & Rptg)
        sql.Append("','" & UnitSecurityContact)
        sql.Append("','" & Replace(Justification, "'", "''''"))
        sql.Append("','" & ClinicLocation)
        sql.Append("','" & PersonNumber)
        sql.Append("','" & HIPAATraining)
        sql.Append("','" & ComputerForm)
        sql.Append("','" & SPAHRS_HR)
        If TelephoneService = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If LongDistanceAuthorization = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        sql.Append("','" & EmployeeClass)
        sql.Append("','" & PictureName)
        sql.Append("','" & PictureNumber)
        Dim rOfficeDoor As String = Replace(Officedoor1, "'", "''''")
        sql.Append("','" & rOfficeDoor)
        sql.Append("','" & Date1)
        Dim rNotes As String = Replace(Notes, "'", "''''")
        sql.Append("','" & rNotes)
        sql.Append("','" & TimesFrames)
        Dim rTimeFramesNotes As String = Replace(TimeFramesNotes, "'", "''''")
        sql.Append("','" & rTimeFramesNotes)
        sql.Append("'," & 0)
        sql.Append(",'" & Now())
        sql.Append("','" & PersonEnteredForm)
        sql.Append("','" & RequestersEmail)
        sql.Append("','" & StartPage)
        sql.Append("','" & Network)
        sql.Append("','" & ApplicationNumberLogin)
        sql.Append("','" & Justification_24_7 & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                'ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (RequestForm/InsertForm), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertTravelRequest(FirstName As String, LastName As String, EncryptSSN As String, UserLogin As String, JobTitle As String _
                             , PhoneNumber As String, FromCity As String, FromState As String, ToCity As String, ToState As String, DistrictCountyOffice As String _
                            , AnnualProfMeeting As String, RequiredTrainingMeeting As String, OtherTraining As String, OtherMeeting As String _
                            , DateOfTravel As String, DateOfProgramMeeting As String, ProgMeetingTitle As String _
                            , JustificationExplanation As String, TravelAdvanceAmount As String, AirFare As String, MileageMiles As String, MileageAt As String _
                            , MileageTotal As String, HotelNights As String, HotelAt As String, HotelTotal As String, Meals As String, Registration As String _
                            , OtherSpecifiy As String, OtherExp As String, TotalExp As String, OrgCode As String, ACTV As String, RPTG As String, Project As String _
                            , TimeOnly As String, PriorOutOfState As String, PriorInstate As String, DateFormEntered As String, StartPage As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO TravelTraining (FirstName,LastName,UserLogin,SSN,JobTitle,PhoneNumber,FromCity,FromState,ToCity,ToState,DistrictCountyHealthDeptOffice,AnnualProfessionalMeeting")
        sql.Append(",RequiredTrainingMeeting,OtherTraining,OtherMeeting,DateOfTravel,DateOfProgramMeeting,ProgramMeetingTitle,JustificationExplanation,TravelAdvanceAmount,AirFareCost,MileageMiles")
        sql.Append(",MileagePay,MileageTotal,HotelDaysStayed,HotelCost,HotelTotal,MealsCost,RegistrationCost,OtherSpecify,OtherExpense,TotalExpenses,OrgCode,ACTV,RPTG,Project,TimeOnly")
        sql.Append(",PriorOutOfStateTravel,PriorInStateTravel,DateFormEntered,Inactive,StartPage)")
        sql.Append("  VALUES(")
        sql.Append("'" & Replace(FirstName, "'", "''''"))
        sql.Append("','" & Replace(LastName, "'", "''''"))
        sql.Append("','" & UserLogin)
        sql.Append("','" & EncryptSSN)
        sql.Append("','" & JobTitle)
        sql.Append("','" & PhoneNumber)
        sql.Append("','" & FromCity)
        sql.Append("','" & FromState)
        sql.Append("','" & ToCity)
        sql.Append("','" & ToState)
        sql.Append("','" & Replace(DistrictCountyOffice, "'", "''"))
        If AnnualProfMeeting = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If RequiredTrainingMeeting = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If OtherTraining = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If OtherMeeting = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        sql.Append("','" & DateOfTravel)
        sql.Append("','" & DateOfProgramMeeting)
        sql.Append("','" & Replace(ProgMeetingTitle, "'", "''"))
        sql.Append("','" & Replace(JustificationExplanation, "'", "''"))
        sql.Append("','" & TravelAdvanceAmount)
        sql.Append("','" & AirFare)
        sql.Append("','" & MileageMiles)
        sql.Append("','" & MileageAt)
        sql.Append("','" & MileageTotal)
        sql.Append("','" & HotelNights)
        sql.Append("','" & HotelAt)
        sql.Append("','" & HotelTotal)
        sql.Append("','" & Meals)
        sql.Append("','" & Registration)
        sql.Append("','" & OtherSpecifiy)
        sql.Append("','" & OtherExp)
        sql.Append("','" & TotalExp)
        sql.Append("','" & OrgCode)
        sql.Append("','" & ACTV)
        sql.Append("','" & RPTG)
        sql.Append("','" & Project)
        If TimeOnly = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        sql.Append("','" & Replace(PriorOutOfState, "'", "''"))
        sql.Append("','" & Replace(PriorInstate, "'", "''"))
        sql.Append("','" & DateFormEntered)
        sql.Append("','0")
        sql.Append("','" & StartPage & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection)
                sqlConnection.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (TravelTraining/Insert), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertChangeMgt(UserLogin As String, NameofApplicationorDatabase As String, ProgramArea As String, Requestor As String, Reqtelephone As String, ReqEmail As String, VendorContactName As String, VendorTelephone As String, VendorEmail As String _
                              , DescriptionOfUpgrade As String, ChangeComponents As String, SpecialInstructions As String, ReasonForChange As String, AffectedDB As String, EnvComments As String _
                             , DatabaseRefreshYes As String, DatabaseRefreshno As String, RefreshDB As String _
                             , DateRequested As String, IdealTime As String, ResourceChangeYes As String, ResourceChangeNo As String, FileUpload1 As String, FileUpload2 As String, FileUpload3 As String _
                             , Supervisor As String, DateEntered As String, StartPage As String)





        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO ChangeManagement (UserLogin,NameOfApplicationOrDatabase ,ProgramArea,RequestorName,RequestorPhoneNumber,RequestorEmail,VendorContactName,VendorPhoneNumber,VendorEmail")
        sql.Append(",DescriptionOfUpdate,ChangeComponents,SpecialInstructions,ReasonForChange,EnvironmentAffected,EnvironmentComments,DatabaseRefreshYesNo,DatabaseToBeRefreshed,DateRequested")
        sql.Append(",IdealTime,ResourceChangeYesNo,AdditionalFiles1,AdditionalFiles2,AdditionalFiles3,SupervisorEmail,DateEntered,Inactive,StartPage)")
        sql.Append("  VALUES(")
        sql.Append("'" & UserLogin)
        sql.Append("','" & NameofApplicationorDatabase)
        sql.Append("','" & ProgramArea)
        sql.Append("','" & Requestor)
        sql.Append("','" & Reqtelephone)
        sql.Append("','" & ReqEmail)
        sql.Append("','" & VendorContactName)
        sql.Append("','" & VendorTelephone)
        sql.Append("','" & VendorEmail)
        sql.Append("','" & Replace(DescriptionOfUpgrade, "'", "''"))
        sql.Append("','" & Replace(ChangeComponents, "'", "''"))
        sql.Append("','" & Replace(SpecialInstructions, "'", "''"))
        sql.Append("','" & Replace(ReasonForChange, "'", "''"))
        sql.Append("','" & AffectedDB)
        sql.Append("','" & Replace(EnvComments, "'", "''"))
        If DatabaseRefreshYes = True Then
            sql.Append("','Yes")
        ElseIf DatabaseRefreshno = True Then
            sql.Append("','No")
        End If
        sql.Append("','" & RefreshDB)
        sql.Append("','" & DateRequested)
        sql.Append("','" & IdealTime)
        If ResourceChangeYes = True Then
            sql.Append("','Yes")
        ElseIf ResourceChangeNo = True Then
            sql.Append("','No")
        End If


        sql.Append("',@File1")
        sql.Append("',@File2")
        sql.Append("',@File3")
        'sql.Append("','" & FileUpload1)
        'sql.Append("','" & FileUpload2)
        'sql.Append("','" & FileUpload3)
        sql.Append("','" & Supervisor)
        sql.Append("','" & DateEntered)
        sql.Append("','0")
        sql.Append("','" & StartPage & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Dim cmd As New SqlCommand
        cmd.CommandText = sql.ToString
        cmd.Parameters.Clear()
        'cmd.Parameters.AddWithValue("@File1", fileContent)
        'cmd.Parameters.AddWithValue("@File2", fileContent1)
        'cmd.Parameters.AddWithValue("@File3", fileContent2)
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection

        Try
            ' Using cmd As New SqlCommand(sql.ToString, sqlConnection)
            sqlConnection.Open()
            ID = cmd.ExecuteScalar()
            ' End Using
            sqlConnection.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (ChangeManagement/Insert), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection.Dispose()
        End Try
        Return ID
    End Function
    Public Function GetApproverEmail(FormType As String)
        Dim sql As New StringBuilder
        sql.Append(" Select UserEmail, UserLogin")
        sql.Append(" From MSDH_Forms.dbo.FormAuth")
        sql.Append(" where FormType = '" & FormType & "'")
        'sql.Append(" order by person_first_name")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("Your Request to retrieve Approver Email/Login did not get submitted there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetAuthEmail(UserLogin As String)
        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From MSDH_Forms.dbo.FormAuth")
        sql.Append(" where UserLogin = '" & UserLogin & "'")
        'sql.Append(" order by person_first_name")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("Your Request to retrieve Auth Email/Login did not get submitted there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetFormUser(UserLogin As String, FormType As String)
        Dim sql As New StringBuilder
        sql.Append(" Select FormType, UserEmail, PageName, FormName ")
        sql.Append(" From MSDH_Forms.dbo.FormAuth")
        If UserLogin <> "" Then
            sql.Append(" where UserLogin = '" & UserLogin & "'")
        Else
            sql.Append(" where FormType = '" & FormType & "'")
        End If
        'sql.Append(" order by person_first_name")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (FormMaster/GetFormUser), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetFormTypes()
        Dim sql As New StringBuilder
        sql.Append(" Select FormType, FormName, PageName ")
        sql.Append(" From MSDH_Forms.dbo.FormTypes")
        sql.Append(" where Inactive = 0")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("Your Select of FormTypes table did not get submitted there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetSiteDesc(ID As Integer, AdminPerson As String)
        Dim sql As New StringBuilder
        sql.Append(" Select SiteID, SiteName, MenuName,SiteDescription ")
        sql.Append(" From MSDH_Forms.dbo.MSDHSitesDescription")
        If ID > 0 Then
            sql.Append(" where SiteID = '" & ID & "'")
        ElseIf AdminPerson = "yes" Then
            sql.Append(" where SiteType = 'A' or  SiteType = 'F'")
        Else
            sql.Append(" where SiteType = 'F'")
        End If
        'sql.Append(" where SiteDescription = '" & FormType & "'")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("FormMaster/GetSiteDesc table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetResponse(pin As String, CalWeek As String, FormType As String)
        Dim sql As New StringBuilder
        sql.Append(" Select Response ")
        sql.Append(" From MSDH_Forms.dbo.TimeStudyResponse a")
        sql.Append(" left join MSDH_Forms.dbo.TimeStudyEmmployeeInfo b on a.PIN = b.PIN")
        sql.Append(" where a.PIN = '")
        sql.Append(pin & "'")
        sql.Append(" and b.FormType = '")
        sql.Append(FormType & "'")
        If CalWeek <> "" Then
            sql.Append(" and a.CalenderWeek = '")
            sql.Append(CalWeek & "'")
        End If
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("constr1").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to read TimeStudyResponse in TimeStudySheet did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetMasterUsers(UserName As String)
        Dim sql As New StringBuilder
        'sql.Append(" Select FormType, FormName, PageName ")
        'sql.Append(" From MSDH_Forms.dbo.MSDHMasterUsers")
        'sql.Append(" where MasterUsers = '" & Tonye.Lasseter & "'")

        sql.Append(" SELECT a.MasterUsers,a.StartSite,c.SiteName,c.SiteDescription,c.MenuName,c.SiteType ")
        sql.Append(" FROM [MSDH_Forms].[dbo].[MSDHMasterUsers] a")
        sql.Append(" inner Join MSDH_Forms.dbo.MSDHAllowedSites b on a.ClientID = b.ClientID")
        sql.Append(" inner Join MSDH_Forms.dbo.MSDHSitesDescription c on c.SiteID = b.SiteID")
        sql.Append(" where MasterUsers = '" & UserName & "' and c.Inactive=0")
        sql.Append(" order by c.SiteType ")

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("FormMaster/GetMasterUsers Table was not read there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetMasterUserAdmin()
        Dim sql As New StringBuilder
        sql.Append(" SELECT ClientID, MasterUsers ")
        sql.Append(" FROM MSDH_Forms.dbo.MSDHMasterUsers")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("MasterUsers Table was not read there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetTimeDetail(Login As String)
        Dim sql As New StringBuilder
        sql.Append(" Select SupervisorName")
        sql.Append(" From MSDH_Forms.dbo.TimeStudyDetail")
        sql.Append(" where SupervisorName = '")
        sql.Append(Login & "@msdh.ms.gov'")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to read TimeStudyDetail in TimeStudyForm did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetTSDetail(PIN As String)
        Dim sql As New StringBuilder
        sql.Append("Select a.APPROVED ")
        sql.Append(" From MSDH_Forms.dbo.TimeStudyDetail a ")
        sql.Append(" Left Join MSDH_Forms.dbo.TimeStudyEmmployeeInfo b on a.PIN = b.PIN ")
        sql.Append(" where a.PIN = '")
        sql.Append(PIN & "' and b.FormType='TS' and APPROVED='Yes'")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to read TimeStudyDetail in TimeStudyForm did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetLeaveSupervisor(Email As String)
        Dim sql As New StringBuilder
        sql.Append(" Select Top 1 Supervisor")
        sql.Append(" From MSDH_Forms.dbo.TimeOffPersonelRecord")
        sql.Append(" where Supervisor = '")
        sql.Append(Email & "'")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to read TimeOffPersonelRecord in Request For Leave did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetSignature(SQLConn As String)
        Dim sql As New StringBuilder
        sql.Append(" Select replace (email, '''', '') as email")
        sql.Append(" From MSDH_Forms.dbo.AD_INFO")
        sql.Append(" where email <> '' and email IS NOT NULL and email <> 'NULL'")
        sql.Append(" order by email ")
        Dim sqlConnection1 As New SqlConnection(SQLConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request To build Approval Person In RequestFormn did Not Get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetEmpInfo(UserLogin As String, PID As String, PIN As String)
        Dim sql As New StringBuilder

        sql.Append(" SELECT person_last_name, person_first_name, person_middle_name, pin_win_nmbr,org_code,location,pid_nmbr ")
        sql.Append(" FROM MSDH_Forms.dbo.AD_INFO")
        If PID <> "" And PIN <> "" Then
            sql.Append(" where pid_nmbr  = '" & PID & "' and pin_win_nmbr= '" & PIN & "'")
        Else
            sql.Append(" where Login_name = '" & UserLogin & "'")
        End If
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("AD_INFO Table was not read there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function
    Public Function GetFoodForm1(RecordId As Integer, SqlConn As String)
        Dim sql As New StringBuilder

        sql.Append(" SELECT *")
        sql.Append(" FROM MSDH_Forms.dbo.FoodForm a")
        sql.Append(" inner join FoodFormDetail b on a.RecordID = b.FoodID")
        sql.Append(" where a.recordID = '" & RecordId & "'")

        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("FoodForm Table was not read there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function
    Public Function GetFoodForm(RecordId As Integer, SqlConn As String)
        Dim sql As New StringBuilder

        sql.Append(" SELECT * ")
        sql.Append(" FROM MSDH_Forms.dbo.FoodForm a")
        sql.Append(" inner join FoodFormDetail b on a.RecordID = b.FoodID")
        sql.Append(" where a.recordID = '" & RecordId & "'")

        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("FoodForm Table was not read there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetFoodFormDeclineNotice(FoodID As Integer, SqlConn As String)
        Dim sql As New StringBuilder

        sql.Append(" SELECT * ")
        sql.Append(" FROM MSDH_Forms.dbo.DeclineNotice")
        sql.Append(" where FoodID = " & FoodID)

        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New ApplicationException("FoodForm Table was not read there was an ERROR!!!, error discription => ", ex)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function SendEmailPA(link As String, RecordID As String, type As String, SqlConn As String)
        Dim con As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand("sp_PurchaseNotification")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        'Dim param3 As SqlParameter
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        param = cmd.CreateParameter()
        param.ParameterName = "@Link"
        param.Value = link
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@formid"
        param1.Value = type
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@recordid"
        param2.Value = RecordID
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

        'param3 = cmd.CreateParameter()
        'param3.ParameterName = "@UserName"
        'param3.Value = Session("UserName")
        'param3.SqlDbType = SqlDbType.VarChar
        'cmd.Parameters.Add(param3)

        Dim dataReader As SqlDataReader = Nothing
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
        Catch ex As Exception
            Throw New Exception("Purchase/Form was Not submitted there was an ERROR!!!!. error           discription => " & ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Nothing
    End Function


    Public Function SendEmail(Link As String, RecordID As String, type As String, SqlConn As String)
        Dim con As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand("sp_FoodNotification")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure

        param = cmd.CreateParameter()
        param.ParameterName = "@Link"
        param.Value = Link
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@formid"
        param1.Value = type
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@recordid"
        param2.Value = RecordID
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)
        Dim dataReader As SqlDataReader = Nothing
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
        Catch ex As Exception
            Throw New Exception("FoodForm/SendEmail was Not submitted there was an ERROR!!!!. error           discription => " & ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Nothing
    End Function



    Public Function SendLeaveEmail(Link As String, RecordID As String, FormID As String, PID As String, PIN As String)
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("sp_LeaveNotification")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        Dim param3 As SqlParameter

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure

        param = cmd.CreateParameter()
        param.ParameterName = "@Link"
        param.Value = Link
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param = cmd.CreateParameter()
        param.ParameterName = "@formid"
        param.Value = FormID
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@recordid"
        param1.Value = RecordID
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@PID"
        param2.Value = PID
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

        param3 = cmd.CreateParameter()
        param3.ParameterName = "@PIN"
        param3.Value = PIN
        param3.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param3)

        Dim dataReader As SqlDataReader = Nothing
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
        Catch ex As Exception
            Throw New Exception("RequestForm/SendEmail was Not submitted there was an ERROR!!!!. error discription => " & ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function InsertSiteDesc(SiteName As String, SiteDescription As String, MenuName As String, SiteType As String)
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("sp_SiteDescriptions")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        Dim param3 As SqlParameter
        Dim param4 As SqlParameter
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        param = cmd.CreateParameter()
        param.ParameterName = "@SiteName"
        param.Value = SiteName
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@SiteDesc"
        param1.Value = SiteDescription
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@MenuName"
        param2.Value = MenuName
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

        param3 = cmd.CreateParameter()
        param3.ParameterName = "@SiteType"
        param3.Value = SiteType
        param3.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param3)

        param4 = cmd.CreateParameter()
        param4.ParameterName = "@Success"
        param4.Direction = ParameterDirection.Output
        param4.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param4)

        Dim dataReader As SqlDataReader = Nothing
        Dim Success As String
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
            Success = param4.Value
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Success
    End Function

    Public Function InsertMasterUsers(Username As String)
        Dim ID As Integer
        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO MSDHMasterUsers (MasterUsers, StartSite)")
        sql.Append("  VALUES(")
        sql.Append("'" & Username)
        sql.Append("','RequestForm.aspx') ; Select Scope_Identity()")

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("FormMaster/InsertMasterUsers, Request did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function


    Public Function InsertAllowedSites(ClientID As String, SiteID As String, SiteName As String)
        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO MSDHAllowedSites (clientID,siteID,SiteName)")
        sql.Append("  VALUES(")
        sql.Append("'" & ClientID)
        sql.Append("','" & SiteID)
        sql.Append("','" & SiteName & "')")
        ' sql.Append("'RequestForm.aspx') ; Select Scope_Identity()")

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("FormMaster/InsertAllowedSies, Request did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function LoadData(RecordID As Integer)
        Dim sql As New StringBuilder

        sql.Append(" Select SSNLast4,FirstName,LastName,UserLogin,JobTitle,WIN,PIN, BUS_TEMP,UNIT,LocationRoom,PhoneNumber,ComputerAccess,Telecommunication,Pagertelephone,IDBadge")
        sql.Append(",NewEmployee,CurrentEmployee,TerminateEmployee,actionAdd,actionChange,actionDelete,EffectiveDate,ContractEmployeeTerminationDate")
        sql.Append(",orgCode,Actv,Rptg,UnitSecurityContact,Justification, ClinicLocation, PersonNumber, HIPAATraning, ComputerForm, SPAHRS_HR")
        sql.Append(",TelephoneService,LongDistanceAuthorization,EmployeeClass,PictureName,PitctureNumber")
        sql.Append(",Officedoor1,Date,Notes,TimesFrames,TimeFramesNotes,ResponseNotes,RequestersEmail,NETWORK, ApplicationNumberLogin, Justification_24_7")
        sql.Append(" From MSDH_Forms.dbo.Form907 ")
        sql.Append(" where RecordID=" & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("RequestForm/LoadData ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetFormEmail()

        Dim sql1 As New StringBuilder
        sql1.Append(" Select Email")
        sql1.Append(" From MSDH_Forms.dbo.FormEmails")
        sql1.Append(" order by email ")
        Dim sqlConnection2 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd1 As New SqlCommand(sql1.ToString, sqlConnection2)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim ds1 As New DataSet
        Try
            da1.Fill(ds1, "info1")
        Catch ex As Exception
            Throw New Exception("Your Request to build Form Emails Approval Person in RequestFormn did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection2.Close()
            sqlConnection2.Dispose()
        End Try
        Return ds1
    End Function

    Public Function LoadTravel(RecordID As Integer)
        Dim sql As New StringBuilder
        sql.Append(" Select *")
        'sql.Append(",NewEmployee,CurrentEmployee,TerminateEmployee,actionAdd,actionChange,actionDelete,EffectiveDate,ContractEmployeeTerminationDate")
        'sql.Append(",orgCode,Actv,Rptg,UnitSecurityContact,Justification,Pagertype,PagerNumber,PagerLocalArea,PagerStateWide,PageWideArea,Converage,Coverage2")
        'sql.Append(",ToneVibrateDisplay,tonevoice,Messaging,TelephoneService,LongDistanceAuthorization,ChargeCallingCard,EmployeeClass,PictureName,PitctureNumber")
        'sql.Append(",Officedoor1,Officedoor2,Officedoor3,HealthInformatics,Date,Notes,TimesFrames,TimeFramesNotes,ResponseNotes,RequestersEmail")
        sql.Append(" From MSDH_Forms.dbo.TravelTraining ")
        sql.Append(" where RecordID=" & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Travel-Training/LoadTravel ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function CheckAllowSites(UserLogin As String, AdminPerson As String)
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim sql As New StringBuilder
        sql.Append(" Select SiteID, SiteName From [MSDH_Forms].[dbo].[MSDHSitesDescription]")
        sql.Append(" Where SiteID  Not In ")
        sql.Append("(select siteID  From [MSDH_Forms].[dbo].[MSDHAllowedSites] a ")
        sql.Append("  Join [MSDH_Forms].[dbo].[MSDHMasterUsers] b on a.clientID  = b.ClientID ")
        sql.Append("  Where b.MasterUsers = '")
        sql.Append(UserLogin & "')")
        If AdminPerson = "no" Then
            sql.Append(" And SiteType = 'F'")
        End If

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("CheckAllowSites ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try

        sql.Clear()
        sql.Append(" Select ClientID From MSDH_Forms.dbo.MSDHMasterUsers")
        sql.Append("  Where MasterUsers = '" & UserLogin & "'")

        Dim sqlConnection2 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd1 As New SqlCommand(sql.ToString, sqlConnection2)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim ds1 As New DataSet
        Try
            da1.Fill(ds1, "info1")
            sqlConnection2.Close()
        Catch ex As Exception
            Throw New Exception("CheckAllowSites 1 ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection2.Dispose()
        End Try


        For y = 1 To ds.Tables(0).Rows.Count
            Dim sqlConnection3 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
            sql.Clear()
            sql.Append(" INSERT INTO MSDHAllowedSites (clientID,siteID,SiteName)")
            sql.Append("  VALUES(")
            sql.Append("'" & ds1.Tables("Info1").Rows(0)("ClientID").ToString)
            sql.Append("','" & ds.Tables("Info").Rows(y - 1)("SiteID").ToString)
            sql.Append("','" & ds.Tables("Info").Rows(y - 1)("SiteName").ToString & "')")
            Try
                Using cmd2 As New SqlCommand(sql.ToString, sqlConnection3)
                    sqlConnection3.Open()
                    cmd2.ExecuteScalar()
                End Using
                sqlConnection3.Close()
            Catch ex As Exception
                Throw New Exception("FormMaster/InsertAllowedSies, Request did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
            Finally
                sqlConnection3.Dispose()
            End Try
        Next

        Return Nothing


        'Dim cmd As New SqlCommand("sp_InsertAllowedSites")
        'Dim param As SqlParameter
        'Dim param1 As SqlParameter

        'cmd.Connection = con
        'cmd.CommandType = CommandType.StoredProcedure
        'param = cmd.CreateParameter()
        'param.ParameterName = "@UserLogin"
        'param.Value = UserLogin
        'param.SqlDbType = SqlDbType.VarChar
        'cmd.Parameters.Add(param)

        'param1 = cmd.CreateParameter()
        'param1.ParameterName = "@AdminPerson"
        'param1.Value = AdminPerson
        'param1.SqlDbType = SqlDbType.VarChar
        'cmd.Parameters.Add(param1)

        'param1 = cmd.CreateParameter()
        'param1.ParameterName = "@Success"
        'param1.Direction = ParameterDirection.Output
        'param1.SqlDbType = SqlDbType.Int
        'cmd.Parameters.Add(param1)

        'Dim dataReader As SqlDataReader = Nothing
        '' Dim Success As Integer
        'Try
        '    con.Open()
        '    dataReader = cmd.ExecuteReader()
        '    'Success = param1.Value
        'Catch ex As Exception
        '    Throw New Exception("AllowSites (CheckAllowSites) build did not get inserted there was an ERROR!!!, error discription => " & ex.Message)
        'Finally
        '    con.Close()
        '    con.Dispose()
        'End Try
        'Return Nothing ' Success
    End Function

    '************** REQUEST FOR LEAVE **************

    Public Function InsertPersonlRecord(PID As String, PIN As String, Supervisor As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO TimeOffPersonelRecord (PID,PIN,Supervisor)")
        sql.Append("  VALUES(")
        sql.Append("'" & PID)
        sql.Append("','" & PIN)
        sql.Append("','" & Supervisor & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection)
                sqlConnection.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection.Close()
        Catch ex As Exception
            Throw New Exception("Your RequestForLeave/Insert), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertOffDuty(recordID As Integer, BeginningDate As String, BegginningTime As String, EndingDate As String, EndingTime As String, EmployeeElectSignature As String _
                                  , EmployeeElectDate As String, ApprovalStatus As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO TimeOffDuty (recordID,BegginingDate,Begginingtime,EndingDate,Endingtime,EmployeeElectronicSignature,EmployeeElectronicDate,ApprovalStatus)")
        sql.Append("  VALUES(")
        sql.Append("'" & recordID)
        sql.Append("','" & BeginningDate)
        sql.Append("','" & BegginningTime)
        sql.Append("','" & EndingDate)
        sql.Append("','" & EndingTime)
        'If EmployeeElectSignature <> "" Then
        '    sql.Append("','Yes")
        'Else
        '    sql.Append("','" & EmployeeElectSignature)
        'End If
        sql.Append("','" & EmployeeElectSignature)
        sql.Append("','" & EmployeeElectDate)
        sql.Append("','" & ApprovalStatus & "') ; Select Scope_Identity()")

        Dim sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim ID As Integer
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection)
                sqlConnection.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection.Close()
        Catch ex As Exception
            Throw New Exception("Your Request For Leave OffDuty/Insert), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertLeaveTaken(recordID As Integer, TypeOffDutyID As Integer, TypeOfLeaveTaken As String, ReasonCode As String, AmountTaken As String)

        Dim TypeLeaveTaken = TypeOfLeaveTaken & ReasonCode
        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO TypeAndAmountOfLeaveTaken (recordID,TypeOffDutyID,TypeOfLeaveTaken,AmountTaken)")
        sql.Append("  VALUES(")
        sql.Append("'" & recordID)
        sql.Append("','" & TypeOffDutyID)
        sql.Append("','" & TypeLeaveTaken)
        sql.Append("','" & AmountTaken & "')")

        Dim sqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection)
                sqlConnection.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection.Close()
        Catch ex As Exception
            Throw New Exception("Your Request For Leave (AmountLeaveTaken/Insert), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection.Dispose()
        End Try
        Return 1
    End Function

    Public Function LoadLeave1(RecordID As Integer, TypeTaken As String, FromDate As String, ToDate As String, Year As String, Month As String)
        Dim sql As New StringBuilder
        sql.Append(" SELECT a.PersonalLeaveBalance,a.MajorMedicalBalance,a.CompensatoryLeaveBalance,b.BegginingDate , b.Begginingtime ,EndingDate ,Endingtime ,c.TypeOfLeaveTaken ,c.AmountTaken")
        sql.Append(" FROM MSDH_Forms.dbo.TimeOffPersonelRecord a")
        sql.Append(" inner join MSDH_Forms.dbo.TimeOffDuty b on a.recordID = b.recordID")
        sql.Append(" inner join MSDH_Forms.dbo.TypeAndAmountOfLeaveTaken c on b.TimeOffDutyID = c.TimeOffDutyID")
        sql.Append(" where a.recordID = '" & RecordID & "' and left(c.TypeOfLeaveTaken,2)='" & TypeTaken & "'")
        If FromDate <> "" And ToDate <> "" Then
            sql.Append(" and b.BegginingDate between '" & FromDate & "' and '" & ToDate & "'")
        End If
        If Year <> "" Then
            sql.Append(" and Year(b.BegginingDate) = '" & Year & "'")
        End If
        If Month <> "" Then
            sql.Append(" and Month(b.BegginingDate) = '" & Month & "'")
        End If
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "LoadLeave")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("TimeOffPersonelRecord (LoadLeave1) Table was not read there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function LoadLeave(PID As String, PIN As String, recordID As Integer)
        ' Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        ' Dim con As New SqlConnection(sqlConnection1)
        Dim cmd As New SqlCommand("sp_GetRequestForLeave")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        param = cmd.CreateParameter()
        param.ParameterName = "@PID"
        param.Value = PID
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@PIN"
        param1.Value = PIN
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@recordID"
        param2.Value = recordID
        param2.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param2)

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "LoadLeave")
            con.Close()
        Catch ex As Exception
            Throw New ApplicationException("Your Request to retrieve Approver Email did not get submitted there was an ERROR!!!, error discription => ", ex)
        Finally
            con.Dispose()
        End Try
        Return ds
    End Function

    Public Function InsertTimePersonalLeave(PID As String, PIN As String, Supervisor As String)
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("sp_InsertTimeOffPersonalRecord")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        Dim param3 As SqlParameter

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        param = cmd.CreateParameter()
        param.ParameterName = "@PID"
        param.Value = PID
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@PIN"
        param1.Value = PIN
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@Supervisor"
        param2.Value = Supervisor
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

        param3 = cmd.CreateParameter()
        param3.ParameterName = "@ID"
        param3.Direction = ParameterDirection.Output
        param3.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param3)

        Dim dataReader As SqlDataReader = Nothing
        Dim ID As Integer
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
            ID = param3.Value

        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertLeave(recordID As Integer, BeginningDate As String, BeginningTime As String, EndingDate As String _
                                , EndingTime As String, EmpElectSign As String, EmpElectDate As String, ApprovalStatus As String, TypeOfLeaveTaken As String _
                                , AmountTaken As String)
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("sp_InsertRequestForLeave")
        Dim param2 As SqlParameter
        Dim param3 As SqlParameter
        Dim param4 As SqlParameter
        Dim param5 As SqlParameter
        Dim param6 As SqlParameter
        Dim param7 As SqlParameter
        Dim param8 As SqlParameter
        Dim param9 As SqlParameter
        Dim param10 As SqlParameter
        Dim param11 As SqlParameter
        Dim param12 As SqlParameter

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@ID"
        param2.Value = recordID
        param2.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param2)

        param3 = cmd.CreateParameter()
        param3.ParameterName = "@BeginningDate"
        param3.Value = BeginningDate
        param3.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param3)

        param4 = cmd.CreateParameter()
        param4.ParameterName = "@BeginningTime"
        param4.Value = BeginningTime
        param4.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param4)

        param5 = cmd.CreateParameter()
        param5.ParameterName = "@EndingDate"
        param5.Value = EndingDate
        param5.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param5)

        param6 = cmd.CreateParameter()
        param6.ParameterName = "@EndingTime"
        param6.Value = EndingTime
        param6.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param6)

        param7 = cmd.CreateParameter()
        param7.ParameterName = "@EmpElectSignature"
        param7.Value = EmpElectSign
        param7.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param7)

        param8 = cmd.CreateParameter()
        param8.ParameterName = "@EmpElectDate"
        param8.Value = EmpElectDate
        param8.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param8)

        param9 = cmd.CreateParameter()
        param9.ParameterName = "@ApprovalStatus"
        param9.Value = ApprovalStatus
        param9.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param9)

        param10 = cmd.CreateParameter()
        param10.ParameterName = "@TypeOfLeaveTaken"
        param10.Value = TypeOfLeaveTaken
        param10.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param10)

        param11 = cmd.CreateParameter()
        param11.ParameterName = "@AmountTaken"
        param11.Value = AmountTaken
        param11.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param11)

        param12 = cmd.CreateParameter()
        param12.ParameterName = "@Success"
        param12.Direction = ParameterDirection.Output
        param12.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param12)

        Dim dataReader As SqlDataReader = Nothing
        Dim Success As String
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
            Success = param12.Value
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Success
    End Function

    Public Function UpdateLeave(TimeOffDutyID As String, recordID As String, BeginningTime As String, BeginningDate As String, EndingTime As String, EndingDate As String _
                                , TypeOfLeave As String, HoursTaken As String, Status As String)


        ' Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        ' Dim con As New SqlConnection(sqlConnection1)
        Dim cmd As New SqlCommand("sp_UpdateRequestForLeave")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        Dim param3 As SqlParameter
        Dim param4 As SqlParameter
        Dim param5 As SqlParameter
        ' Dim param6 As SqlParameter
        'Dim param7 As SqlParameter
        Dim param10 As SqlParameter
        Dim param11 As SqlParameter
        Dim param12 As SqlParameter
        Dim param13 As SqlParameter

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        param = cmd.CreateParameter()
        param.ParameterName = "@TimeOffDutyID"
        param.Value = TimeOffDutyID
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@recordID"
        param1.Value = recordID
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@BeginningTime"
        param2.Value = BeginningTime
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

        param3 = cmd.CreateParameter()
        param3.ParameterName = "@BeginningDate"
        param3.Value = BeginningDate
        param3.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param3)

        param4 = cmd.CreateParameter()
        param4.ParameterName = "@EndingTime"
        param4.Value = EndingTime
        param4.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param4)

        param5 = cmd.CreateParameter()
        param5.ParameterName = "@EndingDate"
        param5.Value = EndingDate
        param5.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param5)

        'param6 = cmd.CreateParameter()
        'param6.ParameterName = "@SupervisorApproval"
        'param6.Value = SupervisorApproval
        'param6.SqlDbType = SqlDbType.VarChar
        'cmd.Parameters.Add(param6)

        'param7 = cmd.CreateParameter()
        'param7.ParameterName = "@SupervisorApprovalDate"
        'param7.Value = SupervisorApprovalDate
        'param7.SqlDbType = SqlDbType.VarChar
        'cmd.Parameters.Add(param7)

        param10 = cmd.CreateParameter()
        param10.ParameterName = "@TypeOfLeave"
        param10.Value = TypeOfLeave
        param10.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param10)

        param11 = cmd.CreateParameter()
        param11.ParameterName = "@AmountTaken"
        param11.Value = HoursTaken
        param11.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param11)

        param12 = cmd.CreateParameter()
        param12.ParameterName = "@ApprovalStatus"
        param12.Value = Status
        param12.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param12)

        param13 = cmd.CreateParameter()
        param13.ParameterName = "@Success"
        param13.Direction = ParameterDirection.Output
        param13.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param13)


        Dim dataReader As SqlDataReader = Nothing
        Dim Success As String
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
            Success = param13.Value
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Success
    End Function

    Public Function UpdateLeaveRespStatus(Response As String, recordID As String, Status As String, Email As String)
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand("sp_UpdateLeaveRespStatus")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        Dim param3 As SqlParameter
        Dim param4 As SqlParameter
        Dim param5 As SqlParameter
        Dim SupvDate As String
        If Status = "Approved" Then
            SupvDate = Today()
        Else
            SupvDate = ""
        End If

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        param = cmd.CreateParameter()
        param.ParameterName = "@ResponseNotes"
        param.Value = Response
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@recordID"
        param1.Value = recordID
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@ApprovalStatus"
        param2.Value = Status
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

        param3 = cmd.CreateParameter()
        param3.ParameterName = "@SupervisorSign"
        param3.Value = Email
        param3.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param3)

        param4 = cmd.CreateParameter()
        param4.ParameterName = "@SupervisorDate"
        param4.Value = SupvDate
        param4.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param4)

        param5 = cmd.CreateParameter()
        param5.ParameterName = "@Success"
        param5.Direction = ParameterDirection.Output
        param5.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param5)


        Dim dataReader As SqlDataReader = Nothing
        Dim Success As String
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
            Success = param3.Value
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Success
    End Function

    Public Function UpdateTimeKeeper(TimeKeeper As String, recordID As String)
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand("sp_UpdateTimeKeeper")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        param = cmd.CreateParameter()
        param.ParameterName = "@TimeKeeper"
        param.Value = TimeKeeper
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@recordID"
        param1.Value = recordID
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@Success"
        param2.Direction = ParameterDirection.Output
        param2.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param2)

        Dim dataReader As SqlDataReader = Nothing
        Dim Success As String
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
            Success = param2.Value
        Catch ex As Exception
            Throw ex
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Success
    End Function

    Public Function UpdateLeaveCompDate(recordID As Integer, CompDate As String)
        ' Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        ' Dim con As New SqlConnection(sqlConnection1)
        Dim cmd As New SqlCommand("sp_UpdateCompletedDate")
        Dim param As SqlParameter
        Dim param1 As SqlParameter

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure

        param = cmd.CreateParameter()
        param.ParameterName = "@recordID"
        param.Value = recordID
        param.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@CompletedDate"
        param1.Value = CompDate
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            con.Close()
        Catch ex As Exception
            Throw New Exception("Your Request to update Completed Date did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            con.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetLeaveName(TimeKeeper As String, RecordID As String, FromDate As String, ToDate As String, Year As String, Month As String)
        Dim sql As New StringBuilder

        ' Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        ' Dim con As New SqlConnection(sqlConnection1)
        Dim cmd As New SqlCommand("sp_GetLeaveNames")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        Dim param3 As SqlParameter
        Dim param4 As SqlParameter
        Dim param5 As SqlParameter
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure

        param = cmd.CreateParameter()
        param.ParameterName = "@TimeKeeper"
        param.Value = TimeKeeper
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@recordID"
        param1.Value = RecordID
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@FromDate"
        param2.Value = FromDate
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

        param3 = cmd.CreateParameter()
        param3.ParameterName = "@ToDate"
        param3.Value = ToDate
        param3.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param3)

        param4 = cmd.CreateParameter()
        param4.ParameterName = "@Year"
        param4.Value = Year
        param4.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param4)

        param5 = cmd.CreateParameter()
        param5.ParameterName = "@Month"
        param5.Value = Month
        param5.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param5)

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            con.Close()
        Catch ex As Exception
            Throw New Exception("Your Request to Select TimeKeeper Data in GetLeaveName, did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            con.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetLeaveResp(RecordID As Integer)
        Dim sql As New StringBuilder
        sql.Append(" Select ResponseNotes")
        sql.Append(" From MSDH_Forms.dbo.TimeOffPersonelRecord")
        sql.Append(" where recordID = ")
        sql.Append(RecordID)
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to read TimeOffPersonelRecord in Request For Leave did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function


    ' ********** CHANGE MANAGEMENT ************
    Public Function LoadChangeMgmt(recordID As Integer)
        ' Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        ' Dim con As New SqlConnection(sqlConnection1)
        Dim cmd As New SqlCommand("sp_GetChangeManagement")
        Dim param As SqlParameter
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure

        param = cmd.CreateParameter()
        param.ParameterName = "@recordID"
        param.Value = recordID
        param.SqlDbType = SqlDbType.Int
        cmd.Parameters.Add(param)

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "LoadCM")
            con.Close()
        Catch ex As Exception
            Throw New ApplicationException("Your Request to retrieve Change Management did not get submitted there was an ERROR!!!, error discription => ", ex)
        Finally
            con.Dispose()
        End Try
        Return ds
    End Function


    Public Function UpdateChangeManagement(NameOfApplicationOrDatabase As String, ProgramArea As String, RequestorName As String, RequestorPhoneNumber As String _
                                           , RequestorEmail As String, VendorContactName As String, VendorPhoneNumber As String, VendorEmail As String _
                                           , DescriptionOfUpdate As String, ChangeComponents As String, SpecialInstructions As String, ReasonForChange As String _
                                           , EnvironmentAffected As String, EnvironmentComments As String, DatabaseRefreshYesNo As String, DatabaseToBeRefreshed As String _
                                           , DateRequested As String, IdealTime As String, ResourceChangeYesNo As String, RecordID As Integer, Link As String _
                                           , bytes1 As Byte(), bytes2 As Byte(), bytes3 As Byte(), filename1 As String, filename2 As String, filename3 As String, Status As String)
        Dim sql As New StringBuilder
        sql.Append("Update MSDH_Forms.dbo.ChangeManagement ")
        sql.Append(" SET NameOfApplicationOrDatabase = '" & NameOfApplicationOrDatabase & "',ProgramArea = '" & ProgramArea & "',RequestorName = '" & RequestorName & "'")
        sql.Append(",RequestorPhoneNumber='" & RequestorPhoneNumber & "',RequestorEmail='" & RequestorEmail & "',VendorContactName='" & VendorContactName & "'")
        sql.Append(",VendorPhoneNumber='" & VendorPhoneNumber & "',VendorEmail='" & VendorEmail & "',DescriptionOfUpdate='" & DescriptionOfUpdate & "'")
        sql.Append(",ChangeComponents = '" & ChangeComponents & "',SpecialInstructions = '" & SpecialInstructions & "',ReasonForChange = '" & ReasonForChange & "'")
        sql.Append(",EnvironmentAffected = '" & EnvironmentAffected & "',EnvironmentComments = '" & EnvironmentComments & "',DatabaseRefreshYesNo = '" & DatabaseRefreshYesNo & "'")
        sql.Append(",DatabaseToBeRefreshed='" & DatabaseToBeRefreshed & "',DateRequested='" & DateRequested & "',IdealTime='" & IdealTime & "'")
        sql.Append(",ResourceChangeYesNo='" & ResourceChangeYesNo & "'")
        sql.Append(", StartPage= '" & Link & "'")


        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        If filename1 <> "" Then
            sql.Append(", AdditionalFiles1=@File1")
            sql.Append(", FileName1= '" & filename1 & "'")
            cmd.Parameters.Add("@File1", SqlDbType.Binary).Value = bytes1
        End If
        If filename2 <> "" Then
            sql.Append(", AdditionalFiles2=@File2")
            sql.Append(", FileName2= '" & filename2 & "'")
            cmd.Parameters.Add("@File2", SqlDbType.Binary).Value = bytes2
        End If
        If filename3 <> "" Then
            sql.Append(", AdditionalFiles3=@File3")
            sql.Append(", FileName3= '" & filename3 & "'")
            cmd.Parameters.Add("@File3", SqlDbType.Binary).Value = bytes3
        End If
        If Status <> "" Then
            sql.Append(", ApprovalStatus= '" & Status & "'")
        End If
        sql.Append(" Where RecordID = " & RecordID)

        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Updated Request, (UpdateChangeManagement / btnSubmit_Click), did Not Get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing

    End Function

    Public Function UpdateApprovedDecline(Link As String, RecordID As Integer, Status As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.ChangeManagement ")
        sql.Append(" SET StartPage = '" & Link & "'")
        If Status = "Approved" Then
            sql.Append(", DateApproved = '" & Today() & "'")
        End If
        sql.Append(", ApprovalStatus = '" & Status & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (ChangeManagement/UpdateApprovedDecline), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function GetCMResponse(RecordID As String)
        Dim sql As New StringBuilder
        sql.Append(" Select RecordID, ResponseNotes ")
        sql.Append(" From MSDH_Forms.dbo.ChangeManagementResponse")
        sql.Append(" where ChangeMgntID = ")
        sql.Append(RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Select of ChangeManagementResponse table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetCMSupervisor(Email As String)
        Dim sql As New StringBuilder
        sql.Append(" Select Top 1 SupervisorEmail")
        sql.Append(" From MSDH_Forms.dbo.ChangeManagement")
        sql.Append(" where SupervisorEmail = '")
        sql.Append(Email & "'")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to read ChangeManagement(GetCMSupervisor) table did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function Get907Supervisor(Email As String)
        Dim sql As New StringBuilder
        sql.Append(" Select Top 1 UnitSecurityContact")
        sql.Append(" From MSDH_Forms.dbo.Form907")
        sql.Append(" where UnitSecurityContact = '")
        sql.Append(Email & "'")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to read Form907(Get907Supervisor) table did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function
    Public Function UpdateDeclineNotice(FoodID As Integer, DeclineNotice As String, SQLconn As String)
        Dim sql As New StringBuilder
        sql.Append(" UPDATE MSDH_Forms.dbo.DeclineNotice ")
        sql.Append(" SET DeclineNotice = '" & DeclineNotice & "'")
        sql.Append(" Where FoodID = " & FoodID)
        Dim sqlConnection1 As New SqlConnection(SQLconn)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (ChangeUpdateApprovedDecline), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function UpdateFoodForm(Recordid As Integer, ApproveSignature As String, SQLconn As String)
        Dim sql As New StringBuilder
        sql.Append(" UPDATE MSDH_Forms.dbo.FoodForm ")
        sql.Append(" SET ApproveSignature = '" & ApproveSignature & "'")
        sql.Append(" Where Recordid = " & Recordid)
        Dim sqlConnection1 As New SqlConnection(SQLconn)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (ChangeUpdateApprovedDecline), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function GetBillType(SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append(" select * FROM PaymentTypeBill ")
        sql.Append(" order by BillName ")
        'sql.Append(" where Inactive = 0 ")
        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request get PaymentTypeBill/GetBillType did Not Get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try

        Return ds
    End Function

    Public Function GetDonorLeaveList(EmailAddress As String, SqlConn As String)

        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From  DonorLeave")
        sql.Append(" where (ApprovalPerson = '" & EmailAddress & "' and ApprovalPersonSignature is null and ApprovalSignDate is null)")
        sql.Append(" or  (RegionalAdminOffDir = '" & EmailAddress & "' and RegionalAdminOffDirSignature is null and RegionalAdminOffDirSignDate is null)")
        sql.Append(" or  (DonorOffMgrLeaveKeeper = '" & EmailAddress & "' and DonorOffMgrLeaveKeeperSignature is null and DonorOffMgrLeaveKeeperSignDate is null)")
        sql.Append(" or  (OfficeOfHR = '" & EmailAddress & "' and OfficeOfHRSignature is null and OfficeOfHRSignDate is null)")
        sql.Append(" and Inactive=0 ")
        sql.Append(" order by CreateDate ")


        Dim sqlConnection2 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection2)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to build Form DonorLeave/GetDonorLeave did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection2.Close()
            sqlConnection2.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetInventory(UserName As String, SQLConn As String)
        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From  MSDH_Forms.dbo.FormAuth")
        sql.Append(" where UserLogin = '" & UserName & "'")
        sql.Append(" and FormType = 'InvList'")
        Dim sqlConnection1 As New SqlConnection(SQLConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request to pull FormAuth/GetInventory From FormAuth did Not Get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function UpdateCMResponse(RecordID As Integer, ResponseNotes As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.ChangeManagementResponse ")
        sql.Append(" SET ResponseNotes = '" & ResponseNotes & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        cmd.CommandText = sql.ToString
        cmd.CommandType = CommandType.Text
        cmd.Connection = sqlConnection1

        Try
            sqlConnection1.Open()
            reader = cmd.ExecuteReader()
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (ChangeManagement/UpdateApprovedDecline), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function InsertCMResponse(RecordID As Integer, ResponseNotes As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO MSDH_Forms.dbo.ChangeManagementResponse (ChangeMgntID,ResponseNotes)")
        sql.Append("  VALUES(")
        sql.Append(RecordID)
        sql.Append(",'" & ResponseNotes & "')")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim rowCount As Integer

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Insert into ChangeManagementResponse did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return rowCount
    End Function

    ' ^^^^^^^^^^^^^^^^^^ CHANGE MANAGEMENT ^^^^^^^^^^^^^^^^^^

    Public Function GetTSEmpInfo(UserName As String, PIN As String)
        Dim sql As New StringBuilder
        sql.Append(" Select FormType ")
        sql.Append(" From MSDH_Forms.dbo.TimeStudyEmmployeeInfo")
        sql.Append(" where EmployeeName = '")
        sql.Append(UserName)
        sql.Append("' and PIN='")
        sql.Append(PIN & "'")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Select of TimeStudyEmmployeeInfo table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function
    Public Function GetLeaveSubmitted(PID As String, SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append(" Select Top 1 * ")
        sql.Append(" From TimeOffPersonelRecord a ")
        sql.Append(" Left Join TimeOffDuty b on a.recordID = b.recordid ")
        sql.Append(" Left Join TypeAndAmountOfLeaveTaken c on b.TimeOffDutyID = c.TimeOffDutyID ")
        sql.Append(" inner join MSDH_Forms.dbo.AD_INFO e on a.PID = e.pid_nmbr ")
        sql.Append(" where  a.PID = '" & PID & "'")
        ' sql.Append(" where b.ApprovalStatus != 'Approved' and a.PID = '" & PID & "'")
        Dim sqlConnection As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request TimeOffPersonelRecord/GetLeaveSubmitted did not get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection.Close()
            sqlConnection.Dispose()
        End Try
        Return ds
    End Function
    Public Function InsertTSEmpInfo(sql As String)

        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim rowCount As Integer

        Try
            Using cmd As New SqlCommand(sql, sqlConnection1)

                sqlConnection1.Open()
                rowCount = cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Insert into TimeStudyEmmployeeInfo did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return rowCount
    End Function

    '############# CONTRACTOR CONTRACT ###########
    Public Function InsertContractor(ContractorFirstName As String, ContractorLastName As String, ContractorContactPerson As String, ContractorEmail As String _
                                   , ContractorID As String, EffectedProgram As String, ContractorAddress As String, ContractorPhoneNumber As String, ContractorCity As String _
                                   , ContractorState As String, ContractorZip As String, DateEntered As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO Contract_ContractorInfo (Contractors_lastname,Contractors_firstname,Contractors_Contactperson,Contractors_ContactEmail")
        sql.Append(",ContractorID,EffectedProgram,ContractorAddress,ContractorTelephone,ContractorCity,ContractorState,ContractorZip,dateEntered)")
        sql.Append("  VALUES(")
        sql.Append("'" & ContractorLastName)
        sql.Append("','" & ContractorFirstName)
        sql.Append("','" & ContractorContactPerson)
        sql.Append("','" & ContractorEmail)
        sql.Append("','" & ContractorID)
        sql.Append("','" & EffectedProgram)
        sql.Append("','" & ContractorAddress)
        sql.Append("','" & ContractorPhoneNumber)
        sql.Append("','" & ContractorCity)
        sql.Append("','" & ContractorState)
        sql.Append("','" & ContractorZip)
        sql.Append("','" & DateEntered & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request for Contract Between Department and Contractor, (InsertContractor), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertContract(ContractID As String, ContractDesc As String, ServiceProvided As String, TotContractAmount As String, PerYearAmount As String, FeeRetainer As String, FeeRetainerBasis As String _
                                        , BegDate As String, EndDate As String, MSDHOrg1 As String, MSDHOrg2 As String, MSDHOrg3 As String, MSDHActivity As String, MSDHProj1 As String, MSDHProj2 As String, MSDHProj3 As String, MSDHProj4 As String, MSDHProj5 As String _
                                        , MSDHReportingCategory1 As String, MSDHReportingCategory2 As String, MSDHReportingCategory3 As String, MSDHReportingCategory4 As String, ckFGYes As String, ckFGNo As String, ckSFYes As String, ckSFNo As String, FederaGrantAwardNumber As String _
                                        , FederalAidNumber As String, CFDANumber As String, Occupation As String, Specialty As String, Program As String, TotalPersonnelServices As String _
                                        , TotalTravelSubstence As String, MaxHoursAuthorizedPerMonth As String, AssignedTravelBase As String, ckNone As String, MealsAuthorized As String _
                                        , MileageAuthorized As String, LodgingAuthorized As String, ckStateWide As String, ckCentralOffice As String, District As String _
                                        , AuthorizedHours As String, AuthorizedDistrict As String, ContractorCertificationLicensure As String, ContractorExperienceDegrees As String _
                                        , ckBenefitYes As String, ckBenefitNo As String, ckContractorYes As String, ckContractorNo As String, ContractedServices As String, AttachmentBConflictofInterest As String _
                                        , AttachmentCAdditionalContractTerms As String, ContractorDateofRetirement As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO Contract_ContractInfo (ContractID,ContractDescription,ServiceProvided,ContractAmount,MaxContractAmount,FeeRetainer,FeeRetainerBasis,ContractBeginDate,ContractEndDate,MSDHOrg1,MSDHOrg2,MSDHOrg3")
        sql.Append(",MSDHActivity,MSDHProject1,MSDHProject2,MSDHProject3,MSDHProject4,MSDHProject5,MSDHReportingCategory1,MSDHReportingCategory2,MSDHReportingCategory3,MSDHReportingCategory4,FederalGrant,StimulusFunds,FederaGrantAwardNumber,FederalAidNumber,CFDANumber")
        sql.Append(",Occupation,Specialty,Program,TotalPersonnelServices,TotalTravelSubstence,MaxHoursAuthorizedPerMonth,AssignedTravelBase")
        sql.Append(",MealsMileageAuthorized,MealsAuthorized,MileageAuthorized,LodgingAuthorized,AuthorizedLocation,AuthorizedHours")
        sql.Append(",AuthorizedDistrict,ContractorCertificationLicensure,ContractorExperienceDegrees,ContratorPers,IndependentContractorIndicator")
        sql.Append(",ContractedServices,AttachmentBConflictofInterest,AttachmentCAdditionalContractTerms,ContractorDateofRetirement)")
        sql.Append("  VALUES(")
        sql.Append("'" & ContractID)
        sql.Append("','" & ContractDesc)
        sql.Append("','" & ServiceProvided)
        sql.Append("','" & TotContractAmount)
        sql.Append("','" & PerYearAmount)
        sql.Append("','" & FeeRetainer)
        sql.Append("','" & FeeRetainerBasis)
        sql.Append("','" & BegDate)
        sql.Append("','" & EndDate)
        sql.Append("','" & MSDHOrg1)
        sql.Append("','" & MSDHOrg2)
        sql.Append("','" & MSDHOrg3)
        sql.Append("','" & MSDHActivity)
        sql.Append("','" & MSDHProj1)
        sql.Append("','" & MSDHProj2)
        sql.Append("','" & MSDHProj3)
        sql.Append("','" & MSDHProj4)
        sql.Append("','" & MSDHProj5)
        sql.Append("','" & MSDHReportingCategory1)
        sql.Append("','" & MSDHReportingCategory2)
        sql.Append("','" & MSDHReportingCategory3)
        sql.Append("','" & MSDHReportingCategory4)
        If ckFGYes = "on" Then
            sql.Append("','Yes'")
        ElseIf ckFGNo = "on" Then
            sql.Append("','No'")
        Else
            sql.Append("',''")
        End If
        If ckSFYes = "on" Then
            sql.Append(",'Yes'")
        ElseIf ckSFNo = "on" Then
            sql.Append(",'No'")
        Else
            sql.Append(",''")
        End If
        sql.Append(",'" & FederaGrantAwardNumber)
        sql.Append("','" & FederalAidNumber)
        sql.Append("','" & CFDANumber)
        sql.Append("','" & Occupation)
        sql.Append("','" & Specialty)
        sql.Append("','" & Program)
        sql.Append("','" & TotalPersonnelServices)
        sql.Append("','" & TotalTravelSubstence)
        sql.Append("','" & MaxHoursAuthorizedPerMonth)
        sql.Append("','" & AssignedTravelBase)
        If ckNone = "on" Then
            sql.Append("','None'")
        Else
            sql.Append("',''")
        End If
        sql.Append(",'" & MealsAuthorized)
        sql.Append("','" & MileageAuthorized)
        sql.Append("','" & LodgingAuthorized)
        If ckStateWide = "on" Then
            sql.Append("','Statewide'")
        ElseIf ckCentralOffice = "on" Then
            sql.Append("','Central Office'")
        ElseIf District <> "" Then
            sql.Append("','" & District & "'")
        Else
            sql.Append("',''")
        End If

        sql.Append(",'" & AuthorizedHours)
        sql.Append("','" & AuthorizedDistrict)
        sql.Append("','" & ContractorCertificationLicensure)
        sql.Append("','" & ContractorExperienceDegrees)
        If ckBenefitYes = "on" Then
            sql.Append("','Yes'")
        ElseIf ckBenefitNo = "on" Then
            sql.Append("','No'")
        Else
            sql.Append("',''")
        End If
        If ckContractorYes = "on" Then
            sql.Append(",'Yes'")
        ElseIf ckContractorNo = "on" Then
            sql.Append(",'No'")
        Else
            sql.Append(",''")
        End If
        sql.Append(",'" & ContractedServices)
        sql.Append("','" & AttachmentBConflictofInterest)
        sql.Append("','" & AttachmentCAdditionalContractTerms)
        sql.Append("','" & ContractorDateofRetirement & "')")

        'Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request to add Contract Info, (InsertContract), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function SendEmailFA(Link As String, FormID As String, RecordID As Integer, SqlConn As String)
        Dim strConnString As String = SqlConn
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("sp_FinanceAdminNotification")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter

        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        param = cmd.CreateParameter()
        param.ParameterName = "@Link"
        param.Value = Link
        param.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param)

        param1 = cmd.CreateParameter()
        param1.ParameterName = "@formid"
        param1.Value = FormID
        param1.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param1)

        param2 = cmd.CreateParameter()
        param2.ParameterName = "@recordID"
        param2.Value = RecordID
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

        Dim dataReader As SqlDataReader = Nothing
        Try
            con.Open()
            dataReader = cmd.ExecuteReader()
        Catch ex As Exception
            Throw New Exception("SendEmailFA was Not submitted there was an ERROR!!!!. error discription => " & ex.Message)
        Finally
            con.Close()
            con.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function GetDocument(Invoice As String, Location As String, Month As String, Year As String, SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append(" select RecordID,Filename1 FROM EntergyDocUpload ")
        sql.Append(" where TypeBill = '" & Invoice & "'")
        sql.Append(" and Location = '" & Location & "'")
        sql.Append(" and Month = '" & Month & "'")
        sql.Append(" and Year = '" & Year & "'")
        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request get EntergyDocUpload/GetDocument did Not Get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try

        Return ds
    End Function



    Public Function InsertEntergyUpload(Location As String, Month As String, Year As String, FileName1 As String, DataFile1 As Byte() _
                                , CreatedBy As String, CreateDate As String, SQLConn As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO EntergyDocUpload (Location,Month,Year,Filename1,DataFile1,CreatedBy,CreateDate)")
        sql.Append("  VALUES(")
        sql.Append("'" & Location)
        sql.Append("','" & Month)
        sql.Append("','" & Year)
        'sql.Append("','" & Amount)
        sql.Append("',@Name1")
        sql.Append(",@File1")
        sql.Append(",'" & CreatedBy)
        sql.Append("','" & CreateDate & "');Select Scope_Identity()")
        ' sql.Append("','" & TypeBill & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim con As New SqlConnection(SQLConn)
        Using cmd As New SqlCommand(sql.ToString())
            cmd.Connection = con
            cmd.Parameters.Add("@Name1", SqlDbType.VarChar).Value = FileName1
            cmd.Parameters.Add("@File1", SqlDbType.Binary).Value = DataFile1
            Try
                con.Open()
                ID = cmd.ExecuteScalar()
            Catch ex As Exception
                Throw New Exception("Your Insert into InsertEntergyUpload/EntergyDocUpload did not get added there was an ERROR!!!, error discription => " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using
        Return ID
    End Function



    Public Function GetLeaveHistory(UserName As String, PIN As String, UserName1 As String, UserName2 As String, UserName3 As String)
        Dim sql As New StringBuilder
        sql.Append(" Select FormType ")
        sql.Append(" From MSDH_Forms.dbo.TimeStudyEmmployeeInfo")
        sql.Append(" where EmployeeName = '")
        sql.Append(UserName)
        sql.Append("' and PIN='")
        sql.Append(PIN & "'")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Select of TimeStudyEmmployeeInfo table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function
    Public Function GetVendor(SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append(" Select distinct [County Health Department], ApplicationClinicID ")
        sql.Append(" From  MSDHClinics")
        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Select of GetVendor/MSDHClinics table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetEntergyDoc(TypeBill As String, Location As String, Month As String, Year As String, Amount As String, DocID As Integer, SqlConn As String)
        Dim x As String = ""
        Dim sql As New StringBuilder
        sql.Append(" select a.RecordID as RecID, b.RecordID as DFAID,b.ApprovalPersonEmail,a.CreatedBy,* FROM EntergyDocUpload a ")
        sql.Append(" inner join EntergyPayment b on a.RecordID = b.DocumentID")
        sql.Append(" where ")
        If TypeBill <> "" Then
            sql.Append(" TypeBill =  '" & TypeBill & "'")
            x = "yes"
        End If
        If Location <> "" Then
            If x = "yes" Then
                sql.Append(" and Location =  '" & Location & "'")
            Else
                sql.Append(" Location =  '" & Location & "'")
            End If
        End If
        If Month <> "" Then
            If x = "yes" Then
                sql.Append(" and Month =  '" & Month & "'")
            Else
                sql.Append(" Month =  '" & Month & "'")
            End If
        End If
        If Year <> "" Then
            If x = "yes" Then
                sql.Append(" and Year =  '" & Year & "'")
            Else
                sql.Append(" Year =  '" & Year & "'")
            End If
        End If
        If Amount <> "" Then
            If x = "yes" Then
                sql.Append(" and Amount =  '" & Amount & "'")
            Else
                sql.Append(" Amount =  '" & Amount & "'")
            End If
        End If
        If DocID <> 0 Then
            sql.Append(" and a.RecordID =  " & DocID)
        End If

        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request get EntergyDocUpload/GetEntergyDoc did Not Get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try

        Return ds
    End Function
    Public Function GetEntergyPaymentDN(RecordID As Integer, SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append(" select * FROM EntergyPaymentDeclineNotes ")
        sql.Append(" where PayID = " & RecordID)
        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request get EntergyPaymentDeclineNotes/GetEntergyPaymentDN did Not Get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try

        Return ds
    End Function


    Public Function GetEntergyPayment(RecordID As Integer, SqlConn As String)
        Dim sql As New StringBuilder
        sql.Append(" select b.RecordID as DFAID,* FROM EntergyPayment a ")
        sql.Append(" inner join EntergyDocUpload b on a.DocumentID = b.RecordID")
        sql.Append(" where a.recordid = " & RecordID)
        Dim sqlConnection1 As New SqlConnection(SqlConn)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
        Catch ex As Exception
            Throw New Exception("Your Request get PaymentEntergy/GetEntergyPayment did Not Get processed there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Close()
            sqlConnection1.Dispose()
        End Try

        Return ds
    End Function

    Public Function InsertEntergyPayment(DocumentID As Integer, CostCenter As String, FunctionalArea As String, InternalCode As String _
                                         , ApprovalPerson As String, Status As String, Inactive As Integer, SQLConn As String)


        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO EntergyPayment (DocumentID, CostCenter,FunctionalArea,InternalCode,ApprovalPersonEmail,Status,Inactive)")
        sql.Append("  VALUES(")
        sql.Append(DocumentID)
        sql.Append(",'" & CostCenter)
        sql.Append("','" & FunctionalArea)
        sql.Append("','" & InternalCode)
        sql.Append("','" & ApprovalPerson)
        sql.Append("','" & Status)
        sql.Append("'," & Inactive & ") ; Select Scope_Identity()")

        Dim sqlConnection1 As New SqlConnection(SQLConn)
        Dim ID As Integer
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (EntergyPayment/InsertEntergyPayment), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function
    Public Function UpdateEntergyPaymentDln(RecordID As Integer, CostCenter As String, FunctionalArea As String, InternalCode As String _
                                            , ApprovalPerson As String, Status As String, SQLConn As String)

        Dim sql As New StringBuilder
        sql.Append(" UPDATE  EntergyPayment ")
        sql.Append(" SET CostCenter = '" & CostCenter & "'")
        sql.Append(", FunctionalArea = '" & FunctionalArea & "'")
        sql.Append(", InternalCode = '" & InternalCode & "'")
        sql.Append(", ApprovalPersonEmail = '" & ApprovalPerson & "'")
        sql.Append(", Status = '" & Status & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(SQLConn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (EntergyPayment/UpdateEntergyPaymentDln), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function UpdatePayment1(RecordID As Integer, Status As String, SQLConn As String)

        Dim sql As New StringBuilder
        sql.Append(" UPDATE  EntergyPayment ")
        sql.Append(" SET FacilitiesProgramSignature = ''")
        sql.Append(", FacilitiesProgramDate = ''")
        sql.Append(", FAEmail = ''")
        sql.Append(", FASignature = ''")
        sql.Append(", FADate = ''")
        sql.Append(", Status = '" & Status & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(SQLConn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (EntergyPayment/UpdatePayment1), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function InsertEntergyPaymentDN(RecordID As Integer, DeclineNotes As String, SQLConn As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO EntergyPaymentDeclineNotes (PayID, DeclineNotes)")
        sql.Append("  VALUES(")
        sql.Append(RecordID)
        sql.Append(",'" & DeclineNotes & "')")

        Dim sqlConnection1 As New SqlConnection(SQLConn)
        Dim ID As Integer
        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (EntergyPaymentDeclineNotes/InsertEntergyPaymentDN), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function
    Public Function UpdateEntergyPaymentStatus(RecordID As Integer, Status As String, SQLConn As String)

        Dim sql As New StringBuilder
        sql.Append(" UPDATE  EntergyPayment ")
        sql.Append(" SET Status = '" & Status & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(SQLConn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (EntergyPayment/UpdateEntergyPaymentAP), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function
    Public Function UpdateEntergyPaymentAP(RecordID As Integer, FacilitiesProgramSignature As String, FacilitiesProgramDate As String, Status As String, FAEmail As String, SQLConn As String)

        Dim sql As New StringBuilder
        sql.Append(" UPDATE  EntergyPayment ")
        sql.Append(" SET FacilitiesProgramSignature = '" & FacilitiesProgramSignature & "'")
        sql.Append(", FacilitiesProgramDate = '" & FacilitiesProgramDate & "'")
        sql.Append(", Status = '" & Status & "'")
        sql.Append(", FAEmail = '" & FAEmail & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(SQLConn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Update Request, (EntergyPayment/UpdateEntergyPaymentAP), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateEntergyPayment1(RecordID As Integer, VendorNumber As String, MagicDocumentNumber As String, GLAccountNumber As String _
                                       , Funds As String, FASignature As String, FADate As String, Status As String, SQLConn As String)

        Dim sql As New StringBuilder
        sql.Append(" UPDATE  EntergyPayment ")
        sql.Append(" SET VendorNumber = '" & VendorNumber & "'")
        sql.Append(", MagicDocumentNumber = '" & MagicDocumentNumber & "'")
        sql.Append(", GLAccountNumber = '" & GLAccountNumber & "'")
        sql.Append(", Funds = '" & Funds & "'")
        sql.Append(", FASignature = '" & FASignature & "'")
        sql.Append(", FADate = '" & FADate & "'")
        sql.Append(", Status = '" & Status & "'")
        sql.Append(" Where RecordID = " & RecordID)

        Dim sqlConnection1 As New SqlConnection(SQLConn)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                cmd.ExecuteNonQuery()
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (EntergyPayment/UpdateEntergyPayment1), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

End Class