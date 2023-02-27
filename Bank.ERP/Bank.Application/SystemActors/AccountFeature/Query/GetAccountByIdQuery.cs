#region Using
using Bank.Core.Entity;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.AccountFeature.Query
{
    public class GetAccountByIdQuery : IRequest<Account>
    {
        public int Id { get; set; }
    }
}
