using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// ASP.NET CORE MVC 
// M = MODEL => Veriler
// V = VIEW => Görüntü
// C = CONTROLLER => Sayfa Kontrols

namespace CalculateCapacity.Controllers
{
    public class CalculateController : Controller
    {
        public IActionResult GetCapacity()
        {
            // Text dosyasına ulaşma
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Capacity.txt");


            // Verileri tanımlama (Variable)
            double MediaTotalCapacity = 0;
            double MediaUsedCapacity = 0;
            double MediaAvailableCapacity = 0;
            double MasterTotalCapacity = 0;
            double MasterUsedCapacity = 0;
            double MasterAvailableCapacity = 0;

            // Text dosyasını okuma Read
            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.Contains("mediaselin"))
                {
                    string isGBOne = "";
                    string isGBTwo = "";
                    string isGBThree = "";
                    string valueOne = "";
                    string valueTwo = "";
                    string valueThree = "";
                    double temporaryOne = 0;
                    double temporaryTwo = 0;
                    double temporaryThree = 0;

                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    isGBOne = parts[6];
                    isGBTwo = parts[8];
                    isGBThree = parts[10];
                    valueOne = parts[5];
                    valueTwo = parts[7];
                    valueThree = parts[9];


                    if (isGBOne == "GB")
                    {
                        MediaUsedCapacity = double.Parse(valueOne.Replace("GB", "").Trim());
                    }
                    else if (isGBOne == "MB")
                    {
                        double change = double.Parse(valueOne.Replace("MB", "").Trim());
                        temporaryOne = change / 1024;
                        MediaUsedCapacity = Math.Round(temporaryOne, 2);
                    }

                    if (isGBTwo == "GB")
                    {
                        MediaAvailableCapacity = double.Parse(valueTwo.Replace("GB", "").Trim());
                    }
                    else if (isGBTwo == "MB")
                    {
                        double change = double.Parse(valueTwo.Replace("MB", "").Trim());
                        temporaryTwo = change / 1024;
                        MediaAvailableCapacity = Math.Round(temporaryTwo, 2);
                    }

                    if (isGBThree == "GB")
                    {
                        MediaTotalCapacity = double.Parse(valueThree.Replace("GB", "").Trim());
                    }
                    else if (isGBThree == "MB")
                    {
                        double change = double.Parse(valueThree.Replace("MB", "").Trim());
                        temporaryThree = change / 1024;
                        MediaTotalCapacity = Math.Round(temporaryThree, 2);
                    }
                }
                if (line.Contains("selindisk"))
                {
                    string isGBOne = "";
                    string isGBTwo = "";
                    string isGBThree = "";
                    string valueOne = "";
                    string valueTwo = "";
                    string valueThree = "";
                    double temporaryOne = 0;
                    double temporaryTwo = 0;
                    double temporaryThree = 0;

                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    isGBOne = parts[6];
                    isGBTwo = parts[8];
                    isGBThree = parts[10];
                    valueOne = parts[5];
                    valueTwo = parts[7];
                    valueThree = parts[9];


                    if (isGBOne == "GB")
                    {
                        MasterUsedCapacity = double.Parse(valueOne.Replace("GB", "").Trim());
                    }
                    else if (isGBOne == "MB")
                    {
                        double change = double.Parse(valueOne.Replace("MB", "").Trim());
                        temporaryOne = change / 1024;
                        MasterUsedCapacity = Math.Round(temporaryOne, 2);
                    }
                    
                    if (isGBTwo == "GB")
                    {
                        MasterAvailableCapacity = double.Parse(valueTwo.Replace("GB", "").Trim());
                    }
                    else if (isGBTwo == "MB")
                    {
                        double change = double.Parse(valueTwo.Replace("MB", "").Trim());
                        temporaryTwo = change / 1024;
                        MasterAvailableCapacity = Math.Round(temporaryTwo, 2);
                    }

                    if (isGBThree == "GB")
                    {
                        MasterTotalCapacity = double.Parse(valueThree.Replace("GB", "").Trim());
                    }
                    else if (isGBThree == "MB")
                    {
                        double change = double.Parse(valueThree.Replace("MB", "").Trim());
                        temporaryThree = change / 1024;
                        MasterTotalCapacity = Math.Round(temporaryThree, 2);
                    }

                }
            }
            ViewBag.MediaUsedCapacity = MediaUsedCapacity;
            ViewBag.MasterUsedCapacity = MasterUsedCapacity;
            ViewBag.MediaAvailableCapacity = MediaAvailableCapacity;
            ViewBag.MasterAvailableCapacity = MasterAvailableCapacity;
            ViewBag.MediaTotalCapacity = MediaTotalCapacity;
            ViewBag.MasterTotalCapacity = MasterTotalCapacity;
            return View();
        }
    }
}