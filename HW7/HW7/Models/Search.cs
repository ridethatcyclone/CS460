namespace HW7
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Search
    {
        public int SearchID { get; set; }

        [Required]
        [StringLength(128)]
        public string SearchPhrase { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
