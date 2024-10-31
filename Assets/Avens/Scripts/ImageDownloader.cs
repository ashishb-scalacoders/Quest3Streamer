using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
/* using SocketIOClient;
using SocketIOClient.Newtonsoft.Json; */
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using System.ComponentModel.Design;

public class ImageDownloader : MonoBehaviour
{
    // public Image image;
    public RawImage rawImage;
    public Image pointerImg;


    // public Camera centerCamera;
    // public GameObject pointer;
    // public Vector2 pointerPos;
    // public float scale;

    // /// <summary>
    // /// Start is called on the frame when a script is enabled just before
    // /// any of the Update methods is called the first time.
    // /// </summary>
    // void Start() { Application.targetFrameRate = 60; InitSocket(); }
    public static ImageDownloader Instance;
    public Text fpsTxt;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Instance = this;
        Application.targetFrameRate = 60;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    float count = 0;
    void Update()
    {

        if (Time.frameCount % 30 != 0) return;
        count = 1f / Time.unscaledDeltaTime;
        int avgFrameRate = (int)count;
        fpsTxt.text = avgFrameRate.ToString() + " FPS";

    }
    // public string str, strtx;
    [System.Serializable]
    public class ImageData
    {
        public string imageUrl;// { get; set; }
        public int height;// { get; set; }
        public int width;// { get; set; }
    }


    public ImageData imageData;
    [ContextMenu("Checlk")]
    public async void SetupImage(string str)
    {
        // string strX = str;
        // Debug.Log("> str > " + str);
        string jsonData = str.Remove(0, 26);
        // Debug.Log(jsonData);
        // strX = "{" + strX.Remove(0, 8) + "}";
        // strX = strX.Remove(0, 18);

        imageData = JsonUtility.FromJson<ImageData>(jsonData);

        rawImage.texture = await DownloadImage(imageData.imageUrl); // Download the image from URL
        rawImage.rectTransform.sizeDelta = new Vector2(imageData.width, imageData.height);

        // async void DownloadImageX()
        // {
        //     // Set up the image size according to uploaded image dimentions
        //     rawImage.rectTransform.sizeDelta = new Vector2(latestUploadedIMGData.image_dimensions[0], latestUploadedIMGData.image_dimensions[1]);
        //     rawImage.texture = await DownloadImage(latestUploadedIMGData.url); // Download the image from URL
        // }

    }
    [System.Serializable]
    public class PointerData
    {
        public float x;// { get; set; }
        public float y;// { get; set; }
    }
    public PointerData pointerCoordinate;
    void HidePointer()
    {
        pointerImg.enabled = false;
    }
    public void MovePointer(string str)
    {
        CancelInvoke("HidePointer");
        // string strX = str;
        Debug.Log("> str > " + str);
        string jsonData = str.Remove(0, 18);
        // Debug.Log(jsonData);
        // strX = "{" + strX.Remove(0, 8) + "}";
        // strX = strX.Remove(0, 18);

        pointerCoordinate = JsonUtility.FromJson<PointerData>(jsonData);

        // rawImage.texture = await DownloadImage(imageData.imageUrl); // Download the image from URL
        // 2064x2208
        pointerImg.rectTransform.localPosition = new Vector3(map(pointerCoordinate.x, 0, 640, -1032, 1032), -map(pointerCoordinate.y - 480, -480, 00, -1104, 1104), 50);
        pointerImg.enabled = true;
        Invoke("HidePointer", 10);
        // async void DownloadImageX()
        // {
        //     // Set up the image size according to uploaded image dimentions
        //     rawImage.rectTransform.sizeDelta = new Vector2(latestUploadedIMGData.image_dimensions[0], latestUploadedIMGData.image_dimensions[1]);
        //     rawImage.texture = await DownloadImage(latestUploadedIMGData.url); // Download the image from URL
        // }

    }


    // [ContextMenu("Socket Init")]
    // public async void InitSocket()
    // {
    //     socket = new SocketIOUnity($"http://{socketIP}:{port}");

