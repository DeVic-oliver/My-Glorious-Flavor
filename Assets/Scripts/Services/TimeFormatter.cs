namespace Assets.Scripts.Core.Services
{
    public class TimeFormatter
    {
        public static string GetTimeFormated(float time)
        {
            int minutes = GetMinutes(time);
            int seconds = GetSeconds(time);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private static int GetMinutes(float time)
        {
            return (int)(time / 60);
        }

        private static int GetSeconds(float time)
        {
            return (int)(time % 60);
        }
    }
}