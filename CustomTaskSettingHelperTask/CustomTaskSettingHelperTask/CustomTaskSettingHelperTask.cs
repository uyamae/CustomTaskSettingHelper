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
        public string InputFile { get; set; }
        [Required]
        public string PropsFile { get; set; }
        [Required]
        public string TargetsFile { get; set; }

        public override bool Execute()
        {
            return false;
        }
    }
}
