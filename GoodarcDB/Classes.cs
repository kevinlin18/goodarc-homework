using System;

namespace GoodarcDB {
    [Dapper.Contrib.Extensions.Table("Classes")]
    public class Classes {

        [Dapper.Contrib.Extensions.ExplicitKey]
        public string cl_id { get; set; }
        public string cl_name { get; set; }
        public int cl_credit { get; set; }
        public string cl_location { get; set; }
        public string cl_teacher { get; set; }
    }
}
