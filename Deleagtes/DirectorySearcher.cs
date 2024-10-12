using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Deleagtes
{
    public class FileArgs : EventArgs
    {
        public string FileName { get; }
        public bool Cancel { get; set; }

        public FileArgs(string fileName)
        {
            FileName = fileName;
            Cancel = false;
        }
    }

    public class DirectorySearcher
    {
        public event EventHandler<FileArgs> FileFound;

        public void Search(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new DirectoryNotFoundException($"Директория  '{directory}' не найдена.");
            }

            foreach (var file in Directory.GetFiles(directory))
            {
                FileArgs args = new FileArgs(file);
                OnFileFound(args);

                if (args.Cancel)
                {
                    Console.WriteLine("Галя, у нас отмена");
                    break;
                }
            }
        }

        protected virtual void OnFileFound(FileArgs e)
        {
            FileFound?.Invoke(this, e);
        }
    }
}
