#region Using
using FluentValidation;
using MediatR; 
#endregion

namespace Bank.Application.Behaviour
{
    /// <summary>
    /// Validation behaviour each validation pass through this to validate property
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        #region Property
        private readonly IEnumerable<IValidator<TRequest>> _validators; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validators"></param>
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Handle ValidationBehaviour
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="FluentValidation.ValidationException"></exception>
        public async Task<TResponse> Handle(TRequest request,  RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new FluentValidation.ValidationException(failures);
            }
            return await next();
        } 
    }
}
