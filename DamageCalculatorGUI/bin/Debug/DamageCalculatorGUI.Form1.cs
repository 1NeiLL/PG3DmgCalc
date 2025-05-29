// DamageCalculatorGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// DamageCalculatorGUI.Form1
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DamageCalculatorGUI;
using DamageCalculatorGUI.Properties;

public class Form1 : Form
{
	private readonly Dictionary<string, double> buffs = new Dictionary<string, double>
	{
		{ "Mask", 1.07 },
		{ "Cape", 1.05 },
		{ "Tiara", 1.07 },
		{ "Pet", 1.05 },
		{ "Drum", 1.25 },
		{ "Turtle", 1.35 },
		{ "Frog", 1.3 },
		{ "Crown", 1.05 },
		{ "TurtSh", 0.4 },
		{ "RG", 0.5 },
		{ "RR", 0.75 },
		{ "DW", 0.7 },
		{ "Weak", 0.75 },
		{ "Charm", 0.5 },
		{ "I", 1.03 },
		{ "II", 1.05 },
		{ "III", 1.07 },
		{ "IV", 1.1 },
		{ "V", 1.13 },
		{ "VI", 1.2 },
		{ "VII", 1.265 },
		{ "VIII", 1.33 },
		{ "IX", 1.41 },
		{ "X", 1.49 },
		{ "L_I", 1.04 },
		{ "L_II", 1.05 },
		{ "L_III", 1.08 },
		{ "L_IV", 1.11 },
		{ "L_V", 1.15 },
		{ "L_VI", 1.23 },
		{ "L_VII", 1.3 },
		{ "L_VIII", 1.38 },
		{ "L_IX", 1.47 },
		{ "L_X", 1.57 },
		{ "E_I", 1.05 },
		{ "E_II", 1.07 },
		{ "E_III", 1.09 },
		{ "E_IV", 1.13 },
		{ "E_V", 1.18 },
		{ "E_VI", 1.27 },
		{ "E_VII", 1.36 },
		{ "E_VIII", 1.44 },
		{ "E_IX", 1.55 },
		{ "E_X", 1.66 },
		{ "R_I", 1.05 },
		{ "R_II", 1.08 },
		{ "R_III", 1.1 },
		{ "R_IV", 1.15 },
		{ "R_V", 1.2 },
		{ "R_VI", 1.29 },
		{ "R_VII", 1.38 },
		{ "R_VIII", 1.48 },
		{ "R_IX", 1.6 },
		{ "R_X", 1.72 },
		{ "C_I", 1.07 },
		{ "C_II", 1.11 },
		{ "C_III", 1.15 },
		{ "C_IV", 1.23 },
		{ "C_V", 1.31 },
		{ "C_VI", 1.47 },
		{ "C_VII", 1.63 },
		{ "C_VIII", 1.78 },
		{ "C_IX", 1.98 },
		{ "C_X", 2.18 }
	};

	private readonly Dictionary<string, double> headshotBuffs = new Dictionary<string, double> { { "Altar", 1.07 } };

	private readonly List<string> selectedBuffs = new List<string>();

	private IContainer components = null;

	private Label lblBaseDamage;

	private TextBox txtBaseDamage;

	private Label lblChooseBuffs;

	private Button btnI;

	private Button btnII;

	private Button btnIII;

	private Button btnIV;

	private Button btnV;

	private Button btnVI;

	private Button btnVII;

	private Button btnVIII;

	private Button btnIX;

	private Button btnX;

	private Label lblMythicModules;

	private Label lblWears;

	private Button btnMask;

	private Button btnCape;

	private Button btnTiara;

	private Button btnPet;

	private Button btnDrum;

	private PictureBox picMask;

	private PictureBox picCape;

	private PictureBox picTiara;

	private PictureBox picPet;

	private PictureBox picDrum;

	private Label lblResult;

	private Button btnCalculate;

	private Label label1;

	private Label label2;

	private Label txtHeadshotDamage;

	private Label label4;

	private Label Notice;

	private Button btnTurtle;

	private PictureBox PicTurtle;

	private PictureBox PicAltar;

	private Button btnAltar;

	private Label label3;

	private Button btnFrog;

	private PictureBox PicFrog;

	private Label txtCritDamage;

	private Label txtCritHeadDamage;

	private Label label7;

	private Label label8;

	private Label label6;

	private Label label5;

	private Label label9;

	private Label label10;

	private Label label11;

	private Label label12;

	private Label label13;

	private Label label14;

	private Button btnCrown;

	private PictureBox pictureBox1;

	private Label label15;

	private Label label16;

	private Label label17;

	private Button LbtnX;

	private Button LbtnIX;

	private Button LbtnVIII;

	private Button LbtnVII;

	private Button LbtnVI;

	private Button LbtnV;

	private Button LbtnIV;

	private Button LbtnIII;

	private Button LbtnII;

	private Button LbtnI;

	private Label label18;

	private Button RbtnX;

	private Button RbtnIX;

	private Button RbtnVIII;

	private Button RbtnVII;

	private Button RbtnVI;

	private Button RbtnV;

	private Button RbtnIV;

	private Button RbtnIII;

	private Button RbtnII;

	private Button RbtnI;

	private Label label19;

	private Button CbtnX;

	private Button CbtnIX;

	private Button CbtnVIII;

	private Button CbtnVII;

	private Button CbtnVI;

	private Button CbtnV;

	private Button CbtnIV;

	private Button CbtnIII;

	private Button CbtnII;

	private Button CbtnI;

	private Label label20;

	private Button EbtnX;

	private Button EbtnIX;

	private Button EbtnVIII;

	private Button EbtnVII;

	private Button EbtnVI;

	private Button EbtnV;

	private Button EbtnIV;

	private Button EbtnIII;

	private Button EbtnII;

	private Button EbtnI;

	private Label label21;

	private Label label22;

	private Label label23;

	private PictureBox pictureBox2;

	private Button btnTurtSh;

	private PictureBox pictureBox3;

	private PictureBox pictureBox4;

	private PictureBox pictureBox5;

	private Label label24;

	private Button btnRG;

	private Button btnRR;

	private Button btnDW;

	private Label label25;

	private Label label26;

	private Label label27;

	private Label label28;

	private Button btnWeak;

	private PictureBox pictureBox6;

	private PictureBox pictureBox7;

	private Button btnCharm;

	private Label label29;

	private Label label30;

	public Form1()
	{
		InitializeComponent();
	}

	private async void LoadResourcesAsync()
	{
		await Task.Delay(1000);
	}

	private void ToggleBuff(string buff, Button button)
	{
		if (selectedBuffs.Contains(buff))
		{
			selectedBuffs.Remove(buff);
			button.BackColor = SystemColors.GrayText;
		}
		else
		{
			selectedBuffs.Add(buff);
			button.BackColor = Color.LightGreen;
		}
	}

	private void btnMask_Click(object sender, EventArgs e)
	{
		ToggleBuff("Mask", btnMask);
	}

	private void btnCape_Click(object sender, EventArgs e)
	{
		ToggleBuff("Cape", btnCape);
	}

	private void btnTiara_Click(object sender, EventArgs e)
	{
		ToggleBuff("Tiara", btnTiara);
	}

	private void btnPet_Click(object sender, EventArgs e)
	{
		ToggleBuff("Pet", btnPet);
	}

	private void btnDrum_Click(object sender, EventArgs e)
	{
		ToggleBuff("Drum", btnDrum);
	}

	private void btnTurtle_Click(object sender, EventArgs e)
	{
		ToggleBuff("Turtle", btnTurtle);
	}

	private void btnFrog_Click(object sender, EventArgs e)
	{
		ToggleBuff("Frog", btnFrog);
	}

	private void btnCrown_Click(object sender, EventArgs e)
	{
		ToggleBuff("Crown", btnCrown);
	}

	private void btnTurtSh_Click(object sender, EventArgs e)
	{
		ToggleBuff("TurtSh", btnTurtSh);
	}

	private void btnRG_Click(object sender, EventArgs e)
	{
		ToggleBuff("RG", btnRG);
	}

	private void btnRR_Click(object sender, EventArgs e)
	{
		ToggleBuff("RR", btnRR);
	}

	private void btnDW_Click(object sender, EventArgs e)
	{
		ToggleBuff("DW", btnDW);
	}

	private void btnWeak_Click(object sender, EventArgs e)
	{
		ToggleBuff("Weak", btnWeak);
	}

	private void btnCharm_Click(object sender, EventArgs e)
	{
		ToggleBuff("Charm", btnCharm);
	}

	private void btnAltar_Click(object sender, EventArgs e)
	{
		ToggleBuff("Altar", btnAltar);
	}

	private void btnI_Click(object sender, EventArgs e)
	{
		ToggleBuff("I", btnI);
	}

	private void btnII_Click(object sender, EventArgs e)
	{
		ToggleBuff("II", btnII);
	}

