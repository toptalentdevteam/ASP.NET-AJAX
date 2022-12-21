using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoHireNow.Models;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Brotli;
using System.IO;
using System;
using Nancy.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace GoHireNow.Controllers
{
    public class JobDetailService : Controller
    {
        [HttpGet]
        public List<JobTitleModel> getJobTitle()
        {
            var client = new RestClient("https://apiv1.evirtualassistants.com/hire/job-titles");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "3d005d61-3873-278a-e16a-ec9f533851c3");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("user-agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Mobile Safari/537.36");
            request.AddHeader("sec-fetch-site", "same-site");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-ch-ua-mobile", "?1");
            request.AddHeader("sec-ch-ua", "\"Google Chrome\";v=\"89\", \"Chromium\";v=\"89\", \";Not\"A Brand\";v=\"99\"");
            request.AddHeader("referer", "https://www.evirtualassistants.com/");
            request.AddHeader("origin", "https://www.evirtualassistants.com");
            request.AddHeader("authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im5ndXllbnN5MTUxMjE5OTdAZ21haWwuY29tIiwianRpIjoiOTA4NGE4OGYtNTEzZS00MjhmLTg4NTctNmRlYmFjNTBiZmI5IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZWlkZW50aWZpZXIiOiI1MGEyNTUxZC04YmQzLTRjNDUtOWI4Yy02MmNhNWYyNzk5MjIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3VzZXJkYXRhIjoie1wiSW50cm9kdWN0aW9uXCI6bnVsbCxcIkZ1bGxOYW1lXCI6bnVsbCxcIkNvbXBhbnlcIjpcIlNhcG90YSBDb3JwXCIsXCJEZXNjcmlwdGlvblwiOm51bGwsXCJDb3VudHJ5SWRcIjoyNTcsXCJQcm9maWxlUGljdHVyZVwiOm51bGwsXCJVc2VyVHlwZVwiOjEsXCJDdXN0b21lclN0cmlwZUlkXCI6bnVsbCxcIlVzZXJSZXN1bWVcIjpudWxsLFwiQ29tcGFueUxvZ29cIjpudWxsLFwiQ3JlYXRlZERhdGVcIjpcIjIwMjEtMDMtMjlUMDk6MzM6MzAuNjE1MzU4NFpcIixcIklzRGVsZXRlZFwiOmZhbHNlLFwiTW9kaWZpZWREYXRlXCI6bnVsbCxcIldoYXRXZURvXCI6bnVsbCxcIlVzZXJUaXRsZVwiOm51bGwsXCJMaW5rZWRpblwiOm51bGwsXCJTa3lwZVwiOm51bGwsXCJGYWNlYm9va1wiOm51bGwsXCJVc2VyU2FsYXJ5XCI6bnVsbCxcIlVzZXJBdmFpbGlibGl0eVwiOm51bGwsXCJVc2VySVBcIjpcIjEyNy4wLjAuMVwiLFwiTGFzdExvZ2luVGltZVwiOlwiMjAyMS0wMy0yOVQwOTozMzozMC42MTUzNTg4WlwiLFwiUmVnaXN0cmF0aW9uRGF0ZVwiOlwiMjAyMS0wMy0yOVQwOTozMzozMS41NzIwMjY0WlwiLFwiRWR1Y2F0aW9uXCI6bnVsbCxcIkV4cGVyaWVuY2VcIjpudWxsLFwiZmVhdHVyZWRcIjowLFwicmF0aW5nXCI6MC4wLFwiR2xvYmFsUGxhbklkXCI6MSxcIlJlZlVybFwiOlwiMTAxXCIsXCJJZFwiOlwiNTBhMjU1MWQtOGJkMy00YzQ1LTliOGMtNjJjYTVmMjc5OTIyXCIsXCJVc2VyTmFtZVwiOlwibmd1eWVuc3kxNTEyMTk5N0BnbWFpbC5jb21cIixcIk5vcm1hbGl6ZWRVc2VyTmFtZVwiOlwiTkdVWUVOU1kxNTEyMTk5N0BHTUFJTC5DT01cIixcIkVtYWlsXCI6XCJuZ3V5ZW5zeTE1MTIxOTk3QGdtYWlsLmNvbVwiLFwiTm9ybWFsaXplZEVtYWlsXCI6XCJOR1VZRU5TWTE1MTIxOTk3QEdNQUlMLkNPTVwiLFwiRW1haWxDb25maXJtZWRcIjp0cnVlLFwiUGFzc3dvcmRIYXNoXCI6XCJBUUFBQUFFQUFDY1FBQUFBRUszSWdLenUxek5oSVNzRlRhTGtucU16ZjRtUkU0bWNXTUF5dnh4T0ZFZFBrOG4wUzA0dndyTkJ4dXEwUnJDOEV3PT1cIixcIlNlY3VyaXR5U3RhbXBcIjpcIlFSM1pENktWTlhGS1ZMWkFLWU9NRlRNRzdNRFRSTFVKXCIsXCJDb25jdXJyZW5jeVN0YW1wXCI6XCI0ZDk0OGQzOC1lNmJiLTRlZjktOTJiNS1hZTc2ZTQxMWI0ODlcIixcIlBob25lTnVtYmVyXCI6bnVsbCxcIlBob25lTnVtYmVyQ29uZmlybWVkXCI6ZmFsc2UsXCJUd29GYWN0b3JFbmFibGVkXCI6ZmFsc2UsXCJMb2Nrb3V0RW5kXCI6bnVsbCxcIkxvY2tvdXRFbmFibGVkXCI6dHJ1ZSxcIkFjY2Vzc0ZhaWxlZENvdW50XCI6MH0iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJDbGllbnQiLCJleHAiOjE2MTk2MDI0MTEsImlzcyI6Imh0dHBzOi8vd3d3LmdvaGlyZW5vdy5jb20iLCJhdWQiOiJodHRwczovL3d3dy5nb2hpcmVub3cuY29tIn0.czN8zO-gfoWouo_sYUaAjDZtUxrxdi2q0sQ1Cwc_Yko");
            request.AddHeader("accept-language", "vi-VN,vi;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
            request.AddHeader("accept-encoding", "gzip, deflate, utf-8");
            request.AddHeader("accept", "application/json, text/plain, */*");
            var response = client.Execute(request);
            string jsonString = response.Content;
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<JobTitleModel> JobTitleModel = js.Deserialize<List<JobTitleModel>>(jsonString);
            return JobTitleModel;
        }
    }
}
