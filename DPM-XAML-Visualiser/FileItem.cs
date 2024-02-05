using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM_XAML_Visualiser
{
    internal class FileItem : Item
    {
        public string FileType { get; set; }

        public FileItem(string name, string fileType) : base(name)
        {
            FileType = fileType;
        }
    }
}