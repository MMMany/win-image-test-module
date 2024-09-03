using System.Drawing;
using System.Windows.Forms;

namespace ImageTest;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Text = "Form1";

        this.MainLabel.Name = "MainLabel";
        this.MainLabel.Text = "This is test form";
        this.MainLabel.AutoSize = true;
        this.MainLabel.Location = new Point(30, 30);

        this.SubLabel.Name = "SubLabel";
        this.SubLabel.Text = "0";
        this.SubLabel.AutoSize = true;
        this.SubLabel.Location = new Point(this.MainLabel.Left, this.MainLabel.Bottom + 15);

        this.IncreaseButton.Name = "IncreaseButton";
        this.IncreaseButton.Text = "Increase";
        this.IncreaseButton.Location = new Point(this.SubLabel.Left, this.SubLabel.Bottom + 15);
        this.IncreaseButton.Click += this.IncreaseButton_Clicked;

        this.DecreaseButton.Name = "DescreaseButton";
        this.DecreaseButton.Text = "Decrease";
        this.DecreaseButton.Location = new Point(this.IncreaseButton.Right + 10, this.IncreaseButton.Top);
        this.DecreaseButton.Click += this.DecreaseButton_Clicked;

        this.OpenImage1.Name = "OpenImage1";
        this.OpenImage1.Text = "Open 1";
        this.OpenImage1.Location = new Point(this.IncreaseButton.Left, this.IncreaseButton.Bottom + 15);
        this.OpenImage1.Click += this.OpenImage1_Clicked;

        this.OpenImage2.Name = "OpenImage2";
        this.OpenImage2.Text = "Open 2";
        this.OpenImage2.Location = new Point(this.OpenImage1.Right + 10, this.OpenImage1.Top);
        this.OpenImage2.Click += this.OpenImage2_Clicked;

        this.CompareButton.Name = "CompareButton";
        this.CompareButton.Text = "Compare";
        this.CompareButton.Location = new Point(this.OpenImage2.Right + 10, this.OpenImage2.Top);
        this.CompareButton.Click += this.CompareButton_Clicked;

        this.Image1Label.Name = "Image1Label";
        this.Image1Label.Text = "Image 1 : unknown";
        this.Image1Label.AutoSize = true;
        this.Image1Label.Location = new Point(this.OpenImage1.Left, this.OpenImage1.Bottom + 15);

        this.Image2Label.Name = "Image2Label";
        this.Image2Label.Text = "Image 2 : unknown";
        this.Image2Label.AutoSize = true;
        this.Image2Label.Location = new Point(this.Image1Label.Left, this.Image1Label.Bottom + 10);

        this.ScoreLabel.Name = "ScoreLabel";
        this.ScoreLabel.Text = "Score : 0";
        this.ScoreLabel.AutoSize = true;
        this.ScoreLabel.Location = new Point(this.Image2Label.Left, this.Image2Label.Bottom + 15);

        AddControls();
    }

    Label MainLabel = new Label();
    Label SubLabel = new Label();
    Button IncreaseButton = new Button();
    Button DecreaseButton = new Button();
    Button OpenImage1 = new Button();
    Button OpenImage2 = new Button();
    Button CompareButton = new Button();
    Label Image1Label = new Label();
    Label Image2Label = new Label();
    Label ScoreLabel = new Label();

    private void AddControls()
    {
        this.Controls.AddRange([
            MainLabel,
            SubLabel,
            IncreaseButton,
            DecreaseButton,
            OpenImage1,
            OpenImage2,
            CompareButton,
            Image1Label,
            Image2Label,
            ScoreLabel,
        ]);
    }

    #endregion
}
