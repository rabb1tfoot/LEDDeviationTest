using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing.Imaging;
using System.Windows.Forms;

using OpenCvSharp;
using System.IO;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace LEDDeviation
{
    public partial class Form1 : Form
    {

        const int FOLDER_NUM = 4;
        const int PIXEL_NUM = 2048;
        int g_imgNum = 0;
        string[] strfolderNum = { "#1", "#2", "#3", "#4" };
        string[] strplotDataname = { "HTop", "HCenter", "HBot", "VLeft", "VCenter", "VRight", "Horizontal", "Vertical" };
        string[] strplotImagename = { "ALL", "X.bmp", "Y.bmp", "ADD_XY", "ADD_LR", "ADD_UD", "ADD_LRUD" };
        string[] strchartImagenameUni = { "_ALL_", "_X_", "_Y_",};
        string[] strchartImagenameRep = { "_ALL_", "_ADDXY_", "_ADDLRUD_", "_X_", "_ADDLR_", "_Y_", "_ADDUD_"};
        int[] plotDataValue = {PIXEL_NUM / 4, (PIXEL_NUM /2) -14, (PIXEL_NUM /4 * 3) + 48};
        PlotModel pm = new PlotModel();

        //데이터 순회하면서 CSV에 기록
        public void WriteCSV(StreamWriter wr, int patternIdx, int imgIdx, ref List<Mat>[] listImgArr, ref List<string>[] listImgNameArr, int folderNum)
        {
            
            for (int k = 0; k < strplotDataname.Length - 2; ++k)
            {
                string tempname = "-1";
                //.bmp 이름에서 빼기
                if (listImgNameArr[folderNum][imgIdx].Contains('X') || listImgNameArr[folderNum][imgIdx].Contains('Y'))
                {
                     string[] partname = strplotImagename[patternIdx].Split('.');
                     tempname = partname[0];
                }
                if(tempname == "-1")
                {
                    wr.Write("{0}_{1}_{2}, ", strfolderNum[folderNum], strplotImagename[patternIdx], strplotDataname[k]);
                }
                else
                {
                    wr.Write("{0}_{1}_{2}, ", strfolderNum[folderNum], tempname, strplotDataname[k]);
                }
                for (int n = 0; n < PIXEL_NUM; ++n)
                {
                    if (k < 3)
                    {
                        if (n == PIXEL_NUM - 1)
                        {
                            wr.Write("{0}\n", listImgArr[folderNum][imgIdx].At<byte>(plotDataValue[k], n));
                            break;
                        }

                        wr.Write("{0}, ", listImgArr[folderNum][imgIdx].At<byte>(plotDataValue[k], n));
                    }
                    else if(k >= 3)
                    {
                        if (n == PIXEL_NUM - 1)
                        {
                            wr.Write("{0}\n", listImgArr[folderNum][imgIdx].At<byte>(n, plotDataValue[k - 3]));
                            break;
                        }

                        wr.Write("{0}, ", listImgArr[folderNum][imgIdx].At<byte>(n, plotDataValue[k - 3]));
                    }

                }
            }
            g_imgNum = listImgArr[0].Count();
        }

        public void SaveChart(string filename, bool user = false)
        {
            //차트 이미지 저장
            // 주화면의 크기 정보 읽기
            if(user)
                Thread.Sleep(200);

            System.Drawing.Size ClSize = ClientSize;
            System.Drawing.Point loc = Location;
            Rectangle rect = new Rectangle();
            rect.Size = new System.Drawing.Size(758, 450);
            rect.Location = new System.Drawing.Point(loc.X + 7, loc.Y + 30);

            int bitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
            if (bitsPerPixel <= 16)
            {
                pixelFormat = PixelFormat.Format16bppRgb565;
            }
            if (bitsPerPixel == 24)
            {
                pixelFormat = PixelFormat.Format24bppRgb;
            }

            // 화면 크기만큼의 Bitmap 생성
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, pixelFormat);

            // Bitmap 이미지 변경을 위해 Graphics 객체 생성
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                // 화면을 그대로 카피해서 Bitmap 메모리에 저장
                gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
            }            
            bmp.Save(filename);
            bmp.Dispose();
        }

        public void WorksUniButton()
        {
            // 선택된 값 가져오기
            string strFolder = cbfolder.SelectedItem.ToString();
            string strPattern = cbUniPattern.SelectedItem.ToString();
            string strData = cbUniData.SelectedItem.ToString();

            int drawStack = 0;
            List<string[]> listCSV = new List<string[]>();
            //csv 로딩
            using (StreamReader rd = new StreamReader(@"WVLightingCompare.csv"))
            {
                while (!rd.EndOfStream)
                {
                    string s = rd.ReadLine();
                    string[] temp = s.Split(',');
                    listCSV.Add(temp);
                }
            }

            for (int i = 0; i < listCSV.Count(); ++i)
            {
                //H_top, centor, bot V_left, centor, right를 합친 차트
                if (strData == "Horizontal" || strData == "Vertical")
                {
                    if (listCSV[i][0].Contains(strFolder)
                         && strData == "Horizontal"
                         && listCSV[i][0].Contains("ALL_H")
                         && listCSV[i][0].Contains(strPattern))
                    {
                        plotView1.Model = new PlotModel { Title = "ALL" + "_" + strData };
                        LineSeries fs = new LineSeries();
                        DrawChart(listCSV[i], 0, ref fs);
                        LineSeries fs2 = new LineSeries();
                        DrawChart(listCSV[i + 1], 1, ref fs2);
                        LineSeries fs3 = new LineSeries();
                        DrawChart(listCSV[i + 2], 2, ref fs3);
                        lbfirst.Text = "ALL_H_Top";
                        lbfirst.Visible = true;
                        pbRed.Visible = true;
                        lbSecond.Text = "ALL_H_Center";
                        lbSecond.Visible = true;
                        pbGreen.Visible = true;
                        lbthird.Text = "ALL_H_Bot";
                        lbthird.Visible = true;
                        pbBlue.Visible = true;
                        lbfirst.Update();
                        lbSecond.Update();
                        lbthird.Update();
                        pbRed.Update();
                        pbGreen.Update();
                        pbBlue.Update();
                        break;
                    }
                    if (listCSV[i][0].Contains(strFolder)
                         && strData == "Vertical"
                         && listCSV[i][0].Contains("ALL_V") 
                         && listCSV[i][0].Contains(strPattern))
                    {
                        plotView1.Model = new PlotModel { Title = "ALL" + "_" + strData };
                        LineSeries fs = new LineSeries();
                        DrawChart(listCSV[i], 0, ref fs);
                        LineSeries fs2 = new LineSeries();
                        DrawChart(listCSV[i + 1], 1, ref fs2);
                        LineSeries fs3 = new LineSeries();
                        DrawChart(listCSV[i + 2], 2, ref fs3);
                        lbfirst.Text = "ALL_V_Left";
                        lbfirst.Visible = true;
                        pbRed.Visible = true;
                        lbSecond.Text = "ALL_V_Center";
                        lbSecond.Visible = true;
                        pbGreen.Visible = true;
                        lbthird.Text = "ALL_V_Right";
                        lbthird.Visible = true;
                        pbBlue.Visible = true;
                        lbfirst.Update();
                        lbSecond.Update();
                        lbthird.Update();
                        pbRed.Update();
                        pbGreen.Update();
                        pbBlue.Update();
                        break;
                    }
                }

                    if (listCSV[i][0].Contains(strFolder)
                    && listCSV[i][0].Contains(strData)
                    && listCSV[i][0].Contains(strPattern))
                {

                    if (listCSV[i][0].Contains("ALL"))
                    {
                        string Dataname = strData[0].ToString();
                        string strtemp = strData.Substring(1);
                        Dataname += " _" + strtemp;


                        plotView1.Model = new PlotModel { Title = "ALL" + "_" + Dataname };
                        LineSeries fs = new LineSeries();
                        lbfirst.Text = "ALL";
                        lbfirst.Visible = true;
                        pbRed.Visible = true;
                        lbfirst.Update();
                        pbRed.Update();
                        DrawChart(listCSV[i], drawStack, ref fs);
                        drawStack++;

                        for (int j = 0; j < listCSV.Count(); ++j)
                        {
                            if (listCSV[j][0].Contains(strFolder)
                                && listCSV[j][0].Contains(strData)
                                && (listCSV[j][0].Contains("ADD_XY") || listCSV[j][0].Contains("ADD_LRUD")))
                            {
                                if (listCSV[j][0].Contains("ADD_LRUD"))
                                {
                                    LineSeries fs2 = new LineSeries();
                                    lbSecond.Text = "ADD_LRUD";
                                    lbSecond.Visible = true;
                                    pbGreen.Visible = true;
                                    lbSecond.Update();
                                    pbGreen.Update();
                                    DrawChart(listCSV[j], drawStack, ref fs2);
                                }
                                else
                                {
                                    LineSeries fs2 = new LineSeries();
                                    lbthird.Text = "ADD_XY";
                                    lbthird.Visible = true;
                                    pbBlue.Visible = true;
                                    lbthird.Update();
                                    pbBlue.Update();
                                    DrawChart(listCSV[j], drawStack, ref fs2);
                                }
                                drawStack++;
                                if (drawStack == 3)
                                    break;
                            }
                        }

                        if (drawStack == 3)
                        {
                            lbforth.Visible = false;
                            pbYellow.Visible = false;
                            lbforth.Update();
                            pbYellow.Update();
                            break;
                        }
                    }
                    else if (listCSV[i][0].Contains("X"))
                    {
                        string Dataname = strData[0].ToString();
                        string strtemp = strData.Substring(1);
                        Dataname += " _" + strtemp;
                        plotView1.Model = new PlotModel { Title = "X" + "_" + Dataname };
                        LineSeries fs = new LineSeries();
                        lbfirst.Text = "X";
                        lbfirst.Visible = true;
                        pbRed.Visible = true;
                        lbfirst.Update();
                        pbRed.Update();
                        DrawChart(listCSV[i], drawStack, ref fs);
                        drawStack++;

                        for (int j = 0; j < listCSV.Count(); ++j)
                        {
                            if (listCSV[j][0].Contains(strFolder)
                                && listCSV[j][0].Contains(strData)
                                && (listCSV[j][0].Contains("ADD_LR")))
                            {
                                LineSeries fs2 = new LineSeries();
                                lbSecond.Text = "ADD_LR";
                                lbSecond.Visible = true;
                                pbGreen.Visible = true;
                                lbSecond.Update();
                                pbGreen.Update();
                                DrawChart(listCSV[j], drawStack, ref fs2);
                                drawStack++;

                                if (drawStack == 2)
                                    break;
                            }
                        }

                        if (drawStack == 2)
                        {
                            lbthird.Visible = false;
                            pbBlue.Visible = false;
                            lbforth.Visible = false;
                            pbYellow.Visible = false;
                            lbthird.Update();
                            pbBlue.Update();
                            lbforth.Update();
                            pbYellow.Update();
                            break;
                        }
                    }
                    else if (listCSV[i][0].Contains("Y"))
                    {
                        string Dataname = strData[0].ToString();
                        string strtemp = strData.Substring(1);
                        Dataname += " _" + strtemp;
                        plotView1.Model = new PlotModel { Title = "Y" + "_" + Dataname };
                        LineSeries fs = new LineSeries();
                        lbfirst.Text = "Y";
                        lbfirst.Visible = true;
                        pbRed.Visible = true;
                        lbfirst.Update();
                        pbRed.Update();
                        DrawChart(listCSV[i], drawStack, ref fs);
                        drawStack++;

                        for (int j = 0; j < listCSV.Count(); ++j)
                        {
                            if (listCSV[j][0].Contains(strFolder)
                                && listCSV[j][0].Contains(strData)
                                && (listCSV[j][0].Contains("ADD_UD")))
                            {
                                LineSeries fs2 = new LineSeries();
                                lbSecond.Text = "ADD_UD";
                                lbSecond.Visible = true;
                                pbGreen.Visible = true;
                                lbSecond.Update();
                                pbGreen.Update();
                                DrawChart(listCSV[j], drawStack, ref fs2);
                                drawStack++;

                                if (drawStack == 2)
                                    break;
                            }
                        }

                        if (drawStack == 2)
                        {
                            lbthird.Visible = false;
                            pbBlue.Visible = false;
                            lbforth.Visible = false;
                            pbYellow.Visible = false;
                            lbthird.Update();
                            pbBlue.Update();
                            lbforth.Update();
                            pbYellow.Update();
                      
                            break;
                        }
                    }
                }
            }
            drawStack = 0;
        }
        public void WorksRepButton()
        {
            // 선택된 값 가져오기
            string strPattern = cbRepPattern.SelectedItem.ToString();
            string strData = cbRepData.SelectedItem.ToString();

            int drawStack = 0;
            List<string[]> listCSV = new List<string[]>();
            //csv 로딩
            using (StreamReader rd = new StreamReader(@"WVLightingCompare.csv"))
            {
                while (!rd.EndOfStream)
                {
                    string s = rd.ReadLine();
                    string[] temp = s.Split(',');
                    listCSV.Add(temp);
                }
            }
            string Dataname = strData[0].ToString();
            string strtemp = strData.Substring(1);
            Dataname += " _" + strtemp;
            plotView1.Model = new PlotModel { Title = strPattern + "_" + Dataname };
            for (int i = 0; i < listCSV.Count(); ++i)
            {

                if (listCSV[i][0].Contains(strData)
                    && listCSV[i][0].Contains(strPattern))
                {
                    LineSeries fs = new LineSeries();
                    lbfirst.Visible = true;
                    lbfirst.Text = "#1";
                    pbRed.Visible = true;
                    lbSecond.Visible = true;
                    lbSecond.Text = "#2";
                    pbGreen.Visible = true;
                    lbthird.Visible = true;
                    lbthird.Text = "#3";
                    pbBlue.Visible = true;
                    lbforth.Visible = true;
                    lbforth.Text = "#4";
                    pbYellow.Visible = true;
                    lbfirst.Update();
                    pbRed.Update();
                    lbSecond.Update();
                    pbGreen.Update();
                    lbthird.Update();
                    pbBlue.Update();
                    lbforth.Update();
                    pbYellow.Update();
                    DrawChart(listCSV[i], drawStack, ref fs);

                    drawStack++;
                    if (drawStack == 4)
                    {
                        break;
                    }
                }
            }
        }

        public void LoadComboBox()
        {
            cbfolder.Items.Add("#1");
            cbfolder.Items.Add("#2");
            cbfolder.Items.Add("#3");
            cbfolder.Items.Add("#4");

            cbUniPattern.Items.Add("ALL");
            cbUniPattern.Items.Add("_X_");
            cbUniPattern.Items.Add("_Y_");

            cbUniData.Items.Add("HTop");
            cbUniData.Items.Add("HCenter");
            cbUniData.Items.Add("HBot");
            cbUniData.Items.Add("VLeft");
            cbUniData.Items.Add("VCenter");
            cbUniData.Items.Add("VRight");
            cbUniData.Items.Add("Horizontal");
            cbUniData.Items.Add("Vertical");

            cbRepPattern.Items.Add("ALL");
            cbRepPattern.Items.Add("ADD_XY");
            cbRepPattern.Items.Add("ADD_LRUD");
            cbRepPattern.Items.Add("_X_");
            cbRepPattern.Items.Add("_ADD_LR_");
            cbRepPattern.Items.Add("_Y_");
            cbRepPattern.Items.Add("_ADD_UD_");

            cbRepData.Items.Add("HTop");
            cbRepData.Items.Add("HCenter");
            cbRepData.Items.Add("HBot");
            cbRepData.Items.Add("VLeft");
            cbRepData.Items.Add("VCenter");
            cbRepData.Items.Add("VRight");
            cbRepData.Items.Add("Horizontal");
            cbRepData.Items.Add("Vertical");


        }

        public void DrawChart(string[] temp, int drawstack, ref LineSeries fs)
        {
            // 타이틀, 색상, temp    
            for (int i = 1; i < temp.Length; ++i)
            {
                fs.Points.Add(new DataPoint(i - 1, int.Parse(temp[i])));
            }

            if (drawstack == 0)
            {
                fs.Color = OxyColors.Red;              
            }
            if (drawstack == 1)
            {
                fs.Color = OxyColors.Green;
            }
            if (drawstack == 2)
            {
                fs.Color = OxyColors.Blue;
            }
            if (drawstack == 3)
            {
                fs.Color = OxyColors.Yellow;
            }
            fs.StrokeThickness = 1;
            plotView1.Model.InvalidatePlot(true);
            plotView1.Model.Series.Add(fs);
        }
        
        public void LoadChart()
        {
            PlotModel pm = new PlotModel { Title = "" };
            plotView1.Model = pm;
            plotView1.Model.PlotType = PlotType.XY;
            plotView1.Model.InvalidatePlot(true);
            
            plotView1.Location = new System.Drawing.Point(0, 0);
            plotView1.Size = new System.Drawing.Size(650, 450);

            plotView1.Model = new PlotModel { Title = "example" };

            LineSeries fs = new FunctionSeries();
            fs.Title = "data1";
            fs.Color = OxyColors.Red;
            fs.Points.Add(new DataPoint(0, 0));
            plotView1.Model.Series.Add(fs);
            LineSeries fs2 = new FunctionSeries();
            fs2.Title = "data2";
            fs2.Color = OxyColors.Green;
            fs2.Points.Add(new DataPoint(0, 10));
            plotView1.Model.Series.Add(fs2);

        }

        public Form1()
        {
            InitializeComponent();

            List<Mat>[] listImgArr = new List<Mat>[FOLDER_NUM];
            List<string>[] listImgNameArr = new List<string>[FOLDER_NUM];

            string str = System.IO.Directory.GetCurrentDirectory();

            //csv파일 있으면 삭제
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(str);
            foreach (var item in di.GetFiles())
            {
                if (item.FullName.Contains("WVLightingCompare"))
                {
                    File.Delete(item.FullName);
                    break;
                }
            }

            str += "\\Image\\";

            di = new System.IO.DirectoryInfo(str);
            var dir = di.GetDirectories();
            string[] curDir = new string[4];
            curDir[0] = dir[0].FullName;
            int ifolderIdx = 0;

            //이미지을 불러온다.
            for (int i = 0; i < FOLDER_NUM; ++i)
            {
                listImgArr[ifolderIdx] = new List<Mat>();
                listImgNameArr[ifolderIdx] = new List<string>();
                foreach (var item in dir[i].GetFiles())
                {
                    if (curDir[ifolderIdx] != item.DirectoryName)
                    {
                        curDir[ifolderIdx] = item.DirectoryName;
                    }
                    //그래프 파일과 ADD파일 chart파일은 제외한다.
                    string filename = item.Name;
                    string[] extense = filename.Split('.');

                    if (extense[1] != "bmp")
                    {
                        continue;
                    }

                    if (extense[0].Contains("ADD"))
                        continue;

                    curDir[ifolderIdx] += ("\\" + item.Name);
                    listImgArr[ifolderIdx].Add(Cv2.ImRead(curDir[ifolderIdx], ImreadModes.Grayscale));
                    listImgNameArr[ifolderIdx].Add(item.Name);
                    curDir[ifolderIdx] = item.DirectoryName;
                }
                ifolderIdx++;
            }

            for (int i = 0; i < FOLDER_NUM; ++i)
            {
                //합연산으로 ADD 이미지 생성한다.
                Mat[] addImg = new Mat[4];
                for (int j = 0; j < 4; ++j)
                {
                    addImg[j] = listImgArr[0][j].Clone();
                }
                int localIdx = 0;
                int range = listImgArr[3].Count();

                //좌, 우, 상, 하 따로있는 영상은 합연산으로 합친다.
                for (int j = 0; j < range; ++j)
                {
                    if (listImgNameArr[i][j].Contains("X.bmp"))
                    {
                        for (int k = 0; k < range; ++k)
                        {
                            if (listImgNameArr[i][k].Contains("Y.bmp"))
                            {
                                Cv2.Add(listImgArr[i][j], listImgArr[i][k], addImg[localIdx]);
                                listImgArr[i].Add(addImg[localIdx]);
                                string name1 = listImgNameArr[i][j];
                                string[] partname = name1.Split('_');
                                name1 = partname[0] + partname[1] + "ADD_XY.bmp";
                                name1 = curDir[i] + "\\" + name1;
                                listImgNameArr[i].Add(name1);
                                Cv2.ImWrite(name1, addImg[localIdx++]);
                                break;
                            }
                        }
                    }
                    if (listImgNameArr[i][j].Contains("L.bmp"))
                    {
                        //ALL은 제외
                        if (listImgNameArr[i][j].Contains("ALL"))
                            continue;
                        for (int k = 0; k < range; ++k)
                        {
                            if (listImgNameArr[i][k].Contains("R.bmp"))
                            {
                                Cv2.Add(listImgArr[i][j], listImgArr[i][k], addImg[localIdx]);
                                listImgArr[i].Add(addImg[localIdx]);
                                string name1 = listImgNameArr[i][j];
                                string[] partname = name1.Split('_');
                                name1 = partname[0] + partname[1] + "ADD_LR.bmp";
                                name1 = curDir[i] + "\\" + name1;
                                listImgNameArr[i].Add(name1);
                                Cv2.ImWrite(name1, addImg[localIdx++]);
                                break;
                            }
                        }
                    }

                    if (listImgNameArr[i][j].Contains("D.bmp"))
                    {
                        for (int k = 0; k < range; ++k)
                        {
                            if (listImgNameArr[i][k].Contains("U.bmp"))
                            {
                                Cv2.Add(listImgArr[i][j], listImgArr[i][k], addImg[localIdx]);
                                listImgArr[i].Add(addImg[localIdx]);
                                string name1 = listImgNameArr[i][j];
                                string[] partname = name1.Split('_');
                                name1 = partname[0] + partname[1] + "ADD_UD.bmp";
                                name1 = curDir[i] + "\\" + name1;
                                listImgNameArr[i].Add(name1);
                                Cv2.ImWrite(name1, addImg[localIdx++]);
                                break;
                            }
                        }
                    }
                }
                Cv2.Add(addImg[1], addImg[2], addImg[3]);
                listImgArr[i].Add(addImg[3]);
                string name2 = listImgNameArr[i][2];
                string[] partname2 = name2.Split('_');
                name2 = partname2[0] + partname2[1] + "ADD_LRUD.bmp";
                name2 = curDir[i] + "\\" + name2;
                listImgNameArr[i].Add(name2);
                Cv2.ImWrite(name2, addImg[3]);
            }
            //라인 프로파일링 진행
            //데이터 6개 * 이미지 7개 * 폴더수 4개 => 168줄 생성
            //이미지 인덱스 ALL, ADDXY, ADDRLUD, X, ADDLR, Y, ADD UD

            for (int i = 0; i < FOLDER_NUM; ++i)
            {
                for (int j = 0; j < 7; ++j)
                {
                    int imgIdx = 0;

                    //필요한 이미지 인덱스 저장
                    for (int k = 0; k < listImgNameArr[0].Count; ++k)
                    {
                        if (listImgNameArr[i][k].Contains(strplotImagename[j]))
                        {
                            Cv2.Blur(listImgArr[i][k], listImgArr[i][k], new OpenCvSharp.Size(5, 5));
                            imgIdx = k;
                            break;
                        }
                    }
                    using (StreamWriter wr = new StreamWriter(@"WVLightingCompare.csv", true))
                    {
                        WriteCSV(wr, j, imgIdx, ref listImgArr, ref listImgNameArr, i);
                    }
                }
            }
            //콤보박스 로딩
            LoadComboBox();

            //그래프 로딩
            LoadChart();
            

            
        }
        private void drawUniBtn_Click(object sender, EventArgs e)
        {
            WorksUniButton();
        }

        private void drawRepBtn_Click(object sender, EventArgs e)
        {
            WorksRepButton();
        }

        private void btnSaveImg_Click(object sender, EventArgs e)
        {
            
            string fileName;
            SaveFileDialog saveFileDlg = new SaveFileDialog();
            saveFileDlg.Title = "차트를 이미지로 저장하기";
            saveFileDlg.OverwritePrompt = true;
            saveFileDlg.Filter = "PNG file (*.png) |*.png";

            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                // Bitmap 데이타를 파일로 저장
                fileName = saveFileDlg.FileName;
                SaveChart(fileName, true);
            }
        }


        //그래프 저장
        // #1 균일성 데이터 6개 이미지 패턴에 맞춰서 3개 총 18개 *4(폴더갯수) = 72
        // #2 반복성 폴더 1개 만들고 1~4폴더에 겹치는 그래프 합쳐서 하나의 차트를 만듬 데이터 6개 이미지 7개 총 42개
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            //균일성 차트 저장
            for (int i = 0; i < FOLDER_NUM; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    for (int k = 0; k < 8; ++k)
                    {
                        if (j != 0 && k > 5)
                            continue;

                        cbfolder.SelectedIndex = i;
                        cbUniPattern.SelectedIndex = j;
                        cbUniData.SelectedIndex = k;
                        WorksUniButton();
                        plotView1.Update();
                        string foldername = System.IO.Directory.GetCurrentDirectory();
                        foldername += "\\Image\\" + strfolderNum[i] + "\\";
                        foldername += strchartImagenameUni[j] + strplotDataname[k] + ".png";
                        SaveChart(foldername);
                    }
                }
            }

            //반복성 차트 저장
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < 6; ++j)
                {
                    cbRepPattern.SelectedIndex = i;
                    cbRepData.SelectedIndex = j;
                    WorksRepButton();
                    plotView1.Update();
                    string foldername = System.IO.Directory.GetCurrentDirectory();
                    foldername += "\\Image\\Repeat\\";
                    foldername += strchartImagenameRep[i] + strplotDataname[j] + ".png";
                    SaveChart(foldername);
                }
            }
        }
    }
}
