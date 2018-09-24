using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Autofac;
using FluentAssertions;
using Github.Drawer.Abstractions;
using Github.Drawer.Schema;
using Xunit;

namespace Tests
{
    public class SchemaReaderShould : BaseTest
    {
        protected ISchemaReader SchemaReader;
        protected string CorrectTestData;

        public SchemaReaderShould()
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

        [Theory]
        [MemberData(nameof(CorrectTestCases))]
        private void Parse(TestCase testCase)
        {
            var schema = SchemaReader.Read((MemoryStream) testCase.Value);

            schema.ToString().Should().BeEquivalentTo((string) testCase.Expectation);
        }

        [Theory]
        [MemberData(nameof(InCorrectTestCases))]
        private void ParseThrows(TestCase testCase)
        {
            Assert.Throws((Type) testCase.Expectation, () => SchemaReader.Read((MemoryStream) testCase.Value));
        }

        public static IEnumerable<object[]> CorrectTestCases()
        {
            const string correctTestData = "0000000000000000000000000000000000000000000000000000" +
                                           "\n0000000000000000000000000000000000000000000000000000" +
                                           "\n0000000000000000000000000000000000000000000000000000" +
                                           "\n0000000000000000000000000000000000000000000000000000" +
                                           "\n0000000000000000000000000000000000000000000000000000" +
                                           "\n0000000000000000000000000000000000000000000000000000" +
                                           "\n0000000000000000000000000000000000000000000000000000" +
                                           "\n";
            yield return new object[]
            {
                new TestCase(CreateStream(correctTestData), correctTestData, "CorrectData"),
            };

            const string testDataWithInCorrectSymbol = "7000000000000000000000000000000000000000000000000000" +
                                                       "\n0000000000000000000000000000000000000000000000000000" +
                                                       "\n0000000000000000000000000000000000000000000000000000" +
                                                       "\n0000000000000000000000000000000000000000000000000000" +
                                                       "\n0000000000000000000000000000000000000000000000000000" +
                                                       "\n0000000000000000000000000000000000000000000000000000" +
                                                       "\n0000000000000000000000000000000000000000000000000000" +
                                                       "\n";
            yield return new object[]
            {
                new TestCase(CreateStream(testDataWithInCorrectSymbol), testDataWithInCorrectSymbol,
                    "ContainsIncorrectSymbol"),
            };
        }

        public static IEnumerable<object[]> InCorrectTestCases()
        {
            const string testDataWithSmallHeight = "0000000000000000000000000000000000000000000000000000" +
                                                   "\n0000000000000000000000000000000000000000000000000000" +
                                                   "\n0000000000000000000000000000000000000000000000000000" +
                                                   "\n0000000000000000000000000000000000000000000000000000" +
                                                   "\n0000000000000000000000000000000000000000000000000000" +
                                                   "\n0000000000000000000000000000000000000000000000000000" +
                                                   "\n";
            yield return new object[]
            {
                new TestCase(CreateStream(testDataWithSmallHeight), typeof(SchemaException), "HeightIsSmallerThan7"),
            };

            const string testDataWithBigHeight = "0000000000000000000000000000000000000000000000000000" +
                                                 "\n0000000000000000000000000000000000000000000000000000" +
                                                 "\n0000000000000000000000000000000000000000000000000000" +
                                                 "\n0000000000000000000000000000000000000000000000000000" +
                                                 "\n0000000000000000000000000000000000000000000000000000" +
                                                 "\n0000000000000000000000000000000000000000000000000000" +
                                                 "\n0000000000000000000000000000000000000000000000000000" +
                                                 "\n0000000000000000000000000000000000000000000000000000" +
                                                 "\n";
            yield return new object[]
            {
                new TestCase(CreateStream(testDataWithBigHeight), typeof(SchemaException), "HeightIsBiggerThan7"),
            };
        }

        private static MemoryStream CreateStream(string dataString)
        {
            var bytes = Encoding.UTF8.GetBytes(dataString);
            return new MemoryStream(bytes);
        }

        [Fact(Skip = "Чтобы создать строку")]
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