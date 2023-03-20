using GNWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GNWebApp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult ContactList(string SortOrder, string SortBy)
        {
            try
            {

              
                ViewBag.SortOrder = SortOrder;
                IEnumerable<ContactModel> ContList;
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Contact").Result;
                ContList = response.Content.ReadAsAsync<IEnumerable<ContactModel>>().Result;

                if (response.IsSuccessStatusCode)
                {
                    switch (SortOrder)
                    {
                        case "Asc":
                            {
                                switch (SortBy)
                                {

                                    case "FirstName":
                                        ContList = ContList.OrderBy(cl => cl.FirstName);
                                        break;
                                    case "LastName":
                                        ContList = ContList.OrderBy(cl => cl.LastName);
                                        break;
                                    case "Email":
                                        ContList = ContList.OrderBy(cl => cl.Email);
                                        break;
                                    case "PhoneNumber":
                                        ContList = ContList.OrderBy(cl => cl.PhoneNumber);
                                        break;
                                    case "Address":
                                        ContList = ContList.OrderBy(cl => cl.Address);
                                        break;
                                    case "City":
                                        ContList = ContList.OrderBy(cl => cl.City);
                                        break;
                                    case "State":
                                        ContList = ContList.OrderBy(cl => cl.State);
                                        break;
                                    case "Country":
                                        ContList = ContList.OrderBy(cl => cl.Country);
                                        break;
                                    case "PostalCode":
                                        ContList = ContList.OrderBy(cl => cl.PostalCode);
                                        break;
                                    default:
                                        ContList = ContList.OrderBy(cl => cl.FirstName);
                                        break;
                                }
                                break;
                            }
                        case "Desc":
                            {
                                switch (SortBy)
                                {

                                    case "FirstName":
                                        ContList = ContList.OrderByDescending(cl => cl.FirstName);
                                        break;
                                    case "LastName":
                                        ContList = ContList.OrderByDescending(cl => cl.LastName);
                                        break;
                                    case "Email":
                                        ContList = ContList.OrderByDescending(cl => cl.Email);
                                        break;
                                    case "PhoneNumber":
                                        ContList = ContList.OrderByDescending(cl => cl.PhoneNumber);
                                        break;
                                    case "Address":
                                        ContList = ContList.OrderByDescending(cl => cl.Address);
                                        break;
                                    case "City":
                                        ContList = ContList.OrderByDescending(cl => cl.City);
                                        break;
                                    case "State":
                                        ContList = ContList.OrderByDescending(cl => cl.State);
                                        break;
                                    case "Country":
                                        ContList = ContList.OrderByDescending(cl => cl.Country);
                                        break;
                                    case "PostalCode":
                                        ContList = ContList.OrderByDescending(cl => cl.PostalCode);
                                        break;
                                    default:
                                        ContList = ContList.OrderByDescending(cl => cl.FirstName);
                                        break;
                                }
                                break;
                            }

                        default:
                            ContList = ContList.OrderByDescending(cl => cl.ContactId);
                            break;
                    }
                    return View(ContList);
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult GoogleMap(string Address)
        {
            ViewBag.MapAddres = Address;
            return View("GoogleMap");
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View("AddContact");
        }
        [HttpPost]
        public ActionResult AddContact(ContactModel cont)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Contact", cont).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Msg"] = "Contact :"+ cont.FirstName + " Added Successfully !!";


                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Error Found while Inserting Contact Entry :" + cont.FirstName + " !!";

                    }

                }
                return Redirect("ContactList");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditContact(int? id)
        {
            try
            {
                ContactModel ContList;
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Contact/" + id).Result;
                ContList = response.Content.ReadAsAsync<ContactModel>().Result;

                if (response.IsSuccessStatusCode)

                    return View(ContList);
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        public ActionResult EditContact(ContactModel cont)
         {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Contact/" + cont.ContactId, cont).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Msg"] = "Contact :" + cont.FirstName + "  Updated Successfully !!";


                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Error Found while Updating Contact Entry :" + cont.FirstName + " !!";

                    }

                }
                return RedirectToAction("ContactList");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                ContactModel ContList;
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Contact/" + id).Result;
                ContList = response.Content.ReadAsAsync<ContactModel>().Result;

                if (response.IsSuccessStatusCode)

                    return View(ContList);
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteContact(int id)
        {
            try
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Contact/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Msg"] = "Contact Deleted Successfully !!";


                }
                else
                {
                    TempData["ErrorMsg"] = "Error Found while Deleting Contact Entry !!";

                }
                return RedirectToAction("ContactList");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}