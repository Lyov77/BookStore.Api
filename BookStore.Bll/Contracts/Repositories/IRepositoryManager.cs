namespace BookStore.Bll.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
