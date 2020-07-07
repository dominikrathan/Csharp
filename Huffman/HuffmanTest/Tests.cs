using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace HuffmanTest
{
    
    public class TestFilesFixture
    {
        public string PathToRoot { get; private set; }
        public List<string[]> Calls { get; private set; }

        public TestFilesFixture()
        {
            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            PathToRoot = Path.Combine(projectDirectory, "TESTS");
            Calls = new List<string[]>();
            Calls.Add("-e binary.in".Split(' '));
            for (int i = 1; i < 5; i++)
            {
                Calls.Add($"-e simple{i}.in".Split(' '));
            }
        }
    }
    public class OutputTests : IClassFixture<TestFilesFixture>
    {
        private TestFilesFixture fixture;

        public OutputTests(TestFilesFixture fixture, ITestOutputHelper testOutputHelper)
        {
            this.fixture = fixture;
        }
        
        [Theory]
        [InlineData("binary.in")]
        [InlineData("simple.in")]
        [InlineData("simple2.in")]
        [InlineData("simple3.in")]
        [InlineData("simple4.in")]
        public void TestWholeOutputEncode(string inputFileName)
        {
            var inputFilePath = Path.Combine(fixture.PathToRoot, "Encode", inputFileName);
            Huffman.Program.Encode(new [] {"-e ", inputFilePath});
            
            var actualOutputPath = Path.Combine(fixture.PathToRoot, "Encode", inputFileName + ".huff");
            var expectedOutputPath = actualOutputPath + ".test";
            
            BinaryReader actualOutputReader = new BinaryReader(File.OpenRead(actualOutputPath));
            BinaryReader expectedOutputReader = new BinaryReader(File.OpenRead(expectedOutputPath));

            using (actualOutputReader)
            {
                using (expectedOutputReader)
                {
                    while (actualOutputReader.BaseStream.Position != actualOutputReader.BaseStream.Length &&
                           expectedOutputReader.BaseStream.Position != expectedOutputReader.BaseStream.Length)
                    {
                        var actualByte = actualOutputReader.ReadByte();
                        var expectedByte = expectedOutputReader.ReadByte();
                        Assert.Equal(actualByte,expectedByte);
                    }
                }
            }
        }

        [Theory]
        [InlineData("binary.in")]
        [InlineData("simple.in")]
        [InlineData("simple2.in")]
        [InlineData("simple3.in")]
        [InlineData("simple4.in")]
        public void TestWholeOutputDecode(string inputFileName)
        {
            var inputFilePath = Path.Combine(fixture.PathToRoot, "Decode", inputFileName + ".huff");
            Huffman.Program.Decode(new [] {"-d", inputFilePath});
            
            var actualOutputPath = Path.Combine(fixture.PathToRoot, "Decode", inputFileName);
            var expectedOutputPath = actualOutputPath + ".test";
            
            BinaryReader actualOutputReader = new BinaryReader(File.OpenRead(actualOutputPath));
            BinaryReader expectedOutputReader = new BinaryReader(File.OpenRead(expectedOutputPath));

            using (actualOutputReader) 
            {
                using (expectedOutputReader)
                {
                    while (actualOutputReader.BaseStream.Position != actualOutputReader.BaseStream.Length &&
                           expectedOutputReader.BaseStream.Position != expectedOutputReader.BaseStream.Length)
                    {
                        var actualByte = actualOutputReader.ReadByte();
                        var expectedByte = expectedOutputReader.ReadByte();
                        Assert.Equal(actualByte,expectedByte);
                    } 
                }
            }
           
        }
        
    }
}