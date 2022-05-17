using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Web;
using BL.FaceRecognition;

namespace BL
{
    public class Trial
    {
        #region Variables
        //int testid = 0;


        private Image<Bgr, Byte> currentFrame = null;
        private bool facesDetectionEnabled = true;
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"C:\Users\User\Source\Repos\SERVER\BL\FaceRecognition\haarcascade_frontalface_alt.xml");
        Image<Bgr, byte> bgr;
        Mat grayImage = new Mat();
        public void Recognize(string v)
        {
            throw new NotImplementedException();
        }

        //Image<Bgr, Byte> faceResult = null;
        List<Mat> TrainedFaces = new List<Mat>();
        List<int> PersonsLabes = new List<int>();

        bool EnableSaveImage = true;
        private bool isTrained = false;
        EigenFaceRecognizer recognizer;
        List<string> PersonsNames = new List<string>();
        List<ReconizerResult> res = new List<ReconizerResult>();
        
        #endregion
        public List<ReconizerResult> ImageProccess(string filePath, string idChild ="")
        {

            var faces = DetectFaces(filePath);
           
             //If faces detected
            if (faces.Length > 0)
            {

                foreach (var face in faces)
                {
                    
                    ReconizerResult faceResult = new ReconizerResult();
                    Image<Bgr, Byte> resultImage;

                    resultImage = bgr.Convert<Bgr, Byte>();
                    resultImage.ROI = face;
                    ////picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                    ////picDetected.Image = resultImage.Bitmap;

                    if (idChild != string.Empty)
                        SaveImageToDir(resultImage, idChild);
                    else SaveImageToDir(resultImage, RecognizeFace(resultImage, face).ChildId.ToString());
                }
            }
            else res.Add(new ReconizerResult { ResultOption = ReconizerResultOption.NoFace });

            return res;

        } 
        //זיהוי פנים
        public Rectangle[] DetectFaces(string filePath)
        {
            //var i = System.Convert.FromBase64String(stringInBase64)
            bgr = new Image<Bgr, byte>(filePath).Resize(320, 240, Inter.Cubic);

            //Convert from Bgr to Gray Image

            CvInvoke.CvtColor(bgr, grayImage, ColorConversion.Bgr2Gray);
            //Enhance the image to get better result
            CvInvoke.EqualizeHist(grayImage, grayImage);

            return faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);

        }
        // פונקצייה השומרת תמונה 
        public bool SaveImageToDir(Image<Bgr, Byte> resultImage, string idChild)

        {
            //We will create a directory if does not exists!
            string path = HttpContext.Current.Server.MapPath("~") + @"\TrainedImages";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //we will save 10 images with delay a second for each image 
            //to avoid hang GUI we will create a new task
            Task.Factory.StartNew(() =>
            {
                //for (int i = 0; i < 10; i++)
                //{
                    //resize the image then saving it
                    resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + idChild + "_" +
                        DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                    Thread.Sleep(1000);
               // }
            });
            return true;
        }
        // פונקציית זיהוי פנים
        public ReconizerResult RecognizeFace(Image<Bgr, Byte> resultImage, Rectangle face)
        {
            //todo Read and write recognizer
                var resultOption = new ReconizerResult();
                Image <Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                var result = recognizer.Predict(grayFaceResult);
                //var a = grayFaceResult.Convert(;
                //var b = TrainedFaces[result.Label].Bitmap;
                Debug.WriteLine(result.Label + ". " + result.Distance);
                //Here results found known faces
                if (result.Label != -1 && result.Distance < 2000)
                {
                resultOption.ResultOption = ReconizerResultOption.RecognizedFace;
               //todo Add selection from db
               resultOption.ChildId = result.Label;//"Fro9m db";
                }
                //here results did not found any know faces
                else
                {
                resultOption.ResultOption = ReconizerResultOption.NotRecognizedFace;

            }
            return resultOption;
            
        }

        // פונקצייה לאימון תמונה
        public bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            double Threshold = 2000;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = HttpContext.Current.Server.MapPath("~") + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);


                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage.Mat);

                    PersonsLabes.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);
                }

                if (TrainedFaces.Count() > 0)
                {
                    // recognizer = new EigenFaceRecognizer(ImagesCount,Threshold);
                    recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                    //todo save labels
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());

                    isTrained = true;
                    //Debug.WriteLine(ImagesCount);
                    //Debug.WriteLine(isTrained);
                    return true;
                }
                else
                {
                    isTrained = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return false;
            }

        }

    }
}
