using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using meagbot.Models;

namespace meagbot.Controllers
{
    public class ConversationsController : Controller
    {
        private meagbotContext db = new meagbotContext();

        // GET: Conversations
        public async Task<ActionResult> Index()
        {
            return View(await db.Messages.ToListAsync());
        }

        // GET: Conversations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = await db.Messages.FindAsync(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // GET: Conversations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conversations/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MessageId,UserId,AnswersBytes,ContactMe,Self")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(messages);
        }

        // GET: Conversations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = await db.Messages.FindAsync(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: Conversations/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MessageId,UserId,AnswersBytes,ContactMe,Self")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messages).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(messages);
        }

        // GET: Conversations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = await db.Messages.FindAsync(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: Conversations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Messages messages = await db.Messages.FindAsync(id);
            db.Messages.Remove(messages);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
