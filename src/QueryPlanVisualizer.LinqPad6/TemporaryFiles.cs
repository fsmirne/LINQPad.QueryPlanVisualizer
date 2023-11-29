using System;
using System.Collections.Generic;
using System.IO;

namespace ExecutionPlanVisualizer
{

    public class TemporaryFiles : IDisposable
    {
        private List<string> filesToDelete;
        private List<string> foldersToDelete;


        public TemporaryFiles()
        {
            filesToDelete = new List<string>();
            foldersToDelete = new List<string>();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            DeleteFiles();
        }

        ~TemporaryFiles()
        {
            Dispose(disposing: false);
        }

        public void AddFile(string fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));

            filesToDelete.Add(fileName);
        }


        public void AddFolder(string folderName)
        {
            if (String.IsNullOrWhiteSpace(folderName))
                throw new ArgumentNullException(nameof(folderName));

            foldersToDelete.Add(folderName);
        }

        public string GetTemporaryFileName()
        {
            var tempFile = Path.GetTempFileName();
            AddFile(tempFile);
            return tempFile;
        }

        public string CreateTemporaryFolder(string folderName = null)
        {
            if (String.IsNullOrWhiteSpace(folderName))
                folderName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            Directory.CreateDirectory(folderName);
            foldersToDelete.Add(folderName);

            return folderName;
        }


        private void Try(Action action)
        {
            try { action(); } catch { }
        }


        public void DeleteFiles()
        {
            filesToDelete.ForEach(fileName => Try(() => File.Delete(fileName)));
            filesToDelete.Clear();

            foldersToDelete.ForEach(folder => Try(() => Directory.Delete(folder)));
            foldersToDelete.Clear();
        }

    }
}
