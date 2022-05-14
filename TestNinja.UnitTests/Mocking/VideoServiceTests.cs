using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mock
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProccessed_ReturnEmptyString()
        {
            _videoRepository.Setup(r => r.GetUnproccessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnproccessedVideos_ReturnStringWithIdsOfUnproccessedVideos()
        {
            _videoRepository.Setup(r => r.GetUnproccessedVideos()).Returns(new List<Video>()
            {
                new Video() { Id = 1},
                new Video() { Id = 2},
                new Video() { Id = 3},
            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
