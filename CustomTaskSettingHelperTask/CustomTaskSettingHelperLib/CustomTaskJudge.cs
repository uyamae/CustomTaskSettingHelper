using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CustomTaskSettingHelperLib
{
    /// <summary>
    /// Judgement cs file contains Custom Task class
    /// </summary>
    public static class CustomTaskJudge
    {
        /// <summary>
        /// Judgement cs file contains Custom Task class
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>If cs file cotains Custom Task class returns true.</returns>
        public static bool JudgementCSharpFileContainsCustomTaskFromFile(string filePath)
        {
            var programText = File.ReadAllText(filePath);
            return JudgementCSharpFileContainsCustomTask(programText);
        }
        /// <summary>
        /// Judgement programText contains Custom Task class
        /// </summary>
        /// <param name="programText"></param>
        /// <returns>If programText cotains Custom Task class returns true.</returns>
        public static bool JudgementCSharpFileContainsCustomTask(string programText)
        {
            var tree = CSharpSyntaxTree.ParseText(programText);
            var root = tree.GetCompilationUnitRoot();

            var compilation = CSharpCompilation.Create("CustomTask")
                                               .AddReferences(MetadataReference.CreateFromFile(typeof(Microsoft.Build.Utilities.Task).Assembly.Location))
                                               .AddSyntaxTrees(tree);
            var semanticModel = compilation.GetSemanticModel(tree);

            foreach (var classDeclarationSyntax in root.DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                var declaredSymbol = semanticModel.GetDeclaredSymbol(classDeclarationSyntax);
                var originalDefinition = declaredSymbol.BaseType.OriginalDefinition.ToString();
                if (originalDefinition == "Microsoft.Build.Utilities.Task")
                {
                    return true;
                }
                else if (originalDefinition == "Microsoft.Build.Framework.ITask")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
