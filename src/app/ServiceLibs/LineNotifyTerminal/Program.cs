using System;

namespace LineNotifyTerminal
{
    using System.Collections.Specialized;
    using INFOLINK.LineAPP.Notify;
    using INFOLINK.ShareLibs;

    class Program
    {
        private LineNotifyService lineService = null;
        private NameValueCollection dict = new NameValueCollection();

        public Program()
        {
            this.lineService = new LineNotifyService();
            this.dict.Clear();
            this.dict.Add(LineOfficialAddress.LINENOTIFY_MSG, string.Empty);
            //this.dict.Add(LineOfficialAddress.LINENOTIFY_TOKEN, "2NPnKfgwIaTcMAojs9P1ji0MWckkh15JLnobeGWQOg8");
        }

        public async void ExecuteNotify(string token, string message)
        {
            this.dict[LineOfficialAddress.LINENOTIFY_TOKEN] = token;
            this.dict[LineOfficialAddress.LINENOTIFY_MSG] = message;
            await this.lineService.Execute(this.dict);
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("usage: LineNotify.exe {token} {message}");
                Console.WriteLine("usage: LineNotify.exe {token} {message}");
            }
            else
            {
                Program p = new Program();
                p.ExecuteNotify(args[0], args[1]);
                Console.WriteLine("Hello World!");
            }

            Console.Read();
        }
    }
}
