using System;

namespace mk_management
{
    internal class PC_HwId
    {
        internal static void Calculate()
        {
            try
            {
                var hwId = common.FingerPrint.Value();
                var value = hwId;
            }
            catch (Exception ex)
            {
                common.DataHelper.AgregarBitacoraSistema("PC_HwId.Calculate", ex.Message, true);
            }
        }
    }
}

