using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.GPU;

namespace WindowsFormsApplication1
{
   public static class DetectFace
   {
      public static void Detect(Image<Bgr, Byte> image, String faceFileName, String eyeFileName, List<Rectangle> faces, List<Rectangle> eyes, out long detectionTime)
      {
         Stopwatch watch;

         if (GpuInvoke.HasCuda)
         {
            using (GpuCascadeClassifier face = new GpuCascadeClassifier(faceFileName))
            using (GpuCascadeClassifier eye = new GpuCascadeClassifier(eyeFileName))
            {
               watch = Stopwatch.StartNew();
               using (GpuImage<Bgr, Byte> gpuImage = new GpuImage<Bgr, byte>(image))
               using (GpuImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
               {
                  Rectangle[] faceRegion = face.DetectMultiScale(gpuGray, 1.1, 10, Size.Empty);
                  faces.AddRange(faceRegion);
                  foreach (Rectangle f in faceRegion)
                  {
                     using (GpuImage<Gray, Byte> faceImg = gpuGray.GetSubRect(f))
                     {
                        using (GpuImage<Gray, Byte> clone = faceImg.Clone())
                        {
                           Rectangle[] eyeRegion = eye.DetectMultiScale(clone, 1.1, 10, Size.Empty);

                           foreach (Rectangle e in eyeRegion)
                           {
                              Rectangle eyeRect = e;
                              eyeRect.Offset(f.X, f.Y);
                              eyes.Add(eyeRect);
                           }
                        }
                     }
                  }
               }
               watch.Stop();
            }
         }
         else
         {
            using (CascadeClassifier face = new CascadeClassifier(faceFileName))
            using (CascadeClassifier eye = new CascadeClassifier(eyeFileName))
            {
               watch = Stopwatch.StartNew();
               using (Image<Gray, Byte> gray = image.Convert<Gray, Byte>())
               {
                  gray._EqualizeHist();

                  Rectangle[] facesDetected = face.DetectMultiScale(
                     gray,
                     1.1,
                     10,
                     new Size(20, 20),
                     Size.Empty);
                  faces.AddRange(facesDetected);

                  foreach (Rectangle f in facesDetected)
                  {
                     gray.ROI = f;
                     Rectangle[] eyesDetected = eye.DetectMultiScale(
                        gray,
                        1.1,
                        10,
                        new Size(20, 20),
                        Size.Empty);
                     gray.ROI = Rectangle.Empty;

                     foreach (Rectangle e in eyesDetected)
                     {
                        Rectangle eyeRect = e;
                        eyeRect.Offset(f.X, f.Y);
                        eyes.Add(eyeRect);
                     }
                  }
               }
               watch.Stop();
            }
         }
         detectionTime = watch.ElapsedMilliseconds;
      }
   }
}
