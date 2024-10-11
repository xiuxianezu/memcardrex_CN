// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Drawing;
using Foundation;
using AppKit;

namespace MemcardRex
{
	public partial class InfoDialogController : NSViewController
	{
        #region Private Variables
        private string _dialogTitle = "";
        private string _saveTitle = "";
        private string _productCode = "";
        private string _identifier = "";
        private string _region = "";
        private int _frames = 0;
        private int _size = 0;
        private int[] _slots = new int[1];
        private Color[,][] _icons;
        private NSViewController _presentor;
        #endregion

        #region Computed Properties
        public string DialogTitle
        {
            get { return _dialogTitle; }
            set { _dialogTitle = value; }
        }

        public string SaveTitle
        {
            get { return _saveTitle; }
            set { _saveTitle = value; }
        }

        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }

        public string IdentifierString
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public int Frames
        {
            get { return _frames; }
            set { _frames = value; }
        }

        public int[] Slots
        {
            get { return _slots; }
            set { _slots = value; }
        }

        public Color[,][] Icons
        {
            get { return _icons; }
            set { _icons = value; }
        }

        public NSViewController Presentor
        {
            get { return _presentor; }
            set { _presentor = value; }
        }
        #endregion

        public InfoDialogController (IntPtr handle) : base (handle)
		{
		}

        #region Override Methods
        public override void ViewWillAppear()
        {
            string ocupiedSlots = "";

            base.ViewWillAppear();

            this.View.Window.Title = DialogTitle;

            titleLabel.StringValue = SaveTitle;
            identifierLabel.StringValue = IdentifierString;
            productCodeLabel.StringValue = ProductCode;
            regionLabel.StringValue = Region;
            sizeLabel.StringValue = Size.ToString() + " KB";
            iconFramesLabel.StringValue = Frames.ToString();

            for (int i = 0; i < Slots.Length; i++)
                ocupiedSlots += (Slots[i] + 1).ToString() + ", ";

            //Show ocupied slots
            slotLabel.StringValue = ocupiedSlots.Remove(ocupiedSlots.Length - 2);

            //Prepare icons
            BmpBuilder bmpImage = new BmpBuilder();

            NSData imageData = NSData.FromArray(bmpImage.BuildBmp(Icons[Slots[0],0]));
            NSImage image = new NSImage(imageData);
            var newImage = new NSImage(new CoreGraphics.CGSize(48, 48));
            var targetRect = new CoreGraphics.CGRect(0, 0, 48, 48);

            image.Flipped = true;

            newImage.LockFocus();
            image.Draw(targetRect, CoreGraphics.CGRect.Empty, NSCompositingOperation.Copy, 1.0f);
            newImage.UnlockFocus();

            iconImage.Image = newImage;

            //Disable resizing of modal dialog
            this.View.Window.StyleMask &= ~NSWindowStyle.Resizable;
        }
        #endregion

        [Export("CloseDialog:")]
        void CloseDialoga(NSObject sender)
        {
            Presentor.DismissViewController(this);
        }
    }
}
