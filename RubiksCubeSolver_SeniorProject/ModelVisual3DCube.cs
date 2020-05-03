using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RubiksCubeSolver_SeniorProject
{
	public class ModelVisual3DCube : ModelVisual3D
	{
		public BlockFace3D BlockFace;
		public ModelVisual3DCube(BlockFace3D BlockFace, GeometryModel3D GeometryModel)
		{
			this.BlockFace = BlockFace;
			Content = GeometryModel;
			return;
		}
	}
}
