using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ImgDto
    {
        public string FileName { get; set; }
        public Stream FileStream { get; set; }
    }
}
