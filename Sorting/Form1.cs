using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sorting
{
     public partial class Form1 : Form
    {

        int loopCounter;
        int comparisonCounter;
        int shiftCounter;
        int[] selectionSort = new int[8];
        int[] bubbleSort = new int[8];
        int[] insertionSort = new int[8];

        Random rando = new Random();
        int numberONE, numberTWO, numberTHREE, numberFOUR, numberFIVE, numberSIX, numberSEVEN, numberEIGHT;



        public Form1()
        {
            InitializeComponent();


            numberONE = rando.Next(-1000, 1000);
            numberTWO = rando.Next(-1000, 1000);
            numberTHREE = rando.Next(-1000, 1000);
            numberFOUR = rando.Next(-1000, 1000);
            numberFIVE = rando.Next(-1000, 1000);
            numberSIX = rando.Next(-1000, 1000);
            numberSEVEN = rando.Next(-1000, 1000);
            numberEIGHT = rando.Next(-1000, 1000);

            int[] originalArray = { numberONE, numberTWO, numberTHREE, numberFOUR, numberFIVE, numberSIX, numberSEVEN, numberEIGHT };

            originalArray.CopyTo(selectionSort, 0);
            originalArray.CopyTo(bubbleSort, 0);
            originalArray.CopyTo(insertionSort, 0);

            

            bubble(bubbleSort);
            loopCounter = 0;
            comparisonCounter = 0;
            shiftCounter = 0;

            selection(selectionSort);
            loopCounter = 0;
            comparisonCounter = 0;
            shiftCounter = 0;

            insertion(insertionSort);

            ogLabel.Text = selLabel.Text = "";

            foreach (int i in originalArray)
            {
                ogLabel.Text += i + ", ";
            }

            foreach (int i in selectionSort)
            {
                selLabel.Text += i + ", ";
            }
            foreach (int i in bubbleSort)
            {
                bubLabel.Text += i + ", ";
            }
            foreach (int i in insertionSort)
            {
                insLabel.Text += i + ", ";
            }
        }
        public void selection(int[] tempArray)
        {
            int temp;

            //starting stopwatch
            Stopwatch myWatch = new Stopwatch();
            myWatch.Start();

            for (int i = 0; i < tempArray.Length; i++)
            {
                loopCounter++;

                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    comparisonCounter++;
                    if (tempArray[j] < tempArray[i])
                    {
                        shiftCounter++;
                        temp = tempArray[i];
                        tempArray[i] = tempArray[j];
                        tempArray[j] = temp;
                    }
                }
            }
            //ending stopwatch
            myWatch.Stop();
            TimeSpan ts = myWatch.Elapsed;
            string elapsedTime = Convert.ToString(ts.TotalMilliseconds);

            selectionShiftOutputLabel.Text = Convert.ToString(shiftCounter);
            selectionLoopOutputLabel.Text = Convert.ToString(loopCounter);
            selectionComparisonOutputLabel.Text = Convert.ToString(comparisonCounter);
            selectionTimerOutput.Text = elapsedTime;
        }


        public void insertion(int[] tempArray)
        {
            int temp, j;

            //starting stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int n = 0; n < tempArray.Length; n++)
            {
                loopCounter++;

                temp = tempArray[n];
                j = n - 1;
                comparisonCounter++;

                while (j >= 0 && tempArray[j] > temp)
                {
                    shiftCounter++;

                    tempArray[j + 1] = tempArray[j];
                    j--;
                }

                tempArray[j + 1] = temp;
            }
            //ending stopwatch
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = Convert.ToString(ts.TotalMilliseconds);

            insertionShiftOutputLabel.Text = Convert.ToString(shiftCounter);
            insertionLoopOutputLabel.Text = Convert.ToString(loopCounter);
            insertionComparisonOutputLabel.Text = Convert.ToString(comparisonCounter);
            insertionTimerOutput.Text = elapsedTime;
        }

        private void lineLabel_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Times New Roman", 18);
            Brush brush = new SolidBrush(Color.Black);
            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString("______________________________", font, brush, 0, 0);
        }



        public void bubble(int[] tempArray)
        {
            int bottom = tempArray.Length - 1;
            int temp;
            Boolean sw = true;

            //starting stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (sw == true)
            {
                sw = false;
                loopCounter++;

                for (int j = 0; j < bottom; j++)
                {
                    comparisonCounter++;
                    if (tempArray[j] > tempArray[j + 1])
                    {
                        shiftCounter++;
                        sw = true;
                        temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                    }
                }
                bottom--;
            }
            //ending stopwatch
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = Convert.ToString(ts.TotalMilliseconds);

            bubbleShiftOutputLabel.Text = Convert.ToString(shiftCounter);
            bubbleLoopOutputLabel.Text = Convert.ToString(loopCounter);
            bubbleComparisonOutputLabel.Text = Convert.ToString(comparisonCounter);
            bubbleTimerOutput.Text = elapsedTime;
        }
    }
}
