using System;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using Logic.UserInterface;
using Notebook.NoteFactory;

namespace Notebook
{
    [ContainerElement]
    public class AddNoteCommand : INotebookCommand
    {
        private INotebook _notebook;
        private AddCommandInput _input;
        public AddNoteCommand(INotebook notebook, AddCommandInputFactory inputFactory)
        {
            _input = inputFactory.GetInput();
            _notebook = notebook;
        }
        
        public void Execute()
        {
            try
            {
                var note = _input.GetNote();
                _notebook.Notes.Add(note);
            }
            catch (Exception) { }
        }
    }
}