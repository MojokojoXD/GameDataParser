using GameDataParser.Main.DataProcessing;
using GameDataParser.Main.Interfaces;
using System.IO;
using System.Text.Json;
using GameDataParser.Main.GameTypes;

namespace GameDataParser.Main
{
    public class GameParser
    {

        private string _gameDataRaw = "";

        private IUserPromptable _userPrompter;

        private IFileAccessable _fileAccess;

        private IStringInputProcessor _pathProcessor;

        public GameParser(
            IUserPromptable userPrompter,
            IStringInputProcessor pathProcessor,
            IFileAccessable fileAccess
          )
        {
            _userPrompter = userPrompter;
            _pathProcessor = pathProcessor;
            _fileAccess = fileAccess;
        }

        public void Run() 
        {

            SetFileName();

            try
            {
                string gameDataPath = _pathProcessor.BasePath + _pathProcessor.FileName;

                _gameDataRaw = _fileAccess.Read(gameDataPath);

                var games = JsonSerializer.Deserialize<List<Game>>(_gameDataRaw);

                if (games is null || games.Count == 0)
                {
                    _userPrompter.Output("Games file is empty");
                    return;
                }

                _userPrompter.Output("Loaded games are:");

                foreach(var game in games)
                {
                    _userPrompter.Output(game.ToString());
                }

                _userPrompter.Exit();

            }
            catch (JsonException ex) 
            {

                _ = ex;

                _userPrompter.Output("JSON in the \"" + _pathProcessor.FileName
                    + "\" was not in a valid format. \nJSONbody:", true);

                _userPrompter.Output(_gameDataRaw);

                throw;

            }

        }

        private void SetFileName()
        {
            bool isPathValid = false;

            do
            {
                _userPrompter.Output("Enter the name of the "
                    + "file you want to read: ");
                var unprocessedFileName = _userPrompter.Input();

                _pathProcessor.Process(unprocessedFileName);

                if (!_pathProcessor.IsValid)
                {
                    _userPrompter.Output(_pathProcessor.StatusMessage);

                    _userPrompter.Output("");

                    continue;
                }

               isPathValid = true;

            } while (!isPathValid);

        }

    }
}
