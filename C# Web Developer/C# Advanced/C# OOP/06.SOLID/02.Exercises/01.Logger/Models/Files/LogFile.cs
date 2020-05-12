using System;
using System.Globalization;
using System.IO;
using System.Linq;
using _01.Logger.Common;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;
using _01.Logger.Models.IOManagement;

namespace _01.Logger.Models.Files
{
    public class LogFile : IFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryAndFileExist();
        }

        //public ILayout Layout { get; }
        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        /// <summary>
        /// Returns formatted message in provided layout with provided error's data
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="error"></param>
        /// <returns></returns>

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format, dateTime
                .ToString(GlobalConstants.DATE_FORMAT,
                    CultureInfo.InvariantCulture), message, level.ToString()) + Environment.NewLine;

            return formattedMessage;
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            long size = text.Where(ch => char.IsLetter(ch)).Sum(ch => ch);

            return size;
        }
    }
}