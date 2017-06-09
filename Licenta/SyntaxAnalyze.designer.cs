namespace Licenta.Resources
{
    partial class SyntaxAnalyze
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lemma = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dependency = new System.Windows.Forms.Label();
            this.dependence = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.partOfSpeech = new System.Windows.Forms.Label();
            this.right = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.tokenText = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.right);
            this.panel1.Controls.Add(this.left);
            this.panel1.Controls.Add(this.tokenText);
            this.panel1.Controls.Add(this.textLabel);
            this.panel1.Location = new System.Drawing.Point(12, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 344);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lemma);
            this.panel4.Location = new System.Drawing.Point(387, 186);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(145, 158);
            this.panel4.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lemma:";
            // 
            // lemma
            // 
            this.lemma.AutoSize = true;
            this.lemma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lemma.Location = new System.Drawing.Point(14, 22);
            this.lemma.Name = "lemma";
            this.lemma.Size = new System.Drawing.Size(45, 16);
            this.lemma.TabIndex = 10;
            this.lemma.Text = "label6";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dependency);
            this.panel3.Controls.Add(this.dependence);
            this.panel3.Location = new System.Drawing.Point(180, 186);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 158);
            this.panel3.TabIndex = 13;
            // 
            // dependency
            // 
            this.dependency.AutoSize = true;
            this.dependency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dependency.Location = new System.Drawing.Point(14, 2);
            this.dependency.Name = "dependency";
            this.dependency.Size = new System.Drawing.Size(114, 20);
            this.dependency.TabIndex = 9;
            this.dependency.Text = "Dependency:";
            // 
            // dependence
            // 
            this.dependence.AutoSize = true;
            this.dependence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dependence.Location = new System.Drawing.Point(16, 23);
            this.dependence.Name = "dependence";
            this.dependence.Size = new System.Drawing.Size(45, 16);
            this.dependence.TabIndex = 8;
            this.dependence.Text = "label4";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.partOfSpeech);
            this.panel2.Location = new System.Drawing.Point(6, 186);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 158);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Part of speech:";
            // 
            // partOfSpeech
            // 
            this.partOfSpeech.AutoSize = true;
            this.partOfSpeech.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partOfSpeech.Location = new System.Drawing.Point(4, 22);
            this.partOfSpeech.Name = "partOfSpeech";
            this.partOfSpeech.Size = new System.Drawing.Size(45, 16);
            this.partOfSpeech.TabIndex = 4;
            this.partOfSpeech.Text = "label1";
            // 
            // right
            // 
            this.right.BackgroundImage = global::Licenta.Properties.Resources.Right_Arrows;
            this.right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.right.Location = new System.Drawing.Point(463, 101);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(75, 79);
            this.right.TabIndex = 7;
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // left
            // 
            this.left.BackgroundImage = global::Licenta.Properties.Resources.Left_Arrows;
            this.left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.left.Location = new System.Drawing.Point(6, 101);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(75, 79);
            this.left.TabIndex = 6;
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // tokenText
            // 
            this.tokenText.AutoSize = true;
            this.tokenText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tokenText.Location = new System.Drawing.Point(261, 119);
            this.tokenText.Name = "tokenText";
            this.tokenText.Size = new System.Drawing.Size(57, 20);
            this.tokenText.TabIndex = 3;
            this.tokenText.Text = "label1";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel.Location = new System.Drawing.Point(3, 9);
            this.textLabel.MaximumSize = new System.Drawing.Size(520, 0);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(53, 16);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "Content";
            // 
            // SyntaxAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 352);
            this.Controls.Add(this.panel1);
            this.Name = "SyntaxAnalyze";
            this.Text = "SyntaxAnalyze";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label tokenText;
        private System.Windows.Forms.Label partOfSpeech;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lemma;
        private System.Windows.Forms.Label dependency;
        private System.Windows.Forms.Label dependence;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}