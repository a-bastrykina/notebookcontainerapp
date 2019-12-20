using System;
using System.Collections.Generic;
using Notebook;
using Notebook.NoteFactory;
using NotebookTests.Mock;
using NUnit.Framework;

namespace NotebookTests
{
    [TestFixture]
    public class NotebookCommandTests
    {
        private static List<INoteFactory> _factories = new List<INoteFactory>()
            {new PhoneNoteFactory(), new StudentNoteFactory()};

        [Test]
        public void AddPhoneNoteCommandTest()
        {
            var notebook = new Notebook.Notebook();
            var commandLineInputs = new List<string>() {"PhoneNote", "Name Surname, 1234567"};
            var inputMock = new TextReaderMock(commandLineInputs);
            
            
            var addCommand = new AddNoteCommand(_factories, notebook);
            
            Console.SetIn(inputMock);
            
            addCommand.Execute();
            
            Assert.AreEqual(1, notebook.Notes.Count);
            INote note = notebook.Notes[0];
            
            Assert.IsTrue(note is PhoneNote);

            PhoneNote phoneNote = (PhoneNote) note;
            
            Assert.AreEqual("Name Surname",phoneNote.Name);
            Assert.AreEqual("1234567",phoneNote.Phone);
        }
        
        [Test]
        public void AddStudentNoteCommandTest()
        {
            var notebook = new Notebook.Notebook();
            var commandLineInputs = new List<string>() {"StudentNote", "Name Surname, 16203"};
            var inputMock = new TextReaderMock(commandLineInputs);
            
            var addCommand = new AddNoteCommand(_factories, notebook);
            
            Console.SetIn(inputMock);
            
            addCommand.Execute();
            
            Assert.AreEqual(1, notebook.Notes.Count);
            var note = notebook.Notes[0];
            
            Assert.IsTrue(note is StudentNote);

            StudentNote studentNote = (StudentNote) note;
            
            Assert.AreEqual("Name Surname",studentNote.Name);
            Assert.AreEqual("16203",studentNote.Group);
        }
        
        [Test]
        public void AddStudentNoteWithBadFormatTest()
        {
            var notebook = new Notebook.Notebook();
            var commandLineInputs = new List<string>() {"StudentNote", "Name Surname16203"};
            var inputMock = new TextReaderMock(commandLineInputs);
            
            var addCommand = new AddNoteCommand(_factories, notebook);
            
            Console.SetIn(inputMock);
            
            addCommand.Execute();
            
            Assert.AreEqual(0, notebook.Notes.Count);
        }
        
        [Test]
        public void AddPhoneNoteWithBadFormatTest()
        {
            var notebook = new Notebook.Notebook();
            var commandLineInputs = new List<string>() {"PhoneNote", "Name Surname 123456"};
            var inputMock = new TextReaderMock(commandLineInputs);
            
            var addCommand = new AddNoteCommand(_factories, notebook);
            
            Console.SetIn(inputMock);
            
            addCommand.Execute();
            
            Assert.AreEqual(0, notebook.Notes.Count);
        }

        [Test]
        public void TryAddNoteWithNotRegisteredType()
        {
            var notebook = new Notebook.Notebook();
            var commandLineInputs = new List<string>() {"unregistered", "Name Surname, 16203"};
            var inputMock = new TextReaderMock(commandLineInputs);
            
            var addCommand = new AddNoteCommand(_factories, notebook);

            Console.SetIn(inputMock);
            
            var outputMock = new TextWriterMock();
            Console.SetOut(outputMock);
            addCommand.Execute();
            
            Assert.AreEqual(0, notebook.Notes.Count);
            Assert.IsTrue( outputMock.CapturedOutputs.Count != 0);
            Assert.IsTrue( outputMock.CapturedOutputs[0].StartsWith("Available note types"));
        }

        [Test]
        public void RemoveNoteCommandTest()
        {
            var notebook = new Notebook.Notebook();
            notebook.Notes.Add(new PhoneNote("Name", "123"));
            RemoveNoteCommand removeCommand = new RemoveNoteCommand(notebook);
            
            var commandLineInputs = new List<string>() {"Name, 123"};
            var inputMock = new TextReaderMock(commandLineInputs);
            
            Console.SetIn(inputMock);
            
            removeCommand.Execute();
            
            Assert.AreEqual(0, notebook.Notes.Count);
        }
        
        [Test]
        public void RemoveNotExistingNoteCommandTest()
        {
            var notebook = new Notebook.Notebook();
            notebook.Notes.Add(new PhoneNote("Name", "123"));
            RemoveNoteCommand removeCommand = new RemoveNoteCommand(notebook);
            
            var commandLineInputs = new List<string>() {"absent, 123"};
            var inputMock = new TextReaderMock(commandLineInputs);
            
            Console.SetIn(inputMock);
            
            removeCommand.Execute();
            
            Assert.AreEqual(1, notebook.Notes.Count);
        }
        
        [Test]
        public void ListNotebookCommandTest()
        {
            var notebook = new Notebook.Notebook();
            notebook.Notes.Add(new PhoneNote("Name1", "123"));
            notebook.Notes.Add(new StudentNote("Name2", "12003"));

            ListNotebookCommand listNotebookCommand = new ListNotebookCommand(notebook);
            
            var outputMock = new TextWriterMock();
            Console.SetOut(outputMock);
            listNotebookCommand.Execute();
            
            Assert.AreEqual( 2, outputMock.CapturedOutputs.Count);
        }
        
        [Test]
        public void ListEmptyNotebookTest()
        {
            var notebook = new Notebook.Notebook();

            ListNotebookCommand listNotebookCommand = new ListNotebookCommand(notebook);
            
            var outputMock = new TextWriterMock();
            Console.SetOut(outputMock);
            listNotebookCommand.Execute();
            
            Assert.AreEqual( 0, outputMock.CapturedOutputs.Count);
        }
        
    }
}