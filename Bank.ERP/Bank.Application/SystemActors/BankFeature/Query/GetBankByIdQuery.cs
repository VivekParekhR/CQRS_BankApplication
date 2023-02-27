#region Using
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.BankFeature.Query
{
    public class GetBankByIdQuery : IRequest<Bank.Core.Entity.Bank>
    {
        public int Id { get; set; }
    }
}
