using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Modules;

namespace ToolsTests.Modules
{
    [TestClass]
    public class GeneratorUtilsTests
    {
        [TestMethod]
        public void TestCamelCase()
        {
            Assert.AreEqual(GeneratorUtils.CamelCase("field name"), "FieldName");
            Assert.AreEqual(GeneratorUtils.CamelCase("another field_name"), "AnotherFieldName");
            Assert.AreEqual(GeneratorUtils.CamelCase("another field_name"), "AnotherFieldName");
            Assert.AreEqual(GeneratorUtils.CamelCase("another fieldName"), "AnotherFieldName");
        }

        [TestMethod]
        public void TestSingularize()
        {
            Assert.AreEqual(GeneratorUtils.Singularize("cars"), "car");
            Assert.AreEqual(GeneratorUtils.Singularize("car"), "car");
            Assert.AreEqual(GeneratorUtils.Singularize("witness"), "witness");
        }

        [TestMethod]
        public void TestPluralize()
        {
            Assert.AreEqual(GeneratorUtils.Pluralize("car"), "cars");
            Assert.AreEqual(GeneratorUtils.Pluralize("cars"), "cars");
            Assert.AreEqual(GeneratorUtils.Pluralize("penny"), "pennies");
            Assert.AreEqual(GeneratorUtils.Pluralize("witness"), "witnesses");
            Assert.AreEqual(GeneratorUtils.Pluralize("waitress"), "waitresses");
        }

        [TestMethod]
        public void TestToBoolean()
        {
            Assert.AreEqual(GeneratorUtils.ToBoolean(0), false);
            Assert.AreEqual(GeneratorUtils.ToBoolean(1), true);
            Assert.AreEqual(GeneratorUtils.ToBoolean(5), true);
            Assert.AreEqual(GeneratorUtils.ToBoolean(-1), false);
        }
    }
}