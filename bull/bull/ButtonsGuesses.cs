using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace bull
{
    public class ButtonsGuesses
    {
        List<Color> m_SelectedColors;
        private ColorsWindow m_ColorsWindow = new ColorsWindow();
        private int m_PaintedButtonCounter = 0;
        private List<Button> m_ButtonsGuessesList = new List<Button>();
        private int m_JumpPixel = 66;
        private int m_StartColumnOfButtonGuess = 29;
        private int m_TotalColumnOfButtonGuess = 4;
        private int m_StartRow;
        private int m_SumRows;
        private Button m_ButtonsArrow = new Button();
        private int m_StartColumnOfButtonsArrow = 300;
        private List<Panel> m_CowsAndBullPanelList = new List<Panel>();
        private int m_StartColumnOfCowsAndBullPanel = 412;
        private int m_Index = 0;
        private int m_JumpPixelOfCowsAndBull = 35;
        public event EventHandler ColoringComplete;
        public event EventHandler AllButtonsTrue;
        public event EventHandler ColoringLineOfButtons;
        public static int m_CounterCompleteLine = 0;

        public ButtonsGuesses(int startRow,int i_SumRows,ref List<Color> i_MyColors, ref Form i_OwnerOfColorsWindow)
        {
            m_ColorsWindow.Owner = i_OwnerOfColorsWindow;
            m_ColorsWindow.StartPosition = FormStartPosition.CenterParent;
            m_StartRow = startRow;
            m_SumRows = i_SumRows;
            m_SelectedColors = i_MyColors;
            InitializeButtonsGuessesList();
        }

        private void InitializeButtonsGuessesList()
        {
            for (int column = 0; column < m_TotalColumnOfButtonGuess; column++)
            {
                Button buttonGuess = new Button();
                buttonGuess.Location = new Point(m_StartColumnOfButtonGuess + column * m_JumpPixel, m_StartRow);
                buttonGuess.Size = new Size(50, 50);
                buttonGuess.UseVisualStyleBackColor = true;
                buttonGuess.Click += ButtonGuessesClick;
                buttonGuess.Enabled = false;
                m_ButtonsGuessesList.Add(buttonGuess);
            }

            InitializeArrowButtons();
        }

        private void InitializeArrowButtons()
        {
            m_ButtonsArrow.Location = new Point(m_StartColumnOfButtonsArrow, m_StartRow);
            m_ButtonsArrow.Size = new Size(73, 50);
            m_ButtonsArrow.TabIndex = 8;
            m_ButtonsArrow.Text = "-->>";
            m_ButtonsArrow.Enabled = false;
            m_ButtonsArrow.Click += ButtonsArrowClick;
            InitializeCowsAndBullPanel();
        }

        private void InitializeCowsAndBullPanel()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Panel panel = new Panel();
                    panel.BackColor = Color.White;
                    panel.Location = new Point(m_StartColumnOfCowsAndBullPanel + i * m_JumpPixelOfCowsAndBull, m_StartRow + j * m_JumpPixelOfCowsAndBull);
                    panel.Name = m_Index.ToString();
                    m_Index++;
                    panel.Size = new Size(29, 29);
                    m_CowsAndBullPanelList.Add(panel);
                }
            }
        }

        private void ButtonGuessesClick(object sender, EventArgs e)
        {
            m_ColorsWindow.ShowDialog();
            Button clickedButton = (Button)sender;
            m_ButtonsGuessesList[m_ButtonsGuessesList.IndexOf(clickedButton)].BackColor = m_ColorsWindow.SelectedColor;
            m_PaintedButtonCounter++;
            if (m_PaintedButtonCounter >= 4)
            {
                m_ButtonsArrow.Enabled = true;
            }
        }
        private void ButtonsArrowClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            foreach(Button button in m_ButtonsGuessesList) 
            {
                button.Enabled = false;
            }
            m_ButtonsArrow.Enabled = false;
            CheckColors();
            m_CounterCompleteLine++;
            if(m_CounterCompleteLine == m_SumRows)
            {
                ColoringComplete?.Invoke(this, EventArgs.Empty);
            }
            ColoringLineOfButtons?.Invoke(this, EventArgs.Empty);
        }

        private void CheckColors()
        {
            int counterBoll = 0;
            for (int i = 0; i < m_ButtonsGuessesList.Count; i++)
            {
                for (int j = 0; j < m_SelectedColors.Count; j++)
                {
                    if (m_ButtonsGuessesList.ElementAt(i).BackColor == m_SelectedColors.ElementAt(j) && i == j)
                    {
                        m_CowsAndBullPanelList.ElementAt(i).BackColor = Color.Black;
                        counterBoll++;
                    }
                    else if(m_ButtonsGuessesList.ElementAt(i).BackColor == m_SelectedColors.ElementAt(j) && i != j)
                    {
                        m_CowsAndBullPanelList.ElementAt(i).BackColor = Color.Yellow;
                    }
                }
            }
            if(counterBoll == m_ButtonsGuessesList.Count)
            {
                AllButtonsTrue?.Invoke(this, EventArgs.Empty);
            }

        }
        public void EnableButtons()
        {
            foreach(Button button in m_ButtonsGuessesList)
            {
                button.Enabled = true; 
            }
        }

        public List<Button> ButtonsGuessesList => m_ButtonsGuessesList;
        public Button ButtonsArrow => m_ButtonsArrow;
        public List<Panel> CowsAndBullPanelList => m_CowsAndBullPanelList;
    }
}
