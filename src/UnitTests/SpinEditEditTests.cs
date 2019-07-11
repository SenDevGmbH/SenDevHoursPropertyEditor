using SenDev.Xaf.HoursPropertyEditor.Web.Editors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class SpinEditEditTests
    {
        [Fact]
        public void ValueConvertionTest()
        {
            HoursSpinEdit hoursSpinEdit = new HoursSpinEdit();
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");
            hoursSpinEdit.Value = "1,5";
            Assert.Equal(1.5, hoursSpinEdit.Value);
        }
    }
}
