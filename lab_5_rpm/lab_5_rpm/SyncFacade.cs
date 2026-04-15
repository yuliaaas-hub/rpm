using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_rpm
{
    // Facade для синхронизации папок
    public class SyncFacade
    {
        private IFileSystem _sourceFS;
        private IFileSystem _targetFS;
        public SyncFacade(IFileSystem source, IFileSystem target)
        {
            _sourceFS = source;
            _targetFS = target;
        }

        public void SyncFolder(string sourcePath, string targetPath)
        {
            var items = _sourceFS.ListItems(sourcePath);
            foreach (var item in items)
            {
                string sourceItemPath = $"{sourcePath}/{item}";
                string targetItemPath = $"{targetPath}/{item}";
                // Для каждого файла вызвать ReadFile
                byte[] data = _sourceFS.ReadFile(sourceItemPath);
                _targetFS.WriteFile(targetItemPath, data);
                //Вызываем WriteFile

                Console.WriteLine("Синхронизация завершена.");
            }
            
        }
        public void Backup(string sourcePath, string backupPath)
        {
            // Аналогично, но с обработкой исключений и т.д.
            Console.WriteLine("\n=== Backup started ===");

            int success = 0;
            int errors = 0;

            var items = _sourceFS.ListItems(sourcePath);

            foreach (var item in items)
            {
                try
                {
                    byte[] data = _sourceFS.ReadFile(item);
                    if (data.Length > 0)
                    {
                        _targetFS.WriteFile(item, data);
                        success++;
                        Console.WriteLine($"Backed up: {item}");
                    }
                }
                catch
                {
                    errors++;
                    Console.WriteLine($"Failed: {item}");
                }
            }

            Console.WriteLine($"\nDone! Success: {success}, Errors: {errors}");
            Console.WriteLine("Backup completed.\n");
        }
    }
}
