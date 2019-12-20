using System;
using System.IO;

namespace Notebook
{
    public class CommandReader
    {
        private string _helpMessage = "Available commands:\n" +
                                      "add <name>, <phone_number> - add note to notebook\n" +
                                      "rm_index <index> - remove note by index\n" +
                                      "rm <name>, <phone_number> - remove note by note string\n" +
                                      "load <path> - load notebook from file\n" +
                                      "save <path> - store notebook to file system.";
        public INotebookCommand GetNextCommand(Notebook notebook)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                try
                {
                    var splitted = line.Split(" ",2);
                    var commandPart = splitted[0];
                    string dataPart;
                    INote note;
                    switch (commandPart.Trim())
                    {
                        case "add":
                            dataPart = splitted[1];
                            note = new PhoneNote(dataPart);
                            return new AddNoteCommand(notebook, note);
                        case "rm":
                            dataPart = splitted[1];
                            note = new PhoneNote(dataPart);
                            try
                            {
                                return new RemoveNoteCommand(notebook, note);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Note '{note}' not found");
                                Console.ResetColor();
                                break;
                            }
                        case "rm_index":
                            dataPart = splitted[1];
                            int index;
                            try
                            {
                                index = int.Parse(dataPart);
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Can't convert {dataPart} to a number");
                                Console.ResetColor();
                                break;
                            }
                            catch (OverflowException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Index number is overflowed for int32");
                                Console.ResetColor();
                                break;
                            }

                            return new RemoveNoteCommand(notebook, index);
                        case "load":
                            dataPart = splitted[1];
                            return new DeserializeNotebookCommand(out notebook, dataPart);
                        case "save":
                            dataPart = splitted[1];
                            return new SerializeNotebookCommand(notebook, dataPart);
                        case "list":
                            return new ListNotebookCommand(notebook);
                        default:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(_helpMessage);
                            Console.ResetColor();
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error parsing command arguments. See help");
                    Console.ResetColor();
                }
                
            }
            return null;
        }
    }
}