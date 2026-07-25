using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Mod.FemtoHelper.Entities.Sokoban;

public interface IHistoryAction
{
    public void Do();
    public void Undo();
}
