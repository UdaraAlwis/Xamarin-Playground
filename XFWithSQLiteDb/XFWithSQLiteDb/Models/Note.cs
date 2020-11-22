using System;

namespace XFWithSQLiteDb.Models
{
    public class Note
    {
        public Guid NoteId { get; set; }

        public string NoteTitle { get; set; }

        public string NoteText { get; set; }

        public DateTime NoteTimeStamp { get; set; }
    }
}
