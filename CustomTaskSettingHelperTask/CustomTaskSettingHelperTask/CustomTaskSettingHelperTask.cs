using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace CustomTaskSettingHelperTask
{
    /// <summary>
    /// Help MSBuild Custom Task class to setting props/targets.
    /// </summary>
    public class CustomTaskSettingHelperTask : Task
    {
        [Required]
        public string InputFilePaths { get; set; }
        [Required]
        public string PropsFilePath { get; set; }
        [Required]
        public string TargetsFilePath { get; set; }

        public override bool Execute()
        {
            return false;
        }
    }
}
