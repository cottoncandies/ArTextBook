using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scietec.Combine.Inject;
using Alva.ArTextBook.Kernel.Services;
using System.Threading.Tasks;
using System.IO;
using Alva.ArTextBook.TextBook.Tdm;
using Alva.ArTextBook.Types;
using System.Collections.Generic;
using Alva.ArTextBook.TextBook.Vdm;
using System;

namespace Alva.ArTextBook.Features.TextBook
{
    //[Route("Api/V1/User/[action]/{id?}")]
    public class TextBookApiController : BaseController
    {
        [Autowired]
        GradeService gradeService = null;
        [Autowired]
        SubjectService subjectService = null;
        [Autowired]
        PublishService publishService = null;
        [Autowired]
        EditionService editionService = null;
        [Autowired]
        TextBookService textBookService = null;

        public TextBookApiController()
        {
            BeanManager.Autowire(this);
        }

        public ActionResult GetGrades()
        {
           return Json(MethodResult<List<GradeTdm>>.Successful(gradeService.GetAll()));
        }

        public ActionResult GetSubjects()
        {
            return Json(MethodResult<List<SubjectTdm>>.Successful(subjectService.GetAll()));
        }
        public ActionResult GetPublishs()
        {
            return Json(MethodResult<List<PublishTdm>>.Successful(publishService.GetAll()));
        }

        public ActionResult GetEditions()
        {
            return Json(MethodResult<List<EditionTdm>>.Successful(editionService.GetAll()));
        }

        public ActionResult GetTextBooks()
        {
            return Json(MethodResult<List<TextbookTdm>>.Successful(textBookService.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            //上传图书
                var filePath = @"E:\UploadingFiles\" + file.FileName;

                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }


            //记录数据


            //返回数据
            return Ok(new { url= filePath });
        }

        [HttpPost]
        public ActionResult UploadForm(TextbookTdm textbook)
        {

            //接收数据并存入数据库
            textBookService.Save(textbook);

            //返回信息
            return Ok(new { msg = "ok" });
        }
    }
}