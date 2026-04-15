using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_rpm
{
    // Target
    public interface IFileSystem
    {
        List<string> ListItems(string path);
        byte[] ReadFile(string path);
        void WriteFile(string path, byte[] data);
        void DeleteItem(string path);
    }
    public class IFileSystemAdapter: IFileSystem
    {
        private FileSystemItem _root;

        public IFileSystemAdapter(FileSystemItem root)
        {
            _root = root;
        }

        private FileSystemItem? FindItem(string name, FileSystemItem? current = null)
        {
            if (current == null) current = _root;
            if (current.Name == name) return current;

            if (current is Folder folder)
            {
                for (int i = 0; ; i++)
                {
                    try
                    {
                        var child = folder.GetChild(i);
                        if (child.Name == name) return child;
                        var found = FindItem(name, child);
                        if (found != null) return found;
                    }
                    catch (IndexOutOfRangeException) { break; }
                }
            }
            return null;
        }
        public List<string> ListItems(string path)
        {
            var item = FindItem(path);
            if (item is not Folder folder) return new List<string>();

            var result = new List<string>();
            for (int i = 0; ; i++)  // ✅ Убрали i < 10
            {
                try
                {
                    var child = folder.GetChild(i);
                    if (child != null) result.Add(child.Name);
                }
                catch (IndexOutOfRangeException) { break; }  // ✅ Безопасный выход
            }
            return result;
        }
        public byte[] ReadFile(string path)
        {
            var item = FindItem(path);

            if (item == null)
            {
                return Array.Empty<byte>();
            }

            if (item is File file)
            {
                return new byte[file.GetSize()];
            }

            return Array.Empty<byte>();
        }
        public void WriteFile(string path, byte[] data)
        {
            Console.WriteLine($"The file is written to the path: {path}.\nFile size is {data.Length}");
        }

        public void DeleteItem(string path)
        {
            var item = FindItem(path);  // Ищем сам элемент
            if (item == null) return;

            // Ищем ПАПА-ПАПКУ (другой метод!)
            var parent = FindParent(item, _root);

            if (parent is Folder parentFolder)
            {
                parentFolder.Remove(item);  // ✅ Удаляем из родителя
            }
        }

        // Вспомогательный метод: ищет, в какой папке лежит target
        private Folder? FindParent(FileSystemItem target, FileSystemItem current)
        {
            if (current is Folder folder)
            {
                for (int i = 0; ; i++)
                {
                    try
                    {
                        var child = folder.GetChild(i);
                        if (child == target) return folder;  // Нашли!
                        if (child is Folder sub)
                        {
                            var found = FindParent(target, sub);
                            if (found != null) return found;
                        }
                    }
                    catch (IndexOutOfRangeException) { break; }
                }
            }
            return null;
        }
    }
}
