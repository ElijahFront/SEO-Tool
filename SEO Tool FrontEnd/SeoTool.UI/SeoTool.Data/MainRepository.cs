using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace SeoTool.Data
{
    public class MainRepository
    {
        List<WordItem> Items { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }

        static MainRepository()
        {

        }
        private static MainRepository instance;
        public static MainRepository GetInstance()
        {
            if (instance == null)
                instance = new MainRepository();
            return instance;
        }
        private MainRepository()
        {
            
        }

        public List<WordItem> GetItems()
        {
            return Items;
        }

        public void GenerateData()
        {
            try
            {
                var path = @"../../../../../data.json";
                var txt = File.ReadAllText(path);
                var dataItem = JsonConvert.DeserializeObject<DataItem>(txt);
                if (dataItem.Status == 1)
                {
                    Items = ((Newtonsoft.Json.Linq.JArray)(dataItem.Data)).ToObject<List<WordItem>>();
                    Status = 1;
                }
                else
                {
                    Status = 0;
                    ErrorMessage = (string)(dataItem.Data);
                    OnBackEndError?.Invoke(ErrorMessage);
                }
                OnDataLoaded?.Invoke();
            }
            catch (Exception e)
            {

            }
            
        }
        public event Action OnDataLoaded;
        public event Action<string> OnBackEndError;


        public void RunCmdCommand(string address)
        {

            string strCmdText;
            strCmdText = "/c npm --prefix ../../../../../SEO_Tool_BackEnd/ install ../../../../../SEO_Tool_BackEnd/ && node ../../../../../SEO_Tool_BackEnd/index.js " + address;
            
            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe", strCmdText);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = System.Diagnostics.Process.Start(startInfo);
            process.WaitForExit(5000);
            while (!process.HasExited)
            {

            }
            GenerateData();
        }
    }
}
