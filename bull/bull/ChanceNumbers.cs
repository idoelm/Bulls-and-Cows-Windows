using System;
using System.Windows.Forms;

namespace bull
{
    public class ChanceNumbers : Form
    {
        private Button m_ChanceNumbersButton;
        private Button m_StartButton;
        private int m_CounterChances = 4;

        public ChanceNumbers()
        {
            InitializeComponent();
            m_ChanceNumbersButton.Text = string.Format("Number of chances: {0}", m_CounterChances);
        }

        private void InitializeComponent()
        {
            this.m_ChanceNumbersButton = new System.Windows.Forms.Button();
            this.m_StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ChanceNumbersButton
            // 
            this.m_ChanceNumbersButton.BackColor = System.Drawing.SystemColors.Info;
            this.m_ChanceNumbersButton.Location = new System.Drawing.Point(21, 60);
            this.m_ChanceNumbersButton.Name = "m_ChanceNumbersButton";
            this.m_ChanceNumbersButton.Size = new System.Drawing.Size(236, 63);
            this.m_ChanceNumbersButton.TabIndex = 0;
            this.m_ChanceNumbersButton.UseVisualStyleBackColor = false;
            this.m_ChanceNumbersButton.Click += new System.EventHandler(this.m_ChanceNumbersButton_Click);
            // 
            // m_StartButton
            // 
            this.m_StartButton.BackColor = System.Drawing.Color.Yellow;
            this.m_StartButton.Location = new System.Drawing.Point(163, 163);
            this.m_StartButton.Name = "m_StartButton";
            this.m_StartButton.Size = new System.Drawing.Size(94, 39);
            this.m_StartButton.TabIndex = 1;
            this.m_StartButton.Text = "Start";
            this.m_StartButton.UseVisualStyleBackColor = false;
            this.m_StartButton.Click += new System.EventHandler(this.m_StartButton_Click);
            // 
            // ChanceNumbers
            // 
            this.ClientSize = new System.Drawing.Size(278, 214);
            this.Controls.Add(this.m_StartButton);
            this.Controls.Add(this.m_ChanceNumbersButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChanceNumbers";
            this.Text = "Bool Pgia";
            this.Load += new System.EventHandler(this.ChanceNumbers_Load);
            this.ResumeLayout(false);

        }

        private void m_ChanceNumbersButton_Click(object sender, EventArgs e)
        {
            if (m_CounterChances < 10)
            {
                m_CounterChances++;
                m_ChanceNumbersButton.Text = string.Format("Number of chances: {0}", m_CounterChances);
            }
        }

        public int CounterChances
        { get { return m_CounterChances; } }

        private void m_StartButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChanceNumbers_Load(object sender, EventArgs e)
        {

        }
    }
}
