using System;
using System.Diagnostics;
using System.Drawing;

namespace RefactorMe
{
	public class Painter
	{
		private static Bitmap image;
		private static float x, y;
		private static Graphics graphics;
		private static string resultBmpFilename = "result.bmp";

		// Имена методов должны быть глаголами
		public static void Initialize(int width, int height)
		{
			image = new Bitmap(width, height);
			graphics = Graphics.FromImage(image);
		}
		
		// Имена методов должны быть в PascalCase (не camelCase и не snake_case).
		public static void SetPosition(float x0, float y0)
		{
			x = x0;
			y = y0;
		}

		// Имя метода должно быть понятным. Имена аргументов должны быть с маленькой буквы.
		public static void DrawLine(double len, double angle)
		{
			var x1 = (float)(x + len * Math.Cos(angle));
			var y1 = (float)(y + len * Math.Sin(angle));
			graphics.DrawLine(Pens.Yellow, x, y, x1, y1);
			x = x1;
			y = y1;
		}

		public static void ShowResult()
		{
			image.Save(resultBmpFilename);
			Process.Start(resultBmpFilename);
		}
	}

	public class ImpossibleSquarePainter
	{
		public static void Main()
		{
			// ширину и высоту лучше задавать тут — рядом с остальными координатами, 
			// чтобы проще было убедиться в их согласованности
			Painter.Initialize(800, 600);
			// константы, ответственные за пропорции фигуры
			var bigSize = 400;
			var smallSize = 50;

			// повторяющийся код вынесен в метод. Подобная разбивка на строки, конечно, не обязательна, но повышает читаемость.
			DrawImpossibleSquarePart(
				smallSize, 0, 0, 
				bigSize, smallSize);
			DrawImpossibleSquarePart(
				bigSize + 2* smallSize, smallSize, Math.PI / 2, 
				bigSize, smallSize);
			DrawImpossibleSquarePart(
				bigSize + smallSize, bigSize + 2 * smallSize, Math.PI, 
				bigSize, smallSize);
			DrawImpossibleSquarePart(
				0, bigSize + smallSize, -Math.PI / 2, 
				bigSize, smallSize);

			Painter.ShowResult();
		}


		public static void DrawImpossibleSquarePart(float x0, float y0, double angle, double bigSize, double smallSize)
		{
			Painter.SetPosition(x0, y0);
			Painter.DrawLine(bigSize, angle);
			Painter.DrawLine(smallSize * Math.Sqrt(2), angle + Math.PI / 4);
			Painter.DrawLine(bigSize, angle + Math.PI);
			Painter.DrawLine(bigSize - smallSize, angle + Math.PI / 2);
		}
	}
}
