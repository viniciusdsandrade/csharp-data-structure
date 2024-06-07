using static System.Math;

namespace lista_1_cotuca
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
            this.speed = Max(speed, 0); // Garante que a velocidade seja não negativa
        }

        public int GetX() => x;

        public int GetY() => y;

        public int GetSpeed() => speed;

        public void MoveUp() => y += speed;

        public void MoveDown() => y -= speed;

        public void MoveLeft() => x -= speed;

        public void MoveRight() => x += speed;

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var that = (MovablePoint)obj;

            return Equals(this.x, that.x) &&
                Equals(this.y, that.y) &&
                Equals(this.speed, that.speed);
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            var hash = 1;

            hash *= prime + x;
            hash *= prime + y;
            hash *= prime + speed;

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override string ToString() => $"MovablePoint [x = {x}, y = {y}, speed = {speed}]";
    }

    public class MovableRectangle
    {
        private readonly MovablePoint topLeft;
        private readonly MovablePoint bottomRight;

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

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var that = (MovableRectangle)obj;

            return Equals(this.topLeft, that.topLeft) &&
                Equals(this.bottomRight, that.bottomRight);
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            var hash = 1;

            hash *= prime + topLeft.GetHashCode();
            hash *= prime + bottomRight.GetHashCode();

            if (hash < 0) hash = -hash;

            return hash;
        }

        public override string ToString() => $"MovableRectangle[x1 = {topLeft.GetX()}, y1 = {topLeft.GetY()}, x2 = {bottomRight.GetX()}, y2 = {bottomRight.GetY()}, speed = {topLeft.GetSpeed()}]";
    }
}
