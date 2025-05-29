using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Form1 : Form
{
    private readonly Dictionary<string, double> buffs = new Dictionary<string, double>
    {
        { "Mask", 1.07 }, { "Cape", 1.05 }, { "Tiara", 1.07 }, { "Pet", 1.05 },
        { "Drum", 1.25 }, { "Turtle", 1.35 }, { "Frog", 1.3 }, { "Crown", 1.05 },
        { "TurtB", 0.4 }, { "RG", 0.5 }, { "RR", 0.75 }, { "DW", 0.7 },{ "Wani", 0.9 },{ "Cloyal", 0.85 },
        { "Weak", 0.75 }, { "Charm", 0.5 },{ "TM", 1.05 },{ "Cboss", 1.07 },{ "None" ,1.00 },

        { "I", 1.03 }, { "II", 1.05 }, { "III", 1.07 }, { "IV", 1.1 }, { "V", 1.13 },
        { "VI", 1.2 }, { "VII", 1.265 }, { "VIII", 1.33 }, { "IX", 1.41 }, { "X", 1.4918 },
        { "L_I", 1.04 }, { "L_II", 1.05 }, { "L_III", 1.08 }, { "L_IV", 1.11 }, { "L_V", 1.15 },
        { "L_VI", 1.23 }, { "L_VII", 1.3 }, { "L_VIII", 1.38 }, { "L_IX", 1.47 }, { "L_X", 1.57 },
        { "E_I", 1.05 }, { "E_II", 1.07 }, { "E_III", 1.09 }, { "E_IV", 1.13 }, { "E_V", 1.18 },
        { "E_VI", 1.27 }, { "E_VII", 1.36 }, { "E_VIII", 1.44 }, { "E_IX", 1.55 }, { "E_X", 1.66 },
        { "R_I", 1.05 }, { "R_II", 1.08 }, { "R_III", 1.1 }, { "R_IV", 1.15 }, { "R_V", 1.2 },
        { "R_VI", 1.29 }, { "R_VII", 1.38 }, { "R_VIII", 1.48 }, { "R_IX", 1.6 }, { "R_X", 1.72 },
        { "C_I", 1.07 }, { "C_II", 1.11 }, { "C_III", 1.15 }, { "C_IV", 1.23 }, { "C_V", 1.31 },
        { "C_VI", 1.47 }, { "C_VII", 1.63 }, { "C_VIII", 1.78 }, { "C_IX", 1.98 }, { "C_X", 2.18 }
    };
    string[] levels = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
    string[] rarities = { "Mythic", "Legendary", "Epic", "Rare", "Common" };


    private readonly Dictionary<string, double> headshotBuffs = new Dictionary<string, double>
    {
        { "Altar", 1.0714 }
    };

    private readonly List<string> selectedBuffs = new List<string>();

    private IContainer components = null;

    private Label Enterbasedamage;
    private TextBox textBoxBaseDamage;
    private TextBox lblResult;
    private TextBox txtHeadshotDamage;
    private TextBox txtCritDamage;

    public Form1()
    {
        InitializeComponent();

    }

    private async void LoadResourcesAsync()
    {
        await Task.Delay(1000);

    }

    public void CalculateDamage()
    {
        
        if (!double.TryParse(textBoxBaseDamage.Text, out var baseDamage))
        {
            
            return;
        }

        double finalDamage = baseDamage;


        string rarity = comboRarity.SelectedItem?.ToString();
        string level = comboLevel.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(rarity) && !string.IsNullOrEmpty(level) &&
            rarity != "None" && level != "None")
        {
            string key = "";

            switch (rarity)
            {
                case "Common": key = $"C_{level}"; break;
                case "Rare": key = $"R_{level}"; break;
                case "Epic": key = $"E_{level}"; break;
                case "Legendary": key = $"L_{level}"; break;
                case "Mythic": key = level; break;
            }

            if (buffs.TryGetValue(key, out double rarityMultiplier))
            {
                finalDamage *= rarityMultiplier;
            }
            else
            {
                MessageBox.Show($"No multiplier found for {rarity} {level}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        foreach (string buff in selectedBuffs)
        {
            if (buffs.TryGetValue(buff, out double multiplier))
                finalDamage *= multiplier;
        }

        
        double headshotDamage = finalDamage * 1.4;
        double critDamage = finalDamage * 1.4;
        double critHeadDamage = critDamage * 1.4;

        foreach (string buff in selectedBuffs)
        {
            if (headshotBuffs.TryGetValue(buff, out double hsBuff))
            {
                headshotDamage *= hsBuff;
                critHeadDamage *= hsBuff;
            }
        }
        double increasePercent = 0;
        if (double.TryParse(txtDamageIncreasePercent.Text, out double inputPercent))
        {
            increasePercent = inputPercent / 100.0;
        }

        finalDamage *= (1 + increasePercent);
        headshotDamage *= (1 + increasePercent);
        critDamage *= (1 + increasePercent);
        critHeadDamage *= (1 + increasePercent);

        double decreasePercent = 0;
        if (double.TryParse(txtDamageDecreasePercent.Text, out double inputPercentDecrease))
        {
            decreasePercent = inputPercentDecrease / 100.0;
            decreasePercent = Math.Max(0, Math.Min(decreasePercent, 1.0)); 
        }

        finalDamage *= (1 - decreasePercent);
        headshotDamage *= (1 - decreasePercent);
        critDamage *= (1 - decreasePercent);
        critHeadDamage *= (1 - decreasePercent);

        //OUTPUT RESULTS
        lblResult.Text = $"{finalDamage:F2}";
        txtHeadshotDamage.Text = $"{headshotDamage:F2}";
        txtCritDamage.Text = $"{critDamage:F2}";
        txtHeadshotCritDamage.Text = $"{critHeadDamage:F2}";
        //ARMOR VISIBLIITY
        Armor1.BackColor = finalDamage >= 200 ? Color.Lime : Color.Transparent;
        armor2.BackColor = finalDamage >= 220 ? Color.Lime : Color.Transparent;
        armor3.BackColor = finalDamage >= 240 ? Color.Lime : Color.Transparent;
        armor4.BackColor = finalDamage >= 260 ? Color.Lime : Color.Transparent;
        armor5.BackColor = finalDamage >= 280 ? Color.Lime : Color.Transparent;

        //RED X OVER ARMOR
        X1.Visible = finalDamage < 200;
        X2.Visible = finalDamage < 220;
        X3.Visible = finalDamage < 240;
        X4.Visible = finalDamage < 260;
        X5.Visible = finalDamage < 280;

    }
    private bool isUpdatingText = false;

    
    
    private Timer fadeOutTimer;
    private bool isClosing = false;
    private Timer fadeTimer;
    private void FadeOutTimer_Tick(object sender, EventArgs e)
    {
        if (this.Opacity > 0)
        {
            this.Opacity -= 0.05;
        }
        else
        {
            fadeOutTimer.Stop();
            fadeOutTimer.Dispose();
            Application.Exit(); // Or this.Close(); if not already exiting
        }
    }

    private void fadeTimer_Tick(object sender, EventArgs e)
    {
        if (this.Opacity < 1)
            this.Opacity += 0.05;
        else
            fadeTimer.Stop();
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!isClosing)
        {
            e.Cancel = true;
            isClosing = true;

            fadeOutTimer = new Timer();
            fadeOutTimer.Interval = 30;
            fadeOutTimer.Tick += FadeOutTimer_Tick;
            fadeOutTimer.Start();
        }
    }


    private void Form1_Load(object sender, EventArgs e)
    {
        comboRarity.Items.Add("None");
        comboLevel.Items.Add("None");

        comboRarity.Items.AddRange(rarities);
        comboLevel.Items.AddRange(levels);

        comboRarity.SelectedItem = "None";
        comboLevel.SelectedItem = "None";
        fadeTimer = new Timer();
        fadeTimer.Interval = 30;
        fadeTimer.Tick += fadeTimer_Tick;
        fadeTimer.Start();

        textBoxBaseDamage.TextChanged += (s1, e1) => CalculateDamage();

        txtDamageIncreasePercent.TextChanged += (s2, e2) => CalculateDamage();

        txtDamageDecreasePercent.TextChanged += (s3, e3) => CalculateDamage();
        comboRarity.SelectedIndexChanged += (s4, e4) => CalculateDamage();
        comboLevel.SelectedIndexChanged += (s5, e5) => CalculateDamage();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Enterbasedamage = new System.Windows.Forms.Label();
            this.textBoxBaseDamage = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.TextBox();
            this.txtHeadshotDamage = new System.Windows.Forms.TextBox();
            this.txtCritDamage = new System.Windows.Forms.TextBox();
            this.txtHeadshotCritDamage = new System.Windows.Forms.TextBox();
            this.comboRarity = new System.Windows.Forms.ComboBox();
            this.comboLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.X5 = new System.Windows.Forms.PictureBox();
            this.X4 = new System.Windows.Forms.PictureBox();
            this.X3 = new System.Windows.Forms.PictureBox();
            this.X2 = new System.Windows.Forms.PictureBox();
            this.X1 = new System.Windows.Forms.PictureBox();
            this.armor5 = new System.Windows.Forms.PictureBox();
            this.armor4 = new System.Windows.Forms.PictureBox();
            this.armor3 = new System.Windows.Forms.PictureBox();
            this.armor2 = new System.Windows.Forms.PictureBox();
            this.Armor1 = new System.Windows.Forms.PictureBox();
            this.btnCboss = new System.Windows.Forms.Button();
            this.btnCloyal = new System.Windows.Forms.Button();
            this.btnWeak = new System.Windows.Forms.Button();
            this.btnCharm = new System.Windows.Forms.Button();
            this.btnWani = new System.Windows.Forms.Button();
            this.btnDW = new System.Windows.Forms.Button();
            this.btnRR = new System.Windows.Forms.Button();
            this.btnRG = new System.Windows.Forms.Button();
            this.btnTurtB = new System.Windows.Forms.Button();
            this.btnAltar = new System.Windows.Forms.Button();
            this.btnPet = new System.Windows.Forms.Button();
            this.btnTurtle = new System.Windows.Forms.Button();
            this.btnFrog = new System.Windows.Forms.Button();
            this.btnDrum = new System.Windows.Forms.Button();
            this.btnCrown = new System.Windows.Forms.Button();
            this.btnCape = new System.Windows.Forms.Button();
            this.btnTiara = new System.Windows.Forms.Button();
            this.btnMask = new System.Windows.Forms.Button();
            this.txtDamageIncreasePercent = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDamageDecreasePercent = new System.Windows.Forms.TextBox();
            this.btnTMboost = new System.Windows.Forms.Button();
        this.AutoValidate = AutoValidate.Disable;

        ((System.ComponentModel.ISupportInitialize)(this.X5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.X1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Armor1)).BeginInit();
            this.SuspendLayout();
            // 
            // Enterbasedamage
            // 
            this.Enterbasedamage.AutoSize = true;
            this.Enterbasedamage.Font = new System.Drawing.Font("Noto Sans JP", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enterbasedamage.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Enterbasedamage.Location = new System.Drawing.Point(289, 19);
            this.Enterbasedamage.Name = "Enterbasedamage";
            this.Enterbasedamage.Size = new System.Drawing.Size(241, 35);
            this.Enterbasedamage.TabIndex = 0;
            this.Enterbasedamage.Text = "Enter Base Damage";
            // 
            // textBoxBaseDamage
            // 
            this.textBoxBaseDamage.Font = new System.Drawing.Font("Noto Sans JP", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBaseDamage.Location = new System.Drawing.Point(315, 62);
            this.textBoxBaseDamage.Multiline = true;
            this.textBoxBaseDamage.Name = "textBoxBaseDamage";
            this.textBoxBaseDamage.Size = new System.Drawing.Size(175, 59);
            this.textBoxBaseDamage.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.SystemColors.Window;
            this.lblResult.Font = new System.Drawing.Font("Noto Sans JP", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(665, 86);
            this.lblResult.Multiline = true;
            this.lblResult.Name = "lblResult";
            this.lblResult.ReadOnly = true;
            this.lblResult.Size = new System.Drawing.Size(150, 35);
            this.lblResult.TabIndex = 2;
            // 
            // txtHeadshotDamage
            // 
            this.txtHeadshotDamage.BackColor = System.Drawing.SystemColors.Window;
            this.txtHeadshotDamage.Font = new System.Drawing.Font("Noto Sans JP", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeadshotDamage.Location = new System.Drawing.Point(665, 141);
            this.txtHeadshotDamage.Multiline = true;
            this.txtHeadshotDamage.Name = "txtHeadshotDamage";
            this.txtHeadshotDamage.ReadOnly = true;
            this.txtHeadshotDamage.Size = new System.Drawing.Size(150, 35);
            this.txtHeadshotDamage.TabIndex = 3;
            // 
            // txtCritDamage
            // 
            this.txtCritDamage.BackColor = System.Drawing.SystemColors.Window;
            this.txtCritDamage.Font = new System.Drawing.Font("Noto Sans JP", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCritDamage.Location = new System.Drawing.Point(665, 196);
            this.txtCritDamage.Multiline = true;
            this.txtCritDamage.Name = "txtCritDamage";
            this.txtCritDamage.ReadOnly = true;
            this.txtCritDamage.Size = new System.Drawing.Size(150, 35);
            this.txtCritDamage.TabIndex = 4;
            // 
            // txtHeadshotCritDamage
            // 
            this.txtHeadshotCritDamage.BackColor = System.Drawing.SystemColors.Window;
            this.txtHeadshotCritDamage.Font = new System.Drawing.Font("Noto Sans JP", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeadshotCritDamage.Location = new System.Drawing.Point(665, 251);
            this.txtHeadshotCritDamage.Multiline = true;
            this.txtHeadshotCritDamage.Name = "txtHeadshotCritDamage";
            this.txtHeadshotCritDamage.ReadOnly = true;
            this.txtHeadshotCritDamage.Size = new System.Drawing.Size(150, 35);
            this.txtHeadshotCritDamage.TabIndex = 6;
            this.txtHeadshotCritDamage.TextChanged += new System.EventHandler(this.txtHeadshotCritDamage_TextChanged);
            // 
            // comboRarity
            // 
            this.comboRarity.AllowDrop = true;
            this.comboRarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRarity.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboRarity.FormattingEnabled = true;
            this.comboRarity.Location = new System.Drawing.Point(7, 373);
            this.comboRarity.Name = "comboRarity";
            this.comboRarity.Size = new System.Drawing.Size(121, 35);
            this.comboRarity.TabIndex = 7;
            this.comboRarity.SelectedIndexChanged += new System.EventHandler(this.comboRarity_SelectedIndexChanged);
            // 
            // comboLevel
            // 
            this.comboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLevel.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLevel.FormattingEnabled = true;
            this.comboLevel.Location = new System.Drawing.Point(147, 373);
            this.comboLevel.Name = "comboLevel";
            this.comboLevel.Size = new System.Drawing.Size(62, 35);
            this.comboLevel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(66, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Modules";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(46, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "Damage Buffs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(7, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 27);
            this.label3.TabIndex = 11;
            this.label3.Text = "Wears";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(81, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 27);
            this.label4.TabIndex = 20;
            this.label4.Text = "Gadgets";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(175, 430);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 27);
            this.label5.TabIndex = 24;
            this.label5.Text = "Other";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(603, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 27);
            this.label6.TabIndex = 27;
            this.label6.Text = "Base";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(558, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 27);
            this.label7.TabIndex = 28;
            this.label7.Text = "Headshot";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label8.Location = new System.Drawing.Point(603, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 27);
            this.label8.TabIndex = 29;
            this.label8.Text = "Crit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label9.Location = new System.Drawing.Point(510, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 27);
            this.label9.TabIndex = 30;
            this.label9.Text = "Headshot Crit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label10.Location = new System.Drawing.Point(333, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 27);
            this.label10.TabIndex = 31;
            this.label10.Text = "Barriers/Effects";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label11.Location = new System.Drawing.Point(309, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 27);
            this.label11.TabIndex = 32;
            this.label11.Text = "Barriers";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label12.Location = new System.Drawing.Point(435, 354);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 27);
            this.label12.TabIndex = 36;
            this.label12.Text = "Effects";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Noto Sans JP", 14.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label13.Location = new System.Drawing.Point(682, 354);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 27);
            this.label13.TabIndex = 48;
            this.label13.Text = "1 Shot Kill";
            // 
            // X5
            // 
            this.X5.BackColor = System.Drawing.Color.Transparent;
            this.X5.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.X5;
            this.X5.InitialImage = null;
            this.X5.Location = new System.Drawing.Point(687, 396);
            this.X5.Name = "X5";
            this.X5.Size = new System.Drawing.Size(98, 98);
            this.X5.TabIndex = 53;
            this.X5.TabStop = false;
            // 
            // X4
            // 
            this.X4.BackColor = System.Drawing.Color.Transparent;
            this.X4.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.X4;
            this.X4.InitialImage = null;
            this.X4.Location = new System.Drawing.Point(744, 506);
            this.X4.Name = "X4";
            this.X4.Size = new System.Drawing.Size(99, 98);
            this.X4.TabIndex = 52;
            this.X4.TabStop = false;
            // 
            // X3
            // 
            this.X3.BackColor = System.Drawing.Color.Transparent;
            this.X3.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.X3;
            this.X3.InitialImage = null;
            this.X3.Location = new System.Drawing.Point(626, 527);
            this.X3.Name = "X3";
            this.X3.Size = new System.Drawing.Size(99, 100);
            this.X3.TabIndex = 51;
            this.X3.TabStop = false;
            // 
            // X2
            // 
            this.X2.BackColor = System.Drawing.Color.Transparent;
            this.X2.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.X2;
            this.X2.InitialImage = null;
            this.X2.Location = new System.Drawing.Point(744, 634);
            this.X2.Name = "X2";
            this.X2.Size = new System.Drawing.Size(99, 98);
            this.X2.TabIndex = 50;
            this.X2.TabStop = false;
            // 
            // X1
            // 
            this.X1.BackColor = System.Drawing.Color.Transparent;
            this.X1.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.X1;
            this.X1.InitialImage = null;
            this.X1.Location = new System.Drawing.Point(625, 667);
            this.X1.Name = "X1";
            this.X1.Size = new System.Drawing.Size(100, 100);
            this.X1.TabIndex = 49;
            this.X1.TabStop = false;
            // 
            // armor5
            // 
            this.armor5.BackColor = System.Drawing.Color.Transparent;
            this.armor5.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.armor5;
            this.armor5.InitialImage = null;
            this.armor5.Location = new System.Drawing.Point(687, 396);
            this.armor5.Name = "armor5";
            this.armor5.Size = new System.Drawing.Size(98, 98);
            this.armor5.TabIndex = 47;
            this.armor5.TabStop = false;
            // 
            // armor4
            // 
            this.armor4.BackColor = System.Drawing.Color.Transparent;
            this.armor4.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.armor4;
            this.armor4.InitialImage = null;
            this.armor4.Location = new System.Drawing.Point(744, 506);
            this.armor4.Name = "armor4";
            this.armor4.Size = new System.Drawing.Size(99, 98);
            this.armor4.TabIndex = 46;
            this.armor4.TabStop = false;
            // 
            // armor3
            // 
            this.armor3.BackColor = System.Drawing.Color.Transparent;
            this.armor3.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.armor3;
            this.armor3.InitialImage = null;
            this.armor3.Location = new System.Drawing.Point(625, 527);
            this.armor3.Name = "armor3";
            this.armor3.Size = new System.Drawing.Size(99, 105);
            this.armor3.TabIndex = 45;
            this.armor3.TabStop = false;
            // 
            // armor2
            // 
            this.armor2.BackColor = System.Drawing.Color.Transparent;
            this.armor2.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.armor2;
            this.armor2.InitialImage = null;
            this.armor2.Location = new System.Drawing.Point(744, 634);
            this.armor2.Name = "armor2";
            this.armor2.Size = new System.Drawing.Size(99, 105);
            this.armor2.TabIndex = 44;
            this.armor2.TabStop = false;
            // 
            // Armor1
            // 
            this.Armor1.BackColor = System.Drawing.Color.Transparent;
            this.Armor1.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Armor1;
            this.Armor1.InitialImage = null;
            this.Armor1.Location = new System.Drawing.Point(625, 667);
            this.Armor1.Name = "Armor1";
            this.Armor1.Size = new System.Drawing.Size(103, 105);
            this.Armor1.TabIndex = 43;
            this.Armor1.TabStop = false;
            // 
            // btnCboss
            // 
            this.btnCboss.BackColor = System.Drawing.Color.Transparent;
            this.btnCboss.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Cboss;
            this.btnCboss.FlatAppearance.BorderSize = 0;
            this.btnCboss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCboss.Location = new System.Drawing.Point(12, 735);
            this.btnCboss.Name = "btnCboss";
            this.btnCboss.Size = new System.Drawing.Size(60, 60);
            this.btnCboss.TabIndex = 42;
            this.btnCboss.UseVisualStyleBackColor = false;
            this.btnCboss.Click += new System.EventHandler(this.btnCboss_Click);
            // 
            // btnCloyal
            // 
            this.btnCloyal.BackColor = System.Drawing.Color.Transparent;
            this.btnCloyal.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Cloyal1;
            this.btnCloyal.FlatAppearance.BorderSize = 0;
            this.btnCloyal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloyal.Location = new System.Drawing.Point(356, 466);
            this.btnCloyal.Name = "btnCloyal";
            this.btnCloyal.Size = new System.Drawing.Size(60, 60);
            this.btnCloyal.TabIndex = 41;
            this.btnCloyal.UseVisualStyleBackColor = false;
            this.btnCloyal.Click += new System.EventHandler(this.btnCloyal_Click);
            // 
            // btnWeak
            // 
            this.btnWeak.BackColor = System.Drawing.Color.Transparent;
            this.btnWeak.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Weak;
            this.btnWeak.FlatAppearance.BorderSize = 0;
            this.btnWeak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeak.Location = new System.Drawing.Point(440, 464);
            this.btnWeak.Name = "btnWeak";
            this.btnWeak.Size = new System.Drawing.Size(58, 55);
            this.btnWeak.TabIndex = 40;
            this.btnWeak.UseVisualStyleBackColor = false;
            this.btnWeak.Click += new System.EventHandler(this.btnWeak_Click);
            // 
            // btnCharm
            // 
            this.btnCharm.BackColor = System.Drawing.Color.Transparent;
            this.btnCharm.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Charm;
            this.btnCharm.FlatAppearance.BorderSize = 0;
            this.btnCharm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCharm.Location = new System.Drawing.Point(440, 404);
            this.btnCharm.Name = "btnCharm";
            this.btnCharm.Size = new System.Drawing.Size(67, 44);
            this.btnCharm.TabIndex = 39;
            this.btnCharm.UseVisualStyleBackColor = false;
            this.btnCharm.Click += new System.EventHandler(this.btnCharm_Click);
            // 
            // btnWani
            // 
            this.btnWani.BackColor = System.Drawing.Color.Transparent;
            this.btnWani.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Wani;
            this.btnWani.FlatAppearance.BorderSize = 0;
            this.btnWani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWani.Location = new System.Drawing.Point(356, 396);
            this.btnWani.Name = "btnWani";
            this.btnWani.Size = new System.Drawing.Size(60, 60);
            this.btnWani.TabIndex = 38;
            this.btnWani.UseVisualStyleBackColor = false;
            this.btnWani.Click += new System.EventHandler(this.btnWani_Click);
            // 
            // btnDW
            // 
            this.btnDW.BackColor = System.Drawing.Color.Transparent;
            this.btnDW.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.DW;
            this.btnDW.FlatAppearance.BorderSize = 0;
            this.btnDW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDW.Location = new System.Drawing.Point(281, 592);
            this.btnDW.Name = "btnDW";
            this.btnDW.Size = new System.Drawing.Size(60, 60);
            this.btnDW.TabIndex = 37;
            this.btnDW.UseVisualStyleBackColor = false;
            this.btnDW.Click += new System.EventHandler(this.btnDW_Click);
            // 
            // btnRR
            // 
            this.btnRR.BackColor = System.Drawing.Color.Transparent;
            this.btnRR.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.RR;
            this.btnRR.FlatAppearance.BorderSize = 0;
            this.btnRR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRR.Location = new System.Drawing.Point(281, 526);
            this.btnRR.Name = "btnRR";
            this.btnRR.Size = new System.Drawing.Size(60, 60);
            this.btnRR.TabIndex = 35;
            this.btnRR.UseVisualStyleBackColor = false;
            this.btnRR.Click += new System.EventHandler(this.btnRR_Click);
            // 
            // btnRG
            // 
            this.btnRG.BackColor = System.Drawing.Color.Transparent;
            this.btnRG.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Rguard;
            this.btnRG.FlatAppearance.BorderSize = 0;
            this.btnRG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRG.Location = new System.Drawing.Point(281, 460);
            this.btnRG.Name = "btnRG";
            this.btnRG.Size = new System.Drawing.Size(60, 60);
            this.btnRG.TabIndex = 34;
            this.btnRG.UseVisualStyleBackColor = false;
            this.btnRG.Click += new System.EventHandler(this.btnRG_Click);
            // 
            // btnTurtB
            // 
            this.btnTurtB.BackColor = System.Drawing.Color.Transparent;
            this.btnTurtB.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.turtle;
            this.btnTurtB.FlatAppearance.BorderSize = 0;
            this.btnTurtB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurtB.Location = new System.Drawing.Point(281, 388);
            this.btnTurtB.Name = "btnTurtB";
            this.btnTurtB.Size = new System.Drawing.Size(60, 60);
            this.btnTurtB.TabIndex = 33;
            this.btnTurtB.UseVisualStyleBackColor = false;
            this.btnTurtB.Click += new System.EventHandler(this.btnTurtB_Click);
            // 
            // btnAltar
            // 
            this.btnAltar.BackColor = System.Drawing.Color.Transparent;
            this.btnAltar.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Altar;
            this.btnAltar.FlatAppearance.BorderSize = 0;
            this.btnAltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltar.Location = new System.Drawing.Point(180, 538);
            this.btnAltar.Name = "btnAltar";
            this.btnAltar.Size = new System.Drawing.Size(60, 63);
            this.btnAltar.TabIndex = 26;
            this.btnAltar.UseVisualStyleBackColor = false;
            this.btnAltar.Click += new System.EventHandler(this.btnAltar_Click);
            // 
            // btnPet
            // 
            this.btnPet.BackColor = System.Drawing.Color.Transparent;
            this.btnPet.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Pet1;
            this.btnPet.FlatAppearance.BorderSize = 0;
            this.btnPet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPet.Location = new System.Drawing.Point(180, 474);
            this.btnPet.Name = "btnPet";
            this.btnPet.Size = new System.Drawing.Size(60, 44);
            this.btnPet.TabIndex = 25;
            this.btnPet.UseVisualStyleBackColor = false;
            this.btnPet.Click += new System.EventHandler(this.btnPet_Click);
            // 
            // btnTurtle
            // 
            this.btnTurtle.BackColor = System.Drawing.Color.Transparent;
            this.btnTurtle.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.turtle;
            this.btnTurtle.FlatAppearance.BorderSize = 0;
            this.btnTurtle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurtle.Location = new System.Drawing.Point(96, 604);
            this.btnTurtle.Name = "btnTurtle";
            this.btnTurtle.Size = new System.Drawing.Size(60, 60);
            this.btnTurtle.TabIndex = 23;
            this.btnTurtle.UseVisualStyleBackColor = false;
            this.btnTurtle.Click += new System.EventHandler(this.btnTurtle_Click);
            // 
            // btnFrog
            // 
            this.btnFrog.BackColor = System.Drawing.Color.Transparent;
            this.btnFrog.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Frog;
            this.btnFrog.FlatAppearance.BorderSize = 0;
            this.btnFrog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFrog.Location = new System.Drawing.Point(96, 538);
            this.btnFrog.Name = "btnFrog";
            this.btnFrog.Size = new System.Drawing.Size(60, 60);
            this.btnFrog.TabIndex = 22;
            this.btnFrog.UseVisualStyleBackColor = false;
            this.btnFrog.Click += new System.EventHandler(this.btnFrog_Click);
            // 
            // btnDrum
            // 
            this.btnDrum.BackColor = System.Drawing.Color.Transparent;
            this.btnDrum.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.drum;
            this.btnDrum.FlatAppearance.BorderSize = 0;
            this.btnDrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrum.Location = new System.Drawing.Point(96, 474);
            this.btnDrum.Name = "btnDrum";
            this.btnDrum.Size = new System.Drawing.Size(60, 60);
            this.btnDrum.TabIndex = 21;
            this.btnDrum.UseVisualStyleBackColor = false;
            this.btnDrum.Click += new System.EventHandler(this.btnDrum_Click);
            // 
            // btnCrown
            // 
            this.btnCrown.BackColor = System.Drawing.Color.Transparent;
            this.btnCrown.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Crown;
            this.btnCrown.FlatAppearance.BorderSize = 0;
            this.btnCrown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrown.Location = new System.Drawing.Point(12, 670);
            this.btnCrown.Name = "btnCrown";
            this.btnCrown.Size = new System.Drawing.Size(60, 60);
            this.btnCrown.TabIndex = 19;
            this.btnCrown.UseVisualStyleBackColor = false;
            this.btnCrown.Click += new System.EventHandler(this.btnCrown_Click);
            // 
            // btnCape
            // 
            this.btnCape.BackColor = System.Drawing.Color.Transparent;
            this.btnCape.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Cape;
            this.btnCape.FlatAppearance.BorderSize = 0;
            this.btnCape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCape.Location = new System.Drawing.Point(12, 604);
            this.btnCape.Name = "btnCape";
            this.btnCape.Size = new System.Drawing.Size(60, 60);
            this.btnCape.TabIndex = 18;
            this.btnCape.UseVisualStyleBackColor = false;
            this.btnCape.Click += new System.EventHandler(this.btnCape_Click);
            // 
            // btnTiara
            // 
            this.btnTiara.BackColor = System.Drawing.Color.Transparent;
            this.btnTiara.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Tiara;
            this.btnTiara.FlatAppearance.BorderSize = 0;
            this.btnTiara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTiara.Location = new System.Drawing.Point(12, 538);
            this.btnTiara.Name = "btnTiara";
            this.btnTiara.Size = new System.Drawing.Size(60, 60);
            this.btnTiara.TabIndex = 17;
            this.btnTiara.UseVisualStyleBackColor = false;
            this.btnTiara.Click += new System.EventHandler(this.btnTiara_Click);
            // 
            // btnMask
            // 
            this.btnMask.BackColor = System.Drawing.Color.Transparent;
            this.btnMask.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.Halloweenmask2;
            this.btnMask.FlatAppearance.BorderSize = 0;
            this.btnMask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMask.Location = new System.Drawing.Point(12, 474);
            this.btnMask.Name = "btnMask";
            this.btnMask.Size = new System.Drawing.Size(60, 60);
            this.btnMask.TabIndex = 16;
            this.btnMask.UseVisualStyleBackColor = false;
            this.btnMask.Click += new System.EventHandler(this.btnMask_Click);
            // 
            // txtDamageIncreasePercent
            // 
            this.txtDamageIncreasePercent.Font = new System.Drawing.Font("Old English Text MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDamageIncreasePercent.Location = new System.Drawing.Point(33, 68);
            this.txtDamageIncreasePercent.Multiline = true;
            this.txtDamageIncreasePercent.Name = "txtDamageIncreasePercent";
            this.txtDamageIncreasePercent.Size = new System.Drawing.Size(153, 53);
            this.txtDamageIncreasePercent.TabIndex = 54;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Old English Text MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label14.Location = new System.Drawing.Point(33, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 23);
            this.label14.TabIndex = 55;
            this.label14.Text = "Custom % Buff";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Old English Text MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label15.Location = new System.Drawing.Point(29, 157);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(159, 23);
            this.label15.TabIndex = 56;
            this.label15.Text = "Custom % Debuff";
            // 
            // txtDamageDecreasePercent
            // 
            this.txtDamageDecreasePercent.Font = new System.Drawing.Font("Old English Text MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDamageDecreasePercent.Location = new System.Drawing.Point(33, 196);
            this.txtDamageDecreasePercent.Multiline = true;
            this.txtDamageDecreasePercent.Name = "txtDamageDecreasePercent";
            this.txtDamageDecreasePercent.Size = new System.Drawing.Size(153, 53);
            this.txtDamageDecreasePercent.TabIndex = 57;
            // 
            // btnTMboost
            // 
            this.btnTMboost.BackColor = System.Drawing.Color.Transparent;
            this.btnTMboost.BackgroundImage = global::DamageCalculatorGUI.Properties.Resources.mateboost;
            this.btnTMboost.FlatAppearance.BorderSize = 0;
            this.btnTMboost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTMboost.Location = new System.Drawing.Point(443, 526);
            this.btnTMboost.Name = "btnTMboost";
            this.btnTMboost.Size = new System.Drawing.Size(55, 55);
            this.btnTMboost.TabIndex = 58;
            this.btnTMboost.UseVisualStyleBackColor = false;
            this.btnTMboost.Click += new System.EventHandler(this.btnTMboost_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(844, 807);
            this.Controls.Add(this.btnTMboost);
            this.Controls.Add(this.txtDamageDecreasePercent);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtDamageIncreasePercent);
            this.Controls.Add(this.X5);
            this.Controls.Add(this.X4);
            this.Controls.Add(this.X3);
            this.Controls.Add(this.X2);
            this.Controls.Add(this.X1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.armor5);
            this.Controls.Add(this.armor4);
            this.Controls.Add(this.armor3);
            this.Controls.Add(this.armor2);
            this.Controls.Add(this.Armor1);
            this.Controls.Add(this.btnCboss);
            this.Controls.Add(this.btnCloyal);
            this.Controls.Add(this.btnWeak);
            this.Controls.Add(this.btnCharm);
            this.Controls.Add(this.btnWani);
            this.Controls.Add(this.btnDW);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnRR);
            this.Controls.Add(this.btnRG);
            this.Controls.Add(this.btnTurtB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAltar);
            this.Controls.Add(this.btnPet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTurtle);
            this.Controls.Add(this.btnFrog);
            this.Controls.Add(this.btnDrum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCrown);
            this.Controls.Add(this.btnCape);
            this.Controls.Add(this.btnTiara);
            this.Controls.Add(this.btnMask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboLevel);
            this.Controls.Add(this.comboRarity);
            this.Controls.Add(this.txtHeadshotCritDamage);
            this.Controls.Add(this.Enterbasedamage);
            this.Controls.Add(this.textBoxBaseDamage);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtHeadshotDamage);
            this.Controls.Add(this.txtCritDamage);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0D;
            this.Text = "PG3D Damage Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.X5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.X1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Armor1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void btnCalculate_Click(object sender, EventArgs e)
    {
        CalculateDamage();
    }

    private TextBox txtHeadshotCritDamage;

    private void txtHeadshotCritDamage_TextChanged(object sender, EventArgs e)
    {

    }

    private Button btnRG;
    private ComboBox comboRarity;
    private ComboBox comboLevel;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button btnMask;
    private Label label5;
    private Button btnPet;
    private Button btnAltar;
    private Label label4;
    private Button btnDrum;
    private Button btnFrog;
    private Button btnTurtle;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Button btnTurtB;
    private PictureBox Armor1;
    private PictureBox armor2;
    private PictureBox armor3;
    private PictureBox armor4;
    private PictureBox armor5;
    private Label label13;
    private bool isMaskSelected = false;
    private bool isTiaraSelected = false;
    private bool isCapeSelected = false;
    private bool isCrownSelected = false;
    private bool isDrumSelected = false;
    private bool isFrogSelected = false;
    private bool isTurtleSelected = false;
    private bool isPetSelected = false;
    private bool isAltarSelected = false;
    private bool isTurtBSelected = false;
    private bool isRRSelected = false;
    private bool isRGSelected = false;
    private bool isWaniSelected = false;
    private bool isCharmSelected = false;
    private bool isWeakSelected = false;
    private bool isCloyalSelected = false;
    private bool isCbossSelected = false;
    private bool isTMboostSelected = false;
    private bool isDWSelected = false;


    private void btnMask_Click(object sender, EventArgs e)
    {
        isMaskSelected = !isMaskSelected;

        if (isMaskSelected)
        {
            btnMask.BackColor = Color.Lime;
            selectedBuffs.Add("Mask");
        }
        else
        {
            btnMask.BackColor = Color.Transparent;
            selectedBuffs.Remove("Mask");
        }
        CalculateDamage();

    }

    private Button btnTiara;

    private void btnTiara_Click(object sender, EventArgs e)
    {
        isTiaraSelected = !isTiaraSelected;

        if (isTiaraSelected)
        {
            btnTiara.BackColor = Color.Lime;
            selectedBuffs.Add("Tiara");
        }
        else
        {
            btnTiara.BackColor = Color.Transparent;
            selectedBuffs.Remove("Tiara");
        }
        CalculateDamage();
    }

    private Button btnCape;
    
    private void btnCape_Click(object sender, EventArgs e)
    {
        isCapeSelected = !isCapeSelected;

        if (isCapeSelected)
        {
            btnCape.BackColor = Color.Lime;
            selectedBuffs.Add("Cape");
        }
        else
        {
            btnCape.BackColor = Color.Transparent;
            selectedBuffs.Remove("Cape");
        }
        CalculateDamage();
    }
    
    private Button btnCrown;

    private void btnCrown_Click(object sender, EventArgs e)
    {
        isCrownSelected = !isCrownSelected;

        if (isCrownSelected)
        {
            btnCrown.BackColor = Color.Lime;
            selectedBuffs.Add("Crown");
        }
        else
        {
            btnCrown.BackColor = Color.Transparent;
            selectedBuffs.Remove("Crown");
        }
        CalculateDamage();
    }

 

    private void btnDrum_Click(object sender, EventArgs e)
    {
        isDrumSelected = !isDrumSelected;

        if (isDrumSelected)
        {
            btnDrum.BackColor = Color.Lime;
            selectedBuffs.Add("Drum");
        }
        else
        {
            btnDrum.BackColor = Color.Transparent;
            selectedBuffs.Remove("Drum");
        }
        CalculateDamage();
    }

    private void btnFrog_Click(object sender, EventArgs e)
    {
        isFrogSelected = !isFrogSelected;

        if (isFrogSelected)
        {
            btnFrog.BackColor = Color.Lime;
            selectedBuffs.Add("Frog");
        }
        else
        {
            btnFrog.BackColor = Color.Transparent;
            selectedBuffs.Remove("Frog");
        }
        CalculateDamage();
    }

    private void btnTurtle_Click(object sender, EventArgs e)
    {
        isTurtleSelected = !isTurtleSelected;

        if (isTurtleSelected)
        {
            btnTurtle.BackColor = Color.Lime;
            selectedBuffs.Add("Turtle");
        }
        else
        {
            btnTurtle.BackColor = Color.Transparent;
            selectedBuffs.Remove("Turtle");
        }
        CalculateDamage();
    }

  
    
    private void btnPet_Click(object sender, EventArgs e)
    {
        isPetSelected = !isPetSelected;

        if (isPetSelected)
        {
            btnPet.BackColor = Color.Lime;
            selectedBuffs.Add("Pet");
        }
        else
        {
            btnPet.BackColor = Color.Transparent;
            selectedBuffs.Remove("Pet");
        }
        CalculateDamage();
    }

    private void btnAltar_Click(object sender, EventArgs e)
    {
        isAltarSelected = !isAltarSelected;

        if (isAltarSelected)
        {
            btnAltar.BackColor = Color.Lime;
            selectedBuffs.Add("Altar");
        }
        else
        {
            btnAltar.BackColor = Color.Transparent;
            selectedBuffs.Remove("Altar");
        }
        CalculateDamage();
    }
    private void btnTurtB_Click(object sender, EventArgs e)
    {
        isTurtBSelected = !isTurtBSelected;

        if (isTurtBSelected)
        {
            btnTurtB.BackColor = Color.Lime;
            selectedBuffs.Add("TurtB");
        }
        else
        {
            btnTurtB.BackColor = Color.Transparent;
            selectedBuffs.Remove("TurtB");
        }
        CalculateDamage();
    }



    private void btnRG_Click(object sender, EventArgs e)
    {
        isRGSelected = !isRGSelected;

        if (isRGSelected)
        {
            btnRG.BackColor = Color.Lime;
            selectedBuffs.Add("RG");
        }
        else
        {
            btnRG.BackColor = Color.Transparent;
            selectedBuffs.Remove("RG");
        }
        CalculateDamage();
    }

    private Button btnRR;

    private void btnRR_Click(object sender, EventArgs e)
    {
        isRRSelected = !isRRSelected;

        if (isRRSelected)
        {
            btnRR.BackColor = Color.Lime;
            selectedBuffs.Add("RR");
        }
        else
        {
            btnRR.BackColor = Color.Transparent;
            selectedBuffs.Remove("RR");
        }
        CalculateDamage();
    }

    private Label label12;
    private Button btnDW;
    private Button btnWani;
    
    private void btnWani_Click(object sender, EventArgs e)
    {
        isWaniSelected = !isWaniSelected;

        if (isWaniSelected)
        {
            btnWani.BackColor = Color.Lime;
            selectedBuffs.Add("Wani");
        }
        else
        {
            btnWani.BackColor = Color.Transparent;
            selectedBuffs.Remove("Wani");
        }
        CalculateDamage();
    }

    private Button btnCharm;
    
    private void btnCharm_Click(object sender, EventArgs e)
    {
        isCharmSelected = !isCharmSelected;

        if (isCharmSelected)
        {
            btnCharm.BackColor = Color.Lime;
            selectedBuffs.Add("Charm");
        }
        else
        {
            btnCharm.BackColor = Color.Transparent;
            selectedBuffs.Remove("Charm");
        }
        CalculateDamage();
    }

    private Button btnWeak;

    private void btnWeak_Click(object sender, EventArgs e)
    {
        isWeakSelected = !isWeakSelected;

        if (isWeakSelected)
        {
            btnWeak.BackColor = Color.Lime;
            selectedBuffs.Add("Weak");
        }
        else
        {
            btnWeak.BackColor = Color.Transparent;
            selectedBuffs.Remove("Weak");
        }
        CalculateDamage();
    }

    private void comboRarity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    private Button btnCloyal;

    private void btnCloyal_Click(object sender, EventArgs e)
    {
        isCloyalSelected = !isCloyalSelected;

        if (isCloyalSelected)
        {
            btnCloyal.BackColor = Color.Lime;
            selectedBuffs.Add("Cloyal");
        }
        else
        {
            btnCloyal.BackColor = Color.Transparent;
            selectedBuffs.Remove("Cloyal");
        }

        CalculateDamage();
    }

    private Button btnCboss;

    private void btnCboss_Click(object sender, EventArgs e)
    {
        isCbossSelected = !isCbossSelected;

        if (isCbossSelected)
        {
            btnCboss.BackColor = Color.Lime;
            selectedBuffs.Add("Cboss");
        }
        else
        {
            btnCboss.BackColor = Color.Transparent;
            selectedBuffs.Remove("Cboss");
        }
        CalculateDamage();

    }

    private PictureBox X1;
    private PictureBox X2;
    private PictureBox X3;
    private PictureBox X4;
    private PictureBox X5;
    private TextBox txtDamageIncreasePercent;
    private Label label14;
    private Label label15;
    private TextBox txtDamageDecreasePercent;
    private Button btnTMboost;

    private void btnTMboost_Click(object sender, EventArgs e)
    {

        isTMboostSelected = !isTMboostSelected;

        if (isTMboostSelected)
        {
            btnTMboost.BackColor = Color.Lime;
            selectedBuffs.Add("TM");
        }
        else
        {
            btnTMboost.BackColor = Color.Transparent;
            selectedBuffs.Remove("TM");
        }
        CalculateDamage();

    }

    private void btnDW_Click(object sender, EventArgs e)
    {

        isDWSelected = !isDWSelected;

        if (isDWSelected)
        {
            btnDW.BackColor = Color.Lime;
            selectedBuffs.Add("DW");
        }
        else
        {
            btnDW.BackColor = Color.Transparent;
            selectedBuffs.Remove("DW");
        }
        CalculateDamage();

    }

}