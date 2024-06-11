using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.Main.Interfaces
{
    public interface IStringInputProcessor
    {
        bool IsValid { get; }
        void Process(string? input);
        string StatusMessage {  get; }
        string FileName { get; }

        string BasePath { get; }
    }
}