	private void btnIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("III", btnIII);
	}

	private void btnIV_Click(object sender, EventArgs e)
	{
		ToggleBuff("IV", btnIV);
	}

	private void btnV_Click(object sender, EventArgs e)
	{
		ToggleBuff("V", btnV);
	}

	private void btnVI_Click(object sender, EventArgs e)
	{
		ToggleBuff("VI", btnVI);
	}

	private void btnVII_Click(object sender, EventArgs e)
	{
		ToggleBuff("VII", btnVII);
	}

	private void btnVIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("VIII", btnVIII);
	}

	private void btnIX_Click(object sender, EventArgs e)
	{
		ToggleBuff("IX", btnIX);
	}

	private void btnX_Click(object sender, EventArgs e)
	{
		ToggleBuff("X", btnX);
	}

	private void LbtnI_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_I", LbtnI);
	}

	private void LbtnII_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_II", LbtnII);
	}

	private void LbtnIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_III", LbtnIII);
	}

	private void LbtnIV_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_IV", LbtnIV);
	}

	private void LbtnV_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_V", LbtnV);
	}

	private void LbtnVI_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_VI", LbtnVI);
	}

	private void LbtnVII_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_VII", LbtnVII);
	}

	private void LbtnVIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_VIII", LbtnVIII);
	}

	private void LbtnIX_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_IX", LbtnIX);
	}

	private void LbtnX_Click(object sender, EventArgs e)
	{
		ToggleBuff("L_X", LbtnX);
	}

	private void EbtnI_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_I", EbtnI);
	}

	private void EbtnII_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_II", EbtnII);
	}

	private void EbtnIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_III", EbtnIII);
	}

	private void EbtnIV_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_IV", EbtnIV);
	}

	private void EbtnV_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_V", EbtnV);
	}

	private void EbtnVI_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_VI", EbtnVI);
	}

	private void EbtnVII_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_VII", EbtnVII);
	}

	private void EbtnVIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_VIII", EbtnVIII);
	}

	private void EbtnIX_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_IX", EbtnIX);
	}

	private void EbtnX_Click(object sender, EventArgs e)
	{
		ToggleBuff("E_X", EbtnX);
	}

	private void RbtnI_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_I", RbtnI);
	}

	private void RbtnII_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_II", RbtnII);
	}

	private void RbtnIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_III", RbtnIII);
	}

	private void RbtnIV_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_IV", RbtnIV);
	}

	private void RbtnV_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_V", RbtnV);
	}

	private void RbtnVI_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_VI", RbtnVI);
	}

	private void RbtnVII_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_VII", RbtnVII);
	}

	private void RbtnVIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_VIII", RbtnVIII);
	}

	private void RbtnIX_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_IX", RbtnIX);
	}

	private void RbtnX_Click(object sender, EventArgs e)
	{
		ToggleBuff("R_X", RbtnX);
	}

	private void CbtnI_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_I", CbtnI);
	}

	private void CbtnII_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_II", CbtnII);
	}

	private void CbtnIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_III", CbtnIII);
	}

	private void CbtnIV_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_IV", CbtnIV);
	}

	private void CbtnV_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_V", CbtnV);
	}

	private void CbtnVI_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_VI", CbtnVI);
	}

	private void CbtnVII_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_VII", CbtnVII);
	}

	private void CbtnVIII_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_VIII", CbtnVIII);
	}

	private void CbtnIX_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_IX", CbtnIX);
	}

	private void CbtnX_Click(object sender, EventArgs e)
	{
		ToggleBuff("C_X", CbtnX);
	}

	private void btnCalculate_Click(object sender, EventArgs e)
	{
		if (!double.TryParse(txtBaseDamage.Text, out var baseDamage))
		{
			MessageBox.Show("Enter a number bruh", "Buff Gauss Cannon pls", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		double finalDamage = baseDamage;
		foreach (string buff in selectedBuffs)
		{
			if (buffs.ContainsKey(buff))
			{
				finalDamage *= buffs[buff];
			}
		}
		double headshotDamage = finalDamage * 1.4;
		double critDamage = finalDamage * 1.4;
		double critheadDamage = critDamage * 1.4;
		foreach (string buff2 in selectedBuffs)
		{
			if (headshotBuffs.ContainsKey(buff2))
			{
				headshotDamage *= headshotBuffs[buff2];
				critheadDamage *= headshotBuffs[buff2];
			}
		}
		txtCritHeadDamage.Text = $"{critheadDamage:F2}";
		txtCritDamage.Text = $"{critDamage:F2}";
		txtHeadshotDamage.Text = $"{headshotDamage:F2}";
		lblResult.Text = $"{finalDamage:F2}";
	}

	private void textBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void Form1_Load(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DamageCalculatorGUI.Form1));
		this.lblBaseDamage = new System.Windows.Forms.Label();
		this.txtBaseDamage = new System.Windows.Forms.TextBox();
		this.lblChooseBuffs = new System.Windows.Forms.Label();
		this.btnI = new System.Windows.Forms.Button();
		this.btnII = new System.Windows.Forms.Button();
		this.btnIII = new System.Windows.Forms.Button();
		this.btnIV = new System.Windows.Forms.Button();
		this.btnV = new System.Windows.Forms.Button();
		this.btnVI = new System.Windows.Forms.Button();
		this.btnVII = new System.Windows.Forms.Button();
		this.btnVIII = new System.Windows.Forms.Button();
		this.btnIX = new System.Windows.Forms.Button();
		this.btnX = new System.Windows.Forms.Button();
		this.lblMythicModules = new System.Windows.Forms.Label();
		this.lblWears = new System.Windows.Forms.Label();
		this.btnMask = new System.Windows.Forms.Button();
		this.btnCape = new System.Windows.Forms.Button();
		this.btnTiara = new System.Windows.Forms.Button();
		this.btnPet = new System.Windows.Forms.Button();
		this.btnDrum = new System.Windows.Forms.Button();
		this.lblResult = new System.Windows.Forms.Label();
		this.btnCalculate = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.txtHeadshotDamage = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.Notice = new System.Windows.Forms.Label();
		this.btnTurtle = new System.Windows.Forms.Button();
		this.btnAltar = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.btnFrog = new System.Windows.Forms.Button();
		this.txtCritDamage = new System.Windows.Forms.Label();
		this.txtCritHeadDamage = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.btnCrown = new System.Windows.Forms.Button();
		this.label15 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.label17 = new System.Windows.Forms.Label();
		this.LbtnX = new System.Windows.Forms.Button();
		this.LbtnIX = new System.Windows.Forms.Button();
		this.LbtnVIII = new System.Windows.Forms.Button();
		this.LbtnVII = new System.Windows.Forms.Button();
		this.LbtnVI = new System.Windows.Forms.Button();
		this.LbtnV = new System.Windows.Forms.Button();
		this.LbtnIV = new System.Windows.Forms.Button();
		this.LbtnIII = new System.Windows.Forms.Button();
		this.LbtnII = new System.Windows.Forms.Button();
		this.LbtnI = new System.Windows.Forms.Button();
		this.label18 = new System.Windows.Forms.Label();
		this.RbtnX = new System.Windows.Forms.Button();
		this.RbtnIX = new System.Windows.Forms.Button();
		this.RbtnVIII = new System.Windows.Forms.Button();
		this.RbtnVII = new System.Windows.Forms.Button();
		this.RbtnVI = new System.Windows.Forms.Button();
		this.RbtnV = new System.Windows.Forms.Button();
		this.RbtnIV = new System.Windows.Forms.Button();
		this.RbtnIII = new System.Windows.Forms.Button();
		this.RbtnII = new System.Windows.Forms.Button();
		this.RbtnI = new System.Windows.Forms.Button();
		this.label19 = new System.Windows.Forms.Label();
		this.CbtnX = new System.Windows.Forms.Button();
		this.CbtnIX = new System.Windows.Forms.Button();
		this.CbtnVIII = new System.Windows.Forms.Button();
		this.CbtnVII = new System.Windows.Forms.Button();
		this.CbtnVI = new System.Windows.Forms.Button();
		this.CbtnV = new System.Windows.Forms.Button();
		this.CbtnIV = new System.Windows.Forms.Button();
		this.CbtnIII = new System.Windows.Forms.Button();
		this.CbtnII = new System.Windows.Forms.Button();
		this.CbtnI = new System.Windows.Forms.Button();
		this.label20 = new System.Windows.Forms.Label();
		this.EbtnX = new System.Windows.Forms.Button();
		this.EbtnIX = new System.Windows.Forms.Button();
		this.EbtnVIII = new System.Windows.Forms.Button();
		this.EbtnVII = new System.Windows.Forms.Button();
		this.EbtnVI = new System.Windows.Forms.Button();
		this.EbtnV = new System.Windows.Forms.Button();
		this.EbtnIV = new System.Windows.Forms.Button();
		this.EbtnIII = new System.Windows.Forms.Button();
		this.EbtnII = new System.Windows.Forms.Button();
		this.EbtnI = new System.Windows.Forms.Button();
		this.label21 = new System.Windows.Forms.Label();
		this.label22 = new System.Windows.Forms.Label();
		this.label23 = new System.Windows.Forms.Label();
		this.btnTurtSh = new System.Windows.Forms.Button();
		this.pictureBox5 = new System.Windows.Forms.PictureBox();
		this.pictureBox4 = new System.Windows.Forms.PictureBox();
		this.pictureBox3 = new System.Windows.Forms.PictureBox();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.PicFrog = new System.Windows.Forms.PictureBox();
		this.PicAltar = new System.Windows.Forms.PictureBox();
		this.PicTurtle = new System.Windows.Forms.PictureBox();
		this.picDrum = new System.Windows.Forms.PictureBox();
		this.picPet = new System.Windows.Forms.PictureBox();
		this.picTiara = new System.Windows.Forms.PictureBox();
		this.picCape = new System.Windows.Forms.PictureBox();
		this.picMask = new System.Windows.Forms.PictureBox();
		this.label24 = new System.Windows.Forms.Label();
		this.btnRG = new System.Windows.Forms.Button();
		this.btnRR = new System.Windows.Forms.Button();
		this.btnDW = new System.Windows.Forms.Button();
		this.label25 = new System.Windows.Forms.Label();
		this.label26 = new System.Windows.Forms.Label();
		this.label27 = new System.Windows.Forms.Label();
		this.label28 = new System.Windows.Forms.Label();
		this.btnWeak = new System.Windows.Forms.Button();
		this.pictureBox6 = new System.Windows.Forms.PictureBox();
		this.pictureBox7 = new System.Windows.Forms.PictureBox();
		this.btnCharm = new System.Windows.Forms.Button();
		this.label29 = new System.Windows.Forms.Label();
		this.label30 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PicFrog).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PicAltar).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.PicTurtle).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picDrum).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picPet).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picTiara).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picCape).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picMask).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).BeginInit();
		base.SuspendLayout();
		this.lblBaseDamage.AutoSize = true;
		this.lblBaseDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblBaseDamage.ForeColor = System.Drawing.Color.DarkTurquoise;
		this.lblBaseDamage.Location = new System.Drawing.Point(12, 9);
		this.lblBaseDamage.Name = "lblBaseDamage";
		this.lblBaseDamage.Size = new System.Drawing.Size(171, 20);
		this.lblBaseDamage.TabIndex = 0;
		this.lblBaseDamage.Text = "Enter Base Damage";
		this.txtBaseDamage.Location = new System.Drawing.Point(14, 44);
		this.txtBaseDamage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.txtBaseDamage.Name = "txtBaseDamage";
		this.txtBaseDamage.Size = new System.Drawing.Size(152, 20);
		this.txtBaseDamage.TabIndex = 1;
		this.txtBaseDamage.TextChanged += new System.EventHandler(textBox1_TextChanged);
		this.lblChooseBuffs.BackColor = System.Drawing.Color.Transparent;
		this.lblChooseBuffs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChooseBuffs.ForeColor = System.Drawing.Color.DarkTurquoise;
		this.lblChooseBuffs.Location = new System.Drawing.Point(345, 60);
		this.lblChooseBuffs.Name = "lblChooseBuffs";
		this.lblChooseBuffs.Size = new System.Drawing.Size(120, 22);
		this.lblChooseBuffs.TabIndex = 2;
		this.lblChooseBuffs.Text = "Choose Buffs";
		this.btnI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnI.Location = new System.Drawing.Point(159, 112);
		this.btnI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnI.Name = "btnI";
		this.btnI.Size = new System.Drawing.Size(40, 22);
		this.btnI.TabIndex = 4;
		this.btnI.Text = "I";
		this.btnI.UseVisualStyleBackColor = false;
		this.btnI.Click += new System.EventHandler(btnI_Click);
		this.btnII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnII.Location = new System.Drawing.Point(205, 112);
		this.btnII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnII.Name = "btnII";
		this.btnII.Size = new System.Drawing.Size(40, 22);
		this.btnII.TabIndex = 5;
		this.btnII.Text = "II";
		this.btnII.UseVisualStyleBackColor = false;
		this.btnII.Click += new System.EventHandler(btnII_Click);
		this.btnIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnIII.Location = new System.Drawing.Point(251, 112);
		this.btnIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnIII.Name = "btnIII";
		this.btnIII.Size = new System.Drawing.Size(40, 22);
		this.btnIII.TabIndex = 6;
		this.btnIII.Text = "III";
		this.btnIII.UseVisualStyleBackColor = false;
		this.btnIII.Click += new System.EventHandler(btnIII_Click);
		this.btnIV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnIV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnIV.Location = new System.Drawing.Point(297, 112);
		this.btnIV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnIV.Name = "btnIV";
		this.btnIV.Size = new System.Drawing.Size(40, 22);
		this.btnIV.TabIndex = 7;
		this.btnIV.Text = "IV";
		this.btnIV.UseVisualStyleBackColor = false;
		this.btnIV.Click += new System.EventHandler(btnIV_Click);
		this.btnV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnV.Location = new System.Drawing.Point(343, 112);
		this.btnV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnV.Name = "btnV";
		this.btnV.Size = new System.Drawing.Size(40, 22);
		this.btnV.TabIndex = 8;
		this.btnV.Text = "V";
		this.btnV.UseVisualStyleBackColor = false;
		this.btnV.Click += new System.EventHandler(btnV_Click);
		this.btnVI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnVI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnVI.Location = new System.Drawing.Point(389, 112);
		this.btnVI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnVI.Name = "btnVI";
		this.btnVI.Size = new System.Drawing.Size(40, 22);
		this.btnVI.TabIndex = 9;
		this.btnVI.Text = "VI";
		this.btnVI.UseVisualStyleBackColor = false;
		this.btnVI.Click += new System.EventHandler(btnVI_Click);
		this.btnVII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnVII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnVII.Location = new System.Drawing.Point(435, 112);
		this.btnVII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnVII.Name = "btnVII";
		this.btnVII.Size = new System.Drawing.Size(40, 22);
		this.btnVII.TabIndex = 10;
		this.btnVII.Text = "VII";
		this.btnVII.UseVisualStyleBackColor = false;
		this.btnVII.Click += new System.EventHandler(btnVII_Click);
		this.btnVIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnVIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnVIII.Location = new System.Drawing.Point(481, 112);
		this.btnVIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnVIII.Name = "btnVIII";
		this.btnVIII.Size = new System.Drawing.Size(40, 22);
		this.btnVIII.TabIndex = 11;
		this.btnVIII.Text = "VIII";
		this.btnVIII.UseVisualStyleBackColor = false;
		this.btnVIII.Click += new System.EventHandler(btnVIII_Click);
		this.btnIX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnIX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnIX.Location = new System.Drawing.Point(527, 112);
		this.btnIX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnIX.Name = "btnIX";
		this.btnIX.Size = new System.Drawing.Size(40, 22);
		this.btnIX.TabIndex = 12;
		this.btnIX.Text = "IX";
		this.btnIX.UseVisualStyleBackColor = false;
		this.btnIX.Click += new System.EventHandler(btnIX_Click);
		this.btnX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnX.Location = new System.Drawing.Point(573, 112);
		this.btnX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnX.Name = "btnX";
		this.btnX.Size = new System.Drawing.Size(40, 22);
		this.btnX.TabIndex = 13;
		this.btnX.Text = "X";
		this.btnX.UseVisualStyleBackColor = false;
		this.btnX.Click += new System.EventHandler(btnX_Click);
		this.lblMythicModules.AutoSize = true;
		this.lblMythicModules.BackColor = System.Drawing.Color.Transparent;
		this.lblMythicModules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMythicModules.ForeColor = System.Drawing.Color.DarkOrchid;
		this.lblMythicModules.Location = new System.Drawing.Point(5, 112);
		this.lblMythicModules.Name = "lblMythicModules";
		this.lblMythicModules.Size = new System.Drawing.Size(118, 20);
		this.lblMythicModules.TabIndex = 14;
		this.lblMythicModules.Text = "Mythic Modules";
		this.lblWears.AutoSize = true;
		this.lblWears.BackColor = System.Drawing.Color.Transparent;
		this.lblWears.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblWears.ForeColor = System.Drawing.Color.DarkTurquoise;
		this.lblWears.Location = new System.Drawing.Point(155, 286);
		this.lblWears.Name = "lblWears";
		this.lblWears.Size = new System.Drawing.Size(60, 20);
		this.lblWears.TabIndex = 15;
		this.lblWears.Text = "Wears";
		this.btnMask.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnMask.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnMask.Location = new System.Drawing.Point(128, 319);
		this.btnMask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnMask.Name = "btnMask";
		this.btnMask.Size = new System.Drawing.Size(55, 34);
		this.btnMask.TabIndex = 16;
		this.btnMask.Text = "Mask";
		this.btnMask.UseVisualStyleBackColor = false;
		this.btnMask.Click += new System.EventHandler(btnMask_Click);
		this.btnCape.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnCape.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnCape.Location = new System.Drawing.Point(128, 383);
		this.btnCape.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnCape.Name = "btnCape";
		this.btnCape.Size = new System.Drawing.Size(55, 34);
		this.btnCape.TabIndex = 17;
		this.btnCape.Text = "Editor Cape";
		this.btnCape.UseVisualStyleBackColor = false;
		this.btnCape.Click += new System.EventHandler(btnCape_Click);
		this.btnTiara.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnTiara.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnTiara.Location = new System.Drawing.Point(128, 447);
		this.btnTiara.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnTiara.Name = "btnTiara";
		this.btnTiara.Size = new System.Drawing.Size(55, 34);
		this.btnTiara.TabIndex = 18;
		this.btnTiara.Text = "Tiara";
		this.btnTiara.UseVisualStyleBackColor = false;
		this.btnTiara.Click += new System.EventHandler(btnTiara_Click);
		this.btnPet.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnPet.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnPet.Location = new System.Drawing.Point(334, 320);
		this.btnPet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnPet.Name = "btnPet";
		this.btnPet.Size = new System.Drawing.Size(55, 34);
		this.btnPet.TabIndex = 19;
		this.btnPet.Text = "Cookie Pet";
		this.btnPet.UseVisualStyleBackColor = false;
		this.btnPet.Click += new System.EventHandler(btnPet_Click);
		this.btnDrum.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnDrum.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnDrum.Location = new System.Drawing.Point(126, 610);
		this.btnDrum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnDrum.Name = "btnDrum";
		this.btnDrum.Size = new System.Drawing.Size(55, 34);
		this.btnDrum.TabIndex = 20;
		this.btnDrum.Text = "Drum";
		this.btnDrum.UseVisualStyleBackColor = false;
		this.btnDrum.Click += new System.EventHandler(btnDrum_Click);
		this.lblResult.BackColor = System.Drawing.SystemColors.ButtonHighlight;
		this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblResult.Location = new System.Drawing.Point(718, 302);
		this.lblResult.Name = "lblResult";
		this.lblResult.Size = new System.Drawing.Size(127, 22);
		this.lblResult.TabIndex = 27;
		this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
		this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCalculate.Location = new System.Drawing.Point(664, 250);
		this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnCalculate.Name = "btnCalculate";
		this.btnCalculate.Size = new System.Drawing.Size(208, 37);
		this.btnCalculate.TabIndex = 28;
		this.btnCalculate.Text = "Calculate Final Damage";
		this.btnCalculate.UseVisualStyleBackColor = false;
		this.btnCalculate.Click += new System.EventHandler(btnCalculate_Click);
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
		this.label1.Location = new System.Drawing.Point(155, 577);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(78, 20);
		this.label1.TabIndex = 29;
		this.label1.Text = "Gadgets";
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.label2.Location = new System.Drawing.Point(663, 302);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(49, 22);
		this.label2.TabIndex = 30;
		this.label2.Text = "Base";
		this.txtHeadshotDamage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
		this.txtHeadshotDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtHeadshotDamage.Location = new System.Drawing.Point(718, 331);
		this.txtHeadshotDamage.Name = "txtHeadshotDamage";
		this.txtHeadshotDamage.Size = new System.Drawing.Size(127, 22);
		this.txtHeadshotDamage.TabIndex = 31;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.label4.Location = new System.Drawing.Point(629, 331);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(83, 22);
		this.label4.TabIndex = 32;
		this.label4.Text = "Headshot";
		this.Notice.AutoSize = true;
		this.Notice.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
		this.Notice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Notice.Location = new System.Drawing.Point(583, 860);
		this.Notice.Name = "Notice";
		this.Notice.Size = new System.Drawing.Size(289, 16);
		this.Notice.TabIndex = 33;
		this.Notice.Text = "**PG3D Rounds damage up in damage display";
		this.btnTurtle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnTurtle.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnTurtle.Location = new System.Drawing.Point(126, 674);
		this.btnTurtle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnTurtle.Name = "btnTurtle";
		this.btnTurtle.Size = new System.Drawing.Size(55, 34);
		this.btnTurtle.TabIndex = 34;
		this.btnTurtle.Text = "Turtle Shell";
		this.btnTurtle.UseVisualStyleBackColor = false;
		this.btnTurtle.Click += new System.EventHandler(btnTurtle_Click);
		this.btnAltar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnAltar.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnAltar.Location = new System.Drawing.Point(334, 381);
		this.btnAltar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnAltar.Name = "btnAltar";
		this.btnAltar.Size = new System.Drawing.Size(55, 34);
		this.btnAltar.TabIndex = 37;
		this.btnAltar.Text = "Hunter's Altar";
		this.btnAltar.UseVisualStyleBackColor = false;
		this.btnAltar.Click += new System.EventHandler(btnAltar_Click);
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.DarkTurquoise;
		this.label3.Location = new System.Drawing.Point(371, 283);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(54, 20);
		this.label3.TabIndex = 38;
		this.label3.Text = "Other";
		this.btnFrog.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnFrog.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnFrog.Location = new System.Drawing.Point(126, 746);
		this.btnFrog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnFrog.Name = "btnFrog";
		this.btnFrog.Size = new System.Drawing.Size(55, 34);
		this.btnFrog.TabIndex = 39;
		this.btnFrog.Text = "Hypno Frog";
		this.btnFrog.UseVisualStyleBackColor = false;
		this.btnFrog.Click += new System.EventHandler(btnFrog_Click);
		this.txtCritDamage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
		this.txtCritDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtCritDamage.Location = new System.Drawing.Point(718, 361);
		this.txtCritDamage.Name = "txtCritDamage";
		this.txtCritDamage.Size = new System.Drawing.Size(127, 22);
		this.txtCritDamage.TabIndex = 41;
		this.txtCritHeadDamage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
		this.txtCritHeadDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtCritHeadDamage.Location = new System.Drawing.Point(718, 395);
		this.txtCritHeadDamage.Name = "txtCritHeadDamage";
		this.txtCritHeadDamage.Size = new System.Drawing.Size(127, 22);
		this.txtCritHeadDamage.TabIndex = 42;
		this.label7.BackColor = System.Drawing.Color.Transparent;
		this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.label7.Location = new System.Drawing.Point(678, 361);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(34, 22);
		this.label7.TabIndex = 43;
		this.label7.Text = "Crit";
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.label8.Location = new System.Drawing.Point(603, 395);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(109, 22);
		this.label8.TabIndex = 44;
		this.label8.Text = "Headshot Crit";
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.ForeColor = System.Drawing.Color.Red;
		this.label6.Location = new System.Drawing.Point(262, 321);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(27, 19);
		this.label6.TabIndex = 46;
		this.label6.Text = "7%";
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.ForeColor = System.Drawing.Color.Red;
		this.label5.Location = new System.Drawing.Point(262, 450);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(27, 19);
		this.label5.TabIndex = 47;
		this.label5.Text = "7%";
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.ForeColor = System.Drawing.Color.Red;
		this.label9.Location = new System.Drawing.Point(459, 389);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(48, 19);
		this.label9.TabIndex = 48;
		this.label9.Text = "7% HS";
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label10.ForeColor = System.Drawing.Color.Red;
		this.label10.Location = new System.Drawing.Point(262, 383);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(28, 19);
		this.label10.TabIndex = 49;
		this.label10.Text = "5%";
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label11.ForeColor = System.Drawing.Color.Red;
		this.label11.Location = new System.Drawing.Point(459, 334);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(28, 19);
		this.label11.TabIndex = 50;
		this.label11.Text = "5%";
		this.label12.AutoSize = true;
		this.label12.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label12.ForeColor = System.Drawing.Color.Red;
		this.label12.Location = new System.Drawing.Point(262, 610);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(36, 19);
		this.label12.TabIndex = 51;
		this.label12.Text = "25%";
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label13.ForeColor = System.Drawing.Color.Red;
		this.label13.Location = new System.Drawing.Point(262, 674);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(36, 19);
		this.label13.TabIndex = 52;
		this.label13.Text = "35%";
		this.label14.AutoSize = true;
		this.label14.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label14.ForeColor = System.Drawing.Color.Red;
		this.label14.Location = new System.Drawing.Point(262, 737);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(36, 19);
		this.label14.TabIndex = 53;
		this.label14.Text = "30%";
		this.btnCrown.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnCrown.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnCrown.Location = new System.Drawing.Point(128, 512);
		this.btnCrown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnCrown.Name = "btnCrown";
		this.btnCrown.Size = new System.Drawing.Size(55, 34);
		this.btnCrown.TabIndex = 54;
		this.btnCrown.Text = "Crown";
		this.btnCrown.UseVisualStyleBackColor = false;
		this.btnCrown.Click += new System.EventHandler(btnCrown_Click);
		this.label15.AutoSize = true;
		this.label15.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label15.ForeColor = System.Drawing.Color.Red;
		this.label15.Location = new System.Drawing.Point(262, 512);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(28, 19);
		this.label15.TabIndex = 56;
		this.label15.Text = "5%";
		this.label16.AutoSize = true;
		this.label16.BackColor = System.Drawing.Color.White;
		this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label16.Location = new System.Drawing.Point(237, 13);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(340, 16);
		this.label16.TabIndex = 57;
		this.label16.Text = "Please refer to the wiki.gg for damage stats pg3d.wiki.gg";
		this.label17.AutoSize = true;
		this.label17.BackColor = System.Drawing.Color.Transparent;
		this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label17.ForeColor = System.Drawing.Color.Tomato;
		this.label17.Location = new System.Drawing.Point(5, 142);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(148, 20);
		this.label17.TabIndex = 68;
		this.label17.Text = "Legendary Modules";
		this.LbtnX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnX.Location = new System.Drawing.Point(573, 142);
		this.LbtnX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnX.Name = "LbtnX";
		this.LbtnX.Size = new System.Drawing.Size(40, 22);
		this.LbtnX.TabIndex = 67;
		this.LbtnX.Text = "X";
		this.LbtnX.UseVisualStyleBackColor = false;
		this.LbtnX.Click += new System.EventHandler(LbtnX_Click);
		this.LbtnIX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnIX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnIX.Location = new System.Drawing.Point(527, 142);
		this.LbtnIX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnIX.Name = "LbtnIX";
		this.LbtnIX.Size = new System.Drawing.Size(40, 22);
		this.LbtnIX.TabIndex = 66;
		this.LbtnIX.Text = "IX";
		this.LbtnIX.UseVisualStyleBackColor = false;
		this.LbtnIX.Click += new System.EventHandler(LbtnIX_Click);
		this.LbtnVIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnVIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnVIII.Location = new System.Drawing.Point(481, 142);
		this.LbtnVIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnVIII.Name = "LbtnVIII";
		this.LbtnVIII.Size = new System.Drawing.Size(40, 22);
		this.LbtnVIII.TabIndex = 65;
		this.LbtnVIII.Text = "VIII";
		this.LbtnVIII.UseVisualStyleBackColor = false;
		this.LbtnVIII.Click += new System.EventHandler(LbtnVIII_Click);
		this.LbtnVII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnVII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnVII.Location = new System.Drawing.Point(435, 142);
		this.LbtnVII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnVII.Name = "LbtnVII";
		this.LbtnVII.Size = new System.Drawing.Size(40, 22);
		this.LbtnVII.TabIndex = 64;
		this.LbtnVII.Text = "VII";
		this.LbtnVII.UseVisualStyleBackColor = false;
		this.LbtnVII.Click += new System.EventHandler(LbtnVII_Click);
		this.LbtnVI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnVI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnVI.Location = new System.Drawing.Point(389, 142);
		this.LbtnVI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnVI.Name = "LbtnVI";
		this.LbtnVI.Size = new System.Drawing.Size(40, 22);
		this.LbtnVI.TabIndex = 63;
		this.LbtnVI.Text = "VI";
		this.LbtnVI.UseVisualStyleBackColor = false;
		this.LbtnVI.Click += new System.EventHandler(LbtnVI_Click);
		this.LbtnV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnV.Location = new System.Drawing.Point(343, 142);
		this.LbtnV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnV.Name = "LbtnV";
		this.LbtnV.Size = new System.Drawing.Size(40, 22);
		this.LbtnV.TabIndex = 62;
		this.LbtnV.Text = "V";
		this.LbtnV.UseVisualStyleBackColor = false;
		this.LbtnV.Click += new System.EventHandler(LbtnV_Click);
		this.LbtnIV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnIV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnIV.Location = new System.Drawing.Point(297, 142);
		this.LbtnIV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnIV.Name = "LbtnIV";
		this.LbtnIV.Size = new System.Drawing.Size(40, 22);
		this.LbtnIV.TabIndex = 61;
		this.LbtnIV.Text = "IV";
		this.LbtnIV.UseVisualStyleBackColor = false;
		this.LbtnIV.Click += new System.EventHandler(LbtnIV_Click);
		this.LbtnIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnIII.Location = new System.Drawing.Point(251, 142);
		this.LbtnIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnIII.Name = "LbtnIII";
		this.LbtnIII.Size = new System.Drawing.Size(40, 22);
		this.LbtnIII.TabIndex = 60;
		this.LbtnIII.Text = "III";
		this.LbtnIII.UseVisualStyleBackColor = false;
		this.LbtnIII.Click += new System.EventHandler(LbtnIII_Click);
		this.LbtnII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnII.Location = new System.Drawing.Point(205, 142);
		this.LbtnII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnII.Name = "LbtnII";
		this.LbtnII.Size = new System.Drawing.Size(40, 22);
		this.LbtnII.TabIndex = 59;
		this.LbtnII.Text = "II";
		this.LbtnII.UseVisualStyleBackColor = false;
		this.LbtnII.Click += new System.EventHandler(LbtnII_Click);
		this.LbtnI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.LbtnI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.LbtnI.Location = new System.Drawing.Point(159, 142);
		this.LbtnI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.LbtnI.Name = "LbtnI";
		this.LbtnI.Size = new System.Drawing.Size(40, 22);
		this.LbtnI.TabIndex = 58;
		this.LbtnI.Text = "I";
		this.LbtnI.UseVisualStyleBackColor = false;
		this.LbtnI.Click += new System.EventHandler(LbtnI_Click);
		this.label18.AutoSize = true;
		this.label18.BackColor = System.Drawing.Color.Transparent;
		this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label18.ForeColor = System.Drawing.Color.DodgerBlue;
		this.label18.Location = new System.Drawing.Point(5, 203);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(108, 20);
		this.label18.TabIndex = 79;
		this.label18.Text = "Rare Modules";
		this.RbtnX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnX.Location = new System.Drawing.Point(573, 203);
		this.RbtnX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnX.Name = "RbtnX";
		this.RbtnX.Size = new System.Drawing.Size(40, 22);
		this.RbtnX.TabIndex = 78;
		this.RbtnX.Text = "X";
		this.RbtnX.UseVisualStyleBackColor = false;
		this.RbtnX.Click += new System.EventHandler(RbtnX_Click);
		this.RbtnIX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnIX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnIX.Location = new System.Drawing.Point(527, 203);
		this.RbtnIX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnIX.Name = "RbtnIX";
		this.RbtnIX.Size = new System.Drawing.Size(40, 22);
		this.RbtnIX.TabIndex = 77;
		this.RbtnIX.Text = "IX";
		this.RbtnIX.UseVisualStyleBackColor = false;
		this.RbtnIX.Click += new System.EventHandler(RbtnIX_Click);
		this.RbtnVIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnVIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnVIII.Location = new System.Drawing.Point(481, 203);
		this.RbtnVIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnVIII.Name = "RbtnVIII";
		this.RbtnVIII.Size = new System.Drawing.Size(40, 22);
		this.RbtnVIII.TabIndex = 76;
		this.RbtnVIII.Text = "VIII";
		this.RbtnVIII.UseVisualStyleBackColor = false;
		this.RbtnVIII.Click += new System.EventHandler(RbtnVIII_Click);
		this.RbtnVII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnVII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnVII.Location = new System.Drawing.Point(435, 203);
		this.RbtnVII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnVII.Name = "RbtnVII";
		this.RbtnVII.Size = new System.Drawing.Size(40, 22);
		this.RbtnVII.TabIndex = 75;
		this.RbtnVII.Text = "VII";
		this.RbtnVII.UseVisualStyleBackColor = false;
		this.RbtnVII.Click += new System.EventHandler(RbtnVII_Click);
		this.RbtnVI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnVI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnVI.Location = new System.Drawing.Point(389, 203);
		this.RbtnVI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnVI.Name = "RbtnVI";
		this.RbtnVI.Size = new System.Drawing.Size(40, 22);
		this.RbtnVI.TabIndex = 74;
		this.RbtnVI.Text = "VI";
		this.RbtnVI.UseVisualStyleBackColor = false;
		this.RbtnVI.Click += new System.EventHandler(RbtnVI_Click);
		this.RbtnV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnV.Location = new System.Drawing.Point(343, 203);
		this.RbtnV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnV.Name = "RbtnV";
		this.RbtnV.Size = new System.Drawing.Size(40, 22);
		this.RbtnV.TabIndex = 73;
		this.RbtnV.Text = "V";
		this.RbtnV.UseVisualStyleBackColor = false;
		this.RbtnV.Click += new System.EventHandler(RbtnV_Click);
		this.RbtnIV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnIV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnIV.Location = new System.Drawing.Point(297, 203);
		this.RbtnIV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnIV.Name = "RbtnIV";
		this.RbtnIV.Size = new System.Drawing.Size(40, 22);
		this.RbtnIV.TabIndex = 72;
		this.RbtnIV.Text = "IV";
		this.RbtnIV.UseVisualStyleBackColor = false;
		this.RbtnIV.Click += new System.EventHandler(RbtnIV_Click);
		this.RbtnIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnIII.Location = new System.Drawing.Point(251, 203);
		this.RbtnIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnIII.Name = "RbtnIII";
		this.RbtnIII.Size = new System.Drawing.Size(40, 22);
		this.RbtnIII.TabIndex = 71;
		this.RbtnIII.Text = "III";
		this.RbtnIII.UseVisualStyleBackColor = false;
		this.RbtnIII.Click += new System.EventHandler(RbtnIII_Click);
		this.RbtnII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnII.Location = new System.Drawing.Point(205, 203);
		this.RbtnII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnII.Name = "RbtnII";
		this.RbtnII.Size = new System.Drawing.Size(40, 22);
		this.RbtnII.TabIndex = 70;
		this.RbtnII.Text = "II";
		this.RbtnII.UseVisualStyleBackColor = false;
		this.RbtnII.Click += new System.EventHandler(RbtnII_Click);
		this.RbtnI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.RbtnI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.RbtnI.Location = new System.Drawing.Point(159, 203);
		this.RbtnI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.RbtnI.Name = "RbtnI";
		this.RbtnI.Size = new System.Drawing.Size(40, 22);
		this.RbtnI.TabIndex = 69;
		this.RbtnI.Text = "I";
		this.RbtnI.UseVisualStyleBackColor = false;
		this.RbtnI.Click += new System.EventHandler(RbtnI_Click);
		this.label19.AutoSize = true;
		this.label19.BackColor = System.Drawing.Color.Transparent;
		this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label19.ForeColor = System.Drawing.SystemColors.Control;
		this.label19.Location = new System.Drawing.Point(5, 235);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(137, 20);
		this.label19.TabIndex = 90;
		this.label19.Text = "Common Modules";
		this.CbtnX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnX.Location = new System.Drawing.Point(573, 235);
		this.CbtnX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnX.Name = "CbtnX";
		this.CbtnX.Size = new System.Drawing.Size(40, 22);
		this.CbtnX.TabIndex = 89;
		this.CbtnX.Text = "X";
		this.CbtnX.UseVisualStyleBackColor = false;
		this.CbtnX.Click += new System.EventHandler(CbtnX_Click);
		this.CbtnIX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnIX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnIX.Location = new System.Drawing.Point(527, 235);
		this.CbtnIX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnIX.Name = "CbtnIX";
		this.CbtnIX.Size = new System.Drawing.Size(40, 22);
		this.CbtnIX.TabIndex = 88;
		this.CbtnIX.Text = "IX";
		this.CbtnIX.UseVisualStyleBackColor = false;
		this.CbtnIX.Click += new System.EventHandler(CbtnIX_Click);
		this.CbtnVIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnVIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnVIII.Location = new System.Drawing.Point(481, 235);
		this.CbtnVIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnVIII.Name = "CbtnVIII";
		this.CbtnVIII.Size = new System.Drawing.Size(40, 22);
		this.CbtnVIII.TabIndex = 87;
		this.CbtnVIII.Text = "VIII";
		this.CbtnVIII.UseVisualStyleBackColor = false;
		this.CbtnVIII.Click += new System.EventHandler(CbtnVIII_Click);
		this.CbtnVII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnVII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnVII.Location = new System.Drawing.Point(435, 235);
		this.CbtnVII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnVII.Name = "CbtnVII";
		this.CbtnVII.Size = new System.Drawing.Size(40, 22);
		this.CbtnVII.TabIndex = 86;
		this.CbtnVII.Text = "VII";
		this.CbtnVII.UseVisualStyleBackColor = false;
		this.CbtnVII.Click += new System.EventHandler(CbtnVII_Click);
		this.CbtnVI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnVI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnVI.Location = new System.Drawing.Point(389, 235);
		this.CbtnVI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnVI.Name = "CbtnVI";
		this.CbtnVI.Size = new System.Drawing.Size(40, 22);
		this.CbtnVI.TabIndex = 85;
		this.CbtnVI.Text = "VI";
		this.CbtnVI.UseVisualStyleBackColor = false;
		this.CbtnVI.Click += new System.EventHandler(CbtnVI_Click);
		this.CbtnV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnV.Location = new System.Drawing.Point(343, 235);
		this.CbtnV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnV.Name = "CbtnV";
		this.CbtnV.Size = new System.Drawing.Size(40, 22);
		this.CbtnV.TabIndex = 84;
		this.CbtnV.Text = "V";
		this.CbtnV.UseVisualStyleBackColor = false;
		this.CbtnV.Click += new System.EventHandler(CbtnV_Click);
		this.CbtnIV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnIV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnIV.Location = new System.Drawing.Point(297, 235);
		this.CbtnIV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnIV.Name = "CbtnIV";
		this.CbtnIV.Size = new System.Drawing.Size(40, 22);
		this.CbtnIV.TabIndex = 83;
		this.CbtnIV.Text = "IV";
		this.CbtnIV.UseVisualStyleBackColor = false;
		this.CbtnIV.Click += new System.EventHandler(CbtnIV_Click);
		this.CbtnIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnIII.Location = new System.Drawing.Point(251, 235);
		this.CbtnIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnIII.Name = "CbtnIII";
		this.CbtnIII.Size = new System.Drawing.Size(40, 22);
		this.CbtnIII.TabIndex = 82;
		this.CbtnIII.Text = "III";
		this.CbtnIII.UseVisualStyleBackColor = false;
		this.CbtnIII.Click += new System.EventHandler(CbtnIII_Click);
		this.CbtnII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnII.Location = new System.Drawing.Point(205, 235);
		this.CbtnII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnII.Name = "CbtnII";
		this.CbtnII.Size = new System.Drawing.Size(40, 22);
		this.CbtnII.TabIndex = 81;
		this.CbtnII.Text = "II";
		this.CbtnII.UseVisualStyleBackColor = false;
		this.CbtnII.Click += new System.EventHandler(CbtnII_Click);
		this.CbtnI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.CbtnI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.CbtnI.Location = new System.Drawing.Point(159, 235);
		this.CbtnI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.CbtnI.Name = "CbtnI";
		this.CbtnI.Size = new System.Drawing.Size(40, 22);
		this.CbtnI.TabIndex = 80;
		this.CbtnI.Text = "I";
		this.CbtnI.UseVisualStyleBackColor = false;
		this.CbtnI.Click += new System.EventHandler(CbtnI_Click);
		this.label20.AutoSize = true;
		this.label20.BackColor = System.Drawing.Color.Transparent;
		this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label20.ForeColor = System.Drawing.Color.Gold;
		this.label20.Location = new System.Drawing.Point(5, 174);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(104, 20);
		this.label20.TabIndex = 101;
		this.label20.Text = "Epic Modules";
		this.EbtnX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnX.Location = new System.Drawing.Point(573, 172);
		this.EbtnX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnX.Name = "EbtnX";
		this.EbtnX.Size = new System.Drawing.Size(40, 22);
		this.EbtnX.TabIndex = 100;
		this.EbtnX.Text = "X";
		this.EbtnX.UseVisualStyleBackColor = false;
		this.EbtnX.Click += new System.EventHandler(EbtnX_Click);
		this.EbtnIX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnIX.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnIX.Location = new System.Drawing.Point(527, 172);
		this.EbtnIX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnIX.Name = "EbtnIX";
		this.EbtnIX.Size = new System.Drawing.Size(40, 22);
		this.EbtnIX.TabIndex = 99;
		this.EbtnIX.Text = "IX";
		this.EbtnIX.UseVisualStyleBackColor = false;
		this.EbtnIX.Click += new System.EventHandler(EbtnIX_Click);
		this.EbtnVIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnVIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnVIII.Location = new System.Drawing.Point(481, 172);
		this.EbtnVIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnVIII.Name = "EbtnVIII";
		this.EbtnVIII.Size = new System.Drawing.Size(40, 22);
		this.EbtnVIII.TabIndex = 98;
		this.EbtnVIII.Text = "VIII";
		this.EbtnVIII.UseVisualStyleBackColor = false;
		this.EbtnVIII.Click += new System.EventHandler(EbtnVIII_Click);
		this.EbtnVII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnVII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnVII.Location = new System.Drawing.Point(435, 172);
		this.EbtnVII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnVII.Name = "EbtnVII";
		this.EbtnVII.Size = new System.Drawing.Size(40, 22);
		this.EbtnVII.TabIndex = 97;
		this.EbtnVII.Text = "VII";
		this.EbtnVII.UseVisualStyleBackColor = false;
		this.EbtnVII.Click += new System.EventHandler(EbtnVII_Click);
		this.EbtnVI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnVI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnVI.Location = new System.Drawing.Point(389, 172);
		this.EbtnVI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnVI.Name = "EbtnVI";
		this.EbtnVI.Size = new System.Drawing.Size(40, 22);
		this.EbtnVI.TabIndex = 96;
		this.EbtnVI.Text = "VI";
		this.EbtnVI.UseVisualStyleBackColor = false;
		this.EbtnVI.Click += new System.EventHandler(EbtnVI_Click);
		this.EbtnV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnV.Location = new System.Drawing.Point(343, 172);
		this.EbtnV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnV.Name = "EbtnV";
		this.EbtnV.Size = new System.Drawing.Size(40, 22);
		this.EbtnV.TabIndex = 95;
		this.EbtnV.Text = "V";
		this.EbtnV.UseVisualStyleBackColor = false;
		this.EbtnV.Click += new System.EventHandler(EbtnV_Click);
		this.EbtnIV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnIV.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnIV.Location = new System.Drawing.Point(297, 172);
		this.EbtnIV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnIV.Name = "EbtnIV";
		this.EbtnIV.Size = new System.Drawing.Size(40, 22);
		this.EbtnIV.TabIndex = 94;
		this.EbtnIV.Text = "IV";
		this.EbtnIV.UseVisualStyleBackColor = false;
		this.EbtnIV.Click += new System.EventHandler(EbtnIV_Click);
		this.EbtnIII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnIII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnIII.Location = new System.Drawing.Point(251, 172);
		this.EbtnIII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnIII.Name = "EbtnIII";
		this.EbtnIII.Size = new System.Drawing.Size(40, 22);
		this.EbtnIII.TabIndex = 93;
		this.EbtnIII.Text = "III";
		this.EbtnIII.UseVisualStyleBackColor = false;
		this.EbtnIII.Click += new System.EventHandler(EbtnIII_Click);
		this.EbtnII.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnII.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnII.Location = new System.Drawing.Point(205, 172);
		this.EbtnII.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnII.Name = "EbtnII";
		this.EbtnII.Size = new System.Drawing.Size(40, 22);
		this.EbtnII.TabIndex = 92;
		this.EbtnII.Text = "II";
		this.EbtnII.UseVisualStyleBackColor = false;
		this.EbtnII.Click += new System.EventHandler(EbtnII_Click);
		this.EbtnI.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.EbtnI.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.EbtnI.Location = new System.Drawing.Point(159, 172);
		this.EbtnI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.EbtnI.Name = "EbtnI";
		this.EbtnI.Size = new System.Drawing.Size(40, 22);
		this.EbtnI.TabIndex = 91;
		this.EbtnI.Text = "I";
		this.EbtnI.UseVisualStyleBackColor = false;
		this.EbtnI.Click += new System.EventHandler(EbtnI_Click);
		this.label21.AutoSize = true;
		this.label21.BackColor = System.Drawing.Color.Transparent;
		this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label21.ForeColor = System.Drawing.Color.Khaki;
		this.label21.Location = new System.Drawing.Point(6, 263);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(148, 13);
		this.label21.TabIndex = 102;
		this.label21.Text = "Common may not be accurate";
		this.label22.AutoSize = true;
		this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label22.ForeColor = System.Drawing.Color.DarkSlateGray;
		this.label22.Location = new System.Drawing.Point(6, 863);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(155, 13);
		this.label22.TabIndex = 103;
		this.label22.Text = "made by 1neil1 on discord";
		this.label23.AutoSize = true;
		this.label23.BackColor = System.Drawing.Color.Transparent;
		this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label23.ForeColor = System.Drawing.Color.DarkTurquoise;
		this.label23.Location = new System.Drawing.Point(315, 494);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(206, 20);
		this.label23.TabIndex = 104;
		this.label23.Text = "Damage against barriers";
		this.btnTurtSh.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnTurtSh.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnTurtSh.Location = new System.Drawing.Point(334, 546);
		this.btnTurtSh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnTurtSh.Name = "btnTurtSh";
		this.btnTurtSh.Size = new System.Drawing.Size(55, 34);
		this.btnTurtSh.TabIndex = 106;
		this.btnTurtSh.Text = "Turtle Shell";
		this.btnTurtSh.UseVisualStyleBackColor = false;
		this.btnTurtSh.Click += new System.EventHandler(btnTurtSh_Click);
		this.pictureBox5.BackgroundImage = DamageCalculatorGUI.Properties.Resources.DW;
		this.pictureBox5.Location = new System.Drawing.Point(395, 732);
		this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.pictureBox5.Name = "pictureBox5";
		this.pictureBox5.Size = new System.Drawing.Size(60, 60);
		this.pictureBox5.TabIndex = 109;
		this.pictureBox5.TabStop = false;
		this.pictureBox4.BackgroundImage = DamageCalculatorGUI.Properties.Resources.RR;
		this.pictureBox4.Location = new System.Drawing.Point(395, 666);
		this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.pictureBox4.Name = "pictureBox4";
		this.pictureBox4.Size = new System.Drawing.Size(60, 60);
		this.pictureBox4.TabIndex = 108;
		this.pictureBox4.TabStop = false;
		this.pictureBox3.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Rguard;
		this.pictureBox3.Location = new System.Drawing.Point(395, 596);
		this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.pictureBox3.Name = "pictureBox3";
		this.pictureBox3.Size = new System.Drawing.Size(60, 60);
		this.pictureBox3.TabIndex = 107;
		this.pictureBox3.TabStop = false;
		this.pictureBox2.BackgroundImage = DamageCalculatorGUI.Properties.Resources.turtle;
		this.pictureBox2.Location = new System.Drawing.Point(395, 531);
		this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(60, 60);
		this.pictureBox2.TabIndex = 105;
		this.pictureBox2.TabStop = false;
		this.pictureBox1.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Crown;
		this.pictureBox1.Location = new System.Drawing.Point(189, 503);
		this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(60, 60);
		this.pictureBox1.TabIndex = 55;
		this.pictureBox1.TabStop = false;
		this.PicFrog.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Frog;
		this.PicFrog.Location = new System.Drawing.Point(187, 735);
		this.PicFrog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.PicFrog.Name = "PicFrog";
		this.PicFrog.Size = new System.Drawing.Size(60, 60);
		this.PicFrog.TabIndex = 40;
		this.PicFrog.TabStop = false;
		this.PicAltar.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Altar;
		this.PicAltar.Location = new System.Drawing.Point(395, 374);
		this.PicAltar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.PicAltar.Name = "PicAltar";
		this.PicAltar.Size = new System.Drawing.Size(60, 60);
		this.PicAltar.TabIndex = 36;
		this.PicAltar.TabStop = false;
		this.PicTurtle.BackgroundImage = DamageCalculatorGUI.Properties.Resources.turtle;
		this.PicTurtle.Location = new System.Drawing.Point(187, 665);
		this.PicTurtle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.PicTurtle.Name = "PicTurtle";
		this.PicTurtle.Size = new System.Drawing.Size(60, 60);
		this.PicTurtle.TabIndex = 35;
		this.PicTurtle.TabStop = false;
		this.picDrum.BackgroundImage = DamageCalculatorGUI.Properties.Resources.drum;
		this.picDrum.Location = new System.Drawing.Point(187, 605);
		this.picDrum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.picDrum.Name = "picDrum";
		this.picDrum.Size = new System.Drawing.Size(60, 60);
		this.picDrum.TabIndex = 25;
		this.picDrum.TabStop = false;
		this.picPet.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Pet1;
		this.picPet.Location = new System.Drawing.Point(395, 313);
		this.picPet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.picPet.Name = "picPet";
		this.picPet.Size = new System.Drawing.Size(58, 48);
		this.picPet.TabIndex = 24;
		this.picPet.TabStop = false;
		this.picTiara.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Tiara;
		this.picTiara.Location = new System.Drawing.Point(189, 441);
		this.picTiara.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.picTiara.Name = "picTiara";
		this.picTiara.Size = new System.Drawing.Size(60, 60);
		this.picTiara.TabIndex = 23;
		this.picTiara.TabStop = false;
		this.picCape.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Cape;
		this.picCape.Location = new System.Drawing.Point(189, 378);
		this.picCape.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.picCape.Name = "picCape";
		this.picCape.Size = new System.Drawing.Size(60, 60);
		this.picCape.TabIndex = 22;
		this.picCape.TabStop = false;
		this.picMask.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Halloweenmask2;
		this.picMask.Location = new System.Drawing.Point(189, 310);
		this.picMask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.picMask.Name = "picMask";
		this.picMask.Size = new System.Drawing.Size(60, 60);
		this.picMask.TabIndex = 21;
		this.picMask.TabStop = false;
		this.label24.AutoSize = true;
		this.label24.BackColor = System.Drawing.Color.Transparent;
		this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label24.ForeColor = System.Drawing.Color.DarkTurquoise;
		this.label24.Location = new System.Drawing.Point(629, 494);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(73, 20);
		this.label24.TabIndex = 110;
		this.label24.Text = "Debuffs";
		this.btnRG.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnRG.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnRG.Location = new System.Drawing.Point(334, 609);
		this.btnRG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnRG.Name = "btnRG";
		this.btnRG.Size = new System.Drawing.Size(55, 34);
		this.btnRG.TabIndex = 111;
		this.btnRG.Text = "Royal Guard";
		this.btnRG.UseVisualStyleBackColor = false;
		this.btnRG.Click += new System.EventHandler(btnRG_Click);
		this.btnRR.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnRR.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnRR.Location = new System.Drawing.Point(334, 679);
		this.btnRR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnRR.Name = "btnRR";
		this.btnRR.Size = new System.Drawing.Size(55, 34);
		this.btnRR.TabIndex = 112;
		this.btnRR.Text = "Rusted Rev";
		this.btnRR.UseVisualStyleBackColor = false;
		this.btnRR.Click += new System.EventHandler(btnRR_Click);
		this.btnDW.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnDW.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnDW.Location = new System.Drawing.Point(334, 745);
		this.btnDW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnDW.Name = "btnDW";
		this.btnDW.Size = new System.Drawing.Size(55, 34);
		this.btnDW.TabIndex = 113;
		this.btnDW.Text = "Dreams Warden";
		this.btnDW.UseVisualStyleBackColor = false;
		this.btnDW.Click += new System.EventHandler(btnDW_Click);
		this.label25.AutoSize = true;
		this.label25.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label25.ForeColor = System.Drawing.Color.Violet;
		this.label25.Location = new System.Drawing.Point(473, 561);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(36, 19);
		this.label25.TabIndex = 114;
		this.label25.Text = "60%";
		this.label26.AutoSize = true;
		this.label26.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label26.ForeColor = System.Drawing.Color.Violet;
		this.label26.Location = new System.Drawing.Point(473, 622);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(36, 19);
		this.label26.TabIndex = 115;
		this.label26.Text = "50%";
		this.label27.AutoSize = true;
		this.label27.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label27.ForeColor = System.Drawing.Color.Violet;
		this.label27.Location = new System.Drawing.Point(473, 692);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(36, 19);
		this.label27.TabIndex = 116;
		this.label27.Text = "25%";
		this.label28.AutoSize = true;
		this.label28.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label28.ForeColor = System.Drawing.Color.Violet;
		this.label28.Location = new System.Drawing.Point(473, 754);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(36, 19);
		this.label28.TabIndex = 117;
		this.label28.Text = "30%";
		this.btnWeak.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnWeak.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnWeak.Location = new System.Drawing.Point(598, 546);
		this.btnWeak.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnWeak.Name = "btnWeak";
		this.btnWeak.Size = new System.Drawing.Size(55, 34);
		this.btnWeak.TabIndex = 118;
		this.btnWeak.Text = "Weakin";
		this.btnWeak.UseVisualStyleBackColor = false;
		this.btnWeak.Click += new System.EventHandler(btnWeak_Click);
		this.pictureBox6.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Weak;
		this.pictureBox6.Location = new System.Drawing.Point(659, 535);
		this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.pictureBox6.Name = "pictureBox6";
		this.pictureBox6.Size = new System.Drawing.Size(60, 60);
		this.pictureBox6.TabIndex = 119;
		this.pictureBox6.TabStop = false;
		this.pictureBox7.BackgroundImage = DamageCalculatorGUI.Properties.Resources.Charm;
		this.pictureBox7.Location = new System.Drawing.Point(659, 616);
		this.pictureBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.pictureBox7.Name = "pictureBox7";
		this.pictureBox7.Size = new System.Drawing.Size(68, 45);
		this.pictureBox7.TabIndex = 121;
		this.pictureBox7.TabStop = false;
		this.btnCharm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.btnCharm.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.btnCharm.Location = new System.Drawing.Point(598, 627);
		this.btnCharm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		this.btnCharm.Name = "btnCharm";
		this.btnCharm.Size = new System.Drawing.Size(55, 34);
		this.btnCharm.TabIndex = 120;
		this.btnCharm.Text = "Charm";
		this.btnCharm.UseVisualStyleBackColor = false;
		this.btnCharm.Click += new System.EventHandler(btnCharm_Click);
		this.label29.AutoSize = true;
		this.label29.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label29.ForeColor = System.Drawing.Color.Violet;
		this.label29.Location = new System.Drawing.Point(747, 555);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(36, 19);
		this.label29.TabIndex = 122;
		this.label29.Text = "25%";
		this.label30.AutoSize = true;
		this.label30.Font = new System.Drawing.Font("Malgun Gothic Semilight", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label30.ForeColor = System.Drawing.Color.Violet;
		this.label30.Location = new System.Drawing.Point(747, 625);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(36, 19);
		this.label30.TabIndex = 123;
		this.label30.Text = "50%";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.DimGray;
		base.ClientSize = new System.Drawing.Size(878, 885);
		base.Controls.Add(this.label30);
		base.Controls.Add(this.label29);
		base.Controls.Add(this.pictureBox7);
		base.Controls.Add(this.btnCharm);
		base.Controls.Add(this.pictureBox6);
		base.Controls.Add(this.btnWeak);
		base.Controls.Add(this.label28);
		base.Controls.Add(this.label27);
		base.Controls.Add(this.label26);
		base.Controls.Add(this.label25);
		base.Controls.Add(this.btnDW);
		base.Controls.Add(this.btnRR);
		base.Controls.Add(this.btnRG);
		base.Controls.Add(this.label24);
		base.Controls.Add(this.pictureBox5);
		base.Controls.Add(this.pictureBox4);
		base.Controls.Add(this.pictureBox3);
		base.Controls.Add(this.btnTurtSh);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label23);
		base.Controls.Add(this.label22);
		base.Controls.Add(this.label21);
		base.Controls.Add(this.label20);
		base.Controls.Add(this.EbtnX);
		base.Controls.Add(this.EbtnIX);
		base.Controls.Add(this.EbtnVIII);
		base.Controls.Add(this.EbtnVII);
		base.Controls.Add(this.EbtnVI);
		base.Controls.Add(this.EbtnV);
		base.Controls.Add(this.EbtnIV);
		base.Controls.Add(this.EbtnIII);
		base.Controls.Add(this.EbtnII);
		base.Controls.Add(this.EbtnI);
		base.Controls.Add(this.label19);
		base.Controls.Add(this.CbtnX);
		base.Controls.Add(this.CbtnIX);
		base.Controls.Add(this.CbtnVIII);
		base.Controls.Add(this.CbtnVII);
		base.Controls.Add(this.CbtnVI);
		base.Controls.Add(this.CbtnV);
		base.Controls.Add(this.CbtnIV);
		base.Controls.Add(this.CbtnIII);
		base.Controls.Add(this.CbtnII);
		base.Controls.Add(this.CbtnI);
		base.Controls.Add(this.label18);
		base.Controls.Add(this.RbtnX);
		base.Controls.Add(this.RbtnIX);
		base.Controls.Add(this.RbtnVIII);
		base.Controls.Add(this.RbtnVII);
		base.Controls.Add(this.RbtnVI);
		base.Controls.Add(this.RbtnV);
		base.Controls.Add(this.RbtnIV);
		base.Controls.Add(this.RbtnIII);
		base.Controls.Add(this.RbtnII);
		base.Controls.Add(this.RbtnI);
		base.Controls.Add(this.label17);
		base.Controls.Add(this.LbtnX);
		base.Controls.Add(this.LbtnIX);
		base.Controls.Add(this.LbtnVIII);
		base.Controls.Add(this.LbtnVII);
		base.Controls.Add(this.LbtnVI);
		base.Controls.Add(this.LbtnV);
		base.Controls.Add(this.LbtnIV);
		base.Controls.Add(this.LbtnIII);
		base.Controls.Add(this.LbtnII);
		base.Controls.Add(this.LbtnI);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.label15);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.btnCrown);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.txtCritHeadDamage);
		base.Controls.Add(this.txtCritDamage);
		base.Controls.Add(this.PicFrog);
		base.Controls.Add(this.btnFrog);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.btnAltar);
		base.Controls.Add(this.PicAltar);
		base.Controls.Add(this.PicTurtle);
		base.Controls.Add(this.btnTurtle);
		base.Controls.Add(this.Notice);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.txtHeadshotDamage);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.btnCalculate);
		base.Controls.Add(this.lblResult);
		base.Controls.Add(this.picDrum);
		base.Controls.Add(this.picPet);
		base.Controls.Add(this.picTiara);
		base.Controls.Add(this.picCape);
		base.Controls.Add(this.picMask);
		base.Controls.Add(this.btnDrum);
		base.Controls.Add(this.btnPet);
		base.Controls.Add(this.btnTiara);
		base.Controls.Add(this.btnCape);
		base.Controls.Add(this.btnMask);
		base.Controls.Add(this.lblWears);
		base.Controls.Add(this.lblMythicModules);
		base.Controls.Add(this.btnX);
		base.Controls.Add(this.btnIX);
		base.Controls.Add(this.btnVIII);
		base.Controls.Add(this.btnVII);
		base.Controls.Add(this.btnVI);
		base.Controls.Add(this.btnV);
		base.Controls.Add(this.btnIV);
		base.Controls.Add(this.btnIII);
		base.Controls.Add(this.btnII);
		base.Controls.Add(this.btnI);
		base.Controls.Add(this.lblChooseBuffs);
		base.Controls.Add(this.txtBaseDamage);
		base.Controls.Add(this.lblBaseDamage);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "Form1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "PG3D Damage Calculator";
		base.Load += new System.EventHandler(Form1_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PicFrog).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PicAltar).EndInit();
		((System.ComponentModel.ISupportInitialize)this.PicTurtle).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picDrum).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picPet).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picTiara).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picCape).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picMask).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox7).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
