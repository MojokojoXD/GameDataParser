using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.Main.Interfaces
{
    public interface IUserPromptable
    {
        void Output(string message, bool isErrorMessage = false);

        string? Input();

        void Exit();
    }
}
