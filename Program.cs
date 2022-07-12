using System;
using System.IO;

namespace BrainfuckCompiler
{
    class Program
    {
        static void Main(string[] args) 
        {
            string script = File.ReadAllText(args[/*?*/0]);
            //string script = File.ReadAllText("test.txt");
            int scriptPtr = 0;
            int arrayPtr = 0;
            byte[] array = new byte[10000];
            while (scriptPtr!=script.Length)
            {
                switch ((char)script[scriptPtr])
                {
                    case '>':
                        ++arrayPtr;
                        ++scriptPtr;
                        break;
                    case '<':
                        --arrayPtr;
                        ++scriptPtr;
                        break;
                    case '+':
                        ++array[arrayPtr];
                        ++scriptPtr;
                        break;
                    case '-':
                        --array[arrayPtr];
                        ++scriptPtr;
                        break;
                    case '.':
                        Console.Write((char)array[arrayPtr]);
                        ++scriptPtr;
                        break;
                    case ',':
                        array[arrayPtr] = (byte)Console.Read();
                        ++scriptPtr;
                        break;
                    case '[':
                        if(array[arrayPtr] == (byte)0)
                        {
                            int count = 0;
                            while (true)
                            {
                                ++scriptPtr;
                                if (script[scriptPtr] == '[')
                                {
                                    ++count;
                                }
                                else if (script[scriptPtr] == ']' && count == 0)
                                {
                                    break;
                                }
                                else if (script[scriptPtr] == ']')
                                {
                                    --count;
                                }
                            }
                        }
                        else
                        {
                            ++scriptPtr;
                        }
                        break;
                    case ']':
                        if (array[arrayPtr] == (byte)0)
                        {
                            ++scriptPtr;
                        }
                        else
                        {
                            int count = 0;
                            while (true)
                            {
                                --scriptPtr;
                                if (script[scriptPtr] == ']')
                                {
                                    ++count;
                                }
                                else if (script[scriptPtr] == '[' && count == 0)
                                {
                                    ++scriptPtr;
                                    break;
                                }
                                else if (script[scriptPtr] == '[')
                                {
                                    --count;
                                }
                            }
                        }
                        break;
                    default:
                        ++scriptPtr;
                        break;
                }
            }
        }
    }
}
