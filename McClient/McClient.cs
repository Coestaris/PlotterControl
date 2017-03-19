/*
    The MIT License(MIT)

    Copyright (c) 2016 - 2017 Kurylko Maxim Igorevich

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.

*/

using CWA.Connection;
using System;

namespace McClient
{
    class McClient
    {
        static void PressAnyKey()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You shouldn`t launch this program without \"CNC WFA\" client");
                PressAnyKey();
                return;
            }
            else
            {
                ManualControl a;
                try
                {
                    args = args[0].Split(',');
                    string port = args[0];
                    int bd = int.Parse(args[1]);
                    int step = int.Parse(args[2]);
                    if (args[3] != "6fb9a28a-d2f1-49db-8a43-8023f6eab1d2")
                    {
                        Console.WriteLine("Good try");
                        Console.WriteLine("Please, relaunch by hand");
                        PressAnyKey();
                        return;
                    }
                    Console.CursorVisible = false;
                    a = new ManualControl(port, bd);
                    a.Step = step;
                    Console.Clear();
                    Console.WriteLine("Press ESC to exit");
                }
                catch
                {
                    Console.WriteLine("Launch with wrong arguments");
                    PressAnyKey();
                    return;
                }
                while (true)
                {

                    try
                    {
                        var c = Console.ReadKey();
                        if (c.Key == ConsoleKey.Escape)
                        {
                            PressAnyKey();
                            return;
                        }
                        a.MakeStep(c);
                        Console.Clear();
                        Console.WriteLine("Press ESC to exit");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(string.Format("Here some error, while sending data to device. \nDebug info. Message: {0}.\nStackTrace: {1}", e.Message, e.StackTrace));
                        PressAnyKey();
                    }
                }
            }
        }
    }
}