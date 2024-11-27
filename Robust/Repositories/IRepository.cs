namespace Robust.Repositories.Interface;

public interface IRepository
{
    public void GetAll();
    public void GetByID();
    public void Add();
    public void Update();
    public void Delete();
}
