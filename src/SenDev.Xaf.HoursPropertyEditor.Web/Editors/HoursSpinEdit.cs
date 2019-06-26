using DevExpress.Web;
using System;
using System.Globalization;

namespace SenDev.Xaf.HoursPropertyEditor.Web.Editors
{
    public class HoursSpinEdit : ASPxButtonEdit
    {

        public const string ScriptResourceName = "SenDev.Xaf.HoursPropertyEditor.Web.Editors.HoursSpinEdit.js";

        public HoursSpinEdit()
        {
            ClientSideEvents.Validation = "function(s,e) { try {e.value = convertHours(e.value); } catch(error) {e.isValid = false; } }";
            DisplayFormatString = "{0:N2}";
        }


        public override object Value
        {
            get => base.Value;
            set
            {
                base.Value = Convert.ToDouble(value, CultureInfo.InvariantCulture);
            }
        }
        public override void RegisterEditorIncludeScripts()
        {
            base.RegisterEditorIncludeScripts();
            var resourceNames = typeof(HoursSpinEdit).Assembly.GetManifestResourceNames();
            RegisterIncludeScript(typeof(HoursSpinEdit), typeof(HoursSpinEdit).FullName + ".js");
        }


    }

}

