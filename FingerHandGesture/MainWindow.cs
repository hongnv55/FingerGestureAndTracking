using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FingerHandGesture
{
    public partial class MainWindow : Form
    {
        KinectTracker kinectController;
        bool initTime = true;
        float initDistance = 0.0f;
        Size initSize = new Size(435, 419);
        int checker = 0;
        //image
        Image image;
        Bitmap imageBitmap;
        int width, height;

        public MainWindow()
        {
            InitializeComponent();

        }

        // Show the color image in both image elements
        private void drawImageFrames()
        {
            colorImage.Image = kinectController.getColorImage();
            trackingImage.Image = kinectController.getDepthImage();
        }

        // Show the color and tracked images in the image elements
        private void drawDepthImage()
        {
            colorImage.Image = kinectController.getColorImage();
            trackingImage.Image = kinectController.getDepthImage();
        }

        private void drawDistanceRatio()
        {

            if (kinectController.hands.Count > 1)
            {
                int mNumberFinger1 = kinectController.hands[0].fingertips.Count;
                int mNumberFinger2 = kinectController.hands[1].fingertips.Count;
                if (mNumberFinger1 == 1 && mNumberFinger2 == 1)
                {
                    checker++;
                    if (checker >= 3)
                    {
                        checker = 0;

                        double curDistance = Math.Sqrt(Math.Pow(kinectController.hands[0].fingertips[0].X - kinectController.hands[1].fingertips[0].X, 2)
                                                   + Math.Pow(kinectController.hands[0].fingertips[0].Y - kinectController.hands[1].fingertips[0].Y, 2)
                                                    );
                        if (initTime)
                        {

                            initDistance = (float)(curDistance);
                            if (initDistance > 60 && initDistance < 70)
                            {
                                initTime = false;
                            }
                        }
                        else
                        {
                            float ratio = (float)(curDistance * 1.0f / initDistance);
                            int widthTemp = (int)(width * ratio);
                            int heightTemp = (int)(height * ratio);
                            if (widthTemp <= initSize.Width || heightTemp <= initSize.Height)
                            {
                                imageBitmap = new Bitmap(image, new Size(widthTemp, heightTemp));
                                mImage.Image = imageBitmap;
                            }
                            mRatioValue.Text = ratio.ToString();
                        }
                    }
                }
                else
                {
                    checker = 0;
                    mRatioValue.Text = "";
                }
                
            }
        }

        private void mChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            DialogResult result = file.ShowDialog();
            if (result == DialogResult.OK)
            {
                mChooseImage.Visible = false;

                image = Image.FromFile(file.FileName);
                width = (int)(initSize.Width / 2);
                height = (int)(image.Height * (initSize.Width * 1.0f / (2 * image.Width)));
                imageBitmap = new Bitmap(image, width, height);
                mImage.Image = imageBitmap;
                

                kinectController = new KinectTracker();
                if (kinectController.isConnected())
                {
                    kinectController.start();
                    KinectTracker.afterReady a = drawImageFrames;
                    a = a + drawDistanceRatio;
                    kinectController.setEventColorReady(a);
                }
                else
                {
                    // Show an error
                    Console.WriteLine("There is not any Kinect device connected.\nConnect it and restart the application.\n");
                }
            }
        }
    }
}
