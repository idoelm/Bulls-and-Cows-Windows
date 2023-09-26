using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bull
{
    public class GameBoard : Form
    {
        Form m_Owner;
        private RandomColors m_RandomColors;
        private List<Color> m_MyColors;
        private int m_WindowHeight = 534;
        private int m_AddHeight = 41;
        private int m_WindowWidth = 518;
        private int m_MinChance = 4;

        private int m_NewLine = 81;
        private int m_StartRow = 113;
        private int m_JumpPixel = 66;

        List<ButtonsGuesses> m_buttonsGuessesList = new List<ButtonsGuesses>();
        private int m_Index = 0;
        List<Panel> m_BlackPanelList = new List<Panel>();
        private int m_StartColumnBlackPanel = 29;
        private int m_RowBlackPanel = 33;
        private int m_TotalBlackPanel = 4;

        private Panel m_Panel;
        private Panel scrollablePanel;

        public GameBoard(int i_ChanceNumbers)
        {
            m_Owner = new Form();
            m_Owner = this;
            m_RandomColors = new RandomColors();
            m_MyColors = m_RandomColors.SelectRandomColors();
            this.Size = new Size(m_WindowWidth, m_WindowHeight + (i_ChanceNumbers - m_MinChance) * m_AddHeight);
            InitializeBlackPanel();
            scrollablePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(scrollablePanel);
            for (int i = 0; i < i_ChanceNumbers; i++)
            {
                ButtonsGuesses buttonsGuesses = new ButtonsGuesses(m_StartRow + m_NewLine * i,i_ChanceNumbers ,ref m_MyColors, ref m_Owner);
                buttonsGuesses.ColoringComplete += ColoringComplete;
                buttonsGuesses.AllButtonsTrue += ColoringComplete;
                buttonsGuesses.ColoringLineOfButtons += EnableNextLine;
                m_buttonsGuessesList.Add(buttonsGuesses);
                scrollablePanel.Controls.AddRange(buttonsGuesses.ButtonsGuessesList.ToArray());
                scrollablePanel.Controls.Add(buttonsGuesses.ButtonsArrow);
                scrollablePanel.Controls.AddRange(buttonsGuesses.CowsAndBullPanelList.ToArray());
            }
            m_buttonsGuessesList.ElementAt(m_Index).EnableButtons();
        }
        private void InitializeBlackPanel()
        {
            for (int i = 0; i < m_TotalBlackPanel; i++)
            {
                m_Panel = new Panel();
                this.m_Panel.BackColor = System.Drawing.Color.Black;
                this.m_Panel.Location = new System.Drawing.Point(m_StartColumnBlackPanel + i * m_JumpPixel, m_RowBlackPanel);
                this.m_Panel.Name = "panel1";
                this.m_Panel.Size = new System.Drawing.Size(50, 50);
                m_BlackPanelList.Add(this.m_Panel);
                this.Controls.Add(m_BlackPanelList.ElementAt(m_BlackPanelList.Count - 1));
            }
        }
        private void ColoringComplete(object sender, EventArgs e)
        {
            ShowColors();
        }
        private void ShowColors()
        {
            for( int i = 0;  i < m_BlackPanelList.Count; i++) 
            {
                m_BlackPanelList.ElementAt(i).BackColor = m_MyColors.ElementAt(i);
            }
        }
        private void EnableNextLine(object sender, EventArgs e)
        {
            if(m_Index < m_buttonsGuessesList.Count - 1)
            {
                m_Index++;
                m_buttonsGuessesList.ElementAt(m_Index).EnableButtons();
            }
            
        }
    }
}
