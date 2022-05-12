using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IPracticalTaskRepository : IRepository<PracticalTask>
    {
        public void DeleteTaskWithData(int id);
    }
}
