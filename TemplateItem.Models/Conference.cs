using System;
using System.Collections.Generic;

#nullable disable

namespace TemplateItem.Models
{
    public partial class Conference
    {
        //public Conference()
        //{
        //    ConferenceXattendees = new HashSet<ConferenceXattendee>();
        //}

        public int Id { get; set; }
        public int ConferenceTypeId { get; set; }
        public int LocationId { get; set; }
        public string OrganizerEmail { get; set; }
        public int CategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConferenceXattendee> ConferenceXattendees { get; set; }
    }
}
