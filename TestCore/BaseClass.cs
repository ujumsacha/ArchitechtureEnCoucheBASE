﻿namespace TestCore
{
    public class BaseClass
    {
        public string r_id { get; set; }
        public string r_created_by { get; set; }
        public string? r_update_by { get; set; }
        public bool r_is_delete { get; set; }
        public bool r_is_desactivate { get; set; }
        public DateTime r_created_on { get; set; }
        public DateTime? r_update_on { get; set; }

    }
}