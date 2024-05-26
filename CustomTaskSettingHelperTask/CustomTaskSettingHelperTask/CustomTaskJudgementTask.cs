using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using CustomTaskSettingHelperLib;

namespace CustomTaskSettingHelperTask
{
    /// <summary>
    /// Judgement cs file contains Custom Task class
    /// </summary>
    public class CustomTaskJudgementTask : Task
    {
        /// <summary>
        /// CSharp file path 
        /// </summary>
        [Required]
        public string InputFile { get; set; }
        /// <summary>
        /// If a file read from InputFilePath contains CustomTask, Result will be set as same as InputFilePath
        /// </summary>
        [Output]
        public string Result { get; set; }
        public override bool Execute()
        {
            try
            {
                if (CustomTaskJudge.JudgementCSharpFileContainsCustomTaskFromFile(InputFile))
                {
                    Result = InputFile;
                }
            }
            catch (Exception e)
            {
                Log.LogErrorFromException(e);
                return false;
            }
            return true;
        }
    }
}
