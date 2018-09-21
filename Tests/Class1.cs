using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        [TestCaseSource(nameof(das))]
        public void asd(int a)
        {
            a.Should().Be(1);
        }

        private static IEnumerable<TestCaseData> das
        {
            get
            {
                yield return new TestCaseData(1).SetName("123");
                yield return new TestCaseData(2).SetName("123");
            }
        }
    }
}
