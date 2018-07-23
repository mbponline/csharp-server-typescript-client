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
            Assert.AreEqual(GeneratorUtils.Pluralize("file"), "files");
            Assert.AreEqual(GeneratorUtils.Pluralize("centre"), "centres");
            Assert.AreEqual(GeneratorUtils.Pluralize("girl"), "girls");
            Assert.AreEqual(GeneratorUtils.Pluralize("book"), "books");
            Assert.AreEqual(GeneratorUtils.Pluralize("computer"), "computers");
            Assert.AreEqual(GeneratorUtils.Pluralize("ambition"), "ambitions");

            Assert.AreEqual(GeneratorUtils.Pluralize("wash"), "washes");
            Assert.AreEqual(GeneratorUtils.Pluralize("box"), "boxes");
            Assert.AreEqual(GeneratorUtils.Pluralize("match"), "matches");
            Assert.AreEqual(GeneratorUtils.Pluralize("glass"), "glasses");
            Assert.AreEqual(GeneratorUtils.Pluralize("bus"), "buses");
            Assert.AreEqual(GeneratorUtils.Pluralize("business"), "businesses");

            Assert.AreEqual(GeneratorUtils.Pluralize("knife"), "knives");
            Assert.AreEqual(GeneratorUtils.Pluralize("life"), "lives");
            Assert.AreEqual(GeneratorUtils.Pluralize("wife"), "wives");
            Assert.AreEqual(GeneratorUtils.Pluralize("shelf"), "shelves");

            Assert.AreEqual(GeneratorUtils.Pluralize("cliff"), "cliffs");
            Assert.AreEqual(GeneratorUtils.Pluralize("sniff"), "sniffs");
            Assert.AreEqual(GeneratorUtils.Pluralize("scoff"), "scoffs");
            Assert.AreEqual(GeneratorUtils.Pluralize("toff"), "toffs");
            Assert.AreEqual(GeneratorUtils.Pluralize("stiff"), "stiffs");
            Assert.AreEqual(GeneratorUtils.Pluralize("tiff"), "tiffs");

            Assert.AreEqual(GeneratorUtils.Pluralize("boy"), "boys");
            Assert.AreEqual(GeneratorUtils.Pluralize("journey"), "journeys");
            Assert.AreEqual(GeneratorUtils.Pluralize("key"), "keys");
            Assert.AreEqual(GeneratorUtils.Pluralize("tray"), "trays");

            Assert.AreEqual(GeneratorUtils.Pluralize("country"), "countries");
            Assert.AreEqual(GeneratorUtils.Pluralize("baby"), "babies");
            Assert.AreEqual(GeneratorUtils.Pluralize("body"), "bodies");
            Assert.AreEqual(GeneratorUtils.Pluralize("memory"), "memories");

            Assert.AreEqual(GeneratorUtils.Pluralize("radio"), "radios");
            Assert.AreEqual(GeneratorUtils.Pluralize("stereo"), "stereos");
            Assert.AreEqual(GeneratorUtils.Pluralize("video"), "videos");

            Assert.AreEqual(GeneratorUtils.Pluralize("hero"), "heroes");
            Assert.AreEqual(GeneratorUtils.Pluralize("potato"), "potatoes");
            Assert.AreEqual(GeneratorUtils.Pluralize("volcano"), "volcanoes");
            Assert.AreEqual(GeneratorUtils.Pluralize("tomato"), "tomatoes");

            Assert.AreEqual(GeneratorUtils.Pluralize("car"), "cars");
            Assert.AreEqual(GeneratorUtils.Pluralize("penny"), "pennies");
            Assert.AreEqual(GeneratorUtils.Pluralize("witness"), "witnesses");
            Assert.AreEqual(GeneratorUtils.Pluralize("waitress"), "waitresses");

            Assert.AreEqual(GeneratorUtils.Pluralize("address"), "addresses");
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