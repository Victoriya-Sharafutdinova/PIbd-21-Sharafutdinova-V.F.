using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCars
{
    public partial class FormWharf : Form
    {
        MultiLevelWharf wharf;
        FormShipConfig form;
        private const int countLevel = 5;

        private Logger logger;

        public FormWharf()
        {
            InitializeComponent();

            logger = LogManager.GetCurrentClassLogger();

            wharf = new MultiLevelWharf(countLevel, pictureBoxWharf.Width, pictureBoxWharf.Height);
            for(int i = 0; i < countLevel; i++)
            {
                listBoxLevels.Items.Add("Уровень " + (i + 1));
            }
            listBoxLevels.SelectedIndex = 0;
        }

        private void Draw()
        {
            if(listBoxLevels.SelectedIndex > -1)
            {
                Bitmap bmp = new Bitmap(pictureBoxWharf.Width, pictureBoxWharf.Height);
                Graphics gr = Graphics.FromImage(bmp);
                wharf[listBoxLevels.SelectedIndex].Draw(gr);
                pictureBoxWharf.Image = bmp;
            }          
        }

        private void buttonSetShip_Click_1(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var ship = new Ship(100, 1000, dialog.Color, dialogDop.Color);
                        int place = wharf[listBoxLevels.SelectedIndex] + ship;
                        if (place == -1)
                        {
                            MessageBox.Show("Нет свободных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Draw();
                    }
                }
            }          
        }

        private void buttonSetSimpleShip_Click_1(object sender, EventArgs e)
        {
            if (listBoxLevels.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var ship = new SimpleShip(100, 1000, dialog.Color);
                    int place = wharf[listBoxLevels.SelectedIndex] + ship;
                    if(place == -1)
                    {
                        MessageBox.Show("Нет свободных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Draw();
                }
            }
        }
        private void buttonTakeShip_Click_1(object sender, EventArgs e)
        {
            if(listBoxLevels.SelectedIndex > -1)
            {
                if (maskedTextBox1.Text != "")
                {
                    try
                    {
                        var ship = wharf[listBoxLevels.SelectedIndex] - Convert.ToInt32(maskedTextBox1.Text);
                        Bitmap bmp = new Bitmap(pictureBoxTakeShip.Width, pictureBoxTakeShip.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        ship.SetPosition(5, 15, pictureBoxTakeShip.Width, pictureBoxTakeShip.Height);
                        ship.DrawShip(gr);
                        pictureBoxTakeShip.Image = bmp;

                        logger.Info("Изъят корабль " + ship.ToString() + " с места " + maskedTextBox1.Text);

                        Draw();
                    }
                    catch (WharfNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Bitmap bmp = new Bitmap(pictureBoxTakeShip.Width, pictureBoxTakeShip.Height);
                        pictureBoxTakeShip.Image = bmp;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }      
        }
        private void listBoxLevels_SelectedIndexChanged (object sender, EventArgs e)
        {
            Draw();
        }

        private void buttonSetShip_Click(object sender, EventArgs e)
        {
            form = new FormShipConfig();
            form.AddEvent(AddShip);
            form.Show();
        }
        private void AddShip(ITransport ship)
        {
            
            if (ship != null && listBoxLevels.SelectedIndex > -1)
            {
                try
                {
                    int place = wharf[listBoxLevels.SelectedIndex] + ship;
                    logger.Info("Добавлен корабль " + ship.ToString() + " на место " + place);
                    Draw();
                }
                catch (WharfOverflowException ex)
                {
                    MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ParkingAlreadyHaveException ex)
                {
                    MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    wharf.SaveData(saveFileDialog1.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    wharf.LoadData(openFileDialog1.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog1.FileName);
                }
                catch (WharfOccupiedPlaceException ex)
                {
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Draw();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wharf.Sort();
            Draw();
            logger.Info("Сортировка уровней");
        }
    }
}
