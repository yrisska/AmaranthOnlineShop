﻿using FluentValidation;
using MediatR;

namespace AmaranthOnlineShop.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators
                .Select(v => v.ValidateAsync(context, cancellationToken)));

            var validationFailures = validationResults
                .Where(v => v.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (!validationFailures.Any())
            {
                return await next();
            }

            var firstFailure = validationFailures.First();
            throw new ValidationException(firstFailure.ErrorMessage);
        }
    }
}