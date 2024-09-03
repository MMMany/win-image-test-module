using System.Diagnostics;
using ImageTestModule;

namespace ImageTest;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private string _img1Path = "";
    private string _img2Path = "";

    private void IncreaseButton_Clicked(object sender, EventArgs e)
    {
        Log("increase");
        var num = int.Parse(SubLabel.Text);
        if (num > 10) return;
        SubLabel.Text = (num + 1).ToString();
    }

    private void DecreaseButton_Clicked(object sender, EventArgs e)
    {
        Log("decrease");
        var num = int.Parse(SubLabel.Text);
        if (num == 0) return;
        SubLabel.Text = (num - 1).ToString();
    }

    private void OpenImage1_Clicked(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            RestoreDirectory = true
        };
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            Log("save image 1");
            _img1Path = dialog.FileName;
            Image1Label.Text = $"Image 1 : {_img1Path}";
        }
    }

    private void OpenImage2_Clicked(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            RestoreDirectory = true
        };
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _img2Path = dialog.FileName;
            Image2Label.Text = $"Image 1 : {_img2Path}";
        }
    }

    private void CompareButton_Clicked(object sender, EventArgs e) {
        Log("start compare");
        var fileImg1 = new FileInfo(_img1Path);
        var fileImg2 = new FileInfo(_img2Path);

        if (!fileImg1.Exists || !fileImg2.Exists) {
            Log("image not exist");
        }

        Log($"Image 1 : {fileImg1.FullName}");
        Log($"Image 2 : {fileImg2.FullName}");
        var img1 = ImageLoader.Load(fileImg1.FullName);
        var img2 = ImageLoader.Load(fileImg2.FullName);
        var score = ImageCompare.Run(img1, img2);
        ScoreLabel.Text = $"Score : {score:N3}";
    }

    private void Log(string message)
    {
        if (message.Trim().Length == 0) return;
        var now = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
        Debug.WriteLine($"[{now}][D] {message.Trim()}");
    }
}
