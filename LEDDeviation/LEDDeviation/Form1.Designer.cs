namespace LEDDeviation
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbfolder = new System.Windows.Forms.ComboBox();
            this.cbUniPattern = new System.Windows.Forms.ComboBox();
            this.cbUniData = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.drawUniBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRepPattern = new System.Windows.Forms.ComboBox();
            this.cbRepData = new System.Windows.Forms.ComboBox();
            this.drawRepBtn = new System.Windows.Forms.Button();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.btnSaveImg = new System.Windows.Forms.Button();
            this.lbfirst = new System.Windows.Forms.Label();
            this.lbSecond = new System.Windows.Forms.Label();
            this.lbthird = new System.Windows.Forms.Label();
            this.lbforth = new System.Windows.Forms.Label();
            this.pbRed = new System.Windows.Forms.PictureBox();
            this.pbGreen = new System.Windows.Forms.PictureBox();
            this.pbBlue = new System.Windows.Forms.PictureBox();
            this.pbYellow = new System.Windows.Forms.PictureBox();
            this.btnSaveAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYellow)).BeginInit();
            this.SuspendLayout();
            // 
            // cbfolder
            // 
            this.cbfolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfolder.FormattingEnabled = true;
            this.cbfolder.Location = new System.Drawing.Point(103, 475);
            this.cbfolder.Name = "cbfolder";
            this.cbfolder.Size = new System.Drawing.Size(121, 20);
            this.cbfolder.TabIndex = 0;
            // 
            // cbUniPattern
            // 
            this.cbUniPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUniPattern.FormattingEnabled = true;
            this.cbUniPattern.Location = new System.Drawing.Point(279, 475);
            this.cbUniPattern.Name = "cbUniPattern";
            this.cbUniPattern.Size = new System.Drawing.Size(121, 20);
            this.cbUniPattern.TabIndex = 1;
            // 
            // cbUniData
            // 
            this.cbUniData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUniData.FormattingEnabled = true;
            this.cbUniData.Location = new System.Drawing.Point(446, 475);
            this.cbUniData.Name = "cbUniData";
            this.cbUniData.Size = new System.Drawing.Size(121, 20);
            this.cbUniData.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "패턴선택";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "데이터지표 선택";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 460);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "폴더넘버선택";
            // 
            // drawUniBtn
            // 
            this.drawUniBtn.Location = new System.Drawing.Point(446, 523);
            this.drawUniBtn.Name = "drawUniBtn";
            this.drawUniBtn.Size = new System.Drawing.Size(121, 23);
            this.drawUniBtn.TabIndex = 6;
            this.drawUniBtn.Text = "그리기";
            this.drawUniBtn.UseVisualStyleBackColor = true;
            this.drawUniBtn.Click += new System.EventHandler(this.drawUniBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "균일성";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 598);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "반복성";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(313, 583);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "패턴선택";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 583);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "데이터지표 선택";
            // 
            // cbRepPattern
            // 
            this.cbRepPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRepPattern.FormattingEnabled = true;
            this.cbRepPattern.Location = new System.Drawing.Point(279, 598);
            this.cbRepPattern.Name = "cbRepPattern";
            this.cbRepPattern.Size = new System.Drawing.Size(121, 20);
            this.cbRepPattern.TabIndex = 11;
            // 
            // cbRepData
            // 
            this.cbRepData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRepData.FormattingEnabled = true;
            this.cbRepData.Location = new System.Drawing.Point(446, 598);
            this.cbRepData.Name = "cbRepData";
            this.cbRepData.Size = new System.Drawing.Size(121, 20);
            this.cbRepData.TabIndex = 12;
            // 
            // drawRepBtn
            // 
            this.drawRepBtn.Location = new System.Drawing.Point(446, 624);
            this.drawRepBtn.Name = "drawRepBtn";
            this.drawRepBtn.Size = new System.Drawing.Size(121, 23);
            this.drawRepBtn.TabIndex = 13;
            this.drawRepBtn.Text = "그리기";
            this.drawRepBtn.UseVisualStyleBackColor = true;
            this.drawRepBtn.Click += new System.EventHandler(this.drawRepBtn_Click);
            // 
            // plotView1
            // 
            this.plotView1.Location = new System.Drawing.Point(83, 24);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(585, 397);
            this.plotView1.TabIndex = 14;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // btnSaveImg
            // 
            this.btnSaveImg.Location = new System.Drawing.Point(593, 523);
            this.btnSaveImg.Name = "btnSaveImg";
            this.btnSaveImg.Size = new System.Drawing.Size(119, 23);
            this.btnSaveImg.TabIndex = 15;
            this.btnSaveImg.Text = "이미지저장";
            this.btnSaveImg.UseVisualStyleBackColor = true;
            this.btnSaveImg.Click += new System.EventHandler(this.btnSaveImg_Click);
            // 
            // lbfirst
            // 
            this.lbfirst.AutoSize = true;
            this.lbfirst.Location = new System.Drawing.Point(674, 124);
            this.lbfirst.Name = "lbfirst";
            this.lbfirst.Size = new System.Drawing.Size(38, 12);
            this.lbfirst.TabIndex = 16;
            this.lbfirst.Text = "label8";
            this.lbfirst.Visible = false;
            // 
            // lbSecond
            // 
            this.lbSecond.AutoSize = true;
            this.lbSecond.Location = new System.Drawing.Point(674, 149);
            this.lbSecond.Name = "lbSecond";
            this.lbSecond.Size = new System.Drawing.Size(38, 12);
            this.lbSecond.TabIndex = 17;
            this.lbSecond.Text = "label9";
            this.lbSecond.Visible = false;
            // 
            // lbthird
            // 
            this.lbthird.AutoSize = true;
            this.lbthird.Location = new System.Drawing.Point(674, 174);
            this.lbthird.Name = "lbthird";
            this.lbthird.Size = new System.Drawing.Size(44, 12);
            this.lbthird.TabIndex = 18;
            this.lbthird.Text = "label10";
            this.lbthird.Visible = false;
            // 
            // lbforth
            // 
            this.lbforth.AutoSize = true;
            this.lbforth.Location = new System.Drawing.Point(674, 200);
            this.lbforth.Name = "lbforth";
            this.lbforth.Size = new System.Drawing.Size(44, 12);
            this.lbforth.TabIndex = 19;
            this.lbforth.Text = "label11";
            this.lbforth.Visible = false;
            // 
            // pbRed
            // 
            this.pbRed.BackColor = System.Drawing.Color.Red;
            this.pbRed.Location = new System.Drawing.Point(651, 122);
            this.pbRed.Name = "pbRed";
            this.pbRed.Size = new System.Drawing.Size(18, 19);
            this.pbRed.TabIndex = 20;
            this.pbRed.TabStop = false;
            this.pbRed.Visible = false;
            // 
            // pbGreen
            // 
            this.pbGreen.BackColor = System.Drawing.Color.Lime;
            this.pbGreen.Location = new System.Drawing.Point(651, 147);
            this.pbGreen.Name = "pbGreen";
            this.pbGreen.Size = new System.Drawing.Size(18, 19);
            this.pbGreen.TabIndex = 21;
            this.pbGreen.TabStop = false;
            this.pbGreen.Visible = false;
            // 
            // pbBlue
            // 
            this.pbBlue.BackColor = System.Drawing.Color.Blue;
            this.pbBlue.Location = new System.Drawing.Point(651, 172);
            this.pbBlue.Name = "pbBlue";
            this.pbBlue.Size = new System.Drawing.Size(18, 19);
            this.pbBlue.TabIndex = 22;
            this.pbBlue.TabStop = false;
            this.pbBlue.Visible = false;
            // 
            // pbYellow
            // 
            this.pbYellow.BackColor = System.Drawing.Color.Yellow;
            this.pbYellow.Location = new System.Drawing.Point(651, 197);
            this.pbYellow.Name = "pbYellow";
            this.pbYellow.Size = new System.Drawing.Size(18, 19);
            this.pbYellow.TabIndex = 23;
            this.pbYellow.TabStop = false;
            this.pbYellow.Visible = false;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(593, 472);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(119, 23);
            this.btnSaveAll.TabIndex = 24;
            this.btnSaveAll.Text = "차트 모두 저장";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(757, 713);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.pbYellow);
            this.Controls.Add(this.pbBlue);
            this.Controls.Add(this.pbGreen);
            this.Controls.Add(this.pbRed);
            this.Controls.Add(this.lbforth);
            this.Controls.Add(this.lbthird);
            this.Controls.Add(this.lbSecond);
            this.Controls.Add(this.lbfirst);
            this.Controls.Add(this.btnSaveImg);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.drawRepBtn);
            this.Controls.Add(this.cbRepData);
            this.Controls.Add(this.cbRepPattern);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.drawUniBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUniData);
            this.Controls.Add(this.cbUniPattern);
            this.Controls.Add(this.cbfolder);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYellow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbfolder;
        private System.Windows.Forms.ComboBox cbUniPattern;
        private System.Windows.Forms.ComboBox cbUniData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button drawUniBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRepPattern;
        private System.Windows.Forms.ComboBox cbRepData;
        private System.Windows.Forms.Button drawRepBtn;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Button btnSaveImg;
        private System.Windows.Forms.Label lbfirst;
        private System.Windows.Forms.Label lbSecond;
        private System.Windows.Forms.Label lbthird;
        private System.Windows.Forms.Label lbforth;
        private System.Windows.Forms.PictureBox pbRed;
        private System.Windows.Forms.PictureBox pbGreen;
        private System.Windows.Forms.PictureBox pbBlue;
        private System.Windows.Forms.PictureBox pbYellow;
        private System.Windows.Forms.Button btnSaveAll;
    }
}

