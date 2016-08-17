using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSvn;

namespace GetSVNLatestRevision
{
    class SVNWrapper
    {
        public string Target { get; set; }

        public SVNWrapper(string target, string basePath, string currentPath)
        {
            Target = target.Remove(0, 8) + System.IO.Path.GetFullPath(currentPath.Remove(0, 13)).Replace(basePath.Remove(0, 10), "").Replace("\\", "/");
        }

        public long GetLatestVersion()
        {
            long RevisionNumber = 0;

            SvnTarget svnTarget;

            Queue<SvnLogEventArgs> logItems = new Queue<SvnLogEventArgs>();

            if (string.IsNullOrEmpty(Target) || !SvnTarget.TryParse(Target, out svnTarget))
            {
                Console.WriteLine("The path you've specified is not valid. Please provide a valid URL or filesystem path pointing to a Subversion resource");
            }
            else
            {
                using (SvnClient svnClient = new SvnClient())
                {
                    try
                    {
                        svnClient.Log(svnTarget,
                            delegate(object lSender, SvnLogEventArgs le)
                            {
                                //le.Detach(); // detach from client

                                logItems.Enqueue(le);

                                //Console.WriteLine(le.Revision + "\t" + le.LogMessage);
                                // Optionally add items in a streaming way on the other thread
                                //InvokePopulateGrid();
                                /*
                                StringBuilder tooltip = new StringBuilder();

                                tooltip.AppendLine("Changed Paths:");

                                foreach (SvnChangeItem svnpath in le.ChangedPaths)
                                {
                                    tooltip.AppendLine("");
                                    tooltip.Append(svnpath.Action + " " + svnpath.Path);

                                    if (svnpath.CopyFromRevision != -1)
                                        tooltip.Append(" (" + svnpath.CopyFromPath +
                                            "[" + svnpath.CopyFromRevision + "])");
                                }

                                Console.WriteLine(tooltip.ToString());*/
                            });
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine(exc.InnerException);
                        Console.WriteLine(exc.StackTrace);
                    }
                }
            }

            if (logItems.Count > 0)
            {
                SvnLogEventArgs le = logItems.Dequeue();
                RevisionNumber = le.Revision;
            }
            return RevisionNumber;
        }
    }
}
