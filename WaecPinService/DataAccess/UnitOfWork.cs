namespace WaecPinService.DataAccess
{
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(IServiceProvider provider)
        {
            _context = provider.GetRequiredService<ApplicationDBContext>();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
