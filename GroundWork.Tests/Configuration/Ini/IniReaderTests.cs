using GroundWork.Configuration.Ini;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GroundWork.Tests.Configuration.Ini
{
    /// <summary>
    /// INI reader tests.
    /// </summary>
    [TestClass]
    public class IniReaderTests
    {
        /// <summary>
        /// Tests reading the small INI file.
        /// </summary>
        [TestMethod]
        public void ReadSmallIniFile()
        {
            var stream = EmbeddedResourceHelper.GetResourceStream("GroundWork.Tests.Configuration.Ini.Small.ini");
            var iniReader = new IniReader(stream);

            var iniConfiguration = iniReader.ReadIniConfiguration();

            Assert.IsNotNull(iniConfiguration);

            // [MySection]
            var section = iniConfiguration.Sections.First();
            Assert.IsNotNull(section);
            Assert.AreEqual("MySection", section.Name);

            // Key=Value
            var property = section.Properties.First();
            Assert.IsNotNull(property);
            AssertIniProperty("Key", "Value", property);
        }

        /// <summary>
        /// Tests reading the medium INI file.
        /// </summary>
        [TestMethod]
        public void ReadMediumIniFile()
        {
            var stream = EmbeddedResourceHelper.GetResourceStream("GroundWork.Tests.Configuration.Ini.Medium.ini");
            var iniReader = new IniReader(stream);

            var iniConfiguration = iniReader.ReadIniConfiguration();

            Assert.IsNotNull(iniConfiguration);
            Assert.AreEqual(2, iniConfiguration.Sections.Count());

            var sections = iniConfiguration.Sections.ToArray();
            Assert.IsNotNull(sections);

            IniSection section;
            IniProperty[] properties;

            // [Paths]
            section = sections[0];
            properties = section.Properties.ToArray();
            Assert.AreEqual("Paths", section.Name);
            Assert.AreEqual(2, properties.Length);
            // WindowsPath=C:\\windows\\tests
            AssertIniProperty("WindowsPath", @"C:\\windows\\tests", properties[0]);
            // LinuxPath=/home/user
            AssertIniProperty("LinuxPath", "/home/user", properties[1]);

            // [Numbers]
            section = sections[1];
            properties = section.Properties.ToArray();
            Assert.AreEqual("Numbers", section.Name);
            Assert.AreEqual(3, properties.Length);
            // Age=5
            AssertIniProperty("Age", "5", properties[0]);
            // Time=12pm
            AssertIniProperty("Time", "12pm", properties[1]);
            // Why=this?
            AssertIniProperty("Why", "this?", properties[2]);
        }

        /// <summary>
        /// Tests reading the big INI file.
        /// </summary>
        [TestMethod]
        public void ReadBigIniFile()
        {
            var stream = EmbeddedResourceHelper.GetResourceStream("GroundWork.Tests.Configuration.Ini.Big.ini");
            var iniReader = new IniReader(stream);

            var iniConfiguration = iniReader.ReadIniConfiguration();

            Assert.IsNotNull(iniConfiguration);
            Assert.AreEqual(4, iniConfiguration.Sections.Count());

            var sections = iniConfiguration.Sections.ToArray();
            Assert.IsNotNull(sections);

            IniSection section;
            IniProperty[] properties;

            // [Config]
            section = sections[0];
            properties = section.Properties.ToArray();
            Assert.AreEqual("Config", section.Name);
            Assert.AreEqual(3, properties.Length);
            // Path=/etc/test.config
            AssertIniProperty("Path", "/etc/test.config", properties[0]);
            // CacheTimeSpan=20min
            AssertIniProperty("CacheTimeSpan", "20min", properties[1]);
            // IgnoreExtensions=mp3, mp4, txt
            AssertIniProperty("IgnoreExtensions", "mp3, mp4, txt", properties[2]);

            // [LegacyConfig]
            section = sections[1];
            properties = section.Properties.ToArray();
            Assert.AreEqual("LegacyConfig", section.Name);
            Assert.AreEqual(3, properties.Length);
            // Path=/etc/legacyTest.config
            AssertIniProperty("Path", "/etc/legacyTest.config", properties[0]);
            // IgnoreExtensions=doc, tex
            AssertIniProperty("IgnoreExtensions", "doc, tex", properties[1]);
            // CrashAgent=crash-agent.exe
            AssertIniProperty("CrashAgent", "crash-agent.exe", properties[2]);

            // [Map]
            section = sections[2];
            properties = section.Properties.ToArray();
            Assert.AreEqual("Map", section.Name);
            Assert.AreEqual(4, properties.Length);
            // 1=5
            AssertIniProperty("1", "5", properties[0]);
            // 2=4
            AssertIniProperty("2", "4", properties[1]);
            // 4=10
            AssertIniProperty("4", "10", properties[2]);
            // 9=12
            AssertIniProperty("9", "12", properties[3]);

            // [Map2]
            section = sections[3];
            properties = section.Properties.ToArray();
            Assert.AreEqual("Map2", section.Name);
            Assert.AreEqual(4, properties.Length);
            // 8=9
            AssertIniProperty("8", "9", properties[0]);
            // 44=54
            AssertIniProperty("44", "54", properties[1]);
            // 32=140
            AssertIniProperty("32", "140", properties[2]);
            // 3=123
            AssertIniProperty("3", "123", properties[3]);
        }

        /// <summary>
        /// Asserts the given INI property.
        /// </summary>
        /// <param name="expectedName">Expected name.</param>
        /// <param name="expectedValue">Expected value.</param>
        /// <param name="property">INI property to assert.</param>
        void AssertIniProperty(string expectedName, string expectedValue, IniProperty property)
        {
            Assert.IsNotNull(property);
            Assert.AreEqual(expectedName, property.Name);
            Assert.AreEqual(expectedValue, property.Value);
        }
    }
}
