namespace RoadStatus
{
    public class Environment
    {
        struct ExitCode
        {
            public const int Success = 0;
            public const int ApiError = 1;
        }

        public static void Exit(bool success)
        {
            var exitCode = success ?
                ExitCode.Success : ExitCode.ApiError;

            System.Environment.SetEnvironmentVariable("lasterrorcode", exitCode.ToString());
        }
    }
}
