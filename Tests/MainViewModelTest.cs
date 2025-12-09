using ImdbProject.Models;
using ImdbProject.Services.Interfaces;
using ImdbProject.ViewModels;
using Moq;


namespace Tests
{

    [TestClass]
    public sealed class MainViewModelTest
    {
        private Mock<ITitleService> mockTitleService = new Mock<ITitleService>();

        private MainViewModel viewModel = null!;

        [TestInitialize]
        public void Setup()
        {

            viewModel = new MainViewModel(mockTitleService.Object);
        }

        [TestCategory("LoadTitlesAsync")]
        [TestMethod]
        public void LoadTitlesAsync_ShouldPopulateTitlesCollect()
        {
            mockTitleService.Setup(s => s.GetTitlesWithEpisodesAsync())
                .ReturnsAsync(new List<Title>
                {
                    new() { TitleId = "tt0000001", PrimaryTitle = "Test Title 1" },
                    new() { TitleId = "tt0000002", PrimaryTitle = "Test Title 2" }
                });

            viewModel.LoadTitlesAsync().Wait();

            Assert.HasCount(2, viewModel.Titles);
            Assert.AreEqual("Test Title 1", viewModel.Titles[0].PrimaryTitle);
        }

        [TestMethod]
        public void LoadTitlesAsync_ShouldHandleEmptyList()
        {
            mockTitleService.Setup(s => s.GetTitlesWithEpisodesAsync())
                .ReturnsAsync([]);
            viewModel.LoadTitlesAsync().Wait();
            Assert.IsEmpty(viewModel.Titles);
        }

        [TestMethod]
        public void LoadTitlesAsync_ClearTitlesBeforeAddingNewOnes()
        {
            viewModel.Titles.Add(TitleViewModel.FromModel(new Title { TitleId = "tt9999999", PrimaryTitle = "Old Title" }));

            mockTitleService.Setup(s => s.GetTitlesWithEpisodesAsync())
                .ReturnsAsync(
                [
                    new() { TitleId = "tt0000001", PrimaryTitle = "Test Title 1" }
                ]
            );

            viewModel.LoadTitlesAsync().Wait();
            Assert.HasCount(1, viewModel.Titles);
            Assert.AreEqual("Test Title 1", viewModel.Titles[0].PrimaryTitle);
        }


        [TestCategory("Navigation")]
        [TestMethod]
        public void GoToTitleDetails_ShouldInvokeNavigationEvent()
        {
            string? navigatedTitleId = null;
            viewModel.NavigateToTitleDetails += (titleId) => navigatedTitleId = titleId;
            string testTitleId = "tt1234567";
            viewModel.GoToTitleDetailsCommand.Execute(testTitleId);
            Assert.AreEqual(testTitleId, navigatedTitleId);
        }

    }
}
