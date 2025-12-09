using ImdbProject.Models;
using ImdbProject.Services.Interfaces;
using ImdbProject.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public sealed class NameDetailViewModelTests
    {
        private Mock<INameService> _mockNameService = null!;
        private NameDetailViewModel _viewModel = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockNameService = new Mock<INameService>();
            _viewModel = new NameDetailViewModel(_mockNameService.Object);
        }

        [TestMethod]
        public async Task LoadNameDetailsAsync_WithValidNameId_ShouldPopulateSelectedName()
        {
            var testName = new Name
            {
                NameId = "nm0000001",
                PrimaryName = "Test Actor",
                BirthYear = 1960,
                DeathYear = null,
                PrimaryProfession = "Actor"
            };

            _mockNameService.Setup(s => s.GetNameAsync("nm0000001"))
                .ReturnsAsync(testName);

            await _viewModel.LoadNameDetailsAsync("nm0000001");

            Assert.IsNotNull(_viewModel.SelectedName);
            Assert.AreEqual("nm0000001", _viewModel.SelectedName.NameId);
            Assert.AreEqual("Test Actor", _viewModel.SelectedName.PrimaryName);
            Assert.AreEqual(1960, _viewModel.SelectedName.BirthYear);
            Assert.IsNull(_viewModel.SelectedName.DeathYear);
        }

        [TestMethod]
        public async Task LoadNameDetailsAsync_WithInvalidNameId_ShouldNotSetSelectedName()
        {
            _mockNameService.Setup(s => s.GetNameAsync("nm9999999"))
                .ReturnsAsync((Name?)null);

            await _viewModel.LoadNameDetailsAsync("nm9999999");

            Assert.IsNull(_viewModel.SelectedName);
        }

        [TestMethod]
        public async Task LoadNameDetailsAsync_ShouldCallNameServiceOnce()
        {
            var testName = new Name
            {
                NameId = "nm0000002",
                PrimaryName = "Another Actor"
            };

            _mockNameService.Setup(s => s.GetNameAsync("nm0000002"))
                .ReturnsAsync(testName);

            await _viewModel.LoadNameDetailsAsync("nm0000002");

            _mockNameService.Verify(s => s.GetNameAsync("nm0000002"), Times.Once);
        }

        [TestMethod]
        public async Task LoadNameDetailsAsync_WithComplexName_ShouldMapAllProperties()
        {
            var testName = new Name
            {
                NameId = "nm0000003",
                PrimaryName = "Complex Actor",
                BirthYear = 1950,
                DeathYear = 2020,
                PrimaryProfession = "Actor, Director"
            };

            _mockNameService.Setup(s => s.GetNameAsync("nm0000003"))
                .ReturnsAsync(testName);

            await _viewModel.LoadNameDetailsAsync("nm0000003");
            Assert.IsNotNull(_viewModel.SelectedName);
            Assert.AreEqual("Complex Actor", _viewModel.SelectedName.PrimaryName);
            Assert.AreEqual(1950, _viewModel.SelectedName.BirthYear);
            Assert.AreEqual(2020, _viewModel.SelectedName.DeathYear);
            Assert.AreEqual("Actor, Director", _viewModel.SelectedName.PrimaryProfession);
        }

        [TestMethod]
        public async Task LoadNameDetailsAsync_CalledMultipleTimes_ShouldUpdateSelectedName()
        {
            var firstName = new Name { NameId = "nm0000001", PrimaryName = "First Actor" };
            var secondName = new Name { NameId = "nm0000002", PrimaryName = "Second Actor" };

            _mockNameService.Setup(s => s.GetNameAsync("nm0000001")).ReturnsAsync(firstName);
            _mockNameService.Setup(s => s.GetNameAsync("nm0000002")).ReturnsAsync(secondName);

            await _viewModel.LoadNameDetailsAsync("nm0000001");
            Assert.AreEqual("First Actor", _viewModel.SelectedName?.PrimaryName);

            await _viewModel.LoadNameDetailsAsync("nm0000002");

            Assert.AreEqual("Second Actor", _viewModel.SelectedName?.PrimaryName);
            Assert.AreEqual("nm0000002", _viewModel.SelectedName?.NameId);
        }
    }
}
