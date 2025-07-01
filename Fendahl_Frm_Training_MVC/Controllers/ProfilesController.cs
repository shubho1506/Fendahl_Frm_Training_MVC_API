using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Profile;
using Fendahl_Frm_Training_MVC.Models;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net.Http.Headers;

namespace Fendahl_Frm_Training_MVC.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:7181/api/profiles";

        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(apiBaseUrl).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                var profiles = JsonConvert.DeserializeObject<List<Profile>>(data);
                return View(profiles);
            }
        }

        //public ActionResult Index()
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        // Tell the API: "Send me XML"
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

        //        var response = client.GetAsync(apiBaseUrl).Result;
        //        var data = response.Content.ReadAsStringAsync().Result;

        //        // Now Deserialize XML
        //        List<Profile> profiles;
        //        XmlSerializer serializer = new XmlSerializer(typeof(List<Profile>));

        //        using (TextReader reader = new StringReader(data))
        //        {
        //            profiles = (List<Profile>)serializer.Deserialize(reader);
        //        }

        //        return View(profiles);
        //    }
        //}



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Profile profile)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(profile);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(apiBaseUrl, content).Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View(profile);
            }
        }

        public ActionResult Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($"{apiBaseUrl}/{id}").Result;
                var data = response.Content.ReadAsStringAsync().Result;
                var profile = JsonConvert.DeserializeObject<Profile>(data);
                return View(profile);
            }
        }

        [HttpPost]
        public ActionResult Edit(Profile profile)
        {
            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(profile);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PutAsync($"{apiBaseUrl}?id={profile.Id}", content).Result;

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return View(profile);
            }
        }

        public ActionResult Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync($"{apiBaseUrl}/{id}").Result;
                var data = response.Content.ReadAsStringAsync().Result;
                var profile = JsonConvert.DeserializeObject<Profile>(data);
                return View(profile);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteC(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync($"{apiBaseUrl}/{id}").Result;
                return RedirectToAction("Index");
            }
        }
    }
}