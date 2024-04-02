using ArbusTest.Logic;
using ArbusTest.UnitTests.Data;
using FluentAssertions;

namespace ArbusTest.UnitTests.MenuMasterTests;

public class MenuMasterDishesCountPerPageTests
{
    [Fact]
    public void MenuMasterDishesCountPerPageTests_ShouldThrowException_WhenPageWrong()
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
    [InlineData(5, 2, 3, 1)]
    public void MenuMasterDishesCountPerPageTests_ShouldReturnExpectedData(int count, int pageSize, int page, int expectedCount)
    {
        // Arrange
        var menuMaster = new MenuMaster(TestData.GetDishes(count), pageSize);
        
        // Act
        var actualCount = menuMaster.DishesCountPerPage(page);
        
        // Assert
        actualCount.Should().Be(expectedCount);
    }
}