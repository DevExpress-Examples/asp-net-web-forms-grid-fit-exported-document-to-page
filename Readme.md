<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128536701/18.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3994)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Grid View for ASP.NET Web Forms - How to fit exported document to page

This example illustrates how to use the XtraPrinting library to adjust the width of an exported [ASPxGridView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView) to occupy a single page.

![](exported-grid.png)

 Follow the steps below to fit the grid to one document page:

1. Create a [PrintableComponentLinkBase](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase) object for the grid component. 
2. Set the [Document.AutoFitToPagesWidth](http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPrintingDocument_AutoFitToPagesWidthtopic) property to `1` to fit the grid to one page. 
3. Call the [ExportToPdf](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.LinkBase.ExportToPdf(System.IO.Stream)) method to export the document to a stream in PDF format.

```cs
using(MemoryStream ms = new MemoryStream()){
    PrintableComponentLinkBase pcl = new PrintableComponentLinkBase(new PrintingSystemBase());
    pcl.Component = ASPxGridView1;
    pcl.Margins.Left = pcl.Margins.Right = 50;
    pcl.Landscape = true;
    pcl.CreateDocument(false);
    pcl.PrintingSystemBase.Document.AutoFitToPagesWidth = 1;
    pcl.ExportToPdf(ms);
    WriteResponse(this.Response, ms.ToArray(), System.Net.Mime.DispositionTypeNames.Inline.ToString());
}
```

## Files to Review

* [Default.aspx](./CS/WebApplication1/Default.aspx) (VB: [Default.aspx](./VB/WebApplication1/Default.aspx))
* [Default.aspx.cs](./CS/WebApplication1/Default.aspx.cs) (VB: [Default.aspx](./VB/WebApplication1/Default.aspx))
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-grid-fit-exported-document-to-page&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-web-forms-grid-fit-exported-document-to-page&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
