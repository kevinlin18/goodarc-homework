using System;

namespace GoodarcDB {
    [Dapper.Contrib.Extensions.Table("Students")]
    public class Students {

        [Dapper.Contrib.Extensions.ExplicitKey]
        public string st_id { get; set; }
        public string st_name { get; set; }
        public DateTime st_birthday { get; set; }
        public string st_email { get; set; }
    }
}
