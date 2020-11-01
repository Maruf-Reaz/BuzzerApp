using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dynamo.Data;
using Dynamo.Model.Exam;
using Microsoft.AspNetCore.Authorization;
using Dynamo.Model.Common.Authentication;
using Microsoft.AspNetCore.Identity;
using Dynamo.Model.Common.ViewModels;

namespace Dynamo.Controllers
{

    public class ExamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ExamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Exams
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var buzzerTimes = _context.BuzzerTimes.ToList();

            foreach (var buzzerTime in buzzerTimes)
            {
                buzzerTime.EnableTime = null;
                buzzerTime.PressTime = null;
                buzzerTime.IsFirst = false;

                _context.Update(buzzerTime);
                _context.SaveChanges();

            }

            var buzzerMarks = _context.BuzzerMarks.ToList();

            foreach (var buzzerMark in buzzerMarks)
            {
                buzzerMark.CorrectAnswer = 0;
                buzzerMark.WrongAnswer = 0;
                buzzerMark.NotAnswered = 0;
                buzzerMark.TotalMark = 0;

                _context.Update(buzzerMark);
                _context.SaveChanges();

            }




            return View(await _context.Exams.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<JsonResult> AddExam(string name, int typeId)
        {
            Exam exam = new Exam();
            exam.Name = name;
            exam.TypeId = typeId;

            _context.Add(exam);
            await _context.SaveChangesAsync();
            var lastExam = _context.Exams.LastOrDefault();
            return Json(lastExam);
        }


        [HttpPost]
        public async Task<JsonResult> BuzzerPress(int buzzerId)
        {
            var pressedBuzzer = await _context.BuzzerTimes
                .Where(m => m.IsFirst == true).FirstOrDefaultAsync();

            var buzzerTime = await _context.BuzzerTimes
                .Where(m => m.BuzzerNumber == buzzerId).FirstOrDefaultAsync();

            if (pressedBuzzer == null)
            {
                buzzerTime.IsFirst = true;

            }


            buzzerTime.PressTime = DateTime.Now;

            _context.Update(buzzerTime);
            await _context.SaveChangesAsync();

            return Json(true);
        }
        [HttpPost]
        public async Task<JsonResult> EnablesBuzzers()
        {

            var buzzerTimes = _context.BuzzerTimes.ToList();
            DateTime enableTime = DateTime.Now;

            foreach (var buzzerTime in buzzerTimes)
            {
                buzzerTime.EnableTime = enableTime;
                buzzerTime.PressTime = null;

                _context.Update(buzzerTime);
                await _context.SaveChangesAsync();

            }

            return Json(true);
        }
        [HttpPost]
        public async Task<JsonResult> CorrectAnswer(int buzzerId)
        {

            var buzzerMark = await _context.BuzzerMarks
                 .Where(m => m.BuzzerNumber == buzzerId).FirstOrDefaultAsync();

            buzzerMark.CorrectAnswer = buzzerMark.CorrectAnswer + 1;
            buzzerMark.TotalMark = buzzerMark.TotalMark + 2;
            _context.Update(buzzerMark);
            await _context.SaveChangesAsync();

            return Json(true);
        }
        [HttpPost]
        public async Task<JsonResult> WrongAnswer(int buzzerId)
        {

            var buzzerMark = await _context.BuzzerMarks
                 .Where(m => m.BuzzerNumber == buzzerId).FirstOrDefaultAsync();

            buzzerMark.WrongAnswer = buzzerMark.WrongAnswer + 1;
            buzzerMark.TotalMark = buzzerMark.TotalMark - 1;
            _context.Update(buzzerMark);
            await _context.SaveChangesAsync();

            return Json(true);
        }
        [HttpPost]
        public async Task<JsonResult> NotAnswered(int buzzerId)
        {

            var buzzerMark = await _context.BuzzerMarks
                 .Where(m => m.BuzzerNumber == buzzerId).FirstOrDefaultAsync();

            buzzerMark.NotAnswered = buzzerMark.NotAnswered + 1;
            buzzerMark.TotalMark = buzzerMark.TotalMark - .5;
            _context.Update(buzzerMark);
            await _context.SaveChangesAsync();

            return Json(true);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.
                Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.Remove(question);
            await _context.SaveChangesAsync();
            return Json(true);
        }
        [HttpPost]
        public async Task<JsonResult> GetBuzzertimes()
        {

            var buzzerTimes = await _context.BuzzerTimes.ToListAsync();

            return Json(buzzerTimes);
        }
        [HttpPost]
        public async Task<JsonResult> GetActiveQustion()
        {

            var activeQuestion = await _context.Questions
                .Where(m => m.IsActive)
                .FirstOrDefaultAsync();


            return Json(activeQuestion);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddQuestions(int examId)
        {
            var exam = _context.Exams.Where(m => m.Id == examId).FirstOrDefault();
            var questions = _context.Questions.Where(m => m.ExamId == examId).ToList();


            ViewData["Questions"] = questions;
            ViewData["Exam"] = exam;

            return View();
        }
        public IActionResult ResetExam()
        {

            var buzzerTimes = _context.BuzzerTimes.ToList();

            foreach (var buzzerTime in buzzerTimes)
            {
                buzzerTime.EnableTime = null;
                buzzerTime.PressTime = null;
                buzzerTime.IsFirst = false;

                _context.Update(buzzerTime);
                _context.SaveChanges();

            }

            var buzzerMarks = _context.BuzzerMarks.ToList();

            foreach (var buzzerMark in buzzerMarks)
            {
                buzzerMark.CorrectAnswer = 0;
                buzzerMark.WrongAnswer = 0;
                buzzerMark.NotAnswered = 0;
                buzzerMark.TotalMark = 0;

                _context.Update(buzzerMark);
                _context.SaveChanges();

            }




            var questions = _context.Questions.ToList();
            foreach (var question in questions)
            {
                question.IsActive = false;
                _context.Update(question);
                _context.SaveChanges();
            }



            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public IActionResult PlayBuzzer(int examId, int questionId)
        {
            bool noQuestions = false;
            bool noNextQuestions = false;


            var buzzerTimes = _context.BuzzerTimes.ToList();

            foreach (var buzzerTime in buzzerTimes)
            {
                buzzerTime.EnableTime = null;
                buzzerTime.PressTime = null;
                buzzerTime.IsFirst = false;

                _context.Update(buzzerTime);
                _context.SaveChanges();

            }






            if (questionId == 0)
            {
                var tQuestions = _context.Questions.Where(m => m.ExamId == examId).ToList();
                foreach (var tQuestion in tQuestions)
                {
                    tQuestion.IsActive = false;
                    _context.Update(tQuestion);
                    _context.SaveChanges();
                }



                var question = _context.Questions
              .Where(m => m.ExamId == examId)
              .OrderBy(m => m.Id)
              .FirstOrDefault();
                if (question != null)
                {
                    question.IsActive = true;
                    _context.Update(question);
                    _context.SaveChanges();
                }
                else
                {
                    noQuestions = true;
                }




            }
            else
            {
                var question = _context.Questions
            .Where(m => m.Id == questionId)
            .OrderBy(m => m.Id)
            .FirstOrDefault();
                question.IsActive = false;
                _context.Update(question);
                _context.SaveChanges();


                var nextQuestion = _context.Questions
             .Where(m => m.Id > questionId && m.ExamId == examId)
             .OrderByDescending(m => m.Id)
             .LastOrDefault();

                if (nextQuestion != null)
                {
                    nextQuestion.IsActive = true;
                    _context.Update(nextQuestion);
                    _context.SaveChanges();
                }
                else
                {
                    noNextQuestions = true;
                }
            }
            var questions = _context.Questions.Where(m => m.ExamId == examId).ToList();
            if (questions.Count == 0)
            {
                noQuestions = true;

            }

           
            var finalBuzzerMarks = _context.BuzzerMarks.ToList();
            var maxMark = _context.BuzzerMarks.Max(m => m.TotalMark);
            ViewData["FinalBuzzerMarks"] = finalBuzzerMarks;
            ViewData["MaxMark"] = maxMark;

            ViewData["Questions"] = questions;
            ViewData["NoQuestion"] = noQuestions;
            ViewData["NoNextQuestion"] = noNextQuestions;
            return View();
        }
        public async Task<JsonResult> AddExamQuestion(int examId, int examQuestionId, string description, string option1, string option2, string option3, string option4, int correct_answer , string single_answer)
        {
            if (examQuestionId == 0)
            {
                Question question = new Question();

                question.Description = description;
                question.ExamId = examId;
                question.Option1 = option1;
                question.Option2 = option2;
                question.Option3 = option3;
                question.Option4 = option4;


                if (correct_answer == 1)
                {
                    question.IsOption1Correct = true;
                    question.IsOption2Correct = false;
                    question.IsOption3Correct = false;
                    question.IsOption4Correct = false;
                }
                if (correct_answer == 2)
                {
                    question.IsOption1Correct = false;
                    question.IsOption2Correct = true;
                    question.IsOption3Correct = false;
                    question.IsOption4Correct = false;
                }
                if (correct_answer == 3)
                {
                    question.IsOption1Correct = false;
                    question.IsOption2Correct = false;
                    question.IsOption3Correct = true;
                    question.IsOption4Correct = false;
                }
                if (correct_answer == 4)
                {
                    question.IsOption1Correct = false;
                    question.IsOption2Correct = false;
                    question.IsOption3Correct = false;
                    question.IsOption4Correct = true;
                }
                if (correct_answer == 0)
                {
                    question.HasOption = false;
                    question.Answer = single_answer;
                }
                else
                {
                    question.HasOption = true;
                   
                }
                _context.Add(question);
                await _context.SaveChangesAsync();

                var lastId = _context.Questions.LastOrDefault();
                return Json(lastId.Id);
            }
            else
            {

                var question = await _context.Questions
             .FirstOrDefaultAsync(m => m.Id == examQuestionId);

                question.Description = description;
                question.ExamId = examId;
                question.Option1 = option1;
                question.Option2 = option2;
                question.Option3 = option3;
                question.Option4 = option4;

                if (correct_answer == 1)
                {
                    question.IsOption1Correct = true;
                    question.IsOption2Correct = false;
                    question.IsOption3Correct = false;
                    question.IsOption4Correct = false;
                }
                if (correct_answer == 2)
                {
                    question.IsOption1Correct = false;
                    question.IsOption2Correct = true;
                    question.IsOption3Correct = false;
                    question.IsOption4Correct = false;
                }
                if (correct_answer == 3)
                {
                    question.IsOption1Correct = false;
                    question.IsOption2Correct = false;
                    question.IsOption3Correct = true;
                    question.IsOption4Correct = false;
                }
                if (correct_answer == 4)
                {
                    question.IsOption1Correct = false;
                    question.IsOption2Correct = false;
                    question.IsOption3Correct = false;
                    question.IsOption4Correct = true;
                }
                if (correct_answer == 0)
                {
                    question.HasOption = false;
                    question.Answer = single_answer;
                }
                else
                {
                    question.HasOption = true;
                }




                _context.Update(question);
                await _context.SaveChangesAsync();

                return Json(examQuestionId);
            }

            //var defectList = _context.DefectLists
            //     .FirstOrDefaultAsync(m => m.Id == id);

            //JobInformation jobInformation = _context.JobInformations.Find(id);
            //ViewData["JobInformation"] = jobInformation;

        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }
        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }
        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Exam exam)
        {
            if (id != exam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }
        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }
        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.Id == id);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PlayMcq(int examId)
        {
            var questions = await _context.Questions.Where(m => m.ExamId == examId).ToListAsync();
            var userId = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Id; //same thing


            var users = await _context.UserRoles
               .Where(m => m.RoleId == "372ca669g-5f0d-47et-9f82-99a1e7ebbbf2").ToListAsync();


            foreach (var user in users)
            {
                foreach (var question in questions)
                {
                    McqMark mcqMark = new McqMark();
                    mcqMark.UserId = user.UserId;
                    mcqMark.QuestionId = question.Id;
                    ;
                    if (question.IsOption1Correct)
                    {
                        mcqMark.CorrecAnswer = 1;
                    }
                    if (question.IsOption2Correct)
                    {
                        mcqMark.CorrecAnswer = 2;
                    }
                    if (question.IsOption3Correct)
                    {
                        mcqMark.CorrecAnswer = 3;
                    }
                    if (question.IsOption4Correct)
                    {
                        mcqMark.CorrecAnswer = 4;
                    }
                    mcqMark.GivenAnswer = 0;
                    mcqMark.ExamId = examId;
                    _context.Add(mcqMark);
                    await _context.SaveChangesAsync();

                }

            }

            return RedirectToAction("StartView", "Home", new { examId = examId });

        }

