﻿using Dapper;
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
    public class ClassesController : Controller {
        public IActionResult Get() {
            var results = new List<Classes>();
            using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                results = conn.GetAll<Classes>().AsList();
            }
            return Json(results);
        }
        public IActionResult Create([FromBody] Classes model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    conn.Insert(model);
                    result.success = true;
                }
            } catch (Exception ex) {
                result.message = ex.Message;
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
        public IActionResult Update([FromBody] Classes model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    var affected = conn.Update(model);
                    if (affected) {
                        result.success = true;
                    }
                }
            } catch (Exception ex) {
                result.message = ex.Message;
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
        public IActionResult Delete([FromBody] Classes model) {
            var result = new BasicResult();
            try {
                using (var conn = new SqlConnection(clsDefine.ConnStr)) {
                    var affected = conn.Delete(model);
                    if (affected) {
                        result.success = true;
                    }
                }
            } catch (Exception ex) {
                result.message = ex.Message;
                //_logger.LogError(ex.Message);
            }
            return Json(result);
        }
    }
}
