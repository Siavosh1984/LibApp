using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using LibApp.Models;
using System.Web.Script.Serialization;

namespace LibApp.Controllers
{
    public class BookController : Controller
    {

        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();


        static BookController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44370/api/bookdata/");
           
    }

        // GET: Book/List
        public ActionResult List()
        {

            //objective:  communicate with our book data api to retrieve a list of books
            //curl https://localhost:44370/api/bookdata/listbooks

           
            string url = "listbooks";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<BookDto> books = response.Content.ReadAsAsync<IEnumerable<BookDto>>().Result;
            Debug.WriteLine("Number of books received: ");
            Debug.WriteLine(books.Count());


            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {

            //objective:  communicate with our book data api to retrieve one book
            //curl https://localhost:44370/api/bookdata/findbook/{id}

           
            string url = "findbook/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is");
            Debug.WriteLine(response.StatusCode);

            BookDto selectedbook = response.Content.ReadAsAsync<BookDto>().Result;
            Debug.WriteLine("books received: ");
            Debug.WriteLine(selectedbook.BookName);

            return View(selectedbook);
        }

        public ActionResult Error()
        {

            return View();
        }

        // GET: Book/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]


         public ActionResult Create(Book book)
        {
        Debug.WriteLine("the json payload is :");
        //Debug.WriteLine(book.BookName);
        //objective: add a new book into our system using the API
        //curl -H "Content-Type:application/json" -d @book.json https://localhost:44370/api/bookdata/addbook 
        string url = "addbook";


        string jsonpayload = jss.Serialize(book);

        Debug.WriteLine(jsonpayload);

        HttpContent content = new StringContent(jsonpayload);
        content.Headers.ContentType.MediaType = "application/json";

        HttpResponseMessage response = client.PostAsync(url, content).Result;
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }
        else
        {
            return RedirectToAction("Error");
        }


         }

    // GET: Book/Edit/5
    public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
