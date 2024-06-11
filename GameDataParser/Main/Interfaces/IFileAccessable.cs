using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.Main.Interfaces
{
    public interface IFileAccessable
    {
        string Read(string path);

        void Write(string path, IEnumerable<string> text);

    }
}
