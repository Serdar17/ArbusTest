using ArbusTest.Logic;
using ArbusTest.UnitTests.Data;
using FluentAssertions;

namespace ArbusTest.UnitTests.MenuMasterTests;

public class MenuMasterCountTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(255)]
    public void MainMenuCount_ShouldReturnValue(int count)
    {
        // Arrange
        var menuMain = new MenuMaster(TestData.GetDishes(count), count / 2);
        
        // Act 
        var actualCount = menuMain.Count;
        
        // Assert
        actualCount.Should().Be(count);
    }
}