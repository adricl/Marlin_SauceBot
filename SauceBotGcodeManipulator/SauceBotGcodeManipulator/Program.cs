using System;

namespace SauceBotGcodeManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
                throw new Exception("Required [GCode Filename], [relative true/false], [Prefix E,Z], [Movement Size]");

            var fileName = args[0];
            if (!bool.TryParse(args[1], out bool relative))
                throw new Exception("Required [GCode Filename], [relative true/false], [Prefix E,Z], [Movement Size]");

            var prefix = args[2];

            if (!Int32.TryParse(args[3], out int movementSize))
                throw new Exception("Required [GCode Filename], [relative true/false], [Prefix E,Z], [Movement Size]");

            var manipulator = new GcodeManipulator(fileName, relative, prefix, movementSize);
            manipulator.Run();
        }
    }
}
