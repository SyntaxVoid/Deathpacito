using System;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;

namespace Deathpacito
{
  [ApiVersion(2, 1)]
  public class Deathpacito : TerrariaPlugin
  {
    public override string Author => "Myoni(SyntaxVoid)";
    public override string Description => "Provides a self-kill command.";
    public override string Name => "Deathpacito";
    public override Version Version => new Version(1, 0, 0, 0);

    public Deathpacito(Main game) : base(game)
    {
      base.Order = 1;
    }

    public override void Initialize()
    {
        ServerApi.Hooks.GameInitialize.Register(this, OnInitialize);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        ServerApi.Hooks.GameInitialize.Deregister(this, OnInitialize);
      }
      base.Dispose(disposing);
    }
  
    public void OnInitialize(EventArgs args)
    {
      Commands.ChatCommands
          .Add(new Command("deathpacito.die", DeathpacitoCommand, "deathpacito")
          {
            AllowServer = false,
            HelpText = "Commit die"
          });
    }

    private void DeathpacitoCommand(CommandArgs args)
    {
      TSPlayer player = args.Player;
      player.KillPlayer();
      TShock.Utils.Broadcast($"~Despacito~ {player.Name} has been killed-acito.", 168, 50, 50);
    }
  }
}