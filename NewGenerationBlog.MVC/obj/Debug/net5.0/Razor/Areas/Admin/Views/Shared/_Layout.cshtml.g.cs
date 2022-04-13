#pragma checksum "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c86cdf1c3b06a8052b07158ebd10705fc3b4b67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(NewGenerationBlog.MVC.Views.Shared.Areas_Admin_Views_Shared__Layout), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_Layout.cshtml")]
namespace NewGenerationBlog.MVC.Views.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c86cdf1c3b06a8052b07158ebd10705fc3b4b67", @"/Areas/Admin/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37e7abf9a0905a5b1fb5750f7ee11a5acf649211", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("sb-nav-fixed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c86cdf1c3b06a8052b07158ebd10705fc3b4b673381", async() => {
                WriteLiteral("\n    ");
#nullable restore
#line 4 "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml"
Write(await Html.PartialAsync("_LayoutMetaHeaderPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \n    ");
#nullable restore
#line 5 "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml"
Write(await Html.PartialAsync("_LayoutCssPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c86cdf1c3b06a8052b07158ebd10705fc3b4b674886", async() => {
                WriteLiteral("\n    ");
#nullable restore
#line 8 "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml"
Write(await Html.PartialAsync("_LayoutNavbarPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \n    <div id=\"layoutSidenav\">\n        ");
#nullable restore
#line 10 "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml"
   Write(await Html.PartialAsync("_LayoutSideBarNavPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \n        <div id=\"layoutSidenav_content\">\n            <main>\n                <div class=\"container-fluid\">\n                    ");
#nullable restore
#line 14 "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml"
               Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n            </main>\n            ");
#nullable restore
#line 17 "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml"
       Write(await Html.PartialAsync("_LayoutFooterPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \n        </div>\n    </div>\n    ");
#nullable restore
#line 20 "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml"
Write(await Html.PartialAsync("_LayoutJsPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("; \n    ");
#nullable restore
#line 21 "/Users/serkanisel/Projects/NewGenerationBlog/NewGenerationBlog.MVC/Areas/Admin/Views/Shared/_Layout.cshtml"
Write(await RenderSectionAsync("Scripts",false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>\n");
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
