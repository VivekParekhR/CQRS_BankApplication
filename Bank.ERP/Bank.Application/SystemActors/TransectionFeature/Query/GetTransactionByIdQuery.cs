#region Using
using Bank.Core.Entity;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.TransectionFeature.Query
{
    public class GetTransactionByIdQuery : IRequest<Transaction>
    {
        public int Id { get; set; }
    }
}
