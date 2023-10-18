#pragma checksum "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd1c22577754bf9b9925f727b365a8bf5fe84532"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd1c22577754bf9b9925f727b365a8bf5fe84532", @"/Areas/MasterSettings/Views/MasterSetting/Index.cshtml")]
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
            BeginContext(1400, 68, true);
            WriteLiteral(" role=\"tab\">\r\n                                                    <i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1468, "\"", 1496, 1);
#line 29 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 1476, submenu.IconCssName, 1476, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1497, 96, true);
            WriteLiteral("></i>\r\n                                                    <span class=\"hidden-xs-up text-dark\">");
            EndContext();
            BeginContext(1594, 16, false);
#line 30 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                    Write(submenu.MenuName);

#line default
#line hidden
            EndContext();
            BeginContext(1610, 63, true);
            WriteLiteral("</span>\r\n                                                </a>\r\n");
            EndContext();
#line 32 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                            }

#line default
#line hidden
            BeginContext(1720, 44, true);
            WriteLiteral("                                            ");
            EndContext();
            BeginContext(2134, 253, true);
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                    <div class=\"col-7 col-sm-9\">\r\n                                        <div class=\"tab-content\" id=\"vert-tabs-tabContent\">\r\n");
            EndContext();
#line 39 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                             foreach (var submenu in UserMenus.Where(x => x.ParentMenuId == 6).ToList())
                                            {
                                                if (count == 0)
                                                {

#line default
#line hidden
            BeginContext(2672, 61, true);
            WriteLiteral("                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2733, "\"", 2761, 2);
            WriteAttributeValue("", 2738, "Add_", 2738, 4, true);
#line 43 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 2742, submenu.Mnu_Action, 2742, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2762, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2764, 21, false);
#line 43 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                      Write(submenu.IS_ADD_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2785, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2852, "\"", 2881, 2);
            WriteAttributeValue("", 2857, "Edit_", 2857, 5, true);
#line 44 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 2862, submenu.Mnu_Action, 2862, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2882, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2884, 22, false);
#line 44 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                       Write(submenu.IS_EDIT_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2906, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2973, "\"", 3004, 2);
            WriteAttributeValue("", 2978, "Delete_", 2978, 7, true);
#line 45 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 2985, submenu.Mnu_Action, 2985, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3005, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3007, 24, false);
#line 45 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                         Write(submenu.IS_DELETE_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(3031, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(3039, 80, true);
            WriteLiteral("                                                    <div class=\"tab-pane active\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3119, "\"", 3143, 1);
#line 47 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 3124, submenu.Mnu_Action, 3124, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3144, 19, true);
            WriteLiteral(" role=\"tabpanel\">\r\n");
            EndContext();
#line 48 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                          
                                                            Html.RenderPartial("_" + submenu.Mnu_Action, "");
                                                        

#line default
#line hidden
            BeginContext(3393, 56, true);
            WriteLiteral("                                                        ");
            EndContext();
            BeginContext(3504, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3612, 60, true);
            WriteLiteral("                                                    </div>\r\n");
            EndContext();
#line 54 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                    count++;
                                                }
                                                else
                                                {

#line default
#line hidden
            BeginContext(3890, 61, true);
            WriteLiteral("                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3951, "\"", 3979, 2);
            WriteAttributeValue("", 3956, "Add_", 3956, 4, true);
#line 58 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 3960, submenu.Mnu_Action, 3960, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3980, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3982, 21, false);
#line 58 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                      Write(submenu.IS_ADD_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(4003, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4070, "\"", 4099, 2);
            WriteAttributeValue("", 4075, "Edit_", 4075, 5, true);
#line 59 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 4080, submenu.Mnu_Action, 4080, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4100, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4102, 22, false);
#line 59 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                       Write(submenu.IS_EDIT_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(4124, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4191, "\"", 4222, 2);
            WriteAttributeValue("", 4196, "Delete_", 4196, 7, true);
#line 60 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 4203, submenu.Mnu_Action, 4203, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4223, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4225, 24, false);
#line 60 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                                                         Write(submenu.IS_DELETE_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(4249, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(4257, 73, true);
            WriteLiteral("                                                    <div class=\"tab-pane\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4330, "\"", 4354, 1);
#line 62 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
WriteAttributeValue("", 4335, submenu.Mnu_Action, 4335, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4355, 21, true);
            WriteLiteral(" role=\"tabpanel\">\r\n\r\n");
            EndContext();
            BeginContext(4486, 60, true);
            WriteLiteral("                                                    </div>\r\n");
            EndContext();
#line 66 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
                                                }
                                            }

#line default
#line hidden
            BeginContext(4644, 294, true);
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
            BeginContext(4940, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(4948, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "54ab4a34f89e40cc971262f9408da5cc", async() => {
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
            BeginContext(5007, 1211, true);
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
#line 111 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\MasterSettings\Views\MasterSetting\Index.cshtml"
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
