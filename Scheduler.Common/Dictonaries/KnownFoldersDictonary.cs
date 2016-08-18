using Scheduler.Common.Enums;
using System.Collections.Generic;

namespace Scheduler.Common.Dictonaries
{
    public class KnownFoldersDictonary : Dictionary<KnownDirectories, string>
    {
        public KnownFoldersDictonary()
        {
            Add(KnownDirectories.Contacts, "{56784854-C6CB-462B-8169-88E350ACB882}");
            Add(KnownDirectories.Desktop, "{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
            Add(KnownDirectories.Documents, "{FDD39AD0-238F-46AF-ADB4-6C85480369C7}");
            Add(KnownDirectories.Downloads, "{374DE290-123F-4565-9164-39C4925E467B}");
            Add(KnownDirectories.Favorites, "{1777F761-68AD-4D8A-87BD-30B759FA33DD}");
            Add(KnownDirectories.Links, "{BFB9D5E0-C6A9-404C-B2B2-AE6DB6AF4968}");
            Add(KnownDirectories.Music, "{4BD8D571-6D19-48D3-BE97-422220080E43}");
            Add(KnownDirectories.Pictures, "{33E28130-4E1E-4676-835A-98395C3BC3BB}");
            Add(KnownDirectories.SavedGames, "{4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4}");
            Add(KnownDirectories.SavedSearches, "{7D1D3A04-DEBB-4115-95CF-2F29DA2920DA}");
            Add(KnownDirectories.Videos, "{18989B1D-99B5-455B-841C-AB7C74E4DDFC}");
        }
    }
}
