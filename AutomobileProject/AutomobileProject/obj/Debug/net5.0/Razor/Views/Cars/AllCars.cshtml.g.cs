#pragma checksum "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a251da70bc86938e2e5a414f7b65a6fef760f27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cars_AllCars), @"mvc.1.0.view", @"/Views/Cars/AllCars.cshtml")]
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
#line 1 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\_ViewImports.cshtml"
using AutomobileProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\_ViewImports.cshtml"
using AutomobileProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a251da70bc86938e2e5a414f7b65a6fef760f27", @"/Views/Cars/AllCars.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88d1fae58ed41a16ce176636fa13e1b39025dd44", @"/Views/_ViewImports.cshtml")]
    public class Views_Cars_AllCars : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<AutomobileProject.ViewModels.Offer.VisualizeCarViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Cars/PartialViews/_FiltersPartialView.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/SharedPartialViews/_SortingPartialView.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
  
    ViewData["Title"] = "Cars";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""banner banner-secondary"" id=""top"" style=""background-image: url('/img/banner-image-1-1920x300.jpg');"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-10 col-md-offset-1"">
                <div class=""banner-caption"">
                    <div class=""line-dec""></div>
                    <h2>Car Offers</h2>
                </div>
            </div>
        </div>
    </div>
</section>

<main>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2a251da70bc86938e2e5a414f7b65a6fef760f274535", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 20 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = new AutomobileProject.ViewModels.Cars.FiltersInputModel();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    \r\n\r\n    <section class=\"featured-places\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2a251da70bc86938e2e5a414f7b65a6fef760f276231", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 30 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                 foreach (var car in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-4 col-sm-6 col-xs-12\">\r\n                        <div class=\"featured-item\">\r\n                            <div class=\"thumb\">\r\n                                <div>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1226, "\"", 1260, 2);
            WriteAttributeValue("", 1233, "/Cars/CarDetails?id=", 1233, 20, true);
#nullable restore
#line 36 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
WriteAttributeValue("", 1253, car.Id, 1253, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 1308, "\"", 1324, 1);
#nullable restore
#line 37 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
WriteAttributeValue("", 1314, car.Image, 1314, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"360\" width=\"240\" style=\"object-fit: cover\"");
            BeginWriteAttribute("alt", " alt=\"", 1376, "\"", 1382, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    </a>\r\n                                </div>\r\n                                <div class=\"overlay-content\">\r\n                                    <strong><i class=\"fa fa-dashboard\"></i> ");
#nullable restore
#line 41 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                                                                       Write(car.Kilometers);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> &nbsp;&nbsp;&nbsp;&nbsp;\r\n                                    <strong><i class=\"fa fa-cube\"></i> ");
#nullable restore
#line 42 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                                                                  Write(car.EngineSize);

#line default
#line hidden
#nullable disable
            WriteLiteral(" cc</strong>&nbsp;&nbsp;&nbsp;&nbsp;\r\n                                    <strong><i class=\"fa fa-cog\"></i> ");
#nullable restore
#line 43 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                                                                 Write(car.Gearbox);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"down-content\">\r\n                                <h4>");
#nullable restore
#line 47 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                               Write(car.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n                                <br>\r\n\r\n                                <p>");
#nullable restore
#line 51 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                              Write(car.HorsePower);

#line default
#line hidden
#nullable disable
            WriteLiteral(" hp  /  ");
#nullable restore
#line 51 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                                                     Write(car.FuelType);

#line default
#line hidden
#nullable disable
            WriteLiteral("  /  ");
#nullable restore
#line 51 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                                                                       Write(car.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("  /  ");
#nullable restore
#line 51 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                                                                                     Write(car.Condition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                                <p><span><strong>");
#nullable restore
#line 53 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                                            Write(car.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(".00 lev</strong></span></p>\r\n\r\n                                <div class=\"text-button\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2401, "\"", 2435, 2);
            WriteAttributeValue("", 2408, "/Cars/CarDetails?id=", 2408, 20, true);
#nullable restore
#line 56 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
WriteAttributeValue("", 2428, car.Id, 2428, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View More</a>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 61 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\AllCars.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </section>\r\n</main>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<AutomobileProject.ViewModels.Offer.VisualizeCarViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
