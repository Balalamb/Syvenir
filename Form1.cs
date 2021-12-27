using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using OfficeOpenXml;
using System.IO;
using System.Reflection;

namespace Syvenir
{
    public partial class Form1 : Form
    {
        int startMounth = 9;
        //Dictionary<int, int> mounthLessions = new Dictionary<int, int>();
        List<int> mounthLessions2 = new List<int>();
        //дни недели (чекбоксы)
        List<string> chekedDays = new List<string>();
        DataGridViewColumn gridViewColumn = new DataGridViewColumn();
        string XMLfileName;
        List<string> daysHolydays1 = new List<string>();
        List<string> daysHolydays2 = new List<string>();
        //всего доступных учебных часов
        int AllHour = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillLv();
           //выгрузка XML
            btn1.Click += Btn1_Click;
            
            btn2.Click += DayWork;
            btnAddKalendar1.Click += AddCalendar;
            btnAddKalendar2.Click += AddCalendar;
            bntScore.Click += score;
            btnLoadXLS.Click += loadXls;
            loadXML();

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            string path= "c:\\";
            /*using (FolderBrowserDialog dialog =new FolderBrowserDialog())
            {
                dialog.Description = "Выбор директории для сохранения файла";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                }
                
            }*/
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "XLS Files (*.xls)|*.xlsx";
                saveFileDialog.RestoreDirectory = true;
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    FileInfo fi = new FileInfo(path);
                    ExcelPackage pck = new ExcelPackage(fi);
                    if (pck.Workbook.Worksheets.Count > 0)
                    {
                        pck.Workbook.Worksheets.Delete("List1");
                    }
                    ExcelWorksheet excelWorksheet = pck.Workbook.Worksheets.Add("List1");
                    for (int r = 0; r <= dataGridView1.Rows.Count - 1; r++)
                    {
                        DataGridViewRow row = dataGridView1.Rows[r];
                        for (int c = 0; c <= row.Cells.Count - 1; c++)
                        {
                            excelWorksheet.Cells[r + 1, c + 1].Value = row.Cells[c].Value;
                        }
                    }

