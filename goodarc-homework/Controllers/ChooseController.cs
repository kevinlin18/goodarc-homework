using Dapper;
using Dapper.Contrib.Extensions;
using GoodarcDB;
using Homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Controllers {
    public class ChooseController : Controller {
        public IActionResult Initial() {
            var results = new InitialResult();
            using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                var classes = conn.GetAll<Classes>();
                results.classes = classes
                    .Select(e => new TextValue { text = e.cl_name, value = e.cl_id })
                    .AsList();
                var sql = @"SELECT * FROM Students
                    LEFT JOIN StudentClass ON st_id = sc_stId
                    WHERE sc_stId IS NULL";
                //var students = conn.GetAll<Students>();
                var students = conn.Query<Students>(sql);
                results.students = students
                    .Select(e => new TextValue { text = e.st_id + "(" + e.st_name + ")", value = e.st_id})
                    .AsList();
            }
            return Json(results);
        }
        public IActionResult Get() {
            var results = new List<dynamic>();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    //var sql = "SELECT * FROM StudentClass";
                    //results = conn.Query<StudentClass>(sql).AsList();
                    var sql = @"SELECT st_id,STRING_AGG(cl_name, ',') AS cl_names FROM Students
                        INNER JOIN StudentClass ON st_id = sc_stId
                        LEFT JOIN Classes ON cl_id = sc_clId
                        GROUP BY st_id";
                    results = conn.Query(sql).AsList();
                }
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
            }
            return Json(results);
        }
        public IActionResult GetStudentClass([FromBody] GetStudentClassModel model) {
            var result = new GetStudentClassResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    var sql = "SELECT sc_clId FROM StudentClass WHERE sc_stId=@sc_stId";
                    result.cl_ids = conn.Query<string>(sql, new { sc_stId = model.st_id }).AsList();
                    sql = "SELECT * FROM Students WHERE st_id=@st_id";
                    var students = conn.Query<Students>(sql, new { st_id = model.st_id });
                    result.students = students
                        .Select(e => new TextValue { text = e.st_id + "(" + e.st_name + ")", value = e.st_id})
                        .AsList();
                    result.st_id = model.st_id;
                }
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }

        public IActionResult Create([FromBody] CreateModel model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction()) {
                        try {

                            foreach (var item in model.cl_ids) {
                                var sc = new StudentClass {
                                    sc_stId = model.st_id,
                                    sc_clId = item
                                };
                                conn.Insert(sc, transaction);
                            }
                            transaction.Commit();
                            result.success = true;
                        } catch (Exception ex) {
                            //_logger.LogError(ex.Message);
                            transaction.Rollback();
                        }
                    }
                }
            } catch (Exception ex) {
                result.message = ex.Message;
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
        public IActionResult Update([FromBody] CreateModel model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction()) {
                        try {
                            var sql = "DELETE FROM StudentClass WHERE sc_stId=@sc_stId";
                            conn.Query(sql, new { sc_stId = model.st_id }, transaction);
                            foreach (var item in model.cl_ids) {
                                var sc = new StudentClass {
                                    sc_stId = model.st_id,
                                    sc_clId = item
                                };
                                conn.Insert(sc, transaction);
                            }
                            transaction.Commit();
                            result.success = true;
                        } catch (Exception ex) {
                            //_logger.LogError(ex.Message);
                            transaction.Rollback();
                        }
                    }
                }
            } catch (Exception ex) {
                result.message = ex.Message;
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
        public IActionResult Delete([FromBody] Students model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    var sql = "DELETE FROM StudentClass WHERE sc_stId=@sc_stId";
                    conn.Query(sql, new { sc_stId = model.st_id });
                    result.success = true;
                }
            } catch (Exception ex) {
                result.message = ex.Message;
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
        public class InitialResult {
            public List<TextValue> classes { get; set; }
            public List<TextValue> students { get; set; }
        }
        public class GetStudentClassModel {
            public string st_id { get; set; }
        }
        public class GetStudentClassResult {
            public string st_id { get; set; }
            public List<TextValue> students { get; set; }
            public List<string> cl_ids { get; set; } = new List<string>();
        }
        public class CreateModel {
            public string st_id { get; set; }
            public List<string> cl_ids { get; set; }
        }
    }
}
