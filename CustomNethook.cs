using Mastercam.Database;
using Mastercam.IO;
using Mastercam.Database.Types;
using Mastercam.App.Types;

namespace _CustomNethook
{
    public class CustomNethook : Mastercam.App.NetHook3App
    {
        public Mastercam.App.Types.MCamReturn CustomNethookRun(Mastercam.App.Types.MCamReturn notused)
        {
            void offsetCutchain80()
            {
                var selectedCutChain = ChainManager.GetMultipleChains("");
                foreach (var chain in selectedCutChain)
                {
                    chain.Direction = ChainDirectionType.Clockwise;
                    if (chain.Direction == ChainDirectionType.Clockwise)
                    {
                        var lowerChainLarge = chain.OffsetChain2D(OffsetSideType.Right, .0225, OffsetRollCornerType.None, .5, false, .0001, false);
                    }
                    if (chain.Direction == ChainDirectionType.CounterClockwise)
                    {
                        var lowerChainLarge = chain.OffsetChain2D(OffsetSideType.Left, .0225, OffsetRollCornerType.None, .5, false, .0001, false);
                    }
                    GraphicsManager.ClearColors(new GroupSelectionMask(true));
                }
            }
            offsetCutchain80();
            return MCamReturn.NoErrors;
        }
    }
}