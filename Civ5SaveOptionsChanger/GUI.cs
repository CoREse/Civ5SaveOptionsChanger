using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Civ5SaveOptionsChanger
{
    public partial class GUI : Form
    {
        Dictionary<string, string> English, Chinese;
        Dictionary<string, string> CurrentLanguage;
        string LanguageFile = "Language.conf";
        public GUI()
        {
            InitializeComponent();
            generateLanguages();
            refreshUI();
        }

        Core TheCore;
        string LastFileName = "";
        bool Loading = false;
        bool Refreshing = false;

        private void refreshUI()
        {
            Refreshing = true;
            button_open_file.Text = CurrentLanguage["Open"];
            Save.Text = CurrentLanguage["Save"];
            SaveAs.Text = CurrentLanguage["SaveAs"];
            OptionName.Text = CurrentLanguage["Option"];
            this.Text = CurrentLanguage["Title"];
            comboBoxLanguage.SelectedIndex = 0;
            if (CurrentLanguage == English)
            {
                comboBoxLanguage.SelectedIndex = 0;
            }
            else if (CurrentLanguage == Chinese)
            {
                comboBoxLanguage.SelectedIndex = 1;
            }
            Refresh();
            Refreshing = false;
        }

        private void button_open_file_Click(object sender, EventArgs e)
        {
            if (openCiv5SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Loading = true;
                try
                {
                    TheCore = new Core(File.ReadAllBytes(openCiv5SaveFileDialog.FileName));
                    LastFileName = openCiv5SaveFileDialog.FileName;
                }
                catch (WrongFileException E)
                {
                    MessageBox.Show("Something wrong with the file!");
                    return;
                }
                //MessageBox.Show(TheCore.Options[0].Name);

                refreshOptionList();

                //TheCore.Options[10].Value = 1;
                //File.WriteAllBytes(openCiv5SaveFileDialog.FileName+"a",TheCore.output());

                Loading = false;
            }
        }

        private void refreshOptionList()
        {
            OptionList.Items.Clear();
            foreach (Option O in TheCore.Options)
            {
                ListViewItem L = new ListViewItem(O.getLocalName(CurrentLanguage));
                //L.SubItems.Add(O.Value.ToString());
                if (O.Value == 1) L.Checked = true;
                OptionList.Items.Add(L);
            }
        }

        private void onOptionItemCheckedChange(object sender, ItemCheckedEventArgs e)
        {
            if (Loading) return;
            TheCore.Options[e.Item.Index].Value = e.Item.Checked ? 1 : 0;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (LastFileName == "")
            {
                MessageBox.Show("You haven't open a Civ5Save file!");
                return;
            }
            File.WriteAllBytes(LastFileName, TheCore.output());
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (LastFileName == "")
            {
                MessageBox.Show("You haven't open a Civ5Save file!");
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, TheCore.output());
            }
        }

        private void onLanguageChange(object sender, EventArgs e)
        {
            if (Refreshing) return;
            switch (comboBoxLanguage.SelectedIndex)
            {
                case 0:
                    CurrentLanguage = English;
                    File.WriteAllBytes(LanguageFile, System.Text.Encoding.Default.GetBytes("English"));
                    break;
                case 1:
                    CurrentLanguage = Chinese;
                    File.WriteAllBytes(LanguageFile, System.Text.Encoding.Default.GetBytes("Chinese"));
                    break;
            }
            refreshUI();
        }

        private void generateLanguages()
        {
            English = new Dictionary<string, string>();
            Chinese = new Dictionary<string, string>();

            //Languages
            English.Add("Save", "Save");
            English.Add("Open", "Open");
            English.Add("SaveAs", "Save as");
            English.Add("Option", "Option");
            English.Add("Title", "Civilization V Save File Option Changer");
            English.Add("GAMEOPTION_QUICK_COMBAT", "Quick Combat");
            English.Add("GAMEOPTION_QUICK_MOVEMENT", "Quick Movement");
            English.Add("GAMEOPTION_ONE_CITY_CHALLENGE", "One-City Challenge");
            English.Add("GAMEOPTION_ALWAYS_PEACE", "Always Peace");
            English.Add("GAMEOPTION_ALWAYS_WAR", "Always War");
            English.Add("GAMEOPTION_NO_CHANGING_WAR_PEACE", "Permanent War or Peace");
            English.Add("GAMEOPTION_NEW_RANDOM_SEED", "New Random Seed");
            English.Add("GAMEOPTION_NO_GOODY_HUTS", "No Ancient Ruins");
            English.Add("GAMEOPTION_POLICY_SAVING", "Allow Policy Saving");
            English.Add("GAMEOPTION_NO_TUTORIAL", "Disable Tutorial Popups");
            English.Add("GAMEOPTION_NO_HAPPINESS", "Disable Happiness");
            English.Add("GAMEOPTION_PROMOTION_SAVING", "Allow Promotion Saving");
            English.Add("GAMEOPTION_NO_BARBARIANS", "No Barbarians");
            English.Add("GAMEOPTION_NO_CITY_RAZING", "No City Razing");
            English.Add("GAMEOPTION_NO_ESPIONAGE", "No Espionage");
            English.Add("GAMEOPTION_COMPLETE_KILLS", "Complete Kills");
            English.Add("GAMEOPTION_RANDOM_PERSONALITIES", "Random Personalities");
            English.Add("GAMEOPTION_LOCK_MODS", "Lock Mods");
            English.Add("GAMEOPTION_DISABLE_START_BIAS", "Disable Start Bias");
            English.Add("GAMEOPTION_NO_POLICIES", "Disable Policies");
            English.Add("GAMEOPTION_NO_SCIENCE", "Disable Research");
            English.Add("GAMEOPTION_RAGING_BARBARIANS", "Raging Barbarians");
            English.Add("GAMEOPTION_SIMULTANEOUS_TURNS", "Simultaneous Turns");
            English.Add("GAMEOPTION_DYNAMIC_TURNS", "Dynamic Turns");
            English.Add("GAMEOPTION_PITBOSS", "Pitboss");

            Chinese.Add("Save", "保存");
            Chinese.Add("Open", "打开");
            Chinese.Add("SaveAs", "另存为");
            Chinese.Add("Option", "选项");
            Chinese.Add("Title", "文明5存档选项修改器");
            Chinese.Add("GAMEOPTION_QUICK_COMBAT", "快速战斗");
            Chinese.Add("GAMEOPTION_QUICK_MOVEMENT", "快速移动");
            Chinese.Add("GAMEOPTION_ONE_CITY_CHALLENGE", "孤城死斗");
            Chinese.Add("GAMEOPTION_ALWAYS_PEACE", "永久和平");
            Chinese.Add("GAMEOPTION_ALWAYS_WAR", "永久战争");
            Chinese.Add("GAMEOPTION_NO_CHANGING_WAR_PEACE", "永远战争或和平");
            Chinese.Add("GAMEOPTION_NEW_RANDOM_SEED", "全新乱数");
            Chinese.Add("GAMEOPTION_NO_GOODY_HUTS", "抹除遗迹");
            Chinese.Add("GAMEOPTION_POLICY_SAVING", "政策保留");
            Chinese.Add("GAMEOPTION_NO_TUTORIAL", "停止示范弹出视窗");
            Chinese.Add("GAMEOPTION_NO_HAPPINESS", "停止幸福度");
            Chinese.Add("GAMEOPTION_PROMOTION_SAVING", "强化保留");
            Chinese.Add("GAMEOPTION_NO_BARBARIANS", "移除蛮族");
            Chinese.Add("GAMEOPTION_NO_CITY_RAZING", "禁止焚城");
            Chinese.Add("GAMEOPTION_NO_ESPIONAGE", "禁用谍报");
            Chinese.Add("GAMEOPTION_COMPLETE_KILLS", "赶尽杀绝");
            Chinese.Add("GAMEOPTION_RANDOM_PERSONALITIES", "随机特质");
            Chinese.Add("GAMEOPTION_LOCK_MODS", "锁定模组");
            Chinese.Add("GAMEOPTION_DISABLE_START_BIAS", "关闭匹配");
            Chinese.Add("GAMEOPTION_NO_POLICIES", "关闭政策");
            Chinese.Add("GAMEOPTION_NO_SCIENCE", "关闭研究");
            Chinese.Add("GAMEOPTION_RAGING_BARBARIANS", "蛮族之怒");
            Chinese.Add("GAMEOPTION_SIMULTANEOUS_TURNS", "同时进行回合");
            Chinese.Add("GAMEOPTION_DYNAMIC_TURNS", "动态回合");
            Chinese.Add("GAMEOPTION_PITBOSS", "热座模式");

            if (File.Exists(LanguageFile))
            {
                string L = System.Text.Encoding.Default.GetString(File.ReadAllBytes(LanguageFile));
                if (L == "English")
                {
                    CurrentLanguage = English;
                    return;
                }
                else if (L == "Chinese")
                {
                    CurrentLanguage = Chinese;
                    return;
                }
            }
            CurrentLanguage = English;
        }
    }
}
