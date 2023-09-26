#pragma checksum "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b62dfcd5a082e9bff1ff7b4e3dd3b9418fe26c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_UserAccess_Views_UserOperationAccess_Index), @"mvc.1.0.view", @"/Areas/UserAccess/Views/UserOperationAccess/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/UserAccess/Views/UserOperationAccess/Index.cshtml", typeof(AspNetCore.Areas_UserAccess_Views_UserOperationAccess_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
#line 2 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#line 5 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b62dfcd5a082e9bff1ff7b4e3dd3b9418fe26c7", @"/Areas/UserAccess/Views/UserOperationAccess/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa8ed71208807bc22424f19a81c0f0e1dd0c2e9b", @"/Areas/UserAccess/Views/_ViewImports.cshtml")]
    public class Areas_UserAccess_Views_UserOperationAccess_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 6 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    int count = 0;

#line default
#line hidden
            BeginContext(306, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
  
    string str = HttpContextAccessor.HttpContext.Session.GetString("UserMenus");
    List<MVCCoreDemo.Models.MenuModel> UserMenus = JsonConvert.DeserializeObject<List<MVCCoreDemo.Models.MenuModel>>(str);
    if (UserMenus != null)
    {

#line default
#line hidden
            BeginContext(553, 564, true);
            WriteLiteral(@"        <section class=""content"">
            <div class=""container-fluid"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <h4>Role Wise Menu</h4>
                        <div class=""card"">
                            <div class=""card-body"">
                                <div class=""row"">
                                    <div class=""col-5 col-sm-3"">
                                        <div id=""tabstrip"" class=""nav flex-column nav-tabs h-100"" role=""tablist"" aria-orientation=""vertical"">
");
            EndContext();
#line 26 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                             foreach (var submenu in UserMenus.Where(x => x.ParentMenuId == 5).ToList())
                                            {

#line default
#line hidden
            BeginContext(1286, 85, true);
            WriteLiteral("                                                <a class=\"nav-link\" data-toggle=\"tab\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1371, "\"", 1398, 2);
            WriteAttributeValue("", 1378, "#", 1378, 1, true);
#line 28 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 1379, submenu.Mnu_Action, 1379, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1399, 12, true);
            WriteLiteral(" role=\"tab\">");
            EndContext();
            BeginContext(1412, 16, false);
#line 28 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                                                                                        Write(submenu.MenuName);

#line default
#line hidden
            EndContext();
            BeginContext(1428, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 29 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                            }

#line default
#line hidden
            BeginContext(1481, 44, true);
            WriteLiteral("                                            ");
            EndContext();
            BeginContext(1935, 253, true);
            WriteLiteral("\r\n                                        </div>\r\n                                    </div>\r\n                                    <div class=\"col-7 col-sm-9\">\r\n                                        <div class=\"tab-content\" id=\"vert-tabs-tabContent\">\r\n");
            EndContext();
#line 36 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                             foreach (var submenu in UserMenus.Where(x => x.ParentMenuId == 5).ToList())
                                            {
                                                if (count == 0)
                                                {

#line default
#line hidden
            BeginContext(2473, 61, true);
            WriteLiteral("                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2534, "\"", 2562, 2);
            WriteAttributeValue("", 2539, "Add_", 2539, 4, true);
#line 40 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 2543, submenu.Mnu_Action, 2543, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2563, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2565, 21, false);
#line 40 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                                                      Write(submenu.IS_ADD_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2586, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2653, "\"", 2682, 2);
            WriteAttributeValue("", 2658, "Edit_", 2658, 5, true);
#line 41 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 2663, submenu.Mnu_Action, 2663, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2683, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2685, 22, false);
#line 41 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                                                       Write(submenu.IS_EDIT_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2707, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2774, "\"", 2805, 2);
            WriteAttributeValue("", 2779, "Delete_", 2779, 7, true);
#line 42 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 2786, submenu.Mnu_Action, 2786, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2806, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2808, 24, false);
#line 42 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                                                         Write(submenu.IS_DELETE_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(2832, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(2840, 80, true);
            WriteLiteral("                                                    <div class=\"tab-pane active\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2920, "\"", 2944, 1);
#line 44 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 2925, submenu.Mnu_Action, 2925, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2945, 19, true);
            WriteLiteral(" role=\"tabpanel\">\r\n");
            EndContext();
#line 45 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                          
                                                            Html.RenderPartial("_" + submenu.Mnu_Action, "");
                                                        

#line default
#line hidden
            BeginContext(3194, 56, true);
            WriteLiteral("                                                        ");
            EndContext();
            BeginContext(3305, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3413, 60, true);
            WriteLiteral("                                                    </div>\r\n");
            EndContext();
#line 51 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                    count++;
                                                }
                                                else
                                                {

#line default
#line hidden
            BeginContext(3691, 61, true);
            WriteLiteral("                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3752, "\"", 3780, 2);
            WriteAttributeValue("", 3757, "Add_", 3757, 4, true);
#line 55 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 3761, submenu.Mnu_Action, 3761, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3781, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3783, 21, false);
#line 55 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                                                      Write(submenu.IS_ADD_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(3804, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3871, "\"", 3900, 2);
            WriteAttributeValue("", 3876, "Edit_", 3876, 5, true);
#line 56 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 3881, submenu.Mnu_Action, 3881, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3901, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3903, 22, false);
#line 56 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                                                       Write(submenu.IS_EDIT_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(3925, 67, true);
            WriteLiteral("</p>\r\n                                                    <p hidden");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3992, "\"", 4023, 2);
            WriteAttributeValue("", 3997, "Delete_", 3997, 7, true);
#line 57 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 4004, submenu.Mnu_Action, 4004, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4024, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4026, 24, false);
#line 57 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
                                                                                         Write(submenu.IS_DELETE_ACCESS);

#line default
#line hidden
            EndContext();
            BeginContext(4050, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
            BeginContext(4058, 73, true);
            WriteLiteral("                                                    <div class=\"tab-pane\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4131, "\"", 4155, 1);
#line 59 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
WriteAttributeValue("", 4136, submenu.Mnu_Action, 4136, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4156, 21, true);
            WriteLiteral(" role=\"tabpanel\">\r\n\r\n");
            EndContext();
            BeginContext(4287, 60, true);
            WriteLiteral("                                                    </div>\r\n");
            EndContext();
#line 63 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"


                                                }
                                            }

#line default
#line hidden
            BeginContext(4449, 294, true);
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
            BeginContext(4745, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(4753, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ac989a7b4f34dab90dd77e9d25c4339", async() => {
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
            BeginContext(4812, 1217, true);
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
                    url: ""UserOperationAccess/"" + tabID,
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
                    error: fun");
            WriteLiteral("ction (jqXHR, textStatus, errorThrown) {\r\n                        alert(\"get session failed \" + errorThrown);\r\n                    }\r\n                });\r\n\r\n            });\r\n        </script>\r\n");
            EndContext();
#line 110 "C:\Users\vinay\source\repos\GymManagementSystem\MVCCoreDemo\Areas\UserAccess\Views\UserOperationAccess\Index.cshtml"
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
