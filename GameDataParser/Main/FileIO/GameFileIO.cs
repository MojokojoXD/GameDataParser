using GameDataParser.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.Main.FileIO
{
    public class GameFileIO: IFileAccessable
    {
        public string Read(string path) => File.ReadAllText(path);

        public void Write(string path, IEnumerable<string> text) => File.AppendAllLines(path, text);
    }
}
