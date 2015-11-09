using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Drawing;

namespace QRCodeDemo.Controllers
{
    public class ORCodeController : Controller
    {

        //
        // GET: /ORCode/
        public ActionResult Index()
        {
            return View();

        }


        [HttpPost]
        public ActionResult GetORImage(string content)
        {
            //if (string.IsNullOrEmpty(content))
            //{
            //    return Content("");
            //}


            string timeStr = DateTime.Now.ToFileTime().ToString();
            Bitmap bitmap = QRCodeOp.QRCodeEncoderUtil(content);
            string fileName = Server.MapPath("~") + "Content\\Images\\QRImages\\" + timeStr + ".jpg";
            bitmap.Save(fileName);//保存位图
            string imageUrl = "/Content/Images/QRImages/" + timeStr + ".jpg";//显示图片  
            return Content(imageUrl);
        }

        [HttpPost]
        public ActionResult GetORImageContent(string imageName)
        {
            string fileUrl = Server.MapPath("~") + "Content\\Images\\QRImages\\" + imageName;
            Bitmap bitMap = new Bitmap(fileUrl);
            string content = QRCodeOp.QRCodeDecoderUtil(bitMap);
            return Content(content);
        }


    }
}
