#pragma checksum "C:\Users\Moje\Documents\GitHub\OrderManager\OrderManager\OrderManager\Views\AdminOrders\NewOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d45c26dcfe2c362a57b5dc5faa3626b3ab33a2c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminOrders_NewOrders), @"mvc.1.0.view", @"/Views/AdminOrders/NewOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AdminOrders/NewOrders.cshtml", typeof(AspNetCore.Views_AdminOrders_NewOrders))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Moje\Documents\GitHub\OrderManager\OrderManager\OrderManager\Views\_ViewImports.cshtml"
using OrderManager.DataAccess.Models;

#line default
#line hidden
#line 2 "C:\Users\Moje\Documents\GitHub\OrderManager\OrderManager\OrderManager\Views\_ViewImports.cshtml"
using OrderManager.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d45c26dcfe2c362a57b5dc5faa3626b3ab33a2c1", @"/Views/AdminOrders/NewOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"389f9d9993b89a9f5b24a1878b5bb6f265bce434", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminOrders_NewOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Moje\Documents\GitHub\OrderManager\OrderManager\OrderManager\Views\AdminOrders\NewOrders.cshtml"
  
    Layout = "_AdminLayout";
    ViewBag.Tittle = "Nowe zamówienia";

#line default
#line hidden
            BeginContext(80, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\Moje\Documents\GitHub\OrderManager\OrderManager\OrderManager\Views\AdminOrders\NewOrders.cshtml"
 if (ViewBag.Orders != null)
{
    foreach (var item in ViewBag.Orders)
    {

#line default
#line hidden
            BeginContext(164, 175, true);
            WriteLiteral("        <div class=\"card m-1 p-1\">\r\n            <div class=\"p-1\" style=\"height:60px;width:100%; background-color:grey\">\r\n                <h4>\r\n                    Zamówienie: ");
            EndContext();
            BeginContext(340, 14, false);
#line 14 "C:\Users\Moje\Documents\GitHub\OrderManager\OrderManager\OrderManager\Views\AdminOrders\NewOrders.cshtml"
                           Write(item.OrderName);

#line default
#line hidden
            EndContext();
            BeginContext(354, 30, true);
            WriteLiteral("\r\n                    Budowa: ");
            EndContext();
            BeginContext(385, 17, false);
#line 15 "C:\Users\Moje\Documents\GitHub\OrderManager\OrderManager\OrderManager\Views\AdminOrders\NewOrders.cshtml"
                       Write(item.BuildingName);

#line default
#line hidden
            EndContext();
            BeginContext(402, 61, true);
            WriteLiteral("\r\n                </h4>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 19 "C:\Users\Moje\Documents\GitHub\OrderManager\OrderManager\OrderManager\Views\AdminOrders\NewOrders.cshtml"
    }
 }

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
