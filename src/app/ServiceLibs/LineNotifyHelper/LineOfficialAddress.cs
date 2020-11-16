namespace INFOLINK.LineAPP.Notify
{
    public static class LineOfficialAddress
    {
        public const string LINENOTITY_BASE_ADDRESS   = @"https://notify-api.line.me";
        public const string LINENOTITY_NOTITY_ADDRESS = LINENOTITY_BASE_ADDRESS + "/api/notify";
        public const string LINENOTITY_TOKEN_ADDRESS  = LINENOTITY_BASE_ADDRESS + "/oauth/token";
        public const string LINENOTITY_STATUS_ADDRESS = LINENOTITY_BASE_ADDRESS + "/api/status";
        public const string LINENOTITY_REVOKE_ADDRESS = LINENOTITY_BASE_ADDRESS + "/api/revoke";

        public const string LINENOTIFY_TOKEN = "LINENOTIFY_TOKEN";
        public const string LINENOTIFY_MSG = "LINENOTIFY_MSG";
    }
}