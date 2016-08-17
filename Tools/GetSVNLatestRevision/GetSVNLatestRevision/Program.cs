using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace GetSVNLatestRevision
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                SVNWrapper wrapper = new SVNWrapper(args[0], args[1], args[2]);
                long version = wrapper.GetLatestVersion();

                string pathToAssembly = args[3].Remove(0, 16) + "\\AssemblyInfo.cs";

                if (File.Exists(pathToAssembly) == true)
                {
                    string content = File.ReadAllText(pathToAssembly);
                    //content = content.Replace("000000", version.ToString());

                    content = Regex.Replace(content, "(\\d+)\\.(\\d+)\\.(\\d+)\\.(\\d+)", "$1.$2.$3." + version.ToString());

                    File.WriteAllText(pathToAssembly, content);
                }
            }
            else
            {
                Console.WriteLine("Parameters must be used in order:");
                Console.WriteLine("/target: Repository URL");
                Console.WriteLine("/basepath: Path to the intial folder mapped to the repository URL");
                Console.WriteLine("/currentpath: Folder to get latest revision on starting on current folder. Example: .");
                Console.WriteLine("/pathtoassembly: Path from current folder to AssemblyInfo.cs. Example: ..\\..\\..\\..\\..\\SolutionFolder\\ProjectFolder\\Properties");
            }
        }
    }
}
