﻿// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace WUView.Helpers;

internal static class ResourceHelpers
{
    /// <summary>
    /// Gets the string resource for the key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>String</returns>
    /// <remarks>
    /// Want to throw here so that missing resource doesn't make it into a release.
    /// </remarks>
    public static string GetStringResource(string key)
    {
        object description;
        try
        {
            description = Application.Current.TryFindResource(key);
        }
        catch (Exception)
        {
            _log.Error($"Resource not found: {key}");
            throw new Exception("Resource not found");
        }

        if (description is null)
        {
            _log.Error($"Resource not found: {key}");
            throw new Exception("Resource not found");
        }

        return description.ToString();
    }
}
