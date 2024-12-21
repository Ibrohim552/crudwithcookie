namespace BlazorCrud.Services;

public interface IDeveloperService
{
    bool Create(Developer developer);
    bool Update(Developer developer);
    bool Delete(int id);
    Developer GetById(int id);
    IEnumerable<Developer> GetAll();
}