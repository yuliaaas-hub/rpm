using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_5_rpm
{
    public class File : FileSystemItem
    {
        public int FileSize;

        public File(string name, int fileSize) : base(name)
        {
            if (fileSize < 0)
            {
                throw new ArgumentException("File size cannot be negative");
            }
            FileSize = fileSize;
        }
        public override long GetSize()
        {
            return FileSize;
        }

        //У узла не может быть потомков
        public override void Add(FileSystemItem component)
        {
            throw new InvalidOperationException();
        }
        public override void Remove(FileSystemItem component)
        {
            throw new InvalidOperationException();
        }
        public override FileSystemItem GetChild(int index)
        {
            throw new InvalidOperationException();
        }
    }
}
