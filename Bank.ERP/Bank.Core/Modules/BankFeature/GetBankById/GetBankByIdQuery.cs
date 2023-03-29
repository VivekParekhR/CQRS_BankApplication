#region Using
using MediatR;
#endregion

namespace Bank.Core.Modules.BankFeature.GetBankById
{
    public class GetBankByIdQuery : IRequest<Domain.Entity.Bank>
    {
        public int Id { get; set; }
    }
}
