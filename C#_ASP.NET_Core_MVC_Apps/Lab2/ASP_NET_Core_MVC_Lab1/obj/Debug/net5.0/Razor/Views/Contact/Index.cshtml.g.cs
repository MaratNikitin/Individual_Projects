#pragma checksum "C:\Users\maratn\Desktop\MN\Individual_Projects\C#_ASP.NET_Core_MVC_Apps\Lab2\ASP_NET_Core_MVC_Lab1\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4b80a9e8a13a65ac4320c65c0b846d74352dcd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\maratn\Desktop\MN\Individual_Projects\C#_ASP.NET_Core_MVC_Apps\Lab2\ASP_NET_Core_MVC_Lab1\Views\_ViewImports.cshtml"
using ASP_NET_Core_MVC_Lab1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\maratn\Desktop\MN\Individual_Projects\C#_ASP.NET_Core_MVC_Apps\Lab2\ASP_NET_Core_MVC_Lab1\Views\_ViewImports.cshtml"
using ASP_NET_Core_MVC_Lab1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4b80a9e8a13a65ac4320c65c0b846d74352dcd7", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d6c4e0154fd0ff353f7461f444c4851e12ed387", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!--
 * This web app creates a website of a fictional boat marina company allowing users to learn about the company,
    see contact information, see available slips with the option of selecting them by dock, register a new user,
    a registered user can login/logout, lease available slips and see own leased slips
 * This is a body part of the Contact Info page of the website (responsive page design is implemented throughout)
 * Author: Marat Nikitin
 * SAIT, OOSD course, CPRG-214 .NET Web Applications course
 * When: February 2022
-->


");
#nullable restore
#line 12 "C:\Users\maratn\Desktop\MN\Individual_Projects\C#_ASP.NET_Core_MVC_Apps\Lab2\ASP_NET_Core_MVC_Lab1\Views\Contact\Index.cshtml"
  
    ViewData["Title"] = "Contact Info";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <h1 class=""text-center my-4 text-primary"">  Contact Information:  <i class=""far fa-address-card ml-2""></i> </h1>

    <div class=""offset-sm-2"">
        <div class=""my-4"">
            <i class=""far fa-envelope-open text-primary mr-2""></i> Inland Lake Marina: <br />
            Box 123, <br />
            Inland Lake, Arizona, USA <br />
            86038 <br />
        </div>
        <div class=""my-4"">
            <i class=""fa fa-phone text-primary mr-2""></i> Office phone: 928-555-2234 <br />
            <i class=""far fa-address-card text-primary mr-2""></i> Leasing phone: 928-555-2235 <br />
            <i class=""fas fa-fax text-primary mr-2""></i> Fax: 928-555-2236 <br />
        </div>
        <div class=""my-4"">
            <i class=""fas fa-user-tie text-primary mr-2""></i>Manager: Glenn Cooke <br />
            <i class=""far fa-address-book text-primary mr-2""></i>Slip Manager: Kimberley Carson <br />
            <i class=""far fa-envelope-open text-primary mr-2"">");
            WriteLiteral("</i> Contact e-mail: info@inlandmarina.com <br />\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
