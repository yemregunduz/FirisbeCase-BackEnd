﻿namespace FirisbeCase.Core.Wrappers.Results.Abstract
{ 
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
