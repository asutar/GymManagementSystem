#pragma checksum "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51fe84a9225cb19f6b6ed1c0cdefbef3a3a71e5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MasterSettings_Views_MasterSetting_Index), @"mvc.1.0.view", @"/Areas/MasterSettings/Views/MasterSetting/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/MasterSettings/Views/MasterSetting/Index.cshtml", typeof(AspNetCore.Areas_MasterSettings_Views_MasterSetting_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
#line 2 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 5 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51fe84a9225cb19f6b6ed1c0cdefbef3a3a71e5f", @"/Areas/MasterSettings/Views/MasterSetting/Index.cshtml")]
    public class Areas_MasterSettings_Views_MasterSetting_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 6 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    int count = 0;

#line default
#line hidden
            BeginContext(306, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
  
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
#line 26 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                             foreach (var submenu in UserMenus.Where(x => x.ParentMenuId == 6).ToList())
                                            {

#line default
#line hidden
            BeginContext(1287, 85, true);
            WriteLiteral("                                                <a class=\"nav-link\" data-toggle=\"tab\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1372, "\"", 1399, 2);
            WriteAttributeValue("", 1379, "#", 1379, 1, true);
#line 28 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 1380, submenu.Mnu_Action, 1380, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1400, 12, true);
            WriteLiteral(" role=\"tab\">");
            EndContext();
            BeginContext(1413, 16, false);
#line 28 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                                                        Write(submenu.MenuName);

#line default
#line hidden
            EndContext();
            BeginContext(1429, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 29 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                            }

#line default
#line hidden
            BeginContext(1482, 44, true);
            WriteLiteral("                                            ");
            EndContext();
            BeginContext(1936, 253, true);
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                    <div class=\"col-7 col-sm-9\">\r\n                                        <div class=\"tab-content\" id=\"vert-tabs-tabContent\">\r\n");
            EndContext();
#line 36 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                             foreach (var submenu in UserMenus.Where(x => x.ParentMenuId == 6).ToList())
                                            {
                                                if (count == 0)
                                                {

#line default
#line hidden
            BeginContext(2474, 61, true);
            WriteLiteral("                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2535, "\"", 2563, 2);
            WriteAttributeValue("", 2540, "Add_", 2540, 4, true);
#line 40 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 2544, submenu.Mnu_Action, 2544, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2564, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2566, 21, false);
#line 40 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                      Write(submenu.IS_ADD_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2587, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2654, "\"", 2683, 2);
            WriteAttributeValue("", 2659, "Edit_", 2659, 5, true);
#line 41 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 2664, submenu.Mnu_Action, 2664, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2684, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2686, 22, false);
#line 41 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                       Write(submenu.IS_EDIT_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2708, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2775, "\"", 2806, 2);
            WriteAttributeValue("", 2780, "Delete_", 2780, 7, true);
#line 42 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 2787, submenu.Mnu_Action, 2787, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2807, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2809, 24, false);
#line 42 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                         Write(submenu.IS_DELETE_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2833, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(2841, 80, true);
            WriteLiteral("                                                    <div class=\"tab-pane active\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2921, "\"", 2945, 1);
#line 44 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 2926, submenu.Mnu_Action, 2926, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2946, 19, true);
            WriteLiteral(" role=\"tabpanel\">\r\n");
            EndContext();
#line 45 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                          
                                                            Html.RenderPartial("_" + submenu.Mnu_Action, "");
                                                        

#line default
#line hidden
            BeginContext(3195, 56, true);
            WriteLiteral("                                                        ");
            EndContext();
            BeginContext(3306, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3414, 60, true);
            WriteLiteral("                                                    </div>\r\n");
            EndContext();
#line 51 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                    count++;
                                                }
                                                else
                                                {

#line default
#line hidden
            BeginContext(3692, 61, true);
            WriteLiteral("                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3753, "\"", 3781, 2);
            WriteAttributeValue("", 3758, "Add_", 3758, 4, true);
#line 55 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 3762, submenu.Mnu_Action, 3762, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3782, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3784, 21, false);
#line 55 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                      Write(submenu.IS_ADD_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(3805, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3872, "\"", 3901, 2);
            WriteAttributeValue("", 3877, "Edit_", 3877, 5, true);
#line 56 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 3882, submenu.Mnu_Action, 3882, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3902, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3904, 22, false);
#line 56 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                       Write(submenu.IS_EDIT_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(3926, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3993, "\"", 4024, 2);
            WriteAttributeValue("", 3998, "Delete_", 3998, 7, true);
#line 57 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 4005, submenu.Mnu_Action, 4005, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4025, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4027, 24, false);
#line 57 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                         Write(submenu.IS_DELETE_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(4051, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(4059, 73, true);
            WriteLiteral("                                                    <div class=\"tab-pane\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4132, "\"", 4156, 1);
#line 59 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 4137, submenu.Mnu_Action, 4137, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4157, 21, true);
            WriteLiteral(" role=\"tabpanel\">\r\n\r\n");
            EndContext();
            BeginContext(4288, 60, true);
            WriteLiteral("                                                    </div>\r\n");
            EndContext();
#line 63 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                }
                                            }

#line default
#line hidden
            BeginContext(4446, 294, true);
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
            BeginContext(4742, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(4750, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82494c475701436aadfe96bb2b64c348", async() => {
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
            BeginContext(4809, 1211, true);
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
#line 108 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
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
