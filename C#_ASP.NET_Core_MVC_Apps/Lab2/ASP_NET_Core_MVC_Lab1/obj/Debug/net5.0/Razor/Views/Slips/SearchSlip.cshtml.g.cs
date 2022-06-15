#pragma checksum "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "335853f020dbce62521230c66c08bbf060f55565"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Slips_SearchSlip), @"mvc.1.0.view", @"/Views/Slips/SearchSlip.cshtml")]
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
#nullable restore
#line 1 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\_ViewImports.cshtml"
using ASP_NET_Core_MVC_Lab1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\_ViewImports.cshtml"
using ASP_NET_Core_MVC_Lab1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"335853f020dbce62521230c66c08bbf060f55565", @"/Views/Slips/SearchSlip.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d6c4e0154fd0ff353f7461f444c4851e12ed387", @"/Views/_ViewImports.cshtml")]
    public class Views_Slips_SearchSlip : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASP_NET_Core_MVC_Lab1.Models.SlipDockLeaseViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips 
 * This is a body part of the /Slips/SearchSlip/id page of the website where a list of slips for the chosen 
    dock is displayed (responsive page design is implemented throughout)
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
-->

");
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
  
    ViewData["Title"] = "Available Slips by Dock";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1 class=""text-center text-primary"">Available Slips Of The Selected Dock: <i class=""fas fa-ship ml-2""></i></h1>
<div class=""container"">
    <table class=""table table-striped table-bordered table-hover text-center justify-content-center"">
        <thead style=""position:sticky; top:0"" class=""bg-white text-primary"">
            <tr>
                <th>
                    ");
#nullable restore
#line 24 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
               Write(Html.DisplayNameFor(model => model.SlipID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 27 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
               Write(Html.DisplayNameFor(model => model.Width));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 30 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
               Write(Html.DisplayNameFor(model => model.Length));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 33 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
               Write(Html.DisplayNameFor(model => model.DockName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 36 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
               Write(Html.DisplayNameFor(model => model.WaterService));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 39 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
               Write(Html.DisplayNameFor(model => model.ElectricalService));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 45 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SlipID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 52 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Width));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 55 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Length));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DockName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
                   Write(Html.DisplayFor(modelItem => item.WaterService));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 64 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ElectricalService));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 68 "C:\Users\14039\source\repos\ASP_NET_Core_MVC_Lab2\ASP_NET_Core_MVC_Lab1\Views\Slips\SearchSlip.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASP_NET_Core_MVC_Lab1.Models.SlipDockLeaseViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591