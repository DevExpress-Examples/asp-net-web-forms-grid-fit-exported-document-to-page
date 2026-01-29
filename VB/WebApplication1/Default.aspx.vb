Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.IO
Imports DevExpress.XtraPrinting
Imports System.Net.Mime
Imports DevExpress.XtraPrintingLinks

Namespace WebApplication1

    Public Partial Class _Default
        Inherits UI.Page

        Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Using ms As MemoryStream = New MemoryStream()
                Dim pcl As PrintableComponentLinkBase = New PrintableComponentLinkBase(New PrintingSystemBase())
                pcl.Component = ASPxGridView1
                pcl.Margins.Right = 50
                pcl.Margins.Left = pcl.Margins.Right
                pcl.Landscape = True
                pcl.CreateDocument(False)
                pcl.PrintingSystemBase.Document.AutoFitToPagesWidth = 1
                pcl.ExportToPdf(ms)
                Call WriteResponse(Response, ms.ToArray(), DispositionTypeNames.Inline.ToString())
            End Using
        End Sub

        Public Shared Sub WriteResponse(ByVal response As HttpResponse, ByVal filearray As Byte(), ByVal type As String)
            response.ClearContent()
            response.Buffer = True
            response.Cache.SetCacheability(HttpCacheability.Private)
            response.ContentType = "application/pdf"
            Dim contentDisposition As ContentDisposition = New ContentDisposition()
            contentDisposition.FileName = "test.pdf"
            contentDisposition.DispositionType = type
            response.AddHeader("Content-Disposition", contentDisposition.ToString())
            response.BinaryWrite(filearray)
            Call HttpContext.Current.ApplicationInstance.CompleteRequest()
            Try
                response.End()
            Catch __unusedThreadAbortException1__ As Threading.ThreadAbortException
            End Try
        End Sub
    End Class
End Namespace
