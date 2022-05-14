using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IFileDownloader _filedownloader;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _filedownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _filedownloader.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}