                    pck.Save();
                }
            }
            
           
        }

        void loadXls(object sender, EventArgs e)
        {
            string path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XLS Files (*.xls)|*.xlsx";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    FileInfo fi = new FileInfo(path);
                    ExcelPackage pck = new ExcelPackage(fi);
                    ExcelWorksheet excelWorksheet = pck.Workbook.Worksheets[0];
                    for (int r = 0; r <= dataGridView1.Rows.Count - 1; r++)
                    {
                        for (int c = 1; c <= dataGridView1.Columns.Count - 1; c++)
                        {
                            dataGridView1.Rows[r].Cells[c].Value = excelWorksheet.Cells[r + 1, c + 1].Value;
                        }
                    }
                }
            }
            
        }

        private void AddCalendar(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "XML Files (*.xml)|*.xml";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XMLfileName = openFileDialog.FileName;
                }
            }
            XmlDocument xDoc = new XmlDocument();
            if (XMLfileName != null)
            {
                xDoc.Load(XMLfileName);
                XmlElement xRoot = xDoc.DocumentElement;
                XmlNode NodeDays = xRoot.ChildNodes[1];
                if ((sender as Button).Name == "btnAddKalendar1")
                {
                    int day = 0;
                    foreach (XmlNode childnode in NodeDays)
                    {
                        if (childnode.Name == "day")
                        {
                            string str = childnode.Attributes[0].InnerText.Remove(2);
                            int m = Int32.Parse(str);
                            if (m >= 9)
                            {
                                day++;
                                daysHolydays1.Add(childnode.Attributes[0].InnerText);
                            }
                        }
                    }
                    label1.Text = "В первом полугодии не рабочих дней - " + day;
                }
                else
                {
                    int day = 0;
                    foreach (XmlNode childnode in NodeDays)
                    {
                        if (childnode.Name == "day")
                        {
                            string str = childnode.Attributes[0].InnerText.Remove(2);
                            int m = Int32.Parse(str);
                            if (m <= 5)
                            {
                                day++;
                                daysHolydays2.Add(childnode.Attributes[0].InnerText);
                            }
                        }
                    }
                    label2.Text = "Во втором полугодии не рабочих дней - " + day;
                }
            }
        }

        private void DayWork(object sender, EventArgs e)
        {
            label3.Visible = false;
            AllHour = 0;
            mounthLessions2.Clear();
            //mounthLessions.Clear();
            chekedDays.Clear();
            int year = Decimal.ToInt32(numericUpDown1.Value);
            int currentMounth = startMounth;
            //узнаю какие в дни учеба
            foreach ( CheckBox cntl in groupBox1.Controls) 
             {
                if (cntl.Checked)
                {
                    chekedDays.Add(cntl.Name);
                }
             }
            //первое полугодие
            for(int m = startMounth; m<=12; m++)
            {
                //Получаем сколько дней в месяце
                int DayInMounth = DateTime.DaysInMonth(year, currentMounth);
                int days = 0;
                //считаем рабочие дни
                for(int d=1; d<=DayInMounth; d++)
                {
                    DateTime dt = new DateTime(year, m, d);
                    DayOfWeek day = dt.DayOfWeek;
                    string findDay=chekedDays.Find(item=>item==day.ToString());
                    //тут из производственного календаря берем даты и выявняемся является рабочий день выходным
                    bool Holyday = false;
                    foreach (object o in daysHolydays1)
                    {
                        int strM= Int32.Parse((o as System.String).Substring(0, 2));
                        int strD = Int32.Parse((o as System.String).Substring(3));
                        if(dt.Day == strD & dt.Month == strM)
                        {
                            Holyday = true;
                        }
                    }
                    if (findDay != null & Holyday==false)
                    {
                        days++;
                    }
                    
                }
                //mounthLessions.Add(currentMounth, days * 2);
                mounthLessions2.Add(days * 2);
                currentMounth++;
            }

            //добавляю год
            year++;
            currentMounth = 1;
            //второе полугодие
            for (int m = 1; m <= 5; m++)
            {
                //Получаем сколько дней в месяце
                int DayInMounth = DateTime.DaysInMonth(year, currentMounth);
                int days = 0;
                //считаем рабочие дни
                for (int d = 1; d <= DayInMounth; d++)
                {
                    DateTime dt = new DateTime(year, m, d);
                    DayOfWeek day = dt.DayOfWeek;
                    string findDay = chekedDays.Find(item => item == day.ToString());
                    //тут из производственного календаря берем даты и выявняемся является рабочий день выходным
                    bool Holyday = false;
                    foreach (object o in daysHolydays2)
                    {
                        int strM = Int32.Parse((o as System.String).Substring(0, 2));
                        int strD = Int32.Parse((o as System.String).Substring(3));
                        if (dt.Day == strD & dt.Month == strM)
                        {
                            Holyday = true;
                        }
                    }
                    if (findDay != null & Holyday == false)
                    {
                        days++;
                    }
                }
                //mounthLessions.Add(currentMounth, days * 2);
                mounthLessions2.Add(days * 2);
                currentMounth++;
            }
            

            //учебных часов в месяц
            int c = 3;
            
           
            foreach (int kvp in mounthLessions2)
            {
                dataGridView1.Rows[13].Cells[c++].Value = kvp;
                AllHour = AllHour + kvp;
            }
            label4.Text = AllHour.ToString();
            dataGridView1.Rows[13].Cells[2].Value =AllHour;
            
            if (chekNulls())
            {
                calculation();
            }
            else
            {
                MessageBox.Show("Не заполнены часы");
            }
        }

        void calculation()
        {
            clearTable();
            //mounthLessions
            List<int> Themes = new List<int>();
            //осталось распределить внути месяца
            int distributeTheRest;
            //остаток распределения на начало месяца
            int remainder = 0;

            for (int i = 0; i <= 12; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (row.Cells[2].Value != null)//& int.TryParse(row.Cells[1].Value.ToString(), out int number)
                {
                    int hours = Int32.Parse(row.Cells[2].Value.ToString());
                    Themes.Add(hours);
                }
            }
            
            if ( 6== Themes.Last() & !cb1Year.Checked) //& 2== Themes.Last()-1
            {
                //переменная, чтобы точно записать часы культуры
                int indxlast = Themes.Count - 1;
                Themes.RemoveAt(Themes.Count - 1);
                Themes.RemoveAt(Themes.Count - 1);
                List<int> tempMounthLessions = mounthLessions2;
                tempMounthLessions[4] = tempMounthLessions[4] - 2;
                tempMounthLessions[5] = tempMounthLessions[5] - 2;
                tempMounthLessions[6] = tempMounthLessions[6] - 2;
                //для итогового занятия
                tempMounthLessions[7] = tempMounthLessions[7] - 2;
                int lastNdxCell;
                int lastNdxRow=0;
                for (int m = 0; m <= tempMounthLessions.Count - 1; m++)
                    {
                        for (int i = 0; i <= Themes.Count - 1; i++)
                        {

                            distributeTheRest = tempMounthLessions[m] - Themes[i];

                            DataGridViewRow row = dataGridView1.Rows[i];
                            lastNdxRow = i;
                            if (distributeTheRest <= 0)
                            {
                                if (tempMounthLessions[m] != 0) row.Cells[3 + m].Value = tempMounthLessions[m];
                                remainder = Themes[i] - tempMounthLessions[m];
                                Themes[i] = remainder;
                                lastNdxCell = 3 + m;
                                break;
                            }
                            else
                            {
                                if (Themes[i] != 0) row.Cells[3 + m].Value = Themes[i];
                                tempMounthLessions[m] = tempMounthLessions[m] - Themes[i];
                                Themes[i] = 0;

                            }

                        }

                    }
                dataGridView1.Rows[indxlast].Cells[7].Value = "2";
                dataGridView1.Rows[indxlast].Cells[8].Value = "2";
                dataGridView1.Rows[indxlast].Cells[9].Value = "2";
                dataGridView1.Rows[indxlast-1].Cells[10].Value = "2";
            }
            //Первый год обучения
            else if (6 == Themes.Last() & cb1Year.Checked)
            {
                //переменная, чтобы точно записать часы культуры
                int indxlast = Themes.Count - 1;
                Themes.RemoveAt(Themes.Count - 1);
                Themes.RemoveAt(Themes.Count - 1);
                List<int> tempMounthLessions = mounthLessions2;
                tempMounthLessions[0] = tempMounthLessions[0] - 2;
                tempMounthLessions[5] = tempMounthLessions[5] - 2;
                tempMounthLessions[6] = tempMounthLessions[6] - 2;
                //для итогового занятия
                tempMounthLessions[7] = tempMounthLessions[7] - 2;
                int lastNdxCell;
                int lastNdxRow = 0;
                for (int m = 0; m <= tempMounthLessions.Count - 1; m++)
                {
                    for (int i = 0; i <= Themes.Count - 1; i++)
                    {

                        distributeTheRest = tempMounthLessions[m] - Themes[i];

                        DataGridViewRow row = dataGridView1.Rows[i];
                        lastNdxRow = i;
                        if (distributeTheRest <= 0)
                        {
                            if (tempMounthLessions[m] != 0) row.Cells[3 + m].Value = tempMounthLessions[m];
                            remainder = Themes[i] - tempMounthLessions[m];
                            Themes[i] = remainder;
                            lastNdxCell = 3 + m;
                            break;
                        }
                        else
                        {
                            if (Themes[i] != 0) row.Cells[3 + m].Value = Themes[i];
                            tempMounthLessions[m] = tempMounthLessions[m] - Themes[i];
                            Themes[i] = 0;

                        }

                    }

                }
                dataGridView1.Rows[indxlast].Cells[3].Value = "2";
                dataGridView1.Rows[indxlast].Cells[8].Value = "2";
                dataGridView1.Rows[indxlast].Cells[9].Value = "2";
                dataGridView1.Rows[indxlast - 1].Cells[10].Value = "2";
            }
            else
            {
                for (int m = 0; m <= mounthLessions2.Count - 1; m++)
                {
                    for (int i = 0; i <= Themes.Count - 1; i++)
                    {

                        distributeTheRest = mounthLessions2[m] - Themes[i];

                        DataGridViewRow row = dataGridView1.Rows[i];

                        if (distributeTheRest <= 0)
                        {
                            if (mounthLessions2[m] != 0) row.Cells[3 + m].Value = mounthLessions2[m];
                            remainder = Themes[i] - mounthLessions2[m];
                            Themes[i] = remainder;
                            //lastNdxCell = 3 + m;
                            break;
                        }
                        else
                        {
                            if (Themes[i] != 0) row.Cells[3 + m].Value = Themes[i];
                            mounthLessions2[m] = mounthLessions2[m] - Themes[i];
                            Themes[i] = 0;

                        }

                    }
                }
            }
            
            score();

        }

        void clearTable()
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 3; i <= row.Cells.Count-1; i++)
                {
                    row.Cells[i].Value = "";
                }
            }
            
        }

        void score(object sender, EventArgs e)
        {
            //считаю итоги

            //<<<---по строкам горизонтально
            int[] RowsAllHour = new int[dataGridView1.Rows.Count];
            //наполняю массив пересчитанным часами по колонке "Всего часов"
            for (int strN = 0; strN <= 12; strN++)
            {
                DataGridViewRow row = dataGridView1.Rows[strN];
                for (int i = 3; i <= 11; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        if (int.TryParse(row.Cells[i].Value.ToString(), out int Num))
                        {
                            RowsAllHour[strN] = RowsAllHour[strN] + Num;
                        }
                    }

                }
            }
            for (int i = 0; i <= 11; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value != null)
                {
                    //если ячейка число
                    if (int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out int Num))
                    {
                        //если число ячейки не равно пересчитанной сумме
                        if (Num != RowsAllHour[i])
                        {
                            dataGridView1.Rows[i].Cells[2].ToolTipText = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            dataGridView1.Rows[i].Cells[2].Value = RowsAllHour[i];
                            dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[2].ToolTipText = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.White;
                        }
                    }
                }
            }
            //по строкам горизонтально--->>>

            //<<<--по нижней строке 
            int[] score = new int[10];
            for (int m = 0; m <= dataGridView1.Rows.Count - 2; m++)
            {
                DataGridViewRow row = dataGridView1.Rows[m];
                for (int i = 2; i <= row.Cells.Count - 1; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        if (int.TryParse(row.Cells[i].Value.ToString(), out int Num))
                        {
                            score[i - 2] = score[i - 2] + Num;
                        }
                    }
                }
            }
            //заполняю нижнюю строку
            DataGridViewRow rowScore = dataGridView1.Rows[13];
            for (int i = 2; i <= rowScore.Cells.Count - 1; i++)
            {
                if (rowScore.Cells[i].Value != null)
                {
                    if (int.TryParse(rowScore.Cells[i].Value.ToString(), out int Num))
                    {
                        //если число ячейки не равно пересчитанной сумме
                        if (Num != score[i - 2])
                        {
                            rowScore.Cells[i].ToolTipText = rowScore.Cells[i].Value.ToString();
                            rowScore.Cells[i].Value = score[i - 2];
                            rowScore.Cells[i].Style.BackColor = Color.LightGreen;

                        }
                        else
                        {
                            rowScore.Cells[i].ToolTipText = rowScore.Cells[i].Value.ToString();
                            rowScore.Cells[i].Style.BackColor = Color.White;
                        }
                    }
                    else
                    {
                        rowScore.Cells[i].ToolTipText = (score[i - 2]).ToString();
                        rowScore.Cells[i].Value = score[i - 2];
                    }
                }
            }
            if (rowScore.Cells[2].Value != null)
            {
                if (Int32.Parse(rowScore.Cells[2].Value.ToString()) > AllHour & AllHour != 0)
                {
                    label3.Visible = true;
                    label3.ForeColor = Color.Red;
                    label3.Text = "Часов не поместившихся в учебный год " + (Int32.Parse(rowScore.Cells[2].Value.ToString()) - AllHour);
                }
            }
        }
        void score()
        {
            //считаю итоги
           
            //<<<---по строкам горизонтально
            int[] RowsAllHour = new int[dataGridView1.Rows.Count];
            //наполняю массив пересчитанным часами по колонке "Всего часов"
            for (int strN=0; strN <=12; strN++)
            {
                DataGridViewRow row = dataGridView1.Rows[strN];
                for(int i = 3; i <= 11; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        if (int.TryParse(row.Cells[i].Value.ToString(), out int Num))
                        {
                            RowsAllHour[strN] = RowsAllHour[strN] + Num;
                        }
                    }

                }
            }
            for(int i =0; i<=11; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value != null)
                {
                    //если ячейка число
                    if (int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out int Num))
                    {
                        //если число ячейки не равно пересчитанной сумме
                        if (Num != RowsAllHour[i])
                        {
                            dataGridView1.Rows[i].Cells[2].ToolTipText = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            dataGridView1.Rows[i].Cells[2].Value = RowsAllHour[i];
                            dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[2].ToolTipText = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.White;
                        }
                    }
                }
            }
            //по строкам горизонтально--->>>

            //<<<--по нижней строке 
            int[] score = new int[10];
            for (int m = 0; m <= dataGridView1.Rows.Count - 2; m++)
            {
                DataGridViewRow row = dataGridView1.Rows[m];
                for (int i = 2; i <= row.Cells.Count - 1; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        if (int.TryParse(row.Cells[i].Value.ToString(), out int Num))
                        {
                            score[i - 2] = score[i - 2] + Num;
                        }
                    }
                }
            }
            //заполняю нижнюю строку
            DataGridViewRow rowScore = dataGridView1.Rows[13];
            for (int i = 2; i <= rowScore.Cells.Count - 1; i++)
            {
                if (int.TryParse(rowScore.Cells[i].Value.ToString(), out int Num))
                {
                    //если число ячейки не равно пересчитанной сумме
                    if (Num != score[i - 2])
                    {
                        rowScore.Cells[i].ToolTipText = rowScore.Cells[i].Value.ToString();
                        rowScore.Cells[i].Value = score[i - 2];
                        rowScore.Cells[i].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        rowScore.Cells[i].ToolTipText = rowScore.Cells[i].Value.ToString();
                        rowScore.Cells[i].Style.BackColor = Color.White;
                    }
                }
                //если заполняется первый раз
                else
                {
                    rowScore.Cells[i].ToolTipText = (score[i - 2]).ToString();
                    rowScore.Cells[i].Value = score[i - 2];
                }
            }
            //по нижней строке--->>>

            if (Int32.Parse(rowScore.Cells[2].Value.ToString()) > AllHour )
            {
                label3.Visible = true;
                label3.ForeColor = Color.Red;
                label3.Text = "Часов не поместившихся в учебный год " + (Int32.Parse(rowScore.Cells[2].Value.ToString())-AllHour);
            }
        }

        void FillLv()
        {

            DataGridViewColumn data = new DataGridViewColumn();
            data.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "Number", HeaderText = "№", CellTemplate = new DataGridViewTextBoxCell(), Width = 25 });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "NameTheme", HeaderText = "", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "All", HeaderText = "Всего Часов", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m1", HeaderText = "Сентябрь", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m2", HeaderText = "Октябрь", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m2", HeaderText = "Ноябрь", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m2", HeaderText = "Декабрь", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m2", HeaderText = "Январь", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m2", HeaderText = "Февраль", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m2", HeaderText = "Март", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m2", HeaderText = "Апрель", CellTemplate = new DataGridViewTextBoxCell() });
            dataGridView1.Columns.Add(new DataGridViewColumn { Name = "m2", HeaderText = "Май", CellTemplate = new DataGridViewTextBoxCell() });
            for (int i = 1; i <= 13; i++)
            {
                dataGridView1.Rows.Add(i.ToString());
            }

        }


        void loadXML()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
           
            string str1 = "calendar1.xml";
            string str2 = "calendar2.xml";
            XmlDocument xDoc = new XmlDocument();
            //xDoc.Load(XMLfileName);
            
            foreach (string file in files)
            {
                int indexOfChar = file.LastIndexOf('\\');
                
                if (str1 == file.Substring(indexOfChar + 1))
                {
                    xDoc.Load(file);
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlNode NodeDays = xRoot.ChildNodes[1];
                    int day = 0;
                    foreach (XmlNode childnode in NodeDays)
                    {
                        if (childnode.Name == "day")
                        {
                            string str = childnode.Attributes[0].InnerText.Remove(2);
                            int m = Int32.Parse(str);
                            if (m >= 9)
                            {
                                day++;
                                daysHolydays1.Add(childnode.Attributes[0].InnerText);
                            }
                        }
                    }
                    label1.Text = "В первом полугодии не рабочих дней - " + day;
                                        
                 }
                
                if (str2 == file.Substring(indexOfChar + 1))
                {
                    xDoc.Load(file);
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlNode NodeDays = xRoot.ChildNodes[1];
                    int day = 0;
                    foreach (XmlNode childnode in NodeDays)
                    {
                        if (childnode.Name == "day")
                        {
                            string str = childnode.Attributes[0].InnerText.Remove(2);
                            int m = Int32.Parse(str);
                            if (m <= 5)
                            {
                                day++;
                                daysHolydays2.Add(childnode.Attributes[0].InnerText);
                            }
                        }
                    }
                    label2.Text = "Во втором полугодии не рабочих дней - " + day;
                }
            }

         }

        bool chekNulls()
        {
            bool hasInt = false;
            for (int i = 0; i <= 12; i++)
            {
                
                DataGridViewRow row = dataGridView1.Rows[i];
                if (row.Cells[2].Value != null)//& int.TryParse(row.Cells[1].Value, out int number)
                {
                    if (row.Cells[2].Value != null)
                    {
                        hasInt = int.TryParse(row.Cells[2].Value.ToString(), out int number);
                        if (hasInt)
                        {
                            break;
                        }
                    }
                }
            }
            return hasInt;
        }

        
    }
}
