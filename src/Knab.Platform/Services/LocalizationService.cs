using System.Globalization;

namespace Knab.Platform.Services;

// TODO: Retrieve localization keys from distributed memory storage
public class LocalizationService : ILocalizationService
{
    public Task<string> Locale(string language, string key)
    {
        return Task.FromResult(key);
    }

    public Task<string> Locale(CultureInfo cultureInfo, string key)
    {
        return Task.FromResult(key);
    }
}