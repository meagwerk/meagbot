using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace meagbot.Models
{
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        public String UserId { get; set; }
        public int AnswersBytes { get; set; }
        public bool ContactMe { get; set; }
        public String Self
        {
            get { return string.Format(CultureInfo.CurrentCulture,
                  "api/messages/{0}", this.MessageId);
            }
            set { }
        }

    }
}