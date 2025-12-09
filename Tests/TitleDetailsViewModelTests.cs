using ImdbProject.Models;
using ImdbProject.Services.Interfaces;
using ImdbProject.ViewModels;
using Moq;

namespace Tests
{
    [TestClass]
    public sealed class TitleDetailsViewModelTests
    {
        private Mock<ITitleService> _mockTitleService = null!;
        private TitleDetailsViewModel _viewModel = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockTitleService = new Mock<ITitleService>();
            _viewModel = new TitleDetailsViewModel(_mockTitleService.Object);
        }

        [TestMethod]
        public async Task LoadTitleDetailsAsync_WithValidTitleId_ShouldPopulateSelectedTitle()
        {
            var testTitle = new Title
            {
                TitleId = "tt0000001",
                PrimaryTitle = "Test Movie",
                TitleType = "movie",
                StartYear = 2020,
                RuntimeMinutes = 120
            };

            _mockTitleService.Setup(s => s.GetTitleAsync("tt0000001"))
                .ReturnsAsync(testTitle);

            await _viewModel.LoadTitleDetailsAsync("tt0000001");

            Assert.IsNotNull(_viewModel.SelectedTitle);
            Assert.AreEqual("tt0000001", _viewModel.SelectedTitle.TitleId);
            Assert.AreEqual("Test Movie", _viewModel.SelectedTitle.PrimaryTitle);
            Assert.AreEqual("movie", _viewModel.SelectedTitle.TitleType);
            Assert.AreEqual((short)2020, _viewModel.SelectedTitle.StartYear);
        }

        [TestMethod]
        public async Task LoadTitleDetailsAsync_WithInvalidTitleId_ShouldNotSetSelectedTitle()
        {
            _mockTitleService.Setup(s => s.GetTitleAsync("tt9999999"))
                .ReturnsAsync((Title?)null);

            await _viewModel.LoadTitleDetailsAsync("tt9999999");

            Assert.IsNull(_viewModel.SelectedTitle);
        }

        [TestMethod]
        public async Task LoadTitleDetailsAsync_ShouldCallTitleServiceOnce()
        {
            var testTitle = new Title
            {
                TitleId = "tt0000002",
                PrimaryTitle = "Another Movie"
            };

            _mockTitleService.Setup(s => s.GetTitleAsync("tt0000002"))
                .ReturnsAsync(testTitle);

            await _viewModel.LoadTitleDetailsAsync("tt0000002");

            _mockTitleService.Verify(s => s.GetTitleAsync("tt0000002"), Times.Once);
        }

        [TestMethod]
        public void GoToNameDetails_ShouldInvokeNavigationEvent()
        {
            string? navigatedNameId = null;
            _viewModel.NavigateToNameDetails += (nameId) => navigatedNameId = nameId;
            string testNameId = "nm1234567";

            _viewModel.GoToNameDetailsCommand.Execute(testNameId);

            Assert.AreEqual(testNameId, navigatedNameId);
        }

        [TestMethod]
        public void GoToNameDetails_WithNoSubscriber_ShouldNotThrowException()
        {
            string testNameId = "nm1234567";

            _viewModel.GoToNameDetailsCommand.Execute(testNameId);
            Assert.IsTrue(true); // Test passes if no exception thrown
        }

        [TestMethod]
        public async Task LoadTitleDetailsAsync_CalledMultipleTimes_ShouldUpdateSelectedTitle()
        {
            var firstTitle = new Title { TitleId = "tt0000001", PrimaryTitle = "First Movie" };
            var secondTitle = new Title { TitleId = "tt0000002", PrimaryTitle = "Second Movie" };

            _mockTitleService.Setup(s => s.GetTitleAsync("tt0000001")).ReturnsAsync(firstTitle);
            _mockTitleService.Setup(s => s.GetTitleAsync("tt0000002")).ReturnsAsync(secondTitle);

            await _viewModel.LoadTitleDetailsAsync("tt0000001");
            Assert.AreEqual("First Movie", _viewModel.SelectedTitle?.PrimaryTitle);

            await _viewModel.LoadTitleDetailsAsync("tt0000002");
            Assert.AreEqual("Second Movie", _viewModel.SelectedTitle?.PrimaryTitle);
            Assert.AreEqual("tt0000002", _viewModel.SelectedTitle?.TitleId);
        }

        [TestMethod]
        public async Task LoadTitleDetailsAsync_WithComplexTitle_ShouldMapAllBasicProperties()
        {
            var testTitle = new Title
            {
                TitleId = "tt0000003",
                PrimaryTitle = "Complex Movie",
                OriginalTitle = "Original Complex Movie",
                TitleType = "tvSeries",
                IsAdult = false,
                StartYear = 2015,
                EndYear = 2020,
                RuntimeMinutes = 45
            };

            _mockTitleService.Setup(s => s.GetTitleAsync("tt0000003"))
                .ReturnsAsync(testTitle);

            await _viewModel.LoadTitleDetailsAsync("tt0000003");

            Assert.IsNotNull(_viewModel.SelectedTitle);
            Assert.AreEqual("Complex Movie", _viewModel.SelectedTitle.PrimaryTitle);
            Assert.AreEqual("Original Complex Movie", _viewModel.SelectedTitle.OriginalTitle);
            Assert.AreEqual("tvSeries", _viewModel.SelectedTitle.TitleType);
            Assert.IsFalse(_viewModel.SelectedTitle.IsAdult);
            Assert.AreEqual((short)2015, _viewModel.SelectedTitle.StartYear);
            Assert.AreEqual((short)2020, _viewModel.SelectedTitle.EndYear);
        }
    }
}
