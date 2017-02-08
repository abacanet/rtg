﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Serenity.CodeGenerator.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class EntityScriptDialogTS : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

    public dynamic Model { get; set; }
    public Serenity.CodeGenerator.GeneratorConfig Config { get; set; }

        public override void Execute()
        {


WriteLiteral("\r\n");



   
    var dotModule = Model.Module == null ? "" : ("." + Model.Module);


WriteLiteral("namespace ");


      Write(Model.RootNamespace);


                            Write(dotModule);

WriteLiteral(" {\r\n\r\n    ");


WriteLiteral("@Serenity.Decorators.registerClass()\r\n    ");


WriteLiteral("@Serenity.Decorators.responsive()\r\n");


 if (Config.MaximizableDialog)
{
WriteLiteral("    ");


WriteLiteral("@Serenity.Decorators.maximizable()");

WriteLiteral("\r\n");


}

WriteLiteral("    export class ");


             Write(Model.ClassName);

WriteLiteral("Dialog extends Serenity.EntityDialog<");


                                                                    Write(Model.RowClassName);

WriteLiteral(", any> {\r\n        protected getFormKey() { return ");


                                    Write(Model.ClassName);


                                                          WriteLiteral("Form.formKey; }");

                                                                          if (Model.Identity != null)
        {
WriteLiteral("\r\n        protected getIdProperty() { return ");


                                       Write(Model.RowClassName);

WriteLiteral(".idProperty; }");


                                                                                     }

WriteLiteral("\r\n        protected getLocalTextPrefix() { return ");


                                            Write(Model.RowClassName);


                                                                     WriteLiteral(".localTextPrefix; }");

                                                                                         if (Model.NameField != null)
        {
WriteLiteral("\r\n        protected getNameProperty() { return ");


                                         Write(Model.RowClassName);

WriteLiteral(".nameProperty; }");


                                                                                         }

WriteLiteral("\r\n        protected getService() { return ");


                                    Write(Model.ClassName);

WriteLiteral("Service.baseUrl; }\r\n\r\n        protected form = new ");


                         Write(Model.ClassName);

WriteLiteral("Form(this.idPrefix);\r\n\r\n");


         if (Config.MaximizableDialog)
        {
WriteLiteral("        ");

WriteLiteral("dialogOpen() {\r\n                    super.dialogOpen();\r\n                   this." +
"element.closest(\".ui-dialog\").find(\".ui-icon-maximize-window\").click();\r\n       " +
"          }");

WriteLiteral("\r\n");


        }

WriteLiteral("    }\r\n}");


        }
    }
}
#pragma warning restore 1591
