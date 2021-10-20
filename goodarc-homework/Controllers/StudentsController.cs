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

namespace Homework.Controllers
{
    public class StudentsController : Controller {
        public IActionResult Get() {
            var results = new List<Students>();
            using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                results = conn.GetAll<Students>().AsList();
            }
            return Json(results);
        }
        public IActionResult Set([FromBody] Students model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    var affectedRows = conn.Insert(model);
                    if (affectedRows > 0) {
                        result.success = true;
                    }
                }
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
        public IActionResult Update([FromBody] Students model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    var affected = conn.Update(model);
                    if (affected) {
                        result.success = true;
                    }
                }
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
        public IActionResult Delete([FromBody] Students model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    var affected = conn.Delete(model);
                    if (affected) {
                        result.success = true;
                    }
                }
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
    }
}
