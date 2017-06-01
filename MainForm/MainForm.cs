using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FireflyAlgorithm;

namespace MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Cities = new List<City>();
            Translated_Points = new List<PointF>();
            Solution = new List<City>();
            indexes = new List<int>();
            this.checkBox.Checked = true;
        }
        
        
        List<PointF> Translated_Points; //Список с точками для отрисовки
        bool points_flag = false; //Показывает наличие точек
        bool opened_flag = false; //Показывает, был ли открыт файл
        int xMax, xMin, yMax, yMin; //Размеры MyPictureBox
        int XMax, YMax, XMin, YMin; //Минимальные и максимальные значения в координатах

        List<City> Solution; //Найденный тур
        Fireflies firefly;
        List<City> Cities; //Список городов TSP
        List<int> indexes; //Список с оптимальным туром (берется из файла)
        int n = 1;
        int length;
        string path = string.Empty;
        string name_of_tsp = string.Empty; //Название TSP
        string[] comments = new string[3]; //Массив комментариев к TSP
        int session_sum = 0; //Сумма всех путей за сеанс, используется при подсчете среднего значения
        int session_n = 0; //Количество запусков поиска за сеанс
        int session_min=int.MaxValue; //Минимальный путь за сеанс
        int session_optimal=-1; //Длина оптимального пути (берется из файла)
        Stopwatch timeCounter; //Таймер

        /// <summary>
        /// Обработчик события, возникающего при конце итерации цикла алгоритма
        /// Отвечает за увеличение значения в progressBar
        /// </summary>
        public void OnIterationPassed(object source, EventArgs e)
        {

            Invoke((MethodInvoker)(() => { this.progressBar.Increment(+1); }));
        }

        #region Opening and Saving data
        
        /// <summary>
        /// Обработчик события, возникающего при нажатии кнопки открытия .tsp файла
        /// </summary>
        private void Open_File_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {

                        Invoke((MethodInvoker)(() => {
                            ClearData();
                            ControlElements(false);
                        }));

                        string myfile = openFileDialog.FileName;
                        string[] strings = File.ReadAllLines(myfile);
                        string[] name = strings[0].Split(':');
                        name_of_tsp = name[1].Trim(' ');
                        string[] cm = strings[1].Split(':');
                        comments[0] = cm[1].Trim(' ');
                        cm = strings[2].Split(':');
                        comments[1] = cm[1].Trim(' ');
                        cm = strings[3].Split(':');
                        comments[2] = cm[1].Trim(' ');

                        for (int i = 8; i < strings.Length - 1; i++)
                        {
                            string[] str = strings[i].Split(' ');
                            int x = int.Parse(str[1]);
                            int y = int.Parse(str[2]);
                            Cities.Add(new City(x, y, n));
                            n++;
                        }

                        opened_flag = true;

                        Translated_Points = TranslatePoints(Cities);
                        MyPictureBox.Cities = Translated_Points;
                        MyPictureBox.Invalidate();
                        Invoke((MethodInvoker)(() => {
                           
                            ControlElements(true);
                            FillTSPData(true);
                        }));
                        points_flag = true;
                        session_sum = 0;
                        session_n = 0;
                    }
                    catch (Exception ex)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            MessageBox.Show(ex.Message + "\nОшибка могла возникнуть из-за некорректных исходных данных.\nПопробуйте открыть другой файл.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            ControlElements(true);
                        }));
                    }
                });
            }
        }
        
        /// <summary>
        /// Обработчик события, возникающего при нажатии кнопки сохранения найденного тура
        /// Вызывает saveFileDialog1
        /// </summary>
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != string.Empty)
            {
                saveFileDialog1.Filter = "TSP Files|*.tsp";
                saveFileDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Нечего сохранять!\nНайдите маршрут для сохранения!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        
        /// <summary>
        /// Сохранение найденного тура через saveFileDialog1
        /// </summary>
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string res_place = saveFileDialog1.FileName;
            if (res_place != string.Empty)
            {
                StreamWriter streamOut = new StreamWriter(res_place, false, Encoding.Default);
                if (name_of_tsp == string.Empty)
                {
                    name_of_tsp = "MyTSP_" + (Solution.Count - 1).ToString();
                }
                string[] heading = new string[5];
                heading[0] = "NAME: " + name_of_tsp; streamOut.WriteLine(heading[0]);
                heading[1] = "COMMENT: Tour length " + length.ToString(); streamOut.WriteLine(heading[1]);
                heading[2] = "TYPE: TOUR"; streamOut.WriteLine(heading[2]);
                heading[3] = "DIMENSION: " + (Solution.Count - 1).ToString(); streamOut.WriteLine(heading[3]);
                heading[4] = "TOUR_SECTION"; streamOut.WriteLine(heading[4]);
                string[] strarr = path.Split('-', '>');
                foreach (string s in strarr)
                    if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
                        streamOut.WriteLine(s);
                streamOut.WriteLine("EOF");
                streamOut.Close();
            }
        }
        
        /// <summary>
        /// Обработчик события, возникающего при нажатии кнопки открытия оптимального маршрута из файла
        /// </summary>
        private void Open_Optimal_Click(object sender, EventArgs e)
        {
            if (!points_flag)
            {
                MessageBox.Show("Отсутствуют точки! Для открытия оптимального пути необходимо их наличие.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string myfile = openFileDialog.FileName;
                    string[] strings = File.ReadAllLines(myfile);
                    string[] name = strings[0].Split(':');
                    string name_of_opt = name[1].Trim(' ');
                    //parse optimal into session_optimal
                    string[] len = strings[1].Split(':');
                    string[] temp = len[1].Trim(' ').Split(' ');
                    string t = temp[temp.Length - 1];

                    if (!name_of_opt.Equals(name_of_tsp))
                    {
                        MessageBox.Show("Данные в файлах различны!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    for (int i = 5; i < strings.Length - 1; i++)
                    {
                        int ind = int.Parse(strings[i]);
                        if (ind < 0) ind = ind * -1;
                        indexes.Add(ind);
                    }
                    session_optimal = int.Parse(t);
                    MyPictureBox.optimal_indexes = indexes;
                    MyPictureBox.Invalidate();
                    FillTSPData(true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nОшибка могла возникнуть из-за некорректных исходных данных.\nПопробуйте открыть другой файл.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }
        
        /// <summary>
        /// Обработчик события, возникающего при нажатии кнопки сохранения TSP
        /// Вызывает saveFileDialog2
        /// </summary>
        private void SaveTSPdata_Click(object sender, EventArgs e)
        {
            if (points_flag)
            {
                DialogResult r = MessageBox.Show("Хотите изменить или добавить информацию о текущем TSP перед сохранением?",
                "TSP Info", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (r == DialogResult.Yes) ShowTSPData();
                saveFileDialog2.Filter = "TSP Files|*.tsp";
                saveFileDialog2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Нечего сохранять!\nДля сохранения TSP файла нужны точки!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        
        /// <summary>
        /// Сохранение TSP через saveFileDialog2
        /// </summary>
        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string res_place = saveFileDialog2.FileName;
            if (res_place != string.Empty)
            {
                StreamWriter streamOut = new StreamWriter(res_place, false, Encoding.Default);
                if (name_of_tsp == string.Empty)
                {
                    name_of_tsp = "MyTSP_" + (Cities.Count).ToString();
                }
                else
                {
                    name_of_tsp += "_" + (Cities.Count).ToString();
                }
                string[] heading = new string[8];
                heading[0] = "NAME : " + name_of_tsp;
                heading[1] = "COMMENT : " + comments[0];
                heading[2] = "COMMENT : " + comments[1];
                heading[3] = "COMMENT : " + comments[2];
                heading[4] = "TYPE : TSP";
                heading[5] = "DIMENSION : " + (Cities.Count).ToString();
                heading[6] = "EDGE_WEIGHT_TYPE : EUC_2D";
                heading[7] = "NODE_COORD_SECTION";
                for (int i = 0; i < 8; i++) streamOut.WriteLine(heading[i]);
                for (int i = 0; i < Cities.Count; i++)
                {
                    string str = (i + 1).ToString() + " " + Cities[i].x.ToString() + " " + Cities[i].y.ToString();
                    streamOut.WriteLine(str);
                }
                streamOut.WriteLine("EOF");
                streamOut.Close();
            }
        }
        #endregion

        #region ToolStrip and Settings events
        
        /// <summary>
        /// Обработчик события, возникающего при нажатии кнопки поиска тура
        /// </summary>
        private void find_btn_Click(object sender, EventArgs e)
        {
            if (Cities.Count > 2)
            {
                Task.Factory.StartNew(() =>
                {
                    Invoke((MethodInvoker)(() => {
                        progressBar.Visible = true;
                        progressBar.Value = 0;
                        ControlElements(false);
                    }));
                    timeCounter = new Stopwatch();

                    if (Solution.Count <= Cities.Count) Solution.Clear();
                    if (Solution.Count > 0)
                    {
                        Solution.RemoveAt(Solution.Count - 1);
                    }

                    firefly = new Fireflies(Solution);
                    firefly.IterationPassed += OnIterationPassed;

                    timeCounter.Start();
                    Solution = firefly.start(Cities);
                    timeCounter.Stop();

                    string ellapsedTime = (timeCounter.ElapsedMilliseconds / 1000) + "." + (timeCounter.ElapsedMilliseconds % 1000) +
                    " s";
                    int cost = SinglePathCost(Solution); //Also adds the first point to the end (makes a cycle from our path)
                    session_sum += cost;
                    session_n++;
                    MyPictureBox.Solution = Solution;
                    MyPictureBox.Invalidate();
                    length = cost;
                    if (length < session_min) session_min = length;
                    Invoke((MethodInvoker)(() => {
                        length_label.Text = "Длина пути: " + cost.ToString();
                        time_label.Text = "Время: " + ellapsedTime;
                        FillTSPData(true);
                    }));

                    path = string.Empty;
                    foreach (City c in Solution)
                    {
                        path += c.index.ToString() + "->";
                    }
                    path = path.TrimEnd('>', '-');

                    Invoke((MethodInvoker)(() => {
                        richTextBox.Text = path;
                        progressBar.Visible = false;
                        ControlElements(true);
                    }));
                });
            }
            else
            {
                MessageBox.Show("Для нахождения пути необходимо хотя бы три точки!",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }
        
        /// <summary>
        /// Обработчик события, возникающего при нажатии кнопки очищения поля
        /// </summary>
        private void del_btn_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        
        /// <summary>
        /// Обработчик события, возникающего при нажатии кнопки "О программе"
        /// </summary>
        private void Info_btn_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Автор программы:\nРоговец Мирон Алексеевич.\nСтудент 1 курса Программной Инженерии\nФКН НИУ ВШЭ.\n2016 год",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        
        /// <summary>
        /// Обработчик события, возникаюзего при нажатии кнопки просмотра найденного тура
        /// Вызывает окно, где отображается тур
        /// </summary>
        private void EnlargePath_Click(object sender, EventArgs e)
        {

            if (path != string.Empty)
            {
                InfoForm inf = new InfoForm(path);
                inf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Нет пути. Возможно, вы еще не нашли его.", "Найденный путь",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        
        /// <summary>
        /// Обработчик события, возникающего при нажатии кнопки редактирования данных TSP
        /// Вызывает второе окно, где отображается информация для просмотра и редактирования
        /// </summary>
        private void EditTSPdata_Click(object sender, EventArgs e)
        {
            if (points_flag)
            {
                ShowTSPData();
            }
            else
            {
                MessageBox.Show("Отсутствуют данные для TSP. Откройте файл или постройте точки вручную.",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }
        
        /// <summary>
        /// Обработчик события, возникающего при клике мышью по области рисования
        /// По клику рисуется точка
        /// В случае, когда работа идет с открытым файлом, ничего не происходит
        /// </summary>
        private void MyPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!opened_flag)
            {
                if (Check_Point(e.X, e.Y))
                {
                    Cities.Add(new City(e.X, e.Y, n));
                    Translated_Points.Add(new PointF(e.X, e.Y));
                    MyPictureBox.Cities = Translated_Points;
                    n++;
                    session_sum = 0;
                    session_n = 0;
                    session_min = int.MaxValue;
                    session_optimal = -1;
                    MyPictureBox.Invalidate();
                    FillTSPData(true);
                    if (!points_flag)
                    {
                        points_flag = true;
                    }
                }
            }
        }
        
        /// <summary>
        /// Обработчик события, возникающего при установке/снятии галочки в checkBox
        /// Отображает или скрывает область с дополнительной информацией
        /// </summary>
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox.Checked)
            {
                this.info_gb.Visible = true;
            }
            else this.info_gb.Visible = false;
        }
        #endregion

        #region Methods for showing and managing data
        
        /// <summary>
        /// Проверяет точку на уникальность
        /// Вызывается при клике мышью по области рисования для добавления точки
        /// </summary>
        /// <param name="x">Координата по X</param>
        /// <param name="y">Координата по Y</param>
        /// <returns>True в случе, когда точка уникальна и ее следует рисовать, и false в обратном случае</returns>
        bool Check_Point(int x, int y)
        {
            for (int i = 0; i < Cities.Count; i++)
            {
                if (x == Cities[i].x && y == Cities[i].y)
                {
                    return false;
                }
            }
            return true;
        }
        
        /// <summary>
        /// Возвращает полную длину получаемого тура
        /// </summary>
        /// <param name="path">запрашиваемый тур</param>
        /// <returns></returns>
        int SinglePathCost(List<City> path)
        {
            int sum = 0;
            path.Add(path[0]);
            for (int i = 0; i < path.Count - 1; i++)
            {
                sum += City.getDestination(path[i], path[i + 1]);
            }
            return sum;
        }
        
        /// <summary>
        /// Получает размеры MyPictureBox
        /// </summary>
        void pictureData()
        {
            xMax = MyPictureBox.ClientSize.Width - 10;
            yMax = MyPictureBox.ClientSize.Height - 10;
            xMin = 10;
            yMin = 10;
        }
        
        /// <summary>
        /// Метод контроля элементов формы
        /// Блокирует их, когда выполняются объемные вычисления, с целью предотвратить непредвиденные сбои в работе
        /// </summary>
        /// <param name="value">Значение, по которому элементы будут заблокированы или разблокированы</param>
        void ControlElements(bool value)
        {
            find_btn.Enabled = value;
            FindToolStripButton.Enabled = value;
            ClearToolStripButton.Enabled = value;
            del_btn.Enabled = value;
            EditTSPdata.Enabled = value;
            Open_File.Enabled = value;
            открытьToolStripButton.Enabled = value;
            SavePath.Enabled = value;
            сохранитьToolStripButton.Enabled = value;
        }
        
        /// <summary>
        /// Метод перевода координат точек из файла в координаты для отрисовки
        /// </summary>
        /// <param name="p">Список точек</param>
        /// <returns>Переведенный список</returns>
        List<PointF> TranslatePoints(List<City> p)
        {
            List<PointF> translated = new List<PointF>();
            XMax = maxX_search(p);
            XMin = minX_search(p);
            YMax = maxY_search(p);
            YMin = minY_search(p);
            pictureData();

            for (int i = 0; i < p.Count; i++)
            {
                float x0 = (float)(p[i].x - XMin) / (XMax - XMin) * xMax;
                float y0 = yMax - (float)(p[i].y - YMin) / (YMax - YMin) * yMax;
                translated.Add(new PointF(x0, y0));
            }

            return translated;
        }
        
        /// <summary>
        /// Метод открытия окна для отображения информации о TSP
        /// </summary>
        void ShowTSPData()
        {
            DataForm df = new DataForm();

            var txt1 = df.Controls["NameTxt"];
            var txt2 = df.Controls["CommentTxt_1"];
            var txt3 = df.Controls["CommentTxt_2"];
            var txt4 = df.Controls["CommentTxt_3"];
            var lbl = df.Controls["dim_label"];

            if (name_of_tsp != string.Empty)
            {
                txt1.Text = name_of_tsp;
                txt2.Text = comments[0];
                txt3.Text = comments[1];
                txt4.Text = comments[2];
                lbl.Text = "DIMENSION: " + (Cities.Count).ToString();
            }
            else
            {
                txt1.Text = "";
                txt2.Text = "";
                txt3.Text = "";
                txt4.Text = "";
                lbl.Text = "DIMENSION: " + (Cities.Count).ToString();
            }
            if (df.ShowDialog() == DialogResult.OK)
            {
                name_of_tsp = txt1.Text;
                comments[0] = txt2.Text;
                comments[1] = txt3.Text;
                comments[2] = txt4.Text;
            }
        }
        
        /// <summary>
        /// Метод заполнения дополнительно информации
        /// </summary>
        void FillTSPData(bool value)
        {
            if (value)
            {
                if (session_n > 0)
                {
                    nTxt.Text = session_n.ToString();
                    avTxt.Text = (session_sum * 1.0 / session_n).ToString("f2");
                    minTxt.Text = session_min.ToString();
                    if (session_optimal < 0)
                    {
                        optTxt.Text = "????";
                        accTxt.Text = "????";
                    }
                    else
                    {
                        optTxt.Text = session_optimal.ToString();
                        double acc = (session_optimal * 1.0 / session_min) * 100;
                        accTxt.Text = acc.ToString("f2") + "%";
                        if (acc > 90)
                        {
                            accTxt.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            if (acc > 80)
                            {
                                accTxt.BackColor = Color.GreenYellow;
                            }
                            else
                            {
                                if (acc > 60)
                                {
                                    accTxt.BackColor = Color.LightYellow;
                                }
                                else
                                {
                                    if (acc > 40)
                                    {
                                        accTxt.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        if (acc > 20)
                                        {
                                            accTxt.BackColor = Color.LightSalmon;
                                        }
                                        else
                                        {
                                            accTxt.BackColor = Color.Red;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    nTxt.Text = session_n.ToString();
                    avTxt.Text = "-----";
                    minTxt.Text = "-----";
                    optTxt.Text = "-----";
                    accTxt.Text = "-----";
                    accTxt.BackColor = Control.DefaultBackColor;
                }
            }
            else
            {
                nTxt.Clear();
                avTxt.Clear();
                minTxt.Clear();
                optTxt.Clear();
                accTxt.Clear();
                accTxt.BackColor = Control.DefaultBackColor;
            }

        }
        
        /// <summary>
        /// Метод очистки всей информации
        /// </summary>
        void ClearData()
        {
            points_flag = false;
            n = 1;
            opened_flag = false;
            richTextBox.Text = string.Empty;
            path = string.Empty;
            name_of_tsp = string.Empty;
            comments = new string[3];
            length_label.Text = "Длина пути: ";
            time_label.Text = "Время: ";
            session_n = 0;
            session_sum = 0;
            session_min = int.MaxValue;
            session_optimal = -1;
            Cities.Clear();
            Solution.Clear();
            indexes.Clear();
            Translated_Points.Clear();
            MyPictureBox.Invalidate();
            FillTSPData(false);
        }
        
        /// <summary>
        /// Поиск минимальной координаты по X для перевода точек
        /// </summary>
        /// <param name="p">Спиок, в котором осуществляется поиск</param>
        /// <returns></returns>
        int minX_search(List<City> p)
        {
            int min = p[0].x;
            for (int i = 1; i < p.Count; i++)
            {
                if (p[i].x < min) min = p[i].x;
            }
            return min;
        }
        
        /// <summary>
        /// Поиск минимальной координаты по Y для перевода точек
        /// </summary>
        /// <param name="p">Спиок, в котором осуществляется поиск</param>
        /// <returns></returns>
        int minY_search(List<City> p)
        {
            int min = p[0].y;
            for (int i = 1; i < p.Count; i++)
            {
                if (p[i].y < min) min = p[i].y;
            }
            return min;
        }
        
        /// <summary>
        /// Поиск максимальной координаты по X для перевода точек
        /// </summary>
        /// <param name="p">Спиок, в котором осуществляется поиск</param>
        /// <returns></returns>
        int maxX_search(List<City> p)
        {
            int max = p[0].x;
            for (int i = 1; i < p.Count; i++)
            {
                if (p[i].x > max) max = p[i].x;
            }
            return max;
        }
        
        /// <summary>
        /// Поиск максимальной координаты по Y для перевода точек
        /// </summary>
        /// <param name="p">Спиок, в котором осуществляется поиск</param>
        /// <returns></returns>
        int maxY_search(List<City> p)
        {
            int max = p[0].y;
            for (int i = 1; i < p.Count; i++)
            {
                if (p[i].y > max) max = p[i].y;
            }
            return max;
        }
        #endregion

    }
}
