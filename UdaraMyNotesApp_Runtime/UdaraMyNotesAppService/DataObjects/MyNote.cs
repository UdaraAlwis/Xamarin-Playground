using System;
using Microsoft.Azure.Mobile.Server;

namespace UdaraMyNotesAppService.DataObjects
{
    public class MyNote : EntityData
    {
        public DateTime TimeStamp { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}