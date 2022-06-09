using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Dane
{
    internal class Logger
    {
        private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        private Stopwatch watch = new Stopwatch();

        public Logger(List <Circle> circles)
        {
            Thread t = new Thread(() => {

                this.watch.Start();
                while (true)
                {

                    if (this.watch.ElapsedMilliseconds >= 20)
                    {
                        this.watch.Restart();
                        Debug.WriteLine(Directory.GetCurrentDirectory());
                        using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "\\log.txt", true))
                        {
                            string stamp = "INFO [" + DateTime.Now.ToString("yyyy-MM-dd: HH:mm:ss.fffffff") + "]:\n";

                            foreach (Circle c in circles)
                            {
                                writer.WriteLine(stamp + JsonSerializer.Serialize(c, options));
                            }
                        }
                    }
                    if (!this.watch.IsRunning)
                    {
                        break;
                    }
                }
            })
            {
                IsBackground = true
            };
            t.Start();
        }

        public void stop()
        {
            this.watch.Reset();
            this.watch.Stop();
        }
    }
}