        public async Task<JsonResult> AddAnswer(int checkedValue, int examQuestionId)
        {
            var userId = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Id; //same thing
            var mcqMark = await _context.McqMarks
                .Where(m => m.QuestionId == examQuestionId && m.UserId == userId)
                .FirstOrDefaultAsync();
            mcqMark.GivenAnswer = checkedValue;
            _context.Update(mcqMark);
            await _context.SaveChangesAsync();

            return Json(true);
        }
        public async Task<IActionResult> GetMcqResult(int examId)
        {
            var userId = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Id; //same thing



            if (userId == "8e09035f-c640-4ac0-8d5c-4a63d3eddfab")
            {
                List<McqMarkViewModel> mcqMarkViewModels = new List<McqMarkViewModel>();

                var users = await _context.UserRoles
                    .Where(m => m.RoleId == "372ca669g-5f0d-47et-9f82-99a1e7ebbbf2").ToListAsync();

                foreach (var user in users)
                {
                    McqMarkViewModel mcqMarkViewModel = new McqMarkViewModel();
                    mcqMarkViewModel.UserId = user.UserId;

                    var tempUser = await _context.Users
                        .Where(m => m.Id == user.UserId).
                        FirstOrDefaultAsync();
                    mcqMarkViewModel.UserName = tempUser.UserName;

                    var marks = await _context.McqMarks
                        .Include(m => m.Question)
                        .Where(m => m.ExamId == examId && m.UserId == user.UserId)
                        .ToListAsync();


                    foreach (var mark in marks)
                    {
                        if (mark.CorrecAnswer == mark.GivenAnswer)
                        {

                            mcqMarkViewModel.TotalMark += 1;

                        }

                    }

                    mcqMarkViewModels.Add(mcqMarkViewModel);
                    ViewData["Results"] = mcqMarkViewModels;


                }

            }

            else
            {
                var marks = await _context.McqMarks
                       .Include(m => m.Question)
                       .Where(m => m.ExamId == examId && m.UserId == userId)
                       .ToListAsync();
                int totalMark = 0;
                foreach (var mark in marks)
                {
                    if (mark.CorrecAnswer == mark.GivenAnswer)
                    {

                       totalMark += 1;

                    }

                }
                ViewData["Marks"] = marks;
                ViewData["TotalMark"] = totalMark;
            }


            ViewData["UserId"] = userId;


            return View();
        }


        public IActionResult ResetMcq(int examId)
        {

            var mcqResults = _context.McqMarks
                .Where(m => m.ExamId ==examId)
                .ToList();

            foreach (var mcqResult in mcqResults)
            {
               
                _context.Remove(mcqResult);
                _context.SaveChanges();

            }

           
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<JsonResult> GetSecondBuzzer(int buzzerId)
        {

            var buzzer = await _context.BuzzerTimes
                 .Where(m => m.BuzzerNumber != buzzerId && m.PressTime != null)
                 .OrderBy(m => m.PressTime)
                 .FirstOrDefaultAsync();

           

            return Json(buzzer.BuzzerNumber);
        }






    }
}
