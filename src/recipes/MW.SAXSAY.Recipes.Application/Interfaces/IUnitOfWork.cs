
using System.Transactions;
using MediatR;
using recipes.MW.SAXSAY.Recipes.Domain.Entities;

namespace recipes.MW.SAXSAY.Recipes.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Save changes asynchronusly using an instance of <see cref="TransactionScope"/>.
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/> token</param>
    /// <param name="scope"><see cref="TransactionScope"/> instance</param>
    /// <returns></returns>
    Task SaveChangesAsync(
        CancellationToken cancellationToken,
        TransactionScope? scope = null);
}