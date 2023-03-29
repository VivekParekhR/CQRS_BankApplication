#region Using
using Bank.Domain.Entity;
using MediatR;
#endregion

namespace Bank.Core.Modules.TransectionFeature.GetTransactionById
{
    public class GetTransactionByIdQuery : IRequest<Transaction>
    {
        public int Id { get; set; }
    }
}
