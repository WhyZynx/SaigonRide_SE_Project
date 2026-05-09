using Microsoft.Extensions.Localization;
using System.Reflection;

namespace SaigonRideProject.Helpers
{
    public static class Locale
    {
        private static IStringLocalizer _localizer;

        public static void Init(IStringLocalizerFactory factory)
        {
            var type = typeof(SaigonRideProject.Resources.SharedResource);
            var assemblyName = new AssemblyName(type.Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public static string Translate(string key)
        {
            if (string.IsNullOrEmpty(key) || _localizer == null) return key;
            var localized = _localizer[key];
            return localized.ResourceNotFound ? key : localized.Value;
        }
        public static string StationName(int id, string defaultName)
        {
            string key = $"Station_{id}_Name";
            var localized = _localizer[key];
            return localized.ResourceNotFound ? defaultName : localized.Value;
        }
    }
}