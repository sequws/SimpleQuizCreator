using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuizCreator.Abstractions
{
    /// <summary>
    /// Global class for loaders all kind of data, contains:
    /// - global path for loaders
    /// </summary>
    public abstract class Loader : ErrorCollector
    {
        string dataPath;
        private const string mainDataFolder = "data"; // main folder for all loaders
        protected string loadDirectory;
        protected string extension = "*.*";

        public string DataFolder
        {
            get
            {
                return dataPath;
            }
        }

        public Loader() : this(string.Empty, "*.txt")
        {
            CreateDirectoryIfNotExist();
        }

        public Loader(string directory) : this(directory, "*.txt")
        {
        }

        public Loader(string directory, string extension)
        {
            this.extension = extension;

            loadDirectory = directory;
            dataPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, mainDataFolder, directory));

#if (DEBUG)
            dataPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\", mainDataFolder, directory));
#endif

            CreateDirectoryIfNotExist();
        }

        private void CreateDirectoryIfNotExist()
        {
            if (!Directory.Exists(DataFolder))
            {
                Directory.CreateDirectory(DataFolder);
            }
        }
    }
}
