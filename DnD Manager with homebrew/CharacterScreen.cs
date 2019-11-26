using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Equip_screen
{
    public partial class CharacterScreen : Form
    {
        Character character = new Character();

        public CharacterScreen()
        {
            InitializeComponent();
            HumanSilhouette.Image = Properties.Resources.Body;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                HumanSilhouette.Image = Properties.Resources.Body__female_;
            else
                HumanSilhouette.Image = Properties.Resources.Body;
        }

        private void STRvalue_ValueChanged(object sender, EventArgs e)
        {
            character.STR = STRvalue.Value;
            decimal result = character.getSTRmod();

            if (result > 0)
                STRmod.Text = "+";
            else
                STRmod.Text = "";

            STRmod.Text += result.ToString();
        }

        private void DEXvalue_ValueChanged(object sender, EventArgs e)
        {
            character.DEX = STRvalue.Value;
            decimal result = character.getDEXmod();

            if (result > 0)
                DEXmod.Text = "+";
            else
                DEXmod.Text = "";

            DEXmod.Text += result.ToString();
        }

        private void CONvalue_ValueChanged(object sender, EventArgs e)
        {
            character.CON = CONvalue.Value;
            decimal result = character.getCONmod();

            if (result > 0)
                CONmod.Text = "+";
            else
                CONmod.Text = "";

            CONmod.Text += result.ToString();
        }

        private void INTvalue_ValueChanged(object sender, EventArgs e)
        {
            character.INT = INTvalue.Value;
            decimal result = character.getINTmod();

            if (result > 0)
                INTmod.Text = "+";
            else
                INTmod.Text = "";

            INTmod.Text += result.ToString();
        }

        private void WISvalue_ValueChanged(object sender, EventArgs e)
        {
            character.WIS = WISvalue.Value;
            decimal result = character.getWISmod();

            if (result > 0)
                WISmod.Text = "+";
            else
                WISmod.Text = "";

            WISmod.Text += result.ToString();
        }

        private void CHAvalue_ValueChanged(object sender, EventArgs e)
        {
            character.CHA = CHAvalue.Value;
            decimal result = character.getCHAmod();

            if (result > 0)
                CHAmod.Text = "+";
            else
                CHAmod.Text = "";

            CHAmod.Text += result.ToString();
        }

        private void STRProficiency_CheckedChanged(object sender, EventArgs e)
        {
            character.STRproficiency = STRProficiency.Checked;
            STRvalue_ValueChanged(sender, e);
        }

        private void DEXProficiency_CheckedChanged(object sender, EventArgs e)
        {
            character.DEXproficiency = DEXProficiency.Checked;
            DEXvalue_ValueChanged(sender, e);
        }

        private void CONProficiency_CheckedChanged(object sender, EventArgs e)
        {
            character.CONproficiency = CONProficiency.Checked;
            CONvalue_ValueChanged(sender, e);
        }

        private void INTProficiency_CheckedChanged(object sender, EventArgs e)
        {
            character.INTproficiency = INTProficiency.Checked;
            INTvalue_ValueChanged(sender, e);
        }

        private void WISProficiency_CheckedChanged(object sender, EventArgs e)
        {
            character.WISproficiency = WISProficiency.Checked;
            WISvalue_ValueChanged(sender, e);
        }

        private void CHAProficiency_CheckedChanged(object sender, EventArgs e)
        {
            character.CHAproficiency = CHAProficiency.Checked;
            CHAvalue_ValueChanged(sender, e);
        }

 /*       private void PlayerLevel_ValueChanged(object sender, EventArgs e)
        {
            if (PlayerLevel.Value > 1)
                ProficiencyBonusValue.Text = (Math.Ceiling(PlayerLevel.Value / 4) + 1).ToString();
            else
                ProficiencyBonusValue.Text = "N/A";
        }*/

        private void LeftHandedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (LeftHandedCheckbox.Checked)
            {
                LeftHandButton.Text = "Main hand";
                RightHandButton.Text = "Off hand";
            }
            else
            {
                LeftHandButton.Text = "Off hand";
                RightHandButton.Text = "Main hand";
            }
        }
    }
}
