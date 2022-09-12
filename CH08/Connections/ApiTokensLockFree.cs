using System;
using System.Collections.Concurrent;

namespace Connections;
class ApiTokensLockFree
{
    private ConcurrentDictionary<string, Token> tokens { get; } = new();

    public void Set(string key, Token value)
    {
        tokens[key] = value;
    }

    public Token Get(string key)
    {
        if (!tokens.TryGetValue(key, out Token value))
        {
            value = getTokenFromDb(key);
            tokens[key] = value;
            return tokens[key];
        }
        return value;
    }

    private Token getTokenFromDb(string key)
    {
        throw new NotImplementedException();
    }
}

