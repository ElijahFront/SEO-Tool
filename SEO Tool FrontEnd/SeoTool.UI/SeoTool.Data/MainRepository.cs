using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SeoTool.Data
{
    public class MainRepository
    {
        public List<WordItem> Items { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }

        public MainRepository()
        {
            GenerateData();     
        }

        public void GenerateData()
        {
            var txt = File.ReadAllText("/.../");
            var dataItem = JsonConvert.DeserializeObject<DataItem>(txt);
            if(dataItem.Status == 1)
            {
                Items = (List<WordItem>)(dataItem.Data);
                Status = 1;
            }
            else
            {
                Status = 0;
                ErrorMessage = (string)(dataItem.Data);
            }

        }
 
    }
}
