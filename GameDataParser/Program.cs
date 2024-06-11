using GameDataParser.Main;
using GameDataParser.Main.Dialog;
using GameDataParser.Main.DataProcessing;
using GameDataParser.Main.FileIO;


namespace GameDataParser
{
    internal class Program
    {
        const string GameFolderBasePath = "jsonFiles/";

        const string LogFilePath = "log.txt";
        static void Main(string[] args)
        {

            var consoleDialog = new ConsoleDialog();

            var logger = new Logger(
                    LogFilePath,
                    new GameFileIO()
                );

            var gameParser = new GameParser(
                    consoleDialog,
                    new FilePathProcessor(GameFolderBasePath),
                    new GameFileIO()
                );

            try
            {
                gameParser.Run();
            }
            catch(Exception ex )
            {
                _ = ex;

                logger.Log(ex);

                consoleDialog.Output("Sorry! The application has experienced " +
                    "an unexpected error and will have to be closed.");

                consoleDialog.Exit();
            }

        }



    }
}
