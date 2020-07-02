using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testMvc.Services;
using testMvc.Models;
namespace testMvc.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryService _stories;
        public StoryController(IStoryService storyService)
        {
            _stories = storyService;
        }
        // GET: StoryController
        public async Task<ActionResult> Index()
        {
            var res = await _stories.Get();
            return View(res.ToList());
        }

        // GET: StoryController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var res = await _stories.Get(id);
            return View(res);
        }

        // GET: StoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Story storyIn)
        {
             
            try
            {
                await _stories.Create(storyIn);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoryController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            
            return View(await _stories.Get(id));
        }

        // POST: StoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind("id,title,main,vote")] Story model)
        {
         
            
            try
            {
                await _stories.Edit(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
