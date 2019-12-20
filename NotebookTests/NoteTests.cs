using Notebook;
using Notebook.NoteFactory;
using NUnit.Framework;

namespace NotebookTests
{
    [TestFixture]
    class NoteTests
    {
        [Test]
        public void TestCreatePhoneNoteFromStr()
        {
            
            INoteFactory phoneNoteFactory = new PhoneNoteFactory();
            PhoneNote note = (PhoneNote) phoneNoteFactory.createFromCommandLine("Name Surname,1234567");

            Assert.AreEqual(note.Name, "Name Surname");
            Assert.AreEqual(note.Phone, "1234567");
        } 
        
        [Test]
        public void TestCreateStudentNoteFromStr()
        {
            
            INoteFactory phoneNoteFactory = new PhoneNoteFactory();
            PhoneNote note = (PhoneNote) phoneNoteFactory.createFromCommandLine("Name Surname,16203");

            Assert.AreEqual(note.Name, "Name Surname");
            Assert.AreEqual(note.Phone, "16203");
        }
        
        [Test]
        public void TestCreatePhoneNoteFromStrWithTrailingSymbols()
        {
            
            INoteFactory phoneNoteFactory = new PhoneNoteFactory();
            PhoneNote note = (PhoneNote) phoneNoteFactory.createFromCommandLine("  Name Surname  , 1234567\n");

            Assert.AreEqual(note.Name, "Name Surname");
            Assert.AreEqual(note.Phone, "1234567");
        } 
        
        [Test]
        public void TestCreateStudentNoteStrWithTrailingSymbols()
        {
            
            INoteFactory phoneNoteFactory = new PhoneNoteFactory();
            PhoneNote note = (PhoneNote) phoneNoteFactory.createFromCommandLine("  Name Surname  , 16203\n");

            Assert.AreEqual(note.Name, "Name Surname");
            Assert.AreEqual(note.Phone, "16203");
        }
    }
}