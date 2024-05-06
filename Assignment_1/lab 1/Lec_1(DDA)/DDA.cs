using System;

namespace Lec_1_DDA_
{
    public class DDA
    {
        public float X, Y;
        float dy, dx, m;
        public float cx, cy;
        int speed = 10 , direc = 1;
        public void calc(DDA End)
        {
            dy = End.Y - Y;
            dx = End.X - X;
            m = dy / dx;
            cx = X;
            cy = Y;
        }
        public bool CalcNextPoint(DDA End , DDA start)
        {
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (X < End.X)
                {
                    if (direc == 1)
                    {
                        cx += speed;
                        cy += m * speed;
                        if (cx >= End.X)
                        {
                            direc=2;
                        }
                    }
                    else if (direc == 2)
                    {
                        cx -= speed;
                        cy -= m * speed;
                        if (cx <= start.X)
                        {
                            direc = 1;
                        }
                    }


                }
                else
                {
                    if (direc == 1)
                    {
                        cx -= speed;
                        cy -= m * speed;
                        if (cx <= End.X)
                        {
                            direc = 2;
                        }
                    }
                    else if (direc == 2)
                    {
                        cx += speed;
                        cy += m * speed;
                        if (cx >= start.X)
                        {
                            direc = 1;
                        }
                    }
                    
                }
            }
            else
            {
                
                if (Y < End.Y)
                {
                    if (direc == 1)
                    {
                        cy += speed;
                        cx += 1 / m * speed;
                        if (cy >= End.Y)
                        {
                            direc=2;
                        }
                    }
                    else if (direc == 2)
                    {
                        cy -= speed;
                        cx -= 1 / m * speed;
                        if (cy <= start.Y)
                        {
                            direc = 1;
                        }
                    }
                }
                else
                {
                    if (direc == 1)
                    {
                        cy -= speed;
                        cx -= 1 / m * speed;
                        if (cy <= End.Y)
                        {
                            direc = 2;
                        }
                    }
                    else if (direc == 2)
                    {
                        cy += speed;
                        cx += 1 / m * speed;
                        if (cy >= start.Y)
                        {
                            direc = 1;
                        }
                    }
                    
                }

            }
            return true;
        }

    }
}
