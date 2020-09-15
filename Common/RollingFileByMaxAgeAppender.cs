using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Appender;
using System.IO;

namespace Quickstarts.DataAccessClient.Common
{
    public class RollingFileByMaxAgeAppender : RollingFileAppender
    {
        protected override void AdjustFileBeforeAppend()
        {
            base.AdjustFileBeforeAppend();

            if (RollingStyle != RollingMode.Date) return;

            Directory.GetFiles(Path.GetDirectoryName(File), $"*{Path.GetFileNameWithoutExtension(File)}*{Path.GetExtension(File)}*")
                .ToList()
                .ForEach(f =>
                {
                    if (System.IO.File.GetLastWriteTime(f) < DateTime.Today.AddDays(-1 * MaxSizeRollBackups))
                        DeleteFile(f);
                });
        }
    }
}
