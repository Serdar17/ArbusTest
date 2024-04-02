using ArbusTest.Logic;
using ArbusTest.UnitTests.Data;
using FluentAssertions;

namespace ArbusTest.UnitTests.MenuMasterTests;

public class MainMenuGetDishesByPageTests
{
    [Fact]
    public void MainMenuGetDishesByPageTests_ShouldThrowException_WhenPageWrong()
    {
        // Arrange
        var menuMaster = new MenuMaster(TestData.GetDishes(10), 2);
        
        // Act
        var action = () => { menuMaster.DishesCountPerPage(100); };
        
        // Assert
        var exception = Assert.Throws<ArgumentException>(action);
        exception.Should().BeOfType<ArgumentException>();
    }

    [Theory]
    [InlineData(10, 2, 5, 2)]
    [InlineData(7, 3, 3, 1)]
    public void MainMenuGetDishesByPageTests_ShouldReturnExpectedValue(int count, int pageSize, int pageNumber, int expectedCount)
    {
        // Arrange
        var menuMaster = new MenuMaster(TestData.GetDishes(count), pageSize);
        
        // Act
        var actualData = menuMaster.GetDishesByPage(pageNumber);
        
        // Assert
        actualData.Count().Should().Be(expectedCount);
    }
    
}