namespace SULS.App
{
    using SIS.MvcFramework;
    using System.Globalization;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            WebHost.Start(new StartUp());
        }
    }
}