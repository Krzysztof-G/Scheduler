using System.ComponentModel;

namespace Scheduler.Common.Enums
{
    /// <summary>
    /// Know folders
    /// </summary>
    public enum KnownDirectories
    {
        Contacts = 1,
        Desktop = 2,
        Documents = 3,
        Downloads = 4,
        Favorites = 5,
        Links = 6,
        Music = 7,
        Pictures = 8,
        SavedGames = 9,
        SavedSearches = 10,
        Videos = 11,
    }

    public static class KnownFoldersExtensions
    {
        public static string GetGuid(this KnownDirectories source)
        {
            switch (source)
            {
                case KnownDirectories.Contacts:
                    return "{56784854-C6CB-462B-8169-88E350ACB882}";
                case KnownDirectories.Desktop:
                    return "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}";
                case KnownDirectories.Documents:
                    return "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}";
                case KnownDirectories.Downloads:
                    return "{374DE290-123F-4565-9164-39C4925E467B}";
                case KnownDirectories.Favorites:
                    return "{1777F761-68AD-4D8A-87BD-30B759FA33DD}";
                case KnownDirectories.Links:
                    return "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}";
                case KnownDirectories.Music:
                    return "{4BD8D571-6D19-48D3-BE97-422220080E43}";
                case KnownDirectories.Pictures:
                    return "{33E28130-4E1E-4676-835A-98395C3BC3BB}";
                case KnownDirectories.SavedGames:
                    return "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}";
                case KnownDirectories.SavedSearches:
                    return "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}";
                case KnownDirectories.Videos:
                    return "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}";
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
