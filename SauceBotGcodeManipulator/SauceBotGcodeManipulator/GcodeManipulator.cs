using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace SauceBotGcodeManipulator
{
    public class GcodeManipulator
    {
        private string fileName;
        private bool relative;
        private string prefix;
        private int movementSize;
        private string gcodeRegex = @"^(G0 |G1 |G2 |G3 )";
        public GcodeManipulator(string fileName, bool relative, string prefix, int movementSize)
        {
            this.fileName = fileName;
            this.relative = relative;
            this.prefix = prefix;
            this.movementSize = movementSize;

            if (!File.Exists(fileName))
                throw new Exception("File does not exist");
        }

        public void Run()
        {
            var newLines = new List<string>();
            var regex = new Regex (gcodeRegex);
            var extruderPos = movementSize;

            var lines = File.ReadAllLines(fileName);
            foreach(var line in lines){

                if (regex.IsMatch(line)){
                    newLines.Add($"{line} {prefix}{extruderPos}");
                    if (relative)
                        extruderPos += movementSize;
                }
                else 
                    newLines.Add(line);
            }

            File.WriteAllText($"{fileName}_new", string.Join("\n", newLines));


        }
    }
}
