using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5_rpm
{
    public abstract class FileSystemItem
    {
        private string _name;
        public string Name {
            get { return _name; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be empty");
                }
                _name = value;
            }
        }

        public FileSystemItem(string name)
        {
            Name = name;
        }

        public abstract long GetSize();
        public abstract void Add(FileSystemItem item);
        public abstract void Remove(FileSystemItem item);
        public abstract FileSystemItem? GetChild(int index);
    }
}
