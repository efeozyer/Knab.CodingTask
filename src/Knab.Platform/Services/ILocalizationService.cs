using System.Globalization;

namespace Knab.Platform.Services;

public interface ILocalizationService
{
    Task<string> Locale(string language, string key);

    Task<string> Locale(CultureInfo cultureInfo, string key);
}