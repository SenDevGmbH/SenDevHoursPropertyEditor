using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursPropertyEditor.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class WorkingTime : BaseObject
    {
        public WorkingTime(Session session) : base(session)
        {
        }


        private string text;
        public string Text
        {
            get => text;
            set => SetPropertyValue(nameof(Text), ref text, value);
        }

        private double hours;
        [EditorAlias("HoursEditor")]
        public double Hours
        {
            get => hours;
            set => SetPropertyValue(nameof(Hours), ref hours, value);
        }
    }
}
