using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace meagbot.Models
{
    public class Answers
    {
        [Key]
        public int AnswerId { get; set; }
        public String Text { get; set; }
        public int Weight { get; set; }
        public virtual Questions Question { get; set; }
        public String Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
                "api/messages/{0}", this.AnswerId);
            }
            set { }
        }
    }
}