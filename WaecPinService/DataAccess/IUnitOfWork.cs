namespace WaecPinService.DataAccess
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }

}
