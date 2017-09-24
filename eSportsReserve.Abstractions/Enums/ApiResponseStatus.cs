using System.ComponentModel;

namespace eSportsReserve.Abstractions.Enums
{
    public enum ApiResponseStatus
    {
        [Description("success")]
        Success,
        [Description("fail")]
        Fail,
        [Description("error")]
        Error
    }
}
