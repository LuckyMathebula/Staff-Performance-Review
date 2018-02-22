using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace DynamicDNAPerformanceReview.Models
{
    public class FileDownloads
    {

       
            public List<FetchFiles> GetFile()
            {
                List<FetchFiles> listFiles = new List<FetchFiles>();
                string fileSavePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Downloadss");
                DirectoryInfo dirInfo = new DirectoryInfo(fileSavePath);
                int i = 0;
                foreach (var item in dirInfo.GetFiles())
                {
                    listFiles.Add(new FetchFiles()
                    {
                        FileId = i + 1,
                        FileName = item.Name,
                        FilePath = dirInfo.FullName + @"\" + item.Name  
                    });
                    i = i + 1;
                }
                return listFiles;
            }



        }
}