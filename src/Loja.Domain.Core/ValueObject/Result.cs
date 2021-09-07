namespace Loja.Domain.Core.ValueObject
{
    using FluentValidation.Results;
    using System.Collections.Generic;
    using System.Linq;

    public class Result
    {
        public Result()
        {
            Error = new List<string>();
        }

        public ICollection<string> Error { get; set; }

        public bool HasError
        {
            get { return Error?.Any() ?? false; }
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result<TResult> Success<TResult>(TResult result)
        {
            return new Result<TResult>(result);
        }

        public static Result Failed(params ValidationFailure[] failures)
        {
            var result = new Result();
            result.Add(failures);
            return result;
        }

        public void Add(params ValidationFailure[] failures)
        {
            if (failures == null)
            {
                return;
            }

            foreach (var failure in failures.Where(f => f != null))
            {
                Error.Add(failure.ErrorMessage);
            }
        }
    }

    public class Result<TValue> : Result
    {
        public Result(TValue value)
            :base()
        {
            Value = value;
        }

        public TValue Value { get; }
    }
}
