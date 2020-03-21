using System.Drawing;

namespace Sprite_Plist_Extractor
{
    class Item
    {
        public string name;
        public Rectangle frame;
        public Point offset;
        public Rectangle sourceColorRect;
        public Point sourceSize;

        public Item(string name, Rectangle frame, Point offset, Rectangle sourceColorRect, Point sourceSize)
        {
            this.name = name;
            this.frame = frame;
            this.offset = offset;
            this.sourceColorRect = sourceColorRect;
            this.sourceSize = sourceSize;
        }
    }
}
