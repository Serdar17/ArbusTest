using ArbusTest.Logic;
using ArbusTest.UnitTests.Data;
using FluentAssertions;

namespace ArbusTest.UnitTests.MenuMasterTests;

public class MenuMasterGetTopDishesTests
{
    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(5, 2, 3)]
    public void MenuMasterGetTopDishesTests_ShouldReturnExceptedData(int count, int pageSize, int expectedCount)
    {
        // Arrange
        var menuMaster = new MenuMaster(TestData.GetDishes(count), pageSize);
        
        // Act
        var actualData = menuMaster.GetTopDishes();

        // Assert
        actualData.Count().Should().Be(expectedCount);
    }
    
}