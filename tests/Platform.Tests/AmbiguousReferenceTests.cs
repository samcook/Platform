using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Platform;

// ReSharper disable once CheckNamespace
namespace OtherNamespace.Platform.Tests
{
	[TestFixture]
	public class AmbiguousReferenceTests
	{
		/// <summary>
		/// The Prepend extension method exists natively in System.Linq from .NET Framework 4.7.2 onwards.
		/// Ensure that there is no ambiguity between the Platform and System.Linq methods in various target frameworks.
		/// </summary>
		[Test]
		public void Test_Prepend()
		{
			IEnumerable<string> enumerable = new List<string> { "a", "b", "c" };

			enumerable = enumerable.Prepend("d");

			Assert.AreEqual("d,a,b,c", enumerable.Fold((x, y) => x + "," + y));
		}
	}
}