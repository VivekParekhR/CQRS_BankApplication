#region Using
using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection; 
#endregion

namespace Bank.Application.Behaviour
{
    /// <summary>
    /// LoggingBehaviour to add log
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region Property
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handle loginng behaviours
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Request
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            Type myType = request.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(request, null);
                _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
            }
            var response = await next();
            //Response
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
