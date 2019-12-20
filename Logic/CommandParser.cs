using System;
using System.Collections.Generic;

namespace Notebook
{
    [Attributes.ContainerElement]
    public class CommandParser
    {
        private Dictionary<string, INotebookCommand> _commands = new Dictionary<string, INotebookCommand>();
        public CommandParser(List<INotebookCommand> commands)
        {
            foreach (var cmd in commands)
            {
                _commands[cmd.GetType().ToString().Split(".")[1].Replace("Command", "")] = cmd;
            }
        }

        private void ListCommands()
        {
            Console.WriteLine("Available commands: ");
            foreach (var cmd in _commands)
            {
                Console.WriteLine(cmd.Key);
            }
        }
 
        public void Start()
        {
            while (true)
            {
                Console.Write("Enter command: ");
                var commandStr = Console.ReadLine().Trim();
                if (!_commands.ContainsKey(commandStr))
                {
                    ListCommands();
                }
                else
                {
                    try
                    {
                        _commands[commandStr].Execute();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}