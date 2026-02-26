namespace Arkitektur.DataAccess.UOW
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<bool> SaveChangesAsycn()
        {
            return await context.SaveChangesAsync()  > 0; // Değişiklikler kaydedildiğinde true, aksi halde false döner
        }
    }
}
