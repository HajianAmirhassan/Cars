using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models.Entities
{
    public class Setting
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Layout { get; set; }

        public string Keyword { get; set; }
    }
}