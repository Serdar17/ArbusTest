namespace ArbusTest.Logic;

public class MenuMaster
{
    private readonly IReadOnlyCollection<string> _dishes;
    private readonly int _pageSize;
    private readonly int _pageCount;

    public MenuMaster(IEnumerable<string> dishes, int pageSize)
    {
        if (!dishes.Any())
        {
            throw new ArgumentException($"{nameof(pageSize)} should be positive");
        }

        if (pageSize <= 0)
        {
            throw new ArgumentException($"{pageSize} should be greater then zero");
        }
        
        _dishes = dishes.ToList().AsReadOnly();
        _pageSize = pageSize;
        _pageCount = (int)Math.Ceiling((double)_dishes.Count / _pageSize);
    }

    /// <summary>
    /// Returns dishes count
    /// </summary>
    public int Count => _dishes.Count;

    
    /// <summary>
    /// Returns page Count
    /// </summary>
    public int PageCount => _pageCount;

    /// <summary>
    /// Returns the number of dishes on the specified page 
    /// </summary>
    /// <param name="page">Page number</param>
    /// <returns>Dishes count</returns>
    public int DishesCountPerPage(int page)
    {
        Throw(page);
        
        return GetDishesByPage(page)
            .Count();
    }

    /// <summary>
    /// Returns a list of dishes from the specified page 
    /// </summary>
    /// <param name="page">Page number</param>
    /// <returns><see cref="IEnumerable{T}"/> list of dishes</returns>
    public IEnumerable<string> GetDishesByPage(int page)
    {
        Throw(page);
        
        return _dishes
            .Skip((page - 1) * _pageSize)
            .Take(_pageSize);
    }

    /// <summary>
    /// Returns the list of top dishes each page
    /// </summary>
    /// <returns>List of top dishes each page</returns>
    public IEnumerable<string> GetTopDishes()
    {
        return Enumerable.Range(1, _pageCount)
            .Select((i, _) => GetDishesByPage(i).First());
    }

    private void Throw(int page)
    {
        if (page < 1 || page > _pageCount)
        {
            throw new ArgumentException($"{nameof(page)} must be between 1 and {_pageCount}");
        }
    }
 }