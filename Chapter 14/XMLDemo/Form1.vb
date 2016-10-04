'
' The Definitive Guide to the .NET Compact Framework
'   Apress : ISBN 1-59059-095-3 : 2003
'
' Authors:
'   Larry Roof
'     email: larry.roof@larryroof.com
'     web site: www.larryroof.com
'   Dan Fergus 
'     email: danf@forestsoftwaregroup.com
'     web site: www.forestsoftwaregroup.com
'
' You can obtain updates to the samples included with this title 
' at the following sites:
'   www.larryroof.com
'   www.forestsoftwaregroup.com
'   www.apress.com
'
'
' Copyright (c) 2003 by Larry Roof and Dan Fergus
'   
' The information and code provided hereunder (collectively referred to
' as "Software") is provided as is without warranty of any kind, either
' express or implied, including but not limited to the implied 
' warranties of merchantability and fitness for a particular purpose.
' In no event shall either Larry Roof and/or Dan Fergus be liable for any
' damages whatsoever including direct, indirect, incidental, consequential,
' loss of business profits or special damages, even if Larry Roof and/or Dan
' Fergus have been advised of the possibility of such damages. Some states
' do not allow the exclusion or limitation of liability for consequential
' or incidental damages so the foregoing limitation may not apply.
'
' This software, and the examples and techniques demonstrated within this
' software, may be incorporated into your software products subject to the
' following conditions:
'
' 1. This software cannot be distributed in its original form to any other
'    individuals for any purpose.
'
' 2. License to use this software is only provided to those individuals that
'    purchase a copy of the book "The Definitive Guide to the .NET Compact
'    Framework", published by Apress Publishing.
'
' 3. You agree to indemnify, hold harmless, and defend Larry Roof and Dan
'    Fergus from and against any claims or lawsuits, including attorneys 
'    fees, that arise or result from the use or distribution of your software 
'    product and any modifications to the Software.
'
Imports System.Xml
Imports System.IO
Imports System.Reflection
Imports System.Text

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 16)
        Me.Button1.Size = New System.Drawing.Size(88, 20)
        Me.Button1.Text = "Read File 1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(120, 16)
        Me.Button2.Size = New System.Drawing.Size(96, 20)
        Me.Button2.Text = "Read File 2"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(24, 40)
        Me.Button3.Size = New System.Drawing.Size(192, 20)
        Me.Button3.Text = "Read File 3"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 72)
        Me.TextBox1.Multiline = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(224, 192)
        Me.TextBox1.Text = ""
        '
        'Form1
        '
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "Chapter 14 - XML"

    End Sub

