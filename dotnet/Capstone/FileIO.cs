using Capstone.DAO;
using Capstone.Models;
using Microsoft.OpenApi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Capstone
{
    public class FileIO
    {
        string directoryPath = ".\\dotnet\\Pet_Photos\\";

        public string[] GeneratePhotoPathArray()
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException("ERROR: The directory where photos are stored can't be found");
            }
            else
            {
                string[] pathArray = Directory.GetFiles(directoryPath);

                if (pathArray.Length == 0)
                {
                    throw new Exception("No photos");
                }
                else
                {
                    return pathArray;
                }
            }
        }

        public string GetPhotoByPath(Photo dbPhoto)
        {
            string[] pathArray = GeneratePhotoPathArray();

            string photoPath = "";

            foreach (string item in pathArray)
            {
                if (item == dbPhoto.PhotoUrl)
                {
                    photoPath = item;
                    break;
                }
            }

            return photoPath;
        }

        public 
    }
}
