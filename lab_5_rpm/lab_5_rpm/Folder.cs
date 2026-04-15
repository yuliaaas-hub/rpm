using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_5_rpm
{
    public class Folder : FileSystemItem
    {
        List<FileSystemItem> nodes = new List<FileSystemItem>();

        public Folder(string name) : base(name) { }
        public override void Add(FileSystemItem component)
        {
            nodes.Add(component);
        }
        public override void Remove(FileSystemItem component)
        {
            nodes.Remove(component);
        }
        public override FileSystemItem GetChild(int index)
        {
            return nodes[index];
        }
        public override long GetSize()
        {
            long totalSize = 0;
            foreach (var item in nodes)
            {
                totalSize += item.GetSize();
            }
            return totalSize;
        }
    }
}
