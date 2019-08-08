﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using UnityEngine;
using System.IO;

namespace huqiang.Http
{
    public enum ResultCode
    {
        OK,
        WrongAddress,
        UploadFailed,
        FailedDownload
    }
    public enum MethodType
    {
        Get,Post,Put
    }
    public class HttpResult
    {
        public HttpResponseMessage responseMessage;
        public Stream responseStream;
        public ResultCode Code;
        public long Length ;
        public MethodType Type;
        public float Percentage { get {
               if(Type==MethodType.Get)
                {
                    if (Length == 0)
                        return 0;
                    if (responseStream!=null)
                    {
                        float p = responseStream.Length;
                        float l = Length;
                        return p / l ;
                    }
                }
                else if(Type==MethodType.Post)
                {
                    if(responseStream!=null)
                    {
                        float p = responseStream.Position;
                        float l = responseStream.Length;
                        return p / l;
                    }
                }
                return 0;
            } }
    }

    public class HttpControl
    {
        public static async void LoginAsync(string url, string user, string pass,Action<HttpResult> callback)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            using (var client = new HttpClient())
            {
                List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
                paramList.Add(new KeyValuePair<string, string>("username", user));
                paramList.Add(new KeyValuePair<string, string>("password", pass));
                try
                {
                    var result = await client.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList));
                    HttpResult hr = new HttpResult();
                    hr.responseMessage = result;
                    if (callback != null)
                        callback(hr);
                }
                catch (Exception ex)
                {
                   Debug.Log(ex.StackTrace);
                    if (callback != null)
                        callback(null);
                }
            }
        }
        public static async void DownloadAsync(string url, string filePath, Action<HttpResult> start,Action<HttpResult> done, HttpMessageHandler handler = null)
        {
            HttpClient client=null;
            FileStream fs = null;
            try
            {
                if (handler != null)
                    client = new HttpClient(handler);
                else client = new HttpClient();
                try
                {
                    var task = client.GetStreamAsync(url);
                    HttpResult hr = new HttpResult();
                    hr.Type = MethodType.Get;
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                    fs = File.Create(filePath);
                    hr.responseStream = fs;
                    try
                    {
                        if (start != null)
                            start(hr);
                    }catch(Exception ex)
                    {
                        Debug.Log(ex.StackTrace);
                    }
                    try
                    {
                        await task.Result.CopyToAsync(fs);
                    }catch(Exception ex)
                    {
                        hr.Code = ResultCode.FailedDownload;
                        Debug.Log(ex.StackTrace);
                    }
                    if (done != null)
                        done(hr);
                }
                catch(Exception ex)
                {
                    Debug.Log(ex.StackTrace);
                }
            }catch(Exception ex)
            {
                Debug.Log(ex.StackTrace);
            }
            if (client != null)
                client.Dispose();
            if (fs != null)
                fs.Dispose();
        }
        public static async void UploadAsync(string url, Stream stream, Action<HttpResult> start, Action<HttpResult> done, HttpMessageHandler handler = null)
        {
            HttpClient client = null;
            try
            {
                if (handler != null)
                    client = new HttpClient(handler);
                else client = new HttpClient();
                HttpResult hr = new HttpResult();
                hr.Type = MethodType.Post;
                hr.responseStream = stream;
                try
                {
                    if (start != null)
                        start(hr);
                }catch (Exception ex)
                {
                    Debug.Log(ex.StackTrace);
                }
                StreamContent content = new StreamContent(stream);
                try
                {
                    var result = await client.PostAsync(url, content);
                    hr.responseMessage = result;
                }catch(Exception ex)
                {
                    hr.Code = ResultCode.UploadFailed;
                    Debug.Log(ex.StackTrace);
                }
                if (done != null)
                    done(hr);
            }catch(Exception ex)
            {
                Debug.Log(ex.StackTrace);
            }
            if (client != null)
                client.Dispose();
        }
    }
}