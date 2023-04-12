<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128536701/18.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3994)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Grid View for ASP.NET Web Forms - How to fit exported document to page
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3994/)**
<!-- run online end -->

This example illustrates how to use the XtraPrinting library to adjust width of an exported [ASPxGridView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView) to occupy a single page.

![](exported-grid.png)

To fit the grid to one document page follow the steps below:

1. Create a [PrintableComponentLinkBase](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrintingLinks.PrintableComponentLinkBase) object for for the grid component. 
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
