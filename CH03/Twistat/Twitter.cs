using System;
using System.Collections.Generic;

public class Twitter
{
    public static Uri GetAuthorizationUrl(Uri callbackUrl)
    {
        string redirectUrl = "";
        // do something here to build the redirect url
        return new Uri(redirectUrl);
    }

    public static TwitterAccessToken GetAccessToken(
      TwitterCallbackInfo callbackData)
    {
        // we should be getting something like this
        return new TwitterAccessToken();
    }

    public Twitter(TwitterAccessToken accessToken)
    {
        // we should store this somewhere
    }

    public IEnumerable<TwitterUserId> GetListOfFollowers(
      TwitterUserId userId)
    {
        // no idea how this will work
        yield break;
    }
}

public class TwitterUserId
{
    // who knows how twitter defines user ids
}

public class TwitterAccessToken
{
    // no idea what this will be
}

public class TwitterCallbackInfo
{
    // this neither
}