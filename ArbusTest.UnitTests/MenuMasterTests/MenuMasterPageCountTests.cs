using ArbusTest.Logic;
using ArbusTest.UnitTests.Data;
using FluentAssertions;

namespace ArbusTest.UnitTests.MenuMasterTests;

public class MenuMasterPageCountTests
{
    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(7, 3, 3)]
    public void MenuMasterPageCount_ShouldReturnExpectedValue(int count, int pageSize, int expectedPageCount)
    {
        // Arrange
        var menuMaster = new MenuMaster(TestData.GetDishes(count), pageSize);
        
        // Act
        var actualPageCount = menuMaster.PageCount;
        
        // Assert
        actualPageCount.Should().Be(expectedPageCount);
    }
}