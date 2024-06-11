using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDataParser.Main.Interfaces;

namespace GameDataParser.Main.DataProcessing
{
    public class FilePathProcessor: IStringInputProcessor
    {
        private string _processFileName = "";

        public string BasePath { get; private set; }

        public bool IsValid { get; private set; } = false;

        public string FileName
        { 
            get {

                if (!IsValid) 
                    throw new InvalidOperationException("Path or File name has not been processed");
                
                return _processFileName; 
            
            }

            private set { _processFileName = value; }
        }

        public string StatusMessage
        {
            get;
            private set;
        } = "";

        public FilePathProcessor(string basePath)
        {
            BasePath = basePath;
        }


        public void Process(string? input)
        {
            IsValid = false;

            switch (input)
            {
                case string i when i == "":
                    StatusMessage = "File name cannot be empty.";
                    break;
                case string i when !File.Exists(BasePath + i):
                    StatusMessage = "File not found.";
                    break;
                case string i when true:
                    IsValid = true;
                    FileName = input;
                    break;
                default:
                    StatusMessage = "File name cannot be null.";
                    break;
            }    

        }

    }
}
