using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSolver_SeniorProject
{
	public class SolutionStep
	{
		//The Steps Code
		public StepCode StepCode;

		//Message associated with SolutionStep
		public string Message;

		//Face Number in focus
		public int FaceNo;

		//The Color of the face on the top of the cube
		public int UpFaceColor;

		//The Color of the face in the front of the cube
		public int FrontFaceColor;

		/// <summary>
		/// Solution steps expressed in face color
		/// </summary>
		public int[] Steps;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="StepCode">Solution step code</param>
		/// <param name="Message">Text message</param>
		/// <param name="FaceNo">Face number being moved</param>
		/// <param name="UpFaceColor">Cube up face color</param>
		/// <param name="FrontFaceColor">Cube front face color</param>
		/// <param name="Steps">Solution steps</param>
		public SolutionStep
				(
				StepCode StepCode,
				string Message,
				int FaceNo,
				int UpFaceColor,
				int FrontFaceColor,
				int[] Steps
				)
		{
#if DEBUG
			if (UpFaceColor != Cube.WhiteFace && UpFaceColor != Cube.YellowFace)
				throw new ApplicationException("SolveStep up face must be white or yellow");
#endif

			this.StepCode = StepCode;
			this.Message = Message;
			this.FaceNo = FaceNo;
			this.UpFaceColor = UpFaceColor;
			this.FrontFaceColor = FrontFaceColor;
			this.Steps = Steps;
			return;
		}

		/// <summary>
		/// Constructor for cube is solved
		/// </summary>
		public SolutionStep()
		{
			StepCode = StepCode.CubeIsSolved;
			return;
		}
	}
}
