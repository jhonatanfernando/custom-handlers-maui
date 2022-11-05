using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Graphics;
using Article_002.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Article_002.Platforms.Android.Renderes
{
    public class ImageEntryRenderer : EntryHandler
    {
        private ImageEntry element;

        protected override AppCompatEditText CreatePlatformView()
        {
            var editText = new AppCompatEditText(Context);
            element = VirtualView as ImageEntry;

            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }

            editText.CompoundDrawablePadding = 25;
            editText.Background.SetColorFilter(Colors.White.ToAndroid(), PorterDuff.Mode.SrcAtop);

            return editText;
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Context.Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(Context, resID);
            var bitmap = drawableToBitmap(drawable);

            return new BitmapDrawable(Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
        }

        public Bitmap drawableToBitmap(Drawable drawable)
        {
            if (drawable is BitmapDrawable) {
                return ((BitmapDrawable)drawable).Bitmap;
            }

            int width = drawable.IntrinsicWidth;
            width = width > 0 ? width : 1;
            int height = drawable.IntrinsicHeight;
            height = height > 0 ? height : 1;

            Bitmap bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bitmap);
            drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
            drawable.Draw(canvas);

            return bitmap;
        }
    }
}
