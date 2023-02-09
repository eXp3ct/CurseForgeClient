using CurseForgeClient.ApiClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;
namespace CurseForgeClient.Tests
{
    [Trait("Mods", "Fetching")]
    public class ModsTests
    {
        [Fact]
        public async Task GetMods_Count()
        {
            // Arrange
            var expectedNumberOfMods = 50;
            var gameVersion = "1.12.2";
            var slug = "";
            var index = 0;
            var sortField = SortField.Name;
            var sortOrder = "asc";
            var sut = new ModController(new CurseClientContext());

            // Act
            var result = await sut.GetMods(gameVersion, slug, index, sortField, sortOrder);

            // Assert
            Assert.Equal(expectedNumberOfMods, result.Count);
        }
        [Fact]
        public async Task GetMods_NotNull()
        {
            var gameVersion = "1.12.2";
            var slug = "";
            var index = 0;
            var sortField = SortField.Name;
            var sortOrder = "asc";
            var sut = new ModController(new CurseClientContext());

            var result = await sut.GetMods(gameVersion, slug, index, sortField, sortOrder);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetMods_NotEmpty()
        {
            var gameVersion = "1.12.2";
            var slug = "";
            var index = 0;
            var sortField = SortField.Name;
            var sortOrder = "asc";
            var sut = new ModController(new CurseClientContext());

            var result = await sut.GetMods(gameVersion, slug, index, sortField, sortOrder);

            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetMod_NotNull()
        {
            var modId1 = 810803;
            var modId2 = 238222;
            var modId3 = 242638;
            var controller = new ModController(new CurseClientContext());

            var result1 = await controller.GetMod(modId1);
            var result2 = await controller.GetMod(modId2);
            var result3 = await controller.GetMod(modId3);

            Assert.True(result1.Id == modId1);
            Assert.True(result2.Id == modId2);
            Assert.True(result3.Id == modId3);
        }
        [Fact]
        public async Task GetMods_SuccessResponse()
        {
            string gameVersion = "";
            string slug = "";
            int index = 0;
            SortField sortField = SortField.Name;
            string sortOrder = "asc";
            var _client = new CurseClientContext();


            var jsonString = await _client.SearchModAsync(gameVersion: gameVersion, slug: slug,
                index: index, sortField: sortField, sortOrder: sortOrder);

            Assert.NotNull(jsonString);
        }
    }
}
