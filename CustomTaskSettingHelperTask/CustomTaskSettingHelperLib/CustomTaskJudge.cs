using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CustomTaskSettingHelperLib
{
    /// <summary>
    /// Judgement cs file contains Custom Task class
    /// </summary>
    public class CustomTaskJudge
    {
        /// <summary>
        /// Judgement cs file contains Custom Task class
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>If cs file cotains Custom Task class returns true.</returns>
        bool JudgementCSharpFileContainsCustomTask(string filePath)
        {
            var programText = File.ReadAllText(filePath);
            var tree = CSharpSyntaxTree.ParseText(programText);
            var root = tree.GetCompilationUnitRoot();

            var compilation = CSharpCompilation.Create("CustomTask")
                                               .AddReferences(MetadataReference.CreateFromFile(typeof(Microsoft.Build.Framework.ITask).Assembly.Location))
                                               .AddSyntaxTrees(tree);
            var semanticModel = compilation.GetSemanticModel(tree);
            return false;
        }
    }
}
