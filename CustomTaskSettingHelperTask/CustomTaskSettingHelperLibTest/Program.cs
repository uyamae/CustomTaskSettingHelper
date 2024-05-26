using CustomTaskSettingHelperLib;

namespace CustomTaskSettingHelperLibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string programText = @"using Microsoft.Build.Utilities;

namespace Test
{
    public class MyTask : Task
    {
        public override bool Execute()
        {
            return true;
        }
    }
}
";
            CustomTaskJudge.JudgementCSharpFileContainsCustomTask(programText);
        }
    }
}
