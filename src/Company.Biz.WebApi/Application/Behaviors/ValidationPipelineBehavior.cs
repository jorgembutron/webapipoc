﻿using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Behaviors
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly List<IValidator<TRequest>> _validators;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validators"></param>
        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators.ToList();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators
                           .Select(v => v.Validate(context))
                           .SelectMany(result => result.Errors)
                           .Where(f => f != null)
                           .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return await next().ConfigureAwait(false);
        }
    }
}
