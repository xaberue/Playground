using System.Diagnostics.CodeAnalysis;

namespace Xelit3.Playground.ResultPattern;

public class Result<T>
{
    // We don't expose these publicly any more
    private readonly T? _value;
    private readonly Exception? _error;

    // Same constructors
    private Result(T value)
    {
        IsSuccess = true;
        _value = value;
        _error = null;
    }

    private Result(Exception error)
    {
        IsSuccess = false;
        _value = default;
        _error = error;
    }

    [MemberNotNullWhen(true, nameof(_value))]
    [MemberNotNullWhen(false, nameof(_error))]
    private bool IsSuccess { get; }

    // This Method takes two Func<T>, one for the success case and one for the error case
    public Result<TReturn> Switch<TReturn>(Func<T, Result<TReturn>> onSuccess, Func<Exception, Result<TReturn>> onFailure)
    {
        if (IsSuccess)
        {
            return onSuccess(_value);
        }
        else
        {
            return onFailure(_error);
        }
    }


    public static Result<T> Success(T value) => new(value);
    public static Result<T> Fail(Exception error) => new(error);
    public static implicit operator Result<T>(T value) => Success(value);
}


public static class ResultExtensions
{

    public static Result<TResult> Select<TFrom, TResult>(
    this Result<TFrom> source,
    Func<TFrom, TResult> selector)
    {
        return source.Switch(
            onSuccess: r => selector(r),
            onFailure: e => Result<TResult>.Fail(e));
    }


    public static Result<TResult> SelectMany<TFrom, TMiddle, TResult>(
        this Result<TFrom> source,
        Func<TFrom, Result<TMiddle>> collectionSelector,
        Func<TFrom, TMiddle, TResult> resultSelector)
    {
        return source.Switch(
            onSuccess: r =>
            {
                Result<TMiddle> middleResult = collectionSelector(r);

                return middleResult.Switch(
                    onSuccess: v => Result<TResult>.Success(resultSelector(r, v)),
                    onFailure: e => Result<TResult>.Fail(e));
            },
            onFailure: e => Result<TResult>.Fail(e));
    }


}