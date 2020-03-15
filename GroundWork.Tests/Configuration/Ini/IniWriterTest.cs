using GroundWork.Configuration.Ini;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace GroundWork.Tests.Configuration.Ini
{
    /// <summary>
    /// INI writer test.
    /// </summary>
    [TestClass]
    public class IniWriterTest
    {
        /// <summary>
        /// Write small INI file.
        /// </summary>
        [TestMethod]
        public void WriteSmallIniFile()
        {
            var iniConfiguration = new IniConfiguration(new List<IniSection>()
            {
                new IniSection("MySection", new List<IniProperty>()
                {
                    new IniProperty("Key", "Value"),
                }),
            });

            var memoryStream = new MemoryStream();

            var iniWriter = new IniWriter(memoryStream);
            iniWriter.WriteIniConfiguration(iniConfiguration);
            iniWriter.Flush();

            memoryStream.Seek(0, SeekOrigin.Begin);

            var iniText = new StreamReader(memoryStream).ReadToEnd();

            var expectedIniText =
                "[MySection]\r\n" +
                "Key=Value\r\n";

            Assert.AreEqual(expectedIniText, iniText);
        }
    }
}
