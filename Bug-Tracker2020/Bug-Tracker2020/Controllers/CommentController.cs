﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bug_Tracker2020.Data;
using Bug_Tracker2020.Models;
using Bug_Tracker2020.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bug_Tracker2020.Controllers
{
    public class CommentController : Controller
    {
        private BugDbContext context;

        public CommentController(BugDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        //Locate a Bug and return that Bug
        public Bug Find(int id)
        {
            var aBug = context.Bugs.Single(b => b.ID == id);
            return aBug;
        }



        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        //Create a comment
        [HttpPost]
        public IActionResult Add(AddCommentViewModel addCommentViewModel)
        {
            if (ModelState.IsValid)
            {
                Comment newComment = new Comment
                {
                    UserID = 7,
                    Date = addCommentViewModel.Date,
                    CommentBody = addCommentViewModel.CommentBody,
                    Bug = Find(addCommentViewModel.Bug.ID),

                };
                context.Comments.Add(newComment);
                context.SaveChanges();

                return Redirect("/Bug/SingleBug?id=" + addCommentViewModel.Bug.ID);
                //return Redirect("/Bug/SingleBug?id=" + newBug.ID);
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }

            return View();

        }



        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}