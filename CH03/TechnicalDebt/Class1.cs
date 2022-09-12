using System;

namespace TechnicalDebt;

public interface ICache
{
    T Get<T>(string key, Func<T> retrievalCode, TimeSpan expiresIn);
}