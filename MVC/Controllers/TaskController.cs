using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC.Models.Company;
using FilterVM = MVC.Models.Tasks.FilterVM;
using IndexVM = MVC.Models.Tasks.IndexVM;

namespace MVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly Uri url = new Uri("https://localhost:44362/api/tasks");
        public async Task<ActionResult> Index(IndexVM model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("");
                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<TasksVM>>(jsonString);

                model.Pager = model.Pager ?? new PagerVM();

                model.Pager.Page = model.Pager.Page <= 0
                    ? 1
                    : model.Pager.Page;

                model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0
                    ? 12
                    : model.Pager.ItemsPerPage;


                model.Filter = model.Filter ?? new FilterVM();


                model.Pager.PagesCount = (int)Math.Ceiling(responseData.Where(u =>
                    string.IsNullOrEmpty(model.Filter.Title) || u.Title.Contains(model.Filter.Title)).Count() / (double)model.Pager.ItemsPerPage);


                model.Items = responseData
                    .OrderBy(i => i.TaskId)
                    .Where(u =>
                        string.IsNullOrEmpty(model.Filter.Title) || u.Title.Contains(model.Filter.Title))
                    .Skip(model.Pager.ItemsPerPage * (model.Pager.Page - 1))
                    .Take(model.Pager.ItemsPerPage)
                    .ToList();
                return View(model);
            }
        }
        public async Task<ActionResult> Details(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("tasks/" + id);
                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<TasksVM>(jsonString);

                return View(responseData);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(TasksVM model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = JsonConvert.SerializeObject(model);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var bytecontent = new ByteArrayContent(buffer);
                    bytecontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response = await client.PostAsync("tasks/Save", bytecontent);

                    string jsonString = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<TasksVM>(jsonString);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // make the request
                HttpResponseMessage response = await client.GetAsync("tasks/" + id);

                // parse the response and return data
                string jsonString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<TasksVM>(jsonString);
                return View(responseData);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TasksVM tasksVm)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(tasksVm);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request // Save or Update?
                    HttpResponseMessage response = await client.PutAsync("tasks/Edit", byteContent);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync("tasks/" + id);

                return RedirectToAction("Index");
            }
        }

    }
}