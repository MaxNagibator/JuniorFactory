using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace JuniorFactory.Lesson2
{
    public partial class Form1 : Form
    {
        private string _dataPath;
        private string _gameDataPath;
        private GameData _gameData;

        public Form1()
        {
            InitializeComponent();
            _dataPath = "E:\\bobgroup\\projects\\JuniorFactory\\JuniorFactory\\Data\\data.txt";
            _gameDataPath = "E:\\bobgroup\\projects\\JuniorFactory\\JuniorFactory\\Data";
        }

        private void uiReadButton_MouseClick(object sender, MouseEventArgs e)
        {
            var data = File.ReadAllText(_dataPath);
            MessageBox.Show(data, "вы считали текст", MessageBoxButtons.OK);

        }

        private void uiWriteButton_Click(object sender, EventArgs e)
        {
            var data = uiDataTextBox.Text;
            File.WriteAllText(_dataPath, data);
        }

        private void uiBattleButton_Click(object sender, EventArgs e)
        {
            if (_gameData.StaminaPoints < 30)
            {
                MessageBox.Show("вы устали и не можете драться, отдохните");
                return;
            }

            _gameData.StaminaPoints -= 30;
            _gameData.ManaPoints -= 20;
            _gameData.HitPoints -= 10;
            RefreshData();
        }

        private void uiRelaxButton_Click(object sender, EventArgs e)
        {
            _gameData.StaminaPoints += 10;
            _gameData.ManaPoints += 10;
            _gameData.HitPoints += 10;
            RefreshData();
        }

        private void RefreshData()
        {
            uiHitPointTextBox.Text = _gameData.HitPoints.ToString();
            uiManaPointTextBox.Text = _gameData.ManaPoints.ToString();
            uiStaminaPointProgressBar.Value = _gameData.StaminaPoints;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _gameData = new GameData();
            _gameData.HitPoints = 100;
            _gameData.ManaPoints = 100;
            _gameData.StaminaPoints = 100;
            RefreshData();
        }

        private void uiSaveGameButton_Click(object sender, EventArgs e)
        {
            string savePath = GetSavePath();
            string saveData = JsonConvert.SerializeObject(_gameData);
            File.WriteAllText(savePath, saveData);
        }

        private void uiLoadGameButton_Click(object sender, EventArgs e)
        {
            string savePath = GetSavePath();
            var saveData = File.ReadAllText(savePath);
            _gameData = JsonConvert.DeserializeObject<GameData>(saveData);
            RefreshData();
        }

        private string GetSavePath()
        {
            int slotNumber;
            if (uiSaveSlot1RadioButton.Checked)
            {
                slotNumber = 1;
            }
            else if (uiSaveSlot2RadioButton.Checked)
            {
                slotNumber = 2;
            }
            else
            {
                slotNumber = 3;
            }
            var savePath = Path.Combine(_gameDataPath, $"save{slotNumber}.data");
            return savePath;
        }
    }
}
