using Android.Graphics;
using Android.Graphics.Drawables;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;

namespace Article_002.Platforms.Android.Renderes
{
    public class EntryImage : AppCompatEditText
    {
        public EntryImage() :  base(MauiApplication.Current.ApplicationContext)
        {
            this.SetBackgroundResource(Resource.Drawable.backtext);

            this.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable("user"), null, null, null);
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Context.Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(Context, resID);
            var bitmap = drawableToBitmap(drawable);

            return new BitmapDrawable(Bitmap.CreateScaledBitmap(bitmap, 80, 80, true));
        }

        public Bitmap drawableToBitmap(Drawable drawable)
        {
            if (drawable is BitmapDrawable)
            {
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
