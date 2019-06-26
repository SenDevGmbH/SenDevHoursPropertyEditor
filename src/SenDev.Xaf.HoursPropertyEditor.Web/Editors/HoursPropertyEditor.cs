using System;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Persistent.Base;

namespace SenDev.Xaf.HoursPropertyEditor.Web.Editors
{
	[PropertyEditor(typeof(double), "HoursEditor", false)]
    public class HoursPropertyEditor : ASPxPropertyEditor
    {
        public HoursPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }

        protected override WebControl CreateEditModeControlCore()
        {
            var edit = new HoursSpinEdit();
            edit.ValueChanged += EditValueChangedHandler;
            RenderHelper.SetupASPxWebControl(edit);
            return edit;
        }

        public override void BreakLinksToControl(bool unwireEventsOnly)
        {
            base.BreakLinksToControl(unwireEventsOnly);
            if (Editor != null)
                Editor.ValueChanged -= EditValueChangedHandler;

        }
        public new HoursSpinEdit Editor => (HoursSpinEdit)base.Editor;

        protected override object GetControlValueCore()
        {
            object value = Editor?.Value;
            if (value == null)
            {
                return null;
            }
            return ReflectionHelper.Convert(value, MemberInfo.MemberType);
        }

        public override bool CanFormatPropertyValue => true;
    }

}

