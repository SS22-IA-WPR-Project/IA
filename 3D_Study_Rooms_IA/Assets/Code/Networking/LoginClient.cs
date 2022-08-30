using Firesplash.UnityAssets.SocketIO;
using System.Collections;
using System.Collections.Generic;

using System.IO;
using UnityEngine;
using UnityEngine.Networking;


namespace Studyrooms
{
    public class LoginClient 
    {

        //static string baseURL = "http://localhost:3000/api/v1";
        //static string baseURL = "http://35.228.121.222/api/v1";
        static string baseURL = "https://3dstudyrooms.social/api/v1";



        public static string BuildUrl(string path)
        {

            return Path.Combine(baseURL, path).Replace(Path.DirectorySeparatorChar, '/');
        }

        public static UnityWebRequest Get(string path)
        {
            var request = new UnityWebRequest(BuildUrl(path), "GET");
            
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            return request;
        }


        public static UnityWebRequest Post(string path, string jsonString)
        {
            
            var request = new UnityWebRequest(BuildUrl(path), "POST");
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonString);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.certificateHandler = new BypassCertificate();
            
            request.SetRequestHeader("Content-Type", "application/json");
        
            return request;
   
        }

    }

    public class BypassCertificate : CertificateHandler
    {
        protected override bool ValidateCertificate(byte[] certificateData)
        {
            //allways just returns true 
            return true;
        }

    }

}
