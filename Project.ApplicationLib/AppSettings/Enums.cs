using System;

namespace CommonLib.AppSettings
{
    public enum enStatus
    {
        DELETED = 0,
        ACTIVE = 1,
        INACTIVE = 2,
        PENDING = 3,
    }

    public enum enActionTypes
    {
        ADD = 1,
        UPDATE = 2,
        DELETE = 3,
        LIST = 4,
    }

    public enum enUserTypes
    {
        SUPERADMIN = 1,
        ADMIN = 2,
        SYSTEM = 3,
        SCHEDULER = 4,
        CLIENT = 5,
    }

    public enum enDevicePlatform
    {
        WEB = 1,
        ANDROID = 2,
        IOS = 3,
    }

    public enum enModules
    {
        Users = 1,
        MediaFiles = 2,
        AppAccessTokens = 3,
    }

    public enum enGender
    {
        Male = 1,
        Female = 2,
    }
}
