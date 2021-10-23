using System;

namespace GoodarcDB {
    [Dapper.Contrib.Extensions.Table("StudentClass")]
    public class StudentClass {

        public string sc_stId { get; set; }
        public string sc_clId { get; set; }
    }
}
