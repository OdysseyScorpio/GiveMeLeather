using Verse;
using RimWorld;

namespace GiveMeLeather
{
  public class StatPart_LeatherAmount : StatPart
  {
    float leatherMultiplier = GiveMeLeatherSettings.LeatherAmountToMultiply;

    public override void TransformValue(StatRequest req, ref float val)
    {
      val *= leatherMultiplier;
    }

    public override string ExplanationPart(StatRequest req)
    {
      return "GMLstatDescription".Translate() + ": x" + leatherMultiplier.ToStringPercent();
    }
  }
}
