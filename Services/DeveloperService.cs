using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Services;

public class DeveloperService : IDeveloperService
{
    private readonly DataContext _context;

    public DeveloperService(DataContext context)
    {
        _context = context;
    }

    public bool Create(Developer developer)
    {
        try
        {
            _context.Developers.Add(developer);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Update(Developer developer)
    {
        try
        {
            _context.Set<Developer>().Update(developer);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var developer = _context.Set<Developer>().Find(id);
            if (developer == null) return false;

            _context.Set<Developer>().Remove(developer);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Developer GetById(int id)
    {
        return _context.Set<Developer>().Find(id);
    }

    public IEnumerable<Developer> GetAll()
    {
        return _context.Set<Developer>().ToList();
    }
}