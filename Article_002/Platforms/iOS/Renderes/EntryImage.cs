using Microsoft.Maui.Platform;
using System.Drawing;
using UIKit;

namespace Article_002.Platforms.iOS.Renderes
{
    public class EntryImage : MauiTextField
    {
        public EntryImage()
        {
            this.LeftViewMode = UITextFieldViewMode.Always;
            this.LeftView = GetImageView("user", 40, 40);

            this.BorderStyle = UITextBorderStyle.Line;
            this.Layer.MasksToBounds = true;
        }

        private UIView GetImageView(string imagePath, int height, int width)
        {
            var uiImageView = new UIImageView(UIImage.FromFile(imagePath))
            {
                Frame = new RectangleF(0, 0, width, height)
            };
            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 10, height));
            objLeftView.AddSubview(uiImageView);

            return objLeftView;
        }
    }
}
