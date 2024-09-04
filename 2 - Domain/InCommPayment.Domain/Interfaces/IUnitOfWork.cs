namespace InCommPayment.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void CommitAsync();
    }
}
