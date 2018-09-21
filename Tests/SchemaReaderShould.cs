using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Autofac;
using FluentAssertions;
using Github.Drawer.Abstractions;
using Github.Drawer.Schema;
using NUnit.Framework;

namespace Tests
{
    public class SchemaReaderShould : BaseTest
    {
        protected ISchemaReader SchemaReader;
        protected string CorrectTestData;

        protected override void Setup()
        {
            SchemaReader = Container.Resolve<ISchemaReader>();
            CorrectTestData = "0000000000000000000000000000000000000000000000000000" +
                              "\n0000000000000000000000000000000000000000000000000000" +
                              "\n0000000000000000000000000000000000000000000000000000" +
                              "\n0000000000000000000000000000000000000000000000000000" +
                              "\n0000000000000000000000000000000000000000000000000000" +
                              "\n0000000000000000000000000000000000000000000000000000" +
                              "\n0000000000000000000000000000000000000000000000000000" +
                              "\n";
        }

        [Test]
        public void CorrectParse()
        {
            var bytes = Encoding.UTF8.GetBytes(CorrectTestData);
            var correctStream = new MemoryStream(bytes);

            var schema = SchemaReader.Read(correctStream);

            schema.ToString().Should().BeEquivalentTo(CorrectTestData);
        }

        [Test, TestCaseSource(nameof(ThrowableTestCases))]
        public void ThrowSchemaException(Stream incorrectStream)
        {
            Action act = () => SchemaReader.Read(incorrectStream);

            act.Should().Throw<SchemaException>();
        }

        private static IEnumerable<TestCaseData> ThrowableTestCases()
        {
            const string testDataWithSmallHeight = "0000000000000000000000000000000000000000000000000000" +
                                                  "\n0000000000000000000000000000000000000000000000000000" +
                                                  "\n0000000000000000000000000000000000000000000000000000" +
                                                  "\n0000000000000000000000000000000000000000000000000000" +
                                                  "\n0000000000000000000000000000000000000000000000000000" +
                                                  "\n0000000000000000000000000000000000000000000000000000" +
                                                  "\n";
            var bytes = Encoding.UTF8.GetBytes(testDataWithSmallHeight);
            var incorrectDataStream = new MemoryStream(bytes);
            yield return new TestCaseData(incorrectDataStream)
                .SetName("HeightSmallerThan7");

            const string testDataWithBigHeight = "0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n";
            bytes = Encoding.UTF8.GetBytes(testDataWithBigHeight);
            incorrectDataStream = new MemoryStream(bytes);
            yield return new TestCaseData(incorrectDataStream)
                .SetName("HeightBiggerThan7");
            const string testDataWithInCorrectSymbol= "5000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n0000000000000000000000000000000000000000000000000000" +
                                                "\n";
            bytes = Encoding.UTF8.GetBytes(testDataWithInCorrectSymbol);
            incorrectDataStream = new MemoryStream(bytes);
            yield return new TestCaseData(incorrectDataStream)
                .SetName("WithIncorrectSymbol");
        }

        [Test]
        [Ignore("Чтобы создать строку")]
        public void Test()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < 8; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    stringBuilder.Append('0');
                }

                stringBuilder.Append("\\n");
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}