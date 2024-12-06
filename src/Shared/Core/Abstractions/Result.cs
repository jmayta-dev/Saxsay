namespace MW.SAXSAY.Shared.Abstractions;

public class Result
{
    #region Properties
    public bool IsFailure => !IsSuccess;
    public bool IsSuccess { get; }
    public Error Error { get; }
    #endregion

    #region Constructor
    protected Result(bool isSuccess, Error error)
    {
        if(isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
    }
    #endregion

    #region Methods
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    #endregion
}

public sealed class Result<T> : Result
{
    #region Properties
    public T? Value { get; set; }
    #endregion

    #region Constructor
    private Result(bool isSuccess, Error error, T? value) : base(isSuccess, error)
    {
        if (!isSuccess && value != null)
            throw new ArgumentException("Invalid error", nameof(error));

        Value = value;
    }
    #endregion

    #region Methods
    public static Result<T> Success(T? value) => new(true, Error.None, value!);
    public static new Result<T> Failure(Error error) => new(false, error, default);
    #endregion
}