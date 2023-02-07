

using CurseForge_Client.ApiClient;

namespace ModsTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetMods_ShouldReturnExactNumberOfMods()
        {
            // Arrange
            var expectedNumberOfMods = 5;
            var gameVersion = "1.15.2";
            var slug = "";
            var index = 0;
            var sortField = SortField.Name;
            var sortOrder = "asc";
            var sut = new ModService(_client);

            // Act
            var result = await sut.GetMods(gameVersion, slug, index, sortField, sortOrder);

            // Assert
            Assert.Equal(expectedNumberOfMods, result.Count);
        }
    }
}