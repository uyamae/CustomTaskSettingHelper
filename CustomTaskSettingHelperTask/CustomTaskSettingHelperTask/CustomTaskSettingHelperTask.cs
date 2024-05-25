using System;
using Microsoft.Build.Utilities;

namespace CustomTaskSettingHelperTask
{
    /// <summary>
    /// Help MSBuild Custom Task class to setting props/targets.
    /// </summary>
    public class CustomTaskSettingHelperTask : Task
    {
        public override bool Execute()
        {
            return false;
        }
    }
}
