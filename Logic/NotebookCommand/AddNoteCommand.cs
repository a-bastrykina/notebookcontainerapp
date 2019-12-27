using System;
using Logic.UserInterface;


namespace Notebook
{
    [Attributes.CommonElement]
    public class AddNoteCommand : INotebookCommand
    {
        private readonly INotebook _notebook;
        private readonly AddCommandInput _input;
        public AddNoteCommand(INotebook notebook, AddCommandInput input)
        {
            _input = input;
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