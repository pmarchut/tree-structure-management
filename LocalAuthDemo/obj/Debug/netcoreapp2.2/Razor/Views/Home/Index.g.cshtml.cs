#pragma checksum "C:\Users\pm970\source\repos\LocalAuthDemo\LocalAuthDemo\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "818bb5a9b9a9d5ab65ab6e2830cd7111c49cd5ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\pm970\source\repos\LocalAuthDemo\LocalAuthDemo\Views\_ViewImports.cshtml"
using LocalAuthDemo;

#line default
#line hidden
#line 2 "C:\Users\pm970\source\repos\LocalAuthDemo\LocalAuthDemo\Views\_ViewImports.cshtml"
using LocalAuthDemo.Models;

#line default
#line hidden
#line 3 "C:\Users\pm970\source\repos\LocalAuthDemo\LocalAuthDemo\Views\_ViewImports.cshtml"
using LocalAuthDemo.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\pm970\source\repos\LocalAuthDemo\LocalAuthDemo\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"818bb5a9b9a9d5ab65ab6e2830cd7111c49cd5ae", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58daa996b009fa1a69ee19204a3a9e93381c0430", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 39, true);
            WriteLiteral("<div class=\"jumbotron\">\r\n    <h1>Hello ");
            EndContext();
            BeginContext(41, 60, false);
#line 2 "C:\Users\pm970\source\repos\LocalAuthDemo\LocalAuthDemo\Views\Home\Index.cshtml"
          Write(User.Identity.IsAuthenticated ? User.Identity.Name : "World");

#line default
#line hidden
            EndContext();
            BeginContext(102, 15, true);
            WriteLiteral("</h1>\r\n</div>\r\n");
            EndContext();
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
