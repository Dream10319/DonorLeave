Imports Microsoft.VisualBasic
Imports System.DirectoryServices
Imports System.Object
Imports System.IO
Imports System.Net
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Personnel
    Public Function InsertFARA(Classification As String, PIN As String, JobCode As String, Org As String, County As String, ReportToPIN As String _
                               , ReportingCategoryNo1 As String, ReportingCategoryPct1 As String, ReportingCategoryNo2 As String, ReportingCategoryPct2 As String _
                               , ReportingCategoryNo3 As String, ReportingCategoryPct3 As String, ProjectNo As String, EstTotalSalary As String _
                               , AdditionalCompensation As String, SpecialQualYes As String, SpecialQualNo As String, Justification As String _
                               , StateServicePromotionTransfer As String, OpenCompetition As String, AgencyOnlyPromotion As String, DirectAppointment As String _
                               , TravelNone As String, TravelYes As String, SameDayFrequent As String, SameDayInFrequent As String, OvernightFrequent As String _
                               , OvernightInFrequent As String, ContractPersonFullName As String, ContractPersonPhone As String, OtherComments As String _
                               , EffectiveDate As String, SignOfPerson As String, SignOfPersonDate As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO PA_ApprovalRecruitmentAdvertisement (Classification,PIN,JobCode,Org,County,ReportToPIN,ReportingCategoryNo1,ReportingCategoryPct1")
        sql.Append(",ReportingCategoryNo2,ReportingCategoryPct2,ReportingCategoryNo3,ReportingCategoryPct3,ProjectNo,EstTotalSalary")
        sql.Append(",AdditionalCompensation,SpecialQual,Justification,RecruitmentType")
        sql.Append(",TravelType,SameDay,Overnight,ContractPersonFullName,ContractPersonPhone,OtherComments,EffectiveDateOfAction")
        sql.Append(",SignaturePerson,SignaturePersonDate,DateCreated,Inactive)")
        sql.Append("  VALUES(")
        sql.Append("'" & Classification)
        sql.Append("','" & PIN)
        sql.Append("','" & JobCode)
        sql.Append("','" & Org)
        sql.Append("','" & County)
        sql.Append("','" & ReportToPIN)
        sql.Append("','" & ReportingCategoryNo1)
        sql.Append("','" & ReportingCategoryPct1)
        sql.Append("','" & ReportingCategoryNo2)
        sql.Append("','" & ReportingCategoryPct2)
        sql.Append("','" & ReportingCategoryNo3)
        sql.Append("','" & ReportingCategoryPct3)
        sql.Append("','" & ProjectNo)
        sql.Append("','" & EstTotalSalary)
        sql.Append("','" & AdditionalCompensation)
        If SpecialQualYes = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        sql.Append("','" & Justification)
        If StateServicePromotionTransfer = True Then
            sql.Append("','SSPT")
        End If
        If OpenCompetition = True Then
            sql.Append("','OC")
        End If
        If AgencyOnlyPromotion = True Then
            sql.Append("','AOP")
        End If
        If DirectAppointment = True Then
            sql.Append("','DA")
        End If
        If TravelYes = True Then
            sql.Append("','Yes")
        Else
            sql.Append("','No")
        End If
        If SameDayFrequent = True Then
            sql.Append("','SDF")
        Else
            sql.Append("','SDIF")
        End If
        If OvernightFrequent = True Then
            sql.Append("','ONF")
        Else
            sql.Append("','ONIF")
        End If
        sql.Append("','" & ContractPersonFullName)
        sql.Append("','" & ContractPersonPhone)
        sql.Append("','" & OtherComments)
        sql.Append("','" & EffectiveDate)
        sql.Append("','" & SignOfPerson)
        sql.Append("','" & SignOfPersonDate)
        sql.Append("','" & Today())
        sql.Append("','0') ; Select Scope_Identity()")
        'sql.Append("','" & StartPage & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
                'ID = 1
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (PersonnelActionRequest/InsertFARA), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertAppointment(NewHire As String, Reemployment As String, InterAgencyTransfer As String, StandByCallback As String, Other As String _
                               , OtherComment As String, EmployeeName As String, Positionclassification As String, AppJobCode As String _
                               , AppPIN As String, AppReportToPIN As String, AppOrgCode As String, AppSalary As String, AppReportingCategoryNo1 As String _
                               , AppReportingCategoryPct1 As String, AppReportingCategoryNo2 As String, AppReportingCategoryPct2 As String, AppReportingCategoryNo3 As String _
                               , AppReportingCategoryPct3 As String, AppProjectNo As String, AppComments As String, OtherComments As String, EffectiveDate As String, SignOfPerson As String _
                               , SignOfPersonDate As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO PA_Appointment (AppointmentType,AppOtherComment,EmployeeName,Positionclassification,JobCode,PIN,ReportToPIN,OrgCode")
        sql.Append(",Salary,ReportingCategoryNo1,ReportingCategoryPct1,ReportingCategoryNo2,ReportingCategoryPct2")
        sql.Append(",ReportingCategoryNo3,ReportingCategoryPct3,ProjectNo,Comments,OtherComments,EffectiveDateOfAction")
        sql.Append(",SignaturePerson,SignaturePersonDate,DateCreated,Inactive)")
        sql.Append("  VALUES(")
        If NewHire = True Then
            sql.Append("'NH")
        End If
        If Reemployment = True Then
            sql.Append("'RE")
        End If
        If InterAgencyTransfer = True Then
            sql.Append("'IAT")
        End If
        If StandByCallback = True Then
            sql.Append("'SBC")
        End If
        If Other = True Then
            sql.Append("'OTH")
        End If
        sql.Append("','" & OtherComment)
        sql.Append("','" & EmployeeName)
        sql.Append("','" & Positionclassification)
        sql.Append("','" & AppJobCode)
        sql.Append("','" & AppPIN)
        sql.Append("','" & AppReportToPIN)
        sql.Append("','" & AppOrgCode)
        sql.Append("','" & AppSalary)
        sql.Append("','" & AppReportingCategoryNo1)
        sql.Append("','" & AppReportingCategoryPct1)
        sql.Append("','" & AppReportingCategoryNo2)
        sql.Append("','" & AppReportingCategoryPct2)
        sql.Append("','" & AppReportingCategoryNo3)
        sql.Append("','" & AppReportingCategoryPct3)
        sql.Append("','" & AppProjectNo)
        sql.Append("','" & AppComments)
        sql.Append("','" & OtherComments)
        sql.Append("','" & EffectiveDate)
        sql.Append("','" & SignOfPerson)
        sql.Append("','" & SignOfPersonDate)
        sql.Append("','" & Today())
        sql.Append("','0'); Select Scope_Identity()")
        'sql.Append("','" & StartPage & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
                'ID = 1
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (PersonnelActionRequest/InsertAppointment), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertIntraAgencyActions(Promotion As String, Demotion As String, Reallocation As String, Reclassification As String, Transfer As String _
                               , NameOfEmployee As String, Presentclassification As String, IntraPresentJobCode As String, IntraPresentOrgCode As String _
                               , IntraPresentPIN As String, IntraPresentSalary As String, Proposedclassification As String, IntraProposedJobCode As String _
                               , IntraProposedOrgCode As String, IntraProposedPIN As String, IntraProposedSalary As String, IntraReportingCategoryNo1 As String _
                               , IntraReportingCategoryPct1 As String, IntraReportingCategoryNo2 As String, IntraReportingCategoryPct2 As String _
                               , IntraReportingCategoryNo3 As String, IntraReportingCategoryPct3 As String _
                               , IntraProjectNo As String, IntraReportToPIN As String, IntraComments As String, OtherComments As String _
                               , EffectiveDate As String, SignOfPerson As String, SignOfPersonDate As String)


        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO PA_IntraAgencyActions (ActionType,NameOfEmployee,Presentclassification,PresentJobCode,PresentOrgCode,PresentPIN")
        sql.Append(",PresentSalary,Proposedclassification,ProposedJobCode,ProposedOrgCode,ProposedPIN,ProposedSalary")
        sql.Append(",ReportingCategoryNo1,ReportingCategoryPct1,ReportingCategoryNo2,ReportingCategoryPct2")
        sql.Append(",ReportingCategoryNo3,ReportingCategoryPct3,ProjectNo,ReportToPIN,Comments,OtherComments,EffectiveDateOfAction")
        sql.Append(",SignaturePerson,SignaturePersonDate,DateCreated,Inactive)")
        sql.Append("  VALUES(")
        If Promotion = True Then
            sql.Append("'P")
        End If
        If Demotion = True Then
            sql.Append("'D")
        End If
        If Reallocation = True Then
            sql.Append("'RL")
        End If
        If Reclassification = True Then
            sql.Append("'RC")
        End If
        If Transfer = True Then
            sql.Append("'TF")
        End If
        sql.Append("','" & NameOfEmployee)
        sql.Append("','" & Presentclassification)
        sql.Append("','" & IntraPresentJobCode)
        sql.Append("','" & IntraPresentOrgCode)
        sql.Append("','" & IntraPresentPIN)
        sql.Append("','" & IntraPresentSalary)
        sql.Append("','" & Proposedclassification)
        sql.Append("','" & IntraProposedJobCode)
        sql.Append("','" & IntraProposedOrgCode)
        sql.Append("','" & IntraProposedPIN)
        sql.Append("','" & IntraProposedSalary)
        sql.Append("','" & IntraReportingCategoryNo1)
        sql.Append("','" & IntraReportingCategoryPct1)
        sql.Append("','" & IntraReportingCategoryNo2)
        sql.Append("','" & IntraReportingCategoryPct2)
        sql.Append("','" & IntraReportingCategoryNo3)
        sql.Append("','" & IntraReportingCategoryPct3)
        sql.Append("','" & IntraProjectNo)
        sql.Append("','" & IntraReportToPIN)
        sql.Append("','" & IntraComments)
        sql.Append("','" & OtherComments)
        sql.Append("','" & EffectiveDate)
        sql.Append("','" & SignOfPerson)
        sql.Append("','" & SignOfPersonDate)
        sql.Append("','" & Today())
        sql.Append("','0'); Select Scope_Identity()")
        'sql.Append("','" & StartPage & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
                'ID = 1
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (PersonnelActionRequest/InsertIntraAgencyActions), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function

    Public Function InsertCompAdj(EducationalBenchmark As String, DetailSpecialDuty As String, NewHireAgencyHeadFlex As String, StandbyCallBack As String _
                               , OtherAdjs As String, NameOfEmployee As String, Positionclassification As String, JobCode As String _
                               , PIN As String, OrgCode As String, ReportingCategoryNo1 As String, ReportingCategoryPct1 As String _
                               , ReportingCategoryNo2 As String, ReportingCategoryPct2 As String, ReportingCategoryNo3 As String _
                               , ReportingCategoryPct3 As String, PresentSalary As String, ProposedSalary As String, ReportToPIN As String, Comments As String _
                               , OtherComments As String, EffectiveDate As String, SignOfPerson As String, SignOfPersonDate As String, Justification As String _
                               , Filename1 As String, bytes1 As Byte(), Filename2 As String, bytes2 As Byte(), Filename3 As String, bytes3 As Byte())

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO PA_CompensationAdjustments (ActionType,OtherAdjustments,NameOfEmployee,Positionclassification,JobCode,PIN,OrgCode")
        sql.Append(",ReportingCategoryNo1,ReportingCategoryPct1,ReportingCategoryNo2,ReportingCategoryPct2")
        sql.Append(",ReportingCategoryNo3,ReportingCategoryPct3,PresentSalary,ProposedSalary,ReportToPIN,Comments,Justification")
        sql.Append(",FileName1,Document1,FileName2,Document2,FileName3,Document3")
        sql.Append(",OtherComments,EffectiveDateOfAction,SignaturePerson,SignaturePersonDate,DateCreated,Inactive)")
        sql.Append("  VALUES(")
        If EducationalBenchmark = True Then
            sql.Append("'EB")
        End If
        If DetailSpecialDuty = True Then
            sql.Append("'DSD")
        End If
        If NewHireAgencyHeadFlex = True Then
            sql.Append("'NHF")
        End If
        If StandbyCallBack = True Then
            sql.Append("'SC")
        End If
        sql.Append("','" & OtherAdjs)
        sql.Append("','" & NameOfEmployee)
        sql.Append("','" & Positionclassification)
        sql.Append("','" & JobCode)
        sql.Append("','" & PIN)
        sql.Append("','" & OrgCode)
        sql.Append("','" & ReportingCategoryNo1)
        sql.Append("','" & ReportingCategoryPct1)
        sql.Append("','" & ReportingCategoryNo2)
        sql.Append("','" & ReportingCategoryPct2)
        sql.Append("','" & ReportingCategoryNo3)
        sql.Append("','" & ReportingCategoryPct3)
        sql.Append("','" & PresentSalary)
        sql.Append("','" & ProposedSalary)
        sql.Append("','" & ReportToPIN)
        sql.Append("','" & Comments)
        sql.Append("','" & Justification)
        sql.Append("',@Name1")
        sql.Append(",@Doc1")
        sql.Append(",@Name2")
        sql.Append(",@Doc2")
        sql.Append(",@Name3")
        sql.Append(",@Doc3")
        sql.Append(",'" & OtherComments)
        sql.Append("','" & EffectiveDate)
        sql.Append("','" & SignOfPerson)
        sql.Append("','" & SignOfPersonDate)
        sql.Append("','" & Today())
        sql.Append("','0'); Select Scope_Identity()")
        'sql.Append("','" & StartPage & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
            Try
                cmd.Parameters.Add("@Doc1", SqlDbType.Binary).Value = bytes1
                cmd.Parameters.Add("@Doc2", SqlDbType.Binary).Value = bytes2
                cmd.Parameters.Add("@Doc3", SqlDbType.Binary).Value = bytes3
                cmd.Parameters.Add("@Name1", SqlDbType.VarChar).Value = Filename1
                cmd.Parameters.Add("@Name2", SqlDbType.VarChar).Value = Filename2
                cmd.Parameters.Add("@Name3", SqlDbType.VarChar).Value = Filename3
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
                sqlConnection1.Close()
            Catch ex As Exception
                Throw New Exception("Your Request, (PersonnelActionRequest/InsertCompAdj), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
            Finally
                sqlConnection1.Dispose()
            End Try
        End Using
        Return ID
    End Function

    Public Function InsertDataChgs(ChgFrom As String, ChgTo As String, NameOfEmployee As String, Presentclassification As String _
                               , PIN As String, JobCode As String, ReportToPIN As String _
                               , ReportingCategoryNo1 As String, ReportingCategoryPct1 As String _
                               , ReportingCategoryNo2 As String, ReportingCategoryPct2 As String, ReportingCategoryNo3 As String _
                               , ReportingCategoryPct3 As String, ProjectNo As String, OtherComments As String, EffectiveDate As String _
                               , SignOfPerson As String, SignOfPersonDate As String)

        Dim sql As New StringBuilder
        sql.Append(" INSERT INTO PA_DataChanges (FromDate,ToDate,NameOfEmployee,Presentclassification,JobCode,PIN,ReportToPIN")
        sql.Append(",ReportingCategoryNo1,ReportingCategoryPct1,ReportingCategoryNo2,ReportingCategoryPct2")
        sql.Append(",ReportingCategoryNo3,ReportingCategoryPct3,ProjectNo,OtherComments,EffectiveDateOfAction,SignaturePerson,SignaturePersonDate,DateCreated,Inactive)")
        sql.Append("  VALUES(")
        sql.Append("'" & ChgFrom)
        sql.Append("','" & ChgTo)
        sql.Append("','" & NameOfEmployee)
        sql.Append("','" & Presentclassification)
        sql.Append("','" & PIN)
        sql.Append("','" & JobCode)
        sql.Append("','" & ReportToPIN)
        sql.Append("','" & ReportingCategoryNo1)
        sql.Append("','" & ReportingCategoryPct1)
        sql.Append("','" & ReportingCategoryNo2)
        sql.Append("','" & ReportingCategoryPct2)
        sql.Append("','" & ReportingCategoryNo3)
        sql.Append("','" & ReportingCategoryPct3)
        sql.Append("','" & ProjectNo)
        sql.Append("','" & OtherComments)
        sql.Append("','" & EffectiveDate)
        sql.Append("','" & SignOfPerson)
        sql.Append("','" & SignOfPersonDate)
        sql.Append("','" & Today())
        sql.Append("','0'); Select Scope_Identity()")
        'sql.Append("','" & StartPage & "') ; Select Scope_Identity()")

        Dim ID As Integer
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)

        Try
            Using cmd As New SqlCommand(sql.ToString, sqlConnection1)
                sqlConnection1.Open()
                ID = cmd.ExecuteScalar()
                'ID = 1
            End Using
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request, (PersonnelActionRequest/InsertDataChgs), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ID
    End Function

    Public Function UpdateFARA(Sign As String, SignDate As String, RecordID As Integer, Num As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.PA_ApprovalRecruitmentAdvertisement ")
        If Num = "2" Then
            sql.Append(" SET SignatureAdminDirector = '" & Sign & "'")
            sql.Append(", SignatureAdminDirectorDate = '" & SignDate & "'")
        ElseIf Num = "3" Then
            sql.Append(" SET SignatureHR = '" & Sign & "'")
            sql.Append(", SignatureHRDate = '" & SignDate & "'")
        End If
        sql.Append(" Where RecordID = " & RecordID)
        sql.Append(" and Inactive = 0")

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
            Throw New Exception("Your Update Request, (Personnel Action Request/FARA), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateAppointment(Sign As String, SignDate As String, RecordID As Integer, Num As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.PA_Appointment ")
        If Num = "2" Then
            sql.Append(" SET SignatureAdminDirector = '" & Sign & "'")
            sql.Append(", SignatureAdminDirectorDate = '" & SignDate & "'")
        ElseIf Num = "3" Then
            sql.Append(" SET SignatureHR = '" & Sign & "'")
            sql.Append(", SignatureHRDate = '" & SignDate & "'")
        End If
        sql.Append(" Where RecordID = " & RecordID)
        sql.Append(" and Inactive = 0")

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
            Throw New Exception("Your Update Request, (Personnel Action Request/UpdateAppointment), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateIntraAgencyActions(Sign As String, SignDate As String, RecordID As Integer, Num As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.PA_IntraAgencyActions ")
        If Num = "2" Then
            sql.Append(" SET SignatureAdminDirector = '" & Sign & "'")
            sql.Append(", SignatureAdminDirectorDate = '" & SignDate & "'")
        ElseIf Num = "3" Then
            sql.Append(" SET SignatureHR = '" & Sign & "'")
            sql.Append(", SignatureHRDate = '" & SignDate & "'")
        End If
        sql.Append(" Where RecordID = " & RecordID)
        sql.Append(" and Inactive = 0")

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
            Throw New Exception("Your Update Request, (Personnel Action Request/UpdateIntraAgencyActions), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateCompAdj(Sign As String, SignDate As String, RecordID As Integer, Num As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.PA_CompensationAdjustments ")
        If Num = "2" Then
            sql.Append(" SET SignatureAdminDirector = '" & Sign & "'")
            sql.Append(", SignatureAdminDirectorDate = '" & SignDate & "'")
        ElseIf Num = "3" Then
            sql.Append(" SET SignatureHR = '" & Sign & "'")
            sql.Append(", SignatureHRDate = '" & SignDate & "'")
        End If
        sql.Append(" Where RecordID = " & RecordID)
        sql.Append(" and Inactive = 0")

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
            Throw New Exception("Your Update Request, (Personnel Action Request/UpdateCompAdj), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function UpdateDataChgs(Sign As String, SignDate As String, RecordID As Integer, Num As String)
        Dim sql As New StringBuilder

        sql.Append(" UPDATE MSDH_Forms.dbo.PA_DataChanges ")
        If Num = "2" Then
            sql.Append(" SET SignatureAdminDirector = '" & Sign & "'")
            sql.Append(", SignatureAdminDirectorDate = '" & SignDate & "'")
        ElseIf Num = "3" Then
            sql.Append(" SET SignatureHR = '" & Sign & "'")
            sql.Append(", SignatureHRDate = '" & SignDate & "'")
        End If
        sql.Append(" Where RecordID = " & RecordID)
        sql.Append(" and Inactive = 0")

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
            Throw New Exception("Your Update Request, (Personnel Action Request/UpdateDataChgs), did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return Nothing
    End Function

    Public Function GetFARA(RecordID As Integer)
        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From MSDH_Forms.dbo.PA_ApprovalRecruitmentAdvertisement")
        sql.Append(" where RecordID = " & RecordID)
        'sql.Append(" order by person_first_name")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request to retrieve FARA table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetAppointment(RecordID As Integer)
        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From MSDH_Forms.dbo.PA_Appointment")
        sql.Append(" where RecordID = " & RecordID)
        'sql.Append(" order by person_first_name")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request to retrieve Appointment table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetIntraAgencyActions(RecordID As Integer)
        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From MSDH_Forms.dbo.PA_IntraAgencyActions")
        sql.Append(" where RecordID = " & RecordID)
        'sql.Append(" order by person_first_name")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request to retrieve IntraAgencyActions table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetCompAdj(RecordID As Integer)
        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From MSDH_Forms.dbo.PA_CompensationAdjustments")
        sql.Append(" where RecordID = " & RecordID)
        'sql.Append(" order by person_first_name")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request to retrieve IntraAgencyActions table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function GetDataChgs(RecordID As Integer)
        Dim sql As New StringBuilder
        sql.Append(" Select * ")
        sql.Append(" From MSDH_Forms.dbo.PA_DataChanges")
        sql.Append(" where RecordID = " & RecordID)
        'sql.Append(" order by person_first_name")
        Dim sqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
        Dim cmd As New SqlCommand(sql.ToString, sqlConnection1)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        Try
            da.Fill(ds, "info")
            sqlConnection1.Close()
        Catch ex As Exception
            Throw New Exception("Your Request to retrieve PA_DataChanges table did not get submitted there was an ERROR!!!, error discription => " & ex.Message)
        Finally
            sqlConnection1.Dispose()
        End Try
        Return ds
    End Function

    Public Function SendPersonnelActionEmail(Link As String, RecordID As String, FormID As String)
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Dim con As New SqlConnection(strConnString)
        Dim cmd As New SqlCommand("sp_PersonnelActionNotification")
        Dim param As SqlParameter
        Dim param1 As SqlParameter
        Dim param2 As SqlParameter
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
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
        param2.ParameterName = "@link"
        param2.Value = Link
        param2.SqlDbType = SqlDbType.VarChar
        cmd.Parameters.Add(param2)

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

End Class
