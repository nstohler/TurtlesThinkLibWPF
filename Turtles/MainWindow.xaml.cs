using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThinkLib;

namespace Turtles
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Turtle tess, alex, fred, bernd;

		public MainWindow()
		{
			InitializeComponent();
			tess = new Turtle(playground, 100.0, 30.0);  // Create a turtle in the playground.
			tess.BrushWidth = 5.1;                       // Set some properties.

			alex = new Turtle(playground, 300.0, 100.0); // Create another turtle
			alex.LineBrush = Brushes.Blue;               // Make its lines blue
			alex.BodyBrush = Brushes.Blue;               // and make its body blue too
			alex.BrushWidth = 1;

			fred = new Turtle(playground, 300.0, 300.0);
			fred.LineBrush = Brushes.DarkOrange;
			fred.BodyBrush = Brushes.DarkOrchid;
			fred.BrushWidth = 1;

			bernd = new Turtle(playground, 350.0, 250.0);
			bernd.LineBrush = Brushes.DarkGoldenrod;
			bernd.BodyBrush = Brushes.DarkOliveGreen;
			bernd.BrushWidth = 1;
		}

		private void btnRun1_Click(object sender, RoutedEventArgs e)
		{
			btn1.IsEnabled = false;

			tess.Forward(80.0);   // Make Tess draw a square
			tess.Right(90.0);
			tess.Forward(80.0);
			tess.Right(90.0);
			tess.Forward(80.0);
			tess.Right(90.0);
			tess.Forward(80.0);
			tess.Right(90.0);			

			btn1.IsEnabled = true;
			btn1.Focus();
		}

		private void btnRun2_Click(object sender, RoutedEventArgs e)
		{
			btn2.IsEnabled = false;

			//// Draw a broken line by picking up the brush in the middle
			//alex.Forward(40.0);
			//alex.BrushDown = false;
			//alex.Forward(40.0);
			//alex.BrushDown = true;
			//alex.Forward(40.0);
			//alex.Right(95);

			//alex.DelayMillisecs = 100;

			alex.BrushDown = true;       

			int i = 0;
			while (i < 72)
			{
				alex.Forward(120.0);
				alex.Right(95);
				i = i + 1;
			}

			btn2.IsEnabled = true;
			btn2.Focus();
		}

		private void btnRun3_Click(object sender, RoutedEventArgs e)
		{
			btn3.IsEnabled = false;

			alex.WarpTo(200.0, 200.0);    // Warp without drawing
			alex.BrushDown = false;       // Pick up the brush
			double size = 10.0;
			int i = 0;
			while (i < 30)
			{
				alex.Stamp();             // Stamp a footprint
				size = size + 2.0;
				alex.Forward(size);
				alex.Right(24.0);
				i = i + 1;
			}

			btn3.IsEnabled = true;
			btn3.Focus();
		}

		private void btnRun4_Click(object sender, RoutedEventArgs e)
		{
			btn4.IsEnabled = false;
			//---			
			fred.DelayMillisecs = 20;
			const double len = 70.0;
			var originalHeading = fred.Heading;

			DrawHexFigure(len);

			fred.Heading = originalHeading + 12;

			//---
			btn4.IsEnabled = true;
			btn4.Focus();
		}

		private void btnRun5_Click(object sender, RoutedEventArgs e)
		{
			btn5.IsEnabled = false;
			//---						
			const double tiltAngle = 10;
			var originalHeading = fred.Heading;

			fred.DelayMillisecs = 0;
			const double len = 70.0;

			for (int i = 0; i < 360.0 / tiltAngle; i++)
			{
				DrawHexFigure(len);

				fred.Heading = fred.Heading + tiltAngle;
			}
			
			//---
			btn5.IsEnabled = true;
			btn5.Focus();
		}

		private void btnRun6_Click(object sender, RoutedEventArgs e)
		{
			// draw optimized
			btn6.IsEnabled = false;
			//---						

			var originalPosition = bernd.Position;
			var originalHeading  = bernd.Heading;			
			const double len     = 70.0;
			bernd.DelayMillisecs = 0;

			//bernd.BrushDown = false;
			bernd.Stamp();

			bernd.BrushDown = false;
			bernd.Left(60);
			bernd.Forward(3 * len);
			bernd.Right(60);
			bernd.Forward(-1.5 * len);			//bernd.Position.
			bernd.Stamp();

			int[] horizontalLineLengthSet = { 1, 2, 3, 4, 3, 2, 1 };

			foreach (var horizontalLineLength in horizontalLineLengthSet)
			{
				// draw
				bernd.Forward(-0.5 * horizontalLineLength * len);
				bernd.BrushDown = true;
				bernd.Forward(horizontalLineLength * len);

				// update position
				bernd.BrushDown = false;
				bernd.Forward((-0.5 * horizontalLineLength * len));
				bernd.Right(60);
				bernd.Forward(len);
				bernd.Left(60);
				bernd.Forward(-0.5 * len);
			}

			bernd.WarpTo(originalPosition);

			// stripes top left to bottom right
			bernd.Left(120);
			bernd.Forward(3 * len);
			bernd.Right(120);
			bernd.Forward(len);
			bernd.Right(60);

			for (int j = 0; j < 3; j++)
			{
				bernd.BrushDown = true;
				bernd.Forward(4 * len);
				bernd.BrushDown = false;

				bernd.Forward(-4 * len);
				bernd.Right(60);
				bernd.Forward(len);
				bernd.Left(60);
			}

			// stripes top right to bottom left
			//---
			bernd.WarpTo(originalPosition);
			bernd.Heading = originalHeading;
			bernd.Right(120);			
			bernd.Forward(3 * len);
			bernd.Left(120);
			bernd.Forward(len);
			bernd.Left(60);

			for (int j = 0; j < 3; j++)
			{
				bernd.BrushDown = true;
				bernd.Forward(4 * len);
				bernd.BrushDown = false;

				bernd.Forward(-4 * len);
				bernd.Left(60);
				bernd.Forward(len);
				bernd.Right(60);
			}

			


			


			//bernd.WarpTo(originalPosition);
			//bernd.Heading = originalHeading;

			//---
			btn6.IsEnabled = true;
			btn6.Focus();
		}

		private void DrawHexFigure(double len)
		{
			var originalPosition = fred.Position;
			var originalHeading = fred.Heading;
			fred.Stamp();

			fred.BrushDown = false;
			fred.Forward(len);

			for (int i = 0; i < 3; i++)
			{
				fred.BrushDown = true;
				DrawHex(len);

				fred.BrushDown = false;
				fred.Left(120.0);
				fred.Forward(2 * len);
			}

			fred.Right(120.0);
			fred.Forward(2 * len);

			fred.BrushDown = true;
			DrawHex(len);

			// back to origin
			fred.WarpTo(originalPosition);
			//fred.Position = originalPosition;			
		}

		private void DrawHex(double len)
		{
			//fred.Filling = true;
			//fred.FillBrush = new LinearGradientBrush(Colors.Cyan, Colors.Red, 45);

			//fred.Stamp("fred");
			fred.Stamp();

			var middle = fred.Position;
			for (int i = 0; i < 6; i++)
			{
				fred.Forward(len);
				fred.Left(120.0);
				fred.Forward(len);
				fred.WarpTo(middle);
				fred.Right(60.0);
			}
			
			//fred.Filling = false;

			// late edit to testFeature branch?
		}
	}
}