#End Region

    Private Function AppPath() As String

        ' Fetch and return the location where the application was launched.
        AppPath = _
          System.IO.Path.GetDirectoryName(Reflection.Assembly. _
          GetExecutingAssembly().GetName().CodeBase.ToString())

    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ReadingWithDOM()
        'Dim xd As XmlDocument
        'xd = New XmlDocument

        'xd.Load(AppPath() & "\XmlOutAttrib.xml")
        'Dim teams As XmlNodeList

        'TextBox1.Text = String.Empty
        'teams = xd.GetElementsByTagName("Team")
        'For Each xm As XmlNode In teams
        '    For Each att As XmlAttribute In xm.Attributes
        '        TextBox1.Text &= att.Name & ":  " & att.Value() & vbCrLf
        '        Dim n As XmlNodeList = att.ChildNodes
        '    Next
        '    TextBox1.Text &= vbCrLf
        'Next

        Dim xd As XmlDocument = New XmlDocument
        xd.Load(AppPath() & "\XmlOutAttrib.xml")
        Dim teams As XmlNodeList
        Dim xn As XmlElement = xd.CreateElement("Team")
        xn.SetAttribute("Name", "New York Yankees")
        xn.SetAttribute("Manager", "Joe Torre")
        xn.SetAttribute("Stadium", "Yankee Stadium")
        teams = xd.GetElementsByTagName("Teams")

        teams.Item(0).AppendChild(xn)
        xd.Save(AppPath() & "\XmlTest10.xml")
    End Sub
    Private Sub ReadingWithDOMNodes()
        Dim xd As XmlDocument
        xd = New XmlDocument

        xd.Load(AppPath() & "\XmlOutAttrib.xml")
        '        Dim root As XmlNode = xd.FirstChild(

    End Sub
    Private Sub DumpXmlFile(ByVal fileName As String)
        Dim dr As XmlTextReader
        Dim fs As FileStream = New FileStream(fileName, FileMode.Open)
        Dim sb As StringBuilder = New StringBuilder

        Try
            dr = New XmlTextReader(fileName)
            While dr.Read()
                sb.Append(String.Format("{0} {1} {2}" & vbCrLf, dr.NodeType, dr.Name, dr.Value.ToString()))
            End While
            TextBox1.Text = sb.ToString()
        Catch ex As XmlException
            TextBox1.Text = ex.Message
        Finally
            dr.Close()
            fs.Close()
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '        DumpXmlFile("\xmlfile1.xml")
        'WriteNewXmlFile()
        'ReadXmlAttributes("\XmlFile2.xml")
        'ReadXmlAttributesDynamic("\XmlFile2.xml")
        WriteNewXmlFileWithAttributes()
        ReadingWithDOM()
    End Sub
    Private Sub ReadXmlAttributes(ByVal fileName As String)
        Dim dr As XmlTextReader
        Dim strPath As String = AppPath() & fileName

        dr = New XmlTextReader(strPath)
        dr.WhitespaceHandling = WhitespaceHandling.None
        TextBox1.Text = String.Empty

        While dr.Read()
            If dr.NodeType = XmlNodeType.Element And dr.HasAttributes Then
                TextBox1.Text &= "(" & dr.Name.ToString() & ") Name: " & vbTab & dr.GetAttribute("Name") & vbCrLf
            End If
        End While
        dr.Close()
    End Sub
    Private Sub ReadXmlAttributesDynamic(ByVal fileName As String)
        Dim dr As XmlTextReader
        Dim strPath As String = AppPath() & fileName

        dr = New XmlTextReader(strPath)
        dr.WhitespaceHandling = WhitespaceHandling.None
        TextBox1.Text = String.Empty

        While dr.Read()
            If dr.NodeType = XmlNodeType.Element And dr.HasAttributes Then
                TextBox1.Text &= "(" & dr.Name.ToString() & ")" & vbCrLf
                '   Walk and look at all elements
                dr.MoveToFirstAttribute()
                TextBox1.Text &= vbTab & "{" & dr.Name & "}" & vbTab & dr.Value & vbCrLf
                While dr.MoveToNextAttribute
                    TextBox1.Text &= vbTab & "{" & dr.Name & "}" & vbTab & dr.Value & vbCrLf
                End While
                'dr.MoveToElement()
            End If
        End While
        dr.Close()
    End Sub
    Private Sub WriteNewXmlFileWithAttributes()
        Dim dw As XmlTextWriter
        Dim fsOut As FileStream = New FileStream(AppPath() & "\XmlOutAttrib.xml", FileMode.Create)

        dw = New XmlTextWriter(fsOut, System.Text.Encoding.UTF8)
        dw.WriteStartElement("Baseball")
        dw.WriteStartElement("Teams")
        dw.WriteAttributeString("League", "American")
        dw.WriteStartElement("Team")
        dw.WriteAttributeString("Name", "Texas Rangers")
        dw.WriteAttributeString("Manager", "Buck Showalter")
        dw.WriteAttributeString("Stadium", "Ballpark in Arlington")
        dw.WriteEndElement()    '    Close the Team Element

        dw.WriteStartElement("Team")
        dw.WriteAttributeString("Name", "Anaheim Angels")
        dw.WriteAttributeString("Manager", "Mike Scioscia")
        dw.WriteAttributeString("Stadium", "Edison Field")
        dw.WriteEndElement()    '    Close the Team Element

        dw.WriteStartElement("Team")
        dw.WriteAttributeString("Name", "Oakland Athletics")
        dw.WriteAttributeString("Manager", "Ken Macha")
        dw.WriteAttributeString("Stadium", "Network Associates Coliseum")
        dw.WriteEndElement()    '    Close the Team Element

        dw.WriteStartElement("Team")
        dw.WriteAttributeString("Name", "Seattle Mariners")
        dw.WriteAttributeString("Manager", "Bob Melvin")
        dw.WriteAttributeString("Stadium", "SAFECO Field")
        dw.WriteEndElement()    '    Close the Team Element

        dw.WriteEndElement()    '    Close the Teams Element
        dw.WriteEndElement()    '    Close the BaseBall element
        dw.Close()
        fsOut.Close()
    End Sub

    Private Sub WriteNewXmlFile()
        Dim dw As XmlTextWriter
        Dim fsOut As FileStream = New FileStream("\XmlTestFile.xml", FileMode.Create)

        dw = New XmlTextWriter(fsOut, System.Text.Encoding.UTF8)
        dw.Formatting = Formatting.Indented
        dw.Indentation = 4

        dw.WriteStartElement("Baseball")
        dw.WriteStartElement("Teams")
        dw.WriteStartElement("Team")
        dw.WriteElementString("Name", "Texas Rangers")
        dw.WriteElementString("Manager", "Buck Showalter")
        dw.WriteElementString("Stadium", "Ballpark in Arlington")
        dw.WriteEndElement()
        dw.WriteStartElement("Team")
        dw.WriteStartElement("Name")
        dw.WriteString("Anaheim Angels")
        dw.WriteEndElement()
        dw.WriteStartElement("Manager")
        dw.WriteString("Mike Scioscia")
        dw.WriteEndElement()
        dw.WriteStartElement("Stadium")
        dw.WriteString("Edison Field")
        dw.WriteEndElement()
        dw.WriteEndElement()
        dw.WriteStartElement("Team")
        dw.WriteElementString("Name", "Seattle Mariners")
        dw.WriteElementString("Manager", "Bob Melvin")
        dw.WriteElementString("Stadium", "SAFECO Field")
        dw.WriteEndElement()
        dw.WriteStartElement("Team")
        dw.WriteStartElement("Name")
        dw.WriteString("Oakland Athletics")
        dw.WriteEndElement()
        dw.WriteStartElement("Manager")
        dw.WriteString("Ken Macha")
        dw.WriteEndElement()
        dw.WriteStartElement("Stadium")
        dw.WriteString("Network Associates Coliseum")
        dw.WriteEndElement()
        dw.WriteEndElement()    '    Close the Team Element
        dw.WriteEndElement()    '    Close the Teams Element
        dw.WriteEndElement()    '    Close the BaseBall element
        dw.Close()
        fsOut.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '   Load a ddatset from an against a schema
        Dim ds As DataSet = New DataSet
        Dim xmlPath As String = AppPath() & "\XmlTest11.xml"

        ' Read the XML document back in. 
        ' Create new FileStream to read schema with.
        Dim fsReadXml As New System.IO.FileStream(xmlPath, System.IO.FileMode.Open)
        ' Create an XmlTextReader to read the file.
        Dim myXmlReader As New System.Xml.XmlTextReader(fsReadXml)
        ' Read the XML document into the DataSet.
        ds.ReadXml(myXmlReader)
        ' Close the XmlTextReader
        myXmlReader.Close()


        Dim dr As XmlTextReader
        Dim fs As FileStream = New FileStream(AppPath() & "\xmlfile1.xml", FileMode.Open)
        Dim strOutput As String = String.Empty

        dr = New XmlTextReader(fs)
        dr.WhitespaceHandling = WhitespaceHandling.Significant
        While dr.Read()
            If dr.NodeType = XmlNodeType.Element And dr.Name = "League" Then
                '    Now we are in the Element of interest
                '    Read the next two Elements and get their data
                dr.Read()
                strOutput &= String.Format("Name: {0}" & vbTab, dr.ReadElementString())
                strOutput &= String.Format("ID: {0}" & vbCrLf, dr.ReadElementString())
            End If
        End While
        TextBox1.Text = strOutput
        dr.Close()
        fs.Close()
    End Sub

    Private Sub WriteFileXmlTextWriter()
        Dim dr As XmlTextReader
        Dim dw As XmlTextWriter
        Dim fsIn As FileStream = New FileStream(AppPath() & "\xmlfile1.xml", FileMode.Open)
        Dim fsOut As FileStream = New FileStream(AppPath() & "\xmlfile1_out.xml", FileMode.Create)

        Dim inTeams As Boolean = False
        Dim inWins As Boolean = False
        Dim inLosses As Boolean = False
        Dim addToWins As Boolean = False
        Dim addToLosses As Boolean = False

        dr = New XmlTextReader(fsIn)
        dr.WhitespaceHandling = WhitespaceHandling.None
        dw = New XmlTextWriter(fsOut, System.Text.Encoding.UTF8)
        dw.Formatting = Formatting.Indented

        While dr.Read
            '    The Rangers beat the Angels (hey, it can happen!)
            '    Adjust the appropriate values
            If dr.NodeType = XmlNodeType.Element And dr.Name = "Teams" Then
                inTeams = True
            End If

            If inTeams And dr.NodeType = XmlNodeType.Text And dr.Value = "Texas Rangers" Then
                '    Write out the value
                dw.WriteString(dr.Value)
                '    Flag to chnage the Wins value next time
                addToWins = True
            ElseIf inTeams And dr.NodeType = XmlNodeType.Text And dr.Value = "Anaheim Angels" Then
                '    Write out the value
                dw.WriteString(dr.Value)
                '    Flag to change the Losses value next time
                addToLosses = True
            ElseIf dr.NodeType = XmlNodeType.Element And dr.Name = "Wins" Then
                dw.WriteStartElement(dr.Name)
                inWins = True
            ElseIf dr.NodeType = XmlNodeType.Element And dr.Name = "Losses" Then
                dw.WriteStartElement(dr.Name)
                inLosses = True
            Else
                Select Case dr.NodeType
                    Case XmlNodeType.Element
                        dw.WriteStartElement(dr.Name)
                    Case XmlNodeType.EndElement
                        dw.WriteEndElement()
                    Case XmlNodeType.Text
                        Dim newValue As String = dr.Value
                        If inWins And addToWins Then
                            newValue = CType(CType(newValue, Integer) + 1, String)
                            inWins = False
                            addToWins = False
                        End If
                        If inLosses And addToLosses Then
                            newValue = CType(CType(newValue, Integer) + 1, String)
                            inLosses = False
                            addToLosses = False
                        End If
                        dw.WriteString(newValue)

                    Case XmlNodeType.SignificantWhitespace
                        dw.WriteString(dr.Value)
                End Select
            End If
        End While

        dw.Close()
        dr.Close()
        fsOut.Close()
        fsIn.Close()

        DumpXmlFile(AppPath() & "\xmlfile1_out.xml")
    End Sub
    Private Sub ManipulateXmlDataDataSet()
        Dim ds As DataSet = New DataSet

        'ds.ReadXml(AppPath() & "\xmlfile4.xml")
        ''        ds.WriteXmlSchema(AppPath() & "\xmlfile4.xsd")
        'DumpXmlFile(AppPath() & "\xmlfile4.xml")

        ds.Clear()
        ds.ReadXml(AppPath() & "\XmlTest10.xml")
        Dim tab As DataTable = ds.Tables(0)
        For Each dr As DataRow In tab.Rows
            Dim str() As Object = dr.ItemArray()
        Next
        Dim ddr As DataRow = tab.NewRow()
        ddr(0) = "1"
        ddr(1) = "National"
        tab.Rows.Add(ddr)

        tab = ds.Tables(1)
        For Each dr As DataRow In tab.Rows
            Dim str() As Object = dr.ItemArray()
        Next
        ddr = tab.NewRow
        ddr(0) = "Atlanta Braves"
        ddr(1) = "Bobby Cox"
        ddr(2) = "Turner Field"
        ddr(3) = 1
        tab.Rows.Add(ddr)

        Dim xw As XmlWriter = New XmlTextWriter(AppPath() & "\XmlTest11.xml", System.Text.Encoding.UTF8)
        ds.WriteXml(xw, Data.XmlWriteMode.WriteSchema)
        ds.WriteXmlSchema(AppPath() & "\XmlTest10.xsd")
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'WriteFileXmlTextWriter()
        ManipulateXmlDataDataSet()
    End Sub
End Class
