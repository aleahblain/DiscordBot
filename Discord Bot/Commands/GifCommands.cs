using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot
{
    [Group("gif")] 
    [Description("Contains random JO1 themed gifs. When invoked without subcommand, returns a random one.")]
    public class GifCommands : BaseCommandModule
    {
        public async Task RandomGif(CommandContext ctx)
        {
            var rnd = new Random();
            var nxt = rnd.Next(0, 2);

            switch (nxt)
            {
                case 0:
                    await JO1(ctx).ConfigureAwait(false);
                    return;

                case 1:
                    await Keigo(ctx).ConfigureAwait(false);
                    return;
                case 2:
                    await Sho(ctx).ConfigureAwait(false);
                    return;
            }
        }

        [Command("jo1")]
        [Description("Returns a gif of the group.")]
        public async Task JO1(CommandContext ctx)
        {
            String[] gifs = {"https://i2.wp.com/66.media.tumblr.com/13157315cdd956bab44a286b586152f4/ba67ad5e1d616a64-cc/s540x810/5772354ea03111bb6819f8188d10aed5f0ebc1e5.gif", "https://media1.tenor.com/images/335bdadc29156b8c4e23e3d373319f34/tenor.gif",
                    "https://thumbs.gfycat.com/UnripeFakeLice-size_restricted.gif", "https://i2.wp.com/66.media.tumblr.com/186b2cc14eb44d06854ac5436cb3b791/70816c9500517f40-28/s540x810/16d9f7517d077fba2714a5c59d87bd2f8fa5122b.gif" };
            var random = new Random();
            int choice = random.Next(0, gifs.Length);
            var embed = new DiscordEmbedBuilder
            {
                Title = "Here's JO1!",
                ImageUrl = gifs[choice]
            };

            await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
            random = new Random();
            choice = random.Next(0, gifs.Length);
        }

        [Command("keigo")]
        [Description("Returns a gif of Keigo.")]
        public async Task Keigo(CommandContext ctx)
        {
            String[] gifs = {"https://66.media.tumblr.com/1ef51441c0b007a8c9b2d7dc3e7a702e/11e2d32c25e0583c-d9/s400x600/887580c71c1de0c52f09e0c7fe4121059f3e0d7e.gif", "https://thumbs.gfycat.com/NiceUnpleasantHarrier-size_restricted.gif", 
                    "https://66.media.tumblr.com/4e5fc0dad33c38c7843c870cac52ad73/59fb80dec77b6bbf-4a/s250x400/42850138bb9a3fec538a843a1bcc8f9daf671cc7.gifv", "https://66.media.tumblr.com/fc1e5dd319246f9a52e03a421af47c6c/11e2d32c25e0583c-c3/s250x400/8e759300b885b81e7d3ac566e742870a45566f73.gif" };
            var random = new Random();
            int choice = random.Next(0, gifs.Length);
            var embed = new DiscordEmbedBuilder
            {
                    Title = "Have a Keigo!",
                    ImageUrl = gifs[choice]
            };

            await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
            random = new Random();
            choice = random.Next(0, gifs.Length);
        }

        [Command("sho")]
        [Aliases("yona", "yonashiro")]
        [Description("Returns a gif of Sho.")]
        public async Task Sho(CommandContext ctx)
        {
            String[] gifs = {"https://twitter.com/i/status/1268542061743046656", "https://twitter.com/i/status/1269935926894977026",
                    "https://twitter.com/i/status/1265614736931971074", "https://twitter.com/i/status/1265606190337122304" };
            var random = new Random();
            int choice = random.Next(0, gifs.Length);
            var embed = new DiscordEmbedBuilder
            {
                Title = "Have a Sho!",
                ImageUrl = gifs[choice]
            };

            await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
            random = new Random();
            choice = random.Next(0, gifs.Length);
        }

        [Command("shosei")]
        [Aliases("pudding")]
        [Description("Returns a gif of Shosei.")]
        public async Task Shosei(CommandContext ctx)
        {
            String[] gifs = {"https://media.discordapp.net/attachments/717191084702433300/720369057123008614/image0.gif" };
            var random = new Random();
            int choice = random.Next(0, gifs.Length);
            var embed = new DiscordEmbedBuilder
            {
                Title = "Have a Shosei!",
                ImageUrl = gifs[choice]
            };

            await ctx.RespondAsync(embed: embed).ConfigureAwait(false);
            random = new Random();
            choice = random.Next(0, gifs.Length);
        }

    }
}
