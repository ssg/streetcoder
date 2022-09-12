using System;
using System.Collections.Generic;

namespace Connections;
class ApiTokens
{
    private Dictionary<string, Token> tokens { get; } = new();

    public void Set(string key, Token value)
    {
        lock (tokens)
        {
            tokens[key] = value;
        }
    }

    public Token Get(string key)
    {
        lock (tokens)
        {
            if (!tokens.TryGetValue(key, out Token value))
            {
                value = getTokenFromDb(key);
                tokens[key] = value;
                return tokens[key];
            }
            return value;
        }
    }

    private Token getTokenFromDb(string key)
    {
        throw new NotImplementedException();
    }
}

internal class Token
{
}
