﻿using System.Collections.Generic;
using Aljurythm;

namespace Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var jury = new Jury
            {
                Name = "Sum Algorithm",
                Levels = new List<Level>
                {
                    new Level
                    {
                        Name = "Sample Cases",
                        Path = @"Tests/sample.txt",
                        TimeLimit = 12,
                        MultiplierFactor = 1E6,
                        DisplayInputs = true
                    },
                    new Level
                    {
                        Path = @"Tests/complete.txt",
                        TimeLimit = 8
                    }
                }
            };

            jury.DisplayMenu();
            jury.Evaluate((level, streamReader) =>
            {
                // Create an instance from TestCase using the type of the result.
                var testCase = new TestCase<int>();

                // Specify how to read a single test case (input and expected result)
                // from the Level's file, using streamReader to read the file.
                var operands = streamReader.ReadLine().Split(' ');
                var operand1 = int.Parse(operands[0]);
                var operand2 = int.Parse(operands[1]);

                // Assign TestCase's expected value
                testCase.Expected = int.Parse(streamReader.ReadLine());

                // Used in Displaying inputs if level.DisplayInputs == true [optional]
                testCase.Inputs.Multiline = false;
                testCase.Inputs.AddInput(() => operand1);
                testCase.Inputs.AddInput(() => operand2);

                // Test the required Algorithms using the inputs as follow:
                // P.S: You can multiply the runtime to make sure the order is as required.
                testCase.Test(() => RunAlgorithm(operand1, operand2), level.MultiplierFactor);
                return testCase;
            });

        }

        private static int RunAlgorithm(int x, int y) => x + y;
    }
}
