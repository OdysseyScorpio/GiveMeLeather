using UnityEngine;
using Verse;

namespace GiveMeLeather
{
  public class GiveMeLeatherSettings : ModSettings
  {
    public static int LeatherAmountToMultiply => leatherATM;

    // DON'T reference these following var(s) except from inside this class; Reference the above variables instead. ExposeData requires them to be public
    public static int leatherATM = 1;
    // End warning

        public override void ExposeData()
    {
      base.ExposeData();
      Scribe_Values.Look(ref leatherATM, "GMLAmountToMultiply");
    }
  }

  public class GiveMeLeatherMod : Mod
  {
    GiveMeLeatherSettings settings;
    public GiveMeLeatherMod(ModContentPack con) : base(con)
    {
      this.settings = GetSettings<GiveMeLeatherSettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
      Listing_Standard listing = new Listing_Standard();
      listing.Begin(inRect);
      listing.Label("GMLATMLabel".Translate() + " " + (GiveMeLeatherSettings.leatherATM * 100).ToString() + "%");
      GiveMeLeatherSettings.leatherATM = (int)listing.Slider(GiveMeLeatherSettings.leatherATM, 0f, 10f);
      listing.Label("GMLAdviseRestart".Translate());
      listing.End();
      base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
      return "GMLATMTitle".Translate();
    }
  }
}
