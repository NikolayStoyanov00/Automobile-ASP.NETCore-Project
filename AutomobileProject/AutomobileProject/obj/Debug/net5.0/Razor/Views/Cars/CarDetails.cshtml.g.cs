#pragma checksum "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f4bd45595e8eb9c48fab640e1edce290311a033"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cars_CarDetails), @"mvc.1.0.view", @"/Views/Cars/CarDetails.cshtml")]
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
#nullable restore
#line 2 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
using AutomobileProject.Data.Models.User;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f4bd45595e8eb9c48fab640e1edce290311a033", @"/Views/Cars/CarDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88d1fae58ed41a16ce176636fa13e1b39025dd44", @"/Views/_ViewImports.cshtml")]
    public class Views_Cars_CarDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AutomobileProject.ViewModels.Cars.VisualizeCarDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ImageScripts/medium-zoom.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ImageScripts/ChangeImageScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ImageScripts/ChangeImageSizeScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
  
    var userId = userManager.GetUserId(User);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""banner banner-secondary"" id=""top"" style=""background-image: url(/img/banner-image-1-1920x300.jpg);"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-10 col-md-offset-1"">
                <div class=""banner-caption"">
                    <div class=""line-dec""></div>
                    <h2>Car Details</h2>
                </div>
            </div>
        </div>
    </div>
</section>

<main>
    <section class=""featured-places"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-6 col-xs-12"">
                    <div style=""cursor:pointer"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 947, "\"", 969, 1);
#nullable restore
#line 28 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
WriteAttributeValue("", 953, Model.MainImage, 953, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 970, "\"", 976, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive wc-image; zoom\" id=\"mainImage\">\r\n                    </div>\r\n\r\n                    <br>\r\n                    <div class=\"row\">\r\n");
#nullable restore
#line 33 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                         foreach (var image in Model.Images)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-sm-4 col-xs-6\">\r\n                                <div style=\"cursor:pointer\" class=\"form-group\">\r\n                                    <img onclick=\"ChangeImage(this.src)\"");
            BeginWriteAttribute("src", " src=\"", 1431, "\"", 1443, 1);
#nullable restore
#line 37 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
WriteAttributeValue("", 1437, image, 1437, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1444, "\"", 1450, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive\">\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 40 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f4bd45595e8eb9c48fab640e1edce290311a0338648", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f4bd45595e8eb9c48fab640e1edce290311a0339703", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f4bd45595e8eb9c48fab640e1edce290311a03310758", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                <div class=\"col-md-6 col-xs-12\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f4bd45595e8eb9c48fab640e1edce290311a03311876", async() => {
                WriteLiteral("\r\n                        <h2><strong class=\"text-primary\">$");
#nullable restore
#line 50 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                     Write(Model.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(@".00</strong></h2>

                        <br>

                        <ul class=""list-group list-group-flush"">
                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Type</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 59 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.Type);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" vehicle</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Make</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 67 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.Make);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left""> Model</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 75 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.Model);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Year of producing</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 83 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Kilometers</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 91 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.Kilometers);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" km</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Fuel</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 99 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.FuelType);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Engine size</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 107 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.EngineSize);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" cc</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Power</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 115 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.HorsePower);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" hp</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Gearbox</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 123 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.Gearbox);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Doors</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 131 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.Doors);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                </div>
                            </li>

                            <li class=""list-group-item"">
                                <div class=""clearfix"">
                                    <span class=""pull-left"">Color</span>

                                    <strong class=""pull-right"">");
#nullable restore
#line 139 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                          Write(Model.Color);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>
                                </div>
                            </li>
                        </ul>

                        <div class=""accordions"">
                            <ul class=""accordion"">
                                <li>
                                    <a class=""accordion-trigger"">Vehicle Description</a>
                                    <div class=""accordion-content"">
                                        <p>");
#nullable restore
#line 149 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                      Write(Model.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                    </div>
                                </li>
                                <li>
                                    <a class=""accordion-trigger"">Contact Details</a>

                                    <div class=""accordion-content"">

                                        <p>
                                            <span>Name</span>

                                            <br>

                                            <strong>");
#nullable restore
#line 162 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                               Write(Model.UserDetails.FullName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>

                                        </p>

                                        <p>
                                            <span>Mobile phone</span>

                                            <br>

                                            <strong>
                                                <a");
                BeginWriteAttribute("href", " href=\"", 7405, "\"", 7446, 2);
                WriteAttributeValue("", 7412, "tel:", 7412, 4, true);
#nullable restore
#line 172 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
WriteAttributeValue("", 7416, Model.UserDetails.PhoneNumber, 7416, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 172 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                                                        Write(Model.UserDetails.PhoneNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</a>
                                            </strong>
                                        </p>

                                        <p>

                                            <span>Email</span>

                                            <br>

                                            <strong>
                                                <a");
                BeginWriteAttribute("href", " href=\"", 7856, "\"", 7901, 2);
                WriteAttributeValue("", 7863, "mailto:", 7863, 7, true);
#nullable restore
#line 183 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
WriteAttributeValue("", 7870, Model.UserDetails.EmailAddress, 7870, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 183 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                                                                                            Write(Model.UserDetails.EmailAddress);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</a>
                                            </strong>
                                        </p>
                                    </div>
                                </li>
                            </ul> <!-- / accordion -->
                        </div>
");
#nullable restore
#line 190 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                         if (userId == Model.UserDetails.Id)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"form-group\">\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 8389, "\"", 8429, 2);
                WriteAttributeValue("", 8396, "/Cars/CarEditDetails?id=", 8396, 24, true);
#nullable restore
#line 193 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
WriteAttributeValue("", 8420, Model.Id, 8420, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"width:120px; float:right; position:relative; bottom:-15px\" class=\"btn btn-primary\">Edit</a>\r\n                            </div>\r\n");
#nullable restore
#line 195 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1960, "/Cars/CarEditDetails?id=", 1960, 24, true);
#nullable restore
#line 49 "D:\C# - ASP.NET Project\AutomobileProject\AutomobileProject\Views\Cars\CarDetails.cshtml"
AddHtmlAttributeValue("", 1984, Model.Id, 1984, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AutomobileProject.ViewModels.Cars.VisualizeCarDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
