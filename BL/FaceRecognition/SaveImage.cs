//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Emgu.CV;
//using Emgu.CV.Structure;
//using Emgu.CV.Face;
//using Emgu.CV.CvEnum;
//using System.IO;
//using System.Threading;
//using System.Diagnostics;

//namespace BL.Face
//{
//    public class SaveImage
//    {
//        private void Train(string idChild, string filePath)
//        {
//            try
//            {
//                //Trained face counter
//                //ContTrain = ContTrain + 1;
//                //Get a gray frame from capture device
//                Image<Gray, Byte> gray = new Image<Gray, byte>(filePath).Resize(320, 240, Inter.Cubic);


//                //Face Detector
//                List<Rectangle> facesDetected = new List<Rectangle>();
//                using (CascadeClassifier face = new CascadeClassifier(filePath))
//                {
//                    using (UMat ugray = new UMat())
//                    {
//                        // CvInvoke.CvtColor(gray, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

//                        //normalizes brightness and increases contrast of the image
//                        CvInvoke.EqualizeHist(ugray, ugray);

//                        //Detect the faces  from the gray scale image and store the locations as rectangle                   
//                        facesDetected.AddRange(face.DetectMultiScale(
//                          ugray, 1.1, 10, new Size(20, 20));

//                    }
//                }
//                Action for each element detected


//                resize face detected image for force to compare the same size with the
//                test image with cubic interpolation type method


//                        TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
//                trainingImages.Add(TrainedFace);
//                labels.Add(textBox1.Text);

//                //Show face added in gray scale
//                imageBox1.Image = TrainedFace;

//                //Write the number of triained faces in a file text for further load
//                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

//                //Write the labels of triained faces in a file text for further load
//                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
//                {
//                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
//                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
//                }

//                MessageBox.Show(textBox1.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            catch
//            {
//                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//            }
//        }


//    }
//    }

