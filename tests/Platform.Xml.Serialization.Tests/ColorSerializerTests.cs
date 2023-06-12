using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;

namespace Platform.Xml.Serialization.Tests
{
    [TestFixture]
    public class ColorSerializerTests
    {
        public static IEnumerable<TestCaseData> ColorSerializerData()
        {
            yield return new TestCaseData(Color.Red, "Red");
            yield return new TestCaseData(Color.Blue, "Blue");
            yield return new TestCaseData(Color.Green, "Green");
            yield return new TestCaseData(Color.Black, "Black");
            yield return new TestCaseData(Color.White, "White");
            yield return new TestCaseData(Color.Yellow, "Yellow");
            yield return new TestCaseData(Color.Aquamarine, "Aquamarine");
            yield return new TestCaseData(Color.Beige, "Beige");
            yield return new TestCaseData(Color.LightGray, "LightGrey");
            yield return new TestCaseData(Color.Transparent, "Transparent");

            yield return new TestCaseData(SystemColors.MenuText, "menutext");
            yield return new TestCaseData(SystemColors.WindowFrame, "windowframe");

            yield return new TestCaseData(Color.FromArgb(0, 0, 0), "#000000");
            yield return new TestCaseData(Color.FromArgb(255, 255, 255), "#FFFFFF");
            yield return new TestCaseData(Color.FromArgb(255, 0, 0), "#FF0000");
            yield return new TestCaseData(Color.FromArgb(0, 255, 0), "#00FF00");
            yield return new TestCaseData(Color.FromArgb(0, 0, 255), "#0000FF");
            yield return new TestCaseData(Color.FromArgb(255, 255, 0), "#FFFF00");
            yield return new TestCaseData(Color.FromArgb(255, 0, 255), "#FF00FF");
            yield return new TestCaseData(Color.FromArgb(0, 255, 255), "#00FFFF");

        }

        [TestCaseSource(nameof(ColorSerializerData))]
        public void Test_Serialize(Color c, string expected)
        {
            var serializer = new ColorSerializer(typeof(Color), null, null, null);

            var result = serializer.Serialize(c, null);

            Assert.AreEqual(expected.ToLowerInvariant(), result.ToLowerInvariant());
        }

        [TestCaseSource(nameof(ColorSerializerData))]
        public void Test_Deserialize(Color expected, string s)
        {
            var serializer = new ColorSerializer(typeof(Color), null, null, null);

            var result = (Color) serializer.Deserialize(s, null);

            Assert.AreEqual(expected.A, result.A);
            Assert.AreEqual(expected.R, result.R);
            Assert.AreEqual(expected.G, result.G);
            Assert.AreEqual(expected.B, result.B);
        }
    }
}