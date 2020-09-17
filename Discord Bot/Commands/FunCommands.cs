using Discord_Bot.Handlers.Dialogues;
using Discord_Bot.Handlers.Dialogues.Steps;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Discord_Bot.Commands
{
    public class FunCommands : BaseCommandModule

    {
        [Command("quote")]
        [Description("Returns a random JO1 quote")]
        public async Task Quote(CommandContext ctx)
        {
            String[] a = { "Go to the top, JO1!", "I'm 64 what do I know about Japanese boybands?", "Ren: Have you been a good girl?", 
                "Keigo: Ao!", "Syoya: I feel like throwing up.", "Takumi: Kobi kobi!", "Mame: You hag!", 
                "Sho: Machine gun!", "Junki: I'm actually quite sick of carbonara.", 
                "Ruki: Your prince has arrived", "Shion: [stares]", "Sukai: SEE YOU!", "Shosei: Purin is watching.", "Takumi: Baka!",
                "Ren: Mugendai Challenge time!", "Sho: Haisai!", "Keigo: The ocean is salty."};
            var random = new Random();
            int choice = random.Next(0, a.Length);
            await ctx.Channel.SendMessageAsync(a[choice]).ConfigureAwait(false);

            random = new Random();
            choice = random.Next(0, a.Length);

        }

        [Command("class")]
        [Description("Returns a random PD101 class rank")]
        public async Task Class(CommandContext ctx)
        {
            String[] a = { "A", "B", "C", "D", "F"};
            var random = new Random();
            int choice = random.Next(0, a.Length);
            if(a[choice] == "D" || a[choice] == "F")
                await ctx.Channel.SendMessageAsync("Your rank is " + a[choice] + ". Damn, who even let you in here?").ConfigureAwait(false);
            else if(a[choice] == "B" || a[choice] == "C")
                await ctx.Channel.SendMessageAsync("Your rank is " + a[choice] + ". Not too shabby.").ConfigureAwait(false);
            else
                await ctx.Channel.SendMessageAsync("Your rank is " + a[choice] + ". Wow very cool much talent!").ConfigureAwait(false);

            random = new Random();
            choice = random.Next(0, a.Length);

        }


        [Command("rank")]
        [Description("Gives you a PD101 rank!")]
        public async Task Rank(CommandContext ctx)
        {
           
            var random = new Random();
            int rank = random.Next(1, 102);

            if(rank <= 11)
                await ctx.Channel.SendMessageAsync("Your rank is: " + rank + "! Congratulations, you're debuting!").ConfigureAwait(false);
            else
                await ctx.Channel.SendMessageAsync("Your rank is: " + rank + "! You flopped and didn't debut.").ConfigureAwait(false);

            random = new Random();
            rank = random.Next(1, 102);

        }

        [Command("story")]
        [Description("Generates a random scenario")]
        public async Task Story(CommandContext ctx)
        {
            String[] memberList = { "Sho.", "Ren.", "Ruki.", "Junki.", "Keigo.", "Takumi.", "Syoya.", "Shosei.", "Sukai.", "Shion.", 
                "Mame.", "Naoto-san.", "Kanada-san.", "Kamome-chan.", "Purin.", "Milfy." };
            var random = new Random();
            int member = random.Next(0, memberList.Length);

            String[] actionList = {"punched ", "kissed ", "hugged ", "slapped ", "completely obliterated ", "had a nice picnic with " , "held hands with ",
                "cried hopelessly with ", "got married to ", "debuted with ", "got sent hate mail from ", "went to a furry convention with ",
                "got sent to the ER by ", "got hacked by ", "got serenaded by ", "did the mugendai challenge with ", "read fan fic about ", 
                "got killed by ", "cuddled with ", "got stuck in an elevator with ", "bit ", "got bitten by ", "played Super Smash Bros and lost against "};
            var random2 = new Random();
            int action = random2.Next(0, actionList.Length);

            String[] endingList = {" Should've minded your own business.", " Good for you!", " Sucks to be you!", " Flop.", " Hooray!", 
                " How sad.", " Would your mother be proud?", " That's very sexy of you."};
            var random3 = new Random();
            int ending = random3.Next(0, endingList.Length);

            await ctx.Channel.SendMessageAsync("Today you " + actionList[action] + memberList[member] + endingList[ending]).ConfigureAwait(false);

            random = new Random();
            member = random.Next(0, memberList.Length);
            random2 = new Random();
            action = random2.Next(0, actionList.Length);
            random3 = new Random();
            ending = random3.Next(0, endingList.Length);

        }

        [Command("add")]
        [Description("Adds the inputed two numbers together")]
        public async Task Add(CommandContext ctx,[Description ("first number")] int numberOne, 
            [Description ("second number")] int numberTwo)
        {
            await ctx.Channel.
                SendMessageAsync((numberOne + numberTwo).
                ToString()).ConfigureAwait(false);
        }

        [Command("ResponseMessage")]
        public async Task ResponseMessage(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync(message.Result.Content);

        }

        [Command("ResponseReaction")]
        public async Task ResponseEmoji(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var message = await interactivity.WaitForReactionAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);
            await ctx.Channel.SendMessageAsync(message.Result.Emoji);

        }

        [Command("comp")]
        [Description("Calculated compatibility with a member.")]
        public async Task Dialogue(CommandContext ctx)
        {
 
            var inputStep = new TextStep("Enter someone you want to calculate compatibility with! No need to use '^comp' again in your next message", null);
            string input = string.Empty;
            //var funnystep = new TextStep("Haha funny", null);

            inputStep.OnValidResult += (result) => 
            { 
                input = result;
                //if(result == "something interesting")
                {
                    //inputStep.SetNextStep(funnystep);
                }
            };

            //var userChannel = await ctx.Member.CreateDmChannelAsync().ConfigureAwait(false);
            var inputDialogueHandler = new DialogueHandler(ctx.Client, ctx.Channel, ctx.User, inputStep);
            bool succeeded = await inputDialogueHandler.ProcessDialogue().ConfigureAwait(false);

            if (!succeeded) { return; }

            var random = new Random();
            int percent = random.Next(0, 101);
            await ctx.Channel.SendMessageAsync(ctx.Member.Mention + ", your compatibility with " + input + " is " + percent + "%!" ).ConfigureAwait(false);

        }
    }
}
