using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bull
{
    public class ColorsWindow : Form
    {
        private Color m_SelectedColor;
        private Button m_YellowButton;
        private Button m_BlueButton;
        private Button m_GreenButton;
        private Button m_GrayButton;
        private Button m_BrownButton;
        private Button m_PurpleButton;
        private Button m_PinkButton;
        private Button m_RedButton;

        public ColorsWindow()
        {
            InitializeComponent();  
        }
        private void InitializeComponent()
        {
            this.m_YellowButton = new System.Windows.Forms.Button();
            this.m_BlueButton = new System.Windows.Forms.Button();
            this.m_GreenButton = new System.Windows.Forms.Button();
            this.m_RedButton = new System.Windows.Forms.Button();
            this.m_GrayButton = new System.Windows.Forms.Button();
            this.m_BrownButton = new System.Windows.Forms.Button();
            this.m_PurpleButton = new System.Windows.Forms.Button();
            this.m_PinkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_YellowButton
            // 
            this.m_YellowButton.BackColor = System.Drawing.Color.Yellow;
            this.m_YellowButton.Location = new System.Drawing.Point(29, 26);
            this.m_YellowButton.Name = "m_YellowButton";
            this.m_YellowButton.Size = new System.Drawing.Size(78, 68);
            this.m_YellowButton.TabIndex = 0;
            this.m_YellowButton.UseVisualStyleBackColor = false;
            // 
            // m_BlueButton
            // 
            this.m_BlueButton.BackColor = System.Drawing.Color.Blue;
            this.m_BlueButton.Location = new System.Drawing.Point(123, 26);
            this.m_BlueButton.Name = "m_BlueButton";
            this.m_BlueButton.Size = new System.Drawing.Size(78, 68);
            this.m_BlueButton.TabIndex = 1;
            this.m_BlueButton.UseVisualStyleBackColor = false;
            // 
            // m_GreenButton
            // 
            this.m_GreenButton.BackColor = System.Drawing.Color.Green;
            this.m_GreenButton.Location = new System.Drawing.Point(303, 26);
            this.m_GreenButton.Name = "m_GreenButton";
            this.m_GreenButton.Size = new System.Drawing.Size(78, 68);
            this.m_GreenButton.TabIndex = 3;
            this.m_GreenButton.UseVisualStyleBackColor = false;
            // 
            // m_RedButton
            // 
            this.m_RedButton.BackColor = System.Drawing.Color.Red;
            this.m_RedButton.Location = new System.Drawing.Point(209, 26);
            this.m_RedButton.Name = "m_RedButton";
            this.m_RedButton.Size = new System.Drawing.Size(78, 68);
            this.m_RedButton.TabIndex = 2;
            this.m_RedButton.UseVisualStyleBackColor = false;
            // 
            // m_GrayButton
            // 
            this.m_GrayButton.BackColor = System.Drawing.Color.Gray;
            this.m_GrayButton.Location = new System.Drawing.Point(303, 113);
            this.m_GrayButton.Name = "m_GrayButton";
            this.m_GrayButton.Size = new System.Drawing.Size(78, 68);
            this.m_GrayButton.TabIndex = 7;
            this.m_GrayButton.UseVisualStyleBackColor = false;
            // 
            // m_BrownButton
            // 
            this.m_BrownButton.BackColor = System.Drawing.Color.Brown;
            this.m_BrownButton.Location = new System.Drawing.Point(209, 113);
            this.m_BrownButton.Name = "m_BrownButton";
            this.m_BrownButton.Size = new System.Drawing.Size(78, 68);
            this.m_BrownButton.TabIndex = 6;
            this.m_BrownButton.UseVisualStyleBackColor = false;
            // 
            // m_PurpleButton
            // 
            this.m_PurpleButton.BackColor = System.Drawing.Color.Purple;
            this.m_PurpleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_PurpleButton.Location = new System.Drawing.Point(123, 113);
            this.m_PurpleButton.Name = "m_PurpleButton";
            this.m_PurpleButton.Size = new System.Drawing.Size(78, 68);
            this.m_PurpleButton.TabIndex = 5;
            this.m_PurpleButton.UseVisualStyleBackColor = false;
            // 
            // m_PinkButton
            // 
            this.m_PinkButton.BackColor = System.Drawing.Color.Pink;
            this.m_PinkButton.Location = new System.Drawing.Point(29, 113);
            this.m_PinkButton.Name = "m_PinkButton";
            this.m_PinkButton.Size = new System.Drawing.Size(78, 68);
            this.m_PinkButton.TabIndex = 4;
            this.m_PinkButton.UseVisualStyleBackColor = false;
            // 
            // ColorsWindow
            // 
            this.ClientSize = new System.Drawing.Size(421, 205);
            this.Controls.Add(this.m_GrayButton);
            this.Controls.Add(this.m_BrownButton);
            this.Controls.Add(this.m_PurpleButton);
            this.Controls.Add(this.m_PinkButton);
            this.Controls.Add(this.m_GreenButton);
            this.Controls.Add(this.m_RedButton);
            this.Controls.Add(this.m_BlueButton);
            this.Controls.Add(this.m_YellowButton);
            this.Name = "ColorsWindow";
            this.Text = "ColorsWindow";
            this.Load += new System.EventHandler(this.ColorsWindow_Load);
            this.ResumeLayout(false);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;


        }
        private void ColorButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            m_SelectedColor = clickedButton.BackColor;
            clickedButton.Enabled = false;
            this.Close();   
        }
        public Color SelectedColor
        {
            get { return m_SelectedColor; }
        }

        private void ColorsWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
