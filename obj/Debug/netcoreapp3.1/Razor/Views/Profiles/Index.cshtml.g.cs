#pragma checksum "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "638b4ebf7bca636526f5e4abc8e18519c939557b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profiles_Index), @"mvc.1.0.view", @"/Views/Profiles/Index.cshtml")]
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
#line 1 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\_ViewImports.cshtml"
using PapugarniaOnline;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\_ViewImports.cshtml"
using PapugarniaOnline.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"638b4ebf7bca636526f5e4abc8e18519c939557b", @"/Views/Profiles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01f15db1f2afb24dbabd8f16d723ba89980dcc7a", @"/Views/_ViewImports.cshtml")]
    public class Views_Profiles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReadForm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<hr />\r\n");
#nullable restore
#line 7 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
 if (ViewBag.Data == "ok")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <center><h3>Wypełnij niezbędne informacje aby otrzymać Fakturę.</h3></center>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "638b4ebf7bca636526f5e4abc8e18519c939557b3857", async() => {
                WriteLiteral(@"
        <div class=""form-group"">
            <label class=""control-label"">Imię:</label>
            <input name=""name"" class=""form-control"" />
        </div>
        <div class=""form-group"">
            <label class=""control-label"">Nazwisko</label>
            <input name=""surname"" class=""form-control"" />
        </div>
        <div class=""form-group"">
            <label class=""control-label"">Kod pocztowy</label>
            <input name=""zipcode"" class=""form-control"" />
        </div>
        <div class=""form-group"">
            <label class=""control-label"">Miasto/Miejscowość</label>
            <input name=""city"" class=""form-control"" />
        </div>
        <div class=""form-group"">
            <label class=""control-label"">Ulica</label>
            <input name=""street"" class=""form-control"" />
        </div>
        <div class=""form-group"">
            <label class=""control-label"">Numer domu/mieszkania</label>
            <input name=""number"" class=""form-control"" />
        </div>
 ");
                WriteLiteral("       <div class=\"form-group\">\r\n            <input type=\"submit\" value=\"Zapisz\" class=\"btn btn-primary\" />\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 39 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
}
else
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert-primary\"><h2>");
#nullable restore
#line 43 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
                              Write(ViewBag.Data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2></div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "638b4ebf7bca636526f5e4abc8e18519c939557b7041", async() => {
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label\">Imię:</label>\r\n            <input name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 1653, "\"", 1674, 1);
#nullable restore
#line 47 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
WriteAttributeValue("", 1661, ViewBag.name, 1661, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly class=\"form-control\" />\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label\">Nazwisko</label>\r\n            <input name=\"surname\"");
                BeginWriteAttribute("value", " value=\"", 1852, "\"", 1876, 1);
#nullable restore
#line 51 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
WriteAttributeValue("", 1860, ViewBag.surname, 1860, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly class=\"form-control\" />\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label\">Kod pocztowy</label>\r\n            <input name=\"zipcode\"");
                BeginWriteAttribute("value", " value=\"", 2058, "\"", 2082, 1);
#nullable restore
#line 55 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
WriteAttributeValue("", 2066, ViewBag.zipcode, 2066, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly  class=\"form-control\" />\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label\">Miasto/Miejscowość</label>\r\n            <input name=\"city\"");
                BeginWriteAttribute("value", " value=\"", 2268, "\"", 2289, 1);
#nullable restore
#line 59 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
WriteAttributeValue("", 2276, ViewBag.city, 2276, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly class=\"form-control\" />\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label\">Ulica</label>\r\n            <input name=\"street\"");
                BeginWriteAttribute("value", " value=\"", 2463, "\"", 2486, 1);
#nullable restore
#line 63 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
WriteAttributeValue("", 2471, ViewBag.street, 2471, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly class=\"form-control\" />\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label\">Numer domu/mieszkania</label>\r\n            <input name=\"number\"");
                BeginWriteAttribute("value", " value=\"", 2676, "\"", 2699, 1);
#nullable restore
#line 67 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
WriteAttributeValue("", 2684, ViewBag.number, 2684, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly class=\"form-control\" />\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <hr />\r\n");
#nullable restore
#line 71 "C:\Users\blong\OneDrive\Desktop\PROJEKTY\Papugarnia\Views\Profiles\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
