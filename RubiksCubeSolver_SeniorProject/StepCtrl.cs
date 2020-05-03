﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSolver_SeniorProject
{
	public class StepCtrl
	{
		/// <summary>
		/// Cube up face color (white or yellow)
		/// </summary>
		public int UpFaceColor;

		/// <summary>
		/// solution steps in color for cube front color: blue, red, green and orange
		/// </summary>
		public int[][] StepsArray;

		/// <summary>
		/// Solution steps for front color
		/// </summary>
		/// <param name="Index">0=Blue, 1=Red, 2=Green, 3=Orange</param>
		/// <returns>Steps array</returns>
		public int[] Steps
				(
				int Index // 0=Blue, 1=Red, 2=Green, 3=Orange
				)
		{
#if DEBUG
			if (Index < 0 || Index > 3) throw new ApplicationException("Steps argument must be 0 to 3");
#endif
			return StepsArray[Index];
		}

		/// <summary>
		/// Step control constructor
		/// </summary>
		/// <param name="UpFaceColor">Up face color</param>
		public StepCtrl
				(
				int UpFaceColor,
				params int[] RelativeSteps
				)
		{
#if DEBUG
			// test up face color
			if (UpFaceColor != Cube.WhiteFace && UpFaceColor != Cube.YellowFace)
				throw new ApplicationException("SetpCtrl: Up face must be white or yellow");
#endif

			// save arguments
			this.UpFaceColor = UpFaceColor;

			// test up face color
			int UpDown = UpFaceColor == Cube.WhiteFace ? 0 : 4;

			// create 4 steps arrays one for each color: blue, red, green and organge
			StepsArray = new int[4][];
			for (int Index = 0; Index < 4; Index++)
			{
				// create translation array between relative rotation (U F R B L D) and face colors
				int[] Xlate = Cube.RelativeToColor[UpDown + Index];

				// color rotation
				StepsArray[Index] = new int[RelativeSteps.Length];

				// translate rotation relative to color
				for (int Ptr = 0; Ptr < RelativeSteps.Length; Ptr++)
				{
					// single step (U, F, R, B, L, D)
					int Step = RelativeSteps[Ptr];

#if DEBUG
					if (Step < 0 || Step >= Cube.RotationCodes) throw new ApplicationException("StepCtrl: Relative step error. Must be 0 to 17.");
#endif

					// add rotation step to the list
					StepsArray[Index][Ptr] = 3 * Xlate[Step / 3] + (Step % 3);
				}
			}
			return;
		}
	}
}
