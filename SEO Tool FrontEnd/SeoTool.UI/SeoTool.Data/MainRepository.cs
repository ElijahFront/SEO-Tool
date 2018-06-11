﻿using System;
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
        public List<WordItem> Items { get; set; }
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
            OnDataLoaded?.Invoke();
        }
        public event Action OnDataLoaded;
        public event Action<string> OnBackEndError;

        public void RunCmdCommand(string address)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "node ../../../../../SEO_Tool_BackEnd/index.js "+address;
            process.StartInfo = startInfo;
            process.Start();
            if (process.HasExited)
            {
                GenerateData();
            }
        }
    }
}
