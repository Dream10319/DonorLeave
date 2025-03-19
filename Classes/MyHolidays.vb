Imports Microsoft.VisualBasic
Imports System.DirectoryServices
Imports System.Object
Imports System.IO
Imports System.Net
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class MyHolidays
    Public Function getHolidayList(ByVal vYear As Integer) As List(Of Date)

        Dim FirstWeek As Integer = 1
        Dim SecondWeek As Integer = 2
        Dim ThirdWeek As Integer = 3
        Dim FourthWeek As Integer = 4
        Dim LastWeek As Integer = 5

        Dim HolidayList As New List(Of Date)

        '   http://www.usa.gov/citizens/holidays.shtml      
        '   http://archive.opm.gov/operating_status_schedules/fedhol/2013.asp

        ' New Year's Day            Jan 1
        HolidayList.Add(DateSerial(vYear, 1, 1))

        ' Martin Luther King, Jr. third Mon in Jan
        HolidayList.Add(GetNthDayOfNthWeek(DateSerial(vYear, 1, 1), DayOfWeek.Monday, ThirdWeek))

        ' Washington's Birthday third Mon in Feb
        HolidayList.Add(GetNthDayOfNthWeek(DateSerial(vYear, 2, 1), DayOfWeek.Monday, ThirdWeek))

        ' Confederate Memorial Day          last Mon in April
        HolidayList.Add(GetNthDayOfNthWeek(DateSerial(vYear, 4, 1), DayOfWeek.Monday, LastWeek))

        ' Memorial Day          last Mon in May
        HolidayList.Add(GetNthDayOfNthWeek(DateSerial(vYear, 5, 1), DayOfWeek.Monday, LastWeek))

        ' Independence Day      July 4
        HolidayList.Add(DateSerial(vYear, 7, 4))

        ' Labor Day             first Mon in Sept
        HolidayList.Add(GetNthDayOfNthWeek(DateSerial(vYear, 9, 1), DayOfWeek.Monday, FirstWeek))

        ' Columbus Day          second Mon in Oct
        HolidayList.Add(GetNthDayOfNthWeek(DateSerial(vYear, 10, 1), DayOfWeek.Monday, SecondWeek))

        ' Veterans Day          Nov 11
        HolidayList.Add(DateSerial(vYear, 11, 11))

        ' Thanksgiving Day      fourth Thur in Nov
        HolidayList.Add(GetNthDayOfNthWeek(DateSerial(vYear, 11, 1), DayOfWeek.Thursday, FourthWeek))

        ' Christmas Day         Dec 25
        HolidayList.Add(DateSerial(vYear, 12, 25))

        'saturday holidays are moved to Fri; Sun to Mon
        For i As Integer = 0 To HolidayList.Count - 1
            Dim dt As Date = (HolidayList(i))
            If dt.DayOfWeek = DayOfWeek.Saturday Then
                HolidayList(i) = dt.AddDays(-1)
            End If
            If dt.DayOfWeek = DayOfWeek.Sunday Then
                HolidayList(i) = dt.AddDays(1)
            End If
        Next

        'return
        Return HolidayList

    End Function

    Private Function GetNthDayOfNthWeek(ByVal dt As Date, ByVal DayofWeek As Integer, ByVal WhichWeek As Integer) As Date
        'specify which day of which week of a month and this function will get the date
        'this function uses the month and year of the date provided

        'get first day of the given date
        Dim dtFirst As Date = DateSerial(dt.Year, dt.Month, 1)

        'get first DayOfWeek of the month
        Dim dtRet As Date = dtFirst.AddDays(6 - dtFirst.AddDays(-(DayofWeek + 1)).DayOfWeek)

        'get which week
        dtRet = dtRet.AddDays((WhichWeek - 1) * 7)

        'if day is past end of month then adjust backwards a week
        If dtRet >= dtFirst.AddMonths(1) Then
            dtRet = dtRet.AddDays(-7)
        End If

        'return
        Return dtRet

    End Function

End Class