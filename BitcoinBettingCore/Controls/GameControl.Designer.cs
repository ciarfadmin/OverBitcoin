namespace BitcoinBettingCore.Controls
{
    partial class GameControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstvBets = new System.Windows.Forms.ListView();
            this.grpbGeneral = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWinOdds = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPriceMultiplier = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBets = new System.Windows.Forms.TextBox();
            this.txtBtcWonUs = new System.Windows.Forms.TextBox();
            this.txtBtcWonPlayers = new System.Windows.Forms.TextBox();
            this.grpbGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvBets
            // 
            this.lstvBets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvBets.Location = new System.Drawing.Point(3, -49);
            this.lstvBets.Name = "lstvBets";
            this.lstvBets.Size = new System.Drawing.Size(576, 500);
            this.lstvBets.TabIndex = 0;
            this.lstvBets.UseCompatibleStateImageBehavior = false;
            this.lstvBets.View = System.Windows.Forms.View.Details;
            // 
            // grpbGeneral
            // 
            this.grpbGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbGeneral.Controls.Add(this.txtBtcWonPlayers);
            this.grpbGeneral.Controls.Add(this.txtBtcWonUs);
            this.grpbGeneral.Controls.Add(this.txtBets);
            this.grpbGeneral.Controls.Add(this.label8);
            this.grpbGeneral.Controls.Add(this.label7);
            this.grpbGeneral.Controls.Add(this.label6);
            this.grpbGeneral.Controls.Add(this.txtPriceMultiplier);
            this.grpbGeneral.Controls.Add(this.label5);
            this.grpbGeneral.Controls.Add(this.txtWinOdds);
            this.grpbGeneral.Controls.Add(this.label4);
            this.grpbGeneral.Controls.Add(this.txtLabel);
            this.grpbGeneral.Controls.Add(this.label3);
            this.grpbGeneral.Controls.Add(this.txtAddress);
            this.grpbGeneral.Controls.Add(this.txtDescription);
            this.grpbGeneral.Controls.Add(this.label2);
            this.grpbGeneral.Controls.Add(this.label1);
            this.grpbGeneral.Location = new System.Drawing.Point(4, 4);
            this.grpbGeneral.Name = "grpbGeneral";
            this.grpbGeneral.Size = new System.Drawing.Size(575, 106);
            this.grpbGeneral.TabIndex = 1;
            this.grpbGeneral.TabStop = false;
            this.grpbGeneral.Text = "Main Statistics";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(72, 19);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(494, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(72, 45);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(199, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // txtLabel
            // 
            this.txtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLabel.Location = new System.Drawing.Point(357, 43);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(209, 20);
            this.txtLabel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address Label";
            // 
            // txtWinOdds
            // 
            this.txtWinOdds.Location = new System.Drawing.Point(72, 71);
            this.txtWinOdds.Name = "txtWinOdds";
            this.txtWinOdds.Size = new System.Drawing.Size(39, 20);
            this.txtWinOdds.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Win Odds";
            // 
            // txtPriceMultiplier
            // 
            this.txtPriceMultiplier.Location = new System.Drawing.Point(198, 71);
            this.txtPriceMultiplier.Name = "txtPriceMultiplier";
            this.txtPriceMultiplier.Size = new System.Drawing.Size(51, 20);
            this.txtPriceMultiplier.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Price Multiplier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "N.Bets";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "btcWon";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Btc Won Players";
            // 
            // txtBets
            // 
            this.txtBets.Location = new System.Drawing.Point(300, 71);
            this.txtBets.Name = "txtBets";
            this.txtBets.ReadOnly = true;
            this.txtBets.Size = new System.Drawing.Size(39, 20);
            this.txtBets.TabIndex = 13;
            // 
            // txtBtcWonUs
            // 
            this.txtBtcWonUs.Location = new System.Drawing.Point(396, 71);
            this.txtBtcWonUs.Name = "txtBtcWonUs";
            this.txtBtcWonUs.ReadOnly = true;
            this.txtBtcWonUs.Size = new System.Drawing.Size(39, 20);
            this.txtBtcWonUs.TabIndex = 14;
            // 
            // txtBtcWonPlayers
            // 
            this.txtBtcWonPlayers.Location = new System.Drawing.Point(526, 71);
            this.txtBtcWonPlayers.Name = "txtBtcWonPlayers";
            this.txtBtcWonPlayers.ReadOnly = true;
            this.txtBtcWonPlayers.Size = new System.Drawing.Size(39, 20);
            this.txtBtcWonPlayers.TabIndex = 15;
            // 
            // GameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpbGeneral);
            this.Controls.Add(this.lstvBets);
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(582, 454);
            this.grpbGeneral.ResumeLayout(false);
            this.grpbGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvBets;
        private System.Windows.Forms.GroupBox grpbGeneral;
        private System.Windows.Forms.TextBox txtWinOdds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPriceMultiplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBtcWonPlayers;
        private System.Windows.Forms.TextBox txtBtcWonUs;
        private System.Windows.Forms.TextBox txtBets;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
