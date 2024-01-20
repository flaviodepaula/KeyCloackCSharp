namespace Infra.Common
{
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        public Result(TValue? value, bool isSucess, Error error) : base(isSucess, error) => _value = value;

        public TValue Value => _value != null ? _value! : throw new InvalidOperationException("Unable to retrieve the value of failure");

        public static implicit operator Result<TValue>(TValue? value) => new(value, true, Error.None);
    }
}