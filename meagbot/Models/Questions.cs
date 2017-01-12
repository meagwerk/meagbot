using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace meagbot.Models
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public String Text { get; set; }
        public virtual ICollection<Answers> Answer { get; set; }
        public String Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
                "api/messages/{0}", this.QuestionId);
            }
            set { }
        }
    }
}