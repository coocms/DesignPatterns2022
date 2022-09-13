using System;
using System.Net.Http;
using System.Text;

namespace DesignPatternsExec
{
    class Program
    {
        static void Main(string[] args)
        {


            HttpClient client = new HttpClient();

            var mode = new BuildMode();
            mode.ShowSingleton();
            mode.AbstructFactory();
            mode.ShowBuilderMode();

            new AdapterMode().ShowAdapterPattern();

        }
    }
}
