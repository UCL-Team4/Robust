namespace Robust.Repositories.Interface;

interface IRepository
{
    public void GetAll();
    public void GetByID();
    public void Add();
    public void Update();
    public void Delete();
}
