using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FingerHandGesture
{
    public partial class MainWindow : Form
    {
        KinectTracker kinectController;
        Size initSize = new Size(435, 419);
        

        ////////// variables to customize picturebox/////////
        //zoom
        bool initTimeToZoom = true;
        int checkerZoom = 0;
        float initDistance = 0.0f;
        //slide
        bool initTimeToSlide = true;
        int checkerSlide = 0;
        PointFT initPointSlide1;
        PointFT initPointSlide2;
        float distanceBetweenFingers;
        int index = 0;

        //image
        Image image;
        Bitmap imageBitmap;
        int width, height;

        public MainWindow()
        {
            InitializeComponent();
            mTip1.Text = "Choose the image you want before";
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

        private void updatePictureBox()
        {
            //slide
            if (kinectController.hands.Count > 0)
            {
                int numberFinger1 = kinectController.hands[0].fingertips.Count;
                if (numberFinger1 == 2)
                {
                    if (initTimeToSlide)
                    {
                        initPointSlide1 = new PointFT(kinectController.hands[0].fingertips[0].X,
                                                    kinectController.hands[0].fingertips[0].Y);
                        initPointSlide2 = new PointFT(kinectController.hands[0].fingertips[1].X,
                                                    kinectController.hands[0].fingertips[1].Y);
                        distanceBetweenFingers = PointFT.distanceEuclidean(initPointSlide1, initPointSlide2);
                        initTimeToSlide = false;
                    }
                    else
                    {
                        checkerSlide++;
                        if (checkerSlide >= 3)
                        {
                            PointFT curPoint = new PointFT(kinectController.hands[0].fingertips[0].X,
                                    kinectController.hands[0].fingertips[0].Y);
                            PointFT curPoint2 = new PointFT(kinectController.hands[0].fingertips[1].X,
                                    kinectController.hands[0].fingertips[1].Y);

                            float distanceBetweenStates = PointFT.distanceEuclidean(curPoint, initPointSlide1);
                            float disBwFingers = PointFT.distanceEuclidean(curPoint, curPoint2);

                            if (distanceBetweenStates >= 40 && disBwFingers >= distanceBetweenFingers - 10 && disBwFingers <= distanceBetweenFingers + 10 &&
                                curPoint.X < initPointSlide1.X)
                            {
                                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.jpg", SearchOption.AllDirectories);
                                image = Image.FromFile(files[index]);
                                imageBitmap = new Bitmap(image, returnWidth(image), returnHeight(image));
                                mImage.Image = imageBitmap;
                                index++;
                                if (index==files.Length)
                                {
                                    index = 0;
                                }
                            }
                            initTimeToSlide = true;
                            checkerSlide = 0;
                        }
                    }

                }
                else
                {
                    checkerSlide = 0;
                }
            }
            //zoom
            if (kinectController.hands.Count > 1)
            {
                int mNumberFinger1 = kinectController.hands[0].fingertips.Count;
                int mNumberFinger2 = kinectController.hands[1].fingertips.Count;
                if (mNumberFinger1 == 1 && mNumberFinger2 == 1)
                {
                    checkerZoom++;
                    if (checkerZoom >= 3)
                    {
                        checkerZoom = 0;

                        double curDistance = Math.Sqrt(Math.Pow(kinectController.hands[0].fingertips[0].X - kinectController.hands[1].fingertips[0].X, 2)
                                                   + Math.Pow(kinectController.hands[0].fingertips[0].Y - kinectController.hands[1].fingertips[0].Y, 2)
                                                    );
                        if (initTimeToZoom)
                        {

                            initDistance = (float)(curDistance);
                            if (initDistance > 60 && initDistance < 70)
                            {
                                initTimeToZoom = false;
                            }
                        }
                        else
                        {
                            float ratio = (float)(curDistance * 1.0f / initDistance);
                            int widthTemp = (int)(returnWidth(image) * ratio);
                            int heightTemp = (int)(returnHeight(image) * ratio);
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
                    checkerSlide = 0;
                    checkerZoom = 0;
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
                width = returnWidth(image);
                height = returnHeight(image);
                imageBitmap = new Bitmap(image, width, height);
                mImage.Image = imageBitmap;

                mTip1.Text = "1. Using two hand with one finger to zoom in/out image\n2. Using one hand with 2 fingers then quickly swipe\n to change image";
                mTip1.Location = new Point(mTip1.Location.X - 90, 460);

                kinectController = new KinectTracker();
                if (kinectController.isConnected())
                {
                    kinectController.start();
                    KinectTracker.afterReady a = drawImageFrames;
                    a = a + updatePictureBox;
                    kinectController.setEventColorReady(a);
                }
                else
                {
                    // Show an error
                    Console.WriteLine("There is not any Kinect device connected.\nConnect it and restart the application.\n");
                }
            }
        }

        private int returnWidth(Image i)
        {
            return (int)(initSize.Width / 2);
        }

        private int returnHeight(Image i)
        {
            return (int)(i.Height * (initSize.Width * 1.0f / (2 * i.Width)));
        }
    }
}
