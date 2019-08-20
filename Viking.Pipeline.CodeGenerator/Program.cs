﻿using System;
using System.IO;

namespace Viking.Pipeline.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate("ReactionTemplate.txt", Environment.CurrentDirectory + @"\..\..\..\..\Viking.Pipeline\Generated\Reactions\ReactionPipelineStage$Number$.cs", 8);
            Generate("OperationTemplate.txt", Environment.CurrentDirectory + @"\..\..\..\..\Viking.Pipeline\Generated\Operations\OperationPipelineStage$Number$.cs", 8);
            //Testing.Test();
        }

        private static void Generate(string template, string toFile, int toGenerate)
        {
            var templateText = File.ReadAllText(template);

            var dir = Path.GetDirectoryName(toFile);
            var ss = Path.Combine(dir, "lol");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);


            for(int i = 1; i < toGenerate + 1; ++i)
            {
                var generator = new Generator(new PepeHands(i));
                var fileName = toFile.Replace("$Number$", i.ToString());
                File.WriteAllText(fileName, generator.GetString(templateText));
            }
        }
    }
}