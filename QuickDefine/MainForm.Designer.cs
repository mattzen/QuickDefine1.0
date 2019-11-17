namespace QuickDefine
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.RichTextBox google_textbox;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.ComboBox stayontopbox;
        private System.Windows.Forms.Button history_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label deflbl;
        private System.Windows.Forms.Label hislbl;
        private System.Windows.Forms.TabControl tab_container;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox dictref_textbox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox meriamweb_textbox;
        private System.Windows.Forms.CheckBox ontop_check;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox pol_texbox;
        private System.Windows.Forms.CheckBox google_check;
        private System.Windows.Forms.CheckBox dictref_check;
        private System.Windows.Forms.CheckBox meriamweb_check;
        private System.Windows.Forms.CheckBox pol_check;
        private System.Windows.Forms.Label label7;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        // THIS METHOD IS MAINTAINED BY THE FORM DESIGNER
        // DO NOT EDIT IT MANUALLY! YOUR CHANGES ARE LIKELY TO BE LOST
        void InitializeComponent()
        {
            this.google_textbox = new System.Windows.Forms.RichTextBox();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.stayontopbox = new System.Windows.Forms.ComboBox();
            this.history_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.deflbl = new System.Windows.Forms.Label();
            this.hislbl = new System.Windows.Forms.Label();
            this.tab_container = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pol_texbox = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dictref_textbox = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.meriamweb_textbox = new System.Windows.Forms.RichTextBox();
            this.ontop_check = new System.Windows.Forms.CheckBox();
            this.google_check = new System.Windows.Forms.CheckBox();
            this.dictref_check = new System.Windows.Forms.CheckBox();
            this.meriamweb_check = new System.Windows.Forms.CheckBox();
            this.pol_check = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.search_localbtn = new System.Windows.Forms.Button();
            this.genSentence = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sententebox = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.elasticBox = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tab_container.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // google_textbox
            // 
            this.google_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.google_textbox.Location = new System.Drawing.Point(0, 2);
            this.google_textbox.Name = "google_textbox";
            this.google_textbox.Size = new System.Drawing.Size(414, 300);
            this.google_textbox.TabIndex = 2;
            this.google_textbox.Text = "";
            this.google_textbox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(69, 12);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(136, 20);
            this.inputBox.TabIndex = 3;
            this.inputBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // search_btn
            // 
            this.search_btn.Location = new System.Drawing.Point(214, 7);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(93, 23);
            this.search_btn.TabIndex = 4;
            this.search_btn.Text = "search online";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_online_btn_Click);
            // 
            // stayontopbox
            // 
            this.stayontopbox.Location = new System.Drawing.Point(94, 61);
            this.stayontopbox.Name = "stayontopbox";
            this.stayontopbox.Size = new System.Drawing.Size(121, 21);
            this.stayontopbox.TabIndex = 25;
            // 
            // history_btn
            // 
            this.history_btn.Location = new System.Drawing.Point(221, 59);
            this.history_btn.Name = "history_btn";
            this.history_btn.Size = new System.Drawing.Size(93, 23);
            this.history_btn.TabIndex = 6;
            this.history_btn.Text = "get history";
            this.history_btn.UseVisualStyleBackColor = true;
            this.history_btn.Click += new System.EventHandler(this.get_history_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(9, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Definition for [             ]";
            // 
            // deflbl
            // 
            this.deflbl.AutoSize = true;
            this.deflbl.Location = new System.Drawing.Point(9, 11);
            this.deflbl.Name = "deflbl";
            this.deflbl.Size = new System.Drawing.Size(38, 13);
            this.deflbl.TabIndex = 8;
            this.deflbl.Text = "Define";
            // 
            // hislbl
            // 
            this.hislbl.AutoSize = true;
            this.hislbl.Location = new System.Drawing.Point(9, 65);
            this.hislbl.Name = "hislbl";
            this.hislbl.Size = new System.Drawing.Size(79, 13);
            this.hislbl.TabIndex = 9;
            this.hislbl.Text = "Previous words";
            // 
            // tab_container
            // 
            this.tab_container.Controls.Add(this.tabPage1);
            this.tab_container.Controls.Add(this.tabPage4);
            this.tab_container.Controls.Add(this.tabPage2);
            this.tab_container.Controls.Add(this.tabPage3);
            this.tab_container.Location = new System.Drawing.Point(8, 129);
            this.tab_container.Name = "tab_container";
            this.tab_container.SelectedIndex = 0;
            this.tab_container.Size = new System.Drawing.Size(418, 337);
            this.tab_container.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.google_textbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(410, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "google api";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pol_texbox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(410, 311);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "po polsku";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pol_texbox
            // 
            this.pol_texbox.Location = new System.Drawing.Point(0, 0);
            this.pol_texbox.Name = "pol_texbox";
            this.pol_texbox.Size = new System.Drawing.Size(410, 315);
            this.pol_texbox.TabIndex = 0;
            this.pol_texbox.Text = "";
            this.pol_texbox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dictref_textbox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(410, 311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "dictionary.reference.com";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dictref_textbox
            // 
            this.dictref_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dictref_textbox.Location = new System.Drawing.Point(-1, 0);
            this.dictref_textbox.Name = "dictref_textbox";
            this.dictref_textbox.Size = new System.Drawing.Size(410, 300);
            this.dictref_textbox.TabIndex = 0;
            this.dictref_textbox.Text = "";
            this.dictref_textbox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.meriamweb_textbox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(410, 311);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "meriam-webster";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // meriamweb_textbox
            // 
            this.meriamweb_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meriamweb_textbox.Location = new System.Drawing.Point(-1, 1);
            this.meriamweb_textbox.Name = "meriamweb_textbox";
            this.meriamweb_textbox.Size = new System.Drawing.Size(410, 300);
            this.meriamweb_textbox.TabIndex = 0;
            this.meriamweb_textbox.Text = "";
            this.meriamweb_textbox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // ontop_check
            // 
            this.ontop_check.AutoSize = true;
            this.ontop_check.Location = new System.Drawing.Point(915, 7);
            this.ontop_check.Name = "ontop_check";
            this.ontop_check.Size = new System.Drawing.Size(84, 17);
            this.ontop_check.TabIndex = 19;
            this.ontop_check.Text = "show on top";
            this.ontop_check.UseVisualStyleBackColor = true;
            this.ontop_check.CheckedChanged += new System.EventHandler(this.ontop_CheckedChanged);
            // 
            // google_check
            // 
            this.google_check.AutoSize = true;
            this.google_check.Checked = true;
            this.google_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.google_check.Location = new System.Drawing.Point(80, 105);
            this.google_check.Name = "google_check";
            this.google_check.Size = new System.Drawing.Size(58, 17);
            this.google_check.TabIndex = 20;
            this.google_check.Text = "google";
            this.google_check.UseVisualStyleBackColor = true;
            // 
            // dictref_check
            // 
            this.dictref_check.AutoSize = true;
            this.dictref_check.Checked = true;
            this.dictref_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dictref_check.Location = new System.Drawing.Point(179, 105);
            this.dictref_check.Name = "dictref_check";
            this.dictref_check.Size = new System.Drawing.Size(58, 17);
            this.dictref_check.TabIndex = 21;
            this.dictref_check.Text = "dict.ref";
            this.dictref_check.UseVisualStyleBackColor = true;
            // 
            // meriamweb_check
            // 
            this.meriamweb_check.AutoSize = true;
            this.meriamweb_check.Checked = true;
            this.meriamweb_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.meriamweb_check.Location = new System.Drawing.Point(243, 105);
            this.meriamweb_check.Name = "meriamweb_check";
            this.meriamweb_check.Size = new System.Drawing.Size(82, 17);
            this.meriamweb_check.TabIndex = 22;
            this.meriamweb_check.Text = "meriam-web";
            this.meriamweb_check.UseVisualStyleBackColor = true;
            // 
            // pol_check
            // 
            this.pol_check.AutoSize = true;
            this.pol_check.Checked = true;
            this.pol_check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pol_check.Location = new System.Drawing.Point(133, 105);
            this.pol_check.Name = "pol_check";
            this.pol_check.Size = new System.Drawing.Size(40, 17);
            this.pol_check.TabIndex = 23;
            this.pol_check.Text = "pol";
            this.pol_check.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Search with: ";
            // 
            // search_localbtn
            // 
            this.search_localbtn.Location = new System.Drawing.Point(313, 6);
            this.search_localbtn.Name = "search_localbtn";
            this.search_localbtn.Size = new System.Drawing.Size(93, 23);
            this.search_localbtn.TabIndex = 26;
            this.search_localbtn.Text = "search local";
            this.search_localbtn.UseVisualStyleBackColor = true;
            this.search_localbtn.Click += new System.EventHandler(this.search_localbtn_Click);
            // 
            // genSentence
            // 
            this.genSentence.Location = new System.Drawing.Point(432, 88);
            this.genSentence.Name = "genSentence";
            this.genSentence.Size = new System.Drawing.Size(119, 23);
            this.genSentence.TabIndex = 27;
            this.genSentence.Text = "create cool sentence";
            this.genSentence.UseVisualStyleBackColor = true;
            this.genSentence.Click += new System.EventHandler(this.genSentence_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "label2";
            // 
            // sententebox
            // 
            this.sententebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sententebox.Location = new System.Drawing.Point(432, 153);
            this.sententebox.Name = "sententebox";
            this.sententebox.Size = new System.Drawing.Size(269, 309);
            this.sententebox.TabIndex = 30;
            this.sententebox.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(432, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(567, 20);
            this.textBox1.TabIndex = 31;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "ToDBTest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(735, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "SearchElastic";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // elasticBox
            // 
            this.elasticBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elasticBox.Location = new System.Drawing.Point(718, 151);
            this.elasticBox.Name = "elasticBox";
            this.elasticBox.Size = new System.Drawing.Size(269, 309);
            this.elasticBox.TabIndex = 34;
            this.elasticBox.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(514, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 35;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.search_btn;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1011, 481);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.elasticBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.sententebox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.genSentence);
            this.Controls.Add(this.search_localbtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pol_check);
            this.Controls.Add(this.meriamweb_check);
            this.Controls.Add(this.dictref_check);
            this.Controls.Add(this.google_check);
            this.Controls.Add(this.ontop_check);
            this.Controls.Add(this.tab_container);
            this.Controls.Add(this.hislbl);
            this.Controls.Add(this.deflbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.history_btn);
            this.Controls.Add(this.stayontopbox);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.inputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "QuickDefinitions";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tab_container.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search_localbtn;
        private System.Windows.Forms.Button genSentence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox sententebox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox elasticBox;
        private System.Windows.Forms.Button button3;
    }
}

