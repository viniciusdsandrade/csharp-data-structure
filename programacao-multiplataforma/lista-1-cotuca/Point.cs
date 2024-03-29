using System;

namespace Point
{
    public class MovablePoint
    {
        private int x;
        private int y;
        private readonly int speed;

        public MovablePoint(int x, int y, int speed)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;
        }

        public int GetX() => x;
        public int GetY() => y;
        public int GetSpeed() => speed;

        public void MoveUp() => y += speed;

        public void MoveDown() => y -= speed;

        public void MoveLeft() => x -= speed;

        public void MoveRight() => x += speed;

        public override string ToString() => "MovablePoint [x = " + x + ", y = " + y + ", speed = " + speed + "]";
    }

    public class MovableRectangle
    {
        private MovablePoint topLeft;
        private MovablePoint bottomRight;

        public MovableRectangle(int x1, int y1, int x2, int y2, int speed)
        {
            topLeft = new MovablePoint(x1, y1, speed);
            bottomRight = new MovablePoint(x2, y2, speed);
        }

        public MovablePoint GetTopLeft() => topLeft;
        public MovablePoint GetBottomRight() => bottomRight;

        public void MoveUp()
        {
            topLeft.MoveUp();
            bottomRight.MoveUp();
        }

        public void MoveDown()
        {
            topLeft.MoveDown();
            bottomRight.MoveDown();
        }

        public void MoveLeft()
        {
            topLeft.MoveLeft();
            bottomRight.MoveLeft();
        }

        public void MoveRight()
        {
            topLeft.MoveRight();
            bottomRight.MoveRight();
        }

        public override string ToString()
        {
            return "MovableRectangle[x1 = " + topLeft.GetX() + ", y1 = " + topLeft.GetY() + ", x2 = " + bottomRight.GetX() + ", y2 = " + bottomRight.GetY() + ", speed = " + topLeft.GetSpeed() + "]";
        }
    }
}
