#pragma checksum "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\Admin\AllUsersToList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd05430d5adf25233a5d113a240e1c783367485b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AllUsersToList), @"mvc.1.0.view", @"/Views/Admin/AllUsersToList.cshtml")]
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
#line 1 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\_ViewImports.cshtml"
using LibraryProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\_ViewImports.cshtml"
using LibraryProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd05430d5adf25233a5d113a240e1c783367485b", @"/Views/Admin/AllUsersToList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be8390cc30a4c1d6bc6e1591c9d5beccf26439b1", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AllUsersToList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LibraryProject.Models.Users.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\Admin\AllUsersToList.cshtml"
  
    ViewData["Title"] = "AllUsersToList";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Список всех пользователей сайта</h1>
<table class=""table"" border=""1"">
    <tr>
        <th>
            Id
        </th>
        <th>
            Name
        </th>
        <th>
            Email
        </th>
        <th>
            Role
        </th>

    </tr>





");
#nullable restore
#line 29 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\Admin\AllUsersToList.cshtml"
     foreach (var i in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\Admin\AllUsersToList.cshtml"
           Write(Html.DisplayFor(mitem => i.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 36 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\Admin\AllUsersToList.cshtml"
           Write(Html.DisplayFor(mitem => i.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 39 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\Admin\AllUsersToList.cshtml"
           Write(Html.DisplayFor(mitem => i.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 42 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\Admin\AllUsersToList.cshtml"
           Write(Html.DisplayFor(mitem => i.RoleId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Tino\source\repos\LibraryProject\LibraryProject\Views\Admin\AllUsersToList.cshtml"


    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LibraryProject.Models.Users.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
