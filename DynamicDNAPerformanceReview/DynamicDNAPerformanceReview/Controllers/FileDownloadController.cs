using DynamicDNAPerformanceReview.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamicDNAPerformanceReview.Controllers
{
    public class FileDownloadController : Controller
    {
        // GET: FileDownload
        public ActionResult FileHome()
        {
            return View();
        }



        public ActionResult Download()
        {
            FileDownloads obj = new FileDownloads();
            //////int CurrentFileID = Convert.ToInt32(FileID);  
            var filesCol = obj.GetFile().ToList();
            using (var memoryStream = new MemoryStream())
            {
                using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    for (int i = 0; i < filesCol.Count; i++)
                    {
                        ziparchive.CreateEntryFromFile(filesCol[i].FilePath, filesCol[i].FileName);
                    }
                }
                return File(memoryStream.ToArray(), "application/zip", "Attachments.zip");
            }
        }
    }
}