#pragma checksum "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "721611c7ac9fde4e905e5bdc945a0f5544148319"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lead_Index), @"mvc.1.0.view", @"/Views/Lead/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Lead/Index.cshtml", typeof(AspNetCore.Views_Lead_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
#line 2 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 5 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"721611c7ac9fde4e905e5bdc945a0f5544148319", @"/Views/Lead/Index.cshtml")]
    public class Views_Lead_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dist/plugins/jquery/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 6 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    int count = 0;

#line default
#line hidden
            BeginContext(306, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
  
    string str = HttpContextAccessor.HttpContext.Session.GetString("UserMenus");
    List<MVCCoreDemo.Models.MenuModel> UserMenus = JsonConvert.DeserializeObject<List<MVCCoreDemo.Models.MenuModel>>(str);
    if (UserMenus != null)
    {

#line default
#line hidden
            BeginContext(553, 565, true);
            WriteLiteral(@"        <section class=""content"">
            <div class=""container-fluid"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <h4>Master Settings</h4>
                        <div class=""card"">
                            <div class=""card-body"">
                                <div class=""row"">
                                    <div class=""col-5 col-sm-3"">
                                        <div id=""tabstrip"" class=""nav flex-column nav-tabs h-100"" role=""tablist"" aria-orientation=""vertical"">
");
            EndContext();
#line 26 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                             foreach (var submenu in UserMenus.Where(x => x.ParentMenuId == 4011).ToList())
                                            {

#line default
#line hidden
            BeginContext(1290, 85, true);
            WriteLiteral("                                                <a class=\"nav-link\" data-toggle=\"tab\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1375, "\"", 1402, 2);
            WriteAttributeValue("", 1382, "#", 1382, 1, true);
#line 28 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 1383, submenu.Mnu_Action, 1383, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1403, 12, true);
            WriteLiteral(" role=\"tab\">");
            EndContext();
            BeginContext(1416, 16, false);
#line 28 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                                                                                        Write(submenu.MenuName);

#line default
#line hidden
            EndContext();
            BeginContext(1432, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 29 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                            }

#line default
#line hidden
            BeginContext(1485, 44, true);
            WriteLiteral("                                            ");
            EndContext();
            BeginContext(1939, 253, true);
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                    <div class=\"col-7 col-sm-9\">\r\n                                        <div class=\"tab-content\" id=\"vert-tabs-tabContent\">\r\n");
            EndContext();
#line 36 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                             foreach (var submenu in UserMenus.Where(x => x.ParentMenuId == 4011).ToList())
                                            {
                                                if (count == 0)
                                                {

#line default
#line hidden
            BeginContext(2480, 61, true);
            WriteLiteral("                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2541, "\"", 2569, 2);
            WriteAttributeValue("", 2546, "Add_", 2546, 4, true);
#line 40 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 2550, submenu.Mnu_Action, 2550, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2570, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2572, 21, false);
#line 40 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                                                      Write(submenu.IS_ADD_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2593, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2660, "\"", 2689, 2);
            WriteAttributeValue("", 2665, "Edit_", 2665, 5, true);
#line 41 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 2670, submenu.Mnu_Action, 2670, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2690, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2692, 22, false);
#line 41 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                                                       Write(submenu.IS_EDIT_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2714, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2781, "\"", 2812, 2);
            WriteAttributeValue("", 2786, "Delete_", 2786, 7, true);
#line 42 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 2793, submenu.Mnu_Action, 2793, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2813, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2815, 24, false);
#line 42 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                                                         Write(submenu.IS_DELETE_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2839, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(2847, 80, true);
            WriteLiteral("                                                    <div class=\"tab-pane active\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2927, "\"", 2951, 1);
#line 44 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 2932, submenu.Mnu_Action, 2932, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2952, 19, true);
            WriteLiteral(" role=\"tabpanel\">\r\n");
            EndContext();
#line 45 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                          
                                                            Html.RenderPartial("_" + submenu.Mnu_Action, "");
                                                        

#line default
#line hidden
            BeginContext(3201, 56, true);
            WriteLiteral("                                                        ");
            EndContext();
            BeginContext(3312, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3420, 60, true);
            WriteLiteral("                                                    </div>\r\n");
            EndContext();
#line 51 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                    count++;
                                                }
                                                else
                                                {

#line default
#line hidden
            BeginContext(3698, 61, true);
            WriteLiteral("                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3759, "\"", 3787, 2);
            WriteAttributeValue("", 3764, "Add_", 3764, 4, true);
#line 55 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 3768, submenu.Mnu_Action, 3768, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3788, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3790, 21, false);
#line 55 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                                                      Write(submenu.IS_ADD_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(3811, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3878, "\"", 3907, 2);
            WriteAttributeValue("", 3883, "Edit_", 3883, 5, true);
#line 56 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 3888, submenu.Mnu_Action, 3888, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3908, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3910, 22, false);
#line 56 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                                                       Write(submenu.IS_EDIT_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(3932, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3999, "\"", 4030, 2);
            WriteAttributeValue("", 4004, "Delete_", 4004, 7, true);
#line 57 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 4011, submenu.Mnu_Action, 4011, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4031, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4033, 24, false);
#line 57 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                                                         Write(submenu.IS_DELETE_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(4057, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(4065, 73, true);
            WriteLiteral("                                                    <div class=\"tab-pane\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4138, "\"", 4162, 1);
#line 59 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
WriteAttributeValue("", 4143, submenu.Mnu_Action, 4143, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4163, 21, true);
            WriteLiteral(" role=\"tabpanel\">\r\n\r\n");
            EndContext();
            BeginContext(4294, 60, true);
            WriteLiteral("                                                    </div>\r\n");
            EndContext();
#line 63 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
                                                }
                                            }

#line default
#line hidden
            BeginContext(4452, 294, true);
            WriteLiteral(@"
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
");
            EndContext();
            BeginContext(4748, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(4756, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f359b57182c4c37a509c4612143d656", async() => {
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
            EndContext();
            BeginContext(4815, 1211, true);
            WriteLiteral(@"
        <script type=""text/javascript"">
            $('#tabstrip a').click(function (e) {
                e.preventDefault()
                var tabID = $(this).attr(""href"").substr(1);
                //alert(tabID);
                $("".tab-pane"").each(function () {
                    //console.log(""clearing "" + $(this).attr(""id"") + "" tab"");
                    $(this).empty();
                });
                //debugger;
                $.ajax({
                    type: ""GET"",
                    url: ""MasterSetting/"" + tabID,
                    cache: false,
                    data: {
                        val: tabID
                    },
                    contentType: 'application/html; charset=utf-8',
                    dataType: ""html"",
                    success: function (msg) {
                        // debugger;
                        $(""#"" + tabID).html(msg);
                        // alert(tabID);
                    },
                    error: function ");
            WriteLiteral("(jqXHR, textStatus, errorThrown) {\r\n                        alert(\"get session failed \" + errorThrown);\r\n                    }\r\n                });\r\n\r\n            });\r\n        </script>\r\n");
            EndContext();
#line 108 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Views\Lead\Index.cshtml"
    }

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
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
