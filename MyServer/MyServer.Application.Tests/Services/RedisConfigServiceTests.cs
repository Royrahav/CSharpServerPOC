using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using MyServer.Application.Entities;
using MyServer.Infrastructure.Services;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MyServer.Application.Tests.Services
{
    public class RedisConfigServiceTests
    {
        [Fact]
        public async Task LoadConfigsAsync_ShouldReturnEntries_WhenKeysExist()
        {
            // Arrange
            var keys = new[] { "setting1", "setting2" };

            var mockDb = new Mock<StackExchange.Redis.IDatabase>();
            mockDb.Setup(db => db.StringGetAsync("setting1", It.IsAny<CommandFlags>()))
                  .ReturnsAsync((RedisValue)"Value1");
            mockDb.Setup(db => db.StringGetAsync("setting2", It.IsAny<CommandFlags>()))
                  .ReturnsAsync((RedisValue)"Value2");

            var mockConn = new Mock<IConnectionMultiplexer>();
            mockConn.Setup(c => c.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
                    .Returns(mockDb.Object);

            var service = new RedisConfigService(mockConn.Object);

            // Act
            var result = await service.LoadConfigsAsync(keys);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("setting1", result[0].Key);
            Assert.Equal("Value1", result[0].Value);
            Assert.True(result[0].Exists);

            Assert.Equal("setting2", result[1].Key);
            Assert.Equal("Value2", result[1].Value);
            Assert.True(result[1].Exists);
        }
    }
}
