using System;
using JetBrains.Annotations;
using Logic.UserInterface;


namespace Notebook
{
    [Attributes.CommonElement]
    public class AddNoteCommand : INotebookCommand
    {
        [NotNull]
        private readonly INotebook _notebook;
        [NotNull]
        private readonly AddCommandInput _input;
        public AddNoteCommand([NotNull] INotebook notebook, [NotNull] AddCommandInput input)
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
            catch (Exception)
            {
                // ignored
            }
        }
    }
}