using SenDev.Xaf.HoursPropertyEditor.Web.Editors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class TimeConvertionTests
    {

        [Fact]
        public void TimeConvertionTest() => Assert.Equal(2.5f, ConvertHours("2h 30m"));

        [Fact]
        public void TimeConvertionGermanTest() => Assert.Equal(2.5f, ConvertHours("2s 30m"));

        [Fact]
        public void DecimalTest() => Assert.Equal(2.5f, ConvertHours("2,5"));

        [Fact]
        public void RoundingTest() => Assert.Equal(1.17d, ConvertHours("1h 10m"));

        [Fact]
        public void ColonTest() => Assert.Equal(2.5f, ConvertHours("2:30"));

        [Fact]
        public void IntTest() => Assert.Equal(2, ConvertHours("2"));

        private object ConvertHours(string inputString)
        {
            var engine = new Microsoft.ClearScript.V8.V8ScriptEngine();
            return engine.Evaluate(GetConvertScript() + $"convertHours('{inputString}')");
        }

        private string GetConvertScript()
        {
            using (var stream = typeof(HoursSpinEdit).Assembly.GetManifestResourceStream(HoursSpinEdit.ScriptResourceName))
            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }
    }
}