    //     ///// reserved socketio events
    //     socket.OnConnected += (sender, e) => { print("socket.OnConnected"); };
    //     socket.OnDisconnected += (sender, e) => { print("disconnect: " + e); };
    //     socket.OnReconnectAttempt += (sender, e) => { print($"{DateTime.Now} Reconnecting: attempt = {e}"); };
    //     /* socket.OnAnyInUnityThread((name, response) =>
    //  {
    //      print("received in thread");
    //      print("Received On " + name + " : " + response.ToString() + "\n");
    //  }); */


    //     #region ON_IMAGE_UPLOAD_RECEIVED
    //     // Receive the image Upload Event Response
    //     socket.OnUnityThread("image_uploaded", (response) =>
    //     {
    //         // Received Data
    //         print($"{response.ToString()}");
    //         latestUploadedIMGData = JsonUtility.FromJson<LiveImageData>(responseFormating(response.ToString()));
    //         //print($"{response.ToString()}");
    //         DownloadImage();
    //     });
    //     #endregion


    //     #region ON_WEB_POINTER_POINT_RECEIVED
    //     // Receive the image Upload Event Response
    //     socket.OnUnityThread("web_pointer", (response) =>
    //     {

    //         Coordinate coordinate = JsonUtility.FromJson<Coordinate>(responseFormating(response.ToString()));
    //         Vector2 pointerScreenPos = coordinate.pos;
    //         pointerPos = centerCamera.ScreenToViewportPoint(pointerScreenPos);
    //         PlotPointerAt(pointerPos);
    //         print($"{response.ToString()}");
    //         // Received Data
    //         // latestUploadedIMGData = JsonUtility.FromJson<LiveImageData>(responseFormating(response.ToString()));
    //         //print($"{response.ToString()}");
    //         // DownloadImage();
    //     });
    //     #endregion


    //     #region ON_WEB_AUDIO_RECEIVED
    //     // Receive the image Upload Event Response
    //     socket.OnUnityThread("web_audio", (response) =>
    //     {

    //         Coordinate coordinate = JsonUtility.FromJson<Coordinate>(responseFormating(response.ToString()));
    //         Vector2 pointerScreenPos = coordinate.pos;
    //         pointerPos = centerCamera.ScreenToViewportPoint(pointerScreenPos);
    //         PlotPointerAt(pointerPos);
    //         print($"{response.ToString()}");
    //         // Received Data
    //         // latestUploadedIMGData = JsonUtility.FromJson<LiveImageData>(responseFormating(response.ToString()));
    //         //print($"{response.ToString()}");
    //         // DownloadImage();
    //     });
    //     #endregion

    //     print("Connecting...");
    //     socket.Connect(); // establish the socket connection   
    // }

    // void PlotPointerAt(Vector3 pos)
    // {
    //     // pos.z = 1;
    //     pos *= scale;
    //     pos.z = 3;
    //     pointer.transform.position = pos;

    //     pointer.gameObject.SetActive(true);
    //     CancelInvoke("HidePointer");
    //     Invoke("HidePointer", 10);
    // }

    // void HidePointer() { pointer.gameObject.SetActive(false); }

    // async void DownloadImage()
    // {
    //     // Set up the image size according to uploaded image dimentions
    //     rawImage.rectTransform.sizeDelta = new Vector2(latestUploadedIMGData.image_dimensions[0], latestUploadedIMGData.image_dimensions[1]);
    //     rawImage.texture = await DownloadImage(latestUploadedIMGData.url); // Download the image from URL
    // }

    async Task<Texture2D> DownloadImage(string MediaUrl)
    {

        var request = UnityWebRequestTexture.GetTexture(MediaUrl);
        request.SendWebRequest();
        while (!request.isDone) await Task.Yield(); // wait 1 frame until request done
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log("Error: " + request.error); // Optinal: Call Errors
            return null;
        }
        return DownloadHandlerTexture.GetContent(request);
    }

    string responseFormating(string uri)
    {
        uri = uri.Remove(0, 1); // print(uri);
        uri = uri.Remove(uri.Length - 1, 1);
        return uri;
    }
    float map(float currentValue, float inMin, float inMax, float outMin, float outMax) { return outMin + (currentValue - inMin) * (outMax - outMin) / (inMax - inMin); }
}


[System.Serializable]
public class LiveImageData
{
    public string url;
    public List<float> image_dimensions;
}

public class Coordinate
{
    public float x;
    public float y;
    public Vector2 pos { get { return new Vector2(x, y); } }
}