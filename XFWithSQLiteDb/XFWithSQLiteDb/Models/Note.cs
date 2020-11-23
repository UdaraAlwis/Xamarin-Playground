using System;
using SQLite;
using Xamarin.Forms;

namespace XFWithSQLiteDb.Models
{
    [Table("note")]
    public class Note
    {
        [PrimaryKey]
        public Guid NoteId { get; set; }

        public string NoteTitle { get; set; }

        public string NoteText { get; set; }

        public DateTime NoteTimeStamp { get; set; }
    }
}
