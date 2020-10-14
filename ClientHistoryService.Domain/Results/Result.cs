using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ClientHistoryService.Domain.Results
{
    public struct Result<TResult> where TResult : Enum
    {
        public TResult Value { get; }

        public string Message { get; }

        public Result(TResult value, string message = "")
        {
            Value = value;
            Message = message;
        }
    }

    public struct Result<TResult, TData> where TResult : Enum
    {
        public TResult Value { get; }

        public TData Data { get; }

        public string Message { get; }

        public Result(TResult value, TData data = default, string message = "")
        {
            Value = value;
            Message = message;
            Data = data;
        }
    }

    public static class ResultExtensions
    {
        public static bool IsEquals<T>(this Result<T> result, T resultEnum) where T : Enum
        {
            if (result.Value.Equals(resultEnum))
                return true;

            return false;
        }

        public static bool IsEquals<Tr, Tm>(this Result<Tr, Tm> result, Tr resultEnum) where Tr : Enum where Tm : class
        {
            if (result.Value.Equals(resultEnum))
                return true;

            return false;
        }

        public static Result<T> Result<T>(T result, string message = "") where T : Enum
        {
            return new Result<T>(result, message);
        }

        public static Result<Te, Tm> Result<Te, Tm>(Te result, Tm model, string message = "") where Te : Enum where Tm : class
        {
            return new Result<Te, Tm>(result, model, message);
        }
    }
}
