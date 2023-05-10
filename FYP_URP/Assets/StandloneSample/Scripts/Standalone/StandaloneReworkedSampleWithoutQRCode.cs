using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;


public class StandaloneReworkedSampleWithoutQRCode : MonoBehaviour
{
    private const int encodingWidth = 256;

    [SerializeField]
    private string lastResult;
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private RawImage rawImage;
    [SerializeField]
    private string previewInput;

    private WebCamTexture camTexture;
    private Color32[] cameraColorData;
    private int width, height;
    private Rect screenRect;

    // Create the token source.
    private CancellationTokenSource cts = new CancellationTokenSource();

    // create a reader with a custom luminance source
    private BarcodeReader barcodeReader = new BarcodeReader
    {
        AutoRotate = false,
        Options = new ZXing.Common.DecodingOptions
        {
            TryHarder = false
        }
    };

    private BarcodeWriter writer;
    private Result result;

    private BarcodeChecker m_barcodeChecker;

    private bool startEncoding;
    private bool startDecoding;

    private void Start()
    {
        SetupWebcamTexture();
        PlayWebcamTexture();

        m_barcodeChecker = FindObjectOfType<BarcodeChecker>();

        lastResult = "http://www.google.com";
        previewInput = "";

        //rawImage.texture = camTexture;
        //rawImage.material.mainTexture = camTexture;

        cameraColorData = new Color32[width * height];
        screenRect = new Rect(0, 0, Screen.width, Screen.height);

        // Pass the token to the cancelable operation - decoding and encoding.
        ThreadPool.QueueUserWorkItem(new WaitCallback(GetCodeFromImageData), cts.Token);
    }

    private void OnEnable()
    {
        PlayWebcamTexture();
    }

    private void OnDisable()
    {
        if (camTexture != null)
        {
            camTexture.Pause();
        }
    }

    private void Update()
    {
        if (!startDecoding)
        {
            camTexture.GetPixels32(cameraColorData);

            startDecoding = !startDecoding;
        }
    }

    private void OnGUI()
    {
        /*
            // show camera image on screen
            GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleToFit);
            // show decoded text on screen
            GUI.TextField(new Rect(600, 920, 700, 80), lastResult, GUI.skin.textField.fontSize = 50);
        */
    }

    private void OnDestroy()
    {
        camTexture.Stop();

        cts.Cancel();
        // Cancellation should have happened, so call Dispose.
        cts.Dispose();
    }

    private void SetupWebcamTexture()
    {
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width; 
        rawImage.texture = camTexture;
        rawImage.material.mainTexture = camTexture;
    }

    private void PlayWebcamTexture()
    {
        if (camTexture != null)
        {
            camTexture.Play();
            width = camTexture.width;
            height = camTexture.height;
        }
    }

    private void GetCodeFromImageData(object obj)
    {
        CancellationToken token = (CancellationToken)obj;

        while (!token.IsCancellationRequested)
        {
            // decode the current frame
            if (startDecoding && cameraColorData != null)
            {
                result = barcodeReader.Decode(cameraColorData, width, height);
                if (result != null)
                {
                    lastResult = result.Text + " " + result.BarcodeFormat;
                    print(lastResult);
                    startEncoding = true;

                    //Send result.Text to BarcodeCheck
                    m_barcodeChecker.CheckCode(result.Text);
                }
                startDecoding = !startDecoding;
            }
        }
    }

    public void OnValueChange()
    {
        previewInput = inputField.text;
    }
    public void OnEndInput()
    {
        lastResult = inputField.text;
    }
}